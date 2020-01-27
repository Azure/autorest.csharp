// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace header
{
    internal class ResponseIntegerHeaders
    {
        private readonly Response _response;
        public ResponseIntegerHeaders(Response response)
        {
            _response = response;
        }
        public int? Value => _response.Headers.TryGetValue("value", out int? value) ? value : null;
    }
}
