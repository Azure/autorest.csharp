// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;

namespace ExtensionClientName
{
    internal class OriginalOperationHeaders
    {
        private readonly Azure.Response _response;
        public OriginalOperationHeaders(Azure.Response response)
        {
            _response = response;
        }
        public string? OriginalHeader => _response.Headers.TryGetValue("originalHeader", out string? value) ? value : null;
    }
}
