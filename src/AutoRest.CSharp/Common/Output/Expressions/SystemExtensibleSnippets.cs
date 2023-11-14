// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Internal;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions
{
    internal class SystemExtensibleSnippets : ExtensibleSnippets
    {
        public override JsonElementSnippets JsonElement { get; } = new SystemJsonElementSnippets();
        public override XElementSnippets XElement => throw new NotImplementedException("XElement extensions aren't supported in unbranded yet.");
        public override XmlWriterSnippets XmlWriter => throw new NotImplementedException("XmlWriter extensions aren't supported in unbranded yet.");
        public override RestOperationsSnippets RestOperations { get; } = new SystemRestOperationsSnippets();
        public override ModelSnippets Model { get; } = new SystemModelSnippets();

        internal class SystemModelSnippets : ModelSnippets
        {
            public override Method BuildConversionToRequestBodyMethod(MethodSignatureModifiers modifiers)
            {
                return new Method
                (
                    new MethodSignature("ToRequestBody", null, $"Convert into a {nameof(Utf8JsonRequestBody)}.", modifiers, typeof(RequestBody), null, Array.Empty<Parameter>()),
                    new[]
                    {
                        DeclareRequestBody(out var requestContent),
                        requestContent.JsonWriter.WriteObjectValue(This),
                        Return(requestContent)
                    }
                );
            }

            public override Method BuildFromOperationResponseMethod(SerializableObjectType type, MethodSignatureModifiers modifiers)
            {
                var result = new Parameter("result", $"The result to deserialize the model from.", typeof(PipelineResponse), null, ValidationType.None, null);
                return new Method
                (
                    new MethodSignature("FromResponse", null, $"Deserializes the model from a raw response.", modifiers, type.Type, null, new[]{result}),
                    new MethodBodyStatement[]
                    {
                        UsingVar("document", JsonDocumentExpression.Parse(new PipelineResponseExpression(result).Content), out var document),
                        Return(SerializableObjectTypeExpression.Deserialize(type, document.RootElement))
                    }
                );
            }

            public override TypedValueExpression InvokeToRequestBodyMethod(TypedValueExpression model) => new RequestBodyExpression(model.Invoke("ToRequestBody"));

            private static DeclarationStatement DeclareRequestBody(out Utf8JsonRequestBodyExpression variable)
            {
                var variableRef = new VariableReference(typeof(Utf8JsonRequestBody), "content");
                variable = new Utf8JsonRequestBodyExpression(variableRef);
                return new DeclareVariableStatement(null, variableRef.Declaration, New.Instance(typeof(Utf8JsonRequestBody)));
            }
        }

        private class SystemRestOperationsSnippets : RestOperationsSnippets
        {
            public override TypedValueExpression GetTypedResponseFromValue(TypedValueExpression value, TypedValueExpression result)
            {
                return ResultExpression.FromValue(value, GetRawResponse(result));
            }

            public override TypedValueExpression GetTypedResponseFromModel(SerializableObjectType type, TypedValueExpression result)
            {
                var response = GetRawResponse(result);
                var model = new InvokeStaticMethodExpression(type.Type, "FromResponse", new[] { response });
                return ResultExpression.FromValue(model, response);
            }

            public override TypedValueExpression GetTypedResponseFromEnum(EnumType enumType, TypedValueExpression result)
            {
                var response = GetRawResponse(result);
                return ResultExpression.FromValue(EnumExpression.ToEnum(enumType, response.Content.ToObjectFromJson(typeof(string))), response);
            }

            public override TypedValueExpression GetTypedResponseFromBinaryDate(Type responseType, TypedValueExpression result)
            {
                var rawResponse = GetRawResponse(result);
                return responseType == typeof(BinaryData)
                    ? ResultExpression.FromValue(rawResponse.Content, rawResponse)
                    : ResultExpression.FromValue(rawResponse.Content.ToObjectFromJson(responseType), rawResponse);
            }

            public override MethodBodyStatement DeclareHttpMessage(MethodSignatureBase createRequestMethodSignature, out TypedValueExpression message)
            {
                var messageVar = new VariableReference(typeof(PipelineMessage), "message");
                message = messageVar;
                return UsingDeclare(messageVar, new InvokeInstanceMethodExpression(null, createRequestMethodSignature.Name, createRequestMethodSignature.Parameters.Select(p => (ValueExpression)p).ToList(), null, false));
            }

            public override MethodBodyStatement InvokeServiceOperationCallAndReturnHeadAsBool(TypedValueExpression pipeline, TypedValueExpression message, TypedValueExpression clientDiagnostics, bool async)
            {
                var resultVar = new VariableReference(typeof(NullableResult<bool>), "result");
                var result = new ResultExpression(resultVar);
                return new MethodBodyStatement[]
                {
                    Var(resultVar, new MessagePipelineExpression(pipeline).ProcessHeadAsBoolMessage(message, clientDiagnostics, new RequestOptionsExpression(KnownParameters.RequestContext), async)),
                    Return(ResultExpression.FromValue(result.Value, result.GetRawResponse()))
                };
            }

            public override TypedValueExpression InvokeServiceOperationCall(TypedValueExpression pipeline, TypedValueExpression message, bool async)
                => ResultExpression.FromResponse(new MessagePipelineExpression(pipeline).ProcessMessage(message, new RequestOptionsExpression(KnownParameters.RequestContext), null, async));

            private static PipelineResponseExpression GetRawResponse(TypedValueExpression result)
                => result.Type.Equals(typeof(PipelineResponse))
                    ? new PipelineResponseExpression(result)
                    : new ResultExpression(result).GetRawResponse();
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
