// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Serialization.Json;
using AutoRest.CSharp.V3.Output.Models.Serialization.Xml;
using AutoRest.CSharp.V3.Output.Models.TypeReferences;

namespace AutoRest.CSharp.V3.Output.Builders
{
    internal static class SerializationBuilder
    {
        public static ObjectSerialization BuildObject(KnownMediaType mediaType, ObjectSchema objectSchema, bool isNullable)
        {
            TypeReference schemaTypeReference = BuilderHelpers.CreateType(objectSchema, isNullable);

            switch (mediaType)
            {
                case KnownMediaType.Json:
                    return BuildJsonObjectSerialization(objectSchema, schemaTypeReference, isNullable);
                case KnownMediaType.Xml:
                    return BuildXmlObjectSerialization(objectSchema, schemaTypeReference, isNullable);
                default:
                    throw new NotImplementedException(mediaType.ToString());
            }
        }

        public static ObjectSerialization Build(KnownMediaType mediaType, Schema schema, bool isNullable)
        {
            switch (mediaType)
            {
                case KnownMediaType.Json:
                    return BuildSerialization(schema, isNullable);
                case KnownMediaType.Xml:
                    return BuildXmlElementSerialization(schema, isNullable, schema.XmlName ?? schema.Name, true);
                default:
                    throw new NotImplementedException(mediaType.ToString());
            }
        }

        private static XmlElementSerialization BuildXmlElementSerialization(Schema schema, bool isNullable, string? name, bool isRoot)
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
                        BuilderHelpers.CreateType(arraySchema, isNullable),
                        BuildXmlElementSerialization(arraySchema.ElementType, false, null, false),
                        xmlName,
                        wrapped);

                case DictionarySchema dictionarySchema:
                    return new XmlDictionarySerialization(
                        BuilderHelpers.CreateType(dictionarySchema, isNullable),
                        BuildXmlElementSerialization(dictionarySchema.ElementType, false, "!dictionary-item", false),
                        xmlName);
                default:
                    return new XmlElementValueSerialization(xmlName, BuildXmlValueSerialization(schema, isNullable));
            }
        }

        private static XmlValueSerialization BuildXmlValueSerialization(Schema schema, bool isNullable)
        {
            return new XmlValueSerialization(BuilderHelpers.CreateType(schema, isNullable),
                    BuilderHelpers.GetSerializationFormat(schema));
        }

        private static JsonSerialization BuildSerialization(Schema schema, bool isNullable, bool? isBag = null)
        {
            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return BuildSerialization(constantSchema.ValueType, constantSchema.Value.Value == null);
                case ArraySchema arraySchema:
                    return new JsonArraySerialization(
                        BuilderHelpers.CreateType(arraySchema, isNullable), BuildSerialization(arraySchema.ElementType, false));
                case DictionarySchema dictionarySchema:
                    var dictionaryElementTypeReference = new DictionaryTypeReference(
                        new FrameworkTypeReference(typeof(string)),
                        BuilderHelpers.CreateType(dictionarySchema.ElementType, false),
                        isNullable);

                    return new JsonObjectSerialization(dictionaryElementTypeReference, Array.Empty<JsonPropertySerialization>(),
                        new JsonDynamicPropertiesSerialization(BuildSerialization(dictionarySchema.ElementType, false)));
                case ObjectSchema objectSchema when isBag == true:
                    JsonPropertySerialization[] serializationProperties = objectSchema.Properties.Select(CreateJsonPropertySerialization).ToArray();
                    return new JsonObjectSerialization(BuilderHelpers.CreateType(objectSchema, isNullable), serializationProperties, null);
                default:
                    return new JsonValueSerialization(
                        BuilderHelpers.CreateType(schema, isNullable),
                        BuilderHelpers.GetSerializationFormat(schema));
            }
        }

        private static XmlObjectSerialization BuildXmlObjectSerialization(ObjectSchema objectSchema, TypeReference schemaTypeReference, bool isNullable)
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

                    if (isAttribute)
                    {
                        attributes.Add(
                            new XmlObjectAttributeSerialization(
                                name,
                                property.CSharpName(),
                                BuildXmlValueSerialization(property.Schema, property.IsNullable())
                            )
                        );
                    }
                    else
                    {
                        XmlElementSerialization valueSerialization = BuildXmlElementSerialization(property.Schema, property.IsNullable(), name, false);

                        if (valueSerialization is XmlArraySerialization arraySerialization)
                        {
                            embeddedArrays.Add(new XmlObjectArraySerialization(property.CSharpName(), arraySerialization));
                        }
                        else
                        {
                            elements.Add(
                                new XmlObjectElementSerialization(
                                    property.CSharpName(),
                                    valueSerialization
                                )
                            );
                        }
                    }
                }
            }

            return new XmlObjectSerialization(
                objectSchema.Serialization?.Xml?.Name ?? objectSchema.Language.Default.Name,
                schemaTypeReference, elements.ToArray(), attributes.ToArray(), embeddedArrays.ToArray());
        }

        private static JsonPropertySerialization CreateJsonPropertySerialization(Property property) => new JsonPropertySerialization(
            property.SerializedName,
            property.CSharpName(),
            BuildSerialization(property.Schema, property.IsNullable(), property.IsBag),
            property.IsBag
        );

        private static JsonObjectSerialization BuildJsonObjectSerialization(ObjectSchema objectSchema, TypeReference schemaTypeReference, bool isNullable)
        {
            List<JsonPropertySerialization> serializationProperties = new List<JsonPropertySerialization>();
            foreach (var schema in EnumerateHierarchy(objectSchema))
            {
                foreach (Property property in AggregateProperties(schema))
                {
                    serializationProperties.Add(CreateJsonPropertySerialization(property));
                }
            }

            return new JsonObjectSerialization(schemaTypeReference, serializationProperties.ToArray(), CreateAdditionalProperties(objectSchema));
        }

        private class PropertyBag
        {
            public Dictionary<string, PropertyBag> Bag { get; } = new Dictionary<string, PropertyBag>();
            public List<Property> Properties { get; } = new List<Property>();
        }

        private static IEnumerable<Property> AggregateProperties(ObjectSchema schema)
        {
            PropertyBag propertyBag = new PropertyBag();
            propertyBag.Properties.AddRange(schema.Properties ?? Array.Empty<Property>());
            PopulatePropertyBag(propertyBag, 0);
            return propertyBag.Properties;
        }

        private static Property CreatePropertyFromPropertyBag(string name, PropertyBag bag) => new Property
        {
            IsBag = true,
            SerializedName = name,
            Schema = new ObjectSchema
            {
                Properties = bag.Properties,
                Language = new Languages { Default = new Language { Name = $"SYNTHETIC-{name}" } },
                Type = AllSchemaTypes.Object
            },
            Required = true,
            Language = new Languages { Default = new Language { Name = name } }
        };

        private static void PopulatePropertyBag(PropertyBag propertyBag, int depthIndex)
        {
            foreach (Property property in propertyBag.Properties.ToArray())
            {
                if (!(property.FlattenedNames?.Any() ?? false) || depthIndex >= property.FlattenedNames!.Count - 1)
                {
                    continue;
                }

                string name = property.FlattenedNames.ElementAt(depthIndex);
                if (!propertyBag.Bag.TryGetValue(name, out PropertyBag? namedBag))
                {
                    namedBag = new PropertyBag();
                    propertyBag.Bag.Add(name, namedBag);
                }

                namedBag.Properties.Add(property);
                propertyBag.Properties.Remove(property);
            }

            foreach ((string name, PropertyBag innerBag) in propertyBag.Bag)
            {
                PopulatePropertyBag(innerBag, depthIndex + 1);
                propertyBag.Properties.Add(CreatePropertyFromPropertyBag(name, innerBag));
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

        private static JsonDynamicPropertiesSerialization? CreateAdditionalProperties(ObjectSchema objectSchema)
        {
            var inheritedDictionarySchema = objectSchema.Parents!.All.OfType<DictionarySchema>().FirstOrDefault();

            if (inheritedDictionarySchema == null)
            {
                return null;
            }

            return new JsonDynamicPropertiesSerialization(
                BuildSerialization(inheritedDictionarySchema.ElementType, false)
            );
        }
    }
}
