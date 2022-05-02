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
        public static Operation<T> Cast<T>(Operation<BinaryData> operation, Func<Response, T> convertFunc) where T : notnull => new OperationWrapper<T, BinaryData>(operation, convertFunc);

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

        private class OperationWrapper<T, U> : Operation<T>
            where U : notnull
            where T : notnull
        {
            private readonly Operation<U> _operation;
            private readonly Func<Response, T> _convertFunc;
            private Response<T>? _response;

            public OperationWrapper(Operation<U> operation, Func<Response, T> convertFunc)
            {
                _operation = operation;
                _convertFunc = convertFunc;
                _response = null;
            }

            public override string Id => _operation.Id;
            public override T Value => GetOrCreateValue();
            public override bool HasValue => _operation.HasValue;
            public override bool HasCompleted => _operation.HasCompleted;
            public override Response GetRawResponse() => _operation.GetRawResponse();
            public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);
            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
            public override Response<T> WaitForCompletion(CancellationToken cancellationToken = default) => GetOrCreateResponse(_operation.WaitForCompletion(cancellationToken));
            public override Response<T> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken) => GetOrCreateResponse(_operation.WaitForCompletion(pollingInterval, cancellationToken));
            public override async ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => GetOrCreateResponse(await _operation.WaitForCompletionAsync(cancellationToken));
            public override async ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) => GetOrCreateResponse(await _operation.WaitForCompletionAsync(pollingInterval, cancellationToken));

            private T GetOrCreateValue() => GetOrCreateResponse(GetRawResponse()).Value;

            private Response<T> GetOrCreateResponse(Response<U> response) => GetOrCreateResponse(response.GetRawResponse());

            private Response<T> GetOrCreateResponse(Response rawResponse)
            {
                if (_response != null)
                {
                    return _response;
                }

                var value = _convertFunc(rawResponse);
                var response = Response.FromValue(value, rawResponse);
                Interlocked.CompareExchange(ref _response, response, null);
                return _response;
            }
        }
    }
}
