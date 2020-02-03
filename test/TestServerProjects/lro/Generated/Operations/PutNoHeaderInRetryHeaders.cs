// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal class PutNoHeaderInRetryHeaders
    {
        private readonly Azure.Response _response;
        public PutNoHeaderInRetryHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string Location => _response.Headers.TryGetValue("location", out string value) ? value : null;
    }
}
