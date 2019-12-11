// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc.MessageModels;
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

            var models = schemas.Select(ModelBuilder.BuildModel).ToArray();
            var clients = codeModel.OperationGroups.Select(ClientBuilder.BuildClient).ToArray();

            var typeProviders = models.OfType<ISchemaTypeProvider>().ToArray();
            var typeFactory = new TypeFactory(configuration.Namespace, typeProviders);

            var modelWriter = new ModelWriter(typeFactory);
            var writer = new ClientWriter(typeFactory);
            var serializeWriter = new SerializationWriter(typeFactory);

            foreach (var model in models)
            {
                var codeWriter = new CodeWriter();
                modelWriter.WriteModel(codeWriter, model);

                var serializerCodeWriter = new CodeWriter();
                serializeWriter.WriteSerialization(serializerCodeWriter, model);

                var name = model.Name;
                await autoRest.WriteFile($"Generated/Models/{name}.cs", codeWriter.ToFormattedCode(), "source-file-csharp");
                await autoRest.WriteFile($"Generated/Models/{name}.Serialization.cs", serializerCodeWriter.ToFormattedCode(), "source-file-csharp");
            }

            foreach (var client in clients)
            {
                var codeWriter = new CodeWriter();
                writer.WriteClient(codeWriter, client);
                await autoRest.WriteFile($"Generated/Operations/{client.Name}.cs", codeWriter.ToFormattedCode(), "source-file-csharp");
            }

            return true;
        }
    }
}
