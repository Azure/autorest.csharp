// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtensionBuilder
    {
        private record MgmtExtensionInfo(MgmtExtensionWrapper ExtensionWrapper, IReadOnlyDictionary<Type, MgmtExtension> ExtensionsDict, IEnumerable<MgmtExtensionClient> ExtensionClients)
        {
            public IEnumerable<MgmtExtension> Extensions => ExtensionsDict.Values;
        }

        private readonly IReadOnlyDictionary<Type, IEnumerable<Operation>> _extensionOperations;

        public MgmtExtensionBuilder(Dictionary<Type, IEnumerable<Operation>> extensionOperations, bool shouldSplit = true)
        {
            _extensionOperations = extensionOperations;
        }

        public MgmtExtensionWrapper ExtensionWrapper => ExtensionInfo.ExtensionWrapper;

        public IEnumerable<MgmtExtension> Extensions => ExtensionInfo.Extensions;

        public IEnumerable<MgmtExtensionClient> ExtensionClients => ExtensionInfo.ExtensionClients;

        public MgmtExtension GetExtension(Type armCoreType)
        {
            return ExtensionInfo.ExtensionsDict[armCoreType];
        }

        private MgmtExtensionInfo? _info;
        private MgmtExtensionInfo ExtensionInfo => _info ??= EnsureMgmtExtensionInfo();

        private MgmtExtensionInfo EnsureMgmtExtensionInfo()
        {
            var extensions = new Dictionary<Type, MgmtExtension>();
            var extensionClients = new List<MgmtExtensionClient>();
            // create the extensions
            foreach (var (type, operations) in _extensionOperations)
            {
                var extension = new MgmtExtension(operations, extensionClients, type);
                extensions.Add(type, extension);
            }
            // add the ArmClientExtension
            extensions.Add(typeof(ArmClient), new ArmClientExtension(_extensionOperations[typeof(TenantResource)]));

            // construct all possible extension clients
            // first we collection all possible combinations of the resource on operations
            var resourceToOperationsDict = new Dictionary<CSharpType, List<MgmtClientOperation>>();
            // we need to add the system types in at the beginning because we might not have an operation corresponding to that below to ensure those extension clients will always be constructed
            foreach (var type in RequestPath.ExtensionChoices.Keys)
            {
                resourceToOperationsDict.Add(type, new());
            }
            foreach (var (_, extension) in extensions)
            {
                foreach (var operation in extension.AllOperations)
                {
                    if (operation.Resource != null)
                    {
                        resourceToOperationsDict.AddInList(operation.Resource.Type, operation);
                    }
                    else
                    {
                        resourceToOperationsDict.AddInList(extension.ArmCoreType, operation);
                    }
                }
            }
            // then we construct the extension clients
            foreach (var (resourceType, operations) in resourceToOperationsDict)
            {
                // find the extension if the resource type here is a framework type (when it is ResourceGroupResource, SubscriptionResource, etc) to ensure the ExtensionClient could property have the child resources
                MgmtExtension? extensionForChildResources = null;
                if (resourceType.IsFrameworkType && extensions.TryGetValue(resourceType.FrameworkType, out var extension))
                    extensionForChildResources = extension;
                extensionClients.Add(new MgmtExtensionClient(resourceType, operations, extensionForChildResources));
            }

            return new(new MgmtExtensionWrapper(extensions.Values, extensionClients), extensions, extensionClients);
        }
    }
}
