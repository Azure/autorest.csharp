// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;
using Azure.Core;

namespace AppConfiguration
{
    internal class ServiceGetKeyValueHeaders
    {
        private readonly Response _response;
        public ServiceGetKeyValueHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Enables real-time consistency between requests by providing the returned value in the next request made to the server. </summary>
        public string SyncToken => _response.Headers.TryGetValue("Sync-Token", out string value) ? value : null;
        /// <summary> A UTC datetime that specifies the last time the resource was modified. </summary>
        public string LastModified => _response.Headers.TryGetValue("Last-Modified", out string value) ? value : null;
    }
}
