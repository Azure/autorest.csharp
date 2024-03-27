// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Expressions
{
    internal abstract partial class ExtensibleSnippets
    {
        internal class JsonElementSnippets
        {
            public ValueExpression GetBytesFromBase64(JsonElementExpression element, string? format)
                => ModelSerializationExtensionsProvider.Instance.GetBytesFromBase64(element, format);

            public ValueExpression GetChar(JsonElementExpression element)
                => ModelSerializationExtensionsProvider.Instance.GetChar(element);

            public ValueExpression GetDateTimeOffset(JsonElementExpression element, string? format)
                => ModelSerializationExtensionsProvider.Instance.GetDateTimeOffset(element, format);

            public ValueExpression GetObject(JsonElementExpression element)
                => ModelSerializationExtensionsProvider.Instance.GetObject(element);

            public ValueExpression GetTimeSpan(JsonElementExpression element, string? format)
                => ModelSerializationExtensionsProvider.Instance.GetTimeSpan(element, format);

            public MethodBodyStatement ThrowNonNullablePropertyIsNull(JsonPropertyExpression property)
                => ModelSerializationExtensionsProvider.Instance.ThrowNonNullablePropertyIsNull(property);
        }
    }
}
