﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
using System.Diagnostics.CodeAnalysis;

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

                        // we only check if a resource needs a GetByName method when it has a List operation in the subscription extension.
                        // If its parent is Subscription, we will have a GetContainer method of that resource, which contains a GetAllAsGenericResource serves the same purpose.
                        if (CheckGetByNameMethod(clientOperation, out var resource))
                        {
                            WriteListResourceByNameMethod(resource, true);
                            WriteListResourceByNameMethod(resource, false);
                        }
                    }
                }
            }
        }

        // this method checks if the giving opertion corresponding to a list of resources. If it does, this resource will need a GetByName method.
        private bool CheckGetByNameMethod(MgmtClientOperation clientOperation, [MaybeNullWhen(false)] out Resource resource)
        {
            resource = null;
            if (clientOperation.First().IsListMethod(out var itemType, out _))
            {
                if (Context.Library.TryGetTypeProvider(itemType.Name, out var provider) && provider is ResourceData data)
                {
                    var resourcesOfResourceData = Context.Library.FindResources(data);
                    // TODO -- what if we have multiple resources corresponds to the same resource data?
                    // We are not able to determine which resource this opertion belongs, since the list in subsrcirption operation does not have any parenting relationship with other operations.
                    // temporarily directly return and doing nothing when this happens
                    if (resourcesOfResourceData.Count() > 1)
                        return false;
                    // only one resource, this needs a GetByName method
                    resource = resourcesOfResourceData.First();
                    return true;
                }
            }

            return false;
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
                    var resourcesOfResourceData = Context.Library.FindResources(data);
                    return $"Get{resourcesOfResourceData.First().ResourceName.ToPlural()}";
                }
            }

            return operation.Name;
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
