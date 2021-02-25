// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using Azure;
using Azure.Core;

namespace header
{
    internal partial class HeaderResponseDatetimeHeaders
    {
        private readonly Response _response;
        public HeaderResponseDatetimeHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> response with header values &quot;2010-01-01T12:34:56Z&quot; or &quot;0001-01-01T00:00:00Z&quot;. </summary>
        public DateTimeOffset? Value => _response.Headers.TryGetValue("value", out DateTimeOffset? value) ? value : null;
    }
}
