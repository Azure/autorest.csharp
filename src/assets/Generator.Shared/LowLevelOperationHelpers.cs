// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
#if EXPERIMENTAL
    internal static class LowLevelOperationHelpers
    {
        public static async ValueTask<Operation<BinaryData>> ProcessMessageAsync(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, bool waitForCompletion)
        {
            var response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
            var operation = new LowLevelFuncOperation<BinaryData>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, r => r.Content);
            if (waitForCompletion)
            {
                await operation.WaitForCompletionAsync(requestContext?.CancellationToken ?? default).ConfigureAwait(false);
            }
            return operation;
        }

        public static Operation<BinaryData> ProcessMessage(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, bool waitForCompletion)
        {
            var response = pipeline.ProcessMessage(message, requestContext);
            var operation = new LowLevelFuncOperation<BinaryData>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, r => r.Content);
            if (waitForCompletion)
            {
                operation.WaitForCompletion(requestContext?.CancellationToken ?? default);
            }
            return operation;
        }

        public static async ValueTask<Operation<AsyncPageable<BinaryData>>> ProcessMessageAsync(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, bool waitForCompletion, Func<Response, string?, int?, CancellationToken, IAsyncEnumerable<Page<BinaryData>>> createEnumerable)
        {
            var response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
            var operation = new LowLevelFuncOperation<AsyncPageable<BinaryData>>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, r => PageableHelpers.CreateAsyncPageable((nl, ps, ct) => createEnumerable(r, nl, ps, ct), clientDiagnostics, scopeName));
            if (waitForCompletion)
            {
                await operation.WaitForCompletionAsync(requestContext?.CancellationToken ?? default).ConfigureAwait(false);
            }
            return operation;
        }

        public static Operation<Pageable<BinaryData>> ProcessMessage(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, bool waitForCompletion, Func<Response, string?, int?, IEnumerable<Page<BinaryData>>> createEnumerable)
        {
            var response = pipeline.ProcessMessage(message, requestContext);
            var operation = new LowLevelFuncOperation<Pageable<BinaryData>>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, r => PageableHelpers.CreatePageable((nl, ps) => createEnumerable(r, nl, ps), clientDiagnostics, scopeName));
            if (waitForCompletion)
            {
                operation.WaitForCompletion(requestContext?.CancellationToken ?? default);
            }
            return operation;
        }
    }
#endif
}
