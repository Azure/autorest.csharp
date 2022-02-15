// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Resources;
using SubscriptionExtensions = AutoRest.CSharp.Mgmt.Output.SubscriptionExtensions;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class SubscriptionExtensionsWriter : MgmtExtensionWriter
    {
        public SubscriptionExtensionsWriter(CodeWriter writer, SubscriptionExtensions subscriptionExtensions, BuildContext<MgmtOutputLibrary> context)
            : base(writer, subscriptionExtensions, context, typeof(Subscription))
        {
        }

        protected override string Description => "A class to add extension methods to Subscription.";
        protected override string ExtensionOperationVariableName => "subscription";

        public override void Write()
        {
            using (_writer.Namespace(Context.DefaultNamespace))
            {
                _writer.WriteXmlDocumentationSummary($"{Description}");
                using (_writer.Scope($"{Accessibility} static partial class {TypeNameOfThis}"))
                {
                    // Write resource collection entries
                    WriteChildResourceEntries();

                    WriteExtensionClientGet();

                    var resourcesWithGetAllAsGenericMethod = new HashSet<Resource>();
                    foreach (var clientOperation in _extensions.ClientOperations)
                    {
                        WriteMethodWrapper(clientOperation, true);
                        WriteMethodWrapper(clientOperation, false);

                        // we only check if a resource needs a GetByName method when it has a List operation in the subscription extension.
                        // If its parent is Subscription, we will have a GetCollection method of that resource, which contains a GetAllAsGenericResource serves the same purpose.
                        if (CheckGetAllAsGenericMethod(clientOperation, out var resource))
                        {
                            // in case that a resource has multiple list methods at the subscription level (for instance one ListBySusbcription and one ListByLocation, location is not an available parent therefore it will show up here)
                            if (resourcesWithGetAllAsGenericMethod.Contains(resource))
                                continue;
                            WriteGetAllResourcesAsGenericMethodWrapper(resource, true);
                            WriteGetAllResourcesAsGenericMethodWrapper(resource, false);
                            resourcesWithGetAllAsGenericMethod.Add(resource);
                        }
                    }
                }
            }
        }

        private void WriteGetAllResourcesAsGenericMethodWrapper(Resource resource, bool isAsync)
        {
            _writer.Line();
            _writer.WriteXmlDocumentationSummary($"Filters the list of {resource.ResourceName.LastWordToPlural()} for a <see cref=\"{typeof(Subscription)}\" /> represented as generic resources.");
            _writer.WriteXmlDocumentationParameter("subscription", $"The <see cref=\"{typeof(Subscription)}\" /> instance the method will execute against.");
            _writer.WriteXmlDocumentationParameter("filter", $"The string to filter the list.");
            _writer.WriteXmlDocumentationParameter("expand", $"Comma-separated list of additional properties to be included in the response. Valid values include `createdTime`, `changedTime` and `provisioningState`.");
            _writer.WriteXmlDocumentationParameter("top", $"The number of results to return.");
            _writer.WriteXmlDocumentationParameter("cancellationToken", $"The cancellation token to use.");
            _writer.WriteXmlDocumentationReturns($"A collection of resource operations that may take multiple service requests to iterate over.");

            var responseType = typeof(GenericResource).WrapPageable(isAsync);
            string methodName = CreateMethodName($"Get{resource.Type.Name.ResourceNameToPlural()}AsGenericResources", isAsync);
            using (_writer.Scope($"public static {responseType} {methodName}(this {typeof(Subscription)} subscription, {typeof(string)} filter, {typeof(string)} expand, {typeof(int?)} top, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                _writer.Line($"return GetExtensionClient({ExtensionOperationVariableName}).{methodName}(filter, expand, top, cancellationToken);");
            }
        }
    }
}
