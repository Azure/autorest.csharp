// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Expressions
{
    internal abstract partial class ExtensibleSnippets
    {
        internal abstract class ModelSnippets
        {
            public virtual Method BuildConversionToRequestBodyMethod(MethodSignatureModifiers modifiers)
            {
                var utf8RequestContent = Utf8JsonRequestContentProvider.Instance;
                return new Method
                (
                    new MethodSignature(Configuration.ApiTypes.ToRequestContentName, null, $"Convert into a {utf8RequestContent.Declaration.Name}.", modifiers, utf8RequestContent.Inherits, null, Array.Empty<Parameter>()),
                    new[]
                    {
                        Extensible.RestOperations.DeclareContentWithUtf8JsonWriter(out var requestContent, out var writer),
                        writer.WriteObjectValue(This),
                        Return(requestContent)
                    }
                );
            }

            public abstract Method BuildFromOperationResponseMethod(SerializableObjectType type, MethodSignatureModifiers modifiers);
            public abstract TypedValueExpression InvokeToRequestBodyMethod(TypedValueExpression model);
        }
    }
}
