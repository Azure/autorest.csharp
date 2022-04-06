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
    internal static class LowLevelOperationHelpers
    {
        public static ValueTask<Operation<BinaryData>> ProcessMessageAsync(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, WaitUntil waitUntil)
            => ProcessMessageAsync(pipeline, message, clientDiagnostics, scopeName, finalStateVia, requestContext, waitUntil, r => r.Content);

        public static Operation<BinaryData> ProcessMessage(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, WaitUntil waitUntil)
            => ProcessMessage(pipeline, message, clientDiagnostics, scopeName, finalStateVia, requestContext, waitUntil, r => r.Content);

        public static async ValueTask<Operation<T>> ProcessMessageAsync<T>(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, WaitUntil waitUntil, Func<Response, T> resultSelector) where T: notnull
        {
            var response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
            var operation = new LowLevelFuncOperation<T>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, resultSelector);
            if (waitUntil == WaitUntil.Completed)
            {
                await operation.WaitForCompletionAsync(requestContext?.CancellationToken ?? default).ConfigureAwait(false);
            }
            return operation;
        }

        public static Operation<T> ProcessMessage<T>(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, WaitUntil waitUntil, Func<Response, T> resultSelector) where T : notnull
        {
            var response = pipeline.ProcessMessage(message, requestContext);
            var operation = new LowLevelFuncOperation<T>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, resultSelector);
            if (waitUntil == WaitUntil.Completed)
            {
                operation.WaitForCompletion(requestContext?.CancellationToken ?? default);
            }
            return operation;
        }

        public static async ValueTask<Operation<AsyncPageable<BinaryData>>> ProcessMessageAsync(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, WaitUntil waitUntil, Func<Response, string?, int?, CancellationToken, IAsyncEnumerable<Page<BinaryData>>> createEnumerable)
        {
            var response = await pipeline.ProcessMessageAsync(message, requestContext).ConfigureAwait(false);
            var operation = new LowLevelFuncOperation<AsyncPageable<BinaryData>>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, r => PageableHelpers.CreateAsyncPageable((nl, ps, ct) => createEnumerable(r, nl, ps, ct), clientDiagnostics, scopeName));
            if (waitUntil == WaitUntil.Completed)
            {
                await operation.WaitForCompletionAsync(requestContext?.CancellationToken ?? default).ConfigureAwait(false);
            }
            return operation;
        }

        public static Operation<Pageable<BinaryData>> ProcessMessage(HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, string scopeName, OperationFinalStateVia finalStateVia, RequestContext? requestContext, WaitUntil waitUntil, Func<Response, string?, int?, IEnumerable<Page<BinaryData>>> createEnumerable)
        {
            var response = pipeline.ProcessMessage(message, requestContext);
            var operation = new LowLevelFuncOperation<Pageable<BinaryData>>(clientDiagnostics, pipeline, message.Request, response, finalStateVia, scopeName, r => PageableHelpers.CreatePageable((nl, ps) => createEnumerable(r, nl, ps), clientDiagnostics, scopeName));
            if (waitUntil == WaitUntil.Completed)
            {
                operation.WaitForCompletion(requestContext?.CancellationToken ?? default);
            }
            return operation;
        }
    }
}
