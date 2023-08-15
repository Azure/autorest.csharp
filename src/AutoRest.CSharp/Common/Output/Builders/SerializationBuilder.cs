// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Models;

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

        public static SerializationFormat GetSerializationFormat(InputType type)
            => type switch
            {
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
            BodyMediaType.Json => BuildJsonSerialization(inputType, type, false),
            BodyMediaType.Xml => BuildXmlElementSerialization(inputType, type, null, true),
            _ => throw new NotImplementedException(bodyMediaType.ToString())
        };

        private static XmlElementSerialization BuildXmlElementSerialization(InputType inputType, CSharpType type, string? name, bool isRoot)
        {
            switch (inputType)
            {
                case InputListType listType:
                    var wrapped = isRoot || listType.IsXmlSerializationWrapped;
                    var arrayElement = BuildXmlElementSerialization(listType.ElementType, TypeFactory.GetElementType(type), null, false);
                    return new XmlArraySerialization(TypeFactory.GetImplementationType(type), arrayElement, name ?? inputType.Name, wrapped);
                case InputDictionaryType dictionaryType:
                    var valueElement = BuildXmlElementSerialization(dictionaryType.ValueType, TypeFactory.GetElementType(type), null, false);
                    return new XmlDictionarySerialization(TypeFactory.GetImplementationType(type), valueElement, name ?? inputType.Name);
                case CodeModelType cmt:
                    return BuildXmlElementSerialization(cmt.Schema, type, null, isRoot);
                default:
                    return new XmlElementValueSerialization(name ?? inputType.Name, new XmlValueSerialization(type, GetSerializationFormat(inputType)));
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
                InputListType listType => new JsonArraySerialization(TypeFactory.GetImplementationType(valueType), BuildJsonSerialization(listType.ElementType, TypeFactory.GetElementType(valueType), true), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType)),
                InputDictionaryType dictionaryType => new JsonDictionarySerialization(TypeFactory.GetImplementationType(valueType), BuildJsonSerialization(dictionaryType.ValueType, TypeFactory.GetElementType(valueType), true), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType)),
                _ => new JsonValueSerialization(valueType, GetSerializationFormat(inputType, valueType), valueType.IsNullable || (isCollectionElement && !valueType.IsValueType)) // nullable CSharp type like int?, Etag?, and reference type in collection
            };
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
                    return new JsonArraySerialization(
                        TypeFactory.GetImplementationType(type),
                        BuildSerialization(arraySchema.ElementType, TypeFactory.GetElementType(type), true),
                        type.IsNullable);
                case DictionarySchema dictionarySchema:
                    return new JsonDictionarySerialization(
                        TypeFactory.GetImplementationType(type),
                        BuildSerialization(dictionarySchema.ElementType, TypeFactory.GetElementType(type), true),
                        type.IsNullable);
                default:
                    JsonSerializationOptions options = IsManagedServiceIdentityV3(schema, type) ? JsonSerializationOptions.UseManagedServiceIdentityV3 : JsonSerializationOptions.None;
                    return new JsonValueSerialization(type, BuilderHelpers.GetSerializationFormat(schema), type.IsNullable || (isCollectionElement && !type.IsValueType), options);
            }
        }

        public static XmlObjectSerialization BuildXmlObjectSerialization(string serializationName, ObjectType objectType)
        {
            var elements = new List<XmlObjectElementSerialization>();
            var attributes = new List<XmlObjectAttributeSerialization>();
            var embeddedArrays = new List<XmlObjectArraySerialization>();
            XmlObjectContentSerialization? contentSerialization = null;

            foreach (var objectTypeLevel in objectType.EnumerateHierarchy())
            {
                foreach (ObjectTypeProperty objectProperty in objectTypeLevel.Properties)
                {
                    if (objectProperty.SchemaProperty is {} property)
                    {
                        var isAttribute = property.Schema.Serialization?.Xml?.Attribute == true;
                        var isContent = property.Schema.Serialization?.Xml?.Text == true;
                        var format = BuilderHelpers.GetSerializationFormat(property.Schema);
                        var propertyName = property.SerializedName;

                        if (isContent)
                        {
                            contentSerialization = new XmlObjectContentSerialization(objectProperty, new XmlValueSerialization(objectProperty.Declaration.Type, format));
                        }
                        else if (isAttribute)
                        {
                            attributes.Add(new XmlObjectAttributeSerialization(propertyName, objectProperty, new XmlValueSerialization(objectProperty.Declaration.Type, format)));
                        }
                        else
                        {
                            var valueSerialization = BuildXmlElementSerialization(property.Schema, objectProperty.Declaration.Type, propertyName, false);
                            if (valueSerialization is XmlArraySerialization arraySerialization)
                            {
                                embeddedArrays.Add(new XmlObjectArraySerialization(objectProperty, arraySerialization));
                            }
                            else
                            {
                                elements.Add(new XmlObjectElementSerialization(objectProperty, valueSerialization));
                            }
                        }
                    }
                    else if (objectProperty.InputModelProperty is {} inputModelProperty)
                    {
                        var isAttribute = (inputModelProperty.Type as InputModelType)?.Serialization.Xml?.IsAttribute == true;
                        var isContent = (inputModelProperty.Type as InputModelType)?.Serialization.Xml?.IsContent == true;
                        var format = GetSerializationFormat(inputModelProperty.Type);
                        var propertyName = inputModelProperty.SerializedName;

                        if (isContent)
                        {
                            contentSerialization = new XmlObjectContentSerialization(objectProperty, new XmlValueSerialization(objectProperty.Declaration.Type, format));
                        }
                        else if (isAttribute)
                        {
                            attributes.Add(new XmlObjectAttributeSerialization(propertyName, objectProperty, new XmlValueSerialization(objectProperty.Declaration.Type, format)));
                        }
                        else
                        {
                            var valueSerialization = BuildXmlElementSerialization(inputModelProperty.Type, objectProperty.Declaration.Type, propertyName, false);
                            if (valueSerialization is XmlArraySerialization arraySerialization)
                            {
                                embeddedArrays.Add(new XmlObjectArraySerialization(objectProperty, arraySerialization));
                            }
                            else
                            {
                                elements.Add(new XmlObjectElementSerialization(objectProperty, valueSerialization));
                            }
                        }
                    }
                }
            }

            return new XmlObjectSerialization(serializationName, objectType.Type, elements.ToArray(), attributes.ToArray(), embeddedArrays.ToArray(), contentSerialization);
        }

        private IEnumerable<JsonPropertySerialization> GetPropertySerializationsFromBag(PropertyBag propertyBag, SchemaObjectType objectType)
        {
            foreach (var objectProperty in propertyBag.Properties)
            {
                var property = objectProperty.SchemaProperty;
                if (property is null)
                {
                    continue;
                }

                var parameter = objectType.SerializationConstructor.FindParameterByInitializedProperty(objectProperty);
                if (parameter is null)
                {
                    throw new InvalidOperationException($"Serialization constructor of the type {objectType.Declaration.Name} has no parameter for {property.SerializedName} input property");
                }

                yield return new JsonPropertySerialization(
                    parameter.Name,
                    new MemberExpression(null, objectProperty.Declaration.Name),
                    property.SerializedName,
                    objectProperty.Declaration.Type,
                    objectProperty.ValueType,
                    BuildSerialization(property.Schema, objectProperty.Declaration.Type, false),
                    property.IsRequired,
                    property.IsReadOnly,
                    false,
                    customSerializationMethodName: objectProperty.SerializationMapping?.SerializationValueHook,
                    customDeserializationMethodName: objectProperty.SerializationMapping?.DeserializationValueHook);
            }

            foreach ((string name, PropertyBag innerBag) in propertyBag.Bag)
            {
                JsonPropertySerialization[] serializationProperties = GetPropertySerializationsFromBag(innerBag, objectType).ToArray();
                yield return new JsonPropertySerialization(name, serializationProperties);
            }
        }

        public static IReadOnlyList<JsonPropertySerialization> GetPropertySerializations(ModelTypeProvider model, InputModelType inputModel)
            => GetPropertySerializationsFromBag(PopulatePropertyBag(model), inputModel).ToArray();

        private static IEnumerable<JsonPropertySerialization> GetPropertySerializationsFromBag(PropertyBag propertyBag, InputModelType inputModel)
        {
            foreach (var property in propertyBag.Properties)
            {
                if (property.InputModelProperty is null)
                    continue;

                var declaredName = property.Declaration.Name;
                var serializedName = property.InputModelProperty.SerializedName ?? property.InputModelProperty.Name;
                var valueSerialization = BuildJsonSerialization(property.InputModelProperty.Type, property.ValueType, false);

                yield return new JsonPropertySerialization(
                    declaredName.ToVariableName(),
                    new MemberExpression(null, declaredName),
                    serializedName,
                    property.Declaration.Type,
                    property.ValueType.IsNullable && property.OptionalViaNullability ? property.ValueType.WithNullable(false) : property.ValueType,
                    valueSerialization,
                    property.IsRequired,
                    ShouldSkipSerialization(inputModel.Usage, property),
                    false,
                    customSerializationMethodName: property.SerializationMapping?.SerializationValueHook,
                    customDeserializationMethodName: property.SerializationMapping?.DeserializationValueHook);
            }

            foreach ((string name, PropertyBag innerBag) in propertyBag.Bag)
            {
                JsonPropertySerialization[] serializationProperties = GetPropertySerializationsFromBag(innerBag, inputModel).ToArray();
                yield return new JsonPropertySerialization(name, serializationProperties);
            }
        }

        private static bool ShouldSkipSerialization(InputModelTypeUsage inputModelUsage, ObjectTypeProperty property)
        {
            if (property.InputModelProperty!.IsDiscriminator)
            {
                return false;
            }

            if (property.InputModelProperty!.ConstantValue is not null)
            {
                return false;
            }

            if (property.InputModelProperty!.IsReadOnly)
            {
                return true;
            }

            if (property.Declaration.Type.IsCollectionType())
            {
                return inputModelUsage is InputModelTypeUsage.Output;
            }

            return property.IsReadOnly && inputModelUsage is not InputModelTypeUsage.Input;
        }

        public JsonObjectSerialization BuildJsonObjectSerialization(ObjectSchema objectSchema, SchemaObjectType objectType)
        {
            var propertyBag = PopulatePropertyBag(objectType);
            var properties = GetPropertySerializationsFromBag(propertyBag, objectType).ToArray();
            var additionalProperties = CreateAdditionalProperties(objectSchema, objectType);
            return new JsonObjectSerialization(objectType.Type, objectType.SerializationConstructor.Signature.Parameters, properties, additionalProperties, objectType.Discriminator, objectType.IncludeConverter);
        }

        private class PropertyBag
        {
            public Dictionary<string, PropertyBag> Bag { get; } = new();
            public List<ObjectTypeProperty> Properties { get; } = new();
        }

        private static PropertyBag PopulatePropertyBag(ObjectType objectType)
        {
            var propertyBag = new PropertyBag();
            foreach (var objectTypeLevel in objectType.EnumerateHierarchy())
            {
                foreach (var objectTypeProperty in objectTypeLevel.Properties)
                {
                    if (objectTypeProperty.SchemaProperty is not null || objectTypeProperty.InputModelProperty is not null)
                    {
                        propertyBag.Properties.Add(objectTypeProperty);
                    }
                }
            }

            PopulatePropertyBag(propertyBag, 0);
            return propertyBag;
        }

        private static void PopulatePropertyBag(PropertyBag propertyBag, int depthIndex)
        {
            var propertiesCopy = propertyBag.Properties.ToArray();
            foreach (var property in propertiesCopy)
            {
                var name = property.SchemaProperty is {FlattenedNames: {} schemaFlattenedNames} && schemaFlattenedNames.Count > depthIndex + 1
                    ? schemaFlattenedNames.ElementAt(depthIndex)
                    : property.InputModelProperty is {FlattenedNames: {} inputFlattenedNames} && inputFlattenedNames.Count > depthIndex + 1
                        ? inputFlattenedNames[depthIndex]
                        : null;

                if (name is null)
                {
                    continue;
                }

                if (!propertyBag.Bag.TryGetValue(name, out PropertyBag? namedBag))
                {
                    namedBag = new PropertyBag();
                    propertyBag.Bag.Add(name, namedBag);
                }

                namedBag.Properties.Add(property);
                propertyBag.Properties.Remove(property);
            }

            foreach (PropertyBag innerBag in propertyBag.Bag.Values)
            {
                PopulatePropertyBag(innerBag, depthIndex + 1);
            }
        }

        private JsonAdditionalPropertiesSerialization? CreateAdditionalProperties(ObjectSchema objectSchema, ObjectType objectType)
        {
            var inheritedDictionarySchema = objectSchema.Parents!.All.OfType<DictionarySchema>().FirstOrDefault();

            ObjectTypeProperty? additionalPropertiesProperty = null;
            foreach (var obj in objectType.EnumerateHierarchy())
            {
                additionalPropertiesProperty = obj.AdditionalPropertiesProperty;
                if (additionalPropertiesProperty != null)
                {
                    break;
                }
            }

            if (inheritedDictionarySchema == null || additionalPropertiesProperty == null)
            {
                return null;
            }

            var dictionaryValueType = additionalPropertiesProperty.Declaration.Type.Arguments[1];
            Debug.Assert(!dictionaryValueType.IsNullable, $"{typeof(JsonCodeWriterExtensions)} implicitly relies on {additionalPropertiesProperty.Declaration.Name} dictionary value being non-nullable");
            var valueSerialization = BuildSerialization(inheritedDictionarySchema.ElementType, dictionaryValueType, false);

            return new JsonAdditionalPropertiesSerialization(
                    additionalPropertiesProperty,
                    valueSerialization,
                    new CSharpType(typeof(Dictionary<,>), additionalPropertiesProperty.Declaration.Type.Arguments));
        }
    }
}
