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
                //cs.Name = schema.Language.Default.Name.ToCleanName();
                //cs.Description = schema.Language.Default.Description;
            }

            var emptyPropertyTuple = Enumerable.Empty<(ObjectSchema, Property)>();
            var propertyNodes = codeModel.Schemas.Objects?.SelectMany(os => os.Properties?.Select(p => (os, p)) ?? emptyPropertyTuple) ?? emptyPropertyTuple;
            foreach (var (objectSchema, property) in propertyNodes)
            {
                var cs = property.Language.CSharp ??= new CSharpLanguage();
                //cs.Name = property.Language.Default.Name.ToCleanName();
                //cs.Description = property.Language.Default.Description;
                cs.IsNullable = !(property.Required ?? false);
                if(property.Required ?? false)
                {
                    var objectCs = objectSchema.Language.CSharp ??= new CSharpLanguage();
                    //objectCs.HasRequired = true;
                }
            }

            var parameterNodes = codeModel.OperationGroups.SelectMany(og => og.Operations.SelectMany(o => o.Request.Parameters ?? Enumerable.Empty<Parameter>()));
            foreach (var parameter in parameterNodes)
            {
                var cs = parameter.Language.CSharp ??= new CSharpLanguage();
                //cs.Name = parameter.Language.Default.Name.ToVariableName();
                //cs.Description = parameter.Language.Default.Description;
                //cs.IsNullable = !(parameter.Required ?? false);
            }

            var choiceValueNodes = (codeModel.Schemas.Choices?.SelectMany(c => c.Choices) ?? Enumerable.Empty<ChoiceValue>())
                .Concat(codeModel.Schemas.SealedChoices?.SelectMany(sc => sc.Choices) ?? Enumerable.Empty<ChoiceValue>());
            foreach (var choiceValue in choiceValueNodes)
            {
                var cs = choiceValue.Language.CSharp ??= new CSharpLanguage();
                //cs.Name = choiceValue.Language.Default.Name.ToCleanName();
                //cs.Description = choiceValue.Language.Default.Description;
            }

            var andNodes = codeModel.Schemas.Ands ?? Enumerable.Empty<AndSchema>();
            foreach (var andNode in andNodes)
            {
                var cs = andNode.Language.CSharp ??= new CSharpLanguage();
                var hasRequiredObject = andNode.AllOf.OfType<ObjectSchema>().Select(os => os.Language.CSharp).Any(ocs => ocs?.HasRequired ?? false);
                if(hasRequiredObject)
                {
                    //cs.HasRequired = true;
                }
            }

            return true;
        }
    }
}