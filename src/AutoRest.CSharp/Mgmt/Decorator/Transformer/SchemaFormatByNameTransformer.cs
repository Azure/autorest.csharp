// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
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

        internal struct FormatRule
        {
            internal NamePattern NamePattern { get; init; }
            internal FormatPattern FormatPattern { get; init; }
        }

        internal record FormatPattern(bool IsPrimitiveType, AllSchemaTypes? PrimitiveType, string? ExtensionType)
        {
            internal static FormatPattern Parse(string value)
            {
                if (TypeFactory.ToXMsFormatType(value) != null)
                {
                    return new FormatPattern(false, null, value);
                }
                else
                {
                    if (!Enum.TryParse<AllSchemaTypes>(value, true, result: out var primitiveType))
                    {
                        throw new Exception($"Invalid FormatByName rule value: {value}.");
                    }
                    return new FormatPattern(true, primitiveType, null);
                }
            }
        }

        internal record NamePattern(MatchPattern Pattern, string Name)
        {
            internal static NamePattern Parse(string key) => key switch
            {
                _ when key.StartsWith('*') => new NamePattern(MatchPattern.EndWith, key.TrimStart('*')),
                _ when key.EndsWith('*') => new NamePattern(MatchPattern.StartWith, key.TrimEnd('*')),
                _ => new NamePattern(MatchPattern.Full, key)
            };
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
            var rules = ParseRules(allFormatByNameRules).ToList();
            if (rules.Count == 0)
                return;
            UpdateGeneralSchema(rules);
            UpdateOperationSchema(rules);
        }

        internal void UpdateGeneralSchema(IReadOnlyList<FormatRule> rules)
        {
            foreach (Schema schema in allGeneralSchemas)
            {
                if (schema is ObjectSchema objectSchema)
                {
                    TryUpdateObjectSchemaFormat(objectSchema, rules);
                }
            }
        }

        internal void UpdateOperationSchema(IReadOnlyList<FormatRule> rules)
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

        private void TryUpdateParameterFormat(RequestParameter parameter, IReadOnlyList<FormatRule> rules)
        {
            if (parameter.Schema is PrimitiveSchema)
            {
                int ruleIdx = CheckRules(parameter.CSharpName(), rules);
                if (ruleIdx >= 0)
                {
                    var formatPattern = rules[ruleIdx].FormatPattern;
                    if (!formatPattern.IsPrimitiveType)
                    {
                        // As the Schema is shared by parameter, so here only can change the ext. format
                        if (parameter.Extensions == null)
                            parameter.Extensions = new RecordOfStringAndAny();
                        parameter.Extensions.Format = formatPattern.ExtensionType;
                    }
                }
            }
        }

        private void TryUpdateObjectSchemaFormat(ObjectSchema objectSchema, IReadOnlyList<FormatRule> rules)
        {
            foreach (var property in objectSchema.Properties)
            {
                if (property.Schema is ArraySchema propertyArraySchema)
                    TryUpdateSchemaFormat(property.CSharpName(), propertyArraySchema.ElementType, rules);
                else
                    TryUpdateSchemaFormat(property.CSharpName(), property.Schema, rules);
            }
        }

        private int TryUpdateSchemaFormat(string name, Schema schema, IReadOnlyList<FormatRule> rules)
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
                var formatPattern = rules[ruleIdx].FormatPattern;
                if (formatPattern.IsPrimitiveType)
                    schema.Type = formatPattern.PrimitiveType!.Value;
                else
                {
                    if (schema.Extensions == null)
                        schema.Extensions = new RecordOfStringAndAny();
                    schema.Extensions.Format = formatPattern.ExtensionType!;
                }
            }
            schemaCache[schema] = name;
            return ruleIdx;
        }

        private int CheckRules(string name, IReadOnlyList<FormatRule> rules)
        {
            for (int i = 0; i < rules.Count; i++)
            {
                var namePattern = rules[i].NamePattern;
                var isMatch = namePattern.Pattern switch
                {
                    MatchPattern.StartWith => name.StartsWith(namePattern.Name, StringComparison.Ordinal),
                    MatchPattern.EndWith => name.EndsWith(namePattern.Name, StringComparison.Ordinal),
                    MatchPattern.Full => FullStringComapre(name, namePattern.Name),
                    _ => throw new NotImplementedException($"Unknown pattern {namePattern.Pattern}"),
                };
                if (isMatch)
                {
                    return i;
                }
            }
            return -1;
        }

        private IEnumerable<FormatRule> ParseRules(IReadOnlyDictionary<string, string> formatByNameRules)
        {
            if (formatByNameRules == null)
                yield break;
            foreach ((var key, var value) in formatByNameRules)
            {
                // parse match pattern
                var matchPattern = NamePattern.Parse(key);
                // parse format pattern
                var formatPattern = FormatPattern.Parse(value);
                yield return new FormatRule()
                {
                    NamePattern = matchPattern,
                    FormatPattern = formatPattern
                };
            }
        }

        private bool FullStringComapre(string strA, string strB)
        {
            if (strA.Length != strB.Length)
                return false;
            if (char.ToLower(strA[0]) != char.ToLower(strB[0]))
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
