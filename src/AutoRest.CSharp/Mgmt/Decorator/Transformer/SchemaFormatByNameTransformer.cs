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

        /// <summary>
        /// Change the Schema's format by its name.
        /// </summary>
        internal static void Update()
        {
            SchemaFormatByNameTransformer transformer = new SchemaFormatByNameTransformer(
                MgmtContext.CodeModel.AllSchemas,
                MgmtContext.CodeModel.OperationGroups,
                Configuration.MgmtConfiguration.FormatByNameRules);
            transformer.UpdateAllSchemas();
        }

        private IEnumerable<Schema> allGeneralSchemas;
        private IEnumerable<OperationGroup> allOperationGroups;
        private IReadOnlyDictionary<string, string> allFormatByNameRules;
        private Dictionary<Schema, string> schemaCache = new();

        internal SchemaFormatByNameTransformer(
            IEnumerable<Schema> generalSchemas,
            IEnumerable<OperationGroup> operationGroups,
            IReadOnlyDictionary<string, string> allFormatByNameRules)
        {
            this.allGeneralSchemas = generalSchemas;
            this.allOperationGroups = operationGroups;
            this.allFormatByNameRules = allFormatByNameRules;
        }

        public void UpdateAllSchemas()
        {
            IReadOnlyList<FormatByName> rules = NormalizeFormatByNameRules(allFormatByNameRules);
            if (rules.Count == 0)
                return;
            UpdateGeneralSchema(rules);
            UpdateOperationSchema(rules);
        }

        internal void UpdateGeneralSchema(IReadOnlyList<FormatByName> rules)
        {
            foreach (Schema schema in allGeneralSchemas)
            {
                if (schema is ObjectSchema objectSchema)
                {
                    TryUpdateObjectSchemaFormat(objectSchema, rules);
                }
            }
        }

        internal void UpdateOperationSchema(IReadOnlyList<FormatByName> rules)
        {
            foreach (var operationGroup in allOperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    foreach (var parameter in operation.Parameters)
                    {
                        TryUpdateParameterFormat(parameter, rules);
                    }
                }
            }
        }

        private void TryUpdateParameterFormat(RequestParameter parameter, IReadOnlyList<FormatByName> rules)
        {
            if (parameter.Schema is PrimitiveSchema)
            {
                int ruleIdx = CheckRules(parameter.CSharpName(), rules);
                if (ruleIdx >= 0)
                {
                    if (!rules[ruleIdx].IsPrimitiveType)
                    {
                        // As the Schema is shared by parameter, so here only can change the ext. format
                        if (parameter.Extensions == null)
                            parameter.Extensions = new RecordOfStringAndAny();
                        parameter.Extensions.Format = rules[ruleIdx].ExtentionType;
                    }
                }
            }
        }

        private void TryUpdateObjectSchemaFormat(ObjectSchema objectSchema, IReadOnlyList<FormatByName> rules)
        {
            foreach (var property in objectSchema.Properties)
            {
                if (property.Schema is ArraySchema propertyArraySchema)
                    TryUpdateSchemaFormat(property.CSharpName(), propertyArraySchema.ElementType, rules);
                else
                    TryUpdateSchemaFormat(property.CSharpName(), property.Schema, rules);
            }
        }

        private int TryUpdateSchemaFormat(string name, Schema schema, IReadOnlyList<FormatByName> rules)
        {
            int ruleIdx = -1;
            if (schema is not PrimitiveSchema)
                return ruleIdx;
            if (schemaCache.ContainsKey(schema))
            {
                if (!name.Equals(schemaCache[schema]))
                    Console.Error.WriteLine($"WARNING: The schema '{schema.CSharpName()}' is shared by '{name}' and '{schemaCache[schema]}' which is unexpected.");
                return ruleIdx;
            }
            ruleIdx = CheckRules(name, rules);
            if (ruleIdx >= 0)
            {
                if (rules[ruleIdx].IsPrimitiveType)
                    schema.Type = rules[ruleIdx].PrimitiveType;
                else
                {
                    if (schema.Extensions == null)
                        schema.Extensions = new RecordOfStringAndAny();
                    schema.Extensions.Format = rules[ruleIdx].ExtentionType;
                }
            }
            schemaCache[schema] = name;
            return ruleIdx;
        }

        private int CheckRules(string name, IReadOnlyList<FormatByName> rules)
        {
            bool isMatch = false;
            for (int i = 0; i < rules.Count; i++)
            {
                switch (rules[i].Pattern)
                {
                    case MatchPattern.StartWith:
                        isMatch = name.StartsWith(rules[i].Name, StringComparison.Ordinal);
                        break;
                    case MatchPattern.EndWith:
                        isMatch = name.EndsWith(rules[i].Name, StringComparison.Ordinal);
                        break;
                    case MatchPattern.Full:
                        isMatch = FullStringComapre(name, rules[i].Name);
                        break;
                }
                if (isMatch)
                {
                    return i;
                }
            }
            return -1;
        }

        private IReadOnlyList<FormatByName> NormalizeFormatByNameRules(IReadOnlyDictionary<string, string> formatByNameRules)
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
                        throw new Exception($"Invalid FormatByName rule: {kv.Value} : {kv.Value}.");
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

        private bool FullStringComapre(string strA, string strB)
        {
            if (strA.Length != strB.Length)
                return false;
            if (Char.ToLower(strA[0]) != Char.ToLower(strB[0]))
            {
                // Ignore case for the first character,
                // as autorect auto-upper case the first character for model & property name but not for parameter name.
                return false;
            }
            for (int i = 1; i < strA.Length; i++)
            {
                if (!strA[i].Equals(strB[i]))
                    return false;
            }
            return true;
        }
    }
}
