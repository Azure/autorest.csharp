// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace Azure.Core
{
    internal class ResponseWithHeader<THeaders>
    {
        private readonly Response _rawResponse;

        public ResponseWithHeader(THeaders headers, Response rawResponse)
        {
            _rawResponse = rawResponse;
            Headers = headers;
        }

        public Response GetRawResponse() => _rawResponse;

        public THeaders Headers { get; }
    }
}
