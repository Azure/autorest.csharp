// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;

namespace AutoRest.CSharp.Common.Output.Expressions
{
    internal abstract partial class ExtensibleSnippets
    {
        internal abstract class JsonElementSnippets
        {
            public virtual ValueExpression GetBytesFromBase64(JsonElementExpression element, string? format)
                => InvokeExtension(ModelSerializationExtensionsProvider.Instance.Type, element, ModelSerializationExtensionsProvider.GetBytesFromBase64, Snippets.Literal(format));

            public virtual ValueExpression GetChar(JsonElementExpression element)
                => InvokeExtension(ModelSerializationExtensionsProvider.Instance.Type, element, ModelSerializationExtensionsProvider.GetChar);

            public virtual ValueExpression GetDateTimeOffset(JsonElementExpression element, string? format)
                => InvokeExtension(ModelSerializationExtensionsProvider.Instance.Type, element, ModelSerializationExtensionsProvider.GetDateTimeOffset, Snippets.Literal(format));

            public virtual ValueExpression GetObject(JsonElementExpression element)
                => InvokeExtension(ModelSerializationExtensionsProvider.Instance.Type, element, ModelSerializationExtensionsProvider.GetObject);

            public virtual ValueExpression GetTimeSpan(JsonElementExpression element, string? format)
                => InvokeExtension(ModelSerializationExtensionsProvider.Instance.Type, element, ModelSerializationExtensionsProvider.GetTimeSpan, Snippets.Literal(format));

            public virtual MethodBodyStatement ThrowNonNullablePropertyIsNull(JsonPropertyExpression property)
                => new InvokeStaticMethodStatement(ModelSerializationExtensionsProvider.Instance.Type, ModelSerializationExtensionsProvider.ThrowNonNullablePropertyIsNull, new[] { property }, CallAsExtension: true);
        }
    }
}
