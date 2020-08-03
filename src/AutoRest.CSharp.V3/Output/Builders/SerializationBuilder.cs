// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Serialization.Json;
using AutoRest.CSharp.V3.Output.Models.Serialization.Xml;
using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Output.Builders
{
    internal class SerializationBuilder
    {
        public ObjectSerialization BuildObject(KnownMediaType mediaType, ObjectSchema objectSchema, ObjectType type)
        {
            switch (mediaType)
            {
                case KnownMediaType.Json:
                    return BuildJsonObjectSerialization(objectSchema, type);
                case KnownMediaType.Xml:
                    return BuildXmlObjectSerialization(objectSchema, type);
                default:
                    throw new NotImplementedException(mediaType.ToString());
            }
        }

        public ObjectSerialization Build(KnownMediaType mediaType, Schema schema, CSharpType type)
        {
            switch (mediaType)
            {
                case KnownMediaType.Json:
                    return BuildSerialization(schema, type);
                case KnownMediaType.Xml:
                    return BuildXmlElementSerialization(schema, type, schema.XmlName ?? schema.Name, true);
                default:
                    throw new NotImplementedException(mediaType.ToString());
            }
        }

        private XmlElementSerialization BuildXmlElementSerialization(Schema schema, CSharpType type, string? name, bool isRoot)
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
                        TypeFactory.GetImplementationType(type),
                        BuildXmlElementSerialization(arraySchema.ElementType, TypeFactory.GetElementType(type), null, false),
                        xmlName,
                        wrapped);

                case DictionarySchema dictionarySchema:
                    return new XmlDictionarySerialization(
                        TypeFactory.GetImplementationType(type),
                        BuildXmlElementSerialization(dictionarySchema.ElementType,TypeFactory.GetElementType(type), null, false),
                        xmlName);
                default:
                    return new XmlElementValueSerialization(xmlName, BuildXmlValueSerialization(schema, type));
            }
        }

        private XmlValueSerialization BuildXmlValueSerialization(Schema schema, CSharpType type)
        {
            return new XmlValueSerialization(type, BuilderHelpers.GetSerializationFormat(schema));
        }

        private JsonSerialization BuildSerialization(Schema schema, CSharpType type)
        {
            if (type.IsFrameworkType && type.FrameworkType == typeof(JsonElement))
            {
                return new JsonValueSerialization(
                    type,
                    BuilderHelpers.GetSerializationFormat(schema), type.IsNullable);
            }

            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return BuildSerialization(constantSchema.ValueType, type);
                case ArraySchema arraySchema:
                    return new JsonArraySerialization(
                        TypeFactory.GetImplementationType(type),
                        BuildSerialization(arraySchema.ElementType, TypeFactory.GetElementType(type)),
                        type.IsNullable);
                case DictionarySchema dictionarySchema:
                    return new JsonDictionarySerialization(
                        TypeFactory.GetImplementationType(type),
                        BuildSerialization(dictionarySchema.ElementType, TypeFactory.GetElementType(type)),
                        type.IsNullable);
                default:
                    return new JsonValueSerialization(
                        type,
                        BuilderHelpers.GetSerializationFormat(schema),
                        type.IsNullable);
            }
        }

        private XmlObjectSerialization BuildXmlObjectSerialization(ObjectSchema objectSchema, ObjectType objectType)
        {
            List<XmlObjectElementSerialization> elements = new List<XmlObjectElementSerialization>();
            List<XmlObjectAttributeSerialization> attributes = new List<XmlObjectAttributeSerialization>();
            List<XmlObjectArraySerialization> embeddedArrays = new List<XmlObjectArraySerialization>();
            XmlObjectContentSerialization? contentSerialization = null;

            foreach (var objectTypeLevel in objectType.EnumerateHierarchy())
            {
                foreach (ObjectTypeProperty objectProperty in objectTypeLevel.Properties)
                {
                    var property = objectProperty.SchemaProperty;
                    if (property == null)
                    {
                        continue;
                    }

                    var name = property.SerializedName;
                    var isAttribute = property.Schema.Serialization?.Xml?.Attribute == true;
                    var isContent = property.Schema.Serialization?.Xml?.Text == true;

                    if (isContent)
                    {
                        contentSerialization = new XmlObjectContentSerialization(
                            objectProperty,
                            BuildXmlValueSerialization(property.Schema, objectProperty.Declaration.Type));
                    }
                    else if (isAttribute)
                    {
                        attributes.Add(
                            new XmlObjectAttributeSerialization(
                                name,
                                objectProperty,
                                BuildXmlValueSerialization(property.Schema, objectProperty.Declaration.Type)
                            )
                        );
                    }
                    else
                    {
                        XmlElementSerialization valueSerialization = BuildXmlElementSerialization(property.Schema, objectProperty.Declaration.Type, name, false);

                        if (valueSerialization is XmlArraySerialization arraySerialization)
                        {
                            embeddedArrays.Add(new XmlObjectArraySerialization(objectProperty, arraySerialization));
                        }
                        else
                        {
                            elements.Add(
                                new XmlObjectElementSerialization(
                                    objectProperty,
                                    valueSerialization
                                )
                            );
                        }
                    }
                }
            }

            return new XmlObjectSerialization(
                objectSchema.Serialization?.Xml?.Name ?? objectSchema.Language.Default.Name,
                objectType.Type, elements.ToArray(), attributes.ToArray(), embeddedArrays.ToArray(),
                contentSerialization
                );
        }

        private IEnumerable<JsonPropertySerialization> GetPropertySerializationsFromBag(PropertyBag propertyBag, ObjectType objectType)
        {
            foreach (Property property in propertyBag.Properties)
            {
                var objectProperty = objectType.GetPropertyForSchemaProperty(property, includeParents: true);

                yield return new JsonPropertySerialization(
                    property.SerializedName,
                    property.IsRequired,
                    property.IsReadOnly,
                    objectProperty,
                    BuildSerialization(property.Schema, objectProperty.ValueType)
                    );
            }

            foreach ((string name, PropertyBag innerBag) in propertyBag.Bag)
            {
                JsonPropertySerialization[] serializationProperties = GetPropertySerializationsFromBag(innerBag, objectType).ToArray();
                JsonObjectSerialization objectSerialization = new JsonObjectSerialization(null, serializationProperties, null, false);
                yield return new JsonPropertySerialization(name, false, false, null, objectSerialization);
            }
        }

        private JsonObjectSerialization BuildJsonObjectSerialization(ObjectSchema objectSchema, ObjectType objectType)
        {
            PropertyBag propertyBag = new PropertyBag();
            foreach (var objectTypeLevel in objectType.EnumerateHierarchy())
            {
                foreach (var objectTypeProperty in objectTypeLevel.Properties)
                {
                    var schemaProperty = objectTypeProperty.SchemaProperty;
                    if (schemaProperty != null)
                    {
                        propertyBag.Properties.Add(schemaProperty);
                    }
                }
            }

            PopulatePropertyBag(propertyBag, 0);
            return new JsonObjectSerialization(
                objectType.Type,
                GetPropertySerializationsFromBag(propertyBag, objectType).ToArray(),
                CreateAdditionalProperties(objectSchema, objectType),
                false);
        }

        private class PropertyBag
        {
            public Dictionary<string, PropertyBag> Bag { get; } = new Dictionary<string, PropertyBag>();
            public List<Property> Properties { get; } = new List<Property>();
        }

        private static void PopulatePropertyBag(PropertyBag propertyBag, int depthIndex)
        {
            foreach (Property property in propertyBag.Properties.ToArray())
            {
                if (depthIndex >= (property.FlattenedNames?.Count ?? 0) - 1)
                {
                    continue;
                }

                string name = property!.FlattenedNames.ElementAt(depthIndex);
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

            var valueSerialization = BuildSerialization(
                inheritedDictionarySchema.ElementType,
                TypeFactory.GetElementType(additionalPropertiesProperty.Declaration.Type));

            return new JsonAdditionalPropertiesSerialization(
                    additionalPropertiesProperty,
                    valueSerialization,
                    new CSharpType(typeof(Dictionary<,>), additionalPropertiesProperty.Declaration.Type.Arguments));
        }
    }
}
