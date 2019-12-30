// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Plugins;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class SerializationBuilder
    {
        public static ObjectSerialization BuildObject(KnownMediaType mediaType, ObjectSchema objectSchema, bool isNullable)
        {
            ClientTypeReference schemaTypeReference = ClientModelBuilderHelpers.CreateType(objectSchema, isNullable);

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
                    return BuildXmlSerialization(schema, isNullable);
                default:
                    throw new NotImplementedException(mediaType.ToString());
            }
        }

        private static XmlSerialization BuildXmlSerialization(Schema schema, bool isNullable)
        {
            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return BuildXmlSerialization(constantSchema.ValueType, constantSchema.Value.Value == null);
                case ArraySchema arraySchema:
                    string xmlName =
                        arraySchema.ElementType.Serialization?.Xml?.Name ??
                        arraySchema.ElementType.Language.Default.Name;

                    return new XmlArraySerialization(
                        ClientModelBuilderHelpers.CreateType(arraySchema, isNullable),
                        BuildXmlSerialization(arraySchema.ElementType, false),
                        xmlName);
                case DictionarySchema dictionarySchema:
                    return new XmlDictionarySerialization(
                        ClientModelBuilderHelpers.CreateType(dictionarySchema, isNullable),
                        BuildXmlSerialization(dictionarySchema.ElementType, false));
                default:
                    return new XmlValueSerialization(
                        ClientModelBuilderHelpers.CreateType(schema, isNullable),
                        ClientModelBuilderHelpers.GetSerializationFormat(schema));
            }
        }

        private static JsonSerialization BuildSerialization(Schema schema, bool isNullable)
        {
            switch (schema)
            {
                case ConstantSchema constantSchema:
                    return BuildSerialization(constantSchema.ValueType, constantSchema.Value.Value == null);
                case ArraySchema arraySchema:
                    return new JsonArraySerialization(
                        ClientModelBuilderHelpers.CreateType(arraySchema, isNullable), BuildSerialization(arraySchema.ElementType, false));
                case DictionarySchema dictionarySchema:
                    var dictionaryElementTypeReference = new DictionaryTypeReference(
                        new FrameworkTypeReference(typeof(string)),
                        ClientModelBuilderHelpers.CreateType(dictionarySchema.ElementType, false),
                        isNullable);

                    return new JsonObjectSerialization(dictionaryElementTypeReference, Array.Empty<JsonPropertySerialization>(),
                        new JsonDynamicPropertiesSerialization(BuildSerialization(dictionarySchema.ElementType, false)));
                default:
                    return new JsonValueSerialization(
                        ClientModelBuilderHelpers.CreateType(schema, isNullable),
                        ClientModelBuilderHelpers.GetSerializationFormat(schema));
            }
        }

        private static XmlObjectSerialization BuildXmlObjectSerialization(ObjectSchema objectSchema, ClientTypeReference schemaTypeReference, bool isNullable)
        {
            List<XmlObjectElementSerialization> elements = new List<XmlObjectElementSerialization>();
            List<XmlObjectAttributeSerialization> attributes = new List<XmlObjectAttributeSerialization>();
            List<XmlObjectArraySerialization> embeddedArrays = new List<XmlObjectArraySerialization>();
            foreach (var schema in EnumerateHierarchy(objectSchema))
            {
                foreach (Property property in schema.Properties!)
                {
                    var wrapped = property.Schema.Serialization?.Xml?.Wrapped == true;
                    var name = wrapped ? property.SerializedName : property.Schema.Serialization?.Xml?.Name ?? property.SerializedName;
                    var isAttribute = property.Schema.Serialization?.Xml?.Attribute == true;

                    XmlSerialization valueSerialization = BuildXmlSerialization(property.Schema, property.IsNullable());

                    if (isAttribute)
                    {
                        attributes.Add(
                            new XmlObjectAttributeSerialization(
                                name,
                                property.CSharpName(),
                                (XmlValueSerialization)valueSerialization
                            )
                        );
                    }
                    else
                    {
                        if (!wrapped && valueSerialization is XmlArraySerialization arraySerialization)
                        {
                            embeddedArrays.Add(new XmlObjectArraySerialization(property.CSharpName(), arraySerialization));
                        }
                        else
                        {
                            elements.Add(
                                new XmlObjectElementSerialization(
                                    name,
                                    property.CSharpName(),
                                    valueSerialization
                                )
                            );
                        }
                    }
                }
            }

            return new XmlObjectSerialization(objectSchema.Serialization?.Xml?.Name ?? "Auto" + objectSchema.Language.Default.Name,
                schemaTypeReference, elements.ToArray(), attributes.ToArray(), embeddedArrays.ToArray());
        }

        private static JsonObjectSerialization BuildJsonObjectSerialization(ObjectSchema objectSchema, ClientTypeReference schemaTypeReference, bool isNullable)
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
