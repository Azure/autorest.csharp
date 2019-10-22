using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;
using static AutoRest.CSharp.V3.Pipeline.Extensions;

namespace AutoRest.CSharp.V3.Plugins
{
    // Maybe put some of this into a type resolution namespace
    [PluginName("type-resolver")]
    internal class TypeResolver : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            //var recordSet = codeModel.Schemas.Objects.First(o => o.Key == "RecordSet");

            //var recordSet2 = codeModel.Schemas.Ands.First(a => a.Key == "RecordSet").AllOf.First(o => o.Key == "RecordSet");

            //var test = recordSet.Uid == recordSet2.Uid;
            //recordSet.Uid = "TACO";
            //var test2 = recordSet.Uid == recordSet2.Uid;

            var allSchemas = codeModel.Schemas.GetAllSchemaNodes();
            AddUniqueIdentifier(allSchemas);

            var schemaNodes = allSchemas.Select(s => (Schema: s, FrameworkType: s.Type.GetFrameworkType())).ToArray();
            var frameworkNodes = schemaNodes.Where(sn => sn.FrameworkType != null);
            foreach (var (schema, frameworkType) in frameworkNodes)
            {
                var cs = schema.Language.CSharp ??= new CSharpLanguage();
                var type = cs.Type ??= new CSharpType();
                type.FrameworkType = frameworkType;
            }

            // Order these by order value
            var nonFrameworkNodes = schemaNodes.Where(sn => sn.FrameworkType == null).Select(sn => sn.Schema).ToArray();
            var orderedNodes = OrderUids(nonFrameworkNodes);
            foreach (var schema in orderedNodes)
            {
                var cs = schema.Language.CSharp ??= new CSharpLanguage();
                cs.Type = AssignTypeInfo(schema, configuration);
                //var type = cs.Type ??= new CSharpType();

                //type.Namespace ??= new CSharpNamespace();
                //type.Namespace.Base = configuration.Namespace.NullIfEmpty();
                //type.Namespace.Category = "Models";
                //var apiVersion = schema.ApiVersions?.FirstOrDefault()?.Version.RemoveNonWordCharacters();
                //type.Namespace.ApiVersion = apiVersion != null ? $"V{apiVersion}" : schema.Language.Default.Namespace;
                //type.Name = cs.Name;
            }

            return true;
        }

        private static void AddUniqueIdentifier(Schema[] schemas)
        {
            foreach (var (schema, index) in schemas.Select((s, i) => (Schema: s, Index: i)))
            {
                var cs = schema.Language.CSharp ??= new CSharpLanguage();
                cs.Uid = $"schema:{index}";
            }
        }

        private static Schema[] OrderUids(Schema[] schemas)
        {
            // Default depth is 0
            // Mark leaves as top (depth value 999)
            // Pair uid with depth value (branches start at depth 1)
            // /////////////////////If we encounter a leaf, do not change the value (999 will always be greater than the current depth)
            // /////////////////////Group by uid, keep only a single uid with the highest depth value
            // Schemas are by reference, so only need to update the value if the new value is greater than the current value
            // Order by reverse depth order

            var schemaNodes = schemas.Select(s => (Schema: s, HasBranches: HasBranches(s.GetType()))).ToArray();
            var leafNodes = schemaNodes.Where(sn => !sn.HasBranches).Select(sn => sn.Schema);
            foreach (var leafNode in leafNodes)
            {
                leafNode.Language.CSharp.SchemaOrder = 999;
            }

            var branchNodes = schemaNodes.Where(sn => sn.HasBranches).Select(sn => sn.Schema);
            foreach (var branchNode in branchNodes)
            {
                ProcessBranchOrder(branchNode, 1);
            }

            return schemas.OrderByDescending(s => s.Language.CSharp.SchemaOrder).ToArray();
        }

        private static bool IsBranch(Type type) =>
            type == typeof(Schema) || type.IsSubclassOf(typeof(Schema))
            || (type.IsGenericType
                && (type.GenericTypeArguments.First() == typeof(Schema) || type.GenericTypeArguments.First().IsSubclassOf(typeof(Schema))));

        private static bool HasBranches(Type type) => type.GetProperties()
            .Select(p => p.PropertyType)
            .Any(t => IsBranch(t) || (GeneratedTypes.Contains(t) && HasBranches(t)));

        private static void ProcessBranchOrder(Schema schema, int currentDepth)
        {
            // For now, CSharp won't be there sometimes because of https://github.com/Azure/autorest.modelerfour/issues/19
            if (schema.Language.CSharp?.SchemaOrder < currentDepth)
            {
                schema.Language.CSharp.SchemaOrder = currentDepth;
            }

            currentDepth++;
            var branchSchemas = schema.GetType().GetProperties()
                .Where(p => IsBranch(p.PropertyType))
                .Select(p => (IsGeneric: p.PropertyType.IsGenericType, Value: p.GetValue(schema)))
                .Where(tv => tv.Value != null)
                .SelectMany(tv => tv.IsGeneric ? ((IEnumerable)tv.Value!).Cast<Schema>() : new[] {(Schema)tv.Value!});
            foreach (var branchSchema in branchSchemas)
            {
                ProcessBranchOrder(branchSchema, currentDepth);
            }
        }

        private static CSharpType AssignTypeInfo(Schema schema, Configuration configuration) =>
            schema switch
            {
                ArraySchema arraySchema => ArrayTypeInfo(arraySchema, configuration),
                DictionarySchema dictionarySchema => DictionaryTypeInfo(dictionarySchema, configuration),
                _ => DefaultTypeInfo(schema, configuration)
            };

        private static CSharpType ArrayTypeInfo(ArraySchema schema, Configuration configuration)
        {
            var elementType = schema.ElementType.Language.CSharp?.Type?.FullName ?? "[NO TYPE]";
            return new CSharpType
            {
                Name = $"ICollection<{elementType}>",
                Namespace = new CSharpNamespace
                {
                    Base = "System.Collections.Generic"
                }
            };
        }

        private static CSharpType DictionaryTypeInfo(DictionarySchema schema, Configuration configuration)
        {
            var elementType = schema.ElementType.Language.CSharp?.Type?.FullName ?? "[NO TYPE]";
            return new CSharpType
            {
                Name = $"IDictionary<System.String, {elementType}>",
                Namespace = new CSharpNamespace
                {
                    Base = "System.Collections.Generic"
                }
            };
        }

        private static CSharpType DefaultTypeInfo(Schema schema, Configuration configuration)
        {
            var apiVersion = schema.ApiVersions?.FirstOrDefault()?.Version.RemoveNonWordCharacters();
            return new CSharpType
            {
                Name = schema.Language.CSharp.Name,
                Namespace = new CSharpNamespace
                {
                    Base = configuration.Namespace.NullIfEmpty(),
                    Category = "Models",
                    ApiVersion = apiVersion != null ? $"V{apiVersion}" : schema.Language.Default.Namespace
                }
            };
        }
    }
}
