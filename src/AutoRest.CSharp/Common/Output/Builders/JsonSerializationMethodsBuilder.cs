// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;
using Microsoft.CodeAnalysis;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using MemberExpression = AutoRest.CSharp.Common.Output.Expressions.ValueExpressions.MemberExpression;
using SerializationFormat = AutoRest.CSharp.Output.Models.Serialization.SerializationFormat;
using SwitchCase = AutoRest.CSharp.Common.Output.Expressions.Statements.SwitchCase;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal static class JsonSerializationMethodsBuilder
    {
        private const string _jsonModelWriteCoreMethodName = "JsonModelWriteCore";

        public static IEnumerable<Method> BuildResourceJsonSerializationMethods(Resource resource)
        {
            var resourceDataType = resource.ResourceData.Type;
            var jsonModelInterface = new CSharpType(typeof(IJsonModel<>), resourceDataType);
            var options = new ModelReaderWriterOptionsExpression(KnownParameters.Serializations.Options);
            var modelReaderWriter = new CSharpType(typeof(ModelReaderWriter));
            var iModelTInterface = new CSharpType(typeof(IPersistableModel<>), resourceDataType);
            var data = new BinaryDataExpression(KnownParameters.Serializations.Data);

            // void IJsonModel<T>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            var writer = new Utf8JsonWriterExpression(KnownParameters.Serializations.Utf8JsonWriter);
            yield return new Method(
                new MethodSignature(nameof(IJsonModel<object>.Write), null, null, MethodSignatureModifiers.None, null, null, new[] { KnownParameters.Serializations.Utf8JsonWriter, KnownParameters.Serializations.Options }, ExplicitInterface: jsonModelInterface),
                // => ((IJsonModel<T>)Data).Write(writer, options);
                new MemberExpression(This, "Data").CastTo(jsonModelInterface).Invoke(nameof(IJsonModel<object>.Write), writer, options));

            // T IJsonModel<T>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            var reader = KnownParameters.Serializations.Utf8JsonReader;
            yield return new Method(
                new MethodSignature(nameof(IJsonModel<object>.Create), null, null, MethodSignatureModifiers.None, resourceDataType, null, new[] { reader, KnownParameters.Serializations.Options }, ExplicitInterface: jsonModelInterface),
                // => ((IJsonModel<T>)Data).Create(reader, options);
                new MemberExpression(This, "Data").CastTo(jsonModelInterface).Invoke(nameof(IJsonModel<object>.Create), reader, options));

            // BinaryData IPersistableModel<T>.Write(ModelReaderWriterOptions options)
            yield return new Method(
                new MethodSignature(nameof(IPersistableModel<object>.Write), null, null, MethodSignatureModifiers.None, typeof(BinaryData), null, new[] { KnownParameters.Serializations.Options }, ExplicitInterface: iModelTInterface),
                // => ModelReaderWriter.Write<ResourceData>(Data, options);
                new InvokeStaticMethodExpression(modelReaderWriter, "Write", new List<ValueExpression> { new MemberExpression(This, "Data"), options }, new List<CSharpType> { resourceDataType }));

            // T IPersistableModel<T>.Create(BinaryData data, ModelReaderWriterOptions options)
            yield return new Method(
                new MethodSignature(nameof(IPersistableModel<object>.Create), null, null, MethodSignatureModifiers.None, resourceDataType, null, new[] { KnownParameters.Serializations.Data, KnownParameters.Serializations.Options }, ExplicitInterface: iModelTInterface),
                // => ModelReaderWriter.Read<ResourceData>(new BinaryData(reader.ValueSequence));
                new InvokeStaticMethodExpression(modelReaderWriter, "Read", new List<ValueExpression> { data, options }, new List<CSharpType> { resourceDataType }));

            // ModelReaderWriterFormat IPersistableModel<T>.GetFormatFromOptions(ModelReaderWriterOptions options)
            yield return new Method(
                new MethodSignature(nameof(IPersistableModel<object>.GetFormatFromOptions), null, null, MethodSignatureModifiers.None, typeof(string), null, new[] { KnownParameters.Serializations.Options }, ExplicitInterface: iModelTInterface),
                // => Data.GetFormatFromOptions(options);
                new MemberExpression(This, "Data").CastTo(iModelTInterface).Invoke(nameof(IPersistableModel<object>.GetFormatFromOptions), options));
        }

        public static IEnumerable<Method> BuildJsonSerializationMethods(JsonObjectSerialization json, SerializationInterfaces? interfaces, bool hasInherits, bool isSealed)
        {
            var useModelReaderWriter = Configuration.UseModelReaderWriter;

            var iJsonInterface = interfaces?.IJsonInterface;
            var iJsonModelInterface = interfaces?.IJsonModelTInterface;
            var iPersistableModelTInterface = interfaces?.IPersistableModelTInterface;
            var iJsonModelObjectInterface = interfaces?.IJsonModelObjectInterface;
            var writer = new Utf8JsonWriterExpression(KnownParameters.Serializations.Utf8JsonWriter);
            if (iJsonInterface is not null)
            {
                // void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
                if (iJsonModelInterface is not null)
                {
                    yield return new
                    (
                        new MethodSignature(nameof(IUtf8JsonSerializable.Write), null, null, MethodSignatureModifiers.None, null, null, new[] { KnownParameters.Serializations.Utf8JsonWriter }, ExplicitInterface: iJsonInterface),
                        This.CastTo(iJsonModelInterface).Invoke(nameof(IJsonModel<object>.Write), writer, ModelReaderWriterOptionsExpression.Wire)
                    );
                }
                else
                {
                    yield return new
                    (
                        new MethodSignature(nameof(IUtf8JsonSerializable.Write), null, null, MethodSignatureModifiers.None, null, null, new[] { KnownParameters.Serializations.Utf8JsonWriter }, ExplicitInterface: iJsonInterface),
                        WriteObject(json, writer, null, null)
                    );
                }
            }

            if (interfaces is null && Configuration.UseModelReaderWriter)
            {
                // void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
                yield return BuildJsonModelWriteCoreMethod(json, null, hasInherits, isSealed);
            }

            if (iJsonModelInterface is not null && iPersistableModelTInterface is not null)
            {
                var typeOfT = iJsonModelInterface.Arguments[0];
                var model = typeOfT.Implementation as SerializableObjectType;
                Debug.Assert(model != null, $"{typeOfT} should be a SerializableObjectType");

                // void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
                var jsonModelWriteCore = BuildJsonModelWriteCoreMethod(json, iPersistableModelTInterface, hasInherits, isSealed);

                // void IJsonModel<T>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
                var options = new ModelReaderWriterOptionsExpression(KnownParameters.Serializations.Options);
                yield return new
                (
                    new MethodSignature(nameof(IJsonModel<object>.Write), null, null, MethodSignatureModifiers.None, null, null, new[] { KnownParameters.Serializations.Utf8JsonWriter, KnownParameters.Serializations.Options }, ExplicitInterface: iJsonModelInterface),
                    BuildJsonModelWriteMethodBody(jsonModelWriteCore, writer)
                );
                yield return jsonModelWriteCore;
                // T IJsonModel<T>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                var reader = KnownParameters.Serializations.Utf8JsonReader;
                yield return new
                (
                    new MethodSignature(nameof(IJsonModel<object>.Create), null, null, MethodSignatureModifiers.None, typeOfT, null, new[] { KnownParameters.Serializations.Utf8JsonReader, KnownParameters.Serializations.Options }, ExplicitInterface: iJsonModelInterface),
                    new[]
                    {
                        Serializations.ValidateJsonFormat(options, iPersistableModelTInterface, Serializations.ValidationType.Read),
                        // using var document = JsonDocument.ParseValue(ref reader);
                        UsingDeclare("document", JsonDocumentExpression.ParseValue(reader), out var docVariable),
                        // return DeserializeXXX(doc.RootElement, options);
                        Return(SerializableObjectTypeExpression.Deserialize(model, docVariable.RootElement, options))
                    }
                );

                // if the model is a struct, it needs to implement IJsonModel<object> as well which leads to another 2 methods
                if (iJsonModelObjectInterface is not null)
                {
                    // void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
                    yield return new
                    (
                        new MethodSignature(nameof(IJsonModel<object>.Write), null, null, MethodSignatureModifiers.None, null, null, new[] { KnownParameters.Serializations.Utf8JsonWriter, KnownParameters.Serializations.Options }, ExplicitInterface: iJsonModelObjectInterface),
                        This.CastTo(iJsonModelInterface).Invoke(nameof(IJsonModel<object>.Write), writer, options)
                    );

                    // object IJsonModel<object>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
                    yield return new
                    (
                        new MethodSignature(nameof(IJsonModel<object>.Create), null, null, MethodSignatureModifiers.None, typeof(object), null, new[] { KnownParameters.Serializations.Utf8JsonReader, KnownParameters.Serializations.Options }, ExplicitInterface: iJsonModelObjectInterface),
                        This.CastTo(iJsonModelInterface).Invoke(nameof(IJsonModel<object>.Create), reader, options)
                    );
                }
            }
        }

        public static SwitchCase BuildJsonWriteSwitchCase(JsonObjectSerialization json, ModelReaderWriterOptionsExpression options)
        {
            return new SwitchCase(Serializations.JsonFormat,
                    Return(new InvokeStaticMethodExpression(typeof(ModelReaderWriter), nameof(ModelReaderWriter.Write), new[] { This, options })));
        }

        public static SwitchCase BuildJsonCreateSwitchCase(SerializableObjectType model, BinaryDataExpression data, ModelReaderWriterOptionsExpression options)
        {
            /* using var document = JsonDocument.ParseValue(ref reader);
             * return DeserializeXXX(doc.RootElement, options);
             */
            return new SwitchCase(Serializations.JsonFormat,
                    new MethodBodyStatement[]
                    {
                        UsingDeclare("document", JsonDocumentExpression.Parse(data), out var docVariable),
                            Return(SerializableObjectTypeExpression.Deserialize(model, docVariable.RootElement, options))
                    }, addScope: true); // using statement must have a scope, if we do not have the addScope parameter here, the generated code will not compile
        }

        // TODO -- make the options and iPersistableModelTInterface parameter non-nullable again when we remove the `UseModelReaderWriter` flag.
        private static MethodBodyStatement[] WriteObject(JsonObjectSerialization serialization, Utf8JsonWriterExpression utf8JsonWriter, ModelReaderWriterOptionsExpression? options, CSharpType? iPersistableModelTInterface)
            => new[]
            {
                Serializations.ValidateJsonFormat(options, iPersistableModelTInterface, Serializations.ValidationType.Write),
                utf8JsonWriter.WriteStartObject(),
                WriteProperties(utf8JsonWriter, serialization.Properties, serialization.RawDataField?.Value, options).ToArray(),
                SerializeAdditionalProperties(utf8JsonWriter, options, serialization.AdditionalProperties, false),
                SerializeAdditionalProperties(utf8JsonWriter, options, serialization.RawDataField, true),
                utf8JsonWriter.WriteEndObject()
            };

        private static MethodBodyStatement[] BuildJsonModelWriteMethodBody(Method jsonModelWriteCoreMethod, Utf8JsonWriterExpression utf8JsonWriter)
        {
            var coreMethodSignature = jsonModelWriteCoreMethod.Signature;

            return new[]
            {
                utf8JsonWriter.WriteStartObject(),
                This.Invoke((MethodSignature)coreMethodSignature).ToStatement(),
                utf8JsonWriter.WriteEndObject(),
            };
        }

        // void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        private static Method BuildJsonModelWriteCoreMethod(JsonObjectSerialization serialization, CSharpType? iPersistableModelTInterface, bool hasInherits, bool isSealed)
        {
            MethodSignatureModifiers modifiers = hasInherits ? MethodSignatureModifiers.Protected | MethodSignatureModifiers.Override : MethodSignatureModifiers.Protected | MethodSignatureModifiers.Virtual;
            if (serialization.Type.IsValueType || isSealed)
                modifiers = MethodSignatureModifiers.Private;

            var utf8JsonWriter = new Utf8JsonWriterExpression(KnownParameters.Serializations.Utf8JsonWriterWithDescription);
            var options = new ModelReaderWriterOptionsExpression(KnownParameters.Serializations.OptionsWithDescription);

            return new Method
            (
                new MethodSignature(_jsonModelWriteCoreMethodName, null, null, modifiers, null, null, new[] { KnownParameters.Serializations.Utf8JsonWriterWithDescription, KnownParameters.Serializations.OptionsWithDescription }),
                BuildJsonModelWriteCoreMethodBody(serialization, utf8JsonWriter, options, iPersistableModelTInterface, hasInherits)
            );
        }

        private static MethodBodyStatement[] BuildJsonModelWriteCoreMethodBody(JsonObjectSerialization serialization, Utf8JsonWriterExpression utf8JsonWriter, ModelReaderWriterOptionsExpression options, CSharpType? iPersistableModelTInterface, bool hasInherits)
        {
            return new[]
            {
                Serializations.ValidateJsonFormat(options, iPersistableModelTInterface, Serializations.ValidationType.Write),
                CallBaseJsonModelWriteCore(utf8JsonWriter, options, hasInherits),
                WriteProperties(utf8JsonWriter, serialization.SelfProperties, serialization.RawDataField?.Value, options).ToArray(),
                SerializeAdditionalProperties(utf8JsonWriter, options, serialization.AdditionalProperties, false),
                CallSerializeAdditionalPropertiesForRawData(serialization, utf8JsonWriter, options, hasInherits)
            };
        }

        private static MethodBodyStatement CallSerializeAdditionalPropertiesForRawData(JsonObjectSerialization serialization, Utf8JsonWriterExpression utf8JsonWriter, ModelReaderWriterOptionsExpression options, bool hasInherits)
        {
            return hasInherits ?
                EmptyStatement
                : SerializeAdditionalProperties(utf8JsonWriter, options, serialization.RawDataField, true);
        }

        private static MethodBodyStatement CallBaseJsonModelWriteCore(Utf8JsonWriterExpression utf8JsonWriter, ModelReaderWriterOptionsExpression options, bool hasInherits)
        {
            // base.<JsonModelWriteCore>()
            return hasInherits ?
                Base.Invoke(_jsonModelWriteCoreMethodName, utf8JsonWriter, options).ToStatement()
                : EmptyStatement;
        }

        // TODO -- make the options parameter non-nullable again when we remove the `UseModelReaderWriter` flag.
        private static IEnumerable<MethodBodyStatement> WriteProperties(Utf8JsonWriterExpression utf8JsonWriter, IEnumerable<JsonPropertySerialization> properties, ValueExpression? rawData, ModelReaderWriterOptionsExpression? options)
        {
            // TODO -- update this so that we could decide if we want to write the extra check of checking if this thing is in the raw data field dictionary
            foreach (JsonPropertySerialization property in properties)
            {
                if (property.ValueSerialization == null)
                {
                    // Flattened property
                    yield return Serializations.WrapInCheckInRawData(rawData, property.SerializedName, Serializations.WrapInCheckNotWire(
                        property.ShouldExcludeInWireSerialization,
                        options?.Format,
                        new[]
                        {
                            utf8JsonWriter.WritePropertyName(property.SerializedName),
                            utf8JsonWriter.WriteStartObject(),
                            WriteProperties(utf8JsonWriter, property.PropertySerializations!, null, options).ToArray(), // the raw data should not pass through to the flattened properties
                            utf8JsonWriter.WriteEndObject(),
                        }));
                }
                else if (property.SerializedType is { IsNullable: true })
                {
                    var checkPropertyIsInitialized = property.Value.Type.IsCollection && !property.Value.Type.IsReadOnlyMemory && property.IsRequired
                        ? And(NotEqual(property.Value, Null), InvokeOptional.IsCollectionDefined(property.Value))
                        : NotEqual(property.Value, Null);

                    yield return Serializations.WrapInCheckInRawData(rawData, property.SerializedName, Serializations.WrapInCheckNotWire(
                        property.ShouldExcludeInWireSerialization,
                        options?.Format,
                        InvokeOptional.WrapInIsDefined(
                            property,
                            new IfElseStatement(checkPropertyIsInitialized,
                                WritePropertySerialization(utf8JsonWriter, property, options),
                                utf8JsonWriter.WriteNull(property.SerializedName)
                            ))
                    ));
                }
                else
                {
                    yield return Serializations.WrapInCheckInRawData(rawData, property.SerializedName, Serializations.WrapInCheckNotWire(
                        property.ShouldExcludeInWireSerialization,
                        options?.Format,
                        InvokeOptional.WrapInIsDefined(property, WritePropertySerialization(utf8JsonWriter, property, options))));
                }
            }
        }

        private static MethodBodyStatement WritePropertySerialization(Utf8JsonWriterExpression utf8JsonWriter, JsonPropertySerialization serialization, ModelReaderWriterOptionsExpression? options)
        {
            return new[]
            {
                utf8JsonWriter.WritePropertyName(serialization.SerializedName),
                serialization.CustomSerializationMethodName is {} serializationMethodName
                    ? InvokeCustomSerializationMethod(serializationMethodName, utf8JsonWriter, options)
                    : SerializeExpression(utf8JsonWriter, serialization.ValueSerialization, serialization.EnumerableValue ?? serialization.Value, options)
            };
        }

        // TODO -- make the options parameter non-nullable again when we remove the `UseModelReaderWriter` flag.
        private static MethodBodyStatement SerializeAdditionalProperties(Utf8JsonWriterExpression utf8JsonWriter, ModelReaderWriterOptionsExpression? options, JsonAdditionalPropertiesSerialization? additionalProperties, bool isRawData)
        {
            if (additionalProperties is null)
            {
                return EmptyStatement;
            }

            var additionalPropertiesExpression = new DictionaryExpression(additionalProperties.ImplementationType.Arguments[0], additionalProperties.ImplementationType.Arguments[1], additionalProperties.Value);
            MethodBodyStatement statement = new ForeachStatement("item", additionalPropertiesExpression, out KeyValuePairExpression item)
            {
                SerializeForRawData(utf8JsonWriter, additionalProperties.ValueSerialization, item, options, isRawData)
            };

            // if it should be excluded in wire serialization, it is a raw data field and we need to check if it is null
            // otherwise it is the public AdditionalProperties property, we always instantiate it therefore we do not need to check null.
            statement = isRawData ?
                new IfStatement(NotEqual(additionalPropertiesExpression, Null))
                {
                    statement
                } : statement;

            return Serializations.WrapInCheckNotWire(
                additionalProperties.ShouldExcludeInWireSerialization,
                options?.Format,
                statement);

            static MethodBodyStatement SerializeForRawData(Utf8JsonWriterExpression utf8JsonWriter, JsonSerialization? valueSerialization, KeyValuePairExpression item, ModelReaderWriterOptionsExpression? options, bool isRawData)
            {
                MethodBodyStatement statement = new MethodBodyStatement[]
                {
                    utf8JsonWriter.WritePropertyName(item.Key),
                    SerializeExpression(utf8JsonWriter, valueSerialization, item.Value, options)
                };
                if (!isRawData)
                {
                    return statement;
                }

                if (Configuration.EnableInternalRawData && options != null)
                {
                    statement = new MethodBodyStatement[]
                    {
                        new IfStatement(ModelSerializationExtensionsProvider.Instance.IsSentinelValue(item.Value))
                        {
                            Continue
                        },
                        statement
                    };
                }

                return statement;
            }
        }

        public static MethodBodyStatement SerializeExpression(Utf8JsonWriterExpression utf8JsonWriter, JsonSerialization? serialization, TypedValueExpression expression, ModelReaderWriterOptionsExpression? options)
            => serialization switch
            {
                JsonArraySerialization array => SerializeArray(utf8JsonWriter, array, GetEnumerableExpression(expression, array), options),
                JsonDictionarySerialization dictionary => SerializeDictionary(utf8JsonWriter, dictionary, new DictionaryExpression(dictionary.Type.Arguments[0], dictionary.Type.Arguments[1], expression), options),
                JsonValueSerialization value => SerializeValue(utf8JsonWriter, value, expression, options),
                _ => throw new NotSupportedException()
            };

        private static EnumerableExpression GetEnumerableExpression(ValueExpression expression, JsonArraySerialization array)
        {
            if (expression is TypedValueExpression typed && typed.Type.IsReadOnlyMemory)
            {
                expression = typed
                    .NullableStructValue()
                    .Property(nameof(ReadOnlyMemory<byte>.Span), new CSharpType(typeof(ReadOnlySpan<>), typed.Type.Arguments[0]));
            }

            return new EnumerableExpression(array.Type.ElementType, expression);
        }

        private static MethodBodyStatement SerializeArray(Utf8JsonWriterExpression utf8JsonWriter, JsonArraySerialization arraySerialization, EnumerableExpression array, ModelReaderWriterOptionsExpression? options)
        {
            return new[]
            {
                utf8JsonWriter.WriteStartArray(),
                new ForeachStatement("item", array, out var item)
                {
                    CheckCollectionItemForNull(utf8JsonWriter, arraySerialization.ValueSerialization, item),
                    SerializeExpression(utf8JsonWriter, arraySerialization.ValueSerialization, item, options)
                },
                utf8JsonWriter.WriteEndArray()
            };
        }

        private static MethodBodyStatement SerializeDictionary(Utf8JsonWriterExpression utf8JsonWriter, JsonDictionarySerialization dictionarySerialization, DictionaryExpression dictionary, ModelReaderWriterOptionsExpression? options)
        {
            return new[]
            {
                utf8JsonWriter.WriteStartObject(),
                new ForeachStatement("item", dictionary, out KeyValuePairExpression keyValuePair)
                {
                    utf8JsonWriter.WritePropertyName(keyValuePair.Key),
                    CheckCollectionItemForNull(utf8JsonWriter, dictionarySerialization.ValueSerialization, keyValuePair.Value),
                    SerializeExpression(utf8JsonWriter, dictionarySerialization.ValueSerialization, keyValuePair.Value, options)
                },
                utf8JsonWriter.WriteEndObject()
            };
        }

        private static MethodBodyStatement SerializeValue(Utf8JsonWriterExpression utf8JsonWriter, JsonValueSerialization valueSerialization, TypedValueExpression value, ModelReaderWriterOptionsExpression? options)
        {
            if (valueSerialization.Type.SerializeAs is not null)
            {
                return SerializeFrameworkTypeValue(utf8JsonWriter, valueSerialization, value, valueSerialization.Type.SerializeAs, options);
            }

            if (valueSerialization.Type.IsFrameworkType)
            {
                return SerializeFrameworkTypeValue(utf8JsonWriter, valueSerialization, value, valueSerialization.Type.FrameworkType, options);
            }

            switch (valueSerialization.Type.Implementation)
            {
                case SystemObjectType systemObjectType when IsCustomJsonConverterAdded(systemObjectType.SystemType):
                    if (valueSerialization.Options == JsonSerializationOptions.UseManagedServiceIdentityV3)
                    {
                        return new[]
                        {
                            Var("serializeOptions", New.JsonSerializerOptions(), out var serializeOptions),
                            JsonSerializerExpression.Serialize(utf8JsonWriter, value, serializeOptions).ToStatement()
                        };
                    }

                    return JsonSerializerExpression.Serialize(utf8JsonWriter, value).ToStatement();

                case ObjectType:
                    return utf8JsonWriter.WriteObjectValue(value, options: options);

                case EnumType { IsIntValueType: true, IsExtensible: false } enumType:
                    return utf8JsonWriter.WriteNumberValue(new CastExpression(value.NullableStructValue(valueSerialization.Type), enumType.ValueType));

                case EnumType { IsNumericValueType: true } enumType:
                    return utf8JsonWriter.WriteNumberValue(new EnumExpression(enumType, value.NullableStructValue(valueSerialization.Type)).ToSerial());

                case EnumType enumType:
                    return utf8JsonWriter.WriteStringValue(new EnumExpression(enumType, value.NullableStructValue(valueSerialization.Type)).ToSerial());

                default:
                    throw new NotSupportedException($"Cannot build serialization expression for type {valueSerialization.Type}, please add `CodeGenMemberSerializationHooks` to specify the serialization of this type with the customized property");
            }
        }

        private static MethodBodyStatement SerializeFrameworkTypeValue(Utf8JsonWriterExpression utf8JsonWriter, JsonValueSerialization valueSerialization, ValueExpression value, Type valueType, ModelReaderWriterOptionsExpression? options)
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

            if (valueType == typeof(decimal) ||
                valueType == typeof(double) ||
                valueType == typeof(float) ||
                IsIntType(valueType))
            {
                if (valueSerialization.Format is SerializationFormat.Int_String &&
                    IsIntType(valueType))
                {
                    return utf8JsonWriter.WriteStringValue(value.InvokeToString());
                }
                return utf8JsonWriter.WriteNumberValue(value);
            }

            if (valueType == typeof(object))
            {
                return utf8JsonWriter.WriteObjectValue(new TypedValueExpression(valueType, value), options);
            }

            // These are string-like types that could implicitly convert to string type
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
                    return utf8JsonWriter.WriteNumberValue(InvokeConvert.ToInt32(new TimeSpanExpression(value).InvokeToString(format)));
                }

                if (valueSerialization.Format is SerializationFormat.Duration_Seconds_Float or SerializationFormat.Duration_Seconds_Double)
                {
                    return utf8JsonWriter.WriteNumberValue(InvokeConvert.ToDouble(new TimeSpanExpression(value).InvokeToString(format)));
                }

                if (valueSerialization.Format is SerializationFormat.DateTime_Unix)
                {
                    return utf8JsonWriter.WriteNumberValue(value, format);
                }
                return format is not null
                    ? utf8JsonWriter.WriteStringValue(value, format)
                    : utf8JsonWriter.WriteStringValue(value);
            }

            // These are string-like types that cannot implicitly convert to string type, therefore we need to call ToString on them
            if (valueType == typeof(ETag) || valueType == typeof(ContentType) || valueType == typeof(IPAddress) || valueType == typeof(RequestMethod) || valueType == typeof(ExtendedLocationType))
            {
                return utf8JsonWriter.WriteStringValue(value.InvokeToString());
            }

            if (valueType == typeof(Uri))
            {
                return utf8JsonWriter.WriteStringValue(new MemberExpression(value, nameof(Uri.AbsoluteUri)));
            }

            if (valueType == typeof(BinaryData))
            {
                var binaryDataValue = new BinaryDataExpression(value);
                if (valueSerialization.Format is SerializationFormat.Bytes_Base64 or SerializationFormat.Bytes_Base64Url)
                {
                    return utf8JsonWriter.WriteBase64StringValue(new BinaryDataExpression(value).ToArray(), valueSerialization.Format.ToFormatSpecifier());
                }

                return utf8JsonWriter.WriteBinaryData(binaryDataValue);
            }
            if (valueType == typeof(Stream))
            {
                return utf8JsonWriter.WriteBinaryData(BinaryDataExpression.FromStream(value, false));
            }

            if (IsCustomJsonConverterAdded(valueType))
            {
                return JsonSerializerExpression.Serialize(utf8JsonWriter, value).ToStatement();
            }

            throw new NotSupportedException($"Framework type {valueType} serialization not supported, please add `CodeGenMemberSerializationHooks` to specify the serialization of this type with the customized property");
        }

        private static MethodBodyStatement CheckCollectionItemForNull(Utf8JsonWriterExpression utf8JsonWriter, JsonSerialization valueSerialization, ValueExpression value)
            => CollectionItemRequiresNullCheckInSerialization(valueSerialization)
                ? new IfStatement(Equal(value, Null)) { utf8JsonWriter.WriteNullValue(), Continue }
                : EmptyStatement;

        public static Method? BuildDeserialize(TypeDeclarationOptions declaration, JsonObjectSerialization serialization, INamedTypeSymbol? existingType)
        {
            var methodName = $"Deserialize{declaration.Name}";
            var signature = Configuration.UseModelReaderWriter ?
                new MethodSignature(methodName, null, null, MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static, serialization.Type, null, new[] { KnownParameters.Serializations.JsonElement, KnownParameters.Serializations.OptionalOptions }) :
                new MethodSignature(methodName, null, null, MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static, serialization.Type, null, new[] { KnownParameters.Serializations.JsonElement });
            if (SourceInputHelper.TryGetExistingMethod(existingType, signature, out _))
            {
                return null;
            }

            return Configuration.UseModelReaderWriter ?
                new Method(signature, BuildDeserializeBody(serialization, new JsonElementExpression(KnownParameters.Serializations.JsonElement), new ModelReaderWriterOptionsExpression(KnownParameters.Serializations.OptionalOptions)).ToArray()) :
                new Method(signature, BuildDeserializeBody(serialization, new JsonElementExpression(KnownParameters.Serializations.JsonElement), null).ToArray());
        }

        // TODO -- make the options parameter non-nullable again when we remove the `UseModelReaderWriter` flag.
        private static IEnumerable<MethodBodyStatement> BuildDeserializeBody(JsonObjectSerialization serialization, JsonElementExpression jsonElement, ModelReaderWriterOptionsExpression? options)
        {
            // fallback to Default options if it is null
            if (options != null)
            {
                yield return AssignIfNull(options, ModelReaderWriterOptionsExpression.Wire);

                yield return EmptyLine;
            }

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
                yield return new IfStatement(jsonElement.TryGetProperty(discriminator.SerializedName, out var discriminatorElement))
                {
                    new SwitchStatement(discriminatorElement.GetString(), GetDiscriminatorCases(jsonElement, discriminator, options).ToArray())
                };
            }
            // we redirect the deserialization to the `DefaultObjectType` (the unknown version of the discriminated set) if possible.
            // We could only do this when there is a discriminator, and the discriminator does not have a value (having a value indicating it is the child instead of base), and there is an unknown default object type to fall back, and I am not that fallback type.
            if (discriminator is { Value: null, DefaultObjectType: { } defaultObjectType } && !serialization.Type.Equals(defaultObjectType.Type))
            {
                yield return Return(GetDeserializeImplementation(discriminator.DefaultObjectType.Type.Implementation, jsonElement, options, null));
            }
            else
            {
                yield return WriteObjectInitialization(serialization, jsonElement, options).ToArray();
            }
        }

        // TODO -- make the options parameter non-nullable again when we remove the `use-model-reader-writer` flag
        private static IEnumerable<SwitchCase> GetDiscriminatorCases(JsonElementExpression element, ObjectTypeDiscriminator discriminator, ModelReaderWriterOptionsExpression? options)
        {
            foreach (var implementation in discriminator.Implementations)
            {
                yield return new SwitchCase(Literal(implementation.Key), Return(GetDeserializeImplementation(implementation.Type.Implementation, element, options, null)), true);
            }
        }

        // TODO -- make the options parameter non-nullable again when we remove the `UseModelReaderWriter` flag.
        private static IEnumerable<MethodBodyStatement> WriteObjectInitialization(JsonObjectSerialization serialization, JsonElementExpression element, ModelReaderWriterOptionsExpression? options)
        {
            // this is the first level of object hierarchy
            // collect all properties and initialize the dictionary
            var propertyVariables = new Dictionary<JsonPropertySerialization, VariableReference>();

            CollectPropertiesForDeserialization(propertyVariables, serialization);

            bool isThisTheDefaultDerivedType = serialization.Type.Equals(serialization.Discriminator?.DefaultObjectType?.Type);

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
            var additionalProperties = serialization.AdditionalProperties;
            DictionaryExpression? additionalPropertiesDictionary = null;
            var rawDataField = serialization.RawDataField;
            DictionaryExpression? rawDataFieldDictionary = null;
            // if there is additional properties, we need to declare the dictionary first
            if (additionalProperties != null)
            {
                yield return Declare("additionalPropertiesDictionary",
                    new DictionaryExpression(additionalProperties.ImplementationType.Arguments[0], additionalProperties.ImplementationType.Arguments[1], New.Instance(additionalProperties.ImplementationType)),
                    out additionalPropertiesDictionary);
            }
            // if there is raw data field, we need to declare the dictionary first
            if (rawDataField != null)
            {
                yield return Declare("rawDataDictionary",
                    new DictionaryExpression(rawDataField.ImplementationType.Arguments[0], rawDataField.ImplementationType.Arguments[1], New.Instance(rawDataField.ImplementationType)),
                    out rawDataFieldDictionary);
            }

            yield return new ForeachStatement("property", element.EnumerateObject(), out var property)
            {
                DeserializeIntoObjectProperties(serialization.Properties, new JsonPropertyExpression(property), additionalProperties, additionalPropertiesDictionary, rawDataField, rawDataFieldDictionary, propertyVariables, shouldTreatEmptyStringAsNull, options).ToArray()
            };

            if (additionalProperties != null && additionalPropertiesDictionary != null)
            {
                yield return Assign(propertyVariables[additionalProperties], additionalPropertiesDictionary);
            }
            if (rawDataField != null && rawDataFieldDictionary != null)
            {
                yield return Assign(propertyVariables[rawDataField], rawDataFieldDictionary);
            }

            var parameterValues = propertyVariables.ToDictionary(v => v.Key.SerializationConstructorParameterName, v => GetOptional(v.Key, v.Value));
            var parameters = serialization.ConstructorParameters
                .Select(p => parameterValues[p.Name])
                .ToArray();

            yield return Return(New.Instance(serialization.Type, parameters));
        }

        // TODO -- make the options parameter non-nullable again when we remove the `UseModelReaderWriter` flag.
        private static IEnumerable<MethodBodyStatement> DeserializeIntoObjectProperties(
            IEnumerable<JsonPropertySerialization> propertySerializations, JsonPropertyExpression jsonProperty,
            JsonAdditionalPropertiesSerialization? additionalProperties, DictionaryExpression? additionalPropertiesDictionary,
            JsonAdditionalPropertiesSerialization? rawDataField, DictionaryExpression? rawDataFieldDictionary,
            IReadOnlyDictionary<JsonPropertySerialization, VariableReference> propertyVariables,
            bool shouldTreatEmptyStringAsNull,
            ModelReaderWriterOptionsExpression? options)
        {
            yield return DeserializeIntoObjectProperties(propertySerializations, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull, options);

            if (additionalProperties != null && additionalPropertiesDictionary != null)
            {
                var valueSerialization = additionalProperties.ValueSerialization ?? throw new InvalidOperationException("ValueSerialization of AdditionalProperties property should never be null");
                var deserializationStatement = TryDeserializeValue(valueSerialization, jsonProperty.Value, options, out var value);

                var additionalPropertiesStatement = additionalPropertiesDictionary.Add(jsonProperty.Name, value);
                additionalPropertiesStatement = Serializations.WrapInCheckNotWire(
                    additionalProperties.ShouldExcludeInWireDeserialization,
                    options?.Format,
                    additionalPropertiesStatement);

                if (deserializationStatement is IfStatement tryDeserializationStatement)
                {
                    // when we have a verifier, the statement is a if statement, the following value processing statements should be wrapped by this if statement
                    tryDeserializationStatement.Add(additionalPropertiesStatement);
                    // we also need to add "continue" to let the raw data field be skipped
                    tryDeserializationStatement.Add(Continue);
                    yield return tryDeserializationStatement;
                }
                else
                {
                    // when we do not have a verifier, the statement is not a if statement
                    yield return deserializationStatement;
                    yield return additionalPropertiesStatement;
                }
            }

            if (rawDataField != null && rawDataFieldDictionary != null)
            {
                var valueSerialization = rawDataField.ValueSerialization ?? throw new InvalidOperationException("ValueSerialization of raw data field should never be null");
                yield return DeserializeValue(valueSerialization, jsonProperty.Value, options, out var value);
                var rawDataFieldStatement = rawDataFieldDictionary.Add(jsonProperty.Name, value);

                if (Configuration.EnableInternalRawData)
                {
                    rawDataFieldStatement = new MethodBodyStatement[]
                    {
                        AssignIfNull(rawDataFieldDictionary, New.Instance(rawDataField.ImplementationType)),
                        rawDataFieldStatement
                    };
                }

                yield return Serializations.WrapInCheckNotWire(
                    rawDataField.ShouldExcludeInWireDeserialization,
                    options?.Format,
                    rawDataFieldStatement);
            }
        }

        private static MethodBodyStatement DeserializeIntoObjectProperties(IEnumerable<JsonPropertySerialization> propertySerializations, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, VariableReference> propertyVariables, bool shouldTreatEmptyStringAsNull, ModelReaderWriterOptionsExpression? options)
            => propertySerializations
                .Select(p => new IfStatement(jsonProperty.NameEquals(p.SerializedName))
                {
                    DeserializeIntoObjectProperty(p, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull, options)
                })
                .ToArray();

        private static MethodBodyStatement DeserializeIntoObjectProperty(JsonPropertySerialization jsonPropertySerialization, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, VariableReference> propertyVariables, bool shouldTreatEmptyStringAsNull, ModelReaderWriterOptionsExpression? options)
        {
            // write the deserialization hook
            if (jsonPropertySerialization.CustomDeserializationMethodName is { } deserializationMethodName)
            {
                return new[]
                {
                    InvokeCustomDeserializationMethod(deserializationMethodName, jsonProperty, propertyVariables[jsonPropertySerialization].Declaration),
                    Continue
                };
            }

            // Reading a property value
            if (jsonPropertySerialization.ValueSerialization is not null)
            {
                return new[]
                {
                    CreatePropertyNullCheckStatement(jsonPropertySerialization, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull),
                    DeserializeValue(jsonPropertySerialization.ValueSerialization, jsonProperty.Value, options, out var value),
                    Assign(propertyVariables[jsonPropertySerialization], value),
                    Continue
                };
            }

            // Reading a nested object
            if (jsonPropertySerialization.PropertySerializations is not null)
            {
                return new[]
                {
                    CreatePropertyNullCheckStatement(jsonPropertySerialization, jsonProperty, propertyVariables, shouldTreatEmptyStringAsNull),
                    new ForeachStatement("property", jsonProperty.Value.EnumerateObject(), out var nestedItemVariable)
                    {
                        DeserializeIntoObjectProperties(jsonPropertySerialization.PropertySerializations, new JsonPropertyExpression(nestedItemVariable), propertyVariables, shouldTreatEmptyStringAsNull, options)
                    },
                    Continue
                };
            }

            throw new InvalidOperationException($"Either {nameof(JsonPropertySerialization.ValueSerialization)} must not be null or {nameof(JsonPropertySerialization.PropertySerializations)} must not be null.");
        }

        private static MethodBodyStatement CreatePropertyNullCheckStatement(JsonPropertySerialization jsonPropertySerialization, JsonPropertyExpression jsonProperty, IReadOnlyDictionary<JsonPropertySerialization, VariableReference> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            var checkEmptyProperty = GetCheckEmptyPropertyValueExpression(jsonProperty, jsonPropertySerialization, shouldTreatEmptyStringAsNull);
            var serializedType = jsonPropertySerialization.SerializedType;
            if (serializedType?.IsNullable == true)
            {
                var propertyVariable = propertyVariables[jsonPropertySerialization];

                // we only assign null when it is not a collection if we have DeserializeNullCollectionAsNullValue configuration is off
                // specially when it is required, we assign ChangeTrackingList because for optional lists we are already doing that
                if (!serializedType.IsCollection || Configuration.DeserializeNullCollectionAsNullValue)
                {
                    return new IfStatement(checkEmptyProperty)
                    {
                        Assign(propertyVariable, Null),
                        Continue
                    };
                }

                if (jsonPropertySerialization.IsRequired && !propertyVariable.Type.IsValueType)
                {
                    return new IfStatement(checkEmptyProperty)
                    {
                        Assign(propertyVariable, New.Instance(propertyVariable.Type.PropertyInitializationType)),
                        Continue
                    };
                }

                return new IfStatement(checkEmptyProperty)
                {
                    Continue
                };
            }

            var propertyType = jsonPropertySerialization.ValueSerialization?.Type;
            // even if ReadOnlyMemory is required we leave the list empty if the payload doesn't have it
            if (jsonPropertySerialization.IsRequired && (propertyType is null || !propertyType.IsReadOnlyMemory))
            {
                return EmptyStatement;
            }

            if (propertyType?.Equals(typeof(JsonElement)) == true || // JsonElement handles nulls internally
                propertyType?.Equals(typeof(string)) == true) //https://github.com/Azure/autorest.csharp/issues/922
            {
                return EmptyStatement;
            }

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

        private static BoolExpression GetCheckEmptyPropertyValueExpression(JsonPropertyExpression jsonProperty, JsonPropertySerialization jsonPropertySerialization, bool shouldTreatEmptyStringAsNull)
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

        /// <summary>
        /// Collects all the properties, additional properties property, raw data field for deserialization
        /// </summary>
        /// <param name="propertyVariables"></param>
        /// <param name="serialization"></param>
        private static void CollectPropertiesForDeserialization(IDictionary<JsonPropertySerialization, VariableReference> propertyVariables, JsonObjectSerialization serialization)
        {
            CollectPropertiesForDeserialization(propertyVariables, serialization.Properties);

            if (serialization.AdditionalProperties is { } additionalProperties)
            {
                propertyVariables.Add(additionalProperties, new VariableReference(additionalProperties.Value.Type, additionalProperties.SerializationConstructorParameterName));
            }

            if (serialization.RawDataField is { } rawDataField)
            {
                propertyVariables.Add(rawDataField, new VariableReference(rawDataField.Value.Type, rawDataField.SerializationConstructorParameterName));
            }
        }

        /// <summary>
        /// Collects a list of properties being read from all level of object hierarchy
        /// </summary>
        /// <param name="propertyVariables"></param>
        /// <param name="jsonProperties"></param>
        private static void CollectPropertiesForDeserialization(IDictionary<JsonPropertySerialization, VariableReference> propertyVariables, IEnumerable<JsonPropertySerialization> jsonProperties)
        {
            foreach (JsonPropertySerialization jsonProperty in jsonProperties)
            {
                if (jsonProperty.ValueSerialization?.Type is { } variableType)
                {
                    var propertyDeclaration = new CodeWriterDeclaration(jsonProperty.SerializedName.ToVariableName());
                    propertyVariables.Add(jsonProperty, new VariableReference(variableType, propertyDeclaration));
                }
                else if (jsonProperty.PropertySerializations != null)
                {
                    CollectPropertiesForDeserialization(propertyVariables, jsonProperty.PropertySerializations);
                }
            }
        }

        public static MethodBodyStatement BuildDeserializationForMethods(JsonSerialization serialization, bool async, ValueExpression? variable, StreamExpression stream, bool isBinaryData, ModelReaderWriterOptionsExpression? options)
        {
            if (isBinaryData)
            {
                var callFromStream = BinaryDataExpression.FromStream(stream, async);
                var variableExpression = variable is not null ? new BinaryDataExpression(variable) : null;
                return AssignOrReturn(variableExpression, callFromStream);
            }

            var declareDocument = UsingVar("document", JsonDocumentExpression.Parse(stream, async), out var document);
            var deserializeValueBlock = DeserializeValue(serialization, document.RootElement, options, out var value);

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

        // TODO -- make options parameter non-nullable again when we remove the `use-model-reader-writer` flag
        public static MethodBodyStatement TryDeserializeValue(JsonSerialization serialization, JsonElementExpression element, ModelReaderWriterOptionsExpression? options, out ValueExpression value)
        {
            if (serialization.Type is { IsFrameworkType: true, FrameworkType: { } frameworkType } && BuilderHelpers.IsVerifiableType(frameworkType))
            {
                if (frameworkType == typeof(string))
                {
                    DeserializeValue(serialization, element, options, out value);
                    return new IfStatement(Or(element.ValueKindEqualsString(), element.ValueKindEqualsNull()));
                }
                else if (frameworkType == typeof(bool))
                {
                    DeserializeValue(serialization, element, options, out value);
                    var valueKind = element.ValueKind;
                    return new IfStatement(Or(Equal(valueKind, JsonValueKindExpression.True), Equal(valueKind, JsonValueKindExpression.False)));
                }
                else
                {
                    var declarationExpression = new DeclarationExpression(frameworkType, "value", out var variable, isOut: true);
                    value = variable;
                    return new IfStatement(new BoolExpression(element.Invoke($"TryGet{frameworkType.Name}", declarationExpression)));
                }
            }
            else if (serialization.Type.IsList)
            {
                return new IfStatement(Equal(element.ValueKind, JsonValueKindExpression.Array))
                {
                    DeserializeValue(serialization, element, options, out value)
                };
            }
            else if (serialization.Type.IsDictionary)
            {
                return new IfStatement(Equal(element.ValueKind, JsonValueKindExpression.Object))
                {
                    DeserializeValue(serialization, element, options, out value)
                };
            }
            else
            {
                return DeserializeValue(serialization, element, options, out value);
            }
        }

        // TODO -- make options parameter non-nullable again when we remove the `use-model-reader-writer` flag
        public static MethodBodyStatement DeserializeValue(JsonSerialization serialization, JsonElementExpression element, ModelReaderWriterOptionsExpression? options, out ValueExpression value)
        {
            switch (serialization)
            {
                case JsonArraySerialization jsonReadOnlyMemory when jsonReadOnlyMemory.Type.IsReadOnlyMemory:
                    var array = new VariableReference(jsonReadOnlyMemory.Type.InitializationType, "array");
                    var index = new VariableReference(typeof(int), "index");
                    var deserializeReadOnlyMemory = new MethodBodyStatement[]
                    {
                        Declare(index, Int(0)),
                        Declare(array, New.Array(jsonReadOnlyMemory.ValueSerialization.Type, element.GetArrayLength())),
                        new ForeachStatement("item", element.EnumerateArray(), out var item)
                        {
                            DeserializeArrayItemIntoArray(jsonReadOnlyMemory.ValueSerialization, new ArrayElementExpression(array, index), new JsonElementExpression(item), options),
                            Increment(index)
                        }
                    };
                    value = New.Instance(jsonReadOnlyMemory.Type, array);
                    return deserializeReadOnlyMemory;

                case JsonArraySerialization arraySerialization:
                    var deserializeArrayStatement = new MethodBodyStatement[]
                    {
                        Declare("array", New.List(arraySerialization.ValueSerialization.Type), out var list),
                        new ForeachStatement("item", element.EnumerateArray(), out var arrayItem)
                        {
                            DeserializeArrayItemIntoList(arraySerialization.ValueSerialization, list, new JsonElementExpression(arrayItem), options)
                        }
                    };
                    value = list;
                    return deserializeArrayStatement;

                case JsonDictionarySerialization jsonDictionary:
                    var deserializeDictionaryStatement = new MethodBodyStatement[]
                    {
                        Declare("dictionary", New.Dictionary(jsonDictionary.Type.Arguments[0], jsonDictionary.Type.Arguments[1]), out var dictionary),
                        new ForeachStatement("property", element.EnumerateObject(), out var property)
                        {
                            DeserializeDictionaryValue(jsonDictionary.ValueSerialization, dictionary, new JsonPropertyExpression(property), options)
                        }
                    };
                    value = dictionary;
                    return deserializeDictionaryStatement;

                case JsonValueSerialization { Options: JsonSerializationOptions.UseManagedServiceIdentityV3 } valueSerialization:
                    var declareSerializeOptions = Var("serializeOptions", New.JsonSerializerOptions(), out var serializeOptions);
                    value = GetDeserializeValueExpression(element, valueSerialization.Type, options, valueSerialization.Format, serializeOptions);
                    return declareSerializeOptions;

                case JsonValueSerialization valueSerialization:
                    value = GetDeserializeValueExpression(element, valueSerialization.Type, options, valueSerialization.Format);
                    return EmptyStatement;

                default:
                    throw new InvalidOperationException($"{serialization.GetType()} is not supported.");
            }
        }

        private static MethodBodyStatement DeserializeArrayItemIntoList(JsonSerialization serialization, ListExpression listVariable, JsonElementExpression arrayItemVariable, ModelReaderWriterOptionsExpression? options)
            => NullCheckCollectionItemIfRequired(serialization, arrayItemVariable, listVariable.Add(Null), new[]
            {
                DeserializeValue(serialization, arrayItemVariable, options, out var value),
                listVariable.Add(value),
            });

        private static MethodBodyStatement DeserializeArrayItemIntoArray(JsonSerialization serialization, ArrayElementExpression arrayElement, JsonElementExpression arrayItemVariable, ModelReaderWriterOptionsExpression? options)
            => NullCheckCollectionItemIfRequired(serialization, arrayItemVariable, Assign(arrayElement, Null), new[]
            {
                DeserializeValue(serialization, arrayItemVariable, options, out var value),
                Assign(arrayElement, value),
            });

        private static MethodBodyStatement NullCheckCollectionItemIfRequired(JsonSerialization serialization, JsonElementExpression arrayItemVariable, MethodBodyStatement assignNull, MethodBodyStatement deserializeValue)
            => CollectionItemRequiresNullCheckInSerialization(serialization)
                ? new IfElseStatement(arrayItemVariable.ValueKindEqualsNull(), assignNull, deserializeValue)
                : deserializeValue;

        private static MethodBodyStatement DeserializeDictionaryValue(JsonSerialization serialization, DictionaryExpression dictionary, JsonPropertyExpression property, ModelReaderWriterOptionsExpression? options)
        {
            var deserializeValueBlock = new[]
            {
                DeserializeValue(serialization, property.Value, options, out var value),
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

        public static ValueExpression GetDeserializeValueExpression(JsonElementExpression element, CSharpType serializationType, ModelReaderWriterOptionsExpression? options, SerializationFormat serializationFormat = SerializationFormat.Default, ValueExpression? serializerOptions = null)
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

            return GetDeserializeImplementation(serializationType.Implementation, element, options, serializerOptions);
        }

        private static ValueExpression GetDeserializeImplementation(TypeProvider implementation, JsonElementExpression element, ModelReaderWriterOptionsExpression? options, ValueExpression? serializerOptions)
        {
            switch (implementation)
            {
                case SystemObjectType systemObjectType when IsCustomJsonConverterAdded(systemObjectType.SystemType):
                    return JsonSerializerExpression.Deserialize(element, implementation.Type, serializerOptions);

                case Resource { ResourceData: SerializableObjectType resourceDataType } resource:
                    return New.Instance(resource.Type, new MemberExpression(null, "Client"), SerializableObjectTypeExpression.Deserialize(resourceDataType, element));

                case MgmtObjectType mgmtObjectType when TypeReferenceTypeChooser.HasMatch(mgmtObjectType.InputModel):
                    return JsonSerializerExpression.Deserialize(element, implementation.Type);

                case SerializableObjectType type:
                    return SerializableObjectTypeExpression.Deserialize(type, element, options);

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
            if (!sourceType.IsFrameworkType || jsonPropertySerialization.SerializationConstructorParameterName == "serializedAdditionalRawData")
            {
                return variable;
            }
            else if (!jsonPropertySerialization.IsRequired)
            {
                return InvokeOptional.FallBackToChangeTrackingCollection(variable, jsonPropertySerialization.SerializedType);
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
                frameworkType == typeof(AzureLocation) ||
                frameworkType == typeof(ExtendedLocationType))
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

            if (frameworkType == typeof(Stream))
            {
                /* BinaryData.FromString(property.Value).ToStream() */
                return new BinaryDataExpression(BinaryDataExpression.FromString(element.GetRawText())).ToStream();
            }

            if (IsCustomJsonConverterAdded(frameworkType) && serializationType is not null)
            {
                return JsonSerializerExpression.Deserialize(element, serializationType);
            }

            if (frameworkType == typeof(JsonElement))
                return element.InvokeClone();
            if (frameworkType == typeof(object))
                return element.GetObject();
            if (frameworkType == typeof(bool))
                return element.GetBoolean();
            if (frameworkType == typeof(char))
                return element.GetChar();
            if (IsIntType(frameworkType))
                return GetIntTypeDeserializationValueExpression(element, frameworkType, format);
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
                if (format is SerializationFormat.Duration_Seconds)
                {
                    return TimeSpanExpression.FromSeconds(element.GetInt32());
                }

                if (format is SerializationFormat.Duration_Seconds_Float or SerializationFormat.Duration_Seconds_Double)
                {
                    return TimeSpanExpression.FromSeconds(element.GetDouble());
                }

                return element.GetTimeSpan(format.ToFormatSpecifier());
            }

            throw new NotSupportedException($"Framework type {frameworkType} is not supported, please add `CodeGenMemberSerializationHooks` to specify the serialization of this type with the customized property");
        }

        private static ValueExpression GetIntTypeDeserializationValueExpression(JsonElementExpression element, Type type, SerializationFormat format) => format switch
        {
            SerializationFormat.Int_String => new TypeReference(type).Invoke(nameof(int.Parse), new List<ValueExpression> { element.GetString() }),
            _ => type switch
            {
                Type t when t == typeof(sbyte) => element.GetSByte(),
                Type t when t == typeof(byte) => element.GetByte(),
                Type t when t == typeof(short) => element.GetInt16(),
                Type t when t == typeof(int) => element.GetInt32(),
                Type t when t == typeof(long) => element.GetInt64(),
                _ => throw new NotSupportedException($"Framework type {type} is not int.")
            }
        };

        private static bool IsIntType(Type frameworkType) =>
            frameworkType == typeof(sbyte) ||
            frameworkType == typeof(byte) ||
            frameworkType == typeof(short) ||
            frameworkType == typeof(int) ||
            frameworkType == typeof(long);

        private static MethodBodyStatement InvokeListAdd(ValueExpression list, ValueExpression value)
            => new InvokeInstanceMethodStatement(list, nameof(List<object>.Add), value);

        private static MethodBodyStatement InvokeArrayElementAssignment(ValueExpression array, ValueExpression index, ValueExpression value)
            => Assign(new ArrayElementExpression(array, index), value);

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
