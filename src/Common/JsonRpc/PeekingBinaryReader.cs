using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AutoRest.JsonRpc
{
    internal class PeekingBinaryReader : IDisposable
    {
        private byte? _lastByte;
        private readonly Stream _input;

        public PeekingBinaryReader(Stream input)
        {
            _lastByte = null;
            _input = input;
        }

        private int ReadByte()
        {
            if (!_lastByte.HasValue) return _input.ReadByte();

            var result = _lastByte.Value;
            _lastByte = null;
            return result;
        }

        public int PeekByte()
        {
            if (_lastByte.HasValue)
            {
                return _lastByte.Value;
            }
            var result = ReadByte();
            if (result != -1)
            {
                _lastByte = (byte)result;
            }
            return result;
        }

        public async Task<byte[]> ReadBytesAsync(int count)
        {
            var buffer = new byte[count];
            var read = 0;
            if (count > 0 && _lastByte.HasValue)
            {
                buffer[read++] = _lastByte.Value;
                _lastByte = null;
            }
            while (read < count)
            {
                read += await _input.ReadAsync(buffer, read, count - read);
            }
            return buffer;
        }

        public string ReadAsciiLine()
        {
            var result = new StringBuilder();
            var c = ReadByte();
            while (c != '\r' && c != '\n' && c != -1)
            {
                result.Append((char)c);
                c = ReadByte();
            }
            if (c == '\r' && PeekByte() == '\n')
            {
                ReadByte();
            }
            if (c == -1 && result.Length == 0)
            {
                return null;
            }
            return result.ToString();
        }

        public void Dispose()
        {
            _input.Dispose();
        }
    }
}
