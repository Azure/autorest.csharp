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
        public static Operation<T> Create<T>(OriginalFunc originalFunc, PollingFunc pollingFunc, Predicate<Response> completionPredicate, FinalFunc<T> finalFunc,
            AsyncOriginalFunc asyncOriginalFunc, AsyncPollingFunc asyncPollingFunc, AsyncFinalFunc<T> asyncFinalFunc) where T : notnull =>
            new FuncOperation<T>(originalFunc, pollingFunc, completionPredicate, finalFunc, asyncOriginalFunc, asyncPollingFunc, asyncFinalFunc);

        internal delegate ValueTask<Response> AsyncOriginalFunc(CancellationToken cancellationToken = default);
        internal delegate Response OriginalFunc(CancellationToken cancellationToken = default);

        internal delegate ValueTask<Response> AsyncPollingFunc(Response previousResponse, CancellationToken cancellationToken = default);
        internal delegate Response PollingFunc(Response previousResponse, CancellationToken cancellationToken = default);

        internal delegate ValueTask<Response<T>> AsyncFinalFunc<T>(Response response, CancellationToken cancellationToken = default);
        internal delegate Response<T> FinalFunc<T>(Response response, CancellationToken cancellationToken = default);

        private class FuncOperation<T> : Operation<T> where T : notnull
        {
            private readonly AsyncOriginalFunc _asyncOriginalFunc;
            private readonly OriginalFunc _originalFunc;
            private readonly AsyncPollingFunc _asyncPollingFunc;
            private readonly PollingFunc _pollingFunc;
            private readonly Predicate<Response> _completionPredicate;
            private readonly AsyncFinalFunc<T> _asyncFinalFunc;
            private readonly FinalFunc<T> _finalFunc;

            private Response _rawResponse = default!;
            private T _value = default!;
            private bool _hasValue;
            private bool _hasCompleted;
            private bool _hasResponse;

            public FuncOperation(OriginalFunc originalFunc, PollingFunc pollingFunc, Predicate<Response> completionPredicate, FinalFunc<T> finalFunc,
                AsyncOriginalFunc asyncOriginalFunc, AsyncPollingFunc asyncPollingFunc, AsyncFinalFunc<T> asyncFinalFunc)
            {
                _originalFunc = originalFunc;
                _pollingFunc = pollingFunc;
                _completionPredicate = completionPredicate;
                _finalFunc = finalFunc;
                _asyncOriginalFunc = asyncOriginalFunc;
                _asyncPollingFunc = asyncPollingFunc;
                _asyncFinalFunc = asyncFinalFunc;
            }

            public override Response GetRawResponse()
            {
                if (!_hasResponse)
                {
                    throw new InvalidOperationException("The operation has not been started yet.");
                }

                return _rawResponse;
            }

            public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = default) =>
                this.DefaultWaitForCompletionAsync(OperationHelpers.DefaultPollingInterval, cancellationToken);

            public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
                this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

            public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
            {
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                Response response = _hasResponse
                    ? await _asyncPollingFunc(GetRawResponse(), cancellationToken).ConfigureAwait(false)
                    : await _asyncOriginalFunc(cancellationToken).ConfigureAwait(false);
                _rawResponse = response;
                _hasResponse = true;
                _hasCompleted = _completionPredicate(GetRawResponse());
                if (HasCompleted)
                {
                    Response<T> finalResponse = await _asyncFinalFunc(GetRawResponse(), cancellationToken);
                    _rawResponse = finalResponse.GetRawResponse();
                    _value = finalResponse.Value;
                    _hasValue = true;
                    return GetRawResponse();
                }

                return GetRawResponse();
            }

            public override Response UpdateStatus(CancellationToken cancellationToken = default)
            {
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                Response response = _hasResponse
                    ? _pollingFunc(GetRawResponse(), cancellationToken)
                    : _originalFunc(cancellationToken);
                _rawResponse = response;
                _hasResponse = true;
                _hasCompleted = _completionPredicate(GetRawResponse());
                if (HasCompleted)
                {
                    Response<T> finalResponse = _finalFunc(GetRawResponse(), cancellationToken);
                    _rawResponse = finalResponse.GetRawResponse();
                    _value = finalResponse.Value;
                    _hasValue = true;
                    return GetRawResponse();
                }

                return GetRawResponse();
            }

            //TODO: This is currently not used.
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
