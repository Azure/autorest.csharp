// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Microsoft.CodeAnalysis;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using SerializationFormat = AutoRest.CSharp.Output.Models.Serialization.SerializationFormat;
using ValidationType = AutoRest.CSharp.Output.Models.Shared.ValidationType;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal static class JsonSerializationMethodsBuilder
    {
        private static readonly CSharpType modelReaderWriterOptionsType = typeof(ModelReaderWriterOptions);
        private static readonly CSharpType nullableModelReaderWriterOptionsType = new CSharpType(typeof(ModelReaderWriterOptions), isNullable: true);

        private static readonly Parameter utf8JsonWriterParameter = new Parameter("writer", null, typeof(Utf8JsonWriter), null, ValidationType.None, null);
        private static readonly Parameter optionsParameter = new Parameter("options", null, modelReaderWriterOptionsType, null, ValidationType.None, null);
        private static readonly Parameter optionalOptionsParameter = new Parameter("options", null, nullableModelReaderWriterOptionsType, Constant.Default(nullableModelReaderWriterOptionsType), ValidationType.None, null);
        private static readonly Parameter elementParameter = new Parameter("element", null, typeof(JsonElement), null, ValidationType.None, null);
        private static readonly Parameter dataParameter = new Parameter("data", null, typeof(BinaryData), null, ValidationType.None, null);
        private static readonly Parameter utf8JsonReaderParameter = new Parameter("reader", null, typeof(Utf8JsonReader), null, ValidationType.None, null, IsRef: true);
        private static readonly ValueExpression jsonFormat = new TypeReference(typeof(ModelReaderWriterFormat)).Property(nameof(ModelReaderWriterFormat.Json));
        private static readonly BoolExpression isJsonFormatExpression = Equal(new ModelReaderWriterOptionsExpression(optionsParameter).Format, jsonFormat);

        public static IEnumerable<Method> BuildJsonSerializationMethods(SerializableObjectType model, JsonObjectSerialization jsonObjectSerialization)
        {
            var jsonModelTType = new CSharpType(typeof(IJsonModel<>), model.Type);

            // void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
            yield return new
            (
                new MethodSignature(Configuration.ApiTypes.IUtf8JsonSerializableWriteName, null, null, MethodSignatureModifiers.None, null, null, new[] { utf8JsonWriterParameter }, ExplicitInterface: Configuration.ApiTypes.IUtf8JsonSerializableType),
                This.CastTo(jsonModelTType).Invoke(nameof(IJsonModel<object>.Write), utf8JsonWriterParameter, ModelReaderWriterOptionsExpression.DefaultWireOptions)
            );

            // void IJsonModel<T>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            yield return new
            (
                new MethodSignature(nameof(IJsonModel<object>.Write), null, null, MethodSignatureModifiers.None, null, null, new[] { utf8JsonWriterParameter, optionsParameter }, ExplicitInterface: jsonModelTType),
                WriteObject(new Utf8JsonWriterExpression(utf8JsonWriterParameter), jsonObjectSerialization)
            );

            // T IJsonModel<T>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            yield return new
            (
                new MethodSignature(nameof(IJsonModel<object>.Read), null, null, MethodSignatureModifiers.None, model.Type, null, new[] { utf8JsonReaderParameter, optionsParameter }, ExplicitInterface: jsonModelTType),
                new MethodBodyStatement[]
                {
                    // ModelSerializerHelper.ValidateFormat(this, options.Format);
                    BuildModelSerializerHelperValidateFormatStatement(model.Type, new ModelReaderWriterOptionsExpression(optionsParameter).Format, true),
                    EmptyLine,
                    // using var document = JsonDocument.ParseValue(ref reader);
                    UsingDeclare("document", JsonDocumentExpression.ParseValue(utf8JsonReaderParameter), out var docVariable),
                    // return DeserializeXXX(doc.RootElement, options);
                    Return(SerializableObjectTypeExpression.Deserialize(model, docVariable.RootElement, optionsParameter))
                }
            );

            // if the model is a struct, it needs to implement IJsonModel<object> as well which leads to another 2 methods
            if (model.IsStruct)
            {
                var jsonModelObjectType = typeof(IJsonModel<object>);
                // void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
                yield return new
                (
                    new MethodSignature(nameof(IJsonModel<object>.Write), null, null, MethodSignatureModifiers.None, null, null, new[] { utf8JsonWriterParameter, optionsParameter }, ExplicitInterface: jsonModelObjectType),
                    This.CastTo(jsonModelTType).Invoke(nameof(IJsonModel<object>.Write), utf8JsonWriterParameter, optionsParameter)
                );

                // object IJsonModel<object>.Read(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                yield return new
                (
                    new MethodSignature(nameof(IJsonModel<object>.Read), null, null, MethodSignatureModifiers.None, typeof(object), null, new[] { utf8JsonReaderParameter, optionsParameter }, ExplicitInterface: jsonModelObjectType),
                    This.CastTo(jsonModelTType).Invoke(nameof(IJsonModel<object>.Read), utf8JsonReaderParameter, optionsParameter)
                );
            }
        }

        public static IEnumerable<Method> BuildIModelMethods(SerializableObjectType model, bool hasJson, bool hasXml)
        {
            var modelTType = new CSharpType(typeof(IModel<>), model.Type);
            var jsonModelTType = new CSharpType(typeof(IJsonModel<>), model.Type);

            // BinaryData IModel<T>.Write(ModelReaderWriterOptions options)
            yield return new
            (
                new MethodSignature(nameof(IModel<object>.Write), null, null, MethodSignatureModifiers.None, typeof(BinaryData), null, new[] { optionsParameter }, ExplicitInterface: modelTType),
                new MethodBodyStatement[]
                {
                    // ModelSerializerHelper.ValidateFormat(this, options.Format);
                    BuildModelSerializerHelperValidateFormatStatement(model.Type, new ModelReaderWriterOptionsExpression(optionsParameter).Format, true),
                    EmptyLine,
                    BuildModelWriteMethod(hasJson, hasXml)
                }
            );

            // T IModel<T>.Read(BinaryData data, ModelReaderWriterOptions options)
            yield return new
            (
                new MethodSignature(nameof(IModel<object>.Read), null, null, MethodSignatureModifiers.None, model.Type, null, new[] { dataParameter, optionsParameter }, ExplicitInterface: modelTType),
                new MethodBodyStatement[]
                {
                    // ModelSerializerHelper.ValidateFormat(this, options.Format);
                    BuildModelSerializerHelperValidateFormatStatement(model.Type, new ModelReaderWriterOptionsExpression(optionsParameter).Format, true),
                    EmptyLine,
                    BuildModelReadMethod(model, hasJson, hasXml)
                }
            );

            // ModelReaderWriterFormat IModel<T>.GetWireFormat(ModelReaderWriterOptions options)
            yield return new
            (
                new MethodSignature(nameof(IModel<object>.GetWireFormat), null, null, MethodSignatureModifiers.None, typeof(ModelReaderWriterFormat), null, new[] { optionsParameter }, ExplicitInterface: modelTType),
                hasXml ? ModelReaderWriterFormatExpression.Xml : ModelReaderWriterFormatExpression.Json
            );

            // if the model is a struct, it needs to implement IModel<object> as well which leads to another 2 methods
            if (model.IsStruct)
            {
                var modelSerializableObjectType = typeof(IModel<object>);
                // BinaryData IModel<object>.Write(ModelReaderWriterOptions options)
                yield return new
                (
                    new MethodSignature(nameof(IModel<object>.Write), null, null, MethodSignatureModifiers.None, typeof(BinaryData), null, new[] { optionsParameter }, ExplicitInterface: modelSerializableObjectType),
                    // => (IModel<T>this).Write(options);
                    This.CastTo(modelTType).Invoke(nameof(IModel<object>.Write), optionsParameter)
                );

                // object IModel<object>.Read(BinaryData data, ModelReaderWriterOptions options)
                yield return new
                (
                    new MethodSignature(nameof(IModel<object>.Read), null, null, MethodSignatureModifiers.None, typeof(object), null, new[] { dataParameter, optionsParameter }, ExplicitInterface: modelSerializableObjectType),
                    // => (IModel<T>this).Read(options);
                    This.CastTo(modelTType).Invoke(nameof(IModel<object>.Read), dataParameter, optionsParameter)
                );

                // ModelReaderWriterFormat IModel<object>.GetWireFormat(ModelReaderWriterOptions options)
                yield return new
                (
                    new MethodSignature(nameof(IModel<object>.GetWireFormat), null, null, MethodSignatureModifiers.None, typeof(ModelReaderWriterFormat), null, new[] { optionsParameter }, ExplicitInterface: modelSerializableObjectType),
                    // => (IModel<T>this).GetWireFormat(options);
                    This.CastTo(modelTType).Invoke(nameof(IModel<object>.GetWireFormat), optionsParameter)
                );
            }

            static MethodBodyStatement BuildModelWriteMethod(bool hasJson, bool hasXml)
            {
                // return ModelReaderWriter.WriteCore(this, options);
                var jsonPart = Return(new InvokeStaticMethodExpression(typeof(ModelReaderWriter), nameof(ModelReaderWriter.Write), new[] { This, optionsParameter }));
                /*  using MemoryStream stream = new MemoryStream();
                    using XmlWriter writer = XmlWriter.Create(stream);
                    ((IXmlSerializable)this).Write(writer, null);
                    writer.Flush();
                    if (stream.Position > int.MaxValue)
                    {
                        return BinaryData.FromStream(stream);
                    }
                    else
                    {
                        return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                    }
                 */
                var xmlPart = new MethodBodyStatement[]
                {
                UsingDeclare("stream", typeof(MemoryStream), New.Instance(typeof(MemoryStream)), out var stream),
                UsingDeclare("writer", typeof(XmlWriter), new InvokeStaticMethodExpression(typeof(XmlWriter), nameof(XmlWriter.Create), new[] { stream }), out var xmlWriter),
                This.CastTo(typeof(IXmlSerializable)).Invoke(nameof(IXmlSerializable.Write), xmlWriter, Null).ToStatement(),
                xmlWriter.Invoke(nameof(MemoryStream.Flush)).ToStatement(),
                new IfElseStatement(GreaterThan(stream.Property(nameof(Stream.Position)), IntExpression.MaxValue),
                    // return BinaryData.FromStream(stream);
                    Return(BinaryDataExpression.FromStream(stream, false)),
                    // return new BinaryData(stream.GetBuffer().AsMemory(0, (int)stream.Position));
                    Return(New.Instance(typeof(BinaryData),
                        InvokeStaticMethodExpression.Extension(
                            typeof(MemoryExtensions),
                            nameof(MemoryExtensions.AsMemory),
                            stream.Invoke(nameof(MemoryStream.GetBuffer)),
                            new[]{Int(0), stream.Property(nameof(Stream.Position)).CastTo(typeof(int))}
                            ))))
                };

                if (hasJson && hasXml)
                {
                    // we have both, we need to wrap things in a if-else statement
                    return new IfElseStatement(isJsonFormatExpression, jsonPart, xmlPart);
                }

                if (hasJson)
                    return jsonPart;

                if (hasXml)
                    return xmlPart;

                throw new InvalidOperationException("We should never get here if we have neither json serialization nor xml serialization");
            }

            static MethodBodyStatement BuildModelReadMethod(SerializableObjectType model, bool hasJson, bool hasXml)
            {
                var data = new BinaryDataExpression(dataParameter);
                /* using var document = JsonDocument.ParseValue(ref reader);
                 * return DeserializeXXX(doc.RootElement, options);
                 */
                var jsonPart = new MethodBodyStatement[]
                {
                UsingDeclare("document", JsonDocumentExpression.Parse(dataParameter), out var docVariable),
                Return(SerializableObjectTypeExpression.Deserialize(model, docVariable.RootElement, optionsParameter))
                };
                // return DeserializeXmlCollection(XElement.Load(data.ToStream()), options);
                var xmlPart = Return(SerializableObjectTypeExpression.Deserialize(model, XElementExpression.Load(data.ToStream()), optionsParameter));

                if (hasJson && hasXml)
                {
                    // we have both, we need to wrap things in a if-else statement
                    // condition: data.ToMemory().Span.StartsWith("{"u8)
                    var condition = data.ToMemory().Property(nameof(ReadOnlyMemory<byte>.Span))
                        .Invoke(nameof(MemoryExtensions.StartsWith), LiteralU8("{"));
                    return new IfElseStatement(condition, jsonPart, xmlPart);
                }

                if (hasJson)
                    return jsonPart;

                if (hasXml)
                    return xmlPart;

                throw new InvalidOperationException("We should never get here if we have neither json serialization nor xml serialization");
            }
        }

        private static MethodBodyStatement BuildModelSerializerHelperValidateFormatStatement(CSharpType type, ValueExpression format, bool hasJson)
        {
            /*
                bool implementsJson = model is IJsonModel<T>;
                bool isValid = (format == ModelReaderWriterFormat.Json && implementsJson) || format == ModelReaderWriterFormat.Wire;
                if (!isValid)
                {
                    throw new FormatException($"The model {model.GetType().Name} does not support '{format}' format.");
                }
             */
            var iJsonModelType = new CSharpType(typeof(IJsonModel<>), type);
            var isValid = new VariableReference(typeof(bool), "isValid");
            if (hasJson)
            {
                return new MethodBodyStatement[]
                {
                    Declare(isValid, Or(Equal(format, ModelReaderWriterFormatExpression.Json), Equal(format, ModelReaderWriterFormatExpression.Wire))),
                    new IfStatement(Not(new BoolExpression(isValid)))
                    {
                        Throw(New.Instance(
                            typeof(FormatException),
                            new FormattableStringExpression("The model {0} does not support '{1}' format.", new[]
                            {
                                new InvokeInstanceMethodExpression(null, nameof(GetType), Array.Empty<ValueExpression>(), null, false).Property(nameof(Type.Name)),
                                format
                            })))
                    }
                };
            }
            else
            {
                var implementsJson = new VariableReference(typeof(bool), "implementsJson");
                return new MethodBodyStatement[]
                {
                Declare(implementsJson, Is(This, iJsonModelType)),
                Declare(isValid, Or(And(Equal(format, ModelReaderWriterFormatExpression.Json), new BoolExpression(implementsJson)), Equal(format, ModelReaderWriterFormatExpression.Wire))),
                new IfStatement(Not(new BoolExpression(isValid)))
                {
                    Throw(New.Instance(typeof(FormatException), new InvokeStaticMethodExpression(
                        typeof(string),
                        nameof(string.Format),
                        new ValueExpression[]
                        {
                            Literal("The model {0} does not support '{1}' format."),
                            new InvokeInstanceMethodExpression(null, nameof(GetType), Array.Empty<ValueExpression>(), null, false).Property(nameof(Type.Name)),
                            format
                        })))
                }
                };
            }
        }

        public static Method BuildToRequestContent(MethodSignatureModifiers modifiers)
        {
            return new Method
            (
                new MethodSignature(Configuration.ApiTypes.ToRequestContentName, null, $"Convert into a Utf8Json{Configuration.ApiTypes.RequestContentType.Name}.", modifiers, Configuration.ApiTypes.RequestContentType, null, Array.Empty<Parameter>()),
                new[]
                {
                    Var("content", New.Utf8JsonRequestContent(), out var requestContent),
                    requestContent.JsonWriter.WriteObjectValue(This),
                    Return(requestContent)
                }
            );
        }

        // new PipelineContentContent(CreateContent(model, options ?? ModelReaderWriterOptions.DefaultWireOptions));

        public static MethodBodyStatement[] WriteObject(Utf8JsonWriterExpression utf8JsonWriter, JsonObjectSerialization serialization)
            => new[]
            {
                utf8JsonWriter.WriteStartObject(),
                WriteProperties(utf8JsonWriter, serialization.Properties).ToArray(),
                SerializeAdditionalProperties(utf8JsonWriter, serialization.AdditionalProperties),
                utf8JsonWriter.WriteEndObject()
            };

        public static IEnumerable<MethodBodyStatement> WriteProperties(Utf8JsonWriterExpression utf8JsonWriter, IEnumerable<JsonPropertySerialization> properties)
        {
            foreach (JsonPropertySerialization property in properties)
            {
                if (property.ValueSerialization == null)
                {
                    // Flattened property
                    yield return Serializations.WrapInCheckIsJson(
                        property,
                        new ModelReaderWriterOptionsExpression(optionsParameter).Format,
                        new[]
                        {
                            utf8JsonWriter.WritePropertyName(property.SerializedName),
                            utf8JsonWriter.WriteStartObject(),
                            WriteProperties(utf8JsonWriter, property.PropertySerializations!).ToArray(),
                            utf8JsonWriter.WriteEndObject(),
                        });
                }
                else if (property.SerializedType is { IsNullable: true })
                {
                    var checkPropertyIsInitialized = TypeFactory.IsCollectionType(property.SerializedType) && !TypeFactory.IsReadOnlyMemory(property.SerializedType) && property.IsRequired
                        ? And(NotEqual(property.Value, Null), InvokeOptional.IsCollectionDefined(property.Value))
                        : NotEqual(property.Value, Null);

                    yield return Serializations.WrapInCheckIsJson(
                        property,
                        new ModelReaderWriterOptionsExpression(optionsParameter).Format,
                        InvokeOptional.WrapInIsDefined(
                            property,
                            new IfElseStatement(checkPropertyIsInitialized,
                                WritePropertySerialization(utf8JsonWriter, property),
                                utf8JsonWriter.WriteNull(property.SerializedName)
                            ))
                    );
                }
                else
                {
                    yield return Serializations.WrapInCheckIsJson(
                        property,
                        new ModelReaderWriterOptionsExpression(optionsParameter).Format,
                        InvokeOptional.WrapInIsDefined(property, WritePropertySerialization(utf8JsonWriter, property)));
                }
            }
        }

        private static MethodBodyStatement WritePropertySerialization(Utf8JsonWriterExpression utf8JsonWriter, JsonPropertySerialization serialization)
        {
            return new[]
            {
                utf8JsonWriter.WritePropertyName(serialization.SerializedName),
                serialization.CustomSerializationMethodName is {} serializationMethodName
                    ? InvokeCustomSerializationMethod(serializationMethodName, utf8JsonWriter)
                    : SerializeExpression(utf8JsonWriter, serialization.ValueSerialization, serialization.EnumerableValue ?? serialization.Value)
            };
        }

        private static MethodBodyStatement SerializeAdditionalProperties(Utf8JsonWriterExpression utf8JsonWriter, JsonAdditionalPropertiesSerialization? additionalProperties)
        {
            if (additionalProperties is null)
            {
                return MethodBodyStatement.Empty;
            }

            var additionalPropertiesExpression = new DictionaryExpression(TypeFactory.GetElementType(additionalProperties.Type), additionalProperties.Value);
            MethodBodyStatement statement = new ForeachStatement("item", additionalPropertiesExpression, out KeyValuePairExpression item)
            {
                utf8JsonWriter.WritePropertyName(item.Key),
                SerializeExpression(utf8JsonWriter, additionalProperties.ValueSerialization, item.Value)
            };

            if (additionalProperties.ShouldExcludeInWireSerialization)
            {
                statement = new IfStatement(And(NotEqual(additionalPropertiesExpression, Null), isJsonFormatExpression))
                {
                    statement
                };
            }

            return statement;
        }

        public static MethodBodyStatement SerializeExpression(Utf8JsonWriterExpression utf8JsonWriter, JsonSerialization? serialization, ValueExpression expression)
            => serialization switch
            {
                JsonArraySerialization array => SerializeArray(utf8JsonWriter, array, new EnumerableExpression(TypeFactory.GetElementType(array.ImplementationType), expression)),
                JsonDictionarySerialization dictionary => SerializeDictionary(utf8JsonWriter, dictionary, new DictionaryExpression(TypeFactory.GetElementType(dictionary.Type), expression)),
                JsonValueSerialization value => SerializeValue(utf8JsonWriter, value, expression),
                _ => throw new NotSupportedException()
            };

        private static MethodBodyStatement SerializeArray(Utf8JsonWriterExpression utf8JsonWriter, JsonArraySerialization arraySerialization, EnumerableExpression array)
        {
            return new[]
            {
                utf8JsonWriter.WriteStartArray(),
                new ForeachStatement("item", array, out var item)
                {
                    CheckCollectionItemForNull(utf8JsonWriter, arraySerialization.ValueSerialization, item),
                    SerializeExpression(utf8JsonWriter, arraySerialization.ValueSerialization, item)
                },
                utf8JsonWriter.WriteEndArray()
            };
        }

        private static MethodBodyStatement SerializeDictionary(Utf8JsonWriterExpression utf8JsonWriter, JsonDictionarySerialization dictionarySerialization, DictionaryExpression dictionary)
        {
            return new[]
            {
                utf8JsonWriter.WriteStartObject(),
                new ForeachStatement("item", dictionary, out KeyValuePairExpression keyValuePair)
                {
                    utf8JsonWriter.WritePropertyName(keyValuePair.Key),
                    CheckCollectionItemForNull(utf8JsonWriter, dictionarySerialization.ValueSerialization, keyValuePair.Value),
                    SerializeExpression(utf8JsonWriter, dictionarySerialization.ValueSerialization, keyValuePair.Value)
                },
                utf8JsonWriter.WriteEndObject()
            };
        }

        private static MethodBodyStatement SerializeValue(Utf8JsonWriterExpression utf8JsonWriter, JsonValueSerialization valueSerialization, ValueExpression value)
        {
            if (valueSerialization.Type.SerializeAs is not null)
            {
                return SerializeFrameworkTypeValue(utf8JsonWriter, valueSerialization, value, valueSerialization.Type.SerializeAs);
            }

            if (valueSerialization.Type.IsFrameworkType)
            {
                return SerializeFrameworkTypeValue(utf8JsonWriter, valueSerialization, value, valueSerialization.Type.FrameworkType);
            }

            switch (valueSerialization.Type.Implementation)
            {
                case SystemObjectType systemObjectType when IsCustomJsonConverterAdded(systemObjectType.SystemType):
                    if (valueSerialization.Options == JsonSerializationOptions.UseManagedServiceIdentityV3)
                    {
                        return new[]
                        {
                            Var("serializeOptions", New.JsonSerializerOptions(), out var serializeOptions),
                            InvokeJsonSerializerSerializeMethod(utf8JsonWriter, value, serializeOptions)
                        };
                    }

                    return InvokeJsonSerializerSerializeMethod(utf8JsonWriter, value);

                case ObjectType:
                    return utf8JsonWriter.WriteObjectValue(value);

                case EnumType { IsIntValueType: true, IsExtensible: false } enumType:
                    return utf8JsonWriter.WriteNumberValue(new CastExpression(value.NullableStructValue(valueSerialization.Type), enumType.ValueType));

                case EnumType { IsNumericValueType: true } enumType:
                    return utf8JsonWriter.WriteNumberValue(new EnumExpression(enumType, value.NullableStructValue(valueSerialization.Type)).ToSerial());

                case EnumType enumType:
                    return utf8JsonWriter.WriteStringValue(new EnumExpression(enumType, value.NullableStructValue(valueSerialization.Type)).ToSerial());
            }

            throw new NotSupportedException();
        }

        private static MethodBodyStatement SerializeFrameworkTypeValue(Utf8JsonWriterExpression utf8JsonWriter, JsonValueSerialization valueSerialization, ValueExpression value, Type valueType)
        {
            if (valueType == typeof(JsonElement))
            {
                return new JsonElementExpression(value).WriteTo(utf8JsonWriter);
            }

            if (valueType == typeof(Nullable<>))
            {
                valueType = valueSerialization.Type.Arguments[0].FrameworkType;
            }

            value = value.NullableStructValue(valueSerialization.Type);

            if (valueType == typeof(decimal) || valueType == typeof(double) || valueType == typeof(float) || valueType == typeof(long) || valueType == typeof(int) || valueType == typeof(short))
            {
                return utf8JsonWriter.WriteNumberValue(value);
            }

            if (valueType == typeof(object))
            {
                return utf8JsonWriter.WriteObjectValue(value);
            }

            if (valueType == typeof(string) || valueType == typeof(char) || valueType == typeof(Guid) || valueType == typeof(ResourceIdentifier) || valueType == typeof(ResourceType) || valueType == typeof(AzureLocation))
            {
                return utf8JsonWriter.WriteStringValue(value);
            }

            if (valueType == typeof(bool))
            {
                return utf8JsonWriter.WriteBooleanValue(value);
            }

            if (valueType == typeof(byte[]))
            {
                return utf8JsonWriter.WriteBase64StringValue(value, valueSerialization.Format.ToFormatSpecifier());
            }

            if (valueType == typeof(DateTimeOffset) || valueType == typeof(DateTime) || valueType == typeof(TimeSpan))
            {
                var format = valueSerialization.Format.ToFormatSpecifier();

                if (valueSerialization.Format is SerializationFormat.Duration_Seconds)
                {
                    return utf8JsonWriter.WriteNumberValue(InvokeConvert.ToInt32(new TimeSpanExpression(value).ToString(format)));
                }

                if (valueSerialization.Format is SerializationFormat.Duration_Seconds_Float)
                {
                    return utf8JsonWriter.WriteNumberValue(InvokeConvert.ToDouble(new TimeSpanExpression(value).ToString(format)));
                }

                if (valueSerialization.Format is SerializationFormat.DateTime_Unix)
                {
                    return utf8JsonWriter.WriteNumberValue(value, format);
                }
                return format is not null
                    ? utf8JsonWriter.WriteStringValue(value, format)
                    : utf8JsonWriter.WriteStringValue(value);
            }

            if (valueType == typeof(ETag) || valueType == typeof(ContentType) || valueType == typeof(IPAddress) || valueType == typeof(RequestMethod))
            {
                return utf8JsonWriter.WriteStringValue(value.InvokeToString());
            }

            if (valueType == typeof(Uri))
            {
                return utf8JsonWriter.WriteStringValue(new MemberExpression(value, nameof(Uri.AbsoluteUri)));
            }

            if (valueType == typeof(BinaryData))
            {
                if (valueSerialization.Format is SerializationFormat.Bytes_Base64 or SerializationFormat.Bytes_Base64Url)
                {
                    return utf8JsonWriter.WriteBase64StringValue(new BinaryDataExpression(value).ToArray(), valueSerialization.Format.ToFormatSpecifier());
                }

                return new IfElsePreprocessorDirective
                (
                    "NET6_0_OR_GREATER",
                    utf8JsonWriter.WriteRawValue(value),
                    new UsingScopeStatement(typeof(JsonDocument), "document", JsonDocumentExpression.Parse(value), out var jsonDocumentVar)
                    {
                        InvokeJsonSerializerSerializeMethod(utf8JsonWriter, new JsonDocumentExpression(jsonDocumentVar).RootElement)
                    }
                );
            }

            if (IsCustomJsonConverterAdded(valueType))
            {
                return InvokeJsonSerializerSerializeMethod(utf8JsonWriter, value);
            }

            throw new NotSupportedException($"Framework type {valueType} serialization not supported");
        }

        private static MethodBodyStatement CheckCollectionItemForNull(Utf8JsonWriterExpression utf8JsonWriter, JsonSerialization valueSerialization, ValueExpression value)
            => CollectionItemRequiresNullCheckInSerialization(valueSerialization)
                ? new IfStatement(Equal(value, Null)) { utf8JsonWriter.WriteNullValue(), Continue }
                : MethodBodyStatement.Empty;

        public static Method? BuildDeserialize(TypeDeclarationOptions declaration, JsonObjectSerialization serialization, INamedTypeSymbol? existingType)
        {
            var methodName = $"Deserialize{declaration.Name}";
            var signature = new MethodSignature(methodName, null, null, MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static, serialization.Type, null, new[] { elementParameter, optionalOptionsParameter });
            if (SourceInputHelper.TryGetExistingMethod(existingType, signature, out _))
            {
                return null;
            }

            return new Method(signature, BuildDeserializeBody(elementParameter, optionsParameter, serialization).ToArray());
        }

        public static Method BuildFromResponse(SerializableObjectType model, MethodSignatureModifiers modifiers)
        {
            var fromResponse = new Parameter(Configuration.ApiTypes.ResponseParameterName, $"The {Configuration.ApiTypes.ResponseParameterName} to deserialize the model from.", new CSharpType(Configuration.ApiTypes.FromResponseType), null, ValidationType.None, null);
            return new Method
            (
                new MethodSignature(Configuration.ApiTypes.FromResponseName, null, $"Deserializes the model from a raw response.", modifiers, model.Type, null, new[] { fromResponse }),
                new MethodBodyStatement[]
                {
                    UsingVar("document", JsonDocumentExpression.Parse(Configuration.ApiTypes.GetFromResponseExpression(fromResponse).Content), out var document),
                    Return(SerializableObjectTypeExpression.Deserialize(model, document.RootElement, ModelReaderWriterOptionsExpression.DefaultWireOptions))
                }
            );
        }

        private static IEnumerable<MethodBodyStatement> BuildDeserializeBody(Parameter element, Parameter options, JsonObjectSerialization serialization)
        {
            // fallback to Default options if it is null
            yield return AssignIfNull((ValueExpression)options, ModelReaderWriterOptionsExpression.DefaultWireOptions);

            yield return EmptyLine;

            var jsonElement = new JsonElementExpression(element);
            if (!serialization.Type.IsValueType) // only return null for reference type (e.g. no enum)
            {
                yield return new IfStatement(jsonElement.ValueKindEqualsNull())
                {
                    Return(Null)
                };
            }

            var discriminator = serialization.Discriminator;
            if (discriminator is not null && discriminator.HasDescendants)
            {
                yield return new IfStatement(jsonElement.TryGetProperty(element.Name, discriminator.SerializedName, out var discriminatorElement))
                {
                    new SwitchStatement(discriminatorElement.GetString(), GetDiscriminatorCases(jsonElement, discriminator).ToArray())
                };
            }

            if (discriminator is not null && !serialization.Type.HasParent && !serialization.Type.Equals(discriminator.DefaultObjectType.Type))
            {
                yield return Return(GetDeserializeImplementation(discriminator.DefaultObjectType.Type.Implementation, jsonElement, null));
            }
            else
            {
                yield return WriteObjectInitialization(jsonElement, serialization).ToArray();
            }
        }

        private static IEnumerable<SwitchCase> GetDiscriminatorCases(JsonElementExpression element, ObjectTypeDiscriminator discriminator)
        {
            foreach (var implementation in discriminator.Implementations)
            {
                yield return new SwitchCase(Literal(implementation.Key), Return(GetDeserializeImplementation(implementation.Type.Implementation, element, null)), true);
            }
        }

        private static IEnumerable<MethodBodyStatement> WriteObjectInitialization(JsonElementExpression element, JsonObjectSerialization serialization)
        {
            // this is the first level of object hierarchy
            // collect all properties and initialize the dictionary
            var propertyVariables = new Dictionary<JsonPropertySerialization, VariableReference>();

            CollectPropertiesForDeserialization(propertyVariables, serialization.Properties);

            var additionalProperties = serialization.AdditionalProperties;
            if (additionalProperties != null)
            {
                propertyVariables.Add(additionalProperties, new VariableReference(additionalProperties.Value.Type, additionalProperties.SerializationConstructorParameterName));
            }

            bool isThisTheDefaultDerivedType = serialization.Type.Equals(serialization.Discriminator?.DefaultObjectType.Type);

            foreach (var variable in propertyVariables)
            {
                if (serialization.Discriminator?.SerializedName == variable.Key.SerializedName &&
                    isThisTheDefaultDerivedType &&
                    serialization.Discriminator.Value is not null &&
                    (!serialization.Discriminator.Property.ValueType.IsEnum || serialization.Discriminator.Property.ValueType.Implementation is EnumType { IsExtensible: true }))
                {
                    var defaultValue = serialization.Discriminator.Value.Value.Value?.ToString();
                    yield return Declare(variable.Value, Literal(defaultValue));
                }
                else
                {
                    yield return Declare(variable.Value, Default);
                }
            }

            var shouldTreatEmptyStringAsNull = Configuration.ModelsToTreatEmptyStringAsNull.Contains(serialization.Type.Name);
            var objAdditionalProperties = serialization.AdditionalProperties;
            if (objAdditionalProperties != null)
            {
                var dictionary = new VariableReference(objAdditionalProperties.Type, "additionalPropertiesDictionary");
                yield return Declare(dictionary, New.Instance(objAdditionalProperties.Type));
                yield return new ForeachStatement("property", element.EnumerateObject(), out var property)
                {
                    DeserializeIntoObjectProperties(serialization.Properties, objAdditionalProperties, new JsonPropertyExpression(property), new DictionaryExpression(TypeFactory.GetElementType(objAdditionalProperties.Type), dictionary), propertyVariables, shouldTreatEmptyStringAsNull).ToArray()
                };
                yield return new AssignValueStatement(propertyVariables[objAdditionalProperties], dictionary);
            }
            else
            {
                yield return new ForeachStatement("property", element.EnumerateObject(), out var property)
                {
                    DeserializeIntoObjectProperties(serialization.Properties, new JsonPropertyExpression(property), propertyVariables, shouldTreatEmptyStringAsNull)
                };
            }

            var parameterValues = propertyVariables.ToDictionary(v => v.Key.SerializationConstructorParameterName, v => GetOptional(v.Key, v.Value));
            var parameters = serialization.ConstructorParameters
                .Select(p => parameterValues[p.Name])
                .ToArray();

            yield return Return(New.Instance(serialization.Type, parameters));
        }

        private static IEnumerable<MethodBodyStatement> DeserializeIntoObjectProperties(IEnumerable<JsonPropertySerialization> propertySerializations, JsonAdditionalPropertiesSerialization additionalPropertiesSerialization, JsonPropertyExpression jsonProperty, DictionaryExpression dictionary, IReadOnlyDictionary<JsonPropertySerialization, VariableReference> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            yield return DeserializeIntoObjectProperties(propertySerializations, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull);
            // in the case here, this line returns an empty statement, we only want the value here
            DeserializeValue(additionalPropertiesSerialization.ValueSerialization!, jsonProperty.Value, out var value);
            var additionalPropertiesStatement = dictionary.Add(jsonProperty.Name, value);

            if (additionalPropertiesSerialization.ShouldExcludeInWireSerialization)
            {
                yield return new IfStatement(isJsonFormatExpression)
                {
                    additionalPropertiesStatement
                };
            }
            else
            {
                yield return additionalPropertiesStatement;
            }
        }

        private static MethodBodyStatement DeserializeIntoObjectProperties(IEnumerable<JsonPropertySerialization> propertySerializations, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, VariableReference> propertyVariables, bool shouldTreatEmptyStringAsNull)
            => propertySerializations
                .Select(p => new IfStatement(jsonProperty.NameEquals(p.SerializedName))
                {
                    DeserializeIntoObjectProperty(p, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull)
                })
                .ToArray();

        private static MethodBodyStatement DeserializeIntoObjectProperty(JsonPropertySerialization jsonPropertySerialization, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, VariableReference> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            // write the deserialization hook
            if (jsonPropertySerialization.CustomDeserializationMethodName is { } deserializationMethodName)
            {
                return new[]
                {
                    CreatePropertyNullCheckStatement(jsonPropertySerialization, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull),
                    InvokeCustomDeserializationMethod(deserializationMethodName, jsonProperty, propertyVariables[jsonPropertySerialization].Declaration),
                    Continue
                };
            }

            // Reading a property value
            if (jsonPropertySerialization.ValueSerialization is not null)
            {
                List<MethodBodyStatement> statements = new List<MethodBodyStatement>
                {
                    CreatePropertyNullCheckStatement(jsonPropertySerialization, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull),
                    DeserializeValue(jsonPropertySerialization.ValueSerialization, jsonProperty.Value, out var value)
                };

                AssignValueStatement assignStatement = TypeFactory.IsReadOnlyMemory(jsonPropertySerialization.SerializedType!)
                    ? Assign(propertyVariables[jsonPropertySerialization], New.Instance(jsonPropertySerialization.SerializedType!, value))
                    : Assign(propertyVariables[jsonPropertySerialization], value);
                statements.Add(assignStatement);
                statements.Add(Continue);
                return statements;
            }

            // Reading a nested object
            if (jsonPropertySerialization.PropertySerializations is not null)
            {
                return new[]
                {
                    CreatePropertyNullCheckStatement(jsonPropertySerialization, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull),
                    new ForeachStatement("property", jsonProperty.Value.EnumerateObject(), out var nestedItemVariable)
                    {
                        DeserializeIntoObjectProperties(jsonPropertySerialization.PropertySerializations, new JsonPropertyExpression(nestedItemVariable), propertyVariables, shouldTreatEmptyStringAsNull)
                    },
                    Continue
                };
            }

            throw new InvalidOperationException($"Either {nameof(JsonPropertySerialization.ValueSerialization)} must not be null or {nameof(JsonPropertySerialization.PropertySerializations)} must not be null.");
        }

        private static MethodBodyStatement CreatePropertyNullCheckStatement(JsonPropertySerialization jsonPropertySerialization, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, VariableReference> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            if (jsonPropertySerialization.CustomDeserializationMethodName is not null)
            {
                // if we have the deserialization hook here, we do not need to do any check, all these checks should be taken care of by the hook
                return new MethodBodyStatement();
            }

            var checkEmptyProperty = GetCheckEmptyPropertyValueExpression(jsonProperty, jsonPropertySerialization, shouldTreatEmptyStringAsNull);
            var serializedType = jsonPropertySerialization.SerializedType;
            if (serializedType?.IsNullable == true)
            {
                // we only assign null when it is not a collection if we have DeserializeNullCollectionAsNullValue configuration is off
                // specially when it is required, we assign ChangeTrackingList because for optional lists we are already doing that
                if (!TypeFactory.IsCollectionType(serializedType) || Configuration.DeserializeNullCollectionAsNullValue)
                {
                    return new IfStatement(checkEmptyProperty)
                    {
                        Assign(propertyVariables[jsonPropertySerialization], Null),
                        Continue
                    };
                }

                if (jsonPropertySerialization.IsRequired && !TypeFactory.IsReadOnlyMemory(serializedType))
                {
                    return new IfStatement(checkEmptyProperty)
                    {
                        Assign(propertyVariables[jsonPropertySerialization], New.Instance(TypeFactory.GetPropertyImplementationType(serializedType))),
                        Continue
                    };
                }

                return new IfStatement(checkEmptyProperty)
                {
                    Continue
                };
            }

            // even if ReadOnlyMemory is required we leave the list empty if the payload doesn't have it
            if ((!jsonPropertySerialization.IsRequired || (serializedType is not null && TypeFactory.IsReadOnlyMemory(serializedType))) &&
                serializedType?.Equals(typeof(JsonElement)) != true && // JsonElement handles nulls internally
                serializedType?.Equals(typeof(string)) != true) //https://github.com/Azure/autorest.csharp/issues/922
            {
                if (jsonPropertySerialization.PropertySerializations is null)
                {
                    return new IfStatement(checkEmptyProperty)
                    {
                        Continue
                    };
                }

                return new IfStatement(checkEmptyProperty)
                {
                    jsonProperty.ThrowNonNullablePropertyIsNull(),
                    Continue
                };
            }

            return new MethodBodyStatement();
        }

        private static ValueExpression GetCheckEmptyPropertyValueExpression(JsonPropertyExpression jsonProperty, JsonPropertySerialization jsonPropertySerialization, bool shouldTreatEmptyStringAsNull)
        {
            var jsonElement = jsonProperty.Value;
            if (!shouldTreatEmptyStringAsNull)
            {
                return jsonElement.ValueKindEqualsNull();
            }

            if (jsonPropertySerialization.ValueSerialization is not JsonValueSerialization { Type.IsFrameworkType: true } valueSerialization)
            {
                return jsonElement.ValueKindEqualsNull();
            }

            if (!Configuration.IntrinsicTypesToTreatEmptyStringAsNull.Contains(valueSerialization.Type.FrameworkType.Name))
            {
                return jsonElement.ValueKindEqualsNull();
            }

            return Or(jsonElement.ValueKindEqualsNull(), And(jsonElement.ValueKindEqualsString(), Equal(jsonElement.GetString().Length, Int(0))));

        }

        /// Collects a list of properties being read from all level of object hierarchy
        private static void CollectPropertiesForDeserialization(IDictionary<JsonPropertySerialization, VariableReference> propertyVariables, IEnumerable<JsonPropertySerialization> jsonProperties)
        {
            foreach (JsonPropertySerialization jsonProperty in jsonProperties)
            {
                if (jsonProperty.SerializedType is { } type)
                {
                    var propertyDeclaration = new CodeWriterDeclaration(jsonProperty.SerializedName.ToVariableName());
                    if (!jsonProperty.IsRequired)
                    {
                        if (type.IsFrameworkType && type.FrameworkType == typeof(Nullable<>))
                        {
                            type = new CSharpType(type.Arguments[0].FrameworkType);
                        }
                        type = new CSharpType(Configuration.ApiTypes.OptionalPropertyType, type);
                    }

                    propertyVariables.Add(jsonProperty, new VariableReference(type, propertyDeclaration));
                }
                else if (jsonProperty.PropertySerializations != null)
                {
                    CollectPropertiesForDeserialization(propertyVariables, jsonProperty.PropertySerializations);
                }
            }
        }

        public static MethodBodyStatement BuildDeserializationForMethods(JsonSerialization serialization, bool async, ValueExpression? variable, BaseResponseExpression response, bool isBinaryData)
        {
            if (isBinaryData)
            {
                var callFromStream = BinaryDataExpression.FromStream(response, async);
                var variableExpression = variable is not null ? new BinaryDataExpression(variable) : null;
                return AssignOrReturn(variableExpression, callFromStream);
            }

            var declareDocument = UsingVar("document", JsonDocumentExpression.Parse(response, async), out var document);
            var deserializeValueBlock = DeserializeValue(serialization, document.RootElement, out var value);

            if (!serialization.IsNullable)
            {
                return new[] { declareDocument, deserializeValueBlock, AssignOrReturn(variable, value) };
            }

            return new MethodBodyStatement[]
            {
                declareDocument,
                new IfElseStatement
                (
                    document.RootElement.ValueKindEqualsNull(),
                    AssignOrReturn(variable, Null),
                    new[]{deserializeValueBlock, AssignOrReturn(variable, value)}
                )
            };
        }

        public static MethodBodyStatement DeserializeValue(JsonSerialization serialization, JsonElementExpression element, out ValueExpression value)
        {
            switch (serialization)
            {
                case JsonArraySerialization jsonReadOnlyMemory when TypeFactory.IsArray(jsonReadOnlyMemory.ImplementationType):
                    var readOnlyMemory = new VariableReference(jsonReadOnlyMemory.ImplementationType, "array");
                    value = readOnlyMemory;
                    VariableReference index = new VariableReference(typeof(int), "index");

                    return new MethodBodyStatement[]
                    {
                        Declare(index, Int(0)),
                        Declare(readOnlyMemory, New.Array(jsonReadOnlyMemory.ImplementationType, element.GetArrayLength())),
                        new ForeachStatement("item", element.EnumerateArray(), out ValueExpression readOnlyMemoryItem)
                        {
                            DeserializeArrayItem(jsonReadOnlyMemory, value, new JsonElementExpression(readOnlyMemoryItem), index),
                            Increment(index)
                        }
                    };

                case JsonArraySerialization jsonArray:
                    var array = new VariableReference(jsonArray.ImplementationType, "array");
                    value = array;

                    return new MethodBodyStatement[]
                    {
                        Declare(array, New.Instance(jsonArray.ImplementationType)),
                        new ForeachStatement("item", element.EnumerateArray(), out ValueExpression arrayItem)
                        {
                            DeserializeArrayItem(jsonArray, value, new JsonElementExpression(arrayItem)),
                        }
                    };

                case JsonDictionarySerialization jsonDictionary:
                    var dictionary = new VariableReference(jsonDictionary.Type, "dictionary");
                    value = dictionary;
                    return new MethodBodyStatement[]
                    {
                        Declare(dictionary, New.Instance(jsonDictionary.Type)),
                        new ForeachStatement("property", element.EnumerateObject(), out var property)
                        {
                            DeserializeDictionaryValue(jsonDictionary.ValueSerialization, new DictionaryExpression(TypeFactory.GetElementType(jsonDictionary.Type), value), new JsonPropertyExpression(property))
                        }
                    };

                case JsonValueSerialization { Options: JsonSerializationOptions.UseManagedServiceIdentityV3 } valueSerialization:
                    var declareSerializeOptions = Var("serializeOptions", New.JsonSerializerOptions(), out var serializeOptions);
                    value = GetDeserializeValueExpression(element, valueSerialization.Type, valueSerialization.Format, serializeOptions);
                    return declareSerializeOptions;

                case JsonValueSerialization valueSerialization:
                    value = GetDeserializeValueExpression(element, valueSerialization.Type, valueSerialization.Format);
                    return MethodBodyStatement.Empty;

                default:
                    throw new InvalidOperationException($"{serialization.GetType()} is not supported.");
            }
        }

        private static MethodBodyStatement DeserializeArrayItem(JsonArraySerialization serialization, ValueExpression arrayVariable, JsonElementExpression arrayItemVariable, ValueExpression? index = null)
        {
            bool isArray = index is not null;

            List<MethodBodyStatement> statements = new List<MethodBodyStatement>();

            MethodBodyStatement deserializeAndAssign = new[]
            {
                DeserializeValue(serialization.ValueSerialization, arrayItemVariable, out var value),
                isArray ? InvokeArrayElementAssignment(arrayVariable, index!, value) : InvokeListAdd(arrayVariable, value)
            };

            if (CollectionItemRequiresNullCheckInSerialization(serialization.ValueSerialization))
            {
                statements.Add(new IfElseStatement(
                    arrayItemVariable.ValueKindEqualsNull(),
                    isArray ? InvokeArrayElementAssignment(arrayVariable, index!, Null) : InvokeListAdd(arrayVariable, Null),
                    deserializeAndAssign));
            }
            else
            {
                statements.Add(deserializeAndAssign);
            }

            return statements;
        }

        private static MethodBodyStatement DeserializeDictionaryValue(JsonSerialization serialization, DictionaryExpression dictionary, JsonPropertyExpression property)
        {
            var deserializeValueBlock = new[]
            {
                DeserializeValue(serialization, property.Value, out var value),
                dictionary.Add(property.Name, value)
            };

            if (CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                return new IfElseStatement
                (
                    property.Value.ValueKindEqualsNull(),
                    dictionary.Add(property.Name, Null),
                    deserializeValueBlock
                );
            }

            return deserializeValueBlock;
        }

        public static ValueExpression GetDeserializeValueExpression(JsonElementExpression element, CSharpType serializationType, SerializationFormat serializationFormat = SerializationFormat.Default, ValueExpression? serializerOptions = null)
        {
            if (serializationType.SerializeAs != null)
            {
                return new CastExpression(GetFrameworkTypeValueExpression(serializationType.SerializeAs, element, serializationFormat, serializationType), serializationType);
            }

            if (serializationType.IsFrameworkType)
            {
                var frameworkType = serializationType.FrameworkType;
                if (frameworkType == typeof(Nullable<>))
                {
                    frameworkType = serializationType.Arguments[0].FrameworkType;
                }

                return GetFrameworkTypeValueExpression(frameworkType, element, serializationFormat, serializationType);
            }

            return GetDeserializeImplementation(serializationType.Implementation, element, serializerOptions);
        }

        public static ValueExpression GetDeserializeImplementation(TypeProvider implementation, JsonElementExpression element, ValueExpression? serializerOptions)
        {
            switch (implementation)
            {
                case SystemObjectType systemObjectType when IsCustomJsonConverterAdded(systemObjectType.SystemType):
                    return InvokeJsonSerializerDeserializeMethod(element, implementation.Type, serializerOptions);

                case Resource { ResourceData: SerializableObjectType resourceDataType } resource:
                    return New.Instance(resource.Type, new MemberExpression(null, "Client"), SerializableObjectTypeExpression.Deserialize(resourceDataType, element));

                case MgmtObjectType mgmtObjectType when TypeReferenceTypeChooser.HasMatch(mgmtObjectType.ObjectSchema):
                    return InvokeJsonSerializerDeserializeMethod(element, implementation.Type);

                case SerializableObjectType type:
                    return SerializableObjectTypeExpression.Deserialize(type, element);

                case EnumType clientEnum:
                    var value = GetFrameworkTypeValueExpression(clientEnum.ValueType.FrameworkType, element, SerializationFormat.Default, null);
                    return EnumExpression.ToEnum(clientEnum, value);

                default:
                    throw new NotSupportedException($"No deserialization logic exists for {implementation.Declaration.Name}");
            }
        }

        private static ValueExpression GetOptional(PropertySerialization jsonPropertySerialization, TypedValueExpression variable)
        {
            var sourceType = variable.Type;
            if (!sourceType.IsFrameworkType || sourceType.FrameworkType != Configuration.ApiTypes.OptionalPropertyType)
            {
                return variable;
            }

            var targetType = jsonPropertySerialization.Value.Type;
            if (TypeFactory.IsList(targetType) && !TypeFactory.IsReadOnlyMemory(targetType))
            {
                return InvokeOptional.ToList(variable);
            }

            if (TypeFactory.IsDictionary(targetType))
            {
                return InvokeOptional.ToDictionary(variable);
            }

            if (targetType is { IsValueType: true, IsNullable: true })
            {
                return InvokeOptional.ToNullable(variable);
            }

            if (targetType.IsNullable)
            {
                return new MemberExpression(variable, "Value");
            }

            return variable;
        }

        public static ValueExpression GetFrameworkTypeValueExpression(Type frameworkType, JsonElementExpression element, SerializationFormat format, CSharpType? serializationType)
        {
            if (frameworkType == typeof(ETag) ||
                frameworkType == typeof(Uri) ||
                frameworkType == typeof(ResourceIdentifier) ||
                frameworkType == typeof(ResourceType) ||
                frameworkType == typeof(ContentType) ||
                frameworkType == typeof(RequestMethod) ||
                frameworkType == typeof(AzureLocation))
            {
                return New.Instance(frameworkType, element.GetString());
            }

            if (frameworkType == typeof(IPAddress))
            {
                return new InvokeStaticMethodExpression(typeof(IPAddress), nameof(IPAddress.Parse), new[] { element.GetString() });
            }

            if (frameworkType == typeof(BinaryData))
            {
                return format is SerializationFormat.Bytes_Base64 or SerializationFormat.Bytes_Base64Url
                    ? BinaryDataExpression.FromBytes(element.GetBytesFromBase64(format.ToFormatSpecifier()))
                    : BinaryDataExpression.FromString(element.GetRawText());
            }

            if (IsCustomJsonConverterAdded(frameworkType) && serializationType is not null)
            {
                return InvokeJsonSerializerDeserializeMethod(element, serializationType);
            }

            if (frameworkType == typeof(JsonElement))
                return element.InvokeClone();
            if (frameworkType == typeof(object))
                return element.GetObject();
            if (frameworkType == typeof(bool))
                return element.GetBoolean();
            if (frameworkType == typeof(char))
                return element.GetChar();

            if (frameworkType == typeof(short))
                return element.GetInt16();
            if (frameworkType == typeof(int))
                return element.GetInt32();
            if (frameworkType == typeof(long))
                return element.GetInt64();
            if (frameworkType == typeof(float))
                return element.GetSingle();
            if (frameworkType == typeof(double))
                return element.GetDouble();
            if (frameworkType == typeof(decimal))
                return element.GetDecimal();
            if (frameworkType == typeof(string))
                return element.GetString();
            if (frameworkType == typeof(Guid))
                return element.GetGuid();
            if (frameworkType == typeof(byte[]))
                return element.GetBytesFromBase64(format.ToFormatSpecifier());

            if (frameworkType == typeof(DateTimeOffset))
            {
                return format == SerializationFormat.DateTime_Unix
                    ? DateTimeOffsetExpression.FromUnixTimeSeconds(element.GetInt64())
                    : element.GetDateTimeOffset(format.ToFormatSpecifier());
            }

            if (frameworkType == typeof(DateTime))
                return element.GetDateTime();
            if (frameworkType == typeof(TimeSpan))
            {
                if (format == SerializationFormat.Duration_Seconds)
                {
                    return TimeSpanExpression.FromSeconds(element.GetInt32());
                }

                if (format == SerializationFormat.Duration_Seconds_Float)
                {
                    return TimeSpanExpression.FromSeconds(element.GetDouble());
                }

                return element.GetTimeSpan(format.ToFormatSpecifier());
            }

            throw new NotSupportedException($"Framework type {frameworkType} is not supported");
        }

        private static MethodBodyStatement InvokeListAdd(ValueExpression list, ValueExpression value)
            => new InvokeInstanceMethodStatement(list, nameof(List<object>.Add), value);

        private static MethodBodyStatement InvokeArrayElementAssignment(ValueExpression array, ValueExpression index, ValueExpression value)
            => new AssignValueStatement(new ArrayElementExpression(array, index), value);

        private static ValueExpression InvokeJsonSerializerDeserializeMethod(JsonElementExpression element, CSharpType serializationType, ValueExpression? options = null)
        {
            var arguments = options is null
                ? new[] { element.GetRawText() }
                : new[] { element.GetRawText(), options };
            return new InvokeStaticMethodExpression(typeof(JsonSerializer), nameof(JsonSerializer.Deserialize), arguments, new[] { serializationType });
        }

        private static MethodBodyStatement InvokeJsonSerializerSerializeMethod(ValueExpression writer, ValueExpression value)
            => new InvokeStaticMethodStatement(typeof(JsonSerializer), nameof(JsonSerializer.Serialize), new[] { writer, value });

        private static MethodBodyStatement InvokeJsonSerializerSerializeMethod(ValueExpression writer, ValueExpression value, ValueExpression options)
            => new InvokeStaticMethodStatement(typeof(JsonSerializer), nameof(JsonSerializer.Serialize), new[] { writer, value, options });

        private static bool IsCustomJsonConverterAdded(Type type)
            => type.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonConverterAttribute));

        public static bool CollectionItemRequiresNullCheckInSerialization(JsonSerialization serialization) =>
            serialization is { IsNullable: true } and JsonValueSerialization { Type: { IsValueType: true } } || // nullable value type, like int?
            serialization is JsonArraySerialization or JsonDictionarySerialization || // list or dictionary
            serialization is JsonValueSerialization jsonValueSerialization &&
            jsonValueSerialization is { Type: { IsValueType: false, IsFrameworkType: true } } && // framework reference type, e.g. byte[]
            jsonValueSerialization.Type.FrameworkType != typeof(string) && // excluding string, because JsonElement.GetString() can handle null
            jsonValueSerialization.Type.FrameworkType != typeof(byte[]); // excluding byte[], because JsonElement.GetBytesFromBase64() can handle null
    }
}
