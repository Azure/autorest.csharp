// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal static class ClientBuilder
    {
        private const string ClientSuffixValue = "Client";
        private const string OperationsSuffixValue = "Operations";

        public static string GetClientSuffix() => Configuration.AzureArm ? OperationsSuffixValue : ClientSuffixValue;

        public static string CreateDescription(OperationGroup operationGroup, string clientPrefix)
            => CreateDescription(operationGroup.Language.Default.Description, clientPrefix);

        public static string CreateDescription(string description, string clientPrefix)
            => string.IsNullOrWhiteSpace(description)
                ? $"The {clientPrefix} service client."
                : BuilderHelpers.EscapeXmlDocDescription(description);

        private const string AzurePackageNamespacePrefix = "Azure.";
        private const string AzureMgmtPackageNamespacePrefix = "Azure.ResourceManager.";

        /// <summary>
        /// Returns a the name of the RP from the namespace by the following rule:
        /// If the namespace starts with `Azure.ResourceManager` and it is a management plane package, returns every segment concating after the `Azure.ResourceManager` prefix.
        /// If the namespace starts with `Azure`, returns every segment concating together after the `Azure` prefix
        /// Returns the namespace as the RP name if nothing matches.
        /// </summary>
        /// <param name="namespaceName"></param>
        /// <returns></returns>
        public static string GetRPName(string namespaceName)
        {
            var segments = namespaceName.Split('.');
            if (namespaceName.StartsWith(AzurePackageNamespacePrefix))
            {
                if (Configuration.AzureArm && Configuration.MgmtConfiguration.IsArmCore)
                {
                    return "ResourceManager";
                }

                if (Configuration.AzureArm && namespaceName.StartsWith(AzureMgmtPackageNamespacePrefix))
                {
                    return string.Join("", segments.Skip(2)); // skips "Azure" and "ResourceManager"
                }

                return string.Join("", segments.Skip(1));
            }
            return string.Join("", segments);
        }

        public static string GetClientPrefix(string? name, string namespaceName)
        {
            name = string.IsNullOrEmpty(name) ? namespaceName : name.ToCleanName();

            if (name.EndsWith(OperationsSuffixValue) && name.Length >= OperationsSuffixValue.Length)
            {
                name = name.Substring(0, name.Length - OperationsSuffixValue.Length);
            }

            if (name.EndsWith(ClientSuffixValue) && name.Length >= ClientSuffixValue.Length)
            {
                name = name.Substring(0, name.Length - ClientSuffixValue.Length);
            }

            return name;
        }
    }
}
