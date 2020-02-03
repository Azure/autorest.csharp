// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal class PutAsyncNoHeaderInRetryHeaders
    {
        private readonly Azure.Response _response;
        public PutAsyncNoHeaderInRetryHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string AzureAsyncOperation => _response.Headers.TryGetValue("Azure-AsyncOperation", out string value) ? value : null;
    }
}
