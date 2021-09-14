// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal class LowLevelBinaryDataOperation : FuncOperation<BinaryData>
    {
        internal LowLevelBinaryDataOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, string scopeName) :
            base(clientDiagnostics, pipeline, request, response, finalStateVia, scopeName, ResponseBodySelector)
        {

        }

        private static BinaryData ResponseBodySelector(Response r) => r.Content;
    }
}
