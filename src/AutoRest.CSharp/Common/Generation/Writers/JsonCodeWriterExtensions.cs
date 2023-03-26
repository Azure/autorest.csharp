// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using JsonElementExtensions = Azure.Core.JsonElementExtensions;
using Configuration = AutoRest.CSharp.Input.Configuration;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class JsonCodeWriterExtensions
    {
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
