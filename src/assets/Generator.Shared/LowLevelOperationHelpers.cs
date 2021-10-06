// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal static class LowLevelOperationHelpers
    {
#if EXPERIMENTAL
        public static async ValueTask<Operation<BinaryData>> ProcessMessageAsync(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestOptions? requestOptions)
        {
            var response = await pipeline.ProcessMessageAsync(message, clientDiagnostics, requestOptions);
            return new LowLevelFuncOperation<BinaryData>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, r => r.Content);
        }

        public static Operation<BinaryData> ProcessMessage(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestOptions? requestOptions)
        {
            var response = pipeline.ProcessMessage(message, clientDiagnostics, requestOptions);
            return new LowLevelFuncOperation<BinaryData>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, r => r.Content);
        }

        public static async ValueTask<Operation<AsyncPageable<BinaryData>>> ProcessMessageAsync(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestOptions? requestOptions, Func<Response, string?, int?, CancellationToken, IAsyncEnumerable<Page<BinaryData>>> createEnumerable)
        {
            var response = await pipeline.ProcessMessageAsync(message, clientDiagnostics, requestOptions);
            return new LowLevelFuncOperation<AsyncPageable<BinaryData>>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, r => PageableHelpers.CreateAsyncPageable((nl, ps, ct) => createEnumerable(r, nl, ps, ct), clientDiagnostics, scopeName));
        }

        public static Operation<Pageable<BinaryData>> ProcessMessage(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestOptions? requestOptions, Func<Response, string?, int?, IEnumerable<Page<BinaryData>>> createEnumerable)
        {
            var response = pipeline.ProcessMessage(message, clientDiagnostics, requestOptions);
            return new LowLevelFuncOperation<Pageable<BinaryData>>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, r => PageableHelpers.CreatePageable((nl, ps) => createEnumerable(r, nl, ps), clientDiagnostics, scopeName));
        }
#endif
    }
}
