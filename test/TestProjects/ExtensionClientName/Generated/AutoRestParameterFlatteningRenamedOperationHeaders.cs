// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace ExtensionClientName
{
    internal partial class AutoRestParameterFlatteningRenamedOperationHeaders
    {
        private readonly Response _response;
        public AutoRestParameterFlatteningRenamedOperationHeaders(Response response)
        {
            _response = response;
        }
        public string RenamedHeader => _response.Headers.TryGetValue("originalHeader", out string value) ? value : null;
    }
}
