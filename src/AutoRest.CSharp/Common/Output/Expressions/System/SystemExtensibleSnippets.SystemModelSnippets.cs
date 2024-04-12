// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.ClientModel.Primitives;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.Types.HelperTypeProviders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.System
{
    internal partial class SystemExtensibleSnippets
    {
        internal class SystemModelSnippets : ModelSnippets
        {
            public override Method BuildFromOperationResponseMethod(SerializableObjectType type, MethodSignatureModifiers modifiers)
            {
                var result = new Parameter("response", $"The result to deserialize the model from.", typeof(PipelineResponse), null, ValidationType.None, null);
                //var contentType = Snippets.Extensible.Model.ContentTypeFromResponse();
                var contentType = ContentTypeFromResponse();
                var contentyTypeDeclare = new TernaryConditionalOperator(NotEqual(contentType, Null), new ParameterReference(new Parameter("value", null, typeof(string), null, ValidationType.None, null, IsOut: true)), Null);
                MethodBodyStatement[] body;
                if (type.Serialization.Multipart != null)
                {
                    body = new MethodBodyStatement[]
                    {
                        Declare(typeof(string), "contentType", contentyTypeDeclare, out var contentTypeFromResponse),
                        new IfElseStatement(new IfStatement(And(NotEqual(contentTypeFromResponse, Null),new StringExpression(contentTypeFromResponse).StartsWith(Literal("Multipart/form-data"))))
                        {
                            Snippets.Return(SerializableObjectTypeExpression.DeserializeFromMultipart(type, new PipelineResponseExpression(result).Content, contentTypeFromResponse))
                        },
                        new MethodBodyStatement[]
                        {
                            Snippets.UsingVar("document", JsonDocumentExpression.Parse(new PipelineResponseExpression(result).Content), out var document),
                            Snippets.Return(SerializableObjectTypeExpression.Deserialize(type, document.RootElement))
                        })
                    };
                } else
                {
                    body = new MethodBodyStatement[]
                    {
                        Snippets.UsingVar("document", JsonDocumentExpression.Parse(new PipelineResponseExpression(result).Content), out var document),
                        Snippets.Return(SerializableObjectTypeExpression.Deserialize(type, document.RootElement))
                    };
                }
                    return new Method
                (
                    new MethodSignature(Configuration.ApiTypes.FromResponseName, null, $"Deserializes the model from a raw response.", modifiers, type.Type, null, new[] { result }),
                    body
                );
            }

            public override TypedValueExpression InvokeToRequestBodyMethod(TypedValueExpression model) => new BinaryContentExpression(model.Invoke("ToRequestBody"));
            public override ValueExpression ContentTypeFromResponse()
            {
                var result = new Parameter("response", $"The result to deserialize the model from.", typeof(PipelineResponse), null, ValidationType.None, null);
                var response = new PipelineResponseExpression(result);
                var valueParameter = new Parameter("value", null, typeof(string), null, ValidationType.None, null, IsOut: true);
                var valueReference = new ParameterReference(valueParameter);
                return new InvokeInstanceMethodExpression(response.Headers, nameof(ResponseHeaders.TryGetValue), new ValueExpression[] { Literal("Content-Type"), new KeywordExpression("out", new KeywordExpression("var", valueReference)) }, null, false);
            }
            public override MethodBodyStatement DeclareMultipartContent()
            {
                var content = MultipartFormDataRequestContentProvider.Instance;
                var contentVar = new VariableReference(content.Type, "content");
                return Var(contentVar, New.Instance(content.Type));
            }
        }
    }
}
