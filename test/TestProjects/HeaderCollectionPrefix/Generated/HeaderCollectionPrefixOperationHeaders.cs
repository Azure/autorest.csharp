// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure;
using Azure.Core;

namespace HeaderCollectionPrefix
{
    internal partial class HeaderCollectionPrefixOperationHeaders
    {
        private readonly Response _response;
        public HeaderCollectionPrefixOperationHeaders(Response response)
        {
            _response = response;
        }
        public IDictionary<string, string> Metadata => _response.Headers.TryGetValue("x-ms-meta-", out IDictionary<string, string> value) ? value : null;
    }
}
