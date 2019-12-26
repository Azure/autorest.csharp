// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;

namespace header
{
    internal class ResponseExistingKeyHeaders
    {
        private readonly Azure.Response _response;
        public ResponseExistingKeyHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string? UserAgent => _response.Headers.TryGetValue("User-Agent", out string? value) ? value : null;
    }
}
