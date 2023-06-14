// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace header
{
    internal partial class HeaderResponseProtectedKeyHeaders
    {
        private readonly Response _response;
        public HeaderResponseProtectedKeyHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> response with header value "Content-Type": "text/html". </summary>
        public string ContentType => _response.Headers.TryGetValue("Content-Type", out string value) ? value : null;
    }
}
