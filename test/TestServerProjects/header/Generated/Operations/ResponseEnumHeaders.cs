// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;
using header.Models;

namespace header
{
    internal class ResponseEnumHeaders
    {
        private readonly Response _response;
        public ResponseEnumHeaders(Response response)
        {
            _response = response;
        }
        public GreyscaleColors? Value => _response.Headers.TryGetValue("value", out GreyscaleColors? value) ? value : null;
    }
}
