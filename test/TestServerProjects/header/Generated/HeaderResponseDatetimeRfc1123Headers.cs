// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;

namespace header
{
    internal partial class HeaderResponseDatetimeRfc1123Headers
    {
        private readonly Response _response;
        public HeaderResponseDatetimeRfc1123Headers(Response response)
        {
            _response = response;
        }
        /// <summary> response with header values "Wed, 01 Jan 2010 12:34:56 GMT" or "Mon, 01 Jan 0001 00:00:00 GMT". </summary>
        public DateTimeOffset? Value => _response.Headers.TryGetValue("value", out DateTimeOffset? value) ? value : null;
    }
}
