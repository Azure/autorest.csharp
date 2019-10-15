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
            //var objects = codeModel.Schemas.Objects?.Select(o => o.Language.Default) ?? Enumerable.Empty<Language>();
            //var ands = codeModel.Schemas.Ands?.Select(a => a.Language.Default) ?? Enumerable.Empty<Language>();
            //var ors = codeModel.Schemas.Ors?.Select(o => o.Language.Default) ?? Enumerable.Empty<Language>();
            //var xors = codeModel.Schemas.Xors?.Select(x => x.Language.Default) ?? Enumerable.Empty<Language>();
            //var all = objects.Concat(ands).Concat(ors).Concat(xors);
            //foreach (var language in all)
            //{
            //    await autoRest.WriteFile($"models-txt/{language.Name}.txt", language.Description, "source-file-csharp");
            //}

            var objects = codeModel.Schemas.Objects?.Select(o => o.Language.Csharp) ?? Enumerable.Empty<CSharpLanguage>();
            var ands = codeModel.Schemas.Ands?.Select(a => a.Language.Csharp) ?? Enumerable.Empty<CSharpLanguage>();
            var ors = codeModel.Schemas.Ors?.Select(o => o.Language.Csharp) ?? Enumerable.Empty<CSharpLanguage>();
            var xors = codeModel.Schemas.Xors?.Select(x => x.Language.Csharp) ?? Enumerable.Empty<CSharpLanguage>();
            var all = objects.Concat(ands).Concat(ors).Concat(xors);
            foreach (var language in all)
            {
                await autoRest.WriteFile($"models-txt/{language.Name}.txt", language.Description ?? "[NO DESCRIPTION]", "source-file-csharp");
            }

            foreach (var schema in codeModel.Schemas.Objects ?? Enumerable.Empty<ObjectSchema>())
            {
                var modelWriter = new ModelWriter();
                modelWriter.WriteObjectSchema(schema);
                await autoRest.WriteFile($"models-cs/{schema.Language.Default.Name}.cs", modelWriter.GetFormattedCode(), "source-file-csharp");
            }

            var inputFile = (await autoRest.GetValue<string[]>("input-file")).FirstOrDefault();
            var fileName = $"CodeModel-{Path.GetFileNameWithoutExtension(inputFile)}.yaml";
            var codeModelYaml = codeModel.Serialize();
            await autoRest.WriteFile(fileName, codeModelYaml, "source-file-csharp");

            return true;
        }
    }
}
