// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
        public Byte[]? Value => _response.Headers.TryGetValue("value", out Byte[]? value) ? value : null;
    }
}
