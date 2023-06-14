// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace header
{
    internal partial class HeaderResponseBoolHeaders
    {
        private readonly Response _response;
        public HeaderResponseBoolHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> response with header value "value": true or false. </summary>
        public bool? Value => _response.Headers.TryGetValue("value", out bool? value) ? value : null;
    }
}
