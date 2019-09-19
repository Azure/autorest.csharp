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
    public delegate Task<bool> ProcessMethod(Connection connection, string pluginName, string sessionId);
    public delegate Task<string> DispatchMethod(JsonElement jsonElement);

#pragma warning disable IDE0069 // Disposable fields should be disposed
    public sealed class Connection : IDisposable
    {
        private readonly DisposeService<Connection> _disposeService;

        private Stream _writer;
        private PeekingBinaryReader _reader;
        private readonly Task _loop;

        private int _requestId;
        private readonly Dictionary<string, ICallerResponse> _tasks = new Dictionary<string, ICallerResponse>();
        private readonly Dictionary<string, DispatchMethod> _dispatch;

        public Connection(Stream inputStream, Stream outputStream, ProcessMethod processMethod, params string[] pluginNames)
        {
            _disposeService = new DisposeService<Connection>(this, Disposer);

            _reader = new PeekingBinaryReader(inputStream);
            _writer = outputStream;
            _dispatch = new Dictionary<string, DispatchMethod>
            {
                { "GetPluginNames", async je => pluginNames.ToJsonArray() },
                { "Process", async je => await RunProcessor(je, processMethod) },
                { "Shutdown", async je => { Stop(); return null; } }
            };

            _loop = Task.Factory.StartNew(Listen).Unwrap();
        }

        private async Task<string> RunProcessor(JsonElement jsonElement, ProcessMethod processMethod)
        {
            var elements = jsonElement.Unwrap().Select(je => je.GetString()).ToArray();
            return (await processMethod(this, elements[0], elements[1])).ToJsonBool();
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

        private void Process(JsonElement? element)
        {
            if (element == null || element.Value.ValueKind != JsonValueKind.Object) return;

            Task.Factory.StartNew(async () =>
            {
                var properties = element.Value.EnumerateObject().Select(p => (JsonProperty?)p).ToArray();
                var methodProperty = properties.GetPropertyOrNull("method");
                var resultProperty = properties.GetPropertyOrNull("result");
                var idString = properties.GetPropertyOrNull("id")?.Value.ToString();
                var isValidId = !String.IsNullOrEmpty(idString);

                // this is a method call.
                // pass it to the service that is listening...
                if (methodProperty != null)
                {
                    if (_dispatch.TryGetValue(methodProperty.Value.Value.ToString(), out var dispatchMethod))
                    {
                        var parameters = properties.GetPropertyOrNull("params");
                        var result = await dispatchMethod(parameters?.Value ?? new JsonElement());
                        if (isValidId)
                        {
                            // if this is a request, send the response.
                            await Respond(idString, result);
                        }
                    }
                    return;
                }

                // this is a result from a previous call.
                if (resultProperty != null && isValidId)
                {
                    ICallerResponse response;
                    lock (_tasks)
                    {
                        response = _tasks[idString];
                        _tasks.Remove(idString);
                    }
                    response.SetCompleted(resultProperty.Value.Value);
                }
            }, CancellationToken);
        }

        private Semaphore _streamReady = new Semaphore(1, 1);
        public async Task Send(string text)
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

        public async Task<T> Request2<T>(string request)
        {
            var id = _requestId.ToString();
            var response = new CallerResponse<T>(id);
            lock (_tasks) { _tasks.Add(id, response); }
            await Send(request).ConfigureAwait(false);
            return await response.Task.ConfigureAwait(false);
        }

        public int NewRequestId => Interlocked.Decrement(ref _requestId);
    }
#pragma warning restore IDE0069 // Disposable fields should be disposed
}