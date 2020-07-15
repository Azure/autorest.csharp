// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.Storage.Tables
{
    internal class TableInternalSetAccessPolicyHeaders
    {
        private readonly Response _response;
        public TableInternalSetAccessPolicyHeaders(Response response)
        {
            _response = response;
        }
        public string Version => _response.Headers.TryGetValue("x-ms-version", out string value) ? value : null;
    }
}
