// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;
using Azure.ResourceManager.Models;
using JsonElementExtensions = Azure.Core.JsonElementExtensions;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class JsonCodeWriterExtensions
    {
        public static void ToSerializeCall(this CodeWriter writer, JsonSerialization serialization, FormattableString name, FormattableString? writerName = null)
        {
            writerName ??= $"writer";

            switch (serialization)
            {
                case JsonArraySerialization array:
                    writer.Line($"{writerName}.WriteStartArray();");
                    var collectionItemVariable = new CodeWriterDeclaration("item");

                    using (writer.Scope($"foreach (var {collectionItemVariable:D} in {name})"))
                    {
                        writer.ToSerializeCall(
                            array.ValueSerialization,
                            $"{collectionItemVariable}",
                            writerName);
                    }

                    writer.Line($"{writerName}.WriteEndArray();");
                    return;

                case JsonDictionarySerialization dictionary:
                    writer.Line($"{writerName}.WriteStartObject();");
                    var dictionaryItemVariable = new CodeWriterDeclaration("item");

                    using (writer.Scope($"foreach (var {dictionaryItemVariable:D} in {name})"))
                    {
                        writer.Line($"{writerName}.WritePropertyName({dictionaryItemVariable}.Key);");
                        writer.ToSerializeCall(
                            dictionary.ValueSerialization,
                            $"{dictionaryItemVariable}.Value",
                            writerName);
                    }

                    writer.Line($"{writerName}.WriteEndObject();");
                    return;

                case JsonObjectSerialization obj:
                    writer.Line($"{writerName}.WriteStartObject();");

                    foreach (JsonPropertySerialization property in obj.Properties)
                    {
                        if (property.IsReadOnly)
                        {
                            continue;
                        }

                        var objectProperty = property.Property;
                        if (objectProperty == null)
                        {
                            // Flattened property
                            writer.Line($"{writerName}.WritePropertyName({property.Name:L});");
                            writer.ToSerializeCall(property.ValueSerialization, $"");
                            continue;
                        }

                        using (writer.WriteDefinedCheck(objectProperty))
                        {
                            var ifScope = writer.WritePropertyNullCheckIf(objectProperty);
                            using (ifScope)
                            {
                                var propertyType = objectProperty.Declaration.Type;
                                var declarationName = objectProperty.Declaration.Name;

                                writer.Line($"{writerName}.WritePropertyName({property.Name:L});");

                                if (objectProperty.OptionalViaNullability && propertyType.IsNullable && propertyType.IsValueType)
                                {
                                    writer.ToSerializeCall(property.ValueSerialization, $"{declarationName}.Value");
                                }
                                else
                                {
                                    writer.ToSerializeCall(property.ValueSerialization, $"{declarationName}");
                                }
                            }
                            if (ifScope != null)
                            {
                                using (writer.Scope($"else"))
                                {
                                    writer.Line($"{writerName}.WriteNull({property.Name:L});");
                                }
                            }
                        }
                    }

                    if (obj.AdditionalProperties != null)
                    {
                        var itemVariable = new CodeWriterDeclaration("item");

                        using (writer.Scope($"foreach (var {itemVariable:D} in {obj.AdditionalProperties.Property.Declaration.Name})"))
                        {
                            writer.Line($"{writerName}.WritePropertyName({itemVariable}.Key);");
                            writer.ToSerializeCall(
                                obj.AdditionalProperties.ValueSerialization,
                                $"{itemVariable}.Value",
                                writerName);
                        }
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
                            writer.Line($"{name}.WriteTo({writerName});");
                            return;
                        }

                        if (frameworkType == typeof(Nullable<>))
                        {
                            frameworkType = valueSerialization.Type.Arguments[0].FrameworkType;
                        }
                        bool writeFormat = false;

                        if (frameworkType != typeof(BinaryData))
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
                        else if (frameworkType == typeof(ETag) || frameworkType == typeof(IPAddress))
                        {
                            writer.Line($"WriteStringValue({name}.ToString());");
                            return;
                        }
                        else if (frameworkType == typeof(Uri))
                        {
                            writer.Line($"WriteStringValue({name}.{nameof(Uri.AbsoluteUri)});");
                            return;
                        }
                        else if (frameworkType == typeof(BinaryData))
                        {
                            writer.Line($"#if NET6_0_OR_GREATER");
                            writer.Line($"\t\t\t\t{writerName}.WriteRawValue({name});");
                            writer.Line($"#else");
                            writer.Line($"{typeof(JsonSerializer)}.Serialize({writerName}, {typeof(JsonDocument)}.Parse({name}.ToString()).RootElement);");
                            writer.Line($"#endif");
                            return;
                        }

                        writer.Append($"({name}")
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
                        case ObjectType objectType:
                            {
                                var systemObjectType = objectType as SystemObjectType;
                                if (systemObjectType != null && IsCustomJsonConverterAdded(systemObjectType))
                                {
                                    var optionalSerializeOptions = string.Empty;
                                    if (valueSerialization.Options == JsonSerializationOptions.UseManagedServiceIdentityV3)
                                    {
                                        writer.UseNamespace("Azure.ResourceManager.Models");
                                        writer.Line($"var serializeOptions = new JsonSerializerOptions {{ Converters = {{ new {nameof(ManagedServiceIdentityTypeV3Converter)}() }} }};");
                                        optionalSerializeOptions = ", serializeOptions";
                                    }
                                    writer.Append($"JsonSerializer.Serialize(writer, {name}{optionalSerializeOptions});");
                                }
                                else
                                {
                                    writer.Line($"{writerName}.WriteObjectValue({name});");
                                }
                                return;
                            }

                        case EnumType clientEnum:
                            writer.Append($"{writerName}.WriteStringValue({name}")
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

        private static void DeserializeIntoVariableMayBeObject(this CodeWriter writer,
            JsonSerialization serialization,
            Action<CodeWriterDelegate> valueCallback,
            FormattableString element,
            Dictionary<ObjectTypeProperty, ObjectPropertyVariable>? propertyVariables = null)
        {
            if (serialization is JsonObjectSerialization obj)
            {
                var itemVariable = new CodeWriterDeclaration("property");

                if (propertyVariables == null)
                {
                    // this is the first level of object hierarchy
                    // collect all properties and initialize the dictionary
                    propertyVariables = new Dictionary<ObjectTypeProperty, ObjectPropertyVariable>();

                    CollectProperties(propertyVariables, obj);

                    foreach (var variable in propertyVariables)
                    {
                        writer.Line($"{variable.Value.Type} {variable.Value.Declaration:D} = default;");
                    }
                }

                var dictionaryVariable = new CodeWriterDeclaration("additionalPropertiesDictionary");

                var objAdditionalProperties = obj.AdditionalProperties;
                if (objAdditionalProperties != null)
                {
                    writer.Line($"{objAdditionalProperties.Type} {dictionaryVariable:D} = new {objAdditionalProperties.Type}();");
                }

                using (writer.Scope($"foreach (var {itemVariable:D} in {element}.EnumerateObject())"))
                {
                    foreach (JsonPropertySerialization property in obj.Properties)
                    {
                        writer.Append($"if({itemVariable}.NameEquals({property.Name:L}))");
                        using (writer.Scope())
                        {
                            if (property.ValueSerialization.IsNullable)
                            {
                                using (writer.Scope($"if ({itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null)"))
                                {
                                    writer.Line($"{propertyVariables[property.Property!].Declaration} = null;");
                                    writer.Append($"continue;");
                                }
                            }
                            else if (!property.IsRequired &&
                                     property.Property?.ValueType.Equals(typeof(JsonElement)) != true && // JsonElement handles nulls internally
                                     property.Property?.ValueType.Equals(typeof(string)) != true) //https://github.com/Azure/autorest.csharp/issues/922
                            {
                                if (Configuration.AzureArm && property.Property?.ValueType.Equals(typeof(Uri)) == true)
                                {
                                    using (writer.Scope($"if ({itemVariable}.Value.ValueKind == {typeof(JsonValueKind)}.Null)"))
                                    {
                                        writer.Line($"{propertyVariables[property.Property!].Declaration} = null;");
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

                            if (property.Property != null)
                            {
                                // Reading a property value
                                writer.DeserializeIntoVariable(
                                    property.ValueSerialization,
                                    v => writer.Line($"{propertyVariables[property.Property].Declaration} = {v};"),
                                    $"{itemVariable}.Value");
                            }
                            else
                            {
                                // Reading a nested object
                                writer.DeserializeIntoVariableMayBeObject(
                                    property.ValueSerialization,
                                    v => { },
                                    $"{itemVariable}.Value",
                                    propertyVariables);
                            }

                            writer.Line($"continue;");
                        }
                    }

                    if (objAdditionalProperties != null)
                    {
                        writer.DeserializeValue(objAdditionalProperties.ValueSerialization, $"{itemVariable}.Value", v => writer.Line($"{dictionaryVariable}.Add({itemVariable}.Name, {v});"));
                    }
                }

                if (objAdditionalProperties != null)
                {
                    writer.Line($"{propertyVariables[objAdditionalProperties.Property].Declaration} = {dictionaryVariable};");
                }

                if (obj.Type != null)
                {
                    var objectType = (ObjectType)obj.Type.Implementation;

                    var initializers = new List<PropertyInitializer>();
                    foreach (var variable in propertyVariables)
                    {
                        initializers.Add(new PropertyInitializer(variable.Key, GetOptionalFormattable(variable.Key, variable.Value)));
                    }

                    writer.WriteInitialization(valueCallback, objectType, objectType.SerializationConstructor, initializers);
                }
            }
            else
            {
                writer.DeserializeIntoVariableWithNullHandling(serialization, valueCallback, element);
            }
        }

        private static FormattableString GetOptionalFormattable(ObjectTypeProperty target, ObjectPropertyVariable variable)
        {
            var targetType = target.Declaration.Type;
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
        private static void CollectProperties(Dictionary<ObjectTypeProperty, ObjectPropertyVariable> propertyVariables, JsonObjectSerialization obj)
        {
            foreach (JsonPropertySerialization jsonProperty in obj.Properties)
            {
                ObjectTypeProperty? objectProperty = jsonProperty.Property;

                if (objectProperty != null)
                {
                    var propertyDeclaration = new CodeWriterDeclaration(jsonProperty.Name.ToVariableName());

                    var type = objectProperty.ValueType;
                    if (!jsonProperty.IsRequired)
                    {
                        if (type.IsFrameworkType && type.FrameworkType == typeof(Nullable<>))
                            type = new CSharpType(type.Arguments[0].FrameworkType);
                        type = new CSharpType(typeof(Optional<>), type);
                    }

                    propertyVariables.Add(objectProperty, new ObjectPropertyVariable(propertyDeclaration, type));
                }
                else if (jsonProperty.ValueSerialization is JsonObjectSerialization objectSerialization)
                {
                    CollectProperties(propertyVariables, objectSerialization);
                }
            }

            var additionalPropertiesProperty = obj.AdditionalProperties?.Property;
            if (additionalPropertiesProperty != null)
            {
                var propertyDeclaration = new CodeWriterDeclaration(additionalPropertiesProperty.Declaration.Name.ToVariableName());
                propertyVariables.Add(additionalPropertiesProperty, new ObjectPropertyVariable(propertyDeclaration, additionalPropertiesProperty.Declaration.Type));
            }
        }

        private static void DeserializeIntoVariableWithNullHandling(this CodeWriter writer, JsonSerialization serialization, Action<CodeWriterDelegate> valueCallback, FormattableString element)
        {
            if (serialization.IsNullable)
            {
                using (writer.Scope($"if ({element}.ValueKind == {typeof(JsonValueKind)}.Null)"))
                {
                    valueCallback(w => w.Append($"null"));
                }
                using (writer.Scope($"else"))
                {
                    writer.DeserializeIntoVariable(serialization, valueCallback, element);
                }
            }
            else
            {
                writer.DeserializeIntoVariable(serialization, valueCallback, element);
            }
        }

        private static void DeserializeIntoVariable(this CodeWriter writer, JsonSerialization serialization, Action<CodeWriterDelegate> valueCallback, FormattableString element)
        {
            switch (serialization)
            {
                case JsonArraySerialization array:
                    var arrayVariable = new CodeWriterDeclaration("array");
                    writer.Line($"{array.ImplementationType} {arrayVariable:D} = new {array.ImplementationType}();");

                    var collectionItemVariable = new CodeWriterDeclaration("item");
                    using (writer.Scope($"foreach (var {collectionItemVariable:D} in {element}.EnumerateArray())"))
                    {
                        writer.DeserializeValue(
                            array.ValueSerialization,
                            $"{collectionItemVariable}",
                            returnValue => writer.Append($"{arrayVariable}.Add({returnValue});"));
                    }

                    valueCallback(w => w.Append(arrayVariable));
                    return;
                case JsonDictionarySerialization dictionary:
                    var dictionaryVariable = new CodeWriterDeclaration("dictionary");
                    writer.Line($"{dictionary.Type} {dictionaryVariable:D} = new {dictionary.Type}();");

                    var dictionaryItemVariable = new CodeWriterDeclaration("property");
                    using (writer.Scope($"foreach (var {dictionaryItemVariable:D} in {element}.EnumerateObject())"))
                    {
                        writer.DeserializeValue(
                            dictionary.ValueSerialization,
                            $"{dictionaryItemVariable}.Value",
                            (returnValue) => writer.Append($"{dictionaryVariable}.Add({dictionaryItemVariable}.Name, {returnValue});"));
                    }

                    valueCallback(w => w.Append(dictionaryVariable));
                    return;
                case JsonValueSerialization valueSerialization:
                    if (valueSerialization.Options == JsonSerializationOptions.UseManagedServiceIdentityV3)
                    {
                        writer.Line($"var serializeOptions = new JsonSerializerOptions {{ Converters = {{ new {nameof(ManagedServiceIdentityTypeV3Converter)}() }} }};");
                    }
                    valueCallback(w => w.DeserializeValue(valueSerialization, element));
                    return;
            }
        }

        public static void DeserializeValue(this CodeWriter writer, JsonSerialization serialization, FormattableString value, Action<CodeWriterDelegate> valueCallback)
            => writer.DeserializeIntoVariableMayBeObject(serialization, valueCallback, value);

        private static void DeserializeValue(this CodeWriter writer, JsonValueSerialization serialization, FormattableString element)
        {
            writer.UseNamespace(typeof(JsonElementExtensions).Namespace!);

            if (serialization.Type.SerializeAs != null)
            {
                writer.Append($"({serialization.Type}){GetFrameworkTypeValueFormattable(element, serialization.Type.SerializeAs, serialization.Format)}");
            }
            else if (serialization.Type.IsFrameworkType)
            {
                var frameworkType = serialization.Type.FrameworkType;
                if (frameworkType == typeof(Nullable<>))
                {
                    frameworkType = serialization.Type.Arguments[0].FrameworkType;
                }

                writer.Append(GetFrameworkTypeValueFormattable(element, frameworkType, serialization.Format));
            }
            else
            {
                writer.DeserializeImplementation(serialization.Type.Implementation, serialization, element);
            }
        }

        private static FormattableString GetFrameworkTypeValueFormattable(FormattableString element, Type frameworkType, SerializationFormat serializationFormat)
        {
            bool includeFormat = false;

            if (frameworkType == typeof(ETag) ||
                frameworkType == typeof(Uri) ||
                frameworkType == typeof(ResourceIdentifier) ||
                frameworkType == typeof(ResourceType) ||
                frameworkType == typeof(AzureLocation))
            {
                return $"new {frameworkType}({element}.GetString())";
            }

            if (frameworkType == typeof(IPAddress))
            {
                return $"{frameworkType}.Parse({element}.GetString())";
            }

            if (frameworkType == typeof(SystemData))
            {
                return $"JsonSerializer.Deserialize<{typeof(SystemData)}>({element}.ToString())";
            }

            if (frameworkType == typeof(BinaryData))
            {
                return $"{typeof(BinaryData)}.FromString({element}.GetRawText())";
            }

            var typeName = string.Empty;
            if (frameworkType == typeof(JsonElement))
                typeName = "Clone";
            if (frameworkType == typeof(object))
                typeName = "GetObject";
            if (frameworkType == typeof(bool))
                typeName = "GetBoolean";
            if (frameworkType == typeof(char))
                typeName = "GetChar";
            if (frameworkType == typeof(short))
                typeName = "GetInt16";
            if (frameworkType == typeof(int))
                typeName = "GetInt32";
            if (frameworkType == typeof(long))
                typeName = "GetInt64";
            if (frameworkType == typeof(float))
                typeName = "GetSingle";
            if (frameworkType == typeof(double))
                typeName = "GetDouble";
            if (frameworkType == typeof(decimal))
                typeName = "GetDecimal";
            if (frameworkType == typeof(string))
                typeName = "GetString";
            if (frameworkType == typeof(Guid))
                typeName = "GetGuid";

            if (frameworkType == typeof(byte[]))
            {
                typeName = "GetBytesFromBase64";
                includeFormat = true;
            }

            if (frameworkType == typeof(DateTimeOffset))
            {
                typeName = "GetDateTimeOffset";
                includeFormat = true;
            }

            if (frameworkType == typeof(DateTime))
            {
                typeName = "GetDateTime";
                includeFormat = true;
            }

            if (frameworkType == typeof(TimeSpan))
            {
                typeName = "GetTimeSpan";
                includeFormat = true;
            }

            if (includeFormat && serializationFormat.ToFormatSpecifier() is { } formatString)
            {
                return $"{element}.{typeName}({formatString:L})";
            }

            return $"{element}.{typeName}()";
        }

        private static bool IsCustomJsonConverterAdded(SystemObjectType systemObjectType)
        {
            return systemObjectType.GetCustomAttributes().Any(a => a.GetType() == typeof(JsonConverterAttribute));
        }

        public static void DeserializeImplementation(this CodeWriter writer, TypeProvider implementation, JsonSerialization serialization, FormattableString element)
        {
            switch (implementation)
            {
                case SystemObjectType systemObjectType when IsCustomJsonConverterAdded(systemObjectType):
                    var optionalSerializeOptions = (serialization.Options == JsonSerializationOptions.UseManagedServiceIdentityV3) ? ", serializeOptions" : string.Empty;
                    writer.Append($"JsonSerializer.Deserialize<{implementation.Type}>({element}.ToString(){optionalSerializeOptions})");
                    break;

                case MgmtObjectType mgmtObjectType when TypeReferenceTypeChooser.HasMatch(mgmtObjectType.ObjectSchema):
                    writer.Append($"JsonSerializer.Deserialize<{implementation.Type}>({element}.ToString())");
                    break;

                case ObjectType objectType:
                    writer.Append($"{implementation.Type}.Deserialize{objectType.Declaration.Name}({element})");
                    break;

                case EnumType clientEnum:
                    writer.AppendEnumFromString(clientEnum, GetFrameworkTypeValueFormattable(element, clientEnum.BaseType.FrameworkType, SerializationFormat.Default));
                    break;
            }
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

        public static void WriteDeserializationForMethods(this CodeWriter writer, JsonSerialization serialization, bool async, Action<CodeWriterDelegate> callback, string response, bool isBinaryData)
        {
            if (isBinaryData)
            {
                if (async)
                {
                    callback(w => w.Append($"await {typeof(BinaryData)}.FromStreamAsync({response}.ContentStream).ConfigureAwait(false)"));
                }
                else
                {
                    callback(w => w.Append($"{typeof(BinaryData)}.FromStream({response}.ContentStream)"));
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
