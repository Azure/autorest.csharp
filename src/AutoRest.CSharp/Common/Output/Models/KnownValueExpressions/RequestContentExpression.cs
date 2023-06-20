// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models.KnownValueExpressions
{
    internal sealed record RequestContentExpression(ValueExpression Untyped) : TypedValueExpression(typeof(RequestContent), Untyped)
    {
        public static RequestContentExpression Create(ValueExpression serializable) => new(new InvokeStaticMethodExpression(typeof(RequestContent), nameof(RequestContent.Create), new[]{serializable}));

        public static implicit operator RequestContentExpression(FormUrlEncodedContentExpression formUrlEncodedContent) => new(formUrlEncodedContent.Untyped);
        public static implicit operator RequestContentExpression(MultipartFormDataContentExpression multipartFormDataContent) => new(multipartFormDataContent.Untyped);
        public static implicit operator RequestContentExpression(StringRequestContentExpression stringRequestContentExpression) => new(stringRequestContentExpression.Untyped);
        public static implicit operator RequestContentExpression(Utf8JsonRequestContentExpression utf8JsonRequestContent) => new(utf8JsonRequestContent.Untyped);
        public static implicit operator RequestContentExpression(XmlWriterContentExpression xmlWriterContent) => new(xmlWriterContent.Untyped);
    }
}
