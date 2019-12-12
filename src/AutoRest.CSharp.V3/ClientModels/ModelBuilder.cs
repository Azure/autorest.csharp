// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
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
            sealedChoiceSchema.Choices.Select(c => new ClientEnumValue(ModelExtensions.CSharpName((ChoiceValue) c), ClientModelBuilderHelpers.StringConstant(c.Value))));

        private static ClientModel BuildClientEnum(ChoiceSchema choiceSchema) => new ClientEnum(
            choiceSchema,
            choiceSchema.CSharpName(),
            choiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), ClientModelBuilderHelpers.StringConstant(c.Value))),
            true);

        private static ClientModel BuildClientObject(ObjectSchema objectSchema) => new ClientObject(
            objectSchema, objectSchema.CSharpName(),
            objectSchema.Properties.Where(property => !(property.Schema is ConstantSchema)).Select(CreateProperty),
            objectSchema.Properties.Where(property => property.Schema is ConstantSchema).Select(CreateConstant));

        public static ClientModel BuildModel(Schema schema) => schema switch
        {
            SealedChoiceSchema sealedChoiceSchema => BuildClientEnum(sealedChoiceSchema),
            ChoiceSchema choiceSchema => BuildClientEnum(choiceSchema),
            ObjectSchema objectSchema => BuildClientObject(objectSchema),
            _ => throw new NotImplementedException()
        };

        private static ClientObjectConstant CreateConstant(Property property)
        {
            var constantSchema = (ConstantSchema)property.Schema;
            FrameworkTypeReference type = (FrameworkTypeReference)ClientModelBuilderHelpers.CreateType(constantSchema.ValueType, false);
            return new ClientObjectConstant(property.CSharpName(), type, ClientModelBuilderHelpers.ParseClientConstant(constantSchema.Value.Value, type));
        }

        private static ClientObjectProperty CreateProperty(Property property) =>
            new ClientObjectProperty(property.CSharpName(), ClientModelBuilderHelpers.CreateType(property.Schema, property.IsNullable()), property.Schema.IsLazy(), property.SerializedName, ClientModelBuilderHelpers.GetSerializationFormat(property.Schema));
    }
}
