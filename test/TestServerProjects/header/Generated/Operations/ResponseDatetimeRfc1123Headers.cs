// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;

namespace header
{
    internal class ResponseDatetimeRfc1123Headers
    {
        private readonly Response _response;
        public ResponseDatetimeRfc1123Headers(Response response)
        {
            _response = response;
        }
        public DateTimeOffset? Value => _response.Headers.TryGetValue("value", out DateTimeOffset? value) ? value : null;
    }
}
