// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal partial class LROsPatch201RetryWithAsyncHeaderHeaders
    {
        private readonly Response _response;
        public LROsPatch201RetryWithAsyncHeaderHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Location to poll for result status: will be set to /lro/patch/201/retry/onlyAsyncHeader/operationStatuses/201. </summary>
        public string AzureAsyncOperation => _response.Headers.TryGetValue("Azure-AsyncOperation", out string value) ? value : null;
    }
}
