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
    public delegate Task<bool> Processor(Connection connection, string pluginName, string sessionId);

#pragma warning disable IDE0069 // Disposable fields should be disposed
    public sealed class Connection : IDisposable
    {
        private readonly DisposeService<Connection> _disposeService;

        private Stream _writer;
        private PeekingBinaryReader _reader;
        private readonly Task _loop;

        private int _requestId;
        private readonly Dictionary<string, ICallerResponse> _tasks = new Dictionary<string, ICallerResponse>();
        private readonly Dictionary<string, Func<JsonElement, Task<string>>> _dispatch;

        //connection.Dispatch<IEnumerable<string>>("GetPluginNames", async() => new[] { "csharp-v3" });
        //connection.Dispatch<string, string, bool>("Process", (plugin, sessionId) => new Dispatcher(connection, plugin, sessionId).Process());
        //connection.Dispatch("Shutdown", connection.Stop);

        public Connection(Stream inputStream, Stream outputStream, Processor processor, params string[] pluginNames)
        {
            _disposeService = new DisposeService<Connection>(this, Disposer);

            _reader = new PeekingBinaryReader(inputStream);
            _writer = outputStream;
            _dispatch = new Dictionary<string, Func<JsonElement, Task<string>>>
            {
                { "GetPluginNames", async je => pluginNames.ToJsonArray() },
                { "Process", async je => await RunProcessor(je, processor) },
                { "Shutdown", async je => { Stop(); return null; } }
            };

            _loop = Task.Factory.StartNew(Listen).Unwrap();
        }

        private async Task<string> RunProcessor(JsonElement jsonElement, Processor processor)
        {
            var elements = jsonElement.Unwrap().Select(je => je.GetString()).ToArray();
            return (await processor(this, elements[0], elements[1])).ToJsonBool();
        }

        public void Dispose()
        {
            _disposeService.Dispose(true);
        }

        private void Disposer(Connection connection)
        {
            lock (_tasks)
            {
                foreach (var t in _tasks.Values)
                {
                    t.SetCancelled();
                }
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

        public TaskAwaiter GetAwaiter() => _loop.GetAwaiter();

        private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private CancellationToken CancellationToken => _cancellationTokenSource.Token;
        private bool IsAlive => !CancellationToken.IsCancellationRequested && _writer != null && _reader != null;

        private void Stop() => _cancellationTokenSource.Cancel();

        private async Task<JsonElement?> ReadJson()
        {
            var text = String.Empty;
            var nextLine = _reader.ReadAsciiLine();
            JsonElement? element = null;
            while (nextLine != null)
            {
                text += nextLine;
                element = text.Parse();
                if (element != null) break;

                nextLine = _reader.ReadAsciiLine();
            }
            return element;
        }


        //private JsonElement _shutdown;
        //private JsonElement _pluginNames;
        //private JsonElement _process;
        //private string _serializedBool;

        //public void Dispatch(string path, Action method) =>
        //    _dispatch.Add(path, async input =>
        //    {
        //        _shutdown = input;
        //        method();
        //        return null;
        //    });

        //public void Dispatch<TResult>(string path, Func<Task<TResult>> method) =>
        //    _dispatch.Add(path, async input =>
        //    {
        //        _pluginNames = input;
        //        var result = await method();
        //        return result == null ? "null" : JsonSerializer.Serialize(result);
        //    });

        //public void Dispatch<T1, T2, TResult>(string path, Func<T1, T2, Task<TResult>> method) =>
        //    _dispatch.Add(path, async input =>
        //    {
        //        _process = input;
        //        var args = input.Unwrap();
        //        if (args.Length < 2)
        //        {
        //            throw new Exception("Invalid number of arguments. Expected at least 2 arguments.");
        //        }

        //        var a1 = args[0].ToObject<T1>();
        //        var a2 = args[1].ToObject<T2>();

        //        var result = await method(a1, a2);
        //        _serializedBool = result.ToJsonValue();
        //        return result == null ? "null" : result.ToJsonValue();
        //    });

        private async Task<JsonElement?> ReadJson(int contentLength) => Encoding.UTF8.GetString(await _reader.ReadBytesAsync(contentLength)).Parse();

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

                    //Log("SHOULD NEVER GET HERE!");
                    return false;

                }
                catch (Exception)
                {
                    //if (IsAlive)
                    //{
                    //    Log($"Error during Listen {e.GetType().Name}/{e.Message}/{e.StackTrace}");
                    //}
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
            lock(_tasks) { _tasks.Add(id, response); }
            await Send(ProtocolExtensions.Request(id, methodName, values)).ConfigureAwait(false);
            return await response.Task.ConfigureAwait(false);
        }
    }
#pragma warning restore IDE0069 // Disposable fields should be disposed
}