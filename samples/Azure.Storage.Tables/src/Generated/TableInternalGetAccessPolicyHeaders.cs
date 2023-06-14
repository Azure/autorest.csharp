// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.Storage.Tables
{
    internal partial class TableInternalGetAccessPolicyHeaders
    {
        private readonly Response _response;
        public TableInternalGetAccessPolicyHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Indicates the version of the Queue service used to execute the request. This header is returned for requests made against version 2009-09-19 and above. </summary>
        public string Version => _response.Headers.TryGetValue("x-ms-version", out string value) ? value : null;
    }
}
