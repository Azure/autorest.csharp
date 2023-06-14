// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace AppConfiguration
{
    internal partial class AppConfigurationCheckLabelsHeaders
    {
        private readonly Response _response;
        public AppConfigurationCheckLabelsHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Enables real-time consistency between requests by providing the returned value in the next request made to the server. </summary>
        public string SyncToken => _response.Headers.TryGetValue("Sync-Token", out string value) ? value : null;
    }
}
