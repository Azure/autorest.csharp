// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Types;
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
                : BuilderHelpers.EscapeXmlDescription(description);

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

        /// <summary>
        /// This function builds an enumerable of <see cref="ClientMethod"/> from an <see cref="OperationGroup"/> and a <see cref="RestClient"/>
        /// </summary>
        /// <param name="inputClient">The InputClient to build methods from</param>
        /// <param name="restClient">The corresponding RestClient to the operation group</param>
        /// <param name="declaration">The type declaration options</param>
        /// <returns>An enumerable of <see cref="ClientMethod"/></returns>
        public static IEnumerable<ClientMethod> BuildMethods(InputClient inputClient, RestClient restClient, TypeDeclarationOptions declaration)
        {
            foreach (var operation in inputClient.Operations)
            {
                if (operation.LongRunning != null || operation.Paging != null)
                {
                    continue;
                }

                RestClientMethod startMethod = restClient.GetOperationMethod(operation);
                var name = operation.Name.ToCleanName();

                yield return new ClientMethod(
                    name,
                    startMethod,
                    BuilderHelpers.EscapeXmlDescription(operation.Description),
                    new Diagnostic($"{declaration.Name}.{name}", Array.Empty<DiagnosticAttribute>()),
                    operation.Accessibility ?? "public");
            }
        }
    }
}
