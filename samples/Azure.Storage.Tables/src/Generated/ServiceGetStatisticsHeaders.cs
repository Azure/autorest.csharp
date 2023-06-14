// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace Azure.Storage.Tables
{
    internal partial class ServiceGetStatisticsHeaders
    {
        private readonly Response _response;
        public ServiceGetStatisticsHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> Indicates the version of the Table service used to execute the request. This header is returned for requests made against version 2009-09-19 and above. </summary>
        public string Version => _response.Headers.TryGetValue("x-ms-version", out string value) ? value : null;
    }
}
