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
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.Core.Expressions.DataFactory;
using Azure.ResourceManager.Models;
using JsonElementExtensions = Azure.Core.JsonElementExtensions;
using Configuration = AutoRest.CSharp.Input.Configuration;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class JsonCodeWriterExtensions
    {
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

                        if (frameworkType != typeof(BinaryData) && frameworkType != typeof(DataFactoryExpression<>))
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
                                 frameworkType == typeof(Azure.Core.RequestMethod) ||
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
                            if (valueSerialization.Format == SerializationFormat.DateTime_Unix)
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
                            frameworkType == typeof(IPAddress))
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
                            writer.Line($"#if NET6_0_OR_GREATER");
                            writer.Line($"\t\t\t\t{writerName}.WriteRawValue({name:I});");
                            writer.Line($"#else");
                            writer.Line($"{typeof(JsonSerializer)}.{nameof(JsonSerializer.Serialize)}({writerName}, {typeof(JsonDocument)}.Parse({name:I}.ToString()).RootElement);");
                            writer.Line($"#endif");
                            return;
                        }
                        else if (IsCustomJsonConverterAdded(frameworkType))
                        {
                            writer.Line($"{typeof(JsonSerializer)}.{nameof(JsonSerializer.Serialize)}(writer, {name:I});");
                            return;
                        }

                        writer.Append($"({name:I}")
                            .AppendNullableValue(valueSerialization.Type);

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

                        case EnumType clientEnum when clientEnum is { IsIntValueType: true, IsExtensible: false }:
                            writer
                                .Append($"{writerName}.WriteNumberValue(({clientEnum.ValueType}){name:I}")
                                .AppendNullableValue(valueSerialization.Type)
                                .Line($");");
                            return;
                        case EnumType clientEnum:
                            writer
                                .Append($"{writerName}.WriteStringValue({name:I}");
                            writer
                                .AppendNullableValue(valueSerialization.Type)
                                .AppendEnumToString(clientEnum)
                                .Line($");");
                            return;
                    }

                    throw new NotSupportedException();

                default:
                    throw new NotSupportedException();
            }
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

                        if (property.OptionalViaNullability && propertyType.IsNullable && propertyType.IsValueType)
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

        private static void DeserializeIntoObjectProperties(this CodeWriter writer, IEnumerable<JsonPropertySerialization> propertySerializations, CodeWriterDeclaration itemVariable, Dictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, bool shouldTreatEmptyStringAsNull)
        {
            foreach (JsonPropertySerialization property in propertySerializations.Where(p => !p.ShouldSkipDeserialization))
            {
                writer.Append($"if({itemVariable}.NameEquals({property.SerializedName:L}u8))");
                using (writer.Scope())
                {
                    if (property.ValueType?.IsNullable == true)
                    {
                        var emptyStringCheck = GetEmptyStringCheckClause(property, itemVariable, shouldTreatEmptyStringAsNull);
                        using (writer.Scope($"if ({itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null{emptyStringCheck})"))
                        {
                            writer.Line($"{propertyVariables[property].Declaration} = null;");
                            writer.Append($"continue;");
                        }
                    }
                    else if (!property.IsRequired &&
                             property.ValueType?.Equals(typeof(JsonElement)) != true && // JsonElement handles nulls internally
                             property.ValueType?.Equals(typeof(string)) !=
                             true) //https://github.com/Azure/autorest.csharp/issues/922
                    {
                        var emptyStringCheck = GetEmptyStringCheckClause(property, itemVariable, shouldTreatEmptyStringAsNull);
                        if (Configuration.AzureArm && property.ValueType?.Equals(typeof(Uri)) == true)
                        {
                            using (writer.Scope($"if ({itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null{emptyStringCheck})"))
                            {
                                writer.Line($"{propertyVariables[property].Declaration} = null;");
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

                    if (property.ValueSerialization is not null)
                    {
                        // Reading a property value
                        writer.WriteBodyBlock(JsonSerializationMethodsBuilder.DeserializeValue(property.ValueSerialization, new MemberReference(itemVariable, "Value"), out var value));
                        writer.WriteLine(new SetValueLine(propertyVariables[property].Declaration, value));
                    }
                    else if (property.PropertySerializations is not null)
                    {
                        // Reading a nested object
                        var nestedItemVariable = new CodeWriterDeclaration("property");
                        using (writer.Scope($"foreach (var {nestedItemVariable:D} in {itemVariable:I}.Value.EnumerateObject())"))
                        {
                            writer.DeserializeIntoObjectProperties(property.PropertySerializations, nestedItemVariable, propertyVariables, shouldTreatEmptyStringAsNull);
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

        private static FormattableString GetEmptyStringCheckClause(JsonPropertySerialization property, CodeWriterDeclaration itemVariable, bool shouldTreatEmptyStringAsNull)
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

        public static bool CollectionItemRequiresNullCheckInSerialization(JsonSerialization serialization) =>
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

            var itemVariable = new CodeWriterDeclaration("property");
            using (writer.Scope($"foreach (var {itemVariable:D} in element.EnumerateObject())"))
            {
                writer.DeserializeIntoObjectProperties(serialization.Properties, itemVariable, propertyVariables, Configuration.ModelsToTreatEmptyStringAsNull.Contains(serialization.Type.Name));

                if (objAdditionalProperties?.ValueSerialization != null)
                {
                    var key = new MemberReference(itemVariable, "Name");
                    writer.WriteBodyBlock(JsonSerializationMethodsBuilder.DeserializeValue(objAdditionalProperties.ValueSerialization, new MemberReference(itemVariable, "Value"), out var value));
                    writer.WriteLine(MethodBodyLines.LineCall.Dictionary.Add(dictionaryVariable, key, value));
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

            writer.Append($"return new {serialization.Type}({parameters.Join(", ")});");
        }

        private static bool IsCustomJsonConverterAdded(Type type)
        {
            return type.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonConverterAttribute));
        }

        public static string? ToFormatSpecifier(this SerializationFormat format) => format switch
        {
            SerializationFormat.DateTime_RFC1123 => "R",
            SerializationFormat.DateTime_ISO8601 => "O",
            SerializationFormat.Date_ISO8601 => "D",
            SerializationFormat.DateTime_Unix => "U",
            SerializationFormat.Bytes_Base64Url => "U",
            SerializationFormat.Bytes_Base64 => "D",
            SerializationFormat.Duration_ISO8601 => "P",
            SerializationFormat.Duration_Constant => "c",
            SerializationFormat.Time_ISO8601 => "T",
            _ => null
        };

        public static void WriteDeserializationForMethods(this CodeWriter writer, JsonSerialization serialization, bool async, CodeWriterDeclaration? variable, FormattableString response, bool isBinaryData)
            => writer.WriteBodyBlock(JsonSerializationMethodsBuilder.BuildDeserializationForMethods(serialization, async, variable, new FormattableStringToExpression(response), isBinaryData));

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
