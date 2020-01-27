// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace AppConfiguration
{
    internal class GetKeyValueHeaders
    {
        private readonly Azure.Response _response;
        public GetKeyValueHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string SyncToken => _response.Headers.TryGetValue("Sync-Token", out string value) ? value : null;
        public string ETag => _response.Headers.TryGetValue("ETag", out string value) ? value : null;
        public string LastModified => _response.Headers.TryGetValue("Last-Modified", out string value) ? value : null;
    }
}
