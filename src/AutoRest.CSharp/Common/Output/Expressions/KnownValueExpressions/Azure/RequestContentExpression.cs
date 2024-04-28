// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure
{
    internal sealed record RequestContentExpression(ValueExpression Untyped) : TypedValueExpression<RequestContent>(Untyped)
    {
        public static RequestContentExpression Create(ValueExpression serializable) => new(InvokeStatic(nameof(RequestContent.Create), new[] { serializable }));
        public static RequestContentExpression FromObject(ValueExpression value) => new(RequestContentHelperProvider.Instance.FromObject(value));
        public static RequestContentExpression FromEnumerable(ValueExpression enumerable) => new(RequestContentHelperProvider.Instance.FromEnumerable(enumerable));
        public static RequestContentExpression FromDictionary(ValueExpression dictionary) => new(RequestContentHelperProvider.Instance.FromDictionary(dictionary));

        public static implicit operator RequestContentExpression(FormUrlEncodedContentExpression formUrlEncodedContent) => new(formUrlEncodedContent.Untyped);
        public static implicit operator RequestContentExpression(MultipartFormDataContentExpression multipartFormDataContent) => new(multipartFormDataContent.Untyped);
        public static implicit operator RequestContentExpression(StringRequestContentExpression stringRequestContentExpression) => new(stringRequestContentExpression.Untyped);
        public static implicit operator RequestContentExpression(XmlWriterContentExpression xmlWriterContent) => new(xmlWriterContent.Untyped);
    }
}
