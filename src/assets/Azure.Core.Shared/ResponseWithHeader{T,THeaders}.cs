// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Core
{
    internal class ResponseWithHeader<T, THeaders> : Response<T>
    {
        private readonly Response _rawResponse;

        public ResponseWithHeader(T value, THeaders headers, Response rawResponse)
        {
            _rawResponse = rawResponse;
            Value = value;
            Headers = headers;
        }

        public override Response GetRawResponse() => _rawResponse;

        public override T Value { get; }

        public THeaders Headers { get; }
    }
}
