// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Serialization.Multipart;
using AutoRest.CSharp.Generation.Types;
using Azure.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class MultipartSerializationMethodsBuilder
    {
        public static IEnumerable<MethodBodyStatement> BuildMultipartSerializationMethodBody(MulitipartFormDataObjectSerialization? multipart, ModelReaderWriterOptionsExpression options)
        {
            return new MethodBodyStatement[]
                        {
                            Declare(typeof(string), "boundary", new InvokeInstanceMethodExpression(new InvokeStaticMethodExpression(typeof(Guid), nameof(Guid.NewGuid), Array.Empty<ValueExpression>()), nameof(Guid.ToString), Array.Empty<ValueExpression>(), null, false), out var boundary),
                            UsingDeclare("content", typeof(MultipartFormDataContent), New.Instance(typeof(MultipartFormDataContent), new[]{boundary}), out var content),
                            WriteMultiParts(new MultipartFormDataContentExpression(content), multipart!.Properties, options).ToArray(),
                            Declare(typeof(BinaryData), "binaryData", new InvokeInstanceMethodExpression(content, nameof(MultipartFormDataContent.ToContent), Array.Empty<ValueExpression>(), null, false), out var binaryData),
                            Snippets.Return(binaryData)
                        };
        }
        private static IEnumerable<MethodBodyStatement> WriteMultiParts(MultipartFormDataContentExpression multipartContent, IEnumerable<MultipartPropertySerialization> properties, ModelReaderWriterOptionsExpression? options)
        {
            foreach (MultipartPropertySerialization property in properties)
            {
                if (property.SerializedType is { IsNullable: true })
                {
                    var checkPropertyIsInitialized = TypeFactory.IsCollectionType(property.SerializedType) && !TypeFactory.IsReadOnlyMemory(property.SerializedType) && property.IsRequired
                        ? And(NotEqual(property.Value, Null), InvokeOptional.IsCollectionDefined(property.Value))
                        : NotEqual(property.Value, Null);

                    yield return Serializations.WrapInCheckNotWire(
                        property,
                        options?.Format,
                        InvokeOptional.WrapInIsDefined(
                            property,
                    new IfElseStatement(checkPropertyIsInitialized,
                    WritePropertySerialization(multipartContent, property), null)
                    ));
                }
                else
                {
                    yield return Serializations.WrapInCheckNotWire(
                        property,
                    options?.Format,
                        InvokeOptional.WrapInIsDefined(property, WritePropertySerialization(multipartContent, property)));
                }
                /*
                yield return Serializations.WrapInCheckNotWire(
                    property, options?.Format,
                    WritePropertySerialization(multipartContent, property));
                */
            }
        }
        private static MethodBodyStatement WritePropertySerialization(MultipartFormDataContentExpression mulitpartContent, MultipartPropertySerialization serialization) => serialization switch
        {
            _ when serialization.SerializedType != null && serialization.SerializedType.FrameworkType == typeof(BinaryData) => mulitpartContent.Add(serialization.ToBinaryDataExpression, serialization.SerializedName, serialization.SerializedName + ".wav", Null),
            _ => mulitpartContent.Add(serialization.ToBinaryDataExpression, serialization.SerializedName)
        };
    }
}
