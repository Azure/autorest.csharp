// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure;
using Azure.Core;

namespace header
{
    internal partial class HeaderResponseDurationHeaders
    {
        private readonly Response _response;
        public HeaderResponseDurationHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> response with header values "P123DT22H14M12.011S". </summary>
        public TimeSpan? Value => _response.Headers.TryGetValue("value", out TimeSpan? value) ? value : null;
    }
}
