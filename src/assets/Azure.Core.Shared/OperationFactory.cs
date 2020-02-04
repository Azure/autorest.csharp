// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal static class OperationFactory
    {
        //public static Operation<T> Create<T>(Func<string?, Page<T>> pageFunc) where T : class
        //{
        //    return new FuncOperation<T>((continuationToken, pageSizeHint) => pageFunc(continuationToken));
        //}

        //public static Operation<T> CreateAsync<T>(Response<T> initialResponse, AsyncPollingFunc<T> asyncPollingFunc, AsyncCompletionPredicate<T> asyncCompletionPredicate) where T : class
        //{
        //    return new FuncOperation<T>((continuationToken, pageSizeHint) => pageFunc(continuationToken));
        //}

        internal delegate ValueTask<Response<T>> AsyncPollingFunc<T>(CancellationToken cancellationToken = new CancellationToken());
        internal delegate Response<T> PollingFunc<T>(CancellationToken cancellationToken = new CancellationToken());

        internal delegate ValueTask<bool> AsyncCompletionPredicate<T>(Response<T> response);
        internal delegate bool CompletionPredicate<T>(Response<T> response);

        private class FuncOperation<T> : Operation<T> where T : class
        {
            private readonly AsyncPollingFunc<T>? _asyncPollingFunc;
            private readonly PollingFunc<T>? _pollingFunc;
            private readonly AsyncCompletionPredicate<T>? _asyncCompletionPredicate;
            private readonly CompletionPredicate<T>? _completionPredicate;
            private Response _rawResponse;
            private T? _value;
            private bool _completed;

            public FuncOperation(Response<T> initialResponse, AsyncPollingFunc<T> asyncPollingFunc, AsyncCompletionPredicate<T> asyncCompletionPredicate)
            {
                _rawResponse = initialResponse.GetRawResponse();
                _asyncPollingFunc = asyncPollingFunc;
                _asyncCompletionPredicate = asyncCompletionPredicate;
            }

            public FuncOperation(Response<T> initialResponse, PollingFunc<T> pollingFunc, CompletionPredicate<T> completionPredicate)
            {
                _rawResponse = initialResponse.GetRawResponse();
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
                if (HasCompleted) return GetRawResponse();

                Response<T>? response = null;
                if (!_completed && _asyncPollingFunc != null && _asyncCompletionPredicate != null)
                {
                    response = await _asyncPollingFunc(cancellationToken).ConfigureAwait(false);
                    _completed = await _asyncCompletionPredicate(response).ConfigureAwait(false);
                }

                _rawResponse = response?.GetRawResponse() ?? _rawResponse;
                return _rawResponse;
            }

            public override Response UpdateStatus(CancellationToken cancellationToken = new CancellationToken())
            {
                if (HasCompleted) return GetRawResponse();

                Response<T>? response = null;
                if (!_completed && _pollingFunc != null && _completionPredicate != null)
                {
                    response = _pollingFunc(cancellationToken);
                    _completed = _completionPredicate(response);
                }

                _rawResponse = response?.GetRawResponse() ?? _rawResponse;
                return _rawResponse;
            }

            public override string Id { get; } = Guid.NewGuid().ToString();
            public override T Value => OperationHelpers.GetValue(ref _value);
            public override bool HasCompleted => _completed;
            public override bool HasValue => _value != null;
        }
    }
}
