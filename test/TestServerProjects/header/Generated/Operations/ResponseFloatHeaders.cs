// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure;
using Azure.Core;

namespace header
{
    internal class ResponseFloatHeaders
    {
        private readonly Response _response;
        public ResponseFloatHeaders(Response response)
        {
            _response = response;
        }
        public float? Value => _response.Headers.TryGetValue("value", out float? value) ? value : null;
    }
}
