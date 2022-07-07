// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal static class SerializedNamesUpdater
    {
        public static void Update()
        {
            foreach (var schema in MgmtContext.CodeModel.AllSchemas)
            {
                switch (schema)
                {
                    case ChoiceSchema choiceSchema:
                        UpdateChoiceSchema(choiceSchema);
                        break;
                    case SealedChoiceSchema sealedSchema:
                        UpdateSealedChoiceSchema(sealedSchema);
                        break;
                    case ObjectSchema objectSchema:
                        UpdateObjectSchema(objectSchema);
                        break;
                }
            }
        }

        private static void UpdateChoiceSchema(ChoiceSchema choiceSchema)
        {
            // construct the serialized information
            var serializedName = CreateSerializedNameDescription(choiceSchema);
            // update the choice type, append the serialized name of this type to its original description
            choiceSchema.Language.Default.Description = $"{CreateDescription(choiceSchema)}\n{serializedName}";
            // update the choice values
            foreach (var choice in choiceSchema.Choices)
            {
                choice.Language.Default.Description = $"{CreateDescription(choice)}\n{serializedName}.{choice.Value}";
            }
        }

        private static void UpdateSealedChoiceSchema(SealedChoiceSchema sealedChoiceSchema)
        {
            // construct the serialized information
            var serializedName = CreateSerializedNameDescription(sealedChoiceSchema);
            // update the sealed choice type, append the serialized name of this type to its original description
            sealedChoiceSchema.Language.Default.Description = $"{CreateDescription(sealedChoiceSchema)}\n{serializedName}";
            foreach (var choice in sealedChoiceSchema.Choices)
            {
                choice.Language.Default.Description = $"{CreateDescription(choice)}\n{serializedName}.{choice.Value}";
            }
        }

        private static void UpdateObjectSchema(ObjectSchema objectSchema)
        {
            // construct the serialized information
            var serializedName = CreateSerializedNameDescription(objectSchema);
            // update the sealed choice type, append the serialized name of this type to its original description
            objectSchema.Language.Default.Description = $"{CreateDescription(objectSchema)}\n{serializedName}";
            foreach (var property in objectSchema.Properties)
            {
                string propertySerializedName;
                if (property.FlattenedNames.Count == 0)
                    propertySerializedName = $"{property.SerializedName}";
                else
                    propertySerializedName = string.Join(".", property.FlattenedNames);

                var originalDescription = string.IsNullOrEmpty(property.Language.Default.Description) ? string.Empty : $"{property.Language.Default.Description}\n";
                property.Language.Default.Description = $"{originalDescription}{serializedName}.{propertySerializedName}";
            }
        }

        private static string CreateDescription(Schema schema) => string.IsNullOrWhiteSpace(schema.Language.Default.Description) ?
                $"The {schema.Name}.":
                schema.Language.Default.Description;

        private static string CreateDescription(ChoiceValue choiceValue) => string.IsNullOrWhiteSpace(choiceValue.Language.Default.Description)
                ? choiceValue.Value
                : choiceValue.Language.Default.Description;

        private static string CreateSerializedNameDescription(Schema schema) => $"Serialized Name: {SchemaRenamer.GetOriginalName(schema)}";
    }
}
