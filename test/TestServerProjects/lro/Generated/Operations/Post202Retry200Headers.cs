// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal class Post202Retry200Headers
    {
        private readonly Response _response;
        public Post202Retry200Headers(Response response)
        {
            _response = response;
        }
        public string Location => _response.Headers.TryGetValue("Location", out string value) ? value : null;
        public int? RetryAfter => _response.Headers.TryGetValue("Retry-After", out int? value) ? value : null;
    }
}
