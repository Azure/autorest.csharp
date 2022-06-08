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
        public static Operation<TTo> Convert<TFrom, TTo>(LowLevelFuncOperation<TFrom> operation, Func<Response, TTo> convertFunc, ClientDiagnostics diagnostics, string scopeName)
            where TFrom : notnull
            where TTo : notnull
            => new ConvertOperation<TFrom, TTo>(operation, diagnostics, scopeName, convertFunc);

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

        private class ConvertOperation<TFrom, TTo> : Operation<TTo>
            where TFrom : notnull
            where TTo : notnull
        {
            private readonly Operation<TFrom> _operation;
            private readonly ClientDiagnostics _diagnostics;
            private readonly Func<Response, TTo> _convertFunc;
            private Response<TTo>? _response;

            public ConvertOperation(LowLevelFuncOperation<TFrom> operation, ClientDiagnostics diagnostics, string operationName, Func<Response, TTo> convertFunc)
            {
                _operation = operation;
                _diagnostics = diagnostics;
                _convertFunc = convertFunc;
                _response = null;
                operation.SetOperationTypeName(operationName);
            }

            public override string Id => _operation.Id;
            public override TTo Value => GetOrCreateValue();
            public override bool HasValue => _operation.HasValue;
            public override bool HasCompleted => _operation.HasCompleted;
            public override Response GetRawResponse() => _operation.GetRawResponse();

            public override Response UpdateStatus(CancellationToken cancellationToken = default)
            {
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                return _operation.UpdateStatus(cancellationToken);
            }

            public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            {
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                return await _operation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
            }

            public override Response<TTo> WaitForCompletion(CancellationToken cancellationToken = default)
            {
                if (_response != null)
                {
                    return _response;
                }

                var result = _operation.WaitForCompletion(cancellationToken);
                return CreateResponseOfTTo(result);
            }

            public override Response<TTo> WaitForCompletion(TimeSpan pollingInterval, CancellationToken cancellationToken)
            {
                if (_response != null)
                {
                    return _response;
                }

                var result = _operation.WaitForCompletion(pollingInterval, cancellationToken);
                return CreateResponseOfTTo(result);
            }

            public override async ValueTask<Response<TTo>> WaitForCompletionAsync(CancellationToken cancellationToken = default)
            {
                if (_response != null)
                {
                    return _response;
                }

                var result = await _operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return CreateResponseOfTTo(result);
            }

            public override async ValueTask<Response<TTo>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken)
            {
                if (_response != null)
                {
                    return _response;
                }

                var result = await _operation.WaitForCompletionAsync(pollingInterval, cancellationToken).ConfigureAwait(false);
                return CreateResponseOfTTo(result);
            }

            private TTo GetOrCreateValue()
                => _response != null ? _response.Value : CreateResponseOfTTo(GetRawResponse()).Value;

            private Response<TTo> CreateResponseOfTTo(Response<TFrom> responseTFrom)
                => CreateResponseOfTTo(responseTFrom.GetRawResponse());

            private Response<TTo> CreateResponseOfTTo(Response rawResponse)
            {
                var value = _convertFunc(rawResponse);
                var response = Response.FromValue(value, rawResponse);
                Interlocked.CompareExchange(ref _response, response, null);
                return _response;
            }

            private DiagnosticScope CreateScope(string name)
            {
                var scope = _diagnostics.CreateScope(name);
                scope.Start();
                return scope;
            }
        }
    }
}
