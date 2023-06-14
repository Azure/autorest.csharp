// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;

namespace header
{
    internal partial class HeaderResponseDateHeaders
    {
        private readonly Response _response;
        public HeaderResponseDateHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> response with header values "2010-01-01" or "0001-01-01". </summary>
        public DateTimeOffset? Value => _response.Headers.TryGetValue("value", out DateTimeOffset? value) ? value : null;
    }
}
