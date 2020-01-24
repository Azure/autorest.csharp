// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;

namespace header
{
    internal class ResponseByteHeaders
    {
        private readonly Response _response;
        public ResponseByteHeaders(Response response)
        {
            _response = response;
        }
        public byte[] Value => _response.Headers.TryGetValue("value", out byte[] value) ? value : null;
    }
}
