// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Reflection.PortableExecutable;
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
                return new Method
                (
                    new MethodSignature(Configuration.ApiTypes.FromResponseName, null, $"Deserializes the model from a raw response.", modifiers, type.Type, null, new[] { fromResponse }),
                    new MethodBodyStatement[]
                    {
                        Snippets.UsingVar("document", JsonDocumentExpression.Parse(new ResponseExpression(fromResponse).Content), out var document),
                        Snippets.Return(SerializableObjectTypeExpression.Deserialize(type, document.RootElement))
                    }
                );
            }

            public override TypedValueExpression InvokeToRequestBodyMethod(TypedValueExpression model) => new RequestContentExpression(model.Invoke(Configuration.ApiTypes.ToRequestContentName));
            public override ValueExpression ContentTypeFromResponse()
            {
                var response = new ResponseExpression(KnownParameters.Response);
                var valueParameter = new Parameter("value", null, typeof(string), null, ValidationType.None, null, IsOut: true);
                var valueReference = new ParameterReference(valueParameter);
                return new InvokeInstanceMethodExpression(response.Headers, nameof(ResponseHeaders.TryGetValue), new ValueExpression[] { Literal("Content-Type"), new KeywordExpression("out", valueReference) }, null, false);
            }
        }
    }
}
