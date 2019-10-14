using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("type-identifier")]
    internal class TypeIdentifier : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            var simpleSchemaNodes = codeModel.Schemas.GetAllSchemaNodes()
                .Select(s => (Schema: s, Type: s.Type.GetFrameworkType()))
                .Where(st => st.Type != null);
            foreach (var (schema, type) in simpleSchemaNodes)
            {
                schema.Language.Csharp ??= new CSharpLanguage();
                schema.Language.Csharp.Type ??= new CSharpType();
                schema.Language.Csharp.Type.FrameworkType = type;
            }

            await autoRest.WriteFile("CodeModel.yaml", codeModel.Serialize(), "source-file-csharp");

            return true;
        }
    }
}
