using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("model-creator")]
    internal class ModelCreator : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            //var objects = codeModel.Schemas.Objects?.Select(o => o.Language.CSharp) ?? Enumerable.Empty<CSharpLanguage>();
            //var ands = codeModel.Schemas.Ands?.Select(a => a.Language.CSharp) ?? Enumerable.Empty<CSharpLanguage>();
            //var ors = codeModel.Schemas.Ors?.Select(o => o.Language.CSharp) ?? Enumerable.Empty<CSharpLanguage>();
            //var xors = codeModel.Schemas.Xors?.Select(x => x.Language.CSharp) ?? Enumerable.Empty<CSharpLanguage>();
            //var all = objects.Concat(ands).Concat(ors).Concat(xors);
            //foreach (var language in all)
            //{
            //    await autoRest.WriteFile($"models-txt/{language.Name}.txt", language.Description ?? "[NO DESCRIPTION]", "source-file-csharp");
            //}

            foreach (var schema in codeModel.Schemas.Objects ?? Enumerable.Empty<ObjectSchema>())
            {
                var modelWriter = new ModelWriter();
                modelWriter.WriteSchema(schema);
                await autoRest.WriteFile($"models-cs/{schema.Language.CSharp.Name}.cs", modelWriter.GetFormattedCode(), "source-file-csharp");
            }

            foreach (var schema in codeModel.Schemas.GetAllSchemaNodes())
            {
                var modelWriter = new ModelWriter();
                modelWriter.WriteSchema(schema);
                await autoRest.WriteFile($"all-cs/{schema.Language.CSharp.Name}.cs", modelWriter.GetFormattedCode(), "source-file-csharp");
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
