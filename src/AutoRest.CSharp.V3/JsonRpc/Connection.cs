using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc.Messaging;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.JsonRpc
{
    internal delegate string IncomingRequestAction(Connection connection, IncomingRequest request);

#pragma warning disable IDE0069 // Disposable fields should be disposed
    internal sealed class Connection : IDisposable
    {
        private readonly DisposeService<Connection> _disposeService;
        private Stream _outputStream;
        private PeekableBinaryStream _inputStream;
        private readonly Task _listener;

        public CancellationTokenSource CancellationTokenSource { get; private set; } = new CancellationTokenSource();
        private readonly CancellationToken _cancellationToken;

        private readonly ConcurrentDictionary<string, TaskCompletionSource<string>> _responses = new ConcurrentDictionary<string, TaskCompletionSource<string>>();
        private readonly Dictionary<string, IncomingRequestAction> _incomingRequestActions;
        private readonly IncomingMessageProcessor _incomingMessageProcessor;
        private readonly OutgoingMessageProcessor _outgoingMessageProcessor;

        public Connection(Stream inputStream, Stream outputStream, Dictionary<string, IncomingRequestAction> incomingRequestActions = null)
        {
            _disposeService = new DisposeService<Connection>(this, Disposer);
            _cancellationToken = CancellationTokenSource.Token;
            _inputStream = new PeekableBinaryStream(inputStream);
            _outputStream = outputStream;
            _incomingRequestActions = incomingRequestActions ?? new Dictionary<string, IncomingRequestAction>();
            _incomingMessageProcessor = new IncomingMessageProcessor(_inputStream, HandleIncomingRequest, HandleIncomingResponse);
            _outgoingMessageProcessor = new OutgoingMessageProcessor(_outputStream, _cancellationToken);
            _listener = Task.Factory.StartNew(Listen).Unwrap();
        }

        public void Start() => _listener.GetAwaiter().GetResult();

        private async Task<bool> Listen()
        {
            bool IsAlive() => !_cancellationToken.IsCancellationRequested && _outputStream != null && _inputStream != null;
            while (IsAlive() && _incomingMessageProcessor.ProcessStream()) { }
            return false;
        }

        private void HandleIncomingRequest(IncomingRequest request)
        {
            Task.Factory.StartNew(() =>
            {
                if (_incomingRequestActions.TryGetValue(request.Method, out var requestAction))
                {
                    var result = requestAction(this, request);
                    if (!request.Id.IsNullOrEmpty())
                    {
                        _outgoingMessageProcessor.Respond(request.Id, result).GetAwaiter().GetResult();
                    }
                }
            }, _cancellationToken);
        }

        private void HandleIncomingResponse(IncomingResponse response)
        {
            Task.Factory.StartNew(() =>
            {
                if (!response.Id.IsNullOrEmpty())
                {
                    _responses.Remove(response.Id, out var responseTask);
                    responseTask.TrySetResult(response.Result);
                }
            }, _cancellationToken);
        }

        public async Task Notification(string json) => await _outgoingMessageProcessor.Send(json).ConfigureAwait(false);

        public async Task<T> Request<T>(string id, string json)
        {
            var response = new TaskCompletionSource<string>();
            _responses.AddOrUpdate(id, response, (k, e) => response);
            await _outgoingMessageProcessor.Send(json).ConfigureAwait(false);
            return (await response.Task.ConfigureAwait(false)).Parse().ToType<T>();
        }

        public void Dispose()
        {
            _disposeService.Dispose(true);
        }

        private void Disposer(Connection connection)
        {
            foreach (var t in _responses.Values) { t.SetCanceled(); }

            _outputStream?.Dispose();
            _outputStream = null;
            _inputStream?.Dispose();
            _inputStream = null;
            CancellationTokenSource?.Dispose();
            CancellationTokenSource = null;
        }
    }
#pragma warning restore IDE0069 // Disposable fields should be disposed
}