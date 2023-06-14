// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace header
{
    internal partial class HeaderResponseLongHeaders
    {
        private readonly Response _response;
        public HeaderResponseLongHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> response with header value "value": 105 or -2. </summary>
        public long? Value => _response.Headers.TryGetValue("value", out long? value) ? value : null;
    }
}
