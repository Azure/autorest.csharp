// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;

namespace header
{
    internal class ResponseEnumHeaders
    {
        private readonly Response _response;
        public ResponseEnumHeaders(Response response)
        {
            _response = response;
        }
        public string? Value => _response.Headers.TryGetValue("Value", out string value) ? value : null;
    }
}
