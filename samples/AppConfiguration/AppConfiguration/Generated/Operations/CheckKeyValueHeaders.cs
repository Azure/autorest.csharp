// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;

namespace AppConfiguration
{
    internal class CheckKeyValueHeaders
    {
        private readonly Response _response;
        public CheckKeyValueHeaders(Response response)
        {
            _response = response;
        }
        public string? SyncToken => _response.Headers.TryGetValue("Sync-Token", out string? value) ? value : null;
        public string? ETag => _response.Headers.TryGetValue("ETag", out string? value) ? value : null;
        public string? LastModified => _response.Headers.TryGetValue("Last-Modified", out string? value) ? value : null;
    }
}
