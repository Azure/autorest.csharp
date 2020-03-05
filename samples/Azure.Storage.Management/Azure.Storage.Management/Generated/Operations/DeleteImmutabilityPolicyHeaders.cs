// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.Storage.Management
{
    internal class DeleteImmutabilityPolicyHeaders
    {
        private readonly Response _response;
        public DeleteImmutabilityPolicyHeaders(Response response)
        {
            _response = response;
        }
        public string ETag => _response.Headers.TryGetValue("ETag", out string value) ? value : null;
    }
}
