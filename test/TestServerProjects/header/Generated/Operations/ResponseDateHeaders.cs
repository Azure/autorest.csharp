// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;

namespace header
{
    internal class ResponseDateHeaders
    {
        private readonly Response _response;
        public ResponseDateHeaders(Response response)
        {
            _response = response;
        }
        public string? Value => _response.Headers.TryGetValue("value", out string value) ? value : null;
    }
}
