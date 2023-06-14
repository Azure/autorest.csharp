// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace header
{
    internal partial class HeaderResponseExistingKeyHeaders
    {
        private readonly Response _response;
        public HeaderResponseExistingKeyHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> response with header value "User-Agent": "overwrite". </summary>
        public string UserAgent => _response.Headers.TryGetValue("User-Agent", out string value) ? value : null;
    }
}
