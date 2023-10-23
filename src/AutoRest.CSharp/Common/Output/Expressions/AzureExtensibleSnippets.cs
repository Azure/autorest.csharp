// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions
{
    internal class AzureExtensibleSnippets : ExtensibleSnippets
    {
        public override JsonElementSnippets JsonElement { get; } = new AzureJsonElementSnippets();
        public override XElementSnippets XElement { get; } = new AzureXElementSnippets();
        public override XmlWriterSnippets XmlWriter { get; } = new AzureXmlWriterSnippets();
        public override RestOperationsSnippets RestOperations { get; } = new AzureRestOperationsSnippets();
        public override ModelSnippets Model { get; } = new AzureModelSnippets();

        internal class AzureModelSnippets : ModelSnippets
        {
            private const string FromResponseMethodName = "FromResponse";
            private const string ToRequestContentMethodName = "ToRequestContent";

            public override Method BuildConversionToRequestBodyMethod(MethodSignatureModifiers modifiers)
            {
                return new Method
                (
                    new MethodSignature(ToRequestContentMethodName, null, $"Convert into a {nameof(Utf8JsonRequestContent)}.", modifiers, typeof(RequestContent), null, Array.Empty<Parameter>()),
                    new[]
                    {
                        DeclareRequestContent(out var requestContent),
                        requestContent.JsonWriter.WriteObjectValue(This),
                        Return(requestContent)
                    }
                );
            }

            public override Method BuildFromOperationResponseMethod(SerializableObjectType type, MethodSignatureModifiers modifiers)
            {
                var fromResponse = new Parameter("response", "The response to deserialize the model from.", typeof(Response), null, Validation.None, null);
                return new Method
                (
                    new MethodSignature(FromResponseMethodName, null, $"Deserializes the model from a raw response.", modifiers, type.Type, null, new[]{fromResponse}),
                    new MethodBodyStatement[]
                    {
                        UsingVar("document", JsonDocumentExpression.Parse(new ResponseExpression(fromResponse).Content), out var document),
                        Return(SerializableObjectTypeExpression.Deserialize(type, document.RootElement))
                    }
                );
            }

            public override SerializableObjectTypeExpression InvokeFromOperationResponseMethod(SerializableObjectType type, TypedValueExpression response)
                => new(type, new InvokeStaticMethodExpression(type.Type, FromResponseMethodName, new[] { new ResponseExpression(response) }));

            public override TypedValueExpression InvokeToRequestBodyMethod(TypedValueExpression model) => new RequestContentExpression(model.Invoke(ToRequestContentMethodName));

            private static DeclarationStatement DeclareRequestContent(out Utf8JsonRequestContentExpression variable)
            {
                var variableRef = new VariableReference(typeof(Utf8JsonRequestContent), "content");
                variable = new Utf8JsonRequestContentExpression(variableRef);
                return new DeclareVariableStatement(null, variableRef.Declaration, New.Instance(typeof(Utf8JsonRequestContent)));
            }
        }

        internal class AzureRestOperationsSnippets : RestOperationsSnippets
        {
            public override TypedValueExpression GetTypedResponseFromValue(TypedValueExpression value, TypedValueExpression response)
                => ResponseExpression.FromValue(value, new ResponseExpression(response).GetRawResponse());

            public override BinaryDataExpression GetBinaryDataFromResponse(TypedValueExpression response)
                => new ResponseExpression(response).Content;

            public override MethodBodyStatement DeclareHttpMessage(MethodSignatureBase createRequestMethodSignature, out TypedValueExpression message)
            {
                var messageVar = new VariableReference(typeof(HttpMessage), "message");
                message = messageVar;
                return UsingDeclare(messageVar, new InvokeInstanceMethodExpression(null, createRequestMethodSignature.Name, createRequestMethodSignature.Parameters.Select(p => (ValueExpression)p).ToList(), null, false));
            }

            public override MethodBodyStatement InvokeServiceOperationCallAndReturnHeadAsBool(TypedValueExpression pipeline, TypedValueExpression message, TypedValueExpression clientDiagnostics, bool async)
                => Return(new HttpPipelineExpression(pipeline).ProcessHeadAsBoolMessage(new HttpMessageExpression(message), clientDiagnostics, new RequestContextExpression(KnownParameters.RequestContext), async));

            public override TypedValueExpression InvokeServiceOperationCall(TypedValueExpression pipeline, TypedValueExpression message, bool async)
                => new HttpPipelineExpression(pipeline).ProcessMessage(new HttpMessageExpression(message), new RequestContextExpression(KnownParameters.RequestContext), null, async);
        }

        private class AzureJsonElementSnippets : JsonElementSnippets
        {
            public override ValueExpression GetBytesFromBase64(JsonElementExpression element, string? format) => InvokeExtension(typeof(JsonElementExtensions), element, nameof(JsonElementExtensions.GetBytesFromBase64), Literal(format));
            public override ValueExpression GetChar(JsonElementExpression element) => InvokeExtension(typeof(JsonElementExtensions), element, nameof(JsonElementExtensions.GetChar));
            public override ValueExpression GetDateTimeOffset(JsonElementExpression element, string? format) => InvokeExtension(typeof(JsonElementExtensions), element, nameof(JsonElementExtensions.GetDateTimeOffset), Literal(format));
            public override ValueExpression GetObject(JsonElementExpression element) => InvokeExtension(typeof(JsonElementExtensions), element, nameof(JsonElementExtensions.GetObject));
            public override ValueExpression GetTimeSpan(JsonElementExpression element, string? format) => InvokeExtension(typeof(JsonElementExtensions), element, nameof(JsonElementExtensions.GetTimeSpan), Literal(format));

            public override MethodBodyStatement ThrowNonNullablePropertyIsNull(JsonPropertyExpression property)
                => new InvokeStaticMethodStatement(typeof(JsonElementExtensions), nameof(JsonElementExtensions.ThrowNonNullablePropertyIsNull), new[] { property }, CallAsExtension: true);
        }

        private class AzureXElementSnippets : XElementSnippets
        {
            public override ValueExpression GetBytesFromBase64Value(XElementExpression xElement, string? format)
                => InvokeExtension(typeof(XElementExtensions), xElement, nameof(XElementExtensions.GetBytesFromBase64Value), Literal(format));
            public override ValueExpression GetDateTimeOffsetValue(XElementExpression xElement, string? format)
                => InvokeExtension(typeof(XElementExtensions), xElement, nameof(XElementExtensions.GetDateTimeOffsetValue), Literal(format));
            public override ValueExpression GetObjectValue(XElementExpression xElement, string? format)
                => InvokeExtension(typeof(XElementExtensions), xElement, nameof(XElementExtensions.GetObjectValue), Literal(format));
            public override ValueExpression GetTimeSpanValue(XElementExpression xElement, string? format)
                => InvokeExtension(typeof(XElementExtensions), xElement, nameof(XElementExtensions.GetTimeSpanValue), Literal(format));
        }

        private class AzureXmlWriterSnippets : XmlWriterSnippets
        {
            public override MethodBodyStatement WriteValue(XmlWriterExpression xmlWriter, ValueExpression value, string format)
                => new InvokeStaticMethodStatement(typeof(XmlWriterExtensions), nameof(XmlWriterExtensions.WriteValue), new[] { xmlWriter, value, Snippets.Literal(format) }, CallAsExtension: true);

            public override MethodBodyStatement WriteObjectValue(XmlWriterExpression xmlWriter, ValueExpression value, string? nameHint)
                => new InvokeStaticMethodStatement(typeof(XmlWriterExtensions), nameof(XmlWriterExtensions.WriteObjectValue), new[] { xmlWriter, value, Snippets.Literal(nameHint) }, CallAsExtension: true);
        }
    }
}
