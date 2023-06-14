// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace header
{
    internal partial class HeaderResponseStringHeaders
    {
        private readonly Response _response;
        public HeaderResponseStringHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> response with header values "The quick brown fox jumps over the lazy dog" or null or "". </summary>
        public string Value => _response.Headers.TryGetValue("value", out string value) ? value : null;
    }
}
