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

        protected override Type ExtensionOperationVariableType => typeof(Subscription);

        public override void WriteExtension(CodeWriter writer, BuildContext<MgmtOutputLibrary> context)
        {
            var @namespace = context.DefaultNamespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary($"{Description}");
                using (writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    foreach (var resource in context.Library.ArmResources)
                    {
                        if (ParentDetection.ParentResourceType(resource.OperationGroup, context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.Subscriptions)
                            || ParentDetection.ParentResourceType(resource.OperationGroup, context.Configuration.MgmtConfiguration).Equals(ResourceTypeBuilder.Tenant) && resource.OperationGroup.Operations.Any(op => op.ParentResourceType() == ResourceTypeBuilder.Subscriptions))
                        {
                            writer.Line($"#region {resource.Type.Name}");
                            if (resource.IsSingletonResource)
                            {
                                WriteGetSingletonResourceMethod(writer, resource);
                            }
                            else
                            {
                                // a non-singleton resource must have a resource container
                                WriteGetResourceContainerMethod(writer, resource.ResourceContainer!);
                            }
                            writer.LineRaw("#endregion");
                            writer.Line();
                        }
                        else
                        {
                            if (resource.SubscriptionExtensionsListMethods != null && resource.SubscriptionExtensionsListMethods.Count() > 0)
                            {
                                writer.Line($"#region {resource.Type.Name}");
                                WriteGetRestOperations(writer, resource.RestClient);

                                foreach (var listMethod in resource.SubscriptionExtensionsListMethods)
                                {
                                    var methodName = $"Get{resource.Type.Name.ToPlural()}";
                                    var count = resource.SubscriptionExtensionsListMethods.Count();
                                    if (listMethod.PagingMethod != null)
                                    {
                                        if (count > 1 && listMethod.PagingMethod.Name == "GetByLocation")
                                        {
                                            methodName = $"Get{resource.Type.Name.ToPlural()}ByLocation";
                                        }

                                        WriteListResourceMethod(writer, resource, listMethod.PagingMethod, methodName, context.Configuration.MgmtConfiguration, true);
                                        WriteListResourceMethod(writer, resource, listMethod.PagingMethod, methodName, context.Configuration.MgmtConfiguration, false);
                                    }

                                    if (listMethod.ClientMethod != null)
                                    {
                                        if (count > 1 && listMethod.ClientMethod.Name == "GetByLocation")
                                        {
                                            methodName = $"Get{resource.Type.Name.ToPlural()}ByLocation";
                                        }

                                        WriteExtensionClientMethod(writer, resource.OperationGroup, listMethod.ClientMethod, methodName, context, true, resource.RestClient);
                                        WriteExtensionClientMethod(writer, resource.OperationGroup, listMethod.ClientMethod, methodName, context, false, resource.RestClient);
                                    }

                                }

                                WriteListResourceByNameMethod(writer, resource, true);
                                WriteListResourceByNameMethod(writer, resource, false);
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

        private void WriteListResourceMethod(CodeWriter writer, Resource resource, PagingMethod pagingMethod, string methodName, MgmtConfiguration config, bool async)
        {
            if (pagingMethod.PagingResponse.ItemType.Name.Equals(resource.ResourceData.Type.Name))
            {
                WriteExtensionPagingMethod(writer, resource.Type, resource.RestClient, pagingMethod, methodName,
                $".Select(value => new {resource.Type.Name}(subscription, value))", async);
            }
            else
            {
                WriteExtensionPagingMethod(writer, pagingMethod.PagingResponse.ItemType, resource.RestClient, pagingMethod, methodName,
                $"", async);
            }
        }

        private void WriteListResourceByNameMethod(CodeWriter writer, Resource resource, bool async)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Filters the list of {resource.ResourceName.ToPlural()} for a <see cref=\"{typeof(Subscription)}\" /> represented as generic resources.");
            writer.WriteXmlDocumentationParameter("subscription", $"The <see cref=\"{typeof(Subscription)}\" /> instance the method will execute against.");
            writer.WriteXmlDocumentationParameter("filter", $"The string to filter the list.");
            writer.WriteXmlDocumentationParameter("expand", $"Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`.");
            writer.WriteXmlDocumentationParameter("top", $"The number of results to return.");
            writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");

            var responseType = typeof(GenericResource).WrapPageable(async);
            using (writer.Scope($"public static {responseType} {CreateMethodName($"Get{resource.ResourceName}ByName", async)}(this {typeof(Subscription)} subscription, {typeof(string)} filter, {typeof(string)} expand, {typeof(int?)} top, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                var filters = new CodeWriterDeclaration("filters");
                writer.Line($"{typeof(ResourceFilterCollection)} {filters:D} = new({resource.Type}.ResourceType);");
                writer.Line($"{filters}.SubstringFilter = filter;");
                writer.Line($"return {typeof(Core.ResourceListOperations)}.{CreateMethodName("GetAtContext", async)}(subscription, {filters}, expand, top, cancellationToken);");
            }
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
