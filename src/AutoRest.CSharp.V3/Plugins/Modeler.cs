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
        public async Task<bool> Execute(IAutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            var schemas = (codeModel.Schemas.Choices ?? Enumerable.Empty<ChoiceSchema>()).Cast<Schema>()
                .Concat(codeModel.Schemas.SealedChoices ?? Enumerable.Empty<SealedChoiceSchema>())
                .Concat(codeModel.Schemas.Objects ?? Enumerable.Empty<ObjectSchema>());

            var entities = schemas.Select(BuildEntity).ToArray();
            var typeProviders = entities.OfType<ISchemaTypeProvider>().ToArray();
            var typeFactory = new TypeFactory(configuration.Namespace, typeProviders);

            foreach (var entity in entities)
            {
                var name = entity.Name;
                var writer = new SchemaWriter(typeFactory);
                writer.WriteSchema(entity);

                var serializeWriter = new SerializationWriter(typeFactory);
                serializeWriter.WriteSerialization(entity);

                await autoRest.WriteFile($"Generated/Models/{name}.cs", writer.ToFormattedCode(), "source-file-csharp");
                await autoRest.WriteFile($"Generated/Models/{name}.Serialization.cs", serializeWriter.ToFormattedCode(), "source-file-csharp");
            }

            foreach (var operationGroup in codeModel.OperationGroups)
            {
                var writer = new OperationWriter(typeFactory);
                writer.WriteOperationGroup(operationGroup);
                await autoRest.WriteFile($"Generated/Operations/{operationGroup.CSharpName()}.cs", writer.ToFormattedCode(), "source-file-csharp");
            }

            // CodeModel for debugging
            await autoRest.WriteFile($"CodeModel-{configuration.Title}.yaml", codeModel.Serialize(), "source-file-csharp");

            return true;
        }

        private ClientModel.ClientModel BuildEntity(Schema schema)
        {
            switch (schema)
            {
                case SealedChoiceSchema sealedChoiceSchema:
                    return new ClientEnum(sealedChoiceSchema,
                        sealedChoiceSchema.CSharpName(),
                        sealedChoiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), new ClientConstant(c.Value, new FrameworkTypeReference(typeof(string))))))
                    {
                        IsStringBased = false
                    };
                case ChoiceSchema choiceSchema:
                    return new ClientEnum(choiceSchema,
                        choiceSchema.CSharpName(),
                        choiceSchema.Choices.Select(c => new ClientEnumValue(c.CSharpName(), new ClientConstant(c.Value, new FrameworkTypeReference(typeof(string))))))
                    {
                        IsStringBased = true
                    };
                case ObjectSchema objectSchema:
                    return new ClientModel.ClientObject(objectSchema, objectSchema.CSharpName(),
                        objectSchema.Properties.Where(p => !(p.Schema is ConstantSchema)).Select(CreateProperty),
                        objectSchema.Properties.Where(p=>p.Schema is ConstantSchema).Select(CreateConstant));
            }

            throw new NotImplementedException();
        }

        private static ClientObjectConstant CreateConstant(Property property)
        {
            var constantSchema = (ConstantSchema)property.Schema;
            FrameworkTypeReference type = (FrameworkTypeReference)CreateType(constantSchema.ValueType, false);
            return new ClientObjectConstant(property.CSharpName(), type, new ClientConstant(constantSchema.Value.Value, type));
        }

        private static ClientObjectProperty CreateProperty(Property property)
        {
            return new ClientObjectProperty(property.CSharpName(), CreateType(property.Schema, property.IsNullable()), property.Schema.IsLazy(), property.SerializedName);
        }

        private static ClientTypeReference CreateType(Schema schema, bool isNullable)
        {
            switch (schema)
            {
                case ArraySchema array:
                    return new CollectionTypeReference(CreateType(array.ElementType, false));
                case DictionarySchema dictionary:
                    return new DictionaryTypeReference(new FrameworkTypeReference(typeof(string)), CreateType(dictionary.ElementType, isNullable));
                case Schema s when s.Type.ToFrameworkCSharpType() is Type type:
                    return new FrameworkTypeReference(type, isNullable);
                default:
                    return new SchemaTypeReference(schema, isNullable);
            }
        }
    }
}
