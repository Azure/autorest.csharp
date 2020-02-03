// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal class PutAsyncRelativeRetryInvalidJsonPollingHeaders
    {
        private readonly Azure.Response _response;
        public PutAsyncRelativeRetryInvalidJsonPollingHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string AzureAsyncOperation => _response.Headers.TryGetValue("Azure-AsyncOperation", out string value) ? value : null;
        public string Location => _response.Headers.TryGetValue("Location", out string value) ? value : null;
        public int? RetryAfter => _response.Headers.TryGetValue("Retry-After", out int? value) ? value : null;
    }
}
