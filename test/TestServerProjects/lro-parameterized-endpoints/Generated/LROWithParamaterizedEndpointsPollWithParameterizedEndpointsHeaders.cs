// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro_parameterized_endpoints
{
    internal partial class LROWithParamaterizedEndpointsPollWithParameterizedEndpointsHeaders
    {
        private readonly Response _response;
        public LROWithParamaterizedEndpointsPollWithParameterizedEndpointsHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Url to retrieve the final update resource. Is a relative link. </summary>
        public string Location => _response.Headers.TryGetValue("Location", out string value) ? value : null;
    }
}
