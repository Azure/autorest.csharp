﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Azure;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions.Azure
{
    internal partial class AzureExtensibleSnippets
    {
        internal class AzureModelSnippets : ModelSnippets
        {
            public override Method BuildFromOperationResponseMethod(SerializableObjectType type, MethodSignatureModifiers modifiers)
            {
                var fromResponse = new Parameter("response", $"The response to deserialize the model from.", typeof(Response), null, ValidationType.None, null);
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
                            Snippets.Return(SerializableObjectTypeExpression.DeserializeFromMultipart(type, new ResponseExpression(fromResponse).Content, contentTypeFromResponse))
                        },
                        new MethodBodyStatement[]
                        {
                            Snippets.UsingVar("document", JsonDocumentExpression.Parse(new ResponseExpression(fromResponse).Content), out var document),
                            Snippets.Return(SerializableObjectTypeExpression.Deserialize(type, document.RootElement))
                        })
                    };
                } else
                {
                    body = new MethodBodyStatement[]
                    {
                        Snippets.UsingVar("document", JsonDocumentExpression.Parse(new ResponseExpression(fromResponse).Content), out var document),
                        Snippets.Return(SerializableObjectTypeExpression.Deserialize(type, document.RootElement))
                    };
                }
                return new Method
                (
                    new MethodSignature(Configuration.ApiTypes.FromResponseName, null, $"Deserializes the model from a raw response.", modifiers, type.Type, null, new[] { fromResponse }),
                    body
                );
            }

            public override TypedValueExpression InvokeToRequestBodyMethod(TypedValueExpression model) => new RequestContentExpression(model.Invoke(Configuration.ApiTypes.ToRequestContentName));
            public override ValueExpression ContentTypeFromResponse()
            {
                var response = new ResponseExpression(KnownParameters.Response);
                var valueParameter = new Parameter("value", null, typeof(string), null, ValidationType.None, null, IsOut: true);
                var valueReference = new ParameterReference(valueParameter);
                return new InvokeInstanceMethodExpression(response.Headers, nameof(ResponseHeaders.TryGetValue), new ValueExpression[] { Literal("Content-Type"), new KeywordExpression("out", new KeywordExpression("var", valueReference)) }, null, false);
            }
        }
    }
}
