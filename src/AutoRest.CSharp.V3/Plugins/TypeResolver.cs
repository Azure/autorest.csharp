using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("type-resolver")]
    internal class TypeResolver : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            var schemaNodes = codeModel.Schemas.GetAllSchemaNodes().Select(s => (Schema: s, FrameworkType: s.Type.GetFrameworkType()));
            foreach (var (schema, frameworkType) in schemaNodes)
            {
                schema.Language.Csharp ??= new CSharpLanguage();
                schema.Language.Csharp.Type ??= new CSharpType();
                var type = schema.Language.Csharp.Type;

                if (frameworkType != null)
                {
                    type.FrameworkType = frameworkType;
                    continue;
                }

                type.Namespace ??= new CSharpNamespace();
                type.Namespace.Base = configuration.Namespace.NullIfEmpty();
                type.Namespace.Category = "Models";
                var apiVersion = schema.ApiVersions?.FirstOrDefault()?.Version.RemoveNonWordCharacters();
                type.Namespace.ApiVersion = apiVersion != null ? $"V{apiVersion}" : schema.Language.Default.Namespace;
                type.Name = schema.Language.Default.Name;
            }

            await autoRest.WriteFile("CodeModel.yaml", codeModel.Serialize(), "source-file-csharp");

            return true;
        }
    }
}
