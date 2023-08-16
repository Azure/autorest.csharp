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
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.Core.Serialization;
using Azure.ResourceManager.Models;
using Configuration = AutoRest.CSharp.Input.Configuration;
using JsonElementExtensions = Azure.Core.JsonElementExtensions;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class JsonCodeWriterExtensions
    {
        private static readonly FormattableString IsFormatJson = $"options.{nameof(ModelSerializerOptions.Format)} == {typeof(ModelSerializerFormat)}.{nameof(ModelSerializerFormat.Json)}";

        public static void ToSerializeCall(this CodeWriter writer, JsonObjectSerialization serialization)
        {
            FormattableString writerName = $"writer";

            writer.Line($"{writerName}.WriteStartObject();");
            writer.ToSerializeCall(writerName, serialization.Properties);

            if (serialization.AdditionalProperties?.ValueSerialization != null)
            {
                var itemVariable = new CodeWriterDeclaration("item");

                using (writer.Scope($"foreach (var {itemVariable:D} in {serialization.AdditionalProperties.PropertyName})"))
                {
                    writer.Line($"{writerName}.WritePropertyName({itemVariable}.Key);");
                    writer.ToSerializeCall(serialization.AdditionalProperties.ValueSerialization, $"{itemVariable:I}.Value", writerName);
                }
            }
            else if (serialization.ObjectType is not null && serialization.ObjectType.HasRawDataInHeirarchy)
            {
                using (writer.Scope($"if (_rawData is not null && {IsFormatJson})"))
                {
                    using (writer.Scope($"foreach (var property in _rawData)"))
                    {
                        writer.Line($"writer.{nameof(Utf8JsonWriter.WritePropertyName)}(property.Key);");
                        WriteRawJson(writer, $"property.Value", writerName);
                    }
                }
            }

            writer.Line($"{writerName}.WriteEndObject();");
        }

        public static void ToSerializeCall(this CodeWriter writer, JsonSerialization serialization, FormattableString name, FormattableString? writerName = null)
        {
            writerName ??= $"writer";

            switch (serialization)
            {
                case JsonArraySerialization array:
                    ToArraySerializeCall(writer, name, writerName, array);
                    return;

                case JsonDictionarySerialization dictionary:
                    writer.Line($"{writerName}.WriteStartObject();");
                    var dictionaryItemVariable = new CodeWriterDeclaration("item");

                    using (writer.Scope($"foreach (var {dictionaryItemVariable:D} in {name:I})"))
                    {
                        writer.Line($"{writerName}.WritePropertyName({dictionaryItemVariable:I}.Key);");

                        if (CollectionItemRequiresNullCheckInSerialization(dictionary.ValueSerialization))
                        {
                            using (writer.Scope($"if ({dictionaryItemVariable:I}.Value == null)"))
                            {
                                writer.Line($"{writerName}.WriteNullValue();");
                                writer.Line($"continue;");
                            }
                        }
                        writer.ToSerializeCall(
                            dictionary.ValueSerialization,
                            $"{dictionaryItemVariable:I}.Value",
                            writerName);
                    }

                    writer.Line($"{writerName}.WriteEndObject();");
                    return;

                case JsonValueSerialization valueSerialization:
                    writer.UseNamespace(typeof(Utf8JsonWriterExtensions).Namespace!);

                    Type? frameworkType = valueSerialization.Type.SerializeAs != null ? valueSerialization.Type.SerializeAs : valueSerialization.Type.IsFrameworkType ? valueSerialization.Type.FrameworkType : null;
                    if (frameworkType != null)
                    {
                        if (frameworkType == typeof(JsonElement))
                        {
                            writer.Line($"{name:I}.WriteTo({writerName});");
                            return;
                        }

                        if (frameworkType == typeof(Nullable<>))
                        {
                            frameworkType = valueSerialization.Type.Arguments[0].FrameworkType;
                        }
                        bool writeFormat = false;
                        bool addToArrayForBinaryData = false;

                        if (frameworkType != typeof(BinaryData) && frameworkType != typeof(DataFactoryElement<>))
                            writer.Append($"{writerName}.");
                        if (frameworkType == typeof(decimal) ||
                            frameworkType == typeof(double) ||
                            frameworkType == typeof(float) ||
                            frameworkType == typeof(long) ||
                            frameworkType == typeof(int) ||
                            frameworkType == typeof(short))
                        {
                            writer.AppendRaw("WriteNumberValue");
                        }
                        else if (frameworkType == typeof(object))
                        {
                            writer.AppendRaw("WriteObjectValue");
                        }
                        else if (frameworkType == typeof(string) ||
                                 frameworkType == typeof(char) ||
                                 frameworkType == typeof(Guid) ||
                                 frameworkType == typeof(Azure.Core.ResourceIdentifier) ||
                                 frameworkType == typeof(Azure.Core.ResourceType) ||
                                 frameworkType == typeof(Azure.Core.AzureLocation))
                        {
                            writer.AppendRaw("WriteStringValue");
                        }
                        else if (frameworkType == typeof(bool))
                        {
                            writer.AppendRaw("WriteBooleanValue");
                        }
                        else if (frameworkType == typeof(byte[]))
                        {
                            writer.AppendRaw("WriteBase64StringValue");
                            writeFormat = true;
                        }
                        else if (frameworkType == typeof(DateTimeOffset) ||
                                 frameworkType == typeof(DateTime) ||
                                 frameworkType == typeof(TimeSpan))
                        {
                            if (valueSerialization.Format == SerializationFormat.DateTime_Unix ||
                                valueSerialization.Format == SerializationFormat.Duration_Seconds ||
                                valueSerialization.Format == SerializationFormat.Duration_Seconds_Float)
                            {
                                writer.AppendRaw("WriteNumberValue");
                            }
                            else
                            {
                                writer.AppendRaw("WriteStringValue");
                            }
                            writeFormat = true;
                        }
                        else if (frameworkType == typeof(ETag) ||
                            frameworkType == typeof(Azure.Core.ContentType) ||
                            frameworkType == typeof(IPAddress) ||
                            frameworkType == typeof(RequestMethod))
                        {
                            writer.Line($"WriteStringValue({name:I}.ToString());");
                            return;
                        }
                        else if (frameworkType == typeof(Uri))
                        {
                            writer.Line($"WriteStringValue({name:I}.{nameof(Uri.AbsoluteUri)});");
                            return;
                        }
                        else if (frameworkType == typeof(BinaryData))
                        {
                            switch (valueSerialization.Format)
                            {
                                case SerializationFormat.Bytes_Base64: //intentional fall through
                                case SerializationFormat.Bytes_Base64Url:
                                    writer.Append($"{writerName}.");
                                    writer.AppendRaw("WriteBase64StringValue");
                                    writeFormat = true;
                                    addToArrayForBinaryData = true;
                                    break;
                                default:
                                    WriteRawJson(writer, name, writerName);
                                    return;
                            }
                        }
                        else if (IsCustomJsonConverterAdded(frameworkType))
                        {
                            writer.Line($"{typeof(JsonSerializer)}.{nameof(JsonSerializer.Serialize)}(writer, {name:I});");
                            return;
                        }

                        if (frameworkType == typeof(TimeSpan))
                        {
                            if (valueSerialization.Format == SerializationFormat.Duration_Seconds)
                            {
                                writer.Append($"(Convert.ToInt32({name:I}.ToString({valueSerialization.Format.ToFormatSpecifier():L})));");
                                writer.LineRaw("");
                                return;
                            }
                            else if (valueSerialization.Format == SerializationFormat.Duration_Seconds_Float)
                            {
                                writer.Append($"(Convert.ToDouble({name:I}.ToString({valueSerialization.Format.ToFormatSpecifier():L})));");
                                writer.LineRaw("");
                                return;
                            }
                        }

                        writer.Append($"({name:I}")
                            .AppendNullableValue(valueSerialization.Type);

                        if (frameworkType == typeof(BinaryData) && addToArrayForBinaryData)
                            writer.Append($".ToArray()");

                        if (writeFormat && valueSerialization.Format.ToFormatSpecifier() is string formatString)
                        {
                            writer.Append($", {formatString:L}");
                        }

                        writer.LineRaw(");");
                        return;
                    }

                    switch (valueSerialization.Type.Implementation)
                    {
                        case SystemObjectType systemObjectType when IsCustomJsonConverterAdded(systemObjectType.SystemType):
                            var optionalSerializeOptions = string.Empty;
                            if (valueSerialization.Options == JsonSerializationOptions.UseManagedServiceIdentityV3)
                            {
                                writer.UseNamespace("Azure.ResourceManager.Models");
                                writer.Line($"var serializeOptions = new {typeof(JsonSerializerOptions)} {{ Converters = {{ new {nameof(ManagedServiceIdentityTypeV3Converter)}() }} }};");
                                optionalSerializeOptions = ", serializeOptions";
                            }

                            writer.Append($"{typeof(JsonSerializer)}.{nameof(JsonSerializer.Serialize)}(writer, {name:I}{optionalSerializeOptions});");
                            return;

                        case ObjectType:
                            //case ModelTypeProvider:
                            writer.Line($"{writerName}.WriteObjectValue({name:I});");
                            return;

                        case EnumType clientEnum when clientEnum is { IsExtensible: false, IsIntValueType: true }:
                            writer.Append($"{writerName}.WriteNumberValue(({clientEnum.ValueType}){name:I}")
                                .AppendNullableValue(valueSerialization.Type)
                                .LineRaw(");");
                            return;
                        case EnumType clientEnum when clientEnum is { IsStringValueType: false }:
                            writer
                                .Append($"{writerName}.WriteNumberValue({name:I}")
                                .AppendNullableValue(valueSerialization.Type)
                                .AppendEnumToString(clientEnum)
                                .LineRaw(");");
                            return;
                        case EnumType clientEnum:
                            writer
                                .Append($"{writerName}.WriteStringValue({name:I}")
                                .AppendNullableValue(valueSerialization.Type)
                                .AppendEnumToString(clientEnum)
                                .LineRaw(");");
                            return;
                    }

                    throw new NotSupportedException();

                default:
                    throw new NotSupportedException();
            }
        }

        private static void WriteRawJson(CodeWriter writer, FormattableString name, FormattableString? writerName)
        {
            writer.Line($"#if NET6_0_OR_GREATER");
            writer.Line($"\t\t\t\t{writerName}.WriteRawValue({name:I});");
            writer.Line($"#else");
            writer.Line($"{typeof(JsonSerializer)}.{nameof(JsonSerializer.Serialize)}({writerName}, {typeof(JsonDocument)}.Parse({name:I}.ToString()).RootElement);");
            writer.Line($"#endif");
        }

        private static void ToArraySerializeCall(CodeWriter writer, FormattableString name, FormattableString? writerName, JsonArraySerialization array)
        {
            writer.Line($"{writerName}.WriteStartArray();");
            var collectionItemVariable = new CodeWriterDeclaration("item");

            using (writer.Scope($"foreach (var {collectionItemVariable:D} in {name:I})"))
            {
                if (CollectionItemRequiresNullCheckInSerialization(array.ValueSerialization))
                {
                    using (writer.Scope($"if ({collectionItemVariable:I} == null)"))
                    {
                        writer.Line($"{writerName}.WriteNullValue();");
                        writer.Line($"continue;");
                    }
                }
                writer.ToSerializeCall(
                    array.ValueSerialization,
                    $"{collectionItemVariable:I}",
                    writerName);
            }

            writer.Line($"{writerName}.WriteEndArray();");
        }

        private static void ToSerializeCall(this CodeWriter writer, FormattableString writerName, IEnumerable<JsonPropertySerialization> propertySerializations)
        {
            foreach (JsonPropertySerialization property in propertySerializations)
            {
                if (property.ShouldSkipSerialization)
                {
                    continue;
                }

                if (property.ValueSerialization == null)
                {
                    // Flattened property
                    writer.Line($"{writerName}.WritePropertyName({property.SerializedName:L}u8);");
                    writer.Line($"{writerName}.WriteStartObject();");
                    writer.ToSerializeCall(writerName, property.PropertySerializations!);
                    writer.Line($"{writerName}.WriteEndObject();");
                    continue;
                }

                using (writer.WriteDefinedCheck(property))
                {
                    var ifScope = writer.WritePropertyNullCheckIf(property);
                    using (ifScope)
                    {
                        var propertyType = property.PropertyType;
                        var declarationName = property.PropertyName;

                        writer.Line($"{writerName}.WritePropertyName({property.SerializedName:L}u8);");

                        if (property.SerializationValueHook is not null)
                        {
                            // write the serialization value hook
                            writer.Line($"{property.SerializationValueHook}({writerName});");
                        }
                        else if (property.OptionalViaNullability && propertyType.IsNullable && propertyType.IsValueType)
                        {
                            writer.ToSerializeCall(property.ValueSerialization, $"{declarationName:I}.Value");
                        }
                        else
                        {
                            writer.ToSerializeCall(property.ValueSerialization, $"{declarationName:I}");
                        }
                    }

                    if (ifScope != null)
                    {
                        using (writer.Scope($"else"))
                        {
                            writer.Line($"{writerName}.WriteNull({property.SerializedName:L});");
                        }
                    }
                }
            }
        }

        private static void DeserializeIntoObjectProperties(this CodeWriter writer, IEnumerable<JsonPropertySerialization> propertySerializations, FormattableString itemVariable, Dictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            foreach (JsonPropertySerialization property in propertySerializations.Where(p => !p.ShouldSkipDeserialization))
            {
                writer.Append($"if({itemVariable}.NameEquals({property.SerializedName:L}u8))");
                using (writer.Scope())
                {
                    if (property.DeserializationValueHook is not null)
                    {
                        // if we have the deserialization hook here, we do not need to do any check, all these checks should be taken care of by the hook
                    }
                    else if (property.ValueType?.IsNullable == true)
                    {
                        var emptyStringCheck = GetEmptyStringCheckClause(property, itemVariable, shouldTreatEmptyStringAsNull);
                        using (writer.Scope($"if ({itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null{emptyStringCheck})"))
                        {
                            if (Configuration.DeserializeNullCollectionAsNullValue)
                            {
                                // we will assign null to everything if we have this configuration on
                                writer.Line($"{propertyVariables[property].Declaration} = null;");
                            }
                            else
                            {
                                // we only assign null when it is not a collection if we have this configuration off
                                if (!TypeFactory.IsCollectionType(property.ValueType))
                                {
                                    writer.Line($"{propertyVariables[property].Declaration} = null;");
                                }
                                else if (property.IsRequired)
                                {
                                    // specially when it is required, we assign ChangeTrackingList because for optional lists we are already doing that
                                    writer.Line($"{propertyVariables[property].Declaration} = new {TypeFactory.GetPropertyImplementationType(property.ValueType)}();");
                                }
                            }
                            writer.Append($"continue;");
                        }
                    }
                    else if (!property.IsRequired &&
                             property.ValueType?.Equals(typeof(JsonElement)) != true && // JsonElement handles nulls internally
                             property.ValueType?.Equals(typeof(string)) !=
                             true) //https://github.com/Azure/autorest.csharp/issues/922
                    {
                        var emptyStringCheck = GetEmptyStringCheckClause(property, itemVariable, shouldTreatEmptyStringAsNull);
                        if (property.PropertySerializations is null)
                        {
                            using (writer.Scope($"if ({itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null{emptyStringCheck})"))
                            {
                                writer.Append($"continue;");
                            }
                        }
                        else
                        {
                            using (writer.Scope($"if ({itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null{emptyStringCheck})"))
                            {
                                writer.UseNamespace(typeof(JsonElementExtensions).Namespace!);
                                writer.Line($"{itemVariable}.{nameof(JsonElementExtensions.ThrowNonNullablePropertyIsNull)}();");
                                writer.Append($"continue;");
                            }
                        }
                    }

                    if (property.DeserializationValueHook is not null)
                    {
                        // write the deserialization hook
                        writer.Line($"{property.DeserializationValueHook}({itemVariable}, ref {propertyVariables[property].Declaration});");
                    }
                    else if (property.ValueSerialization is not null)
                    {
                        // Reading a property value
                        var variableOrExpression = writer.DeserializeValue(property.ValueSerialization, $"{itemVariable}.Value");
                        writer.Line($"{propertyVariables[property].Declaration} = {variableOrExpression};");
                    }
                    else if (property.PropertySerializations is not null)
                    {
                        // Reading a nested object
                        var nestedItemVariable = new CodeWriterDeclaration("property");
                        using (writer.Scope($"foreach (var {nestedItemVariable:D} in {itemVariable:I}.Value.EnumerateObject())"))
                        {
                            writer.DeserializeIntoObjectProperties(property.PropertySerializations, $"{nestedItemVariable:I}", propertyVariables, shouldTreatEmptyStringAsNull);
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException($"Either {nameof(JsonPropertySerialization.ValueSerialization)} must not be null or {nameof(JsonPropertySerialization.PropertySerializations)} must not be null.");
                    }

                    writer.Line($"continue;");
                }
            }
        }

        private static FormattableString GetEmptyStringCheckClause(JsonPropertySerialization property, FormattableString itemVariable, bool shouldTreatEmptyStringAsNull)
        {
            FormattableString result = $"";
            if (!shouldTreatEmptyStringAsNull)
                return result;
            if (property.ValueSerialization is JsonValueSerialization valueSerialization
                && valueSerialization.Type.IsFrameworkType)
            {
                if (Configuration.IntrinsicTypesToTreatEmptyStringAsNull.Contains(valueSerialization.Type.FrameworkType.Name))
                {
                    result = $" || {itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.{nameof(JsonValueKind.String)} && {itemVariable}.Value.GetString().Length == 0";
                }
            }
            return result;
        }

        private static FormattableString GetOptionalFormattable(JsonPropertySerialization target, ObjectPropertyVariable variable)
        {
            var targetType = target.PropertyType;
            var sourceType = variable.Type;
            if (sourceType.IsFrameworkType && sourceType.FrameworkType == typeof(Optional<>))
            {
                if (TypeFactory.IsList(targetType))
                {
                    return $"{typeof(Optional)}.ToList({variable.Declaration})";
                }

                if (TypeFactory.IsDictionary(targetType))
                {
                    return $"{typeof(Optional)}.ToDictionary({variable.Declaration})";
                }

                if (targetType.IsValueType && targetType.IsNullable)
                {
                    return $"{typeof(Optional)}.ToNullable({variable.Declaration})";
                }

                if (targetType.IsNullable)
                {
                    return $"{variable.Declaration}.Value";
                }
            }

            return $"{variable.Declaration}";
        }

        /// Collects a list of properties being read from all level of object hierarchy
        private static void CollectPropertiesForDeserialization(Dictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, IEnumerable<JsonPropertySerialization> jsonProperties)
        {
            foreach (JsonPropertySerialization jsonProperty in jsonProperties.Where(p => !p.ShouldSkipDeserialization))
            {
                if (jsonProperty.ValueType != null)
                {
                    var propertyDeclaration = new CodeWriterDeclaration(jsonProperty.SerializedName.ToVariableName());

                    var type = jsonProperty.ValueType;
                    if (!jsonProperty.IsRequired)
                    {
                        if (type.IsFrameworkType && type.FrameworkType == typeof(Nullable<>))
                            type = new CSharpType(type.Arguments[0].FrameworkType);
                        type = new CSharpType(typeof(Optional<>), type);
                    }

                    propertyVariables.Add(jsonProperty, new ObjectPropertyVariable(propertyDeclaration, type));
                }
                else if (jsonProperty.PropertySerializations != null)
                {
                    CollectPropertiesForDeserialization(propertyVariables, jsonProperty.PropertySerializations);
                }
            }
        }

        public static FormattableString DeserializeValue(this CodeWriter writer, JsonSerialization serialization, FormattableString element)
        {
            switch (serialization)
            {
                case JsonArraySerialization array:
                    var arrayVariable = new CodeWriterDeclaration("array");
                    writer.Line($"{array.ImplementationType} {arrayVariable:D} = new {array.ImplementationType}();");

                    var collectionItemVariable = new CodeWriterDeclaration("item");
                    using (writer.Scope($"foreach (var {collectionItemVariable:D} in {element}.EnumerateArray())"))
                    {
                        writer.DeserializeArrayItem(array.ValueSerialization, arrayVariable, collectionItemVariable);
                    }

                    return $"{arrayVariable:I}";
                case JsonDictionarySerialization dictionary:
                    var dictionaryVariable = new CodeWriterDeclaration("dictionary");
                    writer.Line($"{dictionary.Type} {dictionaryVariable:D} = new {dictionary.Type}();");

                    var dictionaryItemVariable = new CodeWriterDeclaration("property");
                    using (writer.Scope($"foreach (var {dictionaryItemVariable:D} in {element}.EnumerateObject())"))
                    {
                        writer.DeserializeDictionaryValue(dictionary.ValueSerialization, dictionaryVariable, dictionaryItemVariable);
                    }

                    return $"{dictionaryVariable:I}";
                case JsonValueSerialization valueSerialization:
                    if (valueSerialization.Options == JsonSerializationOptions.UseManagedServiceIdentityV3)
                    {
                        writer.UseNamespace("Azure.ResourceManager.Models");
                        writer.Line($"var serializeOptions = new {typeof(JsonSerializerOptions)} {{ Converters = {{ new {nameof(ManagedServiceIdentityTypeV3Converter)}() }} }};");
                    }

                    writer.UseNamespace(typeof(JsonElementExtensions).Namespace!);
                    return GetDeserializeValueFormattable(valueSerialization, element);
                default:
                    throw new InvalidOperationException($"{serialization.GetType()} is not supported.");
            }
        }

        private static void DeserializeArrayItem(this CodeWriter writer, JsonSerialization serialization, CodeWriterDeclaration arrayVariable, CodeWriterDeclaration arrayItemVariable)
        {
            if (CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                using (writer.Scope($"if ({arrayItemVariable}.ValueKind == {typeof(JsonValueKind)}.Null)"))
                {
                    writer.Append($"{arrayVariable}.Add(null);");
                }
                using (writer.Scope($"else"))
                {
                    var variableOrExpression = writer.DeserializeValue(serialization, $"{arrayItemVariable}");
                    writer.Append($"{arrayVariable}.Add({variableOrExpression});");
                }
            }
            else
            {
                var variableOrExpression = writer.DeserializeValue(serialization, $"{arrayItemVariable}");
                writer.Append($"{arrayVariable}.Add({variableOrExpression});");
            }
        }

        private static void DeserializeDictionaryValue(this CodeWriter writer, JsonSerialization serialization, CodeWriterDeclaration dictionaryVariable, CodeWriterDeclaration itemVariable)
        {
            if (CollectionItemRequiresNullCheckInSerialization(serialization))
            {
                using (writer.Scope($"if ({itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null)"))
                {
                    writer.Line($"{dictionaryVariable}.Add({itemVariable}.Name, null);");
                }
                using (writer.Scope($"else"))
                {
                    var variableOrExpression = writer.DeserializeValue(serialization, $"{itemVariable}.Value");
                    writer.Append($"{dictionaryVariable}.Add({itemVariable}.Name, {variableOrExpression});");
                }
            }
            else
            {
                var variableOrExpression = writer.DeserializeValue(serialization, $"{itemVariable}.Value");
                writer.Append($"{dictionaryVariable}.Add({itemVariable}.Name, {variableOrExpression});");
            }
        }

        private static bool CollectionItemRequiresNullCheckInSerialization(JsonSerialization serialization) =>
            serialization is { IsNullable: true } and JsonValueSerialization { Type: { IsValueType: true } } || // nullable value type, like int?
            serialization is JsonArraySerialization or JsonDictionarySerialization || // list or dictionary
            serialization is JsonValueSerialization jsonValueSerialization &&
                jsonValueSerialization is { Type: { IsValueType: false, IsFrameworkType: true } } && // framework reference type, e.g. byte[]
                jsonValueSerialization.Type.FrameworkType != typeof(string) && // excluding string, because JsonElement.GetString() can handle null
                jsonValueSerialization.Type.FrameworkType != typeof(byte[]); // excluding byte[], because JsonElement.GetBytesFromBase64() can handle null

        public static void WriteObjectInitialization(this CodeWriter writer, JsonObjectSerialization serialization)
        {
            // this is the first level of object hierarchy
            // collect all properties and initialize the dictionary
            var propertyVariables = new Dictionary<JsonPropertySerialization, ObjectPropertyVariable>();

            CollectPropertiesForDeserialization(propertyVariables, serialization.Properties);

            var additionalProperties = serialization.AdditionalProperties;
            if (additionalProperties != null)
            {
                var propertyDeclaration = new CodeWriterDeclaration(additionalProperties.PropertyName.ToVariableName());
                propertyVariables.Add(additionalProperties, new ObjectPropertyVariable(propertyDeclaration, additionalProperties.PropertyType));
            }

            bool isThisTheDefaultDerivedType = serialization.Type.Equals(serialization.Discriminator?.DefaultObjectType.Type);

            foreach (var variable in propertyVariables)
            {
                string defaultValue = "default";
                if (serialization.Discriminator?.SerializedName == variable.Key.SerializedName &&
                    isThisTheDefaultDerivedType &&
                    serialization.Discriminator.Value is not null &&
                    (!serialization.Discriminator.Property.ValueType.IsEnum ||
                    (serialization.Discriminator.Property.ValueType.Implementation is EnumType enumType &&
                    enumType.IsExtensible)))
                {
                    defaultValue = $"\"{serialization.Discriminator.Value.Value.Value}\"";
                }
                writer.Line($"{variable.Value.Type} {variable.Value.Declaration:D} = {defaultValue};");
            }

            var dictionaryVariable = new CodeWriterDeclaration("additionalPropertiesDictionary");

            var objAdditionalProperties = serialization.AdditionalProperties;
            if (objAdditionalProperties != null)
            {
                writer.Line($"{objAdditionalProperties.Type} {dictionaryVariable:D} = new {objAdditionalProperties.Type}();");
            }
            else if (serialization.ObjectType is not null && serialization.ObjectType.HasRawDataInHeirarchy)
            {
                writer.Line($"{Parameter.RawData.Type} rawData = new {Parameter.RawData.Type}();");
            }

            var itemVariable = new CodeWriterDeclaration("property");
            using (writer.Scope($"foreach (var {itemVariable:D} in element.EnumerateObject())"))
            {
                writer.DeserializeIntoObjectProperties(serialization.Properties, $"{itemVariable:I}", propertyVariables, Configuration.ModelsToTreatEmptyStringAsNull.Contains(serialization.Type.Name));

                if (objAdditionalProperties?.ValueSerialization != null)
                {
                    var variableOrExpression = writer.DeserializeValue(objAdditionalProperties.ValueSerialization, $"{itemVariable}.Value");
                    writer.Line($"{dictionaryVariable}.Add({itemVariable}.Name, {variableOrExpression});");
                }
                else if (serialization.ObjectType is not null && serialization.ObjectType.HasRawDataInHeirarchy)
                {
                    // add raw data TODO consolidate with additionalProperties
                    using (writer.Scope($"if ({IsFormatJson})"))
                    {
                        writer.Line($"rawData.Add({itemVariable}.Name, {typeof(BinaryData)}.{nameof(BinaryData.FromString)}({itemVariable}.Value.{nameof(JsonElement.GetRawText)}()));");
                        writer.Line($"continue;");
                    }
                }
            }

            if (objAdditionalProperties != null)
            {
                writer.Line($"{propertyVariables[objAdditionalProperties].Declaration} = {dictionaryVariable};");
            }

            var parameterValues = propertyVariables.ToDictionary(v => v.Key.ParameterName, v => GetOptionalFormattable(v.Key, v.Value));
            var parameters = serialization.Constructor.Parameters
                .Select(p => parameterValues[p.Name])
                .ToArray();

            var typeToReturn = serialization.Discriminator is not null && serialization.Discriminator.HasDescendants ? serialization.Discriminator.DefaultObjectType.Type : serialization.Type;
            writer.Append($"return new {typeToReturn}({parameters.Join(", ")}");
            if (objAdditionalProperties is null && serialization.ObjectType is not null && serialization.ObjectType.HasRawDataInHeirarchy)
            {
                if (parameters.Length > 0)
                    writer.Append($", ");

                writer.Append($"rawData");
            }
            writer.Append($");");
        }

        private static FormattableString GetDeserializeValueFormattable(JsonValueSerialization serialization, FormattableString element)
            => GetDeserializeValueFormattable(element, serialization.Type, serialization.Format, serialization.Options);

        public static FormattableString GetDeserializeValueFormattable(FormattableString element, CSharpType serializationType, SerializationFormat serializationFormat = SerializationFormat.Default, JsonSerializationOptions serializationOptions = JsonSerializationOptions.None)
        {
            if (serializationType.SerializeAs != null)
            {
                return $"({serializationType}){GetFrameworkTypeValueFormattable(serializationType.SerializeAs, element, serializationFormat, serializationType)}";
            }

            if (serializationType.IsFrameworkType)
            {
                var frameworkType = serializationType.FrameworkType;
                if (frameworkType == typeof(Nullable<>))
                {
                    frameworkType = serializationType.Arguments[0].FrameworkType;
                }

                return GetFrameworkTypeValueFormattable(frameworkType, element, serializationFormat, serializationType);
            }

            return GetDeserializeImplementationFormattable(serializationType.Implementation, element, serializationOptions);
        }

        public static FormattableString GetFrameworkTypeValueFormattable(Type frameworkType, FormattableString element, SerializationFormat format, CSharpType? serializationType)
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
                return $"new {frameworkType}({element}.GetString())";
            }

            if (frameworkType == typeof(IPAddress))
            {
                return $"{frameworkType}.Parse({element}.GetString())";
            }

            var methodName = string.Empty;
            if (frameworkType == typeof(BinaryData))
            {
                switch (format)
                {
                    case SerializationFormat.Bytes_Base64: //intentional fall through
                    case SerializationFormat.Bytes_Base64Url:
                        return $"{typeof(BinaryData)}.FromBytes({element}.GetBytesFromBase64(\"{format.ToFormatSpecifier()}\"))";
                    default:
                        return $"{typeof(BinaryData)}.FromString({element}.GetRawText())";
                }
            }

            if (frameworkType == typeof(TimeSpan))
            {
                if (format == SerializationFormat.Duration_Seconds)
                {
                    return $"{typeof(TimeSpan)}.FromSeconds({element}.GetInt32())";
                }
                else if (format == SerializationFormat.Duration_Seconds_Float)
                {
                    return $"{typeof(TimeSpan)}.FromSeconds({element}.GetDouble())";
                }
            }

            if (frameworkType == typeof(DateTimeOffset))
            {
                if (format == SerializationFormat.DateTime_Unix)
                {
                    return $"{typeof(DateTimeOffset)}.FromUnixTimeSeconds({element}.GetInt64())";
                }
            }

            if (IsCustomJsonConverterAdded(frameworkType))
            {
                return $"{typeof(JsonSerializer)}.{nameof(JsonSerializer.Deserialize)}<{serializationType}>({element}.GetRawText())";
            }

            if (frameworkType == typeof(JsonElement))
                methodName = "Clone";
            if (frameworkType == typeof(object))
                methodName = "GetObject";
            if (frameworkType == typeof(bool))
                methodName = "GetBoolean";
            if (frameworkType == typeof(char))
                methodName = "GetChar";
            if (frameworkType == typeof(short))
                methodName = "GetInt16";
            if (frameworkType == typeof(int))
                methodName = "GetInt32";
            if (frameworkType == typeof(long))
                methodName = "GetInt64";
            if (frameworkType == typeof(float))
                methodName = "GetSingle";
            if (frameworkType == typeof(double))
                methodName = "GetDouble";
            if (frameworkType == typeof(decimal))
                methodName = "GetDecimal";
            if (frameworkType == typeof(string))
                methodName = "GetString";
            if (frameworkType == typeof(Guid))
                methodName = "GetGuid";

            if (frameworkType == typeof(byte[]))
            {
                methodName = "GetBytesFromBase64";
                includeFormat = true;
            }

            if (frameworkType == typeof(DateTimeOffset))
            {
                methodName = "GetDateTimeOffset";
                includeFormat = true;
            }

            if (frameworkType == typeof(DateTime))
            {
                methodName = "GetDateTime";
                includeFormat = true;
            }

            if (frameworkType == typeof(TimeSpan))
            {
                methodName = "GetTimeSpan";
                includeFormat = true;
            }

            if (includeFormat && format.ToFormatSpecifier() is { } formatString)
            {
                return $"{element}.{methodName}({formatString:L})";
            }

            return $"{element}.{methodName}()";
        }

        public static FormattableString GetDeserializeImplementationFormattable(TypeProvider implementation, FormattableString element, JsonSerializationOptions options)
        {
            switch (implementation)
            {
                case SystemObjectType systemObjectType when IsCustomJsonConverterAdded(systemObjectType.SystemType):
                    var optionalSerializeOptions = options == JsonSerializationOptions.UseManagedServiceIdentityV3 ? ", serializeOptions" : string.Empty;
                    return $"{typeof(JsonSerializer)}.{nameof(JsonSerializer.Deserialize)}<{implementation.Type}>({element}.GetRawText(){optionalSerializeOptions})";

                case Resource { ResourceData: SerializableObjectType { JsonSerialization: { } } resourceDataType } resource:
                    return $"new {resource.Type}(Client, {resourceDataType.Type}.Deserialize{resourceDataType.Declaration.Name}({element}))";

                case MgmtObjectType mgmtObjectType when TypeReferenceTypeChooser.HasMatch(mgmtObjectType.ObjectSchema):
                    return $"{typeof(JsonSerializer)}.{nameof(JsonSerializer.Deserialize)}<{implementation.Type}>({element}.GetRawText())";

                case SerializableObjectType { JsonSerialization: { } } type:
                    return $"{type.Type}.Deserialize{type.Declaration.Name}({element})";

                case EnumType clientEnum:
                    var value = GetFrameworkTypeValueFormattable(clientEnum.ValueType.FrameworkType, element, SerializationFormat.Default, null);
                    return clientEnum.IsExtensible
                        ? $"new {clientEnum.Type}({value})"
                        : (FormattableString)$"{value}.To{clientEnum.Type:D}()";

                default:
                    throw new NotSupportedException($"No deserialization logic exists for {implementation.Declaration.Name}");
            }
        }

        private static bool IsCustomJsonConverterAdded(Type type)
        {
            return type.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonConverterAttribute));
        }

        public static string? ToFormatSpecifier(this SerializationFormat format) => format switch
        {
            SerializationFormat.DateTime_RFC1123 => "R",
            SerializationFormat.DateTime_RFC3339 => "O",
            SerializationFormat.DateTime_RFC7231 => "R",
            SerializationFormat.DateTime_ISO8601 => "O",
            SerializationFormat.Date_ISO8601 => "D",
            SerializationFormat.DateTime_Unix => "U",
            SerializationFormat.Bytes_Base64Url => "U",
            SerializationFormat.Bytes_Base64 => "D",
            SerializationFormat.Duration_ISO8601 => "P",
            SerializationFormat.Duration_Constant => "c",
            SerializationFormat.Duration_Seconds => "%s",
            SerializationFormat.Duration_Seconds_Float => "s\\.fff",
            SerializationFormat.Time_ISO8601 => "T",
            _ => null
        };

        public static void WriteDeserializationForMethods(this CodeWriter writer, JsonSerialization serialization, bool async, CodeWriterDeclaration? variable, FormattableString response, bool isBinaryData)
        {
            if (isBinaryData)
            {
                var expression = async
                    ? (FormattableString)$"await {typeof(BinaryData)}.FromStreamAsync({response}.ContentStream).ConfigureAwait(false)"
                    : (FormattableString)$"{typeof(BinaryData)}.FromStream({response}.ContentStream)";

                writer.Line(variable is not null ? (FormattableString)$"{variable} = {expression};" : $"return {expression};");
            }
            else
            {
                var documentVariable = new CodeWriterDeclaration("document");
                writer.Append($"using var {documentVariable:D} = ");
                if (async)
                {
                    writer.Line($"await {typeof(JsonDocument)}.ParseAsync({response}.ContentStream, default, cancellationToken).ConfigureAwait(false);");
                }
                else
                {
                    writer.Line($"{typeof(JsonDocument)}.Parse({response}.ContentStream);");
                }

                if (serialization.IsNullable)
                {
                    using (writer.Scope($"if ({documentVariable}.RootElement.ValueKind == {typeof(JsonValueKind)}.Null)"))
                    {
                        writer.Line(variable is not null ? (FormattableString)$"{variable} = null;" : $"return null;");
                    }
                    using (writer.Scope($"else"))
                    {
                        var x = writer.DeserializeValue(serialization, $"{documentVariable}.RootElement");
                        writer.Line(variable is not null ? (FormattableString)$"{variable} = {x};" : $"return {x};");
                    }
                }
                else
                {
                    var x = writer.DeserializeValue(serialization, $"{documentVariable}.RootElement");
                    writer.Line(variable is not null ? (FormattableString)$"{variable} = {x};" : $"return {x};");
                }
            }
        }

        private readonly struct ObjectPropertyVariable
        {
            public ObjectPropertyVariable(CodeWriterDeclaration declaration, CSharpType type)
            {
                Declaration = declaration;
                Type = type;
            }

            public CodeWriterDeclaration Declaration { get; }
            public CSharpType Type { get; }
        }
    }
}
