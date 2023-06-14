// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace httpInfrastructure
{
    internal partial class HttpRedirectsPut307Headers
    {
        private readonly Response _response;
        public HttpRedirectsPut307Headers(Response response)
        {
            _response = response;
        }
        /// <summary> The redirect location for this request. </summary>
        public string Location => _response.Headers.TryGetValue("Location", out string value) ? value : null;
    }
}
