// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal partial class LROsPutAsyncNoHeaderInRetryHeaders
    {
        private readonly Response _response;
        public LROsPutAsyncNoHeaderInRetryHeaders(Response response)
        {
            _response = response;
        }
        public string AzureAsyncOperation => _response.Headers.TryGetValue("Azure-AsyncOperation", out string value) ? value : null;
    }
}
