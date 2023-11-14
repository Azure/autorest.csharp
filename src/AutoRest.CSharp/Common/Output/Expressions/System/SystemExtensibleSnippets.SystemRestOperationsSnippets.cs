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

namespace AutoRest.CSharp.Common.Output.Expressions.System
{
    internal partial class SystemExtensibleSnippets
    {
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
                return Snippets.UsingDeclare(messageVar, new InvokeInstanceMethodExpression(null, createRequestMethodSignature.Name, createRequestMethodSignature.Parameters.Select(p => (ValueExpression)p).ToList(), null, false));
            }

            public override MethodBodyStatement DeclareContentWithUtf8JsonWriter(out TypedValueExpression content, out Utf8JsonWriterExpression writer)
            {
                var contentVar = new VariableReference(typeof(Utf8JsonRequestBody), "content");
                content = contentVar;
                writer = new Utf8JsonRequestBodyExpression(content).JsonWriter;
                return Snippets.Var(contentVar, Snippets.New.Instance(typeof(Utf8JsonRequestBody)));
            }

            public override MethodBodyStatement DeclareContentWithXmlWriter(out TypedValueExpression content, out XmlWriterExpression writer)
            {
                throw new NotImplementedException("Xml serialization isn't supported in System.Net.ClientModel yet");
            }

            public override MethodBodyStatement InvokeServiceOperationCallAndReturnHeadAsBool(TypedValueExpression pipeline, TypedValueExpression message, TypedValueExpression clientDiagnostics, bool async)
            {
                var resultVar = new VariableReference(typeof(NullableResult<bool>), "result");
                var result = new ResultExpression(resultVar);
                return new MethodBodyStatement[]
                {
                    Snippets.Var(resultVar, new MessagePipelineExpression(pipeline).ProcessHeadAsBoolMessage(message, clientDiagnostics, new RequestOptionsExpression(KnownParameters.RequestContext), async)),
                    Snippets.Return(ResultExpression.FromValue(result.Value, result.GetRawResponse()))
                };
            }

            public override TypedValueExpression InvokeServiceOperationCall(TypedValueExpression pipeline, TypedValueExpression message, bool async)
                => ResultExpression.FromResponse(new MessagePipelineExpression(pipeline).ProcessMessage(message, new RequestOptionsExpression(KnownParameters.RequestContext), null, async));

            private static PipelineResponseExpression GetRawResponse(TypedValueExpression result)
                => result.Type.Equals(typeof(PipelineResponse))
                    ? new PipelineResponseExpression(result)
                    : new ResultExpression(result).GetRawResponse();
        }
    }
}
