// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeModelExtension
    {
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

        private static void ApplyAcronymsDictionary(MgmtConfiguration config)
        {
            foreach ((var key, var value) in config.AcroynmsDictionary)
            {
                CommonAcronyms.Add(key, value);
            }
        }

        public static void UpdateAcronyms(this CodeModel codeModel, MgmtConfiguration config)
        {
            ApplyAcronymsDictionary(config);
            foreach (var schema in codeModel.GetAllSchemas())
            {
                TransformSchema(schema);
            }
        }

        public static IEnumerable<Schema> GetAllSchemas(this CodeModel codeModel)
        {
            return codeModel.Schemas.Choices.Cast<Schema>()
                .Concat(codeModel.Schemas.SealedChoices)
                .Concat(codeModel.Schemas.Objects)
                .Concat(codeModel.Schemas.Groups);
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
            var newName = originalName.EnsureNameCase();
            languages.Default.Name = newName;
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

        private static IDictionary<string, string> CommonAcronyms = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "os", "OS" },
            { "ip", "IP" },
            { "vm", "Vm" },
            { "cpu", "Cpu" },
            { "dns", "Dns" },
            { "http", "Http" },
            { "https", "Https" },
        };

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
                    if (CommonAcronyms.TryGetValue(word, out var result))
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
