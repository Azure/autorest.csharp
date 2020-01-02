// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.V3.Plugins
{
    internal static class ModelExtensions
    {
        public static bool IsNullable(this Parameter parameter) => !(parameter.Required ?? false);
        public static bool IsNullable(this Property parameter) => !(parameter.Required ?? false);

        public static string CSharpName(this Parameter parameter) =>
            GetClientName(parameter.Extensions) ?? parameter.Language.Default.Name.ToCleanName();

        public static string CSharpName(this ChoiceValue choice) => choice.Language.Default.Name.ToCleanName();

        public static string CSharpName(this Property property) =>
            GetClientName(property.Extensions) ?? property.Language.Default.Name.ToCleanName();

        public static string CSharpName(this OperationGroup operationGroup)
        {
            string? clientName = GetClientName(operationGroup.Extensions);
            if (clientName != null)
            {
                return clientName;
            }

            string baseName = operationGroup.Language.Default.Name.IsNullOrEmpty() ? "All" : operationGroup.Language.Default.Name.ToCleanName();
            return $"{baseName}Operations";
        }

        public static string CSharpName(this Operation operation) =>
            operation.Language.Default.Name.ToCleanName();

        public static string CSharpName(this Schema schema) =>
            GetClientName(schema.Extensions) ?? schema.Language.Default.Name.ToCleanName();

        private static string? GetClientName(DictionaryOfAny? extensions)
        {
            if (extensions != null && extensions.TryGetValue("x-ms-client-name", out object? value))
            {
                return value as string;
            }

            return null;
        }
    }
}
