// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Serialization.Multipart;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.Types.HelperTypeProviders;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class MultipartSerializationMethodsBuilder
    {
        public static IEnumerable<Method> BuildMultipartSerializationMethods(MultipartObjectSerialization multipart)
        {
            /* private BinaryData SerializeMultipart(ModelReaderWriterOptions options) */
            yield return new Method(
                new MethodSignature(
                    "SerializeMultipart",
                    null,
                    null,
                    MethodSignatureModifiers.Private,
                    typeof(BinaryData),
                    null,
                    new Parameter[] { KnownParameters.Serializations.Options }),
                BuildMultipartSerializationMethodBody().ToArray());

            /* internal virtual MultipartFormDataRequestContent ToMultipartRequestContent() */
            yield return new Method(
                new MethodSignature(
                    Configuration.ApiTypes.ToMultipartRequestContentName,
                    null,
                    null,
                    MethodSignatureModifiers.Internal | MethodSignatureModifiers.Virtual,
                    MultipartFormDataRequestContentProvider.Instance.Type,
                    null,
                    Array.Empty<Parameter>()),
                BuildToMultipartRequestContentMethodBody(multipart).ToArray());
        }
        public static SwitchCase BuildMultipartWriteSwitchCase(MultipartObjectSerialization multipart, ModelReaderWriterOptionsExpression options)
        {
            return new SwitchCase(
                Serializations.MultipartFormat,
                Return(new InvokeInstanceMethodExpression(null, "SerializeMultipart", new[] { options }, null, false)));
        }

        public static IEnumerable<MethodBodyStatement> BuildMultipartSerializationMethodBody()
        {
            var serializeCallExpression = new InvokeInstanceMethodExpression(null, Configuration.ApiTypes.ToMultipartRequestContentName, Array.Empty<ValueExpression>(), null, false);
            return new MethodBodyStatement[]
                        {
                            UsingDeclare("content", MultipartFormDataRequestContentProvider.Instance.Type, serializeCallExpression, out var content),
                            /*using MemoryStream stream = new MemoryStream();*/
                            UsingDeclare("stream", typeof(MemoryStream), New.Instance(typeof(MemoryStream), Array.Empty<ValueExpression>()), out var stream),
                            /*content.WriteTo(stream, cancellationToken);*/
                            MultipartFormDataRequestContentProvider.Instance.WriteTo(content, stream, null),
                            new IfElseStatement(GreaterThan(stream.Property("Position"), IntExpression.MaxValue),
                            /*return BinaryData.FromStream(stream);*/
                            Return(BinaryDataExpression.FromStream(stream, false)),
                            /*return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));*/
                            Return(New.Instance(typeof(BinaryData), new[]{ new InvokeInstanceMethodExpression((new StreamExpression(stream)).GetBuffer, "AsMemory", new[] { Literal(0), new CastExpression(stream.Property("Position"), typeof(int)) }, null, false) }))
                            ),
                        };
        }

        public static IEnumerable<MethodBodyStatement> BuildToMultipartRequestContentMethodBody(MultipartObjectSerialization? multipart)
        {
            return new MethodBodyStatement[]
                    {
                        Declare(MultipartFormDataRequestContentProvider.Instance.Type, "content", New.Instance(MultipartFormDataRequestContentProvider.Instance.Type), out var content),
                        WriteMultiParts(content, multipart!.Properties).ToArray(),
                        SerializeAdditionalProperties((VariableReference)content, multipart.AdditionalProperties),
                        Return(content)
                    };
        }

        private static IEnumerable<MethodBodyStatement> WriteMultiParts(ValueExpression multipartContent, IEnumerable<MultipartPropertySerialization> properties)
        {
            foreach (MultipartPropertySerialization property in properties)
            {
                if (property.SerializedType is { IsNullable: true })
                {
                    var checkPropertyIsInitialized = property.SerializedType.IsCollection && !property.SerializedType.IsReadOnlyMemory && property.IsRequired
                        ? And(NotEqual(property.Value, Null), InvokeOptional.IsCollectionDefined(property.Value))
                        : NotEqual(property.Value, Null);

                    yield return Serializations.WrapInCheckNotWire(
                        property.ShouldExcludeInWireSerialization,
                        Serializations.MultipartFormat,
                        InvokeOptional.WrapInIsDefined(
                            property,
                    new IfElseStatement(checkPropertyIsInitialized,
                    WritePropertySerialization(multipartContent, property), null)
                    ));
                }
                else
                {
                    yield return Serializations.WrapInCheckNotWire(
                        property.ShouldExcludeInWireSerialization,
                        Serializations.MultipartFormat,
                        InvokeOptional.WrapInIsDefined(property, WritePropertySerialization(multipartContent, property)));
                }
            }
        }

        private static MethodBodyStatement SerializeAdditionalProperties(ValueExpression multipartContent, MultipartAdditionalPropertiesSerialization? additionalProperties)
        {
            if (additionalProperties is null || additionalProperties.ShouldExcludeInWireSerialization)
            {
                return EmptyStatement;
            }
            var additionalPropertiesExpression = new DictionaryExpression(additionalProperties.Type.Arguments[0], additionalProperties.Type.Arguments[1], additionalProperties.Value);
            MethodBodyStatement statement = new ForeachStatement("item", additionalPropertiesExpression, out KeyValuePairExpression item)
            {
                SerializationExression(multipartContent, additionalProperties.ValueSerialization, item.Value, new StringExpression(item.Key))
            };
            return statement;
        }

        private static MethodBodyStatement WritePropertySerialization(ValueExpression mulitpartContent, MultipartPropertySerialization serialization)
        {
            return new[]
            {
                SerializationExression(mulitpartContent, serialization.ValueSerialization,serialization.Value, Literal(serialization.SerializedName))
            };
        }

        private static MethodBodyStatement SerializationExression(ValueExpression mulitpartContent, ObjectSerialization serialization, TypedValueExpression value, StringExpression name) => serialization switch
        {
            MultipartArraySerialization arraySerialization => SerializeArray(mulitpartContent, arraySerialization, value, name),
            MultipartValueSerialization valueSerialization => SerializeValue(mulitpartContent, valueSerialization, value.NullableStructValue(), name),
            MultipartDictionarySerialization dictionarySerialization => SerializeDictionary(mulitpartContent, dictionarySerialization, value.NullableStructValue(), name),
            _ => throw new NotImplementedException($"{serialization.GetType()}")
        };

        private static MethodBodyStatement SerializeArray(ValueExpression mulitpartContent, MultipartArraySerialization serialization, ValueExpression value, StringExpression name)
        {
            return new[]
            {
                new ForeachStatement(serialization.Type.ElementType, "item", value, false, out var item)
                {
                    SerializationExression(mulitpartContent, serialization.ValueSerialization, item, name)
                }
            };
        }

        private static MethodBodyStatement SerializeDictionary(ValueExpression mulitpartContent, MultipartDictionarySerialization serialization, ValueExpression value, StringExpression name)
        {
            var dictionaryExpression = new DictionaryExpression(serialization.Type.Arguments[0], serialization.Type.Arguments[1], value);
            return new[]
            {
                new ForeachStatement("item", dictionaryExpression, out KeyValuePairExpression keyValuePair)
                {
                    SerializationExression(mulitpartContent, serialization.ValueSerialization, keyValuePair.Value, new StringExpression(keyValuePair.Key))
                }
            };
        }

        private static MethodBodyStatement SerializeValue(ValueExpression mulitpartContent, MultipartValueSerialization valueSerialization, ValueExpression valueExpression, StringExpression name)
        {
            ValueExpression? contentExpression = null;
            ValueExpression? fileNameExpression = null;
            ValueExpression? contentTypeExpression = null;
            if (valueSerialization.Type.IsFrameworkType && valueSerialization.Type.FrameworkType == typeof(Stream))
            {
                contentExpression = BuildValueSerizationExpression(valueSerialization.Type, valueExpression);
                if (valueSerialization.FileName != null)
                {
                    fileNameExpression = Literal(valueSerialization.FileName);
                }
                else
                {
                    fileNameExpression = name;
                }
                if (valueSerialization.ContentType != null)
                {
                    contentTypeExpression = Literal(valueSerialization.ContentType);
                }
            }
            if (valueSerialization.Type.IsFrameworkType && valueSerialization.Type.FrameworkType == typeof(BinaryData))
            {
                contentExpression = BuildValueSerizationExpression(valueSerialization.Type, valueExpression);
                if (valueSerialization.FileName != null)
                {
                    fileNameExpression = Literal(valueSerialization.FileName);
                }
                else
                {
                    fileNameExpression = name;
                }
                if (valueSerialization.ContentType != null)
                {
                    contentTypeExpression = Literal(valueSerialization.ContentType);
                }
            }
            if (valueSerialization.Type.IsFrameworkType)
            {
                contentExpression = BuildValueSerizationExpression(valueSerialization.Type, valueExpression);
            }
            if (contentExpression != null)
            {
                return MultipartFormDataRequestContentProvider.Instance.Add(mulitpartContent, contentExpression, name, fileNameExpression, contentTypeExpression);
            }

            switch (valueSerialization.Type.Implementation)
            {
                case SerializableObjectType serializableObjectType:
                    contentExpression = BuildValueSerizationExpression(serializableObjectType.Type, valueExpression);
                    break;
                case EnumType { IsIntValueType: true, IsExtensible: false } enumType:
                    contentExpression = BuildValueSerizationExpression(typeof(int), new CastExpression(valueExpression, enumType.ValueType));
                    break;
                case EnumType enumType:
                    contentExpression = BuildValueSerizationExpression(enumType.ValueType, new EnumExpression(enumType, valueExpression).ToSerial());
                    break;
                default:
                    throw new NotSupportedException($"Cannot build serialization expression for type {valueSerialization.Type}, please add `CodeGenMemberSerializationHooks` to specify the serialization of this type with the customized property");
            }
            return MultipartFormDataRequestContentProvider.Instance.Add(mulitpartContent, contentExpression, name, fileNameExpression, contentTypeExpression);
        }

        private static ValueExpression BuildValueSerizationExpression(CSharpType valueType, ValueExpression valueExpression) => valueType switch
        {
            { IsFrameworkType: true } => valueExpression,
            { IsFrameworkType: false, Implementation: SerializableObjectType serializableObjectType } => new InvokeStaticMethodExpression(typeof(ModelReaderWriter), nameof(ModelReaderWriter.Write), new[] { valueExpression, ModelReaderWriterOptionsExpression.Wire }, new[] { valueType }),
            _ => BinaryDataExpression.FromObjectAsJson(valueExpression)
        };
    }
}
