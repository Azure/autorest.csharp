// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions
{
    internal sealed record RequestContentExpression(ValueExpression Untyped) : TypedValueExpression<RequestContent>(Untyped)
    {
        public static RequestContentExpression Create(ValueExpression serializable, ModelSerializerOptionsExpression options)
            => new(InvokeStatic(Configuration.ApiTypes.RequestContentCreateName, serializable, options));
        public static RequestContentExpression Create(ValueExpression serializable) => new(InvokeStatic(Configuration.ApiTypes.RequestContentCreateName, new[] { serializable }));
        public static RequestContentExpression FromEnumerable(ValueExpression enumerable) => new(new InvokeStaticMethodExpression(typeof(RequestContentHelper), nameof(RequestContentHelper.FromEnumerable), new[] { enumerable }));
        public static RequestContentExpression FromDictionary(ValueExpression dictionary) => new(new InvokeStaticMethodExpression(typeof(RequestContentHelper), nameof(RequestContentHelper.FromDictionary), new[] { dictionary }));

        public static implicit operator RequestContentExpression(FormUrlEncodedContentExpression formUrlEncodedContent) => new(formUrlEncodedContent.Untyped);
        public static implicit operator RequestContentExpression(MultipartFormDataContentExpression multipartFormDataContent) => new(multipartFormDataContent.Untyped);
        public static implicit operator RequestContentExpression(StringRequestContentExpression stringRequestContentExpression) => new(stringRequestContentExpression.Untyped);
        public static implicit operator RequestContentExpression(BaseUtf8JsonRequestContentExpression utf8JsonRequestContent) => new(utf8JsonRequestContent.Untyped);
        public static implicit operator RequestContentExpression(XmlWriterContentExpression xmlWriterContent) => new(xmlWriterContent.Untyped);
    }
}
