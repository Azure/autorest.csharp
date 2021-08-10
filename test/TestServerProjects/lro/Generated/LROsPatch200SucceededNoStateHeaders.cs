// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal partial class LROsPatch200SucceededNoStateHeaders
    {
        private readonly Response _response;
        public LROsPatch200SucceededNoStateHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Location to poll for result status: will be set to /lro/patchasync/noheader/202/200/operationResults, and this should be ignored by the generated code. </summary>
        public string Location => _response.Headers.TryGetValue("location", out string value) ? value : null;
    }
}
