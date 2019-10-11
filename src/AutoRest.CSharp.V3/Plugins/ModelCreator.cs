using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.CodeGen;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("model-creator")]
    internal class ModelCreator : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            var objects = codeModel.Schemas.Objects?.Select(o => o.Language.Default) ?? Enumerable.Empty<Language>();
            var ands = codeModel.Schemas.Ands?.Select(a => a.Language.Default) ?? Enumerable.Empty<Language>();
            var ors = codeModel.Schemas.Ors?.Select(o => o.Language.Default) ?? Enumerable.Empty<Language>();
            var xors = codeModel.Schemas.Xors?.Select(x => x.Language.Default) ?? Enumerable.Empty<Language>();
            var all = objects.Concat(ands).Concat(ors).Concat(xors);
            foreach (var language in all)
            {
                await autoRest.WriteFile($"models-txt/{language.Name}.txt", language.Description, "source-file-csharp");
            }

            foreach (var schema in codeModel.Schemas.Objects ?? Enumerable.Empty<ObjectSchema>())
            {
                var modelWriter = new ModelWriter();
                modelWriter.WriteObjectSchema(schema);
                await autoRest.WriteFile($"models-cs/{schema.Language.Default.Name}.cs", modelWriter.GetFormattedCode(), "source-file-csharp");
            }

            return true;
        }
    }
}
