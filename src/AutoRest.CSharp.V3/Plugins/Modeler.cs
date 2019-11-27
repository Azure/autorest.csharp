// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.ClientModel;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("cs-modeler")]
    internal class Modeler : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            var schemas = (codeModel.Schemas.Choices ?? Enumerable.Empty<ChoiceSchema>()).Cast<Schema>()
                .Concat(codeModel.Schemas.SealedChoices ?? Enumerable.Empty<SealedChoiceSchema>())
                .Concat(codeModel.Schemas.Objects ?? Enumerable.Empty<ObjectSchema>());
            foreach (var schema in schemas)
            {
                var name = schema.CSharpName() ?? "[NO NAME]";
                var writer = new SchemaWriter(new TypeFactory(configuration.Namespace));
                var entity = BuildEntity(schema);
                writer.WriteSchema(entity);
                await autoRest.WriteFile($"Generated/Models/{name}.cs", writer.ToFormattedCode(), "source-file-csharp");

                var serializeWriter = new SerializationWriter(new TypeFactory(configuration.Namespace));
                serializeWriter.WriteSerialization(schema);
                await autoRest.WriteFile($"Generated/Models/{name}.Serialization.cs", serializeWriter.ToFormattedCode(), "source-file-csharp");
            }

            foreach (var operationGroup in codeModel.OperationGroups)
            {
                var writer = new OperationWriter(new TypeFactory(configuration.Namespace));
                writer.WriteOperationGroup(operationGroup);
                await autoRest.WriteFile($"Generated/Operations/{operationGroup.CSharpName()}.cs", writer.ToFormattedCode(), "source-file-csharp");
            }

            // CodeModel for debugging
            await autoRest.WriteFile($"CodeModel-{configuration.Title}.yaml", codeModel.Serialize(), "source-file-csharp");

            return true;
        }

        private ClientEntity BuildEntity(Schema schema)
        {
            switch (schema)
            {
                case SealedChoiceSchema sealedChoiceSchema:
                    return new ClientEnum(sealedChoiceSchema.CSharpName(), sealedChoiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), new ClientConstant(c.Value))))
                    {
                        GenerationOptions = { IsStringBased = false }
                    };
                case ChoiceSchema sealedChoiceSchema:
                    return new ClientEnum(sealedChoiceSchema.CSharpName(), sealedChoiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), new ClientConstant(c.Value))))
                    {
                        GenerationOptions = { IsStringBased = true }
                    };
                case ObjectSchema objectSchema:
                    return new ClientModel.ClientModel(objectSchema.CSharpName(), objectSchema.Properties.Select(
                        property => new ClientModelDataProperty(property.CSharpName(), new SchemaTypeReference(property.Schema), !(property.ReadOnly ?? false))));
            }

            throw new NotImplementedException();
        }
    }
}
