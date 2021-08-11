// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager;
using Core = Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class SubscriptionExtensionsWriter : MgmtExtensionWriter
    {
        protected override string Description => "A class to add extension methods to Subscription.";
        protected override string TypeNameOfThis => ResourceTypeBuilder.TypeToExtensionName[ResourceTypeBuilder.Subscriptions];
        protected override string ExtensionOperationVariableName => "subscription";

        protected override Type ExtensionOperationVariableType => typeof(SubscriptionOperations);

        public override void WriteExtension(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            var @namespace = context.DefaultNamespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary($"{Description}");
                using (writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    foreach (var resource in context.Library.ArmResource)
                    {
                        if (ParentDetection.ParentResourceType(resource.OperationGroup, context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.Subscriptions)
                            || ParentDetection.ParentResourceType(resource.OperationGroup, context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.Tenant) && resource.OperationGroup.Operations.Any(op => op.ParentResourceType() == ResourceTypeBuilder.Subscriptions))
                        {
                            if (resource.OperationGroup.IsSingletonResource(context.Configuration.MgmtConfiguration))
                            {
                                var resourceOperation = context.Library.GetResourceOperation(resource.OperationGroup);
                                WriteChildSingletonGetOperationMethods(writer, resourceOperation);
                            }
                            else
                            {
                                writer.Line($"#region {resource.Type.Name}");
                                var resourceContainer = context.Library.GetResourceContainer(resource.OperationGroup);
                                WriteGetResourceContainerMethod(writer, resourceContainer!);
                                writer.LineRaw("#endregion");
                            }
                        }
                        else
                        {
                            var resourceOperation = context.Library.GetResourceOperation(resource.OperationGroup);
                            if (resourceOperation.SubscriptionExtensionsListMethods != null && resourceOperation.SubscriptionExtensionsListMethods.Count() > 0)
                            {
                                writer.Line($"#region {resource.Type.Name}");
                                WriteGetRestOperations(writer, resourceOperation.RestClient);

                                foreach (var listMethod in resourceOperation.SubscriptionExtensionsListMethods)
                                {
                                    var methodName = $"Get{resource.Type.Name.ToPlural()}";
                                    var count = resourceOperation.SubscriptionExtensionsListMethods.Count();
                                    if (listMethod.PagingMethod != null)
                                    {
                                        if (count > 1 && listMethod.PagingMethod.Name == "GetByLocation")
                                        {
                                            methodName = $"Get{resource.Type.Name.ToPlural()}ByLocation";
                                        }

                                        WriteListResourceMethod(writer, resource, resourceOperation, listMethod.PagingMethod, methodName, context.Configuration.MgmtConfiguration, true);
                                        WriteListResourceMethod(writer, resource, resourceOperation, listMethod.PagingMethod, methodName, context.Configuration.MgmtConfiguration, false);
                                    }

                                    if (listMethod.ClientMethod != null)
                                    {
                                        if (count > 1 && listMethod.ClientMethod.Name == "GetByLocation")
                                        {
                                            methodName = $"Get{resource.Type.Name.ToPlural()}ByLocation";
                                        }

                                        WriteExtensionClientMethod(writer, resourceOperation.OperationGroup, listMethod.ClientMethod, methodName, context, true, resourceOperation.RestClient);
                                        WriteExtensionClientMethod(writer, resourceOperation.OperationGroup, listMethod.ClientMethod, methodName, context, false, resourceOperation.RestClient);
                                    }

                                }

                                WriteListResourceByNameMethod(writer, resourceOperation, true);
                                WriteListResourceByNameMethod(writer, resourceOperation, false);
                                writer.LineRaw("#endregion");
                            }
                        }
                        writer.Line();
                    }

                    // write the standalone list operations with the parent of a subscription
                    var mgmtExtensionOperations = context.Library.GetNonResourceOperations(ResourceTypeBuilder.Subscriptions);

                    foreach (var mgmtExtensionOperation in mgmtExtensionOperations)
                    {
                        writer.Line($"#region {mgmtExtensionOperation.SchemaName}");
                        WriteGetRestOperations(writer, mgmtExtensionOperation.RestClient);

                        // despite that we should only have one method, but we still using an IEnumerable
                        foreach (var pagingMethod in mgmtExtensionOperation.PagingMethods)
                        {
                            WriteExtensionPagingMethod(writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, pagingMethod.Name, $"", true);
                            WriteExtensionPagingMethod(writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, pagingMethod.Name, $"", false);
                        }

                        foreach (var clientMethod in mgmtExtensionOperation.ClientMethods)
                        {
                            WriteExtensionClientMethod(writer, mgmtExtensionOperation.OperationGroup, clientMethod, clientMethod.Name, context, true, mgmtExtensionOperation.RestClient);
                            WriteExtensionClientMethod(writer, mgmtExtensionOperation.OperationGroup, clientMethod, clientMethod.Name, context, false, mgmtExtensionOperation.RestClient);
                        }

                        writer.LineRaw("#endregion");
                        writer.Line();
                    }

                }
            }
        }

        private void WriteGetResourceContainerMethod(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.WriteXmlDocumentationSummary($"Gets an object representing a {resourceContainer.Type.Name} along with the instance operations that can be performed on it.");
            writer.WriteXmlDocumentationParameter("subscription", $"The <see cref=\"{typeof(SubscriptionOperations)}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resourceContainer.Type.Name}\" /> object.");

            using (writer.Scope($"public static {resourceContainer.Type} Get{resourceContainer.Resource.Type.Name.ToPlural()}(this {typeof(SubscriptionOperations)} {ExtensionOperationVariableName})"))
            {
                writer.Line($"return new {resourceContainer.Type}({ExtensionOperationVariableName});");
            }
        }

        private void WriteListResourceMethod(CodeWriter writer, Resource resource, ResourceOperation resourceOperation, PagingMethod pagingMethod, string methodName, MgmtConfiguration config, bool async)
        {
            if (pagingMethod.PagingResponse.ItemType.Name.Equals(resourceOperation.ResourceData.Type.Name))
            {
                WriteExtensionPagingMethod(writer, resource.Type, resourceOperation.RestClient, pagingMethod, methodName,
                $".Select(value => new {resource.Type.Name}(subscription, value))", async);
            }
            else
            {
                WriteExtensionPagingMethod(writer, pagingMethod.PagingResponse.ItemType, resourceOperation.RestClient, pagingMethod, methodName,
                $"", async);
            }
        }

        private void WriteListResourceByNameMethod(CodeWriter writer, ResourceOperation resourceOperation, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Filters the list of {resourceOperation.ResourceName.ToPlural()} for a <see cref=\"{typeof(SubscriptionOperations)}\" /> represented as generic resources.");
            writer.WriteXmlDocumentationParameter("subscription", $"The <see cref=\"{typeof(SubscriptionOperations)}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationParameter("filter", $"The string to filter the list.");
            writer.WriteXmlDocumentationParameter("expand", $"Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`.");
            writer.WriteXmlDocumentationParameter("top", $"The number of results to return.");
            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");

            var responseType = typeof(GenericResourceExpanded).WrapPageable(async);
            using (writer.Scope($"public static {responseType} {CreateMethodName($"Get{resourceOperation.ResourceName}ByName", async)}(this {typeof(SubscriptionOperations)} subscription, {typeof(string)} filter, {typeof(string)} expand, {typeof(int?)} top, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                var filters = new CodeWriterDeclaration("filters");
                writer.Line($"{typeof(ResourceFilterCollection)} {filters:D} = new({resourceOperation.Type}.ResourceType);");
                writer.Line($"{filters}.SubstringFilter = filter;");
                writer.Line($"return {typeof(Core.ResourceListOperations)}.{CreateMethodName("GetAtContext", async)}(subscription, {filters}, expand, top, cancellationToken);");
            }
        }

        private void WriteChildSingletonGetOperationMethods(CodeWriter writer, ResourceOperation resourceOperation)
        {
            // The resourceOperation already has a suffix "Operations" therefore it is already in plural form
            // there we do not need to change it to plural again
            writer.Line($"#region Get {resourceOperation.Type.Name} operation");

            writer.WriteXmlDocumentationSummary($"Gets an object representing a {resourceOperation.Type.Name} along with the instance operations that can be performed on it.");
            writer.WriteXmlDocumentationReturns($"Returns a <see cref=\"{resourceOperation.Type.Name}\" /> object.");
            using (writer.Scope($"public static {resourceOperation.Type} Get{resourceOperation.Type.Name}(this {typeof(SubscriptionOperations)} subscriptionOperations)"))
            {
                writer.Line($"return new {resourceOperation.Type.Name}(subscriptionOperations);");
            }
            writer.LineRaw("#endregion");
            writer.Line();
        }

        protected override bool ShouldPassThrough(ref string dotParent, Stack<string> parentNameStack, Parameter parameter, ref string valueExpression)
        {
            if (string.Equals(parameter.Name, "subscriptionId", StringComparison.InvariantCultureIgnoreCase))
            {
                valueExpression = $"{ExtensionOperationVariableName}.Id.Name";
                return false;
            }
            return true;
        }

        protected override void MakeResourceNameParamPassThrough(RestClientMethod method, List<ParameterMapping> parameterMapping, Stack<string> parentNameStack)
        {
            // override to do nothing since we do not need anything from subscription.Id in the SubscriptionExtensions class
        }
    }
}
