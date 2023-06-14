// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure;
using Azure.Core;

namespace xml_service
{
    internal partial class XmlGetHeadersHeaders
    {
        private readonly Response _response;
        public XmlGetHeadersHeaders(Response response)
        {
            _response = response;
        }
        /// <summary> A custom response header. </summary>
        public string CustomHeader => _response.Headers.TryGetValue("Custom-Header", out string value) ? value : null;
    }
}
