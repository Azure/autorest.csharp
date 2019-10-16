using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("name-modifier")]
    internal class NameModifier : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            var schemaNodes = codeModel.Schemas.GetAllSchemaNodes();
            foreach (var schema in schemaNodes)
            {
                var cs = schema.Language.CSharp ??= new CSharpLanguage();

                cs.Name = schema.Language.Default.Name.ToCleanName();
                cs.Description = schema.Language.Default.Description;
            }

            var propertyNodes = codeModel.Schemas.Objects.SelectMany(os => os.Properties);
            foreach (var property in propertyNodes)
            {
                var cs = property.Language.CSharp ??= new CSharpLanguage();

                cs.Name = property.SerializedName.ToCleanName();
                cs.Description = property.Language.Default.Description;
            }

            return true;
        }
    }
}