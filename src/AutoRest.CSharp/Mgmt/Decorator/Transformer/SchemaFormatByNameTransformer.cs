// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Builders;

namespace AutoRest.CSharp.Mgmt.Decorator.Transformer
{
    internal class SchemaFormatByNameTransformer
    {
        internal enum MatchPattern
        {
            Full = 0,
            StartWith = 1,
            EndWith = 2,
        }

        internal struct FormatByName
        {
            public MatchPattern Pattern { get; set; }
            public string Name { get; set; }
            public bool IsPrimitiveType { get; set; }
            public AllSchemaTypes PrimitiveType { get; set; }
            public string ExtentionType { get; set; }
        }


        private static Dictionary<Guid, bool> schemaStatus = new Dictionary<Guid, bool>();

        /// <summary>
        /// Change the Schema's format by its name.
        /// </summary>
        internal static void Update()
        {
            IReadOnlyList<FormatByName> rules = NormalizeFormatByNameRules(Configuration.MgmtConfiguration.FormatByNameRules);
            if (rules.Count == 0)
                return;
            foreach (Schema schema in MgmtContext.CodeModel.AllSchemas)
            {
                TryUpdateSchemaFormat(schema.CSharpName(), schema, rules);
            }
        }

        private static void TryUpdateSchemaFormat(string name, Schema schema, IReadOnlyList<FormatByName> rules)
        {
            if (schema is ArraySchema arraySchema)
            {
                TryUpdateSchemaFormat(name, arraySchema.ElementType, rules);
            }
            else if (schema is ObjectSchema objSchema)
            {
                foreach (var property in objSchema.Properties)
                {
                    TryUpdateSchemaFormat(property.CSharpName(), property.Schema, rules);
                }
            }
            else if (schema is PrimitiveSchema)
            {
                if (schemaStatus.ContainsKey(schema.Id))
                {
                    return;
                }

                bool isMatch = false;
                foreach (var rule in rules)
                {
                    switch (rule.Pattern)
                    {
                        case MatchPattern.StartWith:
                            isMatch = name.StartsWith(rule.Name, StringComparison.Ordinal);
                            break;
                        case MatchPattern.EndWith:
                            isMatch = name.EndsWith(rule.Name, StringComparison.Ordinal);
                            break;
                        case MatchPattern.Full:
                            isMatch = (string.Compare(name, rule.Name, StringComparison.Ordinal) == 0);
                            break;
                    }
                    if (isMatch)
                    {
                        var oldType = schema.Type.ToString();
                        if (rule.IsPrimitiveType)
                            schema.Type = rule.PrimitiveType;
                        else
                        {
                            if (schema.Extensions == null)
                                schema.Extensions = new RecordOfStringAndAny();
                            schema.Extensions.Format = rule.ExtentionType;
                        }
                        break;
                    }
                }
                schemaStatus[schema.Id] = isMatch;
            }
        }
        private static IReadOnlyList<FormatByName> NormalizeFormatByNameRules(IReadOnlyDictionary<string, string> formatByNameRules)
        {
            List<FormatByName> rules = new List<FormatByName>();
            if (formatByNameRules == null)
                return rules;
            foreach (var kv in formatByNameRules)
            {
                FormatByName rule = new FormatByName();
                if (TypeFactory.ToXMsFormatType(kv.Value) != null)
                {
                    rule.IsPrimitiveType = false;
                    rule.ExtentionType = kv.Value;
                }
                else
                {
                    rule.IsPrimitiveType = true;
                    AllSchemaTypes primitiveType;
                    if (!Enum.TryParse<AllSchemaTypes>(kv.Value, true, result: out primitiveType))
                    {
                        Console.Error.WriteLine($"  Invalid FormatByName rule: {kv.Value} : {kv.Value}.");
                        continue;
                    }
                    rule.PrimitiveType = primitiveType;
                }
                // Match pattern
                if (kv.Key.StartsWith('*'))
                {
                    rule.Pattern = MatchPattern.EndWith;
                    rule.Name = kv.Key.TrimStart('*');
                }
                else if (kv.Key.EndsWith('*'))
                {
                    rule.Pattern = MatchPattern.StartWith;
                    rule.Name = kv.Key.TrimEnd('*');
                }
                else
                {
                    rule.Pattern = MatchPattern.Full;
                    rule.Name = kv.Key;
                }
                rules.Add(rule);
            }
            return rules;
        }
    }
}
