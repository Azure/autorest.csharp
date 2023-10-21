// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions
{
    internal class SystemExtensibleSnippets : ExtensibleSnippets
    {
        public override JsonElementSnippets JsonElement { get; } = new SystemJsonElementSnippets();
        public override XElementSnippets XElement => throw new NotImplementedException("XElement extensions aren't supported in unbranded yet.");
        public override XmlWriterSnippets XmlWriter => throw new NotImplementedException("XmlWriter extensions aren't supported in unbranded yet.");
        public override OperationResponseSnippets OperationResponse { get; } = new SystemOperationResponseSnippets();

        private class SystemOperationResponseSnippets : OperationResponseSnippets
        {
            public override TypedValueExpression FromValue(TypedValueExpression value, TypedValueExpression response)
                => ResultExpression.FromValue(value, new PipelineResponseExpression(response));
        }

        private class SystemJsonElementSnippets : JsonElementSnippets
        {
            public override ValueExpression GetBytesFromBase64(JsonElementExpression element, string? format) => InvokeExtension(typeof(ModelSerializationExtensions), element, nameof(ModelSerializationExtensions.GetBytesFromBase64), Literal(format));
            public override ValueExpression GetChar(JsonElementExpression element) => InvokeExtension(typeof(ModelSerializationExtensions), element, nameof(ModelSerializationExtensions.GetChar));
            public override ValueExpression GetDateTimeOffset(JsonElementExpression element, string? format) => InvokeExtension(typeof(ModelSerializationExtensions), element, nameof(ModelSerializationExtensions.GetDateTimeOffset), Literal(format));
            public override ValueExpression GetObject(JsonElementExpression element) => InvokeExtension(typeof(ModelSerializationExtensions), element, nameof(ModelSerializationExtensions.GetObject));
            public override ValueExpression GetTimeSpan(JsonElementExpression element, string? format) => InvokeExtension(typeof(ModelSerializationExtensions), element, nameof(ModelSerializationExtensions.GetTimeSpan), Literal(format));
            public override MethodBodyStatement ThrowNonNullablePropertyIsNull(JsonPropertyExpression property)
                => new InvokeStaticMethodStatement(typeof(ModelSerializationExtensions), nameof(ModelSerializationExtensions.ThrowNonNullablePropertyIsNull), new[] { property }, CallAsExtension: true);
        }
    }
}
