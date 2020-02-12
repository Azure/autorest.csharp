// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal static class OperationFactory
    {
        public static Operation<T> Create<T>(Response originalResponse, PollingFunc pollingFunc, CompletionPredicate completionPredicate, FinalFunc<T> finalFunc) where T : notnull =>
            new FuncOperation<T>(originalResponse, pollingFunc, completionPredicate, finalFunc);

        public static Operation<T> CreateAsync<T>(Response originalResponse, AsyncPollingFunc asyncPollingFunc, AsyncCompletionPredicate asyncCompletionPredicate, AsyncFinalFunc<T> asyncFinalFunc) where T : notnull =>
            new FuncOperation<T>(originalResponse, asyncPollingFunc, asyncCompletionPredicate, asyncFinalFunc);

        internal delegate ValueTask<Response> AsyncPollingFunc(Response previousResponse, CancellationToken cancellationToken = default);
        internal delegate Response PollingFunc(Response previousResponse, CancellationToken cancellationToken = default);

        internal delegate ValueTask<bool> AsyncCompletionPredicate(Response response);
        internal delegate bool CompletionPredicate(Response response);

        internal delegate ValueTask<Response<T>> AsyncFinalFunc<T>(Response response, CancellationToken cancellationToken = default);
        internal delegate Response<T> FinalFunc<T>(Response response, CancellationToken cancellationToken = default);

        private class FuncOperation<T> : Operation<T> where T : notnull
        {
            private readonly AsyncPollingFunc? _asyncPollingFunc;
            private readonly PollingFunc? _pollingFunc;
            private readonly AsyncCompletionPredicate? _asyncCompletionPredicate;
            private readonly CompletionPredicate? _completionPredicate;
            private readonly AsyncFinalFunc<T>? _asyncFinalFunc;
            private readonly FinalFunc<T>? _finalFunc;

            private Response _rawResponse;
            private T _value = default!;
            private bool _hasValue;
            private bool _hasCompleted;

            public FuncOperation(Response originalResponse, AsyncPollingFunc asyncPollingFunc, AsyncCompletionPredicate asyncCompletionPredicate, AsyncFinalFunc<T> asyncFinalFunc)
            {
                _rawResponse = originalResponse;
                _asyncPollingFunc = asyncPollingFunc;
                _asyncCompletionPredicate = asyncCompletionPredicate;
                _asyncFinalFunc = asyncFinalFunc;
            }

            public FuncOperation(Response originalResponse, PollingFunc pollingFunc, CompletionPredicate completionPredicate, FinalFunc<T> finalFunc)
            {
                _rawResponse = originalResponse;
                _pollingFunc = pollingFunc;
                _completionPredicate = completionPredicate;
                _finalFunc = finalFunc;
            }

            public override Response GetRawResponse() => _rawResponse;

            public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
                this.DefaultWaitForCompletionAsync(OperationHelpers.DefaultPollingInterval, cancellationToken);

            public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
                this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

            public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            {
                // If it is completed, short circuit.
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                if (_asyncCompletionPredicate != null)
                {
                    // Since it has not been completed, we check to see if it was completed.
                    _hasCompleted = await _asyncCompletionPredicate(GetRawResponse()).ConfigureAwait(false);
                    // If it is now completed, then we extract the value from the response.
                    if (HasCompleted && _asyncFinalFunc != null)
                    {
                        Response<T> finalResponse = await _asyncFinalFunc(GetRawResponse(), cancellationToken);
                        _rawResponse = finalResponse.GetRawResponse();
                        _value = finalResponse.Value;
                        _hasValue = true;
                        return GetRawResponse();
                    }
                }

                // If it wasn't completed after checking it, then we poll for a new response.
                if (_asyncPollingFunc != null && _asyncCompletionPredicate != null)
                {
                    Response response = await _asyncPollingFunc(GetRawResponse(), cancellationToken).ConfigureAwait(false);
                    _rawResponse = response;
                }

                return GetRawResponse();
            }

            public override Response UpdateStatus(CancellationToken cancellationToken = default)
            {
                // If it is completed, short circuit.
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                if (_completionPredicate != null)
                {
                    // Since it has not been completed, we check to see if it was completed.
                    _hasCompleted = _completionPredicate(GetRawResponse());
                    // If it is now completed, then we extract the value from the response.
                    if (HasCompleted && _finalFunc != null)
                    {
                        Response<T> finalResponse = _finalFunc(GetRawResponse(), cancellationToken);
                        _rawResponse = finalResponse.GetRawResponse();
                        _value = finalResponse.Value;
                        _hasValue = true;
                        return GetRawResponse();
                    }
                }

                // If it wasn't completed after checking it, then we poll for a new response.
                if (_pollingFunc != null && _asyncCompletionPredicate != null)
                {
                    Response response = _pollingFunc(GetRawResponse(), cancellationToken);
                    _rawResponse = response;
                }

                return GetRawResponse();
            }

            public override string Id { get; } = Guid.NewGuid().ToString();

            public override T Value
            {
                get
                {
                    if (!HasValue)
                    {
                        throw new InvalidOperationException("The operation has not completed yet.");
                    }

                    return _value;
                }
            }
            public override bool HasCompleted => _hasCompleted;
            public override bool HasValue => _hasValue;
        }
    }
}
