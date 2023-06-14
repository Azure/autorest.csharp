// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal partial class LROsPutAsyncNoRetrySucceededHeaders
    {
        private readonly Response _response;
        public LROsPutAsyncNoRetrySucceededHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Location to poll for result status: will be set to /lro/putasync/noretry/succeeded/operationResults/200. </summary>
        public string AzureAsyncOperation => _response.Headers.TryGetValue("Azure-AsyncOperation", out string value) ? value : null;
        /// <summary> Location to poll for result status: will be set to /lro/putasync/noretry/succeeded/operationResults/200. </summary>
        public string Location => _response.Headers.TryGetValue("Location", out string value) ? value : null;
    }
}
