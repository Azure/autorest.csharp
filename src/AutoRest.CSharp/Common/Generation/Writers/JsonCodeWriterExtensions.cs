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
                    writer.Line($"{writerName}.WriteStartArray();");
                    var collectionItemVariable = new CodeWriterDeclaration("item");

                    using (writer.Scope($"foreach (var {collectionItemVariable:D} in {name:I})"))
                    {
                        writer.ToSerializeCall(
                            array.ValueSerialization,
                            $"{collectionItemVariable:I}",
                            writerName);
                    }

                    writer.Line($"{writerName}.WriteEndArray();");
                    return;

                case JsonDictionarySerialization dictionary:
                    writer.Line($"{writerName}.WriteStartObject();");
                    var dictionaryItemVariable = new CodeWriterDeclaration("item");

                    using (writer.Scope($"foreach (var {dictionaryItemVariable:D} in {name:I})"))
                    {
                        writer.Line($"{writerName}.WritePropertyName({dictionaryItemVariable:I}.Key);");
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
                                writer.Line($"var serializeOptions = new {typeof(JsonSerializerOptions)} {{ Converters = {{ new {typeof(ManagedServiceIdentityTypeV3Converter)}() }} }};");
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
                    writer.Line($"{writerName}.WritePropertyName({property.SerializedName:L});");
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

                        writer.Line($"{writerName}.WritePropertyName({property.SerializedName:L});");

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

        private static void DeserializeIntoObjectProperties(this CodeWriter writer, IEnumerable<JsonPropertySerialization> propertySerializations, FormattableString itemVariable, Dictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables)
        {
            foreach (JsonPropertySerialization property in propertySerializations)
            {
                writer.Append($"if({itemVariable}.NameEquals({property.SerializedName:L}))");
                using (writer.Scope())
                {
                    if (property.ValueType?.IsNullable == true)
                    {
                        using (writer.Scope($"if ({itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null)"))
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
                        if (Configuration.AzureArm && property.ValueType?.Equals(typeof(Uri)) == true)
                        {
                            using (writer.Scope($"if ({itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null)"))
                            {
                                writer.Line($"{propertyVariables[property].Declaration} = null;");
                                writer.Append($"continue;");
                            }
                        }
                        else
                        {
                            using (writer.Scope($"if ({itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null)"))
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
                        writer.DeserializeIntoVariable(property.ValueSerialization, v => writer.Line($"{propertyVariables[property].Declaration} = {v};"), $"{itemVariable}.Value");
                    }
                    else if (property.PropertySerializations is not null)
                    {
                        // Reading a nested object
                        var nestedItemVariable = new CodeWriterDeclaration("property");
                        using (writer.Scope($"foreach (var {nestedItemVariable:D} in {itemVariable:I}.Value.EnumerateObject())"))
                        {
                            writer.DeserializeIntoObjectProperties(property.PropertySerializations, $"{nestedItemVariable:I}", propertyVariables);
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
        private static void CollectProperties(Dictionary<JsonPropertySerialization, ObjectPropertyVariable> propertyVariables, IEnumerable<JsonPropertySerialization> jsonProperties)
        {
            foreach (JsonPropertySerialization jsonProperty in jsonProperties)
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
                    CollectProperties(propertyVariables, jsonProperty.PropertySerializations);
                }
            }
        }

        private static void DeserializeIntoVariable(this CodeWriter writer, JsonSerialization serialization, Action<FormattableString> valueCallback, FormattableString element)
        {
            switch (serialization)
            {
                case JsonArraySerialization array:
                    var arrayVariable = new CodeWriterDeclaration("array");
                    writer.Line($"{array.ImplementationType} {arrayVariable:D} = new {array.ImplementationType}();");

                    var collectionItemVariable = new CodeWriterDeclaration("item");
                    using (writer.Scope($"foreach (var {collectionItemVariable:D} in {element}.EnumerateArray())"))
                    {
                        writer.DeserializeValue(array.ValueSerialization, $"{collectionItemVariable}", value => writer.Append($"{arrayVariable}.Add({value});"));
                    }

                    valueCallback($"{arrayVariable:I}");
                    return;
                case JsonDictionarySerialization dictionary:
                    var dictionaryVariable = new CodeWriterDeclaration("dictionary");
                    writer.Line($"{dictionary.Type} {dictionaryVariable:D} = new {dictionary.Type}();");

                    var dictionaryItemVariable = new CodeWriterDeclaration("property");
                    using (writer.Scope($"foreach (var {dictionaryItemVariable:D} in {element}.EnumerateObject())"))
                    {
                        writer.DeserializeValue(dictionary.ValueSerialization, $"{dictionaryItemVariable}.Value", value => writer.Append($"{dictionaryVariable}.Add({dictionaryItemVariable}.Name, {value});"));
                    }

                    valueCallback($"{dictionaryVariable:I}");
                    return;
                case JsonValueSerialization valueSerialization:
                    if (valueSerialization.Options == JsonSerializationOptions.UseManagedServiceIdentityV3)
                    {
                        writer.Line($"var serializeOptions = new {typeof(JsonSerializerOptions)} {{ Converters = {{ new {typeof(ManagedServiceIdentityTypeV3Converter)}() }} }};");
                    }

                    writer.UseNamespace(typeof(JsonElementExtensions).Namespace!);
                    valueCallback(GetDeserializeValueFormattable(valueSerialization, element));
                    return;
            }
        }

        public static void DeserializeValue(this CodeWriter writer, JsonSerialization serialization, FormattableString value, Action<FormattableString> valueCallback)
        {
            if (serialization.IsNullable)
            {
                using (writer.Scope($"if ({value}.ValueKind == {typeof(JsonValueKind)}.Null)"))
                {
                    valueCallback($"null");
                }
                using (writer.Scope($"else"))
                {
                    writer.DeserializeIntoVariable(serialization, valueCallback, value);
                }
            }
            else
            {
                writer.DeserializeIntoVariable(serialization, valueCallback, value);
            }
        }

        public static void WriteObjectInitialization(this CodeWriter writer, JsonObjectSerialization serialization)
        {
            // this is the first level of object hierarchy
            // collect all properties and initialize the dictionary
            var propertyVariables = new Dictionary<JsonPropertySerialization, ObjectPropertyVariable>();

            CollectProperties(propertyVariables, serialization.Properties);

            var additionalProperties = serialization.AdditionalProperties;
            if (additionalProperties != null)
            {
                var propertyDeclaration = new CodeWriterDeclaration(additionalProperties.PropertyName.ToVariableName());
                propertyVariables.Add(additionalProperties, new ObjectPropertyVariable(propertyDeclaration, additionalProperties.PropertyType));
            }

            bool isThisTheDefaultDerivedType = serialization.Type.Equals(serialization.Discriminator?.DefaultObjectType.Type);

            foreach (var variable in propertyVariables)
            {
                string defaultValue ="default";
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
                writer.DeserializeIntoObjectProperties(serialization.Properties, $"{itemVariable:I}", propertyVariables);

                if (objAdditionalProperties?.ValueSerialization != null)
                {
                    writer.DeserializeValue(objAdditionalProperties.ValueSerialization, $"{itemVariable}.Value", v => writer.Line($"{dictionaryVariable}.Add({itemVariable}.Name, {v});"));
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

            if (frameworkType == typeof(BinaryData))
            {
                return $"{typeof(BinaryData)}.FromString({element}.GetRawText())";
            }

            if (IsCustomJsonConverterAdded(frameworkType))
            {
                return $"{typeof(JsonSerializer)}.{nameof(JsonSerializer.Deserialize)}<{serializationType}>({element}.GetRawText())";
            }

            var methodName = string.Empty;
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

                case Resource { ResourceData: SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } resourceDataType } resource:
                    return $"new {resource.Type}(Client, {resourceDataType.Type}.Deserialize{resourceDataType.Declaration.Name}({element}))";

                case MgmtObjectType mgmtObjectType when TypeReferenceTypeChooser.HasMatch(mgmtObjectType.ObjectSchema):
                    return $"{typeof(JsonSerializer)}.{nameof(JsonSerializer.Deserialize)}<{implementation.Type}>({element}.GetRawText())";

                case SerializableObjectType { JsonSerialization: { }, IncludeDeserializer: true } type:
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

        public static void WriteDeserializationForMethods(this CodeWriter writer, JsonSerialization serialization, bool async, Action<FormattableString> callback, string response, bool isBinaryData)
        {
            if (isBinaryData)
            {
                if (async)
                {
                    callback($"await {typeof(BinaryData)}.FromStreamAsync({response}.ContentStream).ConfigureAwait(false)");
                }
                else
                {
                    callback($"{typeof(BinaryData)}.FromStream({response}.ContentStream)");
                }
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

                writer.DeserializeValue(serialization, $"{documentVariable}.RootElement", callback);
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
