// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Models;

namespace AutoRest.CSharp.Common.Output.Builders
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

        public static SerializationFormat GetSerializationFormat(InputType type)
            => type switch
            {
                InputListType listType => GetSerializationFormat(listType.ElementType),
                InputDictionaryType dictionaryType => GetSerializationFormat(dictionaryType.ValueType),
                InputPrimitiveType primitiveType => primitiveType.Kind switch
                {
                    InputTypeKind.BytesBase64Url => SerializationFormat.Bytes_Base64Url,
                    InputTypeKind.Bytes => SerializationFormat.Bytes_Base64,
                    InputTypeKind.Date => SerializationFormat.Date_ISO8601,
                    InputTypeKind.DateTime => SerializationFormat.DateTime_ISO8601,
                    InputTypeKind.DateTimeISO8601 => SerializationFormat.DateTime_ISO8601,
                    InputTypeKind.DateTimeRFC1123 => SerializationFormat.DateTime_RFC1123,
                    InputTypeKind.DateTimeRFC3339 => SerializationFormat.DateTime_RFC3339,
                    InputTypeKind.DateTimeRFC7231 => SerializationFormat.DateTime_RFC7231,
                    InputTypeKind.DateTimeUnix => SerializationFormat.DateTime_Unix,
                    InputTypeKind.DurationISO8601 => SerializationFormat.Duration_ISO8601,
                    InputTypeKind.DurationConstant => SerializationFormat.Duration_Constant,
                    InputTypeKind.DurationSeconds => SerializationFormat.Duration_Seconds,
                    InputTypeKind.DurationSecondsFloat => SerializationFormat.Duration_Seconds_Float,
                    InputTypeKind.Time => SerializationFormat.Time_ISO8601,
                    _ => SerializationFormat.Default
                },
                _ => SerializationFormat.Default
            };

        private static SerializationFormat GetSerializationFormat(InputType inputType, CSharpType valueType)
        {
            var serializationFormat = GetSerializationFormat(inputType);
            return serializationFormat != SerializationFormat.Default ? serializationFormat : GetDefaultSerializationFormat(valueType);
        }

        public static ObjectSerialization Build(BodyMediaType bodyMediaType, InputType inputType, CSharpType type) => bodyMediaType switch
        {
            BodyMediaType.Json => BuildJsonSerialization(inputType, type),
            BodyMediaType.Xml => BuildXmlSerialization(inputType, type),
            _ => throw new NotImplementedException(bodyMediaType.ToString())
        };

        public static JsonSerialization BuildJsonSerialization(InputType inputType, CSharpType valueType)
            => BuildJsonSerialization(inputType, valueType, false);

        public static XmlElementSerialization BuildXmlSerialization(InputType inputType, CSharpType valueType)
            => BuildXmlElementSerialization(inputType, valueType, null, true);

        private static XmlElementSerialization BuildXmlElementSerialization(InputType inputType, CSharpType type, string? name, bool isRoot)
        {
            string xmlName = inputType.Serialization.Xml?.Name ?? name ?? inputType.Name;
            switch (inputType)
            {
                case InputListType listType:
                    var wrapped = isRoot || listType.Serialization.Xml?.IsWrapped == true;
                    var arrayElement = BuildXmlElementSerialization(listType.ElementType, TypeFactory.GetElementType(type), null, false);
                    return new XmlArraySerialization(TypeFactory.GetImplementationType(type), arrayElement, xmlName, wrapped);
                case InputDictionaryType dictionaryType:
                    var valueElement = BuildXmlElementSerialization(dictionaryType.ValueType, TypeFactory.GetElementType(type), null, false);
                    return new XmlDictionarySerialization(TypeFactory.GetImplementationType(type), valueElement, xmlName);
                case CodeModelType cmt:
                    return BuildXmlElementSerialization(cmt.Schema, type, null, isRoot);
                default:
                    return new XmlElementValueSerialization(xmlName, new XmlValueSerialization(type, GetSerializationFormat(inputType)));
            }
        }

        public static ObjectSerialization Build(KnownMediaType? mediaType, Schema schema, CSharpType type) => mediaType switch
        {
            KnownMediaType.Json => BuildSerialization(schema, type, false),
            KnownMediaType.Xml => BuildXmlElementSerialization(schema, type, null, true),
            _ => throw new NotImplementedException(mediaType.ToString())
        };


        private static XmlElementSerialization BuildXmlElementSerialization(Schema schema, CSharpType type, string? name, bool isRoot)
        {
            string xmlName = schema.XmlName ?? name ?? schema.Name;
            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return BuildXmlElementSerialization(constantSchema.ValueType, type, name, false);
                case ArraySchema arraySchema:
                    var wrapped = isRoot || arraySchema.Serialization?.Xml?.Wrapped == true;
                    return new XmlArraySerialization(TypeFactory.GetImplementationType(type), BuildXmlElementSerialization(arraySchema.ElementType, TypeFactory.GetElementType(type), null, false), xmlName, wrapped);

                case DictionarySchema dictionarySchema:
                    return new XmlDictionarySerialization(TypeFactory.GetImplementationType(type), BuildXmlElementSerialization(dictionarySchema.ElementType,TypeFactory.GetElementType(type), null, false), xmlName);
                default:
                    return new XmlElementValueSerialization(xmlName, new XmlValueSerialization(type, BuilderHelpers.GetSerializationFormat(schema)));
            }
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

        public static JsonSerialization BuildJsonSerialization(InputType inputType, CSharpType valueType, bool isCollectionElement)
        {
            if (valueType.IsFrameworkType && valueType.FrameworkType == typeof(JsonElement))
            {
                return new JsonValueSerialization(valueType, GetSerializationFormat(inputType, valueType), valueType.IsNullable || isCollectionElement);
            }

            return inputType switch
            {
                CodeModelType codeModelType => BuildSerialization(codeModelType.Schema, valueType, isCollectionElement),
                InputListType listType => new JsonArraySerialization(valueType, BuildJsonSerialization(listType.ElementType, TypeFactory.GetElementType(valueType), true), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType)),
                InputDictionaryType dictionaryType => new JsonDictionarySerialization(valueType, BuildJsonSerialization(dictionaryType.ValueType, TypeFactory.GetElementType(valueType), true), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType)),
                _ => new JsonValueSerialization(valueType, GetSerializationFormat(inputType, valueType), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType)) // nullable CSharp type like int?, Etag?, and reference type in collection
            };
        }

        private static JsonSerialization BuildJsonSerializationFromValue(CSharpType valueType, bool isCollectionElement)
        {
            if (TypeFactory.IsList(valueType, out var elementType))
            {
                return new JsonArraySerialization(valueType, BuildJsonSerializationFromValue(elementType, true), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType));
            }

            if (TypeFactory.IsDictionary(valueType, out _, out var dictionaryValueType))
            {
                return new  JsonDictionarySerialization(valueType, BuildJsonSerializationFromValue(dictionaryValueType, true), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType));
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
                    return new JsonArraySerialization(type, BuildSerialization(arraySchema.ElementType, TypeFactory.GetElementType(type), true), type.IsNullable);
                case DictionarySchema dictionarySchema:
                    return new JsonDictionarySerialization(type, BuildSerialization(dictionarySchema.ElementType, TypeFactory.GetElementType(type), true), type.IsNullable);
                default:
                    JsonSerializationOptions options = IsManagedServiceIdentityV3(schema, type) ? JsonSerializationOptions.UseManagedServiceIdentityV3 : JsonSerializationOptions.None;
                    return new JsonValueSerialization(type, BuilderHelpers.GetSerializationFormat(schema), type.IsNullable || (isCollectionElement && !type.IsValueType), options);
            }
        }

        public static XmlObjectSerialization BuildXmlObjectSerialization(string serializationName, ObjectType objectType, TypeFactory typeFactory)
        {
            var elements = new List<XmlObjectElementSerialization>();
            var attributes = new List<XmlObjectAttributeSerialization>();
            var embeddedArrays = new List<XmlObjectArraySerialization>();
            XmlObjectContentSerialization? contentSerialization = null;

            foreach (var objectTypeLevel in objectType.EnumerateHierarchy())
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
                            var valueSerialization = objectProperty.InputModelProperty is {} inputModelProperty
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

            return new XmlObjectSerialization(serializationName, objectType.Type, elements.ToArray(), attributes.ToArray(), embeddedArrays.ToArray(), contentSerialization);

            static bool IsSerializable(ObjectTypeProperty objectProperty, TypeFactory typeFactory, out bool isAttribute, out bool isContent, out SerializationFormat format, out string serializedName, out CSharpType serializedType)
            {
                if (objectProperty.InputModelProperty is {} inputModelProperty)
                {
                    isAttribute = inputModelProperty.Type.Serialization.Xml?.IsAttribute == true;
                    isContent = inputModelProperty.Type.Serialization.Xml?.IsContent == true;
                    format = GetSerializationFormat(inputModelProperty.Type);
                    serializedName = inputModelProperty.SerializedName;
                    serializedType = typeFactory.CreateType(inputModelProperty.Type);
                    return true;
                }

                if (objectProperty.SchemaProperty is {} property)
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

        public JsonObjectSerialization BuildJsonObjectSerialization(ObjectSchema objectSchema, SchemaObjectType objectType)
        {
            var properties = GetPropertySerializationsFromBag(PopulatePropertyBag(objectType), p => CreateJsonPropertySerializationFromSchemaProperty(p, objectType)).ToArray();
            var additionalProperties = CreateAdditionalProperties(objectType);
            return new JsonObjectSerialization(objectType.Type, objectType.SerializationConstructor.Signature.Parameters, properties, additionalProperties, objectType.Discriminator, objectType.IncludeConverter);
        }

        public static IReadOnlyList<JsonPropertySerialization> GetPropertySerializations(ModelTypeProvider model, TypeFactory typeFactory)
            => GetPropertySerializationsFromBag(PopulatePropertyBag(model), m => CreateJsonPropertySerializationFromInputModelProperty(m, typeFactory)).ToArray();

        public static IReadOnlyList<JsonPropertySerialization> GetPropertiesForSerializationOnly(IReadOnlyDictionary<InputModelProperty, TypedValueExpression> properties)
            => GetPropertySerializationsFromBag(PopulatePropertyBag(properties.Keys), p => CreateJsonPropertySerializationForSerializationOnly(p, properties[p])).ToArray();

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

        private static JsonPropertySerialization? CreateJsonPropertySerializationFromSchemaProperty(ObjectTypeProperty property, SchemaObjectType objectType)
        {
            if (property.SchemaProperty is not {} schemaProperty)
            {
                return null;
            }

            var serializedName = schemaProperty.SerializedName;
            var isRequired = schemaProperty.IsRequired;
            var isReadOnly = schemaProperty.IsReadOnly;
            var serialization = BuildSerialization(schemaProperty.Schema, property.Declaration.Type, false);

            var parameter = objectType.SerializationConstructor.FindParameterByInitializedProperty(property);
            if (parameter is null)
            {
                throw new InvalidOperationException($"Serialization constructor of the type {objectType.Declaration.Name} has no parameter for {serializedName} input property");
            }

            return new JsonPropertySerialization(
                parameter.Name,
                new TypedMemberExpression(null, property.Declaration.Name, property.Declaration.Type),
                serializedName,
                property.ValueType,
                serialization,
                isRequired,
                isReadOnly,
                customSerializationMethodName: property.SerializationMapping?.SerializationValueHook,
                customDeserializationMethodName: property.SerializationMapping?.DeserializationValueHook);
        }

        private static JsonPropertySerialization CreateJsonPropertySerializationForSerializationOnly(InputModelProperty inputModelProperty, TypedValueExpression value)
        {
            var serializedName = inputModelProperty.SerializedName;
            var valueSerialization = BuildJsonSerialization(inputModelProperty.Type, value.Type, false);
            var optionalViaNullability = inputModelProperty is { IsRequired: false, Type.IsNullable: false };

            return new JsonPropertySerialization(
                string.Empty,
                value,
                serializedName,
                value.Type.IsNullable && optionalViaNullability ? value.Type.WithNullable(false) : value.Type,
                valueSerialization,
                inputModelProperty.IsRequired,
                false);
        }

        private static JsonPropertySerialization? CreateJsonPropertySerializationFromInputModelProperty(ObjectTypeProperty property, TypeFactory typeFactory)
        {
            var declaredName = property.Declaration.Name;
            var propertyType = property.Declaration.Type;
            var name = declaredName.ToVariableName();

            if (property.InputModelProperty is not {} inputModelProperty)
            {
                // Property is not part of specification,
                return new JsonPropertySerialization(
                    name,
                    new TypedMemberExpression(null, declaredName, propertyType),
                    property.SerializationMapping?.SerializationPath?.Last() ?? name,
                    propertyType,
                    BuildJsonSerializationFromValue(propertyType, false),
                    property.IsRequired,
                    property.IsReadOnly,
                    customSerializationMethodName: property.SerializationMapping?.SerializationValueHook,
                    customDeserializationMethodName: property.SerializationMapping?.DeserializationValueHook);
            }

            var valueSerialization = BuildJsonSerialization(inputModelProperty.Type, propertyType, false);
            var serializedName = inputModelProperty.SerializedName;
            var serializedType = typeFactory.CreateType(inputModelProperty.Type);

            return new JsonPropertySerialization(
                name,
                new TypedMemberExpression(null, declaredName, propertyType),
                serializedName,
                serializedType,
                valueSerialization,
                property.IsRequired,
                ShouldSkipSerialization(inputModelProperty),
                customSerializationMethodName: property.SerializationMapping?.SerializationValueHook,
                customDeserializationMethodName: property.SerializationMapping?.DeserializationValueHook);
        }

        private static bool ShouldSkipSerialization(InputModelProperty inputProperty)
        {
            if (inputProperty.IsDiscriminator)
            {
                return false;
            }

            if (inputProperty.ConstantValue is not null)
            {
                return false;
            }

            return inputProperty.IsReadOnly;
        }

        private class PropertyBag<T>
        {
            public Dictionary<string, PropertyBag<T>> Bag { get; } = new();
            public List<T> Properties { get; } = new();
        }

        private static PropertyBag<ObjectTypeProperty> PopulatePropertyBag(ObjectType objectType)
        {
            var propertyBag = new PropertyBag<ObjectTypeProperty>();
            foreach (var objectTypeLevel in objectType.EnumerateHierarchy())
            {
                foreach (var objectTypeProperty in objectTypeLevel.Properties)
                {
                    if (objectTypeProperty != objectTypeLevel.AdditionalPropertiesProperty)
                    {
                        propertyBag.Properties.Add(objectTypeProperty);
                    }
                }
            }

            PopulatePropertyBag(propertyBag, GetPropertyNameAtDepth, 0);
            return propertyBag;
        }

        private static PropertyBag<InputModelProperty> PopulatePropertyBag(IEnumerable<InputModelProperty> properties)
        {
            var propertyBag = new PropertyBag<InputModelProperty>();
            foreach (var property in properties)
            {
                propertyBag.Properties.Add(property);
            }

            PopulatePropertyBag(propertyBag, GetPropertyNameAtDepth, 0);
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

        private static string? GetPropertyNameAtDepth(InputModelProperty property, int depthIndex)
            => property is { FlattenedNames: { } inputFlattenedNames } && inputFlattenedNames.Count > depthIndex + 1
                ? inputFlattenedNames[depthIndex]
                : null;

        private static string? GetPropertyNameAtDepth(ObjectTypeProperty property, int depthIndex)
        {
            if (property.SerializationMapping is {SerializationPath: {} serializationPath} && serializationPath.Count > depthIndex + 1)
            {
                return serializationPath[depthIndex];
            }

            if (property.SchemaProperty is {FlattenedNames: {} schemaFlattenedNames} && schemaFlattenedNames.Count > depthIndex + 1)
            {
                return schemaFlattenedNames.ElementAt(depthIndex);
            }

            if (property.InputModelProperty is {} inputModelProperty)
            {
                return GetPropertyNameAtDepth(inputModelProperty, depthIndex);
            }

            return null;
        }

        private JsonAdditionalPropertiesSerialization? CreateAdditionalProperties(ObjectType objectType)
        {
            ObjectTypeProperty? additionalPropertiesProperty = null;
            foreach (var obj in objectType.EnumerateHierarchy())
            {
                additionalPropertiesProperty = obj.AdditionalPropertiesProperty ?? (obj as SerializableObjectType)?.RawDataField;
                if (additionalPropertiesProperty != null)
                {
                    break;
                }
            }

            if (additionalPropertiesProperty == null)
            {
                return null;
            }

            var dictionaryValueType = additionalPropertiesProperty.Declaration.Type.Arguments[1];
            Debug.Assert(!dictionaryValueType.IsNullable, $"{typeof(JsonSerializationMethodsBuilder)} implicitly relies on {additionalPropertiesProperty.Declaration.Name} dictionary value being non-nullable");
            var valueSerialization = new JsonValueSerialization(dictionaryValueType, SerializationFormat.Default, true);

            return new JsonAdditionalPropertiesSerialization(
                    additionalPropertiesProperty,
                    valueSerialization,
                    new CSharpType(typeof(Dictionary<,>), additionalPropertiesProperty.Declaration.Type.Arguments));
        }
    }
}
