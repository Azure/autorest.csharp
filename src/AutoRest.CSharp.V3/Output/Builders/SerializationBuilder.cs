// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly TypeFactory _typeFactory;

        public SerializationBuilder(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public ObjectSerialization BuildObject(KnownMediaType mediaType, ObjectSchema objectSchema, ObjectType type, TypeFlags typeFlags)
        {
            switch (mediaType)
            {
                case KnownMediaType.Json:
                    return BuildJsonObjectSerialization(objectSchema, type, typeFlags);
                case KnownMediaType.Xml:
                    return BuildXmlObjectSerialization(objectSchema, type);
                default:
                    throw new NotImplementedException(mediaType.ToString());
            }
        }

        public ObjectSerialization Build(KnownMediaType mediaType, Schema schema, bool isNullable, TypeFlags typeFlags)
        {
            switch (mediaType)
            {
                case KnownMediaType.Json:
                    return BuildSerialization(schema, isNullable, typeFlags);
                case KnownMediaType.Xml:
                    return BuildXmlElementSerialization(schema, isNullable, schema.XmlName ?? schema.Name, true);
                default:
                    throw new NotImplementedException(mediaType.ToString());
            }
        }

        private XmlElementSerialization BuildXmlElementSerialization(Schema schema, bool isNullable, string? name, bool isRoot)
        {
            string xmlName =
                schema.XmlName ??
                name ??
                schema.Name;

            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return BuildXmlElementSerialization(constantSchema.ValueType, constantSchema.Value.Value == null, name, false);
                case ArraySchema arraySchema:
                    var wrapped = isRoot || arraySchema.Serialization?.Xml?.Wrapped == true;

                    return new XmlArraySerialization(
                        _typeFactory.CreateType(arraySchema, isNullable: false, TypeFlags.Implementation),
                        BuildXmlElementSerialization(arraySchema.ElementType, false, null, false),
                        xmlName,
                        wrapped);

                case DictionarySchema dictionarySchema:
                    return new XmlDictionarySerialization(
                        _typeFactory.CreateType(dictionarySchema, isNullable: false, TypeFlags.Implementation),
                        BuildXmlElementSerialization(dictionarySchema.ElementType, false, null, false),
                        xmlName);
                default:
                    return new XmlElementValueSerialization(xmlName, BuildXmlValueSerialization(schema, isNullable));
            }
        }

        private XmlValueSerialization BuildXmlValueSerialization(Schema schema, bool isNullable)
        {
            return new XmlValueSerialization(_typeFactory.CreateType(schema, isNullable),
                    BuilderHelpers.GetSerializationFormat(schema));
        }

        private JsonSerialization BuildSerialization(Schema schema, bool isNullable, TypeFlags typeFlags)
        {
            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return BuildSerialization(constantSchema.ValueType, constantSchema.Value.Value == null, typeFlags);
                case ArraySchema arraySchema:
                    return new JsonArraySerialization(
                        _typeFactory.CreateType(arraySchema, isNullable, typeFlags | TypeFlags.Implementation),
                        BuildSerialization(arraySchema.ElementType, false, typeFlags));
                case DictionarySchema dictionarySchema:
                    return new JsonDictionarySerialization(
                        _typeFactory.CreateType(dictionarySchema, isNullable, typeFlags | TypeFlags.Implementation),
                        BuildSerialization(dictionarySchema.ElementType, false, typeFlags)
                        );
                default:
                    return new JsonValueSerialization(
                        _typeFactory.CreateType(schema, isNullable),
                        BuilderHelpers.GetSerializationFormat(schema));
            }
        }

        private XmlObjectSerialization BuildXmlObjectSerialization(ObjectSchema objectSchema, ObjectType objectType)
        {
            List<XmlObjectElementSerialization> elements = new List<XmlObjectElementSerialization>();
            List<XmlObjectAttributeSerialization> attributes = new List<XmlObjectAttributeSerialization>();
            List<XmlObjectArraySerialization> embeddedArrays = new List<XmlObjectArraySerialization>();
            foreach (var schema in EnumerateHierarchy(objectSchema))
            {
                foreach (Property property in schema.Properties!)
                {
                    var name = property.SerializedName;
                    var isAttribute = property.Schema.Serialization?.Xml?.Attribute == true;

                    ObjectTypeProperty objectProperty = objectType.GetPropertyForSchemaProperty(property, includeParents: true);

                    if (isAttribute)
                    {
                        attributes.Add(
                            new XmlObjectAttributeSerialization(
                                name,
                                objectProperty,
                                BuildXmlValueSerialization(property.Schema, property.IsNullable())
                            )
                        );
                    }
                    else
                    {
                        XmlElementSerialization valueSerialization = BuildXmlElementSerialization(property.Schema, property.IsNullable(), name, false);

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
                objectType.Type, elements.ToArray(), attributes.ToArray(), embeddedArrays.ToArray()
                );
        }

        private IEnumerable<JsonPropertySerialization> GetPropertySerializationsFromBag(PropertyBag propertyBag, ObjectType objectType, TypeFlags typeFlags)
        {
            foreach (Property property in propertyBag.Properties)
            {
                var objectProperty = objectType.GetPropertyForSchemaProperty(property, includeParents: true);

                yield return new JsonPropertySerialization(
                    property.SerializedName,
                    objectProperty,
                    BuildSerialization(property.Schema, property.IsNullable(), typeFlags)
                    );
            }

            foreach ((string name, PropertyBag innerBag) in propertyBag.Bag)
            {
                JsonPropertySerialization[] serializationProperties = GetPropertySerializationsFromBag(innerBag, objectType, typeFlags).ToArray();
                JsonObjectSerialization objectSerialization = new JsonObjectSerialization(null, serializationProperties, null);
                yield return new JsonPropertySerialization(name, null, objectSerialization);
            }
        }

        private JsonObjectSerialization BuildJsonObjectSerialization(ObjectSchema objectSchema, ObjectType objectType, TypeFlags typeFlags)
        {
            PropertyBag propertyBag = new PropertyBag();
            propertyBag.Properties.AddRange(EnumerateHierarchy(objectSchema).SelectMany(s => s.Properties!));
            PopulatePropertyBag(propertyBag, 0);
            return new JsonObjectSerialization(
                objectType.Type,
                GetPropertySerializationsFromBag(propertyBag, objectType, typeFlags).ToArray(),
                CreateAdditionalProperties(objectSchema, objectType, typeFlags));
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

        private static IEnumerable<ObjectSchema> EnumerateHierarchy(ObjectSchema schema)
        {
            yield return schema;
            foreach (ComplexSchema parent in schema.Parents!.All)
            {
                if (parent is ObjectSchema objectSchema)
                {
                    yield return objectSchema;
                }
            }
        }

        private JsonAdditionalPropertiesSerialization? CreateAdditionalProperties(ObjectSchema objectSchema, ObjectType objectType, TypeFlags typeFlags)
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

            var valueSerialization = BuildSerialization(inheritedDictionarySchema.ElementType, false, typeFlags);

            return  new JsonAdditionalPropertiesSerialization(
                    additionalPropertiesProperty,
                    valueSerialization);
        }
    }
}
