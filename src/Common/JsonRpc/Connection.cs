using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.JsonRpc;
using System.Text.Json;
using AutoRest.CSharp.V3.Common.Utilities;

namespace Microsoft.Perks.JsonRPC
{
    public sealed class Connection : IDisposable
    {
        private Stream _writer;
        private PeekingBinaryReader _reader;
        private bool _isDisposed;
        private int _requestId;
        private readonly Dictionary<string, ICallerResponse> _tasks = new Dictionary<string, ICallerResponse>();

        private readonly Task _loop;

        public event Action<string> OnDebug;

        public Connection(Stream writer, Stream input)
        {
            _writer = writer;
            _reader = new PeekingBinaryReader(input);
            _loop = Task.Factory.StartNew(Listen).Unwrap();
        }

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken CancellationToken => _cancellationTokenSource.Token;
        private bool IsAlive => !CancellationToken.IsCancellationRequested && _writer != null && _reader != null;

        public void Stop() => _cancellationTokenSource.Cancel();

        private async Task<JsonElement?> ReadJson()
        {
            var jsonText = string.Empty;
            JsonElement? json = null;
            while (json == null)
            {
                jsonText += _reader.ReadAsciiLine(); // + "\n";

                // try to parse it.
                try
                {
                    json = jsonText.Parse();
                    if (json != null)
                    {
                        return json;
                    }
                }
                catch
                {
                    // not enough text?
                }
            }
            return json;
        }
        private readonly Dictionary<string, Func<JsonElement, Task<string>>> _dispatch = new Dictionary<string, Func<JsonElement, Task<string>>>();
        public void Dispatch<T>(string path, Func<Task<T>> method)
        {
            _dispatch.Add(path, async input =>
            {
                var result = await method();
                return result == null ? "null" : JsonSerializer.Serialize(result);
            });
        }

        private static JsonElement[] ReadArguments(JsonElement input, int expectedArgs)
        {
            var args = input.ValueKind == JsonValueKind.Array ? input.EnumerateArray().ToArray() : null;
            var arg = input.ValueKind == JsonValueKind.Object ? input : (JsonElement?)null;

            if (expectedArgs == 0)
            {
                if (args == null && arg == null)
                {
                    // expected zero, received zero
                    return new JsonElement[0];
                }

                throw new Exception($"Invalid number of arguments {args?.Length} or argument object passed '{arg}' for this call. Expected {expectedArgs}");
            }

            if (args?.Length == expectedArgs)
            {
                // passed as an array
                return args;
            }

            if (expectedArgs == 1)
            {
                if (args?.Length == 0 && arg != null)
                {
                    // passed as an object
                    return new [] { arg.Value };
                }
            }

            throw new Exception($"Invalid number of arguments {args?.Length} for this call. Expected {expectedArgs}");
        }

        public void DispatchNotification(string path, Action method)
        {
            _dispatch.Add(path, async input =>
            {
                method();
                return null;
            });
        }

        public void Dispatch<P1, P2, T>(string path, Func<P1, P2, Task<T>> method)
        {
            _dispatch.Add(path, async input =>
            {
                var args = ReadArguments(input, 2);
                var a1 = args[0].ToObject<P1>();
                var a2 = args[1].ToObject<P2>();

                var result = await method(a1, a2);
                return result == null ? "null" : result.ToJsonValue();
            });
        }

        private async Task<JsonElement?> ReadJson(int contentLength)
        {
            var jsonText = Encoding.UTF8.GetString(await _reader.ReadBytesAsync(contentLength));
            return jsonText.Parse();
        }

        private void Log(string text) => OnDebug?.Invoke(text);

        private async Task<bool> Listen()
        {
            while (IsAlive)
            {
                try
                {
                    var ch = _reader?.CurrentByte;
                    if (-1 == ch)
                    {
                        // didn't get anything. start again, it'll know if we're shutting down
                        break;
                    }

                    if ('{' == ch || '[' == ch)
                    {
                        // looks like a json block or array. let's do this.
                        // don't wait for this to finish!
                        Process(await ReadJson());

                        // we're done here, start again.
                        continue;
                    }

                    // We're looking at headers
                    var headers = new Dictionary<string, string>();
                    var line = _reader?.ReadAsciiLine();
                    while (!string.IsNullOrWhiteSpace(line))
                    {
                        var bits = line.Split(new[] { ':' }, 2);
                        headers.Add(bits[0].Trim(), bits[1].Trim());
                        line = _reader?.ReadAsciiLine();
                    }

                    ch = _reader?.CurrentByte;
                    // the next character had better be a { or [
                    if ('{' == ch || '[' == ch)
                    {
                        if (headers.TryGetValue("Content-Length", out string value) && Int32.TryParse(value, out int contentLength))
                        {
                            // don't wait for this to finish!
                            Process(await ReadJson(contentLength));
                            continue;
                        }
                        // looks like a json block or array. let's do this.
                        // don't wait for this to finish!
                        Process(await ReadJson());
                        // we're done here, start again.
                        continue;
                    }

                    Log("SHOULD NEVER GET HERE!");
                    return false;

                }
                catch (Exception e)
                {
                    if (IsAlive)
                    {
                        Log($"Error during Listen {e.GetType().Name}/{e.Message}/{e.StackTrace}");
                    }
                }
            }
            return false;
        }

        private void Process(JsonElement? content)
        {
            if (content != null && content.Value.ValueKind == JsonValueKind.Object)
            {
                Task.Factory.StartNew(async () => {
                    var jsonObject = content.Value;
                    try
                    {
                        if (jsonObject.EnumerateObject().Any(each => each.Name == "method"))
                        {
                            var method = jsonObject.GetProperty("method").ToString();
                            var id = jsonObject.GetPropertyOrNull("id")?.ToString();
                            // this is a method call.
                            // pass it to the service that is listening...
                            if (_dispatch.TryGetValue(method, out Func<JsonElement, Task<string>> fn))
                            {
                                var parameters = jsonObject.GetProperty("params");
                                var result = await fn(parameters);
                                if (id != null)
                                {
                                    // if this is a request, send the response.
                                    await Respond(id, result);
                                }
                            }
                            return;
                        }

                        // this is a result from a previous call.
                        if (jsonObject.EnumerateObject().Any(each => each.Name == "result"))
                        {
                            var id = jsonObject.GetPropertyOrNull("id")?.ToString();
                            if (!string.IsNullOrEmpty(id))
                            {
                                ICallerResponse f;
                                lock( _tasks )
                                {
                                    f = _tasks[id];
                                    _tasks.Remove(id);
                                }
                                f.SetCompleted(jsonObject.GetProperty("result"));
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.Error.WriteLine(e);
                    }
                });
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            // ensure that we are in a cancelled state.
            _cancellationTokenSource?.Cancel();
            if (_isDisposed) return;
            // make sure we can't dispose twice
            _isDisposed = true;
            if (!disposing) return;

            foreach (var t in _tasks.Values)
            {
                t.SetCancelled();
            }

            _writer?.Dispose();
            _writer = null;
            _reader?.Dispose();
            _reader = null;
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;
            _streamReady?.Dispose();
            _streamReady = null;
        }

        private Semaphore _streamReady = new Semaphore(1, 1);
        private async Task Send(string text)
        {
            _streamReady.WaitOne();

            var buffer = Encoding.UTF8.GetBytes(text);
            await Write(Encoding.ASCII.GetBytes($"Content-Length: {buffer.Length}\r\n\r\n"));
            await Write(buffer);

            _streamReady.Release();
        }
        private Task Write(byte[] buffer) => _writer.WriteAsync(buffer, 0, buffer.Length);

        private async Task Respond(string id, string value)
        {
            await Send(ProtocolExtensions.Response(id, value)).ConfigureAwait(false);
        }

        public async Task Notify(string methodName, params object[] values) => await Send(ProtocolExtensions.Notification(methodName, values)).ConfigureAwait(false);

        public async Task<T> Request<T>(string methodName, params object[] values)
        {
            var id = Interlocked.Decrement(ref _requestId).ToString();
            var response = new CallerResponse<T>(id);
            lock( _tasks ) { _tasks.Add(id, response); }
            await Send(ProtocolExtensions.Request(id, methodName, values)).ConfigureAwait(false);
            return await response.Task.ConfigureAwait(false);
        }

        public TaskAwaiter GetAwaiter() => _loop.GetAwaiter();
    }
}