// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace AppConfiguration
{
    internal class GetLabelsHeaders
    {
        private readonly Azure.Response _response;
        public GetLabelsHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string SyncToken => _response.Headers.TryGetValue("Sync-Token", out string value) ? value : null;
    }
}
