// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ServiceModel.Rest;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;

namespace AutoRest.CSharp.Common.Input
{
    internal abstract class ApiTypes
    {
        public abstract BaseResponseExpression GetResponseExpression(ValueExpression untyped);

        public abstract Type ResponseType { get; }
        public abstract Type ResponseOfTType { get; }

        public abstract string FromResponseName { get; }
        public abstract string ResponseParameterName { get; }

        public abstract string GetRawResponseName { get; }
        public string ContentStreamName => nameof(Result.ContentStream);
        public string ContentName => nameof(Result.Content);
        public string FromValueName = nameof(Result.FromValue);
        public string StatusName = nameof(Result.Status);

        public Type GetResponseOfT<T>() => ResponseOfTType.MakeGenericType(typeof(T));
        public Type GetTaskOfResponse(Type? valueType = default) =>
            valueType is null ? typeof(Task<>).MakeGenericType(ResponseType) : typeof(Task<>).MakeGenericType(ResponseOfTType.MakeGenericType(valueType));
        public Type GetValueTaskOfResponse(Type? valueType = default) =>
            valueType is null ? typeof(ValueTask<>).MakeGenericType(ResponseType) : typeof(ValueTask<>).MakeGenericType(ResponseOfTType.MakeGenericType(valueType));

        public abstract Type PipelineExtensionsType { get; }
        protected abstract string ProcessHeadAsBoolMessageName { get; }
        public string GetProcessHeadAsBoolMessageName(bool isAsync = false) => isAsync ? $"{ProcessHeadAsBoolMessageName}Async" : ProcessHeadAsBoolMessageName;
        protected abstract string ProcessMessageName { get; }
        public string GetProcessMessageName(bool isAsync = false) => isAsync ? $"{ProcessMessageName}Async" : ProcessMessageName;

        public abstract Type HttpPipelineType { get; }
        public abstract string HttpPipelineCreateMessageName { get; }
        public abstract FormattableString GetHttpPipelineCreateMessageFormat(bool withContext);

        public abstract Type HttpMessageType { get; }
        public abstract string HttpMessageResponseName { get; }
        public Type GetNextPageFuncType() => typeof(Func<,,>).MakeGenericType(typeof(int?), typeof(string), HttpMessageType);

        public abstract Type ClientDiagnosticsType { get; }
        public abstract string ClientDiagnosticsCreateScopeName { get; }

        public abstract Type ClientOptionsType { get; }
    }
}
