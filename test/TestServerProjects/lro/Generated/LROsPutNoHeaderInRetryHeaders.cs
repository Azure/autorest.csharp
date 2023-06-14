// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal partial class LROsPutNoHeaderInRetryHeaders
    {
        private readonly Response _response;
        public LROsPutNoHeaderInRetryHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Location to poll for result status: will be set to /lro/putasync/noheader/202/200/operationResults. </summary>
        public string Location => _response.Headers.TryGetValue("location", out string value) ? value : null;
    }
}
