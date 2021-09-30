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
using AutoRest.CSharp.Generation.Types;
using SubscriptionExtensions = AutoRest.CSharp.Mgmt.Output.SubscriptionExtensions;
using AutoRest.CSharp.Mgmt.Models;
using System.Diagnostics;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class SubscriptionExtensionsWriter : MgmtExtensionWriter
    {
        public SubscriptionExtensionsWriter(CodeWriter writer, SubscriptionExtensions subscriptionExtensions, BuildContext<MgmtOutputLibrary> context)
            : base(writer, subscriptionExtensions, context)
        {
            _extensions = subscriptionExtensions;
        }

        protected override string Description => "A class to add extension methods to Subscription.";
        protected override string ExtensionOperationVariableName => "subscription";

        protected override Type ExtensionOperationVariableType => typeof(Subscription);

        protected override TypeProvider This => _extensions;

        protected override CSharpType TypeOfThis => _extensions.Type;

        public override void Write()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    // Write resource container entries
                    WriteChildResourceEntries();
                    //foreach (var resource in Context.Library.ArmResources)
                    //{
                    //    if (ParentDetection.ParentResourceType(resource.OperationGroup, Config).Equals(ResourceTypeBuilder.Subscriptions)
                    //        || ParentDetection.ParentResourceType(resource.OperationGroup, Config).Equals(ResourceTypeBuilder.Tenant) && resource.OperationGroup.Operations.Any(op => op.ParentResourceType().Equals(ResourceTypeBuilder.Subscriptions, StringComparison.InvariantCultureIgnoreCase)))
                    //    {
                    //        _writer.Line($"#region {resource.Type.Name}");
                    //        if (resource.OperationGroup.TryGetSingletonResourceSuffix(Config, out var singletonResourceSuffix))
                    //        {
                    //            WriteGetSingletonResourceMethod(_writer, resource, singletonResourceSuffix);
                    //        }
                    //        else
                    //        {
                    //            // a non-singleton resource must have a resource container
                    //            WriteGetResourceContainerMethod(_writer, resource.ResourceContainer!);
                    //        }
                    //        _writer.LineRaw("#endregion");
                    //        _writer.Line();
                    //    }
                    //    else
                    //    {
                    //        if (resource.SubscriptionExtensionsListMethods != null && resource.SubscriptionExtensionsListMethods.Count() > 0)
                    //        {
                    //            _writer.Line($"#region {resource.Type.Name}");
                    //            WriteGetRestOperations(_writer, resource.RestClient);

                    //            foreach (var listMethod in resource.SubscriptionExtensionsListMethods)
                    //            {
                    //                var methodName = $"Get{resource.Type.Name.ToPlural()}";
                    //                var count = resource.SubscriptionExtensionsListMethods.Count();
                    //                if (listMethod.PagingMethod != null)
                    //                {
                    //                    if (count > 1 && listMethod.PagingMethod.Name == "GetAllByLocation")
                    //                    {
                    //                        methodName = $"Get{resource.Type.Name.ToPlural()}ByLocation";
                    //                    }

                    //                    WriteListResourceMethod(_writer, resource, listMethod.PagingMethod, methodName, Config, true);
                    //                    WriteListResourceMethod(_writer, resource, listMethod.PagingMethod, methodName, Config, false);
                    //                }

                    //                if (listMethod.ClientMethod != null)
                    //                {
                    //                    if (count > 1 && listMethod.ClientMethod.Name == "GetAllByLocation")
                    //                    {
                    //                        methodName = $"Get{resource.Type.Name.ToPlural()}ByLocation";
                    //                    }

                    //                    WriteExtensionClientMethod(_writer, resource.OperationGroup, listMethod.ClientMethod, methodName, true, resource.RestClient);
                    //                    WriteExtensionClientMethod(_writer, resource.OperationGroup, listMethod.ClientMethod, methodName, false, resource.RestClient);
                    //                }

                    //            }

                    //            WriteListResourceByNameMethod(_writer, resource, true);
                    //            WriteListResourceByNameMethod(_writer, resource, false);
                    //            _writer.LineRaw("#endregion");
                    //        }
                    //    }
                    //    _writer.Line();
                    //}

                    // Write RestOperations
                    foreach (var restClient in _extensions.RestClients)
                    {
                        WriteGetRestOperations(restClient);
                    }

                    // Write other orphan operations with the parent of ResourceGroup
                    foreach (var clientOperation in _extensions.ClientOperations)
                    {
                        var methodName = GetMethodName(clientOperation);
                        WriteMethod(clientOperation, methodName, true);
                        WriteMethod(clientOperation, methodName, false);
                    }

                    // Write list GenericResourceByName methods
                    WriteListResourceByNameMethods();

                    //var mgmtExtensionOperations = Context.Library.GetNonResourceOperations(ResourceTypeBuilder.Subscriptions);

                    //foreach (var mgmtExtensionOperation in mgmtExtensionOperations)
                    //{
                    //    _writer.Line($"#region {mgmtExtensionOperation.SchemaName}");
                    //    WriteGetRestOperations(_writer, mgmtExtensionOperation.RestClient);

                    //    // despite that we should only have one method, but we still using an IEnumerable
                    //    foreach (var pagingMethod in mgmtExtensionOperation.PagingMethods)
                    //    {
                    //        WriteExtensionPagingMethod(_writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, pagingMethod.Name, $"", true);
                    //        WriteExtensionPagingMethod(_writer, pagingMethod.PagingResponse.ItemType, mgmtExtensionOperation.RestClient, pagingMethod, pagingMethod.Name, $"", false);
                    //    }

                    //    foreach (var clientMethod in mgmtExtensionOperation.ClientMethods)
                    //    {
                    //        WriteExtensionClientMethod(_writer, mgmtExtensionOperation.OperationGroup, clientMethod, clientMethod.Name, true, mgmtExtensionOperation.RestClient);
                    //        WriteExtensionClientMethod(_writer, mgmtExtensionOperation.OperationGroup, clientMethod, clientMethod.Name, false, mgmtExtensionOperation.RestClient);
                    //    }

                    //    _writer.LineRaw("#endregion");
                    //    _writer.Line();
                    //}
                }
            }
        }

        protected string GetMethodName(MgmtClientOperation clientOperation)
        {
            // we should always have only one operation in extension classes
            Debug.Assert(clientOperation.Count == 1);
            var operation = clientOperation.First();

            if (operation.IsListMethod(out var itemType, out _))
            {
                if (!Context.Library.TryGetTypeProvider(itemType.Name, out var provider))
                    throw new InvalidOperationException($"Cannot find type {itemType.Name}");

                if (provider is ResourceData data)
                {
                    return $"Get{data.Type.Name.Substring(0, data.Type.Name.Length - 4).ToPlural()}";
                }
            }

            return operation.Name;
        }

        //private void WriteListResourceMethod(CodeWriter writer, Resource resource, PagingMethod pagingMethod, string methodName, MgmtConfiguration config, bool async)
        //{
        //    if (pagingMethod.PagingResponse.ItemType.Name.Equals(resource.ResourceData.Type.Name))
        //    {
        //        WriteExtensionPagingMethod(writer, resource.Type, resource.RestClient, pagingMethod, methodName,
        //        $".Select(value => new {resource.Type.Name}(subscription, value))", async);
        //    }
        //    else
        //    {
        //        WriteExtensionPagingMethod(writer, pagingMethod.PagingResponse.ItemType, resource.RestClient, pagingMethod, methodName,
        //        $"", async);
        //    }
        //}

        private void WriteListResourceByNameMethods()
        {
            foreach (var resource in Context.Library.ArmResources)
            {
                var parents = resource.Parent(Context);
                if (!parents.Contains(This))
                    continue;

                if (!resource.IsSingleton)
                {
                    _writer.Line();
                    _writer.Line($"#region {resource.ResourceName}");
                    WriteListResourceByNameMethod(resource, true);
                    WriteListResourceByNameMethod(resource, false);
                    _writer.Line($"#endregion");
                }
            }
        }

        private void WriteListResourceByNameMethod(Resource resource, bool async)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of {resource.ResourceName.ToPlural()} for a <see cref=\"{typeof(Subscription)}\" /> represented as generic resources.");
            _writer.WriteXmlDocumentationParameter("subscription", $"The <see cref=\"{typeof(Subscription)}\" /> instance the method will execute against.");
            _writer.WriteXmlDocumentationParameter("filter", $"The string to filter the list.");
            _writer.WriteXmlDocumentationParameter("expand", $"Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`.");
            _writer.WriteXmlDocumentationParameter("top", $"The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");

            var responseType = typeof(GenericResource).WrapPageable(async);
            using (_writer.Scope($"public static {responseType} {CreateMethodName($"Get{resource.ResourceName}ByName", async)}(this {typeof(Subscription)} subscription, {typeof(string)} filter, {typeof(string)} expand, {typeof(int?)} top, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                var filters = new CodeWriterDeclaration("filters");
                _writer.Line($"{typeof(ResourceFilterCollection)} {filters:D} = new({resource.Type}.ResourceType);");
                _writer.Line($"{filters}.SubstringFilter = filter;");
                _writer.Line($"return {typeof(Core.ResourceListOperations)}.{CreateMethodName("GetAtContext", async)}(subscription, {filters}, expand, top, cancellationToken);");
            }
        }
    }
}
