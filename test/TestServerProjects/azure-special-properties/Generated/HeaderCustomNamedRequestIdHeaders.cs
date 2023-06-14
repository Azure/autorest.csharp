// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace azure_special_properties
{
    internal partial class HeaderCustomNamedRequestIdHeaders
    {
        private readonly Response _response;
        public HeaderCustomNamedRequestIdHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Gets the foo-request-id. </summary>
        public string FooRequestId => _response.Headers.TryGetValue("foo-request-id", out string value) ? value : null;
    }
}
