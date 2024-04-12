// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Serialization.Multipart;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class MultipartSerializationMethodsBuilder
    {
        public static IEnumerable<Method> BuildMultipartSerializationMethods(MultipartObjectSerialization multipart)
        {
            var options = new ModelReaderWriterOptionsExpression(KnownParameters.Serializations.Options);
            yield return new Method(
                new MethodSignature(
                    "SerializeMultipart",
                    null,
                    null,
                    MethodSignatureModifiers.Private,
                    typeof(BinaryData),
                    null,
                    new Parameter[] { KnownParameters.Serializations.Options }),
                BuildMultipartSerializationMethodBody(multipart).ToArray());
            yield return new Method(
                new MethodSignature(
                    Configuration.ApiTypes.ToMultipartRequestContentName,
                    null,
                    null,
                    MethodSignatureModifiers.Public,
                    typeof(RequestContent),
                    null,
                    new Parameter[] {KnownParameters.Serializations.Options }),
                BuildToMultipartRequestContentMethodBody(multipart).ToArray());
        }
        public static SwitchCase BuildMultipartWriteSwitchCase(MultipartObjectSerialization multipart, ModelReaderWriterOptionsExpression options)
        {
            return new SwitchCase(
                Serializations.MultipartFormat,
                Return(
                    new InvokeInstanceMethodExpression(
                        null,
                        new MethodSignature(
                            $"SerializeMultipart",
                            null,
                            null,
                            MethodSignatureModifiers.Private,
                            typeof(BinaryData),
                            null,
                            new[]
                            {
                                KnownParameters.Serializations.Options
                            }),
                        new ValueExpression[]
                        {
                            options
                        })));
        }

        public static SwitchCase BuildMultipartReadSwitchCase(SerializableObjectType model, BinaryDataExpression data, ModelReaderWriterOptionsExpression options)
        {
            var contentType = data.Property("MediaType");
            return new SwitchCase(
                Serializations.MultipartFormat,
                Return(
                    new InvokeInstanceMethodExpression(
                        null,
                        new MethodSignature(
                            $"DeserializeMultipart",
                            null,
                            null,
                            MethodSignatureModifiers.Private,
                            typeof(BinaryData),
                            null,
                            new[]
                            {
                                KnownParameters.Serializations.Data,
                                KnownParameters.Serializations.contentType
                            }),
                        new ValueExpression[]
                        {
                            data,
                            contentType
                        })));
        }
        public static IEnumerable<MethodBodyStatement> BuildMultipartSerializationBody(MultipartObjectSerialization? multipart)
        {
            var contentVar = new VariableReference(Configuration.ApiTypes.MultipartRequestContentType, "content");
            return new MethodBodyStatement[]
                    {
                        //Snippets.Extensible.Model.DeclareMultipartContent(),
                        //Declare(typeof(string), "boundary", new InvokeInstanceMethodExpression(new InvokeStaticMethodExpression(typeof(Guid), nameof(Guid.NewGuid), Array.Empty<ValueExpression>()), nameof(Guid.ToString), Array.Empty<ValueExpression>(), null, false), out var boundary),
                        //UsingDeclare("content", Configuration.ApiTypes.MultipartRequestContentType, New.Instance(Configuration.ApiTypes.MultipartRequestContentType, new[]{boundary}), out var content),
                        UsingDeclare("content", Configuration.ApiTypes.MultipartRequestContentType, New.Instance(Configuration.ApiTypes.MultipartRequestContentType, Array.Empty<ValueExpression>()), out var content),
                        WriteMultiParts(content, multipart!.Properties/*, options*/).ToArray(),
                        SerializeAdditionalProperties(content, multipart.AdditionalProperties)
                    };
        }
        public static IEnumerable<MethodBodyStatement> BuildMultipartSerializationMethodBody(MultipartObjectSerialization? multipart)
        {
            //var declaration = new CodeWriterDeclaration(name);
            //variable = new VariableReference(type, declaration);
            //var contentVar = new VariableReference(Configuration.ApiTypes.MultipartRequestContentType, new CodeWriterDeclaration("content"));
            return new MethodBodyStatement[]
                        {
                            //Declare(typeof(string), "boundary", new InvokeInstanceMethodExpression(new InvokeStaticMethodExpression(typeof(Guid), nameof(Guid.NewGuid), Array.Empty<ValueExpression>()), nameof(Guid.ToString), Array.Empty<ValueExpression>(), null, false), out var boundary),
                            //UsingDeclare("content", Configuration.ApiTypes.MultipartRequestContentType, New.Instance(Configuration.ApiTypes.MultipartRequestContentType, new[]{boundary}), out var content),
                            //Snippets.Extensible.Model.DeclareMultipartContent(),
                            UsingDeclare("content", Configuration.ApiTypes.MultipartRequestContentType, New.Instance(Configuration.ApiTypes.MultipartRequestContentType, Array.Empty<ValueExpression>()), out var content),
                            WriteMultiParts(content, multipart!.Properties/*, options*/).ToArray(),
                            SerializeAdditionalProperties(content, multipart.AdditionalProperties),
                            Declare(typeof(BinaryData), "binaryData", new InvokeStaticMethodExpression(typeof(ModelReaderWriter), nameof(ModelReaderWriter.Write), new List<ValueExpression>(){ content, ModelReaderWriterOptionsExpression.MultipartFormData},null, false), out var binaryData),
                            Snippets.Return(binaryData)
                        };
        }
        public static IEnumerable<MethodBodyStatement> BuildToMultipartRequestContentMethodBody(MultipartObjectSerialization? multipart)
        {
            //var contentVar = new VariableReference(Configuration.ApiTypes.MultipartRequestContentType, "content");
            return new MethodBodyStatement[]
                    {
                        //Declare(typeof(string), "boundary", new InvokeInstanceMethodExpression(new InvokeStaticMethodExpression(typeof(Guid), nameof(Guid.NewGuid), Array.Empty<ValueExpression>()), nameof(Guid.ToString), Array.Empty<ValueExpression>(), null, false), out var boundary),
                        //UsingDeclare("content", Configuration.ApiTypes.MultipartRequestContentType, New.Instance(Configuration.ApiTypes.MultipartRequestContentType, new[] { boundary }), out var content),
                        //Snippets.Extensible.Model.DeclareMultipartContent(),
                        UsingDeclare("content", Configuration.ApiTypes.MultipartRequestContentType, New.Instance(Configuration.ApiTypes.MultipartRequestContentType, Array.Empty<ValueExpression>()), out var content),
                        WriteMultiParts(content, multipart!.Properties/*, options*/).ToArray(),
                        SerializeAdditionalProperties(content, multipart.AdditionalProperties),
                        Return(content)
                    };
        }
        /*TODO: handle additionalProperties. */
        private static IEnumerable<MethodBodyStatement> WriteMultiParts(VariableReference multipartContent, IEnumerable<MultipartPropertySerialization> properties/*, ModelReaderWriterOptionsExpression? options*/)
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
                        /*options?.Format*/Literal("MFD"),
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
                    /*options?.Format*/Literal("MFD"),
                        InvokeOptional.WrapInIsDefined(property, WritePropertySerialization(multipartContent, property)));
                }
                /*
                yield return Serializations.WrapInCheckNotWire(
                    property, options?.Format,
                    WritePropertySerialization(multipartContent, property));
                */
            }
        }

        private static MethodBodyStatement SerializeAdditionalProperties(VariableReference multipartContent, MultipartAdditionalPropertiesSerialization? additionalProperties)
        {
            if (additionalProperties is null)
            {
                return EmptyStatement;
            }
            var additionalPropertiesExpression = new DictionaryExpression(additionalProperties.Type.Arguments[0], additionalProperties.Type.Arguments[1], additionalProperties.Value);
            MethodBodyStatement statement = new ForeachStatement("item", additionalPropertiesExpression, out KeyValuePairExpression item)
            {
                //multipartContent.Add(BuildValueSerizationExpression(additionalProperties.Type.Arguments[1], item.Value), item.Key)
                SerializationExression(multipartContent, additionalProperties.ValueSerialization, item.Value, new StringExpression(item.Key))
            };
            return statement;
        }
        private static MethodBodyStatement WritePropertySerialization(VariableReference mulitpartContent, MultipartPropertySerialization serialization)
        {
            return new[]
            {
                SerializationExression(mulitpartContent, serialization.ValueSerialization,serialization.Value, Literal(serialization.SerializedName))
            };
        }
        private static MethodBodyStatement SerializationExression(VariableReference mulitpartContent, ObjectSerialization serialization, TypedValueExpression value, StringExpression name) => serialization switch
        {
            MultipartArraySerialization arraySerialization => SerializeArray(mulitpartContent, arraySerialization, value, name),
            MultipartValueSerialization valueSerialization => SerializeValue(mulitpartContent, valueSerialization, value.NullableStructValue(), name),
            _ => throw new NotImplementedException()
        };
        private static MethodBodyStatement SerializeArray(VariableReference mulitpartContent, MultipartArraySerialization serialization, ValueExpression value, StringExpression name)
        {
            return new[]
            {
                //new EnumerableExpression(TypeFactory.GetElementType(array.ImplementationType)
                new ForeachStatement(TypeFactory.GetElementType(serialization.Type), "item", value, false, out var item)
                {
                    SerializationExression(mulitpartContent, serialization.ValueSerialization, item, name)
                }
            };
        }

        private static MethodBodyStatement SerializeValue(VariableReference mulitpartContent, MultipartValueSerialization valueSerialization, ValueExpression valueExpression, StringExpression name)
        {
            if (valueSerialization.Type.IsFrameworkType && valueSerialization.Type.FrameworkType == typeof(Stream))
            {
                //return multipartContentExpression.Add(BuildValueSerizationExpression(valueSerialization.Type, valueExpression), name, name.Add(Literal(".wav")));
                return Configuration.ApiTypes.GetMultipartFormDataRequestContentAddStatment(mulitpartContent,
                    BuildValueSerizationExpression(valueSerialization.Type, valueExpression),
                    name, name.Add(Literal(".wav")));
            }
            if (valueSerialization.Type.IsFrameworkType && valueSerialization.Type.FrameworkType == typeof(BinaryData))
            {
                if (valueSerialization.ContentType != "application/json")
                {
                    //return multipartContentExpression.Add(BuildValueSerizationExpression(valueSerialization.Type, valueExpression), name, name.Add(Literal(".wav")));
                    return Configuration.ApiTypes.GetMultipartFormDataRequestContentAddStatment(mulitpartContent,
                                               BuildValueSerizationExpression(valueSerialization.Type, valueExpression),
                                                                      name, name.Add(Literal(".wav")));
                } else
                {
                    //return multipartContentExpression.Add(BuildValueSerizationExpression(valueSerialization.Type, valueExpression), name);
                    return Configuration.ApiTypes.GetMultipartFormDataRequestContentAddStatment(mulitpartContent,
                                                                      BuildValueSerizationExpression(valueSerialization.Type, valueExpression),
                                                                      name, null);
                }
            }
            if (valueSerialization.Type.IsFrameworkType)
            {
                //return multipartContentExpression.Add(BuildValueSerizationExpression(valueSerialization.Type, valueExpression), name);
                return Configuration.ApiTypes.GetMultipartFormDataRequestContentAddStatment(mulitpartContent,
                    BuildValueSerizationExpression(valueSerialization.Type, valueExpression),
                    name, null);
            }
            switch (valueSerialization.Type.Implementation)
            {
                case SerializableObjectType serializableObjectType:
                    //return multipartContentExpression.Add(BuildValueSerizationExpression(serializableObjectType.Type, valueExpression), name);
                    return Configuration.ApiTypes.GetMultipartFormDataRequestContentAddStatment(mulitpartContent,
                        BuildValueSerizationExpression(serializableObjectType.Type, valueExpression),name, null);
                case ObjectType:
                    //return multipartContentExpression.Add(BuildValueSerizationExpression(valueSerialization.Type, valueExpression), name);
                    return Configuration.ApiTypes.GetMultipartFormDataRequestContentAddStatment(mulitpartContent,
                        BuildValueSerizationExpression(valueSerialization.Type, valueExpression), name, null);
                case EnumType { IsIntValueType: true, IsExtensible: false } enumType:
                    //return multipartContentExpression.Add(BuildValueSerizationExpression(typeof(int), valueExpression), name);
                    return Configuration.ApiTypes.GetMultipartFormDataRequestContentAddStatment(mulitpartContent,
                        BuildValueSerizationExpression(typeof(int), valueExpression), name, null);
                case EnumType { IsNumericValueType: true } enumType:
                    //return multipartContentExpression.Add(BuildValueSerizationExpression(typeof(float), valueExpression), name);
                    return Configuration.ApiTypes.GetMultipartFormDataRequestContentAddStatment(mulitpartContent,
                        BuildValueSerizationExpression(typeof(float), valueExpression), name, null);
                case EnumType enumType:
                    //return multipartContentExpression.Add(BuildValueSerizationExpression(typeof(string), valueExpression), name);
                    return Configuration.ApiTypes.GetMultipartFormDataRequestContentAddStatment(mulitpartContent,
                        BuildValueSerizationExpression(typeof(string), valueExpression), name, null);
                default:
                    throw new NotSupportedException($"Cannot build serialization expression for type {valueSerialization.Type}, please add `CodeGenMemberSerializationHooks` to specify the serialization of this type with the customized property");
            }
        }

        private static ValueExpression BuildValueSerizationExpression(CSharpType valueType,  ValueExpression valueExpression) => valueType switch
        {
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(string) => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.FromString), new[] { valueExpression }),
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(byte[]) => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.FromBytes), new[] { valueExpression }),
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(Stream) => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.FromStream), new[] { valueExpression }),
            //_ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(BinaryData) => new InvokeInstanceMethodExpression(valueExpression, nameof(BinaryData.WithMediaType), new[] { Literal("application/octet-stream") }, null, false),
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(BinaryData) => valueExpression,
            _ => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.FromObjectAsJson), new[] { valueExpression }, new[] { valueType })
        };

        private static ValueExpression BuildValueDeserializationExpression(CSharpType valueType, ValueExpression valueExpression) => valueType switch
        {
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(string) => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.ToString), new[] { valueExpression }),
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(byte[]) => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.ToArray), new[] { valueExpression }),
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(Stream) => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.ToStream), new[] { valueExpression }),
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(BinaryData) => valueExpression,
            _ => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.ToObjectFromJson), new[] { valueExpression }, new[] { valueType})

        };
    }
}
