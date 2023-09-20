// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ServiceModel.Rest;
using System.Threading.Tasks;

namespace AutoRest.CSharp.Common.Input
{
    internal abstract class ApiTypes
    {
        public abstract Type ResponseType { get; }
        public abstract Type ResponseOfTType { get; }

        public string ContentStreamName => nameof(Result.ContentStream);
        public string ContentName => nameof(Result.Content);
        public string FromValueName = nameof(Result.FromValue);
        public string StatusName = nameof(Result.Status);

        public Type GetResponseOfT<T>() => ResponseOfTType.MakeGenericType(typeof(T));
        public Type GetTaskOfResponse(Type? valueType = default) =>
            valueType is null ? typeof(Task<>).MakeGenericType(ResponseType) : typeof(Task<>).MakeGenericType(ResponseOfTType.MakeGenericType(valueType));
        public Type GetValueTaskOfResponse(Type? valueType = default) =>
            valueType is null ? typeof(ValueTask<>).MakeGenericType(ResponseType) : typeof(ValueTask<>).MakeGenericType(ResponseOfTType.MakeGenericType(valueType));
    }
}
