// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public static string GetClientSuffix(BuildContext context) => context.Configuration.AzureArm ? OperationsSuffixValue : ClientSuffixValue;

        public static string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"The {clientPrefix} service client." :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        public static string GetClientPrefix(string name, BuildContext context)
        {
            name = string.IsNullOrEmpty(name) ? context.CodeModel.Language.Default.Name : name.ToCleanName();

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

        public static IEnumerable<ClientMethod> BuildMethods(OperationGroup operationGroup, RestClient restClient, TypeDeclarationOptions Declaration, Func<OperationGroup, Operation, RestClientMethod, string>? nameOverrider = null)
        {
            foreach (var operation in operationGroup.Operations)
            {
                if (operation.IsLongRunning || operation.Language.Default.Paging != null)
                {
                    continue;
                }

                foreach (var request in operation.Requests)
                {
                    var name = operation.CSharpName();
                    RestClientMethod startMethod = restClient.GetOperationMethod(request);

                    yield return new ClientMethod(
                        nameOverrider?.Invoke(operationGroup, operation, startMethod) ?? name,
                        startMethod,
                        BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description),
                        new Diagnostic($"{Declaration.Name}.{name}", Array.Empty<DiagnosticAttribute>()),
                        operation.Accessibility ?? "public");
                }
            }
        }

        public static IEnumerable<PagingMethod> BuildPagingMethods(OperationGroup operationGroup, RestClient restClient, TypeDeclarationOptions Declaration)
        {
            foreach (var operation in operationGroup.Operations)
            {
                Paging? paging = operation.Language.Default.Paging;
                if (paging == null || operation.IsLongRunning)
                {
                    continue;
                }

                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod method = restClient.GetOperationMethod(serviceRequest);
                    RestClientMethod? nextPageMethod = restClient.GetNextOperationMethod(serviceRequest);

                    if (!(method.Responses.SingleOrDefault(r => r.ResponseBody != null)?.ResponseBody is ObjectResponseBody objectResponseBody))
                    {
                        throw new InvalidOperationException($"Method {method.Name} has to have a return value");
                    }

                    yield return new PagingMethod(
                        method,
                        nextPageMethod,
                        method.Name,
                        new Diagnostic($"{Declaration.Name}.{method.Name}"),
                        new PagingResponseInfo(paging, objectResponseBody.Type));
                }
            }
        }
    }
}
