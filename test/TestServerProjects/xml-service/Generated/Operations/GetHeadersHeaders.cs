// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;

namespace xml_service
{
    internal class GetHeadersHeaders
    {
        private readonly Azure.Response _response;
        public GetHeadersHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string CustomHeader => _response.Headers.TryGetValue("Custom-Header", out string value) ? value : null;
    }
}
