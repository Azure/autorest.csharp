// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;

namespace header
{
    internal partial class HeaderResponseByteHeaders
    {
        private readonly Response _response;
        public HeaderResponseByteHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> response with header values "啊齄丂狛狜隣郎隣兀﨩". </summary>
        public byte[] Value => _response.Headers.TryGetValue("value", out byte[] value) ? value : null;
    }
}
