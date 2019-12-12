// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;

namespace header
{
    internal class ResponseBoolHeaders
    {
        private readonly Response _response;
        public ResponseBoolHeaders(Response response)
        {
            _response = response;
        }
        public bool? Value => _response.Headers.TryGetValue("value", out bool? value) ? value : null;
    }
}
