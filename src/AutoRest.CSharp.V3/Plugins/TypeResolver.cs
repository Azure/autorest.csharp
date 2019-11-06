using System;
using System.Collections;
using System.Collections.Generic;
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
    [PluginName("type-resolver")]
    internal class TypeResolver : IPlugin
    {
        public async Task<bool> Execute(AutoRestInterface autoRest, CodeModel codeModel, Configuration configuration)
        {
            await autoRest.Message(new Message { Channel = Channel.Fatal, Text = "Type resolve started" });
            var allSchemas = codeModel.Schemas.GetAllSchemaNodes();
            await autoRest.Message(new Message { Channel = Channel.Fatal, Text = "Got schema nodes" });
            AddUniqueIdentifiers(allSchemas);
            await autoRest.Message(new Message { Channel = Channel.Fatal, Text = "Added Uids" });

            var schemaNodes = allSchemas.Select(s => (Schema: s, FrameworkType: s.Type.GetFrameworkType())).ToArray();
            var frameworkNodes = schemaNodes.Where(sn => sn.FrameworkType != null);
            foreach (var (schema, frameworkType) in frameworkNodes)
            {
                var cs = schema.Language.CSharp ??= new CSharpLanguage();
                var type = cs.Type ??= new CSharpType();
                type.FrameworkType = frameworkType;
            }

            var nonFrameworkNodes = schemaNodes.Where(sn => sn.FrameworkType == null).Select(sn => sn.Schema).ToArray();
            var orderedNodes = OrderUniqueIdentifiers(nonFrameworkNodes, autoRest);
            foreach (var schema in orderedNodes)
            {
                var cs = schema.Language.CSharp ??= new CSharpLanguage();
                cs.Type = CreateTypeInfo(schema, configuration);
                if (schema is ArraySchema || schema is DictionarySchema)
                {
                    cs.IsLazy = true;
                    cs.ConcreteType = CreateTypeInfo(schema, configuration, true);
                    cs.InputType = CreateTypeInfo(schema, configuration, false, true);
                }
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

        private static Schema[] OrderUniqueIdentifiers(Schema[] schemas, AutoRestInterface autoRest)
        {
            var schemaNodes = schemas.Select(s => (Schema: s, HasBranches: HasBranches(s, s.GetType(), autoRest))).ToArray();
            var leafNodes = schemaNodes.Where(sn => !sn.HasBranches).Select(sn => sn.Schema);
            foreach (var leafNode in leafNodes)
            {
                // Mark the leaves as 999 so they will be ordered first (when ordered by descending)
                var cs = leafNode.Language.CSharp ??= new CSharpLanguage();
                cs.SchemaOrder = 999;
            }

            var branchNodes = schemaNodes.Where(sn => sn.HasBranches).Select(sn => sn.Schema);
            foreach (var branchNode in branchNodes)
            {
                ProcessBranchOrder(branchNode);
            }

            // Because of how we mark the depth with higher values, order them by descending.
            // Leaves will get processed first, then the deepest branches working up to the shallowest branches.
            return schemas.OrderByDescending(s => s.Language.CSharp?.SchemaOrder ?? 0).ToArray();
        }

        private static bool IsBranch(Type type) => type == typeof(Schema) || type.IsSubclassOf(typeof(Schema))
            || (type.IsGenericType && (type.GenericTypeArguments.First() == typeof(Schema) || type.GenericTypeArguments.First().IsSubclassOf(typeof(Schema))));

        private static bool HasBranches(Schema? schema, Type type, AutoRestInterface autoRest) =>
            type.GetProperties()
            .Select(p => {
                var text = $"{schema?.Key}: {p.PropertyType.Name} {p.Name}";
                autoRest.Message(new Message { Channel = Channel.Fatal, Text = text }).GetAwaiter().GetResult();
                return (Type: p.PropertyType, Prop: p);
            })
            .Where(t => t.Type != typeof(Languages))
            .Any(t => IsBranch(t.Type) || (/*t.Type != typeof(CSharpLanguage) &&*/ GeneratedTypes.Contains(t.Type) && HasBranches(schema, t.Type, autoRest)));

        //private static bool HasBranches(Schema? schema, Type type, AutoRestInterface autoRest)
        //{
        //    //var currentType = type;
        //    var items = new Queue<(Type Type, Schema? Schema)>(new (Type, Schema?)[] { (type, schema) });
        //    while (items.Count > 0)
        //    {
        //        var current = items.Dequeue();
        //        if (current.Schema == null) continue;
        //        var currentItems = current.Type.GetProperties()
        //        .Select(p =>
        //        {
        //            var text = $"{current.Schema?.Key}: {p.PropertyType.Name} {p.Name}";
        //            autoRest.Message(new Message { Channel = Channel.Fatal, Text = text }).GetAwaiter().GetResult();
        //            return (Type: p.PropertyType, Prop: p);
        //        })
        //        .ToArray();
        //        if (currentItems.Any(i => IsBranch(i.Type))) return true;
        //        foreach(var ci in currentItems.Where(ci => ci.Type != typeof(CSharpLanguage) && GeneratedTypes.Contains(ci.Type)))
        //        {
        //            var text = $"!! {schema?.Key}: {ci.Type.Name}";
        //            autoRest.Message(new Message { Channel = Channel.Fatal, Text = text }).GetAwaiter().GetResult();
        //            //items.Enqueue((ci.Type, current.Schema != null ? ci.Prop.GetValue(current.Schema) as Schema : null));
        //            items.Enqueue((ci.Type, schema));
        //        }
        //    }

        //    return false;

        //    //return type.GetProperties()
        //    //.Select(p =>
        //    //{
        //    //    var text = $"{p.PropertyType.Name} {p.Name}: {schema?.Key}";
        //    //    autoRest.Message(new Message { Channel = Channel.Fatal, Text = text }).GetAwaiter().GetResult();
        //    //    return (Type: p.PropertyType, Prop: p);
        //    //})
        //    //.Any(t => IsBranch(t.Type) || (GeneratedTypes.Contains(t.Type) && HasBranches(schema != null ? t.Prop.GetValue(schema) as Schema : null, t.Type, autoRest)));
        //}



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

        // TODO: Clean this type selection mechanism up
        private static CSharpType CreateTypeInfo(Schema schema, Configuration configuration, bool useConcrete = false, bool useInput = false) =>
            schema switch
            {
                // TODO: Add 'when' condition here for output only types of each
                ArraySchema arraySchema => ArrayTypeInfo(arraySchema, useConcrete, useInput),
                DictionarySchema dictionarySchema => DictionaryTypeInfo(dictionarySchema, useConcrete),
                _ => DefaultTypeInfo(schema, configuration)
            };

        private static CSharpType ArrayTypeInfo(ArraySchema schema, bool useConcrete = false, bool useInput = false) =>
            new CSharpType
            {
                FrameworkType = useConcrete ? typeof(List<>) : (useInput ? typeof(IEnumerable<>) : typeof(ICollection<>)),
                SubType1 = schema.ElementType.Language.CSharp?.Type
            };

        private static CSharpType DictionaryTypeInfo(DictionarySchema schema, bool useConcrete = false) =>
            new CSharpType
            {
                // The generic type arguments are not used when assigning them via FrameworkType.
                FrameworkType = useConcrete ? typeof(Dictionary<string, object>) : typeof(IDictionary<string, object>),
                SubType1 = new CSharpType { FrameworkType = typeof(string) },
                SubType2 = schema.ElementType.Language.CSharp?.Type
            };

        private static CSharpType DefaultTypeInfo(Schema schema, Configuration configuration)
        {
            var apiVersion = schema.ApiVersions?.FirstOrDefault()?.Version.RemoveNonWordCharacters();
            return new CSharpType
            {
                Name = schema.Language.CSharp?.Name ?? schema.Language.Default.Name,
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
