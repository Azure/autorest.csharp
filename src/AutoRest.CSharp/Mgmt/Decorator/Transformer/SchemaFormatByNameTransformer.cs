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

        internal static void Update()
        {
            IReadOnlyList<FormatByName> rules = NormalizeFormatByNameRules(Configuration.MgmtConfiguration.FormatByNameRules);
            if (rules.Count == 0)
                return;
            foreach (Schema schema in MgmtContext.CodeModel.AllSchemas)
            {
                TryUpdateSchema(schema.CSharpName(), schema, rules);
            }
        }

        private static void TryUpdateSchema(string name, Schema schema, IReadOnlyList<FormatByName> rules)
        {
            if (schema is ArraySchema arraySchema)
            {
                if (arraySchema.ElementType is StringSchema)
                    TryUpdateSchema(schema.CSharpName(), arraySchema.ElementType, rules);
                return;
            }
            else if (schema is ObjectSchema objSchema)
            {
                foreach (var property in objSchema.Properties)
                {
                    TryUpdateSchema(property.CSharpName(), property.Schema, rules);
                }
            }

            if (schema.Type != AllSchemaTypes.String)
                return;
            foreach (var rule in rules)
            {
                bool isMatch = false;
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
                    if (rule.IsPrimitiveType)
                        schema.Type = rule.PrimitiveType;
                    else if (schema.Extensions != null)
                        schema.Extensions.Format = rule.ExtentionType;
                }
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
                    AllSchemaTypes primitiveType;
                    if (!Enum.TryParse<AllSchemaTypes>(kv.Value, result: out primitiveType))
                    {
                        // Invalid type
                        continue;
                    }
                    rule.PrimitiveType = primitiveType;
                }
                // Match pattern
                if (kv.Key.StartsWith('*'))
                {
                    rule.Pattern = MatchPattern.StartWith;
                    rule.Name = kv.Key.Substring(1);
                }
                else if (kv.Key.EndsWith('*'))
                {
                    rule.Pattern = MatchPattern.EndWith;
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
