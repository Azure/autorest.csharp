using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("model-creator")]
    internal class ModelCreator : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            foreach (var schema in codeModel.Schemas.Objects ?? Enumerable.Empty<ObjectSchema>())
            {
                var writer = new SchemaWriter();
                writer.WriteSchema(schema);
                await autoRest.WriteFile($"models-cs/{schema.Language.CSharp?.Name}.cs", writer.GetFormattedCode(), "source-file-csharp");
            }

            foreach (var schema in codeModel.Schemas.GetAllSchemaNodes())
            {
                var writer = new SchemaWriter();
                writer.WriteSchema(schema);
                await autoRest.WriteFile($"all-cs/{schema.Language.CSharp?.Name}.cs", writer.GetFormattedCode(), "source-file-csharp");
            }

            var inputFile = (await autoRest.GetValue<string[]>("input-file")).FirstOrDefault();
            var fileName = $"CodeModel-{Path.GetFileNameWithoutExtension(inputFile)}.yaml";
            var codeModelYaml = codeModel.Serialize();
            await autoRest.WriteFile(fileName, codeModelYaml, "source-file-csharp");

            return true;
        }

        public bool ReserializeCodeModel => false;
    }
}
