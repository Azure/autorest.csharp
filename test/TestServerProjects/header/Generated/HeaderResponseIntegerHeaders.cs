// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace header
{
    internal partial class HeaderResponseIntegerHeaders
    {
        private readonly Response _response;
        public HeaderResponseIntegerHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> response with header value "value": 1 or -2. </summary>
        public int? Value => _response.Headers.TryGetValue("value", out int? value) ? value : null;
    }
}
