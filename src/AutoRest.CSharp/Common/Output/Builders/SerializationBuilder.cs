// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Serialization.Multipart;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Bicep;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Models;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Output.Builders
{
    internal class SerializationBuilder
    {
        public static SerializationFormat GetDefaultSerializationFormat(CSharpType type)
        {
            if (type.EqualsIgnoreNullable(typeof(byte[])))
            {
                return SerializationFormat.Bytes_Base64;
            }

            if (type.EqualsIgnoreNullable(typeof(DateTimeOffset)))
            {
                return SerializationFormat.DateTime_ISO8601;
            }

            if (type.EqualsIgnoreNullable(typeof(TimeSpan)))
            {
                return SerializationFormat.Duration_ISO8601;
            }

            return SerializationFormat.Default;
        }

        public static SerializationFormat GetSerializationFormat(InputType type) => type switch
        {
            InputLiteralType literalType => GetSerializationFormat(literalType.ValueType),
            InputListType listType => GetSerializationFormat(listType.ElementType),
            InputDictionaryType dictionaryType => GetSerializationFormat(dictionaryType.ValueType),
            InputDateTimeType dateTimeType => dateTimeType.Encode switch
            {
                DateTimeKnownEncoding.Rfc3339 => SerializationFormat.DateTime_RFC3339,
                DateTimeKnownEncoding.Rfc7231 => SerializationFormat.DateTime_RFC7231,
                DateTimeKnownEncoding.UnixTimestamp => SerializationFormat.DateTime_Unix,
                _ => throw new IndexOutOfRangeException($"unknown encode {dateTimeType.Encode}"),
            },
            InputDurationType durationType => durationType.Encode switch
            {
                // there is no such thing as `DurationConstant`
                DurationKnownEncoding.Iso8601 => SerializationFormat.Duration_ISO8601,
                DurationKnownEncoding.Seconds => durationType.WireType.Kind switch
                {
                    InputPrimitiveTypeKind.Int32 => SerializationFormat.Duration_Seconds,
                    InputPrimitiveTypeKind.Float or InputPrimitiveTypeKind.Float32 => SerializationFormat.Duration_Seconds_Float,
                    _ => SerializationFormat.Duration_Seconds_Double
                },
                DurationKnownEncoding.Constant => SerializationFormat.Duration_Constant,
                _ => throw new IndexOutOfRangeException($"unknown encode {durationType.Encode}")
            },
            InputPrimitiveType primitiveType => primitiveType.Kind switch
            {
                InputPrimitiveTypeKind.PlainDate => SerializationFormat.Date_ISO8601,
                InputPrimitiveTypeKind.PlainTime => SerializationFormat.Time_ISO8601,
                InputPrimitiveTypeKind.Bytes => primitiveType.Encode switch
                {
                    BytesKnownEncoding.Base64 => SerializationFormat.Bytes_Base64,
                    BytesKnownEncoding.Base64Url => SerializationFormat.Bytes_Base64Url,
                    _ => throw new IndexOutOfRangeException($"unknown encode {primitiveType.Encode}")
                },
                _ => SerializationFormat.Default
            },
            _ => SerializationFormat.Default
        };

        internal static SerializationFormat GetSerializationFormat(InputType inputType, CSharpType valueType)
        {
            var serializationFormat = GetSerializationFormat(inputType);
            return serializationFormat != SerializationFormat.Default ? serializationFormat : GetDefaultSerializationFormat(valueType);
        }

        public static ObjectSerialization Build(BodyMediaType bodyMediaType, InputType inputType, CSharpType type, SerializationFormat? serializationFormat) => bodyMediaType switch
        {
            BodyMediaType.Xml => BuildXmlElementSerialization(inputType, type, null, true),
            BodyMediaType.Json => BuildJsonSerialization(inputType, type, false, serializationFormat ?? GetSerializationFormat(inputType, type)),
            _ => throw new NotImplementedException(bodyMediaType.ToString())
        };

        private static XmlElementSerialization BuildXmlElementSerialization(InputType inputType, CSharpType type, string? name, bool isRoot)
        {
            string xmlName = inputType.Serialization.Xml?.Name ?? name ?? inputType.Name;
            switch (inputType)
            {
                case InputListType listType:
                    var wrapped = isRoot || listType.Serialization.Xml?.IsWrapped == true;
                    var arrayElement = BuildXmlElementSerialization(listType.ElementType, type.ElementType, null, false);
                    return new XmlArraySerialization(type.InitializationType, arrayElement, xmlName, wrapped);
                case InputDictionaryType dictionaryType:
                    var valueElement = BuildXmlElementSerialization(dictionaryType.ValueType, type.ElementType, null, false);
                    return new XmlDictionarySerialization(type.InitializationType, valueElement, xmlName);
                case CodeModelType cmt:
                    return BuildXmlElementSerialization(cmt.Schema, type, name, isRoot);
                default:
                    return new XmlElementValueSerialization(xmlName, new XmlValueSerialization(type, GetSerializationFormat(inputType)));
            }
        }

        public ObjectSerialization Build(KnownMediaType? mediaType, Schema schema, CSharpType type) => mediaType switch
        {
            KnownMediaType.Json => BuildSerialization(schema, type, false),
            KnownMediaType.Xml => BuildXmlElementSerialization(schema, type, schema.XmlName ?? schema.Name, true),
            _ => throw new NotImplementedException(mediaType.ToString())
        };


        private static XmlElementSerialization BuildXmlElementSerialization(Schema schema, CSharpType type, string? name, bool isRoot)
        {
            string xmlName =
                schema.XmlName ??
                name ??
                schema.Name;

            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return BuildXmlElementSerialization(constantSchema.ValueType, type, name, false);
                case ArraySchema arraySchema:
                    var wrapped = isRoot || arraySchema.Serialization?.Xml?.Wrapped == true;

                    return new XmlArraySerialization(
                        type.InitializationType,
                        BuildXmlElementSerialization(arraySchema.ElementType, type.ElementType, null, false),
                        xmlName,
                        wrapped);

                case DictionarySchema dictionarySchema:
                    return new XmlDictionarySerialization(
                        type.InitializationType,
                        BuildXmlElementSerialization(dictionarySchema.ElementType, type.ElementType, null, false),
                        xmlName);
                default:
                    return new XmlElementValueSerialization(xmlName, BuildXmlValueSerialization(schema, type));
            }
        }

        private static XmlValueSerialization BuildXmlValueSerialization(Schema schema, CSharpType type)
        {
            return new XmlValueSerialization(type, BuilderHelpers.GetSerializationFormat(schema));
        }

        private static bool IsManagedServiceIdentityV3(Schema schema, CSharpType type)
        {
            // If the type is the common type ManagedServiceIdentity and the schema contains a type property with sealed enum or extensible enum schema which has a choice of v3 "SystemAssigned,UserAssigned" value,
            // then this is a v3 version of ManagedServiceIdentity.
            if (!type.IsFrameworkType && type.Implementation is SystemObjectType systemObjectType
                && systemObjectType.SystemType == typeof(ManagedServiceIdentity)
                && schema is ObjectSchema objectSchema
                && (objectSchema.Properties.FirstOrDefault(p => p.SerializedName == "type")?.Schema is SealedChoiceSchema sealedChoiceSchema && sealedChoiceSchema.Choices.Any(c => c.Value == ManagedServiceIdentityTypeV3Converter.SystemAssignedUserAssignedV3Value)
                    || objectSchema.Properties.FirstOrDefault(p => p.SerializedName == "type")?.Schema is ChoiceSchema choiceSchema && choiceSchema.Choices.Any(c => c.Value == ManagedServiceIdentityTypeV3Converter.SystemAssignedUserAssignedV3Value)))
            {
                return true;
            }
            return false;
        }

        public static JsonSerialization BuildJsonSerialization(InputType inputType, CSharpType valueType, bool isCollectionElement, SerializationFormat serializationFormat)
        {
            if (valueType.IsFrameworkType && valueType.FrameworkType == typeof(JsonElement))
            {
                return new JsonValueSerialization(valueType, serializationFormat, valueType.IsNullable || isCollectionElement);
            }

            return inputType switch
            {
                CodeModelType codeModelType => BuildSerialization(codeModelType.Schema, valueType, isCollectionElement),
                InputListType listType => new JsonArraySerialization(valueType, BuildJsonSerialization(listType.ElementType, valueType.ElementType, true), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType)),
                InputDictionaryType dictionaryType => new JsonDictionarySerialization(valueType, BuildJsonSerialization(dictionaryType.ValueType, valueType.ElementType, true), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType)),
                _ => new JsonValueSerialization(valueType, serializationFormat, valueType.IsNullable || (isCollectionElement && !valueType.IsValueType)) // nullable CSharp type like int?, Etag?, and reference type in collection
            };
        }

        public static JsonSerialization BuildJsonSerialization(InputType inputType, CSharpType valueType, bool isCollectionElement)
            => BuildJsonSerialization(inputType, valueType, isCollectionElement, GetSerializationFormat(inputType, valueType));

        private static JsonSerialization BuildJsonSerializationFromValue(CSharpType valueType, bool isCollectionElement)
        {
            if (valueType.IsList)
            {
                return new JsonArraySerialization(valueType, BuildJsonSerializationFromValue(valueType.ElementType, true), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType));
            }

            if (valueType.IsDictionary)
            {
                var dictionaryValueType = valueType.Arguments[1];
                return new JsonDictionarySerialization(valueType, BuildJsonSerializationFromValue(dictionaryValueType, true), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType));
            }

            return new JsonValueSerialization(valueType, GetDefaultSerializationFormat(valueType), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType));
        }

        public static JsonSerialization BuildSerialization(Schema schema, CSharpType type, bool isCollectionElement)
        {
            if (type.IsFrameworkType && type.FrameworkType == typeof(JsonElement))
            {
                return new JsonValueSerialization(type, BuilderHelpers.GetSerializationFormat(schema), type.IsNullable);
            }

            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return BuildSerialization(constantSchema.ValueType, type, isCollectionElement);
                case ArraySchema arraySchema:
                    return new JsonArraySerialization(type, BuildSerialization(arraySchema.ElementType, type.ElementType, true), type.IsNullable || (isCollectionElement && !type.IsValueType));
                case DictionarySchema dictionarySchema:
                    return new JsonDictionarySerialization(type, BuildSerialization(dictionarySchema.ElementType, type.ElementType, true), type.IsNullable || (isCollectionElement && !type.IsValueType));
                default:
                    JsonSerializationOptions options = IsManagedServiceIdentityV3(schema, type) ? JsonSerializationOptions.UseManagedServiceIdentityV3 : JsonSerializationOptions.None;
                    return new JsonValueSerialization(type, BuilderHelpers.GetSerializationFormat(schema), type.IsNullable || (isCollectionElement && !type.IsValueType), options);
            }
        }

        public static XmlObjectSerialization BuildXmlObjectSerialization(string serializationName, SerializableObjectType model, TypeFactory typeFactory)
        {
            var elements = new List<XmlObjectElementSerialization>();
            var attributes = new List<XmlObjectAttributeSerialization>();
            var embeddedArrays = new List<XmlObjectArraySerialization>();
            XmlObjectContentSerialization? contentSerialization = null;

            foreach (var objectTypeLevel in model.EnumerateHierarchy())
            {
                foreach (ObjectTypeProperty objectProperty in objectTypeLevel.Properties)
                {
                    if (IsSerializable(objectProperty, typeFactory, out var isAttribute, out var isContent, out var format, out var serializedName, out var serializedType))
                    {
                        if (isContent)
                        {
                            contentSerialization = new XmlObjectContentSerialization(serializedName, serializedType, objectProperty, new XmlValueSerialization(objectProperty.Declaration.Type, format));
                        }
                        else if (isAttribute)
                        {
                            attributes.Add(new XmlObjectAttributeSerialization(serializedName, serializedType, objectProperty, new XmlValueSerialization(objectProperty.Declaration.Type, format)));
                        }
                        else
                        {
                            var valueSerialization = objectProperty.InputModelProperty is { } inputModelProperty
                                ? BuildXmlElementSerialization(inputModelProperty.Type, objectProperty.Declaration.Type, serializedName, false)
                                : BuildXmlElementSerialization(objectProperty.SchemaProperty!.Schema, objectProperty.Declaration.Type, serializedName, false);

                            if (valueSerialization is XmlArraySerialization arraySerialization)
                            {
                                embeddedArrays.Add(new XmlObjectArraySerialization(serializedName, serializedType, objectProperty, arraySerialization));
                            }
                            else
                            {
                                elements.Add(new XmlObjectElementSerialization(serializedName, serializedType, objectProperty, valueSerialization));
                            }
                        }
                    }
                }
            }

            return new XmlObjectSerialization(serializationName, model, elements.ToArray(), attributes.ToArray(), embeddedArrays.ToArray(), contentSerialization);

            static bool IsSerializable(ObjectTypeProperty objectProperty, TypeFactory typeFactory, out bool isAttribute, out bool isContent, out SerializationFormat format, out string serializedName, out CSharpType serializedType)
            {
                if (objectProperty.InputModelProperty is { } inputModelProperty)
                {
                    isAttribute = inputModelProperty.Type.Serialization.Xml?.IsAttribute == true;
                    isContent = inputModelProperty.Type.Serialization.Xml?.IsContent == true;
                    format = GetSerializationFormat(inputModelProperty.Type);
                    serializedName = inputModelProperty.SerializedName;
                    serializedType = typeFactory.CreateType(inputModelProperty.Type);
                    return true;
                }

                if (objectProperty.SchemaProperty is { } property)
                {
                    isAttribute = property.Schema.Serialization?.Xml?.Attribute == true;
                    isContent = property.Schema.Serialization?.Xml?.Text == true;
                    format = BuilderHelpers.GetSerializationFormat(property.Schema);
                    serializedName = property.SerializedName;
                    serializedType = objectProperty.ValueType;
                    return true;
                }

                isAttribute = false;
                isContent = false;
                format = default;
                serializedName = string.Empty;
                serializedType = typeof(object);
                return false;
            }
        }

        public BicepObjectSerialization? BuildBicepObjectSerialization(SerializableObjectType objectType, JsonObjectSerialization jsonObjectSerialization)
            => new BicepObjectSerialization(objectType, jsonObjectSerialization);

        private static JsonPropertySerialization? CreateJsonPropertySerializationFromInputModelProperty(SerializableObjectType objectType, ObjectTypeProperty property, TypeFactory typeFactory)
        {
            var declaredName = property.Declaration.Name;
            var propertyType = property.Declaration.Type;
            var name = declaredName.ToVariableName();
            var serializationMapping = objectType.GetForMemberSerialization(declaredName);

            if (property.InputModelProperty is not { } inputModelProperty)
            {
                // Property is not part of specification,
                return new JsonPropertySerialization(
                    name,
                    new TypedMemberExpression(null, declaredName, propertyType),
                    serializationMapping?.SerializationPath?[^1] ?? name,
                    propertyType,
                    BuildJsonSerializationFromValue(propertyType, false),
                    property.IsRequired,
                    property.IsReadOnly,
                    property,
                    serializationHooks: new CustomSerializationHooks(
                        serializationMapping?.JsonSerializationValueHook,
                        serializationMapping?.JsonDeserializationValueHook,
                        serializationMapping?.BicepSerializationValueHook));
            }

            var valueSerialization = BuildJsonSerialization(inputModelProperty.Type, propertyType, false);
            var serializedName = serializationMapping?.SerializationPath?[^1] ?? inputModelProperty.SerializedName;
            var serializedType = typeFactory.CreateType(inputModelProperty.Type);
            var memberValueExpression = new TypedMemberExpression(null, declaredName, propertyType);

            return new JsonPropertySerialization(
                name,
                memberValueExpression,
                serializedName,
                serializedType,
                valueSerialization,
                property.IsRequired,
                ShouldExcludeInWireSerialization(property, inputModelProperty),
                property,
                serializationHooks: new CustomSerializationHooks(
                    serializationMapping?.JsonSerializationValueHook,
                    serializationMapping?.JsonDeserializationValueHook,
                    serializationMapping?.BicepSerializationValueHook),
                enumerableExpression: null);
        }

        private static bool ShouldExcludeInWireSerialization(ObjectTypeProperty property, InputModelProperty inputProperty)
        {
            if (inputProperty.IsDiscriminator)
            {
                return false;
            }

            if (property.InitializationValue is not null)
            {
                return false;
            }

            return inputProperty.IsReadOnly;
        }

        private static IEnumerable<JsonPropertySerialization> GetPropertySerializationsFromBag<T>(PropertyBag<T> propertyBag, Func<T, JsonPropertySerialization?> jsonPropertySerializationFactory)
        {
            foreach (var property in propertyBag.Properties)
            {
                if (jsonPropertySerializationFactory(property) is { } serialization)
                {
                    yield return serialization;
                }
            }

            foreach (var (name, innerBag) in propertyBag.Bag)
            {
                JsonPropertySerialization[] serializationProperties = GetPropertySerializationsFromBag(innerBag, jsonPropertySerializationFactory).ToArray();
                yield return new JsonPropertySerialization(name, serializationProperties);
            }
        }

        private IEnumerable<JsonPropertySerialization> GetPropertySerializationsFromBag(SerializationPropertyBag propertyBag, SchemaObjectType objectType)
        {
            foreach (var (property, serializationMapping) in propertyBag.Properties)
            {
                if (property.SchemaProperty == null)
                {
                    // Property is not part of specification,
                    var declaredName = property.Declaration.Name;
                    var propertyType = property.Declaration.Type;
                    var varName = declaredName.ToVariableName();
                    yield return new JsonPropertySerialization(
                        varName,
                        new TypedMemberExpression(null, property.Declaration.Name, propertyType),
                        serializationMapping?.SerializationPath?[^1] ?? varName,
                        propertyType,
                        BuildJsonSerializationFromValue(propertyType, false),
                        property.IsRequired,
                        property.IsReadOnly,
                        property,
                        serializationHooks: new CustomSerializationHooks(
                            serializationMapping?.JsonSerializationValueHook,
                            serializationMapping?.JsonDeserializationValueHook,
                            serializationMapping?.BicepSerializationValueHook));
                }
                else
                {
                    var schemaProperty = property.SchemaProperty;
                    var parameter = objectType.SerializationConstructor.FindParameterByInitializedProperty(property);
                    if (parameter is null)
                    {
                        throw new InvalidOperationException(
                            $"Serialization constructor of the type {objectType.Declaration.Name} has no parameter for {schemaProperty.SerializedName} input property");
                    }

                    var serializedName = serializationMapping?.SerializationPath?[^1] ?? schemaProperty.SerializedName;
                    var isRequired = schemaProperty.IsRequired;
                    var shouldExcludeInWireSerialization =
                        (schemaProperty.IsDiscriminator == null || !schemaProperty.IsDiscriminator.Value) &&
                        property.InitializationValue is null && schemaProperty.IsReadOnly;
                    var serialization = BuildSerialization(schemaProperty.Schema, property.Declaration.Type, false);

                    var memberValueExpression =
                        new TypedMemberExpression(null, property.Declaration.Name, property.Declaration.Type);
                    TypedMemberExpression? enumerableExpression = null;
                    if (property.SchemaProperty is not null && property.SchemaProperty.Extensions is not null &&
                        property.SchemaProperty.Extensions.IsEmbeddingsVector)
                    {
                        enumerableExpression = property.Declaration.Type.IsNullable
                            ? new TypedMemberExpression(null,
                                $"{property.Declaration.Name}.{nameof(Nullable<ReadOnlyMemory<object>>.Value)}.{nameof(ReadOnlyMemory<object>.Span)}",
                                typeof(ReadOnlySpan<>).MakeGenericType(property.Declaration.Type.Arguments[0]
                                    .FrameworkType))
                            : new TypedMemberExpression(null,
                                $"{property.Declaration.Name}.{nameof(ReadOnlyMemory<object>.Span)}",
                                typeof(ReadOnlySpan<>).MakeGenericType(property.Declaration.Type.Arguments[0]
                                    .FrameworkType));
                    }

                    yield return new JsonPropertySerialization(
                        parameter.Name,
                        memberValueExpression,
                        serializedName,
                        property.ValueType,
                        serialization,
                        isRequired,
                        shouldExcludeInWireSerialization,
                        property,
                        serializationHooks: new CustomSerializationHooks(
                            serializationMapping?.JsonSerializationValueHook,
                            serializationMapping?.JsonDeserializationValueHook,
                            serializationMapping?.BicepSerializationValueHook),
                        enumerableExpression: enumerableExpression);
                }
            }

            foreach ((string name, SerializationPropertyBag innerBag) in propertyBag.Bag)
            {
                JsonPropertySerialization[] serializationProperties = GetPropertySerializationsFromBag(innerBag, objectType).ToArray();
                yield return new JsonPropertySerialization(name, serializationProperties);
            }
        }

        public JsonObjectSerialization BuildJsonObjectSerialization(ObjectSchema objectSchema, SchemaObjectType objectType)
        {
            var propertyBag = new SerializationPropertyBag();
            foreach (var objectTypeLevel in objectType.EnumerateHierarchy())
            {
                foreach (var objectTypeProperty in objectTypeLevel.Properties)
                {
                    if (objectTypeProperty == objectTypeLevel.AdditionalPropertiesProperty)
                        continue;
                    propertyBag.Properties.Add(objectTypeProperty, objectType.GetForMemberSerialization(objectTypeProperty.Declaration.Name));
                }
            }

            PopulatePropertyBag(propertyBag, 0);
            var properties = GetPropertySerializationsFromBag(propertyBag, objectType).ToArray();
            var (additionalProperties, rawDataField) = CreateAdditionalPropertiesSerialization(objectSchema, objectType);
            return new JsonObjectSerialization(objectType, objectType.SerializationConstructor.Signature.Parameters, properties, additionalProperties, rawDataField, objectType.Discriminator, objectType.JsonConverter);
        }

        public static IReadOnlyList<JsonPropertySerialization> GetPropertySerializations(ModelTypeProvider model, TypeFactory typeFactory)
            => GetPropertySerializationsFromBag(PopulatePropertyBag(model), p => CreateJsonPropertySerializationFromInputModelProperty(model, p, typeFactory)).ToArray();

        private class SerializationPropertyBag
        {
            public Dictionary<string, SerializationPropertyBag> Bag { get; } = new();
            public Dictionary<ObjectTypeProperty, SourcePropertySerializationMapping?> Properties { get; } = new();
        }

        private static void PopulatePropertyBag(SerializationPropertyBag propertyBag, int depthIndex)
        {
            foreach (var (property, serializationMapping) in propertyBag.Properties.ToArray())
            {
                ICollection<string> flattenedNames = serializationMapping?.SerializationPath as ICollection<string> ?? property.SchemaProperty?.FlattenedNames ?? new List<string>();
                if (depthIndex >= (flattenedNames?.Count ?? 0) - 1)
                {
                    continue;
                }

                string name = flattenedNames!.ElementAt(depthIndex);
                if (!propertyBag.Bag.TryGetValue(name, out SerializationPropertyBag? namedBag))
                {
                    namedBag = new SerializationPropertyBag();
                    propertyBag.Bag.Add(name, namedBag);
                }

                namedBag.Properties.Add(property, serializationMapping);
                propertyBag.Properties.Remove(property);
            }

            foreach (SerializationPropertyBag innerBag in propertyBag.Bag.Values)
            {
                PopulatePropertyBag(innerBag, depthIndex + 1);
            }
        }

        private class PropertyBag<T>
        {
            public Dictionary<string, PropertyBag<T>> Bag { get; } = new();
            public List<T> Properties { get; } = new();
        }

        private static PropertyBag<ObjectTypeProperty> PopulatePropertyBag(SerializableObjectType objectType)
        {
            var propertyBag = new PropertyBag<ObjectTypeProperty>();
            foreach (var objectTypeLevel in objectType.EnumerateHierarchy())
            {
                foreach (var objectTypeProperty in objectTypeLevel.Properties)
                {
                    if (objectTypeProperty == objectTypeLevel.AdditionalPropertiesProperty)
                    {
                        continue;
                    }

                    if (objectTypeLevel is SerializableObjectType serializableObjectType && objectTypeProperty == serializableObjectType.RawDataField)
                    {
                        continue;
                    }

                    propertyBag.Properties.Add(objectTypeProperty);
                }
            }

            PopulatePropertyBag(propertyBag, (p, i) => GetPropertyNameAtDepth(objectType, p, i), 0);
            return propertyBag;
        }

        private static void PopulatePropertyBag<T>(PropertyBag<T> propertyBag, Func<T, int, string?> getPropertyNameAtDepth, int depthIndex) where T : class
        {
            var propertiesCopy = propertyBag.Properties.ToArray();
            foreach (var property in propertiesCopy)
            {
                var name = getPropertyNameAtDepth(property, depthIndex);

                if (name is null)
                {
                    continue;
                }

                if (!propertyBag.Bag.TryGetValue(name, out PropertyBag<T>? namedBag))
                {
                    namedBag = new PropertyBag<T>();
                    propertyBag.Bag.Add(name, namedBag);
                }

                namedBag.Properties.Add(property);
                propertyBag.Properties.Remove(property);
            }

            foreach (var innerBag in propertyBag.Bag.Values)
            {
                PopulatePropertyBag(innerBag, getPropertyNameAtDepth, depthIndex + 1);
            }
        }

        private static string? GetPropertyNameAtDepth(SerializableObjectType objectType, ObjectTypeProperty property, int depthIndex)
        {
            if (objectType.GetForMemberSerialization(property.Declaration.Name) is { SerializationPath: { } serializationPath } && serializationPath.Count > depthIndex + 1)
            {
                return serializationPath[depthIndex];
            }

            if (property.SchemaProperty is { FlattenedNames: { } schemaFlattenedNames } && schemaFlattenedNames.Count > depthIndex + 1)
            {
                return schemaFlattenedNames.ElementAt(depthIndex);
            }

            if (property.InputModelProperty is { } inputModelProperty)
            {
                return GetPropertyNameAtDepth(inputModelProperty, depthIndex);
            }

            return null;
        }

        private static string? GetPropertyNameAtDepth(InputModelProperty property, int depthIndex)
            => property is { FlattenedNames: { } inputFlattenedNames } && inputFlattenedNames.Count > depthIndex + 1
                ? inputFlattenedNames[depthIndex]
                : null;

        private (JsonAdditionalPropertiesSerialization? AdditionalPropertiesSerialization, JsonAdditionalPropertiesSerialization? RawDataFieldSerialization) CreateAdditionalPropertiesSerialization(ObjectSchema objectSchema, ObjectType objectType)
        {
            // collect additional properties and raw data field
            ObjectTypeProperty? additionalPropertiesProperty = null;
            ObjectTypeProperty? rawDataField = null;
            foreach (var obj in objectType.EnumerateHierarchy())
            {
                additionalPropertiesProperty ??= obj.AdditionalPropertiesProperty;
                rawDataField ??= (obj as SerializableObjectType)?.RawDataField;
            }
            var inheritedDictionarySchema = objectSchema.Parents!.All.OfType<DictionarySchema>().FirstOrDefault();

            if (additionalPropertiesProperty == null && rawDataField == null)
            {
                return (null, null);
            }

            // build serialization for additional properties property (if any)
            var additionalPropertiesSerialization = BuildSerializationForAdditionalProperties(additionalPropertiesProperty, inheritedDictionarySchema, false);
            // build serialization for raw data field (if any)
            var rawDataFieldSerialization = BuildSerializationForAdditionalProperties(rawDataField, null, true);

            return (additionalPropertiesSerialization, rawDataFieldSerialization);

            static JsonAdditionalPropertiesSerialization? BuildSerializationForAdditionalProperties(ObjectTypeProperty? additionalPropertiesProperty, DictionarySchema? inheritedDictionarySchema, bool shouldExcludeInWireSerialization)
            {
                if (additionalPropertiesProperty == null)
                {
                    return null;
                }

                var additionalPropertyValueType = additionalPropertiesProperty.Declaration.Type.Arguments[1];
                JsonSerialization valueSerialization;
                if (inheritedDictionarySchema is not null)
                {
                    valueSerialization = BuildSerialization(inheritedDictionarySchema.ElementType, additionalPropertyValueType, false);
                }
                else
                {
                    valueSerialization = new JsonValueSerialization(additionalPropertyValueType, SerializationFormat.Default, true);
                }

                return new JsonAdditionalPropertiesSerialization(
                    additionalPropertiesProperty,
                    valueSerialization,
                    new CSharpType(typeof(Dictionary<,>), additionalPropertiesProperty.Declaration.Type.Arguments),
                    shouldExcludeInWireSerialization);
            }
        }
        public MultipartObjectSerialization BuildMultipartObjectSerialization(ObjectSchema objectSchema, SchemaObjectType objectType)
        {
            /*TODO: This is a temporary implementation. We need to revisit this and make it more robust.
             *Need to consider the polymorphism and the base class properties.
             **/
            var properties = new List<MultipartPropertySerialization>();
            foreach (ObjectTypeProperty property in objectType.Properties.ToArray())
            {
                var schemaProperty = property.SchemaProperty!; // we ensure this is not null when we build the array
                var parameter = objectType.SerializationConstructor.FindParameterByInitializedProperty(property);
                if (parameter is null)
                {
                    throw new InvalidOperationException($"Serialization constructor of the type {objectType.Declaration.Name} has no parameter for {schemaProperty.SerializedName} input property");
                }

                var serializedName = schemaProperty.SerializedName;
                var isRequired = schemaProperty.IsRequired;
                var shouldExcludeInWireSerialization = schemaProperty.IsReadOnly;
                var memberValueExpression = new TypedMemberExpression(null, property.Declaration.Name, property.Declaration.Type);
                MultipartSerialization valueSerialization = BuildMultipartSerialization(schemaProperty.Schema, property.Declaration.Type, false);
                var propertySerialization = new MultipartPropertySerialization(
                    parameter.Name,
                    memberValueExpression,
                    serializedName,
                    property.ValueType,
                    valueSerialization,
                    isRequired,
                    shouldExcludeInWireSerialization);
                properties.Add(propertySerialization);
            }

            /*build serialization for additional properties*/
            var additionalProperties = CreateMultipartAdditionalPropertiesSerialization(objectSchema, objectType);
            return new MultipartObjectSerialization(objectType,
                objectType.SerializationConstructor.Signature.Parameters,
                properties,
                additionalProperties,
                objectType.Discriminator,
                false);
        }
        private MultipartAdditionalPropertiesSerialization? CreateMultipartAdditionalPropertiesSerialization(ObjectSchema objectSchema, ObjectType objectType)
        {
            var inheritedDictionarySchema = objectSchema.Parents!.All.OfType<DictionarySchema>().FirstOrDefault();
            bool shouldExcludeInWireSerialization = false;
            ObjectTypeProperty? additionalPropertiesProperty = null;
            foreach (var obj in objectType.EnumerateHierarchy())
            {
                additionalPropertiesProperty = obj.AdditionalPropertiesProperty ?? (obj as SerializableObjectType)?.RawDataField;
                if (additionalPropertiesProperty != null)
                {
                    // if this is a real "AdditionalProperties", we should NOT exclude it in wire
                    shouldExcludeInWireSerialization = additionalPropertiesProperty != obj.AdditionalPropertiesProperty;
                    break;
                }
            }

            if (additionalPropertiesProperty == null)
            {
                return null;
            }

            var dictionaryValueType = additionalPropertiesProperty.Declaration.Type.Arguments[1];
            Debug.Assert(!dictionaryValueType.IsNullable, $"{typeof(JsonCodeWriterExtensions)} implicitly relies on {additionalPropertiesProperty.Declaration.Name} dictionary value being non-nullable");
            MultipartSerialization valueSerialization;
            if (inheritedDictionarySchema is not null)
            {
                valueSerialization = BuildMultipartSerialization(inheritedDictionarySchema.ElementType, dictionaryValueType, false);
            }
            else
            {
                valueSerialization = new MultipartValueSerialization(dictionaryValueType, SerializationFormat.Default, true);
            }

            return new MultipartAdditionalPropertiesSerialization(
                additionalPropertiesProperty,
                new CSharpType(typeof(Dictionary<,>), additionalPropertiesProperty.Declaration.Type.Arguments),
                valueSerialization,
                shouldExcludeInWireSerialization);
        }
        public static MultipartSerialization BuildMultipartSerialization(InputType? inputType, CSharpType valueType, bool isCollectionElement, SerializationFormat serializationFormat, ValueExpression memberValueExpression)
        {
            /*TODO: need to update to use InputType to identify if it is a Multipart File or not. Current we will set contentType for Bytes and Stream*/
            if (inputType != null && inputType is InputPrimitiveType { Kind: InputPrimitiveTypeKind.Bytes } && valueType.IsFrameworkType && valueType.FrameworkType == typeof(BinaryData))
            {
                var valueSerialization = new MultipartValueSerialization(valueType, serializationFormat, valueType.IsNullable || isCollectionElement);
                valueSerialization.ContentType = "application/octet-stream"; //TODO: need to set the right content type from InputType
                return valueSerialization;
            }
            if (inputType != null && inputType.Name == InputPrimitiveType.Stream.Name && valueType.IsFrameworkType && valueType.FrameworkType == typeof(Stream))
            {
                var valueSerialization = new MultipartValueSerialization(valueType, serializationFormat, valueType.IsNullable || isCollectionElement);
                valueSerialization.ContentType = "application/octet-stream"; //TODO: need to set the right content type from InputType
                return valueSerialization;
            }
            return inputType switch
            {
                CodeModelType codeModelType => BuildMultipartSerialization(codeModelType.Schema, valueType, isCollectionElement),
                InputListType listType => new MultipartArraySerialization(valueType, BuildMultipartSerialization(listType.ElementType, valueType.ElementType, true, serializationFormat, new VariableReference(valueType.ElementType, "item")), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType)),
                InputDictionaryType dictionaryType => new MultipartDictionarySerialization(valueType, BuildMultipartSerialization(dictionaryType.ValueType, valueType.ElementType, true, serializationFormat, memberValueExpression), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType)),
                _ => new MultipartValueSerialization(valueType, serializationFormat, valueType.IsNullable || isCollectionElement)// nullable CSharp type like int?, Etag?, and reference type in collection
            };
        }
        public static MultipartSerialization BuildMultipartSerialization(Schema schema, CSharpType type, bool isCollectionElement)
        {
            if (type.IsFrameworkType && type.FrameworkType == typeof(JsonElement))
            {
                return new MultipartValueSerialization(type, BuilderHelpers.GetSerializationFormat(schema), type.IsNullable);
            }

            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return BuildMultipartSerialization(constantSchema.ValueType, type, isCollectionElement);
                case ArraySchema arraySchema:
                    return new MultipartArraySerialization(type, BuildMultipartSerialization(arraySchema.ElementType, type.ElementType, true), type.IsNullable || (isCollectionElement && !type.IsValueType));
                case DictionarySchema dictionarySchema:
                    return new MultipartDictionarySerialization(type, BuildMultipartSerialization(dictionarySchema.ElementType, type.ElementType, true), type.IsNullable || (isCollectionElement && !type.IsValueType));
                default:
                    return new MultipartValueSerialization(type, BuilderHelpers.GetSerializationFormat(schema), type.IsNullable || (isCollectionElement && !type.IsValueType));
            }
        }
        public static IEnumerable<MultipartPropertySerialization> CreateMultipartPropertySerializations(ModelTypeProvider model)
        {
            foreach (var objType in model.EnumerateHierarchy())
            {
                foreach (var property in objType.Properties)
                {
                    if (property.InputModelProperty is not { } inputModelProperty)
                        continue;

                    var declaredName = property.Declaration.Name;
                    var serializedName = inputModelProperty.SerializedName;
                    var memberValueExpression = new TypedMemberExpression(null, declaredName, property.Declaration.Type);
                    var valueSerialization = BuildMultipartSerialization(inputModelProperty.Type, property.Declaration.Type, false, property.SerializationFormat, memberValueExpression.NullableStructValue());
                    TypedMemberExpression? enumerableExpression = null;
                    if (property.Declaration.Type.IsReadOnlyMemory)
                    {
                        enumerableExpression = property.Declaration.Type.IsNullable
                            ? new TypedMemberExpression(null, $"{property.Declaration.Name}.{nameof(Nullable<ReadOnlyMemory<object>>.Value)}.{nameof(ReadOnlyMemory<object>.Span)}", typeof(ReadOnlySpan<>).MakeGenericType(property.Declaration.Type.Arguments[0].FrameworkType))
                            : new TypedMemberExpression(null, $"{property.Declaration.Name}.{nameof(ReadOnlyMemory<object>.Span)}", typeof(ReadOnlySpan<>).MakeGenericType(property.Declaration.Type.Arguments[0].FrameworkType));
                    }

                    yield return new MultipartPropertySerialization(
                        declaredName.ToVariableName(),
                        memberValueExpression,
                        serializedName,
                        property.ValueType.IsNullable && property.OptionalViaNullability ? property.ValueType.WithNullable(false) : property.ValueType,
                        valueSerialization,
                        property.IsRequired,
                        ShouldExcludeInWireSerialization(property, inputModelProperty),
                        null,
                        enumerableExpression: enumerableExpression);
                }
            }
        }
    }
}
