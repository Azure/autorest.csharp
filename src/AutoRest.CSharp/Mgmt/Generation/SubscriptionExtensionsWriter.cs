// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class SubscriptionExtensionsWriter : ClientWriter
    {
        public void WriteExtension(CodeWriter writer, BuildContext<MgmtOutputLibrary> context, IEnumerable<Resource> resources)
        {
            var @namespace = context.DefaultNamespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary("Extension methods for convenient access on SubscriptionOperations in a client");
                using (writer.Scope($"public static partial class SubscriptionExtensions"))
                {
                    foreach (var resource in resources)
                    {
                        if (!resource.OperationGroup.IsSingletonResource(context.Configuration.MgmtConfiguration)&&
                            ParentDetection.ParentResourceType(resource.OperationGroup, context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.Subscriptions))
                        {
                            writer.Line($"#region {resource.Type.Name}");
                            var resourceContainer = context.Library.GetResourceContainer(resource.OperationGroup);
                            WriteGetResourceContainerMethod(writer, resourceContainer);
                            writer.LineRaw("#endregion");
                        }
                        else if (resource.OperationGroup.IsSingletonResource(context.Configuration.MgmtConfiguration) &&
                            ParentDetection.ParentResourceType(resource.OperationGroup, context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.Subscriptions))
                        {
                            var resourceOperation = context.Library.GetResourceOperation(resource.OperationGroup);
                            WriteChildSingletonGetOperationMethods(writer, resourceOperation);
                        }
                        else
                        {
                            var resourceOperation = context.Library.GetResourceOperation(resource.OperationGroup);
                            PagingMethod? pagingMethod = default;
                            foreach (var method in resourceOperation.PagingMethods)
                            {
                                if (method.Name == "ListAll" || method.Name == "ListBySubscription")
                                {
                                    pagingMethod = method;
                                    break;
                                }
                            }
                            if (pagingMethod != null)
                            {
                                writer.Line($"#region {resource.Type.Name}");
                                WriteGetResourceRestOperations(writer, resourceOperation);

                                WriteListResourceMethod(writer, resource, resourceOperation, pagingMethod, true);
                                WritePagingOperation(writer, pagingMethod, resourceOperation.RestClient, true);

                                WriteListResourceMethod(writer, resource, resourceOperation, pagingMethod, false);
                                WritePagingOperation(writer, pagingMethod, resourceOperation.RestClient, false);

                                WriteListResourceByNameMethod(writer, resourceOperation, true);
                                WriteListResourceByNameMethod(writer, resourceOperation, false);
                                writer.LineRaw("#endregion");
                            }
                        }
                        writer.Line();
                    }
                }
            }
        }

        private void WriteGetResourceContainerMethod(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {resourceContainer.Type.Name} along with the instance operations that can be performed on it.");
            writer.WriteXmlDocumentationParameter("subscription", $"The <see cref=\"{typeof(SubscriptionOperations)}\" /> instance the method will execute against.");

            using (writer.Scope($"public static {resourceContainer.Type} Get{resourceContainer.Type.Name}(this {typeof(SubscriptionOperations)} subscription)"))
            {
                writer.Line($"return new {resourceContainer.Type}(subscription);");
            }
        }

        private void WriteGetResourceRestOperations(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.Append($"private static {resourceOperation.RestClient.Type} Get{resourceOperation.RestClient.Type.Name}({typeof(ClientDiagnostics)} clientDiagnostics, TokenCredential credential, ArmClientOptions clientOptions, ");
            // TODO: Use https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5783 rest client parameters
            foreach (Parameter parameter in resourceOperation.RestClient.Parameters)
            {
                if (parameter.IsApiVersionParameter)
                {
                    continue;
                }
                writer.WriteParameter(parameter);
            }
            writer.RemoveTrailingComma();
            writer.Append($")");

            using (writer.Scope())
            {
                var httpPipeline = new CodeWriterDeclaration("httpPipeline");
                writer.Line($"var {httpPipeline:D} = {typeof(Azure.Core.ManagementPipelineBuilder)}.Build(credential, endpoint, clientOptions);");
                writer.Append($"return new {resourceOperation.RestClient.Type}(clientDiagnostics, httpPipeline, ");
                foreach (var parameter in resourceOperation.RestClient.Parameters)
                {
                    if (parameter.IsApiVersionParameter)
                    {
                        continue;
                    }
                    writer.Append($"{parameter.Name}, ");
                }
                writer.RemoveTrailingComma();
                writer.Line($");");
            }
            writer.Line();
        }

        private void WritePagingOperation(CodeWriter writer, PagingMethod pagingMethod, MgmtRestClient RestClient, bool async)
        {
            // Paging method signature
            var pageType = pagingMethod.PagingResponse.ItemType;
            CSharpType responseType = async ? new CSharpType(typeof(AsyncPageable<>), pageType) : new CSharpType(typeof(Pageable<>), pageType);
            var parameters = pagingMethod.Method.Parameters;

            writer.WriteXmlDocumentationSummary(pagingMethod.Method.Description);
            writer.WriteXmlDocumentationParameter("clientDiagnostics", "The handler for diagnostic messaging in the client.");
            writer.WriteXmlDocumentationParameter("restOperations", "Resource client operations.");

            foreach (Parameter parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter.Name, parameter.Description);
            }

            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentationRequiredParametersException(parameters);

            writer.Append($"private static {responseType} {CreateMethodName(pagingMethod.Name, async)}({typeof(ClientDiagnostics)} clientDiagnostics, {RestClient.Type} restOperations,");

            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameter(parameter);
            }

            writer.Line($"{typeof(CancellationToken)} cancellationToken = default)");

            // Paging method definiton
            WritePagingOperationDefinition(writer, pagingMethod, async, "restOperations", "clientDiagnostics");
        }

        private void WriteListResourceMethod(CodeWriter writer, Resource resource, ResourceOperation resourceOperation, PagingMethod pagingMethod, bool async)
        {
            writer.WriteXmlDocumentationSummary($"Lists the {resource.Type.Name}s for this {typeof(SubscriptionOperations)}.");
            writer.WriteXmlDocumentationParameter("subscription", $"The <see cref=\"{typeof(SubscriptionOperations)}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentation("return", $"A collection of resource operations that may take multiple service requests to iterate over.");

            var pageType = resource.Type;
            CSharpType responseType = async ? new CSharpType(typeof(AsyncPageable<>), pageType) : new CSharpType(typeof(Pageable<>), pageType);
            var methodName = $"List{resource.Type.Name}";
            using (writer.Scope($"public static {responseType} {CreateMethodName(methodName, async)}(this {typeof(SubscriptionOperations)} subscription, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Append($"return subscription.ListResources((baseUri, credential, options) =>");
                using (writer.Scope())
                {
                    var clientDiagnostics = new CodeWriterDeclaration("clientDiagnostics");
                    var restOperations = new CodeWriterDeclaration("restOperations");
                    var result = new CodeWriterDeclaration("result");

                    writer.Line($"var {clientDiagnostics:D} = new {typeof(ClientDiagnostics)}(options);");
                    // TODO: Remove hard coded rest client parameters after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5783
                    writer.Line($"var {restOperations:D} = Get{resourceOperation.RestClient.Type.Name}(clientDiagnostics, credential, options, subscription.Id.SubscriptionId, baseUri);");
                    writer.Line($"var {result:D} = {CreateMethodName(pagingMethod.Name, async)}({clientDiagnostics}, {restOperations});");

                    CSharpType[] arguments = { pagingMethod.PagingResponse.ItemType, resource.Type };
                    CSharpType returnType = async ? new CSharpType(typeof(PhWrappingAsyncPageable<,>), arguments) : new CSharpType(typeof(PhWrappingPageable<,>), arguments);
                    writer.Line($"return new {returnType}(");
                    writer.Line($"{result},");
                    writer.Line($"s => new {resource.Type}(subscription, s));");
                }
                writer.Append($");");
            }
            writer.Line();
        }

        private void WriteListResourceByNameMethod(CodeWriter writer, ResourceOperation resourceOperation, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Filters the list of {resourceOperation.ResourceName}s for a {typeof(SubscriptionOperations)} represented as generic resources.");
            writer.WriteXmlDocumentationParameter("subscription", $"The <see cref=\"{typeof(SubscriptionOperations)}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationParameter("filter", "The string to filter the list.");
            writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "The cancellation token to use.");
            writer.WriteXmlDocumentation("return", $"A collection of resource operations that may take multiple service requests to iterate over.");

            CSharpType responseType = async ? new CSharpType(typeof(AsyncPageable<>), typeof(GenericResource)) : new CSharpType(typeof(Pageable<>), typeof(GenericResource));
            using (writer.Scope($"public static {responseType} {CreateMethodName($"List{resourceOperation.ResourceName}ByName", async)}(this {typeof(SubscriptionOperations)} subscription, {typeof(string)} filter, {typeof(int?)} top, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                var filters = new CodeWriterDeclaration("filters");
                writer.Line($"{typeof(ResourceFilterCollection)} {filters:D} = new({resourceOperation.Type}.ResourceType);");
                writer.Line($"{filters}.SubstringFilter = filter;");
                writer.Line($"return {typeof(ResourceListOperations)}.{CreateMethodName("ListAtContext", async)}(subscription, {filters}, top, cancellationToken);");
            }
        }

        private void WriteChildSingletonGetOperationMethods(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.Line($"#region Get {StringExtensions.Pluralization(resourceOperation.Type.Name)} operation");

            writer.WriteXmlDocumentationSummary($"Gets an object representing a {resourceOperation.Type.Name} along with the instance operations that can be performed on it.");
            writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resourceOperation.Type.Name}\" /> object.");
            using (writer.Scope($"public static {resourceOperation.Type} Get{StringExtensions.Pluralization(resourceOperation.Type.Name)}(this {typeof(SubscriptionOperations)} subscriptionOperations)"))
            {
                writer.Line($"return new {resourceOperation.Type.Name}(subscriptionOperations);");
            }
            writer.LineRaw("#endregion");
            writer.Line();
        }
    }
}
