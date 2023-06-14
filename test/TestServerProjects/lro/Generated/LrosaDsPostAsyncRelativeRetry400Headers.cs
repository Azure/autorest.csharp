// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal partial class LrosaDsPostAsyncRelativeRetry400Headers
    {
        private readonly Response _response;
        public LrosaDsPostAsyncRelativeRetry400Headers(Response response)
        {
            _response = response;
        }
        /// <summary> Location to poll for result status: will be set to /lro/nonretryerror/putasync/retry/operationResults/400. </summary>
        public string AzureAsyncOperation => _response.Headers.TryGetValue("Azure-AsyncOperation", out string value) ? value : null;
        /// <summary> Location to poll for result status: will be set to /lro/nonretryerror/putasync/retry/operationResults/400. </summary>
        public string Location => _response.Headers.TryGetValue("Location", out string value) ? value : null;
        /// <summary> Number of milliseconds until the next poll should be sent, will be set to zero. </summary>
        public int? RetryAfter => _response.Headers.TryGetValue("Retry-After", out int? value) ? value : null;
    }
}
