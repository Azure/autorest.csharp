// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;

namespace header
{
    internal class ResponseProtectedKeyHeaders
    {
        private readonly Response _response;
        public ResponseProtectedKeyHeaders(Response response)
        {
            _response = response;
        }
        public string? ContentType => _response.Headers.TryGetValue("Content-Type", out string value) ? value : null;
    }
}
