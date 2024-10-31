// <auto-generated/>

#nullable disable

using System.ClientModel;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace SimplePost
{
    internal class Utf8JsonBinaryContent : BinaryContent
    {
        private readonly MemoryStream _stream;
        private readonly BinaryContent _content;

        public Utf8JsonBinaryContent()
        {
            _stream = new MemoryStream();
            _content = Create(_stream);
            JsonWriter = new Utf8JsonWriter(_stream);
        }

        public Utf8JsonWriter JsonWriter { get; }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellationToken = default)
        {
            await JsonWriter.FlushAsync().ConfigureAwait(false);
            await _content.WriteToAsync(stream, cancellationToken).ConfigureAwait(false);
        }

        public override void WriteTo(Stream stream, CancellationToken cancellationToken = default)
        {
            JsonWriter.Flush();
            _content.WriteTo(stream, cancellationToken);
        }

        public override bool TryComputeLength(out long length)
        {
            length = JsonWriter.BytesCommitted + JsonWriter.BytesPending;
            return true;
        }

        public override void Dispose()
        {
            JsonWriter.Dispose();
            _content.Dispose();
            _stream.Dispose();
        }
    }
}
