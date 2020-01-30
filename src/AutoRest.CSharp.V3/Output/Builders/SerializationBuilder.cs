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


namespace AutoRest.CSharp.V3.Output.Builders
{
    internal class SerializationBuilder
    {
        private readonly TypeFactory _typeFactory;

        public SerializationBuilder(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public ObjectSerialization BuildObject(KnownMediaType mediaType, ObjectSchema objectSchema, bool isNullable)
        {
            CSharpType schemaTypeReference = _typeFactory.CreateType(objectSchema, isNullable);

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

        public ObjectSerialization Build(KnownMediaType mediaType, Schema schema, bool isNullable)
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
                        _typeFactory.CreateType(arraySchema, isNullable),
                        BuildXmlElementSerialization(arraySchema.ElementType, false, null, false),
                        xmlName,
                        wrapped);

                case DictionarySchema dictionarySchema:
                    return new XmlDictionarySerialization(
                        _typeFactory.CreateType(dictionarySchema, isNullable),
                        BuildXmlElementSerialization(dictionarySchema.ElementType, false, "!dictionary-item", false),
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

        private JsonSerialization BuildSerialization(Schema schema, bool isNullable)
        {
            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return BuildSerialization(constantSchema.ValueType, constantSchema.Value.Value == null);
                case ArraySchema arraySchema:
                    return new JsonArraySerialization(
                        _typeFactory.CreateType(arraySchema, isNullable), BuildSerialization(arraySchema.ElementType, false));
                case DictionarySchema dictionarySchema:
                    var dictionaryElementTypeReference = new CSharpType(typeof(Dictionary<,>),
                        isNullable,
                        new CSharpType(typeof(string)),
                        _typeFactory.CreateType(dictionarySchema.ElementType, false));

                    return new JsonObjectSerialization(dictionaryElementTypeReference, Array.Empty<JsonPropertySerialization>(),
                        new JsonDynamicPropertiesSerialization(BuildSerialization(dictionarySchema.ElementType, false)));
                default:
                    return new JsonValueSerialization(
                        _typeFactory.CreateType(schema, isNullable),
                        BuilderHelpers.GetSerializationFormat(schema));
            }
        }

        private XmlObjectSerialization BuildXmlObjectSerialization(ObjectSchema objectSchema, CSharpType schemaTypeReference, bool isNullable)
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

        private JsonObjectSerialization BuildJsonObjectSerialization(ObjectSchema objectSchema, CSharpType schemaTypeReference, bool isNullable)
        {
            List<JsonPropertySerialization> serializationProperties = new List<JsonPropertySerialization>();
            foreach (var schema in EnumerateHierarchy(objectSchema))
            {
                foreach (Property property in schema.Properties!)
                {
                    JsonPropertySerialization propertySerialization = new JsonPropertySerialization(
                        property.SerializedName,
                        property.CSharpName(),
                        BuildSerialization(property.Schema, property.IsNullable())
                    );

                    serializationProperties.Add(propertySerialization);
                }
            }

            return new JsonObjectSerialization(schemaTypeReference, serializationProperties.ToArray(), CreateAdditionalProperties(objectSchema));
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

        private JsonDynamicPropertiesSerialization? CreateAdditionalProperties(ObjectSchema objectSchema)
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
