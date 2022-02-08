﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeModelExtension
    {
        private static readonly ConcurrentDictionary<string, string> _cache = new ConcurrentDictionary<string, string>();

        public static void UpdateFrameworkTypes(this IEnumerable<Schema> allSchemas)
        {
            foreach (var schema in allSchemas)
            {
                if (schema is not ObjectSchema objSchema)
                    continue;

                foreach (var property in objSchema.Properties)
                {
                    if (property.Language.Default.Name.EndsWith("Uri"))
                        property.Schema.Type = AllSchemaTypes.Uri;
                }
            }
        }

        public static void UpdateSubscriptionIdForAllResource(this CodeModel codeModel)
        {
            bool setSubParam = false;
            foreach (var operationGroup in codeModel.OperationGroups)
            {
                foreach (var op in operationGroup.Operations)
                {
                    foreach (var p in op.Parameters)
                    {
                        //updater the first subscriptionId to be 'method'
                        if (!setSubParam && p.Language.Default.Name.Equals("subscriptionId", StringComparison.OrdinalIgnoreCase))
                        {
                            setSubParam = true;
                            p.Implementation = ImplementationLocation.Method;
                        }
                        //updater the first subscriptionId to be 'method'
                        if (p.Language.Default.Name.Equals("apiVersion", StringComparison.OrdinalIgnoreCase))
                        {
                            p.Implementation = ImplementationLocation.Client;
                        }
                    }
                }
            }
        }

        private static Regex? _regex;

        internal static void ApplyRenameRules(IReadOnlyDictionary<string, string> renameRules)
        {
            foreach ((var key, var value) in renameRules)
            {
                RenameRules.Add(key, value);
            }
            BuildRegex();
        }

        private static void BuildRegex()
        {
            if (RenameRules.Count == 0)
                return;
            var regexRawString = string.Join("|", RenameRules.Keys);
            // we are building the regex that matches
            // 1. it starts with a lower case letter or a digit which is considered as the end of its previous word
            //    or it is at the beginning of this string
            //    or we hit a word separator including \W, _, ., @, -, spaces
            // 2. it either should match one of the candidates in the rename rules dictionary
            // 3. it should followed by a upper case letter which is considered as the beginning of next word
            //    or it is the end of this string
            //    or we hit a word separator including \W, _, ., @, -, spaces
            _regex = new Regex(@$"([\W|_|\.|@|-|\s|\$\da-z]|^)({regexRawString})([\W|_|\.|@|-|\s|\$A-Z]|$)");
        }

        public static void UpdateAcronyms(this IEnumerable<Schema> allSchemas, IReadOnlyDictionary<string, string> renameRules)
        {
            ApplyRenameRules(renameRules);
            foreach (var schema in allSchemas)
            {
                TransformSchema(schema);
            }
        }

        private static void TransformSchema(Schema schema)
        {
            switch (schema)
            {
                case ChoiceSchema:
                case SealedChoiceSchema:
                    TransformBasicSchema(schema);
                    break;
                case ObjectSchema objSchema: // GroupSchema inherits ObjectSchema, therefore we do not need to handle that
                    TransformObjectSchema(objSchema);
                    break;
                default:
                    throw new InvalidOperationException($"Unknown schema type {schema.GetType()}");
            }
        }

        private static void TransformBasicSchema(Schema schema)
        {
            TransformLanguage(schema.Language);
        }

        private static void TransformLanguage(Languages languages)
        {
            var originalName = languages.Default.Name;
            if (_cache.TryGetValue(originalName, out var result))
            {
                languages.Default.Name = result;
                return;
            }
            result = originalName.EnsureNameCase();
            languages.Default.Name = result;
            _cache.TryAdd(originalName, result);
        }

        private static void TransformObjectSchema(ObjectSchema objSchema)
        {
            // transform the name of this schema
            TransformBasicSchema(objSchema);
            foreach (var property in objSchema.Properties)
            {
                TransformLanguage(property.Language);
            }
        }

        private static IDictionary<string, string> RenameRules = new Dictionary<string, string>();

        internal static string EnsureNameCase(this string name)
        {
            if (_regex == null)
                return name; // this means we do not have any replacement rules
            var strToMatch = name.FirstCharToUpperCase();
            var builder = new StringBuilder();
            var match = _regex.Match(strToMatch);
            while (match.Success)
            {
                // in our regular expression, the content we want to find is in the second group
                var matchGroup = match.Groups[2];
                var replaceValue = RenameRules[matchGroup.Value];
                // append everything between the beginning and the index of this match
                builder.Append(strToMatch.Substring(0, matchGroup.Index));
                // append the replaced value
                builder.Append(replaceValue);
                // move to whatever is left unmatched
                strToMatch = strToMatch.Substring(matchGroup.Index + matchGroup.Length);
                match = _regex.Match(strToMatch);
            }
            if (strToMatch.Length > 0)
                builder.Append(strToMatch);

            return builder.ToString();
        }
    }
}
