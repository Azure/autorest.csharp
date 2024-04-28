// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions
{
    internal abstract partial class ExtensibleSnippets
    {
        internal abstract class ModelSnippets
        {
            public virtual Method BuildConversionToRequestBodyMethod(MethodSignatureModifiers modifiers, CSharpType type)
            {
                var bodyStatements = Configuration.IsBranded
                    ? new[]
                    {
                        Extensible.RestOperations.DeclareContentWithUtf8JsonWriter(out var requestContent, out var writer),
                        writer.WriteObjectValue(new TypedValueExpression(type, This), ModelReaderWriterOptionsExpression.Wire),
                        Return(requestContent)
                    }
                    : new[]
                    {
                        Return(BinaryContentExpression.Create(This, ModelReaderWriterOptionsExpression.Wire, type))
                    };
                return new Method
                (
                    new MethodSignature(Configuration.ApiTypes.ToRequestContentName, null, $"Convert into a {Configuration.ApiTypes.RequestContentType:C}.", modifiers, Configuration.ApiTypes.RequestContentType, null, Array.Empty<Parameter>()),
                    bodyStatements
                );
            }

            public abstract Method BuildFromOperationResponseMethod(SerializableObjectType type, MethodSignatureModifiers modifiers);
            public abstract TypedValueExpression InvokeToRequestBodyMethod(TypedValueExpression model);
        }
    }
}
