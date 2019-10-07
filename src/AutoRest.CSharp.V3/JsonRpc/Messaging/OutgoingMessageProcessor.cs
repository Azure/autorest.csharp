using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.JsonRpc.Messaging
{
#pragma warning disable IDE0069 // Disposable fields should be disposed
    internal class OutgoingMessageProcessor : IDisposable
    {
        private readonly DisposeService<OutgoingMessageProcessor> _disposeService;
        private readonly Stream _stream;
        private readonly CancellationToken _cancellationToken;
        private Semaphore _streamSemaphore = new Semaphore(1, 1);

        public OutgoingMessageProcessor(Stream stream, CancellationToken cancellationToken)
        {
            _disposeService = new DisposeService<OutgoingMessageProcessor>(this, Disposer);
            _stream = stream;
            _cancellationToken = cancellationToken;
        }

        public async Task Send(string json)
        {
            _streamSemaphore.WaitOne();

            var buffer = Encoding.UTF8.GetBytes(json);
            var header = Encoding.ASCII.GetBytes(OutgoingMessages.Header(buffer.Length));
            await _stream.WriteAsync(header, 0, header.Length, _cancellationToken);
            await _stream.WriteAsync(buffer, 0, buffer.Length, _cancellationToken);

            _streamSemaphore.Release();
        }

        public async Task Respond(string id, string json)
        {
            await Send(OutgoingMessages.Response(id, json)).ConfigureAwait(false);
        }

        public void Dispose()
        {
            _disposeService.Dispose(true);
        }

        private void Disposer(OutgoingMessageProcessor processor)
        {
            _streamSemaphore?.Dispose();
            _streamSemaphore = null;
        }
    }
#pragma warning restore IDE0069 // Disposable fields should be disposed
}
