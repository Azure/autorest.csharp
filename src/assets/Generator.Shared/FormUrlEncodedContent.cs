// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Core
{
    internal class FormUrlEncodedContent : RequestContent
    {
        internal class Builder
        {
            private List<KeyValuePair<string?, string?>> Values = new List<KeyValuePair<string?, string?>>();

            public Builder ()
            {
            }

            public void Add (string parameter, string value)
            {
                Values.Add(new KeyValuePair<string?, string?> (parameter, value));
            }

            public FormUrlEncodedContent Build ()
            {
                return new FormUrlEncodedContent(Values);
            }
        }

        private Encoding Latin1 = Encoding.GetEncoding("iso-8859-1");
        private readonly byte[] _bytes;

        internal FormUrlEncodedContent(IEnumerable<KeyValuePair<string?, string?>> nameValueCollection)
        {
            _bytes = GetContentByteArray(nameValueCollection);
        }

        public override async Task WriteToAsync(Stream stream, CancellationToken cancellation)
        {
            await stream.WriteAsync(_bytes, 0, _bytes.Length, cancellation).ConfigureAwait(false);
        }

        public override void WriteTo(Stream stream, CancellationToken cancellation)
        {
            stream.Write(_bytes, 0, _bytes.Length);
        }

        public override bool TryComputeLength(out long length)
        {
            length = _bytes.Length;
            return true;
        }

        public override void Dispose()
        {
        }

        // Taken with love from https://github.com/dotnet/runtime/blob/master/src/libraries/System.Net.Http/src/System/Net/Http/FormUrlEncodedContent.cs#L21-L53
        private byte[] GetContentByteArray(IEnumerable<KeyValuePair<string?, string?>> nameValueCollection)
        {
            if (nameValueCollection == null)
            {
                throw new ArgumentNullException(nameof(nameValueCollection));
            }

            // Encode and concatenate data
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string?, string?> pair in nameValueCollection)
            {
                if (builder.Length > 0)
                {
                    builder.Append('&');
                }

                builder.Append(Encode(pair.Key));
                builder.Append('=');
                builder.Append(Encode(pair.Value));
            }

            return Latin1.GetBytes(builder.ToString());
        }

        private static string Encode(string? data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return string.Empty;
            }
            // Escape spaces as '+'.
            return Uri.EscapeDataString(data).Replace("%20", "+");
        }
    }
}
