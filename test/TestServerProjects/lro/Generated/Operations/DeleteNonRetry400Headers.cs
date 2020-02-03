// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal class DeleteNonRetry400Headers
    {
        private readonly Azure.Response _response;
        public DeleteNonRetry400Headers(Azure.Response response)
        {
            _response = response;
        }
        public string Location => _response.Headers.TryGetValue("Location", out string value) ? value : null;
        public int? RetryAfter => _response.Headers.TryGetValue("Retry-After", out int? value) ? value : null;
    }
}
