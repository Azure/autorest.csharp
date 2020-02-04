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
        public static Operation<T> Create<T>(Response initialResponse, PollingFunc<T> pollingFunc, CompletionPredicate<T> completionPredicate) where T : notnull =>
            new FuncOperation<T>(initialResponse, pollingFunc, completionPredicate);

        public static Operation<T> CreateAsync<T>(Response initialResponse, AsyncPollingFunc<T> asyncPollingFunc, AsyncCompletionPredicate<T> asyncCompletionPredicate) where T : notnull =>
            new FuncOperation<T>(initialResponse, asyncPollingFunc, asyncCompletionPredicate);

        internal delegate ValueTask<Response<T>> AsyncPollingFunc<T>(CancellationToken cancellationToken = new CancellationToken());
        internal delegate Response<T> PollingFunc<T>(CancellationToken cancellationToken = new CancellationToken());

        internal delegate ValueTask<bool> AsyncCompletionPredicate<T>(Response<T> response);
        internal delegate bool CompletionPredicate<T>(Response<T> response);

        private class FuncOperation<T> : Operation<T> where T : notnull
        {
            private readonly AsyncPollingFunc<T>? _asyncPollingFunc;
            private readonly PollingFunc<T>? _pollingFunc;
            private readonly AsyncCompletionPredicate<T>? _asyncCompletionPredicate;
            private readonly CompletionPredicate<T>? _completionPredicate;
            private Response _rawResponse;
            private T _value = default!;
            private bool _hasValue;
            private bool _hasCompleted;

            public FuncOperation(Response initialResponse, AsyncPollingFunc<T> asyncPollingFunc, AsyncCompletionPredicate<T> asyncCompletionPredicate)
            {
                _rawResponse = initialResponse;
                _asyncPollingFunc = asyncPollingFunc;
                _asyncCompletionPredicate = asyncCompletionPredicate;
            }

            public FuncOperation(Response initialResponse, PollingFunc<T> pollingFunc, CompletionPredicate<T> completionPredicate)
            {
                _rawResponse = initialResponse;
                _pollingFunc = pollingFunc;
                _completionPredicate = completionPredicate;
            }

            public override Response GetRawResponse() => _rawResponse;

            public override ValueTask<Response<T>> WaitForCompletionAsync(CancellationToken cancellationToken = new CancellationToken()) =>
                this.DefaultWaitForCompletionAsync(OperationHelpers.DefaultPollingInterval, cancellationToken);

            public override ValueTask<Response<T>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken) =>
                this.DefaultWaitForCompletionAsync(pollingInterval, cancellationToken);

            public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = new CancellationToken())
            {
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                Response<T>? response = null;
                if (!HasCompleted && _asyncPollingFunc != null && _asyncCompletionPredicate != null)
                {
                    response = await _asyncPollingFunc(cancellationToken).ConfigureAwait(false);
                    _hasCompleted = await _asyncCompletionPredicate(response).ConfigureAwait(false);
                }

                if (response != null)
                {
                    _rawResponse = response.GetRawResponse();
                    if (HasCompleted)
                    {
                        _value = response.Value;
                        _hasValue = true;
                    }
                }
                return GetRawResponse();
            }

            public override Response UpdateStatus(CancellationToken cancellationToken = new CancellationToken())
            {
                if (HasCompleted)
                {
                    return GetRawResponse();
                }

                Response<T>? response = null;
                if (!HasCompleted && _pollingFunc != null && _completionPredicate != null)
                {
                    response = _pollingFunc(cancellationToken);
                    _hasCompleted = _completionPredicate(response);
                }

                if (response != null)
                {
                    _rawResponse = response.GetRawResponse();
                    if (HasCompleted)
                    {
                        _value = response.Value;
                        _hasValue = true;
                    }
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
