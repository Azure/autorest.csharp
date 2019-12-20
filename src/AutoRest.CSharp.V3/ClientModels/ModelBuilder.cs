// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Plugins;
using Microsoft.VisualBasic;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ModelBuilder
    {
        private static ClientModel BuildClientEnum(SealedChoiceSchema sealedChoiceSchema) => new ClientEnum(
            sealedChoiceSchema,
            sealedChoiceSchema.CSharpName(),
            sealedChoiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), ClientModelBuilderHelpers.StringConstant(c.Value))));

        private static ClientModel BuildClientEnum(ChoiceSchema choiceSchema) => new ClientEnum(
            choiceSchema,
            choiceSchema.CSharpName(),
            choiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), ClientModelBuilderHelpers.StringConstant(c.Value))),
            true);

        private static ClientModel BuildClientObject(ObjectSchema objectSchema)
        {
            ClientTypeReference? inheritsFromTypeReference = null;
            DictionarySchema? inheritedDictionarySchema = null;

            foreach (ComplexSchema complexSchema in objectSchema.Parents!.Immediate)
            {
                switch (complexSchema)
                {
                    case ObjectSchema parentObjectSchema:
                        inheritsFromTypeReference = ClientModelBuilderHelpers.CreateType(parentObjectSchema, false);
                        break;
                    case DictionarySchema dictionarySchema:
                        inheritedDictionarySchema = dictionarySchema;
                        break;
                }
            }

            List<ClientObjectProperty> properties = new List<ClientObjectProperty>();
            List<JsonPropertySerialization> serializationProperties = new List<JsonPropertySerialization>();

            foreach (Property property in objectSchema.Properties!)
            {
                ClientObjectProperty clientObjectProperty = CreateProperty(property);
                properties.Add(clientObjectProperty);
            }

            foreach (var schema in EnumerateHierarchy(objectSchema))
            {
                foreach (Property property in schema.Properties!)
                {
                    serializationProperties.Add(CreateSerialization(property));
                }
            }

            Discriminator? schemaDiscriminator = objectSchema.Discriminator;
            ClientObjectDiscriminator? discriminator = null;

            if (schemaDiscriminator == null && objectSchema.DiscriminatorValue != null)
            {
                schemaDiscriminator = objectSchema.Parents!.All.OfType<ObjectSchema>().First(p => p.Discriminator != null).Discriminator;

                Debug.Assert(schemaDiscriminator != null);

                discriminator = new ClientObjectDiscriminator(
                    schemaDiscriminator.Property.CSharpName(),
                    schemaDiscriminator.Property.SerializedName,
                    Array.Empty<ClientObjectDiscriminatorImplementation>(),
                    objectSchema.DiscriminatorValue
                );
            }
            else if (schemaDiscriminator != null)
            {
                discriminator = new ClientObjectDiscriminator(
                    schemaDiscriminator.Property.CSharpName(),
                    schemaDiscriminator.Property.SerializedName,
                    CreateDiscriminatorImplementations(schemaDiscriminator),
                    objectSchema.DiscriminatorValue
                    );
            }

            var schemaTypeReference = ClientModelBuilderHelpers.CreateType(objectSchema, false);

            return new ClientObject(
                objectSchema,
                objectSchema.CSharpName(),
                (SchemaTypeReference?) inheritsFromTypeReference,
                properties.ToArray(),
                discriminator,
                inheritedDictionarySchema == null ? null : CreateDictionaryType(inheritedDictionarySchema),
                new JsonObjectSerialization(schemaTypeReference, serializationProperties.ToArray(), CreateAdditionalProperties(objectSchema))
                );
        }

        private static JsonDynamicPropertiesSerialization? CreateAdditionalProperties(ObjectSchema objectSchema)
        {
            var inheritedDictionarySchema = objectSchema.Parents!.All.OfType<DictionarySchema>().SingleOrDefault();

            if (inheritedDictionarySchema == null)
            {
                return null;
            }

            return new JsonDynamicPropertiesSerialization(
                ClientModelBuilderHelpers.CreateSerialization(inheritedDictionarySchema.ElementType, false)
                );
        }

        private static DictionaryTypeReference CreateDictionaryType(DictionarySchema inheritedDictionarySchema)
        {
            return new DictionaryTypeReference(
                new FrameworkTypeReference(typeof(string)),
                ClientModelBuilderHelpers.CreateType(inheritedDictionarySchema.ElementType, false),
                false);
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

        private static JsonPropertySerialization CreateSerialization(Property property)
        {
            return new JsonPropertySerialization(
                property.SerializedName,
                property.CSharpName(),
                ClientModelBuilderHelpers.CreateSerialization(property.Schema, property.IsNullable()),
                ClientModelBuilderHelpers.CreateType(property.Schema, property.IsNullable())
                );
        }

        private static ClientObjectDiscriminatorImplementation[] CreateDiscriminatorImplementations(Discriminator schemaDiscriminator)
        {
            return schemaDiscriminator.All.Select(implementation => new ClientObjectDiscriminatorImplementation(
                implementation.Key,
                (SchemaTypeReference)ClientModelBuilderHelpers.CreateType(implementation.Value, false),
                schemaDiscriminator.Immediate.ContainsKey(implementation.Key)
            )).ToArray();
        }

        public static ClientModel BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => BuildClientEnum(sealedChoiceSchema),
            ChoiceSchema choiceSchema => BuildClientEnum(choiceSchema),
            ObjectSchema objectSchema => BuildClientObject(objectSchema),
            _ => throw new NotImplementedException()
        };

        private static ClientObjectProperty CreateProperty(Property property)
        {
            bool isReadOnly = property.IsDiscriminator == true || property.ReadOnly == true;

            ClientConstant? defaultValue = null;

            ClientTypeReference type;
            if (property.Schema is ConstantSchema constantSchema)
            {
                type = ClientModelBuilderHelpers.CreateType(constantSchema.ValueType, false);
                defaultValue = ClientModelBuilderHelpers.ParseClientConstant(constantSchema.Value.Value, type);
            }
            else
            {
                type = ClientModelBuilderHelpers.CreateType(property.Schema, property.IsNullable());
                if (property.ClientDefaultValue != null)
                {
                    defaultValue = ClientModelBuilderHelpers.ParseClientConstant(property.ClientDefaultValue, type);
                }
            }

            return new ClientObjectProperty(property.CSharpName(),
                type,
                isReadOnly,
                property.SerializedName,
                ClientModelBuilderHelpers.GetSerializationFormat(property.Schema),
                defaultValue);
        }
    }
}
