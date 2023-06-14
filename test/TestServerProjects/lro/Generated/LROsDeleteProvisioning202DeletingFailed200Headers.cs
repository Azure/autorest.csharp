// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal partial class LROsDeleteProvisioning202DeletingFailed200Headers
    {
        private readonly Response _response;
        public LROsDeleteProvisioning202DeletingFailed200Headers(Response response)
        {
            _response = response;
        }
        /// <summary> Location to poll for result status: will be set to /lro/delete/provisioning/202/deleting/200/failed. </summary>
        public string Location => _response.Headers.TryGetValue("Location", out string value) ? value : null;
        /// <summary> Number of milliseconds until the next poll should be sent, will be set to zero. </summary>
        public int? RetryAfter => _response.Headers.TryGetValue("Retry-After", out int? value) ? value : null;
    }
}
