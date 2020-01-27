// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace header
{
    internal class ResponseLongHeaders
    {
        private readonly Response _response;
        public ResponseLongHeaders(Response response)
        {
            _response = response;
        }
        public long? Value => _response.Headers.TryGetValue("value", out long? value) ? value : null;
    }
}
