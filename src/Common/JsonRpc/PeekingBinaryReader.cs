using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AutoRest.JsonRpc
{
    internal class PeekingBinaryReader : IDisposable
    {
        private readonly Stream _stream;

        private byte? _currentByte;
        public byte? CurrentByte
        {
            get
            {
                if (_currentByte.HasValue)
                {
                    return _currentByte.Value;
                }
                var result = GetByte();
                if (result.HasValue)
                {
                    _currentByte = result;
                }
                return result;
            }
        }

        private const int EndOfStream = -1;

        public PeekingBinaryReader(Stream stream)
        {
            _stream = stream;
        }

        private byte? PopCurrentByte()
        {
            if (!_currentByte.HasValue) return null;

            var result = _currentByte.Value;
            _currentByte = null;
            return result;
        }

        // Pops the current byte or reads a new one if there is no current byte
        // Returns null if end-of-stream
        private byte? GetByte()
        {
            if (_currentByte.HasValue) return PopCurrentByte();

            var streamByte = _stream.ReadByte();
            return streamByte != EndOfStream ? (byte?)streamByte : null;
        }

        public async Task<byte[]> ReadBytesAsync(int count)
        {
            var buffer = new byte[count];
            var index = 0;
            if (count > 0 && _currentByte.HasValue)
            {
                // ReSharper disable once PossibleInvalidOperationException
                buffer[index++] = PopCurrentByte().Value;
            }
            while (index < count)
            {
                index += await _stream.ReadAsync(buffer, index, count - index);
            }
            return buffer;
        }

        public string ReadAsciiLine()
        {
            var sb = new StringBuilder();
            var character = GetByte();
            while (character.HasValue && character != '\r' && character != '\n')
            {
                sb.Append((char)character.Value);
                character = GetByte();
            }

            // CurrentByte will only ever be null or a non-line-ending value when this method returns since we read until line ending characters,
            // and discard the last value if it is a '\n' preceded by a '\r'.
            if (character == '\r' && CurrentByte == '\n')
            {
                GetByte();
            }

            return sb.Length != 0 ? sb.ToString() : null;
        }

        public void Dispose()
        {
            _stream.Dispose();
        }
    }
}
