// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeModelExtension
    {
        private static readonly IDictionary<string, string> _cache = new ConcurrentDictionary<string, string>();

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

        internal static void ApplyRenameRules(IReadOnlyDictionary<string, string> renameRules)
        {
            foreach ((var key, var value) in renameRules)
            {
                RenameRules.Add(key, value);
            }
        }

        public static void UpdateAcronyms(this CodeModel codeModel, IReadOnlyDictionary<string, string> renameRules)
        {
            ApplyRenameRules(renameRules);
            foreach (var schema in codeModel.GetAllSchemas())
            {
                TransformSchema(schema);
            }
        }

        private static IEnumerable<Schema>? _allSchemas;
        public static IEnumerable<Schema> GetAllSchemas(this CodeModel codeModel)
        {
            if (_allSchemas != null)
                return _allSchemas;

            _allSchemas = codeModel.Schemas.Choices.Cast<Schema>()
                .Concat(codeModel.Schemas.SealedChoices)
                .Concat(codeModel.Schemas.Objects)
                .Concat(codeModel.Schemas.Groups);
            return _allSchemas;
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

        internal static string EnsureNameCase(this string name, bool lowerFirst = false)
        {
            var words = name.SplitByCamelCase().ToArray();
            var builder = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                if (lowerFirst && i == 0)
                {
                    // we are the first word, all letters should be in lower case, including acronyms
                    word = word.ToLowerInvariant();
                }
                else
                {
                    if (RenameRules.TryGetValue(word, out var result))
                    {
                        word = result;
                    }
                }

                builder.Append(word);
            }

            return builder.ToString();
        }
    }
}
