// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace lro
{
    internal partial class LROsPatch200SucceededIgnoreHeadersHeaders
    {
        private readonly Response _response;
        public LROsPatch200SucceededIgnoreHeadersHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> This header should be ignored in this case. </summary>
        public string AzureAsyncOperation => _response.Headers.TryGetValue("Azure-AsyncOperation", out string value) ? value : null;
    }
}
