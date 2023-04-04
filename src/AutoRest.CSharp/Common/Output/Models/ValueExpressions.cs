// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal static class ValueExpressions
    {
        public static class Call
        {
            public static ValueExpression Instance(ValueExpression? instanceReference, string methodName) => new InvokeInstanceMethodExpression(instanceReference, methodName, Array.Empty<ValueExpression>(), false);
            public static ValueExpression Instance(ValueExpression? instanceReference, string methodName, ValueExpression arg) => new InvokeInstanceMethodExpression(instanceReference, methodName, new[]{ arg }, false);
            public static ValueExpression Static(CSharpType? methodType, string methodName) => new InvokeStaticMethodExpression(methodType, methodName, Array.Empty<ValueExpression>());
            public static ValueExpression Static(CSharpType? methodType, string methodName, ValueExpression arg) => new InvokeStaticMethodExpression(methodType, methodName, new[]{ arg });
            public static ValueExpression Extension(CSharpType? methodType, string methodName, ValueExpression instanceReference) => new InvokeStaticMethodExpression(methodType, methodName, new[]{ instanceReference }, CallAsExtension: true);
            public static ValueExpression Extension(CSharpType? methodType, string methodName, ValueExpression instanceReference, ValueExpression arg) => new InvokeStaticMethodExpression(methodType, methodName, new[]{ instanceReference, arg }, CallAsExtension: true);

            public static ValueExpression ToString(ValueExpression reference) => Instance(reference , "ToString");
            public static ValueExpression ToEnum(CSharpType enumType, ValueExpression stringValue) => new InvokeStaticMethodExpression(enumType, $"To{enumType.Implementation.Declaration.Name}", new[]{ stringValue }, null, true);

            public static class PageableHelpers
            {
                private static readonly CSharpType BinaryDataType = typeof(System.BinaryData);
                private static readonly CSharpType PageableHelpersType = typeof(Azure.Core.PageableHelpers);

                public static ValueExpression CreatePageable(
                    CodeWriterDeclaration createFirstPageRequest,
                    CodeWriterDeclaration? createNextPageRequest,
                    ValueExpression clientDiagnostics,
                    ValueExpression pipeline,
                    CSharpType? pageItemType,
                    string scopeName,
                    string itemPropertyName,
                    string? nextLinkPropertyName,
                    ValueExpression? requestContextOrCancellationToken,
                    bool async)
                {
                    var arguments = new List<ValueExpression>
                    {
                        createFirstPageRequest,
                        createNextPageRequest ?? Null,
                        GetValueFactory(pageItemType),
                        clientDiagnostics,
                        pipeline,
                        Literal(scopeName),
                        Literal(itemPropertyName),
                        Literal(nextLinkPropertyName)
                    };

                    if (requestContextOrCancellationToken is not null)
                    {
                        arguments.Add(requestContextOrCancellationToken);
                    }

                    var methodName = async ? nameof(Azure.Core.PageableHelpers.CreateAsyncPageable) : nameof(Azure.Core.PageableHelpers.CreatePageable);
                    return new InvokeStaticMethodExpression(PageableHelpersType, methodName, arguments);
                }

                public static ValueExpression CreatePageable(
                    HttpMessageExpression message,
                    CodeWriterDeclaration? createNextPageRequest,
                    CodeWriterDeclaration clientDiagnostics,
                    HttpPipelineExpression pipeline,
                    CSharpType? pageItemType,
                    OperationFinalStateVia finalStateVia,
                    string scopeName,
                    string itemPropertyName,
                    string? nextLinkPropertyName,
                    ValueExpression? requestContext,
                    bool async)
                {
                    var arguments = new List<ValueExpression>
                    {
                        new ParameterReference(KnownParameters.WaitForCompletion),
                        message,
                        createNextPageRequest ?? Null,
                        GetValueFactory(pageItemType),
                        clientDiagnostics,
                        pipeline,
                        FrameworkEnumValue(finalStateVia),
                        Literal(scopeName),
                        Literal(itemPropertyName),
                        Literal(nextLinkPropertyName)
                    };

                    if (requestContext is not null)
                    {
                        arguments.Add(requestContext);
                    }

                    var methodName = async ? nameof(Azure.Core.PageableHelpers.CreateAsyncPageable) : nameof(Azure.Core.PageableHelpers.CreatePageable);
                    return new InvokeStaticMethodExpression(PageableHelpersType, methodName, arguments, null, false, async);
                }

                public static ValueExpression GetValueFactory(CSharpType? pageItemType)
                {
                    if (pageItemType is null)
                    {
                        throw new NotSupportedException("Type of the element of the page must be specified");
                    }

                    if (pageItemType.Equals(BinaryDataType))
                    {
                        // When `JsonElement` provides access to its UTF8 buffer, change this code to create `BinaryData` from it.
                        // See also PageableHelpers.ParseResponseForBinaryData
                        var e = new CodeWriterDeclaration("e");
                        return new FuncExpression(new[]{e}, BinaryDataExpression.FromString(new JsonElementExpression(e).GetRawText()));
                    }

                    if (pageItemType is { IsFrameworkType: false, Implementation: SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } type })
                    {
                        return SerializableObjectTypeExpression.FromResponseDelegate(type);
                    }

                    var variable = new CodeWriterDeclaration("e");
                    var deserializeImplementation = JsonSerializationMethodsBuilder.GetDeserializeValueExpression(new JsonElementExpression(variable), pageItemType);
                    return new FuncExpression(new[] { variable }, deserializeImplementation);
                }
            }
        }
    }

    internal record NullConditionalExpression(ValueExpression Inner) : ValueExpression;

    internal record FuncExpression(IReadOnlyList<CodeWriterDeclaration> Parameters, ValueExpression Inner) : ValueExpression;
}
