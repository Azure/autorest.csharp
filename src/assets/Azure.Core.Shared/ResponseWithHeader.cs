// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Azure.Core
{
    internal static class ResponseWithHeader
    {
        public static ResponseWithHeader<T, THeaders> FromValue<T, THeaders>(T value, THeaders headers, Response rawResponse)
        {
            return new ResponseWithHeader<T, THeaders>(value, headers, rawResponse);
        }

        public static ResponseWithHeader<THeaders> FromValue<THeaders>(THeaders headers, Response rawResponse)
        {
            return new ResponseWithHeader<THeaders>(headers, rawResponse);
        }
    }
}
