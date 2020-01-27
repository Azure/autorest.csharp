// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;

namespace header
{
    internal class ResponseDurationHeaders
    {
        private readonly Response _response;
        public ResponseDurationHeaders(Response response)
        {
            _response = response;
        }
        public TimeSpan? Value => _response.Headers.TryGetValue("value", out TimeSpan? value) ? value : null;
    }
}
