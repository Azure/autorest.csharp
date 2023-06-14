// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace header
{
    internal partial class HeaderResponseDoubleHeaders
    {
        private readonly Response _response;
        public HeaderResponseDoubleHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> response with header value "value": 7e120 or -3.0. </summary>
        public double? Value => _response.Headers.TryGetValue("value", out double? value) ? value : null;
    }
}
