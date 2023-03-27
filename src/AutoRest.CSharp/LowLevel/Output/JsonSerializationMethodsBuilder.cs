// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using static AutoRest.CSharp.Output.Models.MethodBodyLines;
using static AutoRest.CSharp.Output.Models.ValueExpressions;

namespace AutoRest.CSharp.Output.Models
{
    internal static class JsonSerializationMethodsBuilder
    {
        public static MethodBodyBlock WriteObject(ValueExpression utf8JsonWriter, JsonObjectSerialization serialization)
        {
            return new MethodBodyBlocks
            (
                LineCall.Utf8JsonWriter.WriteStartObject(utf8JsonWriter),
                WritProperties(utf8JsonWriter, serialization.Properties),
                SerializeAdditionalProperties(utf8JsonWriter, serialization.AdditionalProperties),
                LineCall.Utf8JsonWriter.WriteEndObject(utf8JsonWriter)
            );
        }

        public static MethodBodyBlock WritProperties(ValueExpression utf8JsonWriter, IEnumerable<JsonPropertySerialization> properties)
        {
            var blocks = new List<MethodBodyBlock>();
            foreach (JsonPropertySerialization property in properties)
            {
                if (property.ShouldSkipSerialization)
                {
                    continue;
                }

                if (property.ValueSerialization == null)
                {
                    // Flattened property
                    blocks.Add(LineCall.Utf8JsonWriter.WritePropertyName(utf8JsonWriter, property.SerializedName));
                    blocks.Add(LineCall.Utf8JsonWriter.WriteStartObject(utf8JsonWriter));
                    blocks.Add(WritProperties(utf8JsonWriter, property.PropertySerializations!));
                    blocks.Add(LineCall.Utf8JsonWriter.WriteEndObject(utf8JsonWriter));
                }
                else
                {
                    blocks.Add(WriteProperty(utf8JsonWriter, property));
                }
            }

            return new MethodBodyBlocks(blocks);
        }

        private static MethodBodyBlock WriteProperty(ValueExpression utf8JsonWriter, JsonPropertySerialization property)
        {
            var propertyNameReference = new FormattableStringToExpression($"{property.PropertyName:I}");

            var writePropertyNameLine = LineCall.Utf8JsonWriter.WritePropertyName(utf8JsonWriter, property.SerializedName);
            var writePropertyValueBlock = property is { OptionalViaNullability: true, PropertyType: { IsNullable: true, IsValueType: true } }
                ? SerializeExpression(utf8JsonWriter, property.ValueSerialization, new MemberReference(propertyNameReference, "Value"))
                : SerializeExpression(utf8JsonWriter, property.ValueSerialization, propertyNameReference);

            MethodBodyBlock writePropertyBlock = new MethodBodyBlocks(writePropertyNameLine, writePropertyValueBlock);
            MethodBodyBlock writePropertyWithNullCheckBlock = property.ValueType is { IsNullable: true }
                ? new IfElseBlock(IsNotNull(propertyNameReference), writePropertyBlock, LineCall.Utf8JsonWriter.WriteNull(utf8JsonWriter, property.SerializedName))
                : writePropertyBlock;

            if (property.IsRequired)
            {
                return writePropertyWithNullCheckBlock;
            }

            return TypeFactory.IsCollectionType(property.PropertyType)
                ? new IfElseBlock(Call.Optional.IsCollectionDefined(propertyNameReference), writePropertyWithNullCheckBlock, null)
                : new IfElseBlock(Call.Optional.IsDefined(propertyNameReference), writePropertyWithNullCheckBlock, null);
        }

        private static MethodBodyBlock SerializeAdditionalProperties(ValueExpression utf8JsonWriter, JsonAdditionalPropertiesSerialization? additionalProperties)
        {
            if (additionalProperties is null)
            {
                return new MethodBodyBlock();
            }

            var itemVariable = new CodeWriterDeclaration("item");
            return new ForeachBlock(itemVariable, new FormattableStringToExpression($"{additionalProperties.PropertyName}"), new MethodBodyBlocks(
                LineCall.Utf8JsonWriter.WritePropertyName(utf8JsonWriter, new MemberReference(itemVariable, nameof(KeyValuePair<string, string>.Key))),
                SerializeExpression(utf8JsonWriter, additionalProperties.ValueSerialization, new MemberReference(itemVariable, nameof(KeyValuePair<string, string>.Value))))
            );
        }

        public static MethodBodyBlock SerializeExpression(ValueExpression utf8JsonWriter, JsonSerialization? serialization, ValueExpression expression)
            => serialization switch
            {
                JsonArraySerialization array => SerializeArray(utf8JsonWriter, array, expression),
                JsonDictionarySerialization dictionary => SerializeDictionary(utf8JsonWriter, dictionary, expression),
                JsonValueSerialization value => SerializeValue(utf8JsonWriter, value, expression),
                _ => throw new NotSupportedException()
            };

        private static MethodBodyBlock SerializeArray(ValueExpression utf8JsonWriter, JsonArraySerialization arraySerialization, ValueExpression array)
        {
            var item = new CodeWriterDeclaration("item");
            return new MethodBodyBlocks
            (
                LineCall.Utf8JsonWriter.WriteStartArray(utf8JsonWriter),
                new ForeachBlock(item, array, new MethodBodyBlocks
                (
                    CheckCollectionItemForNull(utf8JsonWriter, arraySerialization.ValueSerialization, item),
                    SerializeExpression(utf8JsonWriter, arraySerialization.ValueSerialization, item))
                ),
                LineCall.Utf8JsonWriter.WriteEndArray(utf8JsonWriter)
            );
        }

        private static MethodBodyBlock SerializeDictionary(ValueExpression utf8JsonWriter, JsonDictionarySerialization dictionarySerialization, ValueExpression dictionary)
        {
            var keyValuePair = new CodeWriterDeclaration("item");
            var value = new MemberReference(keyValuePair, nameof(KeyValuePair<string, string>.Value));
            return new MethodBodyBlocks
            (
                LineCall.Utf8JsonWriter.WriteStartObject(utf8JsonWriter),
                new ForeachBlock(keyValuePair, dictionary, new MethodBodyBlocks
                (
                    LineCall.Utf8JsonWriter.WritePropertyName(utf8JsonWriter, new MemberReference(keyValuePair, nameof(KeyValuePair<string, string>.Key))),
                    CheckCollectionItemForNull(utf8JsonWriter, dictionarySerialization.ValueSerialization, value),
                    SerializeExpression(utf8JsonWriter, dictionarySerialization.ValueSerialization, value))
                ),
                LineCall.Utf8JsonWriter.WriteEndObject(utf8JsonWriter)
            );
        }

        private static MethodBodyBlock SerializeValue(ValueExpression utf8JsonWriter, JsonValueSerialization valueSerialization, ValueExpression value)
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
                        var declareSerializeOptions = DeclareJsonSerializerOptions(out var serializeOptions);
                        return new MethodBodyBlocks(declareSerializeOptions, LineCall.JsonSerializer.Serialize(utf8JsonWriter, value, serializeOptions));
                    }

                    return LineCall.JsonSerializer.Serialize(utf8JsonWriter, value);

                case ObjectType:
                    return LineCall.Utf8JsonWriter.WriteObjectValue(utf8JsonWriter, value);

                case EnumType { IsIntValueType: true, IsExtensible: false } enumType:
                    return LineCall.Utf8JsonWriter.WriteNumberValue(utf8JsonWriter, new CastExpression(NullableValue(value, valueSerialization.Type), enumType.ValueType));

                case EnumType enumType:
                    return LineCall.Utf8JsonWriter.WriteStringValue(utf8JsonWriter, Call.Enum.ToString(NullableValue(value, valueSerialization.Type), enumType));
            }

            throw new NotSupportedException();
        }

        private static MethodBodyBlock SerializeFrameworkTypeValue(ValueExpression utf8JsonWriter, JsonValueSerialization valueSerialization, ValueExpression value, Type valueType)
        {
            if (valueType == typeof(JsonElement))
            {
                return LineCall.JsonElement.WriteTo(value, utf8JsonWriter);
            }

            if (valueType == typeof(Nullable<>))
            {
                valueType = valueSerialization.Type.Arguments[0].FrameworkType;
            }
            value = NullableValue(value, valueSerialization.Type);

            if (valueType == typeof(decimal) || valueType == typeof(double) || valueType == typeof(float) || valueType == typeof(long) || valueType == typeof(int) || valueType == typeof(short))
            {
                return LineCall.Utf8JsonWriter.WriteNumberValue(utf8JsonWriter, value);
            }

            if (valueType == typeof(object))
            {
                return LineCall.Utf8JsonWriter.WriteObjectValue(utf8JsonWriter, value);
            }

            if (valueType == typeof(string) || valueType == typeof(char) || valueType == typeof(Guid) || valueType == typeof(ResourceIdentifier) || valueType == typeof(ResourceType) || valueType == typeof(RequestMethod) || valueType == typeof(AzureLocation))
            {
                return LineCall.Utf8JsonWriter.WriteStringValue(utf8JsonWriter, value);
            }

            if (valueType == typeof(bool))
            {
                return LineCall.Utf8JsonWriter.WriteBooleanValue(utf8JsonWriter, value);
            }

            if (valueType == typeof(byte[]))
            {
                return LineCall.Utf8JsonWriter.WriteBase64StringValue(utf8JsonWriter, value, valueSerialization.Format.ToFormatSpecifier());
            }

            if (valueType == typeof(DateTimeOffset) || valueType == typeof(DateTime) || valueType == typeof(TimeSpan))
            {
                if (valueSerialization.Format == SerializationFormat.DateTime_Unix)
                {
                    return LineCall.Utf8JsonWriter.WriteNumberValue(utf8JsonWriter, value, valueSerialization.Format.ToFormatSpecifier());
                }

                var format = valueSerialization.Format.ToFormatSpecifier();
                return format is not null
                    ? LineCall.Utf8JsonWriter.WriteStringValue(utf8JsonWriter, value, format)
                    : LineCall.Utf8JsonWriter.WriteStringValue(utf8JsonWriter, value);
            }

            if (valueType == typeof(ETag) || valueType == typeof(ContentType) || valueType == typeof(IPAddress))
            {
                return LineCall.Utf8JsonWriter.WriteStringValue(utf8JsonWriter, Call.ToString(value));
            }

            if (valueType == typeof(Uri))
            {
                return LineCall.Utf8JsonWriter.WriteStringValue(utf8JsonWriter, new MemberReference(value, nameof(Uri.AbsoluteUri)));
            }

            if (valueType == typeof(BinaryData))
            {
                return new IfElsePreprocessorBlock
                (
                    "NET6_0_OR_GREATER",
                    LineCall.Utf8JsonWriter.WriteRawValue(utf8JsonWriter, value),
                    LineCall.JsonSerializer.Serialize(utf8JsonWriter, new MemberReference(Call.JsonDocument.Parse(Call.ToString(value)), "RootElement"))
                );
            }

            if (IsCustomJsonConverterAdded(valueType))
            {
                return LineCall.JsonSerializer.Serialize(utf8JsonWriter, value);
            }

            throw new NotSupportedException($"Framework type {valueType} serialization not supported");
        }

        private static MethodBodyBlock CheckCollectionItemForNull(ValueExpression utf8JsonWriter, JsonSerialization valueSerialization, ValueExpression value)
            => JsonCodeWriterExtensions.CollectionItemRequiresNullCheckInSerialization(valueSerialization)
                ? new IfElseBlock(IsNull(value), new MethodBodyBlocks(LineCall.Utf8JsonWriter.WriteNullValue(utf8JsonWriter), Continue), null)
                : new MethodBodyBlock();

        private static ValueExpression NullableValue(ValueExpression value, CSharpType type)
            => type is { IsNullable: true, IsValueType: true } ? new MemberReference(value, "Value") : value;

        public static MethodBodyBlock BuildDeserializationForMethods(JsonSerialization serialization, bool async, CodeWriterDeclaration? variable, ValueExpression response, bool isBinaryData)
        {
            if (isBinaryData)
            {
                var callFromStream = Call.BinaryData.FromStream(response, async);
                return variable is not null ? new SetValueLine(variable, callFromStream) : new ReturnValueLine(callFromStream);
            }

            var declareDocument = Declare.JsonDocument(Call.JsonDocument.Parse(response, async), out var document);
            var deserializeValueBlock = DeserializeValue(serialization, Call.JsonDocument.GetRootElement(document), out var value);
            MethodBodyLine setOrReturnValue = variable is not null ? new SetValueLine(variable, value) : new ReturnValueLine(value);

            if (!serialization.IsNullable)
            {
                return new MethodBodyBlocks(declareDocument, deserializeValueBlock, setOrReturnValue);
            }

            return new MethodBodyBlocks(declareDocument, new IfElseBlock
            (
                new FormattableStringToExpression($"{document}.RootElement.ValueKind == {typeof(JsonValueKind)}.Null"),
                variable is not null ? new SetValueLine(variable, Null) : new ReturnValueLine(Null),
                new MethodBodyBlocks(deserializeValueBlock, setOrReturnValue)
            ));
        }

        public static MethodBodyBlock DeserializeValue(JsonSerialization serialization, ValueExpression element, out ValueExpression value)
        {
            switch (serialization)
            {
                case JsonArraySerialization jsonArray:
                    var array = new CodeWriterDeclaration("array");
                    var item = new CodeWriterDeclaration("item");
                    value = array;

                    var declareListVariable = new DeclareVariableLine(jsonArray.ImplementationType, array, New(jsonArray.ImplementationType));
                    var iterateOverJsonArray = new ForeachBlock(item, Call.JsonElement.EnumerateArray(element), DeserializeArrayItem(jsonArray.ValueSerialization, array, item));
                    return new MethodBodyBlocks(declareListVariable, iterateOverJsonArray);

                case JsonDictionarySerialization jsonDictionary:
                    var dictionary = new CodeWriterDeclaration("dictionary");
                    var property = new CodeWriterDeclaration("property");
                    value = dictionary;

                    var declareDictionaryVariable = new DeclareVariableLine(jsonDictionary.Type, dictionary, New(jsonDictionary.Type));
                    var iterateOverJsonObject = new ForeachBlock(property, Call.JsonElement.EnumerateObject(element), DeserializeDictionaryValue(jsonDictionary.ValueSerialization, dictionary, property));

                    return new MethodBodyBlocks(declareDictionaryVariable, iterateOverJsonObject);

                case JsonValueSerialization { Options: JsonSerializationOptions.UseManagedServiceIdentityV3 } valueSerialization:
                    var declareSerializeOptions = DeclareJsonSerializerOptions(out var serializeOptions);
                    value = GetDeserializeValueExpression(element, valueSerialization.Type, valueSerialization.Format, serializeOptions);
                    return declareSerializeOptions;

                case JsonValueSerialization valueSerialization:
                    value = GetDeserializeValueExpression(element, valueSerialization.Type, valueSerialization.Format);
                    return new MethodBodyBlock();

                default:
                    throw new InvalidOperationException($"{serialization.GetType()} is not supported.");
            }
        }

        private static MethodBodyBlock DeserializeArrayItem(JsonSerialization serialization, CodeWriterDeclaration arrayVariable, CodeWriterDeclaration arrayItemVariable)
        {
            var deserializeValueBlock = DeserializeValue(serialization, arrayItemVariable, out var value);
            var addValueLine = LineCall.List.Add(arrayVariable, value);

            if (JsonCodeWriterExtensions.CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                return new IfElseBlock
                (
                    new FormattableStringToExpression($"{arrayItemVariable}.ValueKind == {typeof(JsonValueKind)}.Null"),
                    LineCall.List.Add(arrayVariable, Null),
                    new MethodBodyBlocks(deserializeValueBlock, addValueLine)
                );
            }

            return new MethodBodyBlocks(deserializeValueBlock, addValueLine);
        }

        private static MethodBodyBlock DeserializeDictionaryValue(JsonSerialization serialization, CodeWriterDeclaration dictionaryVariable, CodeWriterDeclaration itemVariable)
        {
            var key = new MemberReference(itemVariable, "Name");

            var deserializeValueBlock = DeserializeValue(serialization, new MemberReference(itemVariable, "Value"), out var value);
            var addValueLine = LineCall.Dictionary.Add(dictionaryVariable, key, value);

            if (JsonCodeWriterExtensions.CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                return new IfElseBlock
                (
                    new FormattableStringToExpression($"{itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null"),
                    LineCall.Dictionary.Add(dictionaryVariable, key, Null),
                    new MethodBodyBlocks(deserializeValueBlock, addValueLine)
                );
            }

            return new MethodBodyBlocks(deserializeValueBlock, addValueLine);
        }

        public static ValueExpression GetDeserializeValueExpression(ValueExpression element, CSharpType serializationType, SerializationFormat serializationFormat = SerializationFormat.Default, ValueExpression? serializerOptions = null)
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

        public static ValueExpression GetDeserializeImplementation(TypeProvider implementation, ValueExpression element, ValueExpression? serializerOptions)
        {
            switch (implementation)
            {
                case SystemObjectType systemObjectType when IsCustomJsonConverterAdded(systemObjectType.SystemType):
                    return Call.JsonSerializer.Deserialize(element, implementation.Type, serializerOptions);

                case Resource { ResourceData: SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } resourceDataType } resource:
                    return New(resource.Type, new FormattableStringToExpression($"Client"), Call.Static(resourceDataType.Type, $"Deserialize{resourceDataType.Declaration.Name}", element));

                case MgmtObjectType mgmtObjectType when TypeReferenceTypeChooser.HasMatch(mgmtObjectType.ObjectSchema):
                    return Call.JsonSerializer.Deserialize(element, implementation.Type);

                case SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } type:
                    return Call.Static(type.Type, $"Deserialize{type.Declaration.Name}", element);

                case EnumType clientEnum:
                    var value = GetFrameworkTypeValueExpression(clientEnum.ValueType.FrameworkType, element, SerializationFormat.Default, null);
                    return clientEnum.IsExtensible ? New(clientEnum.Type, value) : Call.ToEnum(clientEnum.Type, value);

                default:
                    throw new NotSupportedException($"No deserialization logic exists for {implementation.Declaration.Name}");
            }
        }

        public static ValueExpression GetFrameworkTypeValueExpression(Type frameworkType, ValueExpression element, SerializationFormat format, CSharpType? serializationType)
        {
            bool includeFormat = false;

            if (frameworkType == typeof(ETag) ||
                frameworkType == typeof(Uri) ||
                frameworkType == typeof(ResourceIdentifier) ||
                frameworkType == typeof(ResourceType) ||
                frameworkType == typeof(ContentType) ||
                frameworkType == typeof(RequestMethod) ||
                frameworkType == typeof(AzureLocation))
            {
                return New(frameworkType, Call.JsonElement.GetString(element));
            }

            if (frameworkType == typeof(IPAddress))
            {
                return Call.Static(typeof(IPAddress), nameof(IPAddress.Parse), Call.JsonElement.GetString(element));
            }

            if (frameworkType == typeof(BinaryData))
            {
                return Call.BinaryData.FromString(Call.JsonElement.GetRawText(element));
            }

            if (IsCustomJsonConverterAdded(frameworkType) && serializationType is not null)
            {
                return Call.JsonSerializer.Deserialize(element, serializationType);
            }

            var methodName = string.Empty;
            var callStaticExtension = false;
            if (frameworkType == typeof(JsonElement))
                methodName = nameof(JsonElement.Clone);
            if (frameworkType == typeof(object))
            {
                methodName = nameof(JsonElementExtensions.GetObject);
                callStaticExtension = true;
            }

            if (frameworkType == typeof(bool))
                methodName = nameof(JsonElement.GetBoolean);
            if (frameworkType == typeof(char))
            {
                methodName = nameof(JsonElementExtensions.GetChar);
                callStaticExtension = true;
            }

            if (frameworkType == typeof(short))
                methodName = nameof(JsonElement.GetInt16);
            if (frameworkType == typeof(int))
                methodName = nameof(JsonElement.GetInt32);
            if (frameworkType == typeof(long))
                methodName = nameof(JsonElement.GetInt64);
            if (frameworkType == typeof(float))
                methodName = nameof(JsonElement.GetSingle);
            if (frameworkType == typeof(double))
                methodName = nameof(JsonElement.GetDouble);
            if (frameworkType == typeof(decimal))
                methodName = nameof(JsonElement.GetDecimal);
            if (frameworkType == typeof(string))
                methodName = nameof(JsonElement.GetString);
            if (frameworkType == typeof(Guid))
                methodName = nameof(JsonElement.GetGuid);

            if (frameworkType == typeof(byte[]))
            {
                methodName = nameof(JsonElementExtensions.GetBytesFromBase64);
                callStaticExtension = true;
                includeFormat = true;
            }

            if (frameworkType == typeof(DateTimeOffset))
            {
                methodName = nameof(JsonElementExtensions.GetDateTimeOffset);
                callStaticExtension = true;
                includeFormat = true;
            }

            if (frameworkType == typeof(DateTime))
            {
                methodName = nameof(JsonElement.GetDateTime);
                includeFormat = true;
            }

            if (frameworkType == typeof(TimeSpan))
            {
                methodName = nameof(JsonElementExtensions.GetTimeSpan);
                callStaticExtension = true;
                includeFormat = true;
            }

            var arguments = new List<ValueExpression>();
            if (callStaticExtension)
            {
                arguments.Add(element);
            }
            if (includeFormat && format.ToFormatSpecifier() is { } formatString)
            {
                arguments.Add(Literal(formatString));
            }

            return callStaticExtension
                ? new StaticMethodCallExpression(typeof(JsonElementExtensions), methodName, arguments, CallAsExtension: true)
                : new InstanceMethodCallExpression(element, methodName, arguments, false);
        }

        private static DeclareVariableLine DeclareJsonSerializerOptions(out CodeWriterDeclaration serializeOptions)
        {
            serializeOptions = new CodeWriterDeclaration("serializeOptions");
            var properties = new Dictionary<string, ValueExpression>
            {
                [nameof(JsonSerializerOptions.Converters)] = new CollectionInitializerExpression(New(typeof(ManagedServiceIdentityTypeV3Converter)))
            };
            return new DeclareVariableLine(null, serializeOptions, New(typeof(JsonSerializerOptions), properties));
        }

        private static bool IsCustomJsonConverterAdded(Type type)
            => type.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonConverterAttribute));
    }
}
