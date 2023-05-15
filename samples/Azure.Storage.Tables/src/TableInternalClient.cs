// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Storage.Tables
{
    [CodeGenClient("TableClient")]
    internal partial class TableInternalClient
    {
        public ClientDiagnostics Diagnostics => _clientDiagnostics;
        public HttpPipeline Pipeline => _pipeline;
    }
}
