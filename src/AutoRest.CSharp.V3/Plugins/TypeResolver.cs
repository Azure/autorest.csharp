using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.V3.JsonRpc;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;
using static AutoRest.CSharp.V3.Pipeline.Extensions;

namespace AutoRest.CSharp.V3.Plugins
{
    [PluginName("type-resolver")]
    internal class TypeResolver : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            var allSchemas = codeModel.Schemas.GetAllSchemaNodes();
            AddUniqueIdentifiers(allSchemas);

            var schemaNodes = allSchemas.Select(s => (Schema: s, FrameworkType: s.Type.GetFrameworkType())).ToArray();
            var frameworkNodes = schemaNodes.Where(sn => sn.FrameworkType != null);
            foreach (var (schema, frameworkType) in frameworkNodes)
            {
                var cs = schema.Language.CSharp ??= new CSharpLanguage();
                var type = cs.Type ??= new CSharpType();
                type.FrameworkType = frameworkType;
            }

            var nonFrameworkNodes = schemaNodes.Where(sn => sn.FrameworkType == null).Select(sn => sn.Schema).ToArray();
            var orderedNodes = OrderUniqueIdentifiers(nonFrameworkNodes);
            foreach (var schema in orderedNodes)
            {
                var cs = schema.Language.CSharp ??= new CSharpLanguage();
                cs.Type = CreateTypeInfo(schema, configuration);
            }

            return true;
        }

        // This unique identifier is because of https://github.com/Azure/autorest.modelerfour/issues/20
        private static void AddUniqueIdentifiers(IEnumerable<Schema> schemas)
        {
            foreach (var (schema, index) in schemas.Select((s, i) => (Schema: s, Index: i)))
            {
                var cs = schema.Language.CSharp ??= new CSharpLanguage();
                cs.Uid = $"schema:{index}";
            }
        }

        private static Schema[] OrderUniqueIdentifiers(Schema[] schemas)
        {
            var schemaNodes = schemas.Select(s => (Schema: s, HasBranches: HasBranches(s.GetType()))).ToArray();
            var leafNodes = schemaNodes.Where(sn => !sn.HasBranches).Select(sn => sn.Schema);
            foreach (var leafNode in leafNodes)
            {
                // Mark the leaves as 999 so they will be ordered first (when ordered by descending)
                leafNode.Language.CSharp.SchemaOrder = 999;
            }

            var branchNodes = schemaNodes.Where(sn => sn.HasBranches).Select(sn => sn.Schema);
            foreach (var branchNode in branchNodes)
            {
                ProcessBranchOrder(branchNode);
            }

            // Because of how we mark the depth with higher values, order them by descending.
            // Leaves will get processed first, then the deepest branches working up to the shallowest branches.
            return schemas.OrderByDescending(s => s.Language.CSharp.SchemaOrder).ToArray();
        }

        private static bool IsBranch(Type type) =>
            type == typeof(Schema) || type.IsSubclassOf(typeof(Schema))
            || (type.IsGenericType && (type.GenericTypeArguments.First() == typeof(Schema) || type.GenericTypeArguments.First().IsSubclassOf(typeof(Schema))));

        private static bool HasBranches(Type type) => type.GetProperties()
            .Select(p => p.PropertyType)
            .Any(t => IsBranch(t) || (GeneratedTypes.Contains(t) && HasBranches(t)));

        // Every branch will look through its children and mark the SchemaOrder as the currentDepth, if it is deeper than the previous depth.
        // Since SchemaOrder starts at 0, it will always set a branches currentDepth to 1 on the first pass.
        // Since the schemas are by reference, the SchemaOrder depth will always be the deepest value among all schema branches.
        private static void ProcessBranchOrder(Schema schema, int currentDepth = 1)
        {
            // CSharp won't be there for choiceType because of https://github.com/Azure/autorest.modelerfour/issues/19
            // For now, we always check and create it if needed.
            var cs = schema.Language.CSharp ??= new CSharpLanguage();
            if (cs.SchemaOrder < currentDepth)
            {
                cs.SchemaOrder = currentDepth;
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

        private static CSharpType CreateTypeInfo(Schema schema, Configuration configuration) =>
            schema switch
            {
                ArraySchema arraySchema => ArrayTypeInfo(arraySchema),
                DictionarySchema dictionarySchema => DictionaryTypeInfo(dictionarySchema),
                _ => DefaultTypeInfo(schema, configuration)
            };

        private static CSharpType ArrayTypeInfo(ArraySchema schema) =>
            new CSharpType
            {
                Name = $"ICollection<{schema.ElementType.Language.CSharp?.Type?.FullName ?? "[NO TYPE]"}>",
                Namespace = new CSharpNamespace
                {
                    Base = "System.Collections.Generic"
                }
            };

        private static CSharpType DictionaryTypeInfo(DictionarySchema schema) =>
            new CSharpType
            {
                Name = $"IDictionary<{typeof(string).FullName}, {schema.ElementType.Language.CSharp?.Type?.FullName ?? "[NO TYPE]"}>",
                Namespace = new CSharpNamespace
                {
                    Base = "System.Collections.Generic"
                }
            };

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
