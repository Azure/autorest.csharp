// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;
using header.Models;

namespace header
{
    internal partial class HeaderResponseEnumHeaders
    {
        private readonly Response _response;
        public HeaderResponseEnumHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> response with header values "GREY" or null. </summary>
        public GreyscaleColors? Value => _response.Headers.TryGetValue("value", out string value) ? value.ToGreyscaleColors() : null;
    }
}
