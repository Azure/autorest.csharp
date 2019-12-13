// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Plugins;

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
            var inheritsFrom = objectSchema.Parents?.Immediate.OfType<ObjectSchema>().SingleOrDefault();
            var inheritsFromTypeReference = inheritsFrom != null ? ClientModelBuilderHelpers.CreateType(inheritsFrom, false) : null;

            List<ClientObjectProperty> properties = new List<ClientObjectProperty>();
            List<ClientObjectConstant> constants = new List<ClientObjectConstant>();

            foreach (Property property in objectSchema.Properties!)
            {
                properties.Add(CreateProperty(property));
            }

            Discriminator? schemaDiscriminator = objectSchema.Discriminator;
            ClientObjectDiscriminator? discriminator = null;

            if (schemaDiscriminator != null)
            {
                discriminator = new ClientObjectDiscriminator(
                    schemaDiscriminator.Property.CSharpName(),
                    schemaDiscriminator.Property.SerializedName,
                    schemaDiscriminator.Immediate.ToDictionary(
                        v => v.Key,
                        s => (SchemaTypeReference)ClientModelBuilderHelpers.CreateType(s.Value, false)),
                    objectSchema.DiscriminatorValue!
                    );
            }

            return new ClientObject(
                objectSchema,
                objectSchema.CSharpName(),
                (SchemaTypeReference?) inheritsFromTypeReference,
                properties.ToArray(),
                constants.ToArray(),
                discriminator
                );
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
            bool isReadOnly = property.Schema.IsLazy() || (property.IsDiscriminator == true);

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
                property.SerializedName, ClientModelBuilderHelpers.GetSerializationFormat(property.Schema),
                defaultValue);
        }
    }
}
