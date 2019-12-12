// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;

namespace header
{
    internal class ResponseExistingKeyHeaders
    {
        private readonly Response _response;
        public ResponseExistingKeyHeaders(Response response)
        {
            _response = response;
        }
        public string? UserAgent => _response.Headers.TryGetValue("User-Agent", out string value) ? value : null;
    }
}
