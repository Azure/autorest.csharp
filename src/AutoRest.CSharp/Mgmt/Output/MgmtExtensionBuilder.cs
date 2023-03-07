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
        private record MgmtExtensionInfo(IReadOnlyDictionary<CSharpType, MgmtExtension> ExtensionDict, IEnumerable<MgmtExtensionClient> ExtensionClients)
        {
            private IEnumerable<MgmtExtension>? _extensions;
            public IEnumerable<MgmtExtension> Extensions => _extensions ??= ExtensionDict.Values.OrderBy(e => e.Declaration.Name);

            private MgmtExtensionWrapper? _extensionWrapper;
            public MgmtExtensionWrapper ExtensionWrapper => _extensionWrapper ??= new MgmtExtensionWrapper(Extensions, ExtensionClients);
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
            return ExtensionInfo.ExtensionDict[armCoreType];
        }

        private MgmtExtensionInfo? _info;
        private MgmtExtensionInfo ExtensionInfo => _info ??= EnsureMgmtExtensionInfo();

        private MgmtExtensionInfo EnsureMgmtExtensionInfo()
        {
            var extensionDict = new Dictionary<CSharpType, MgmtExtension>();
            var extensionClients = new List<MgmtExtensionClient>();
            // create the extensions
            foreach (var (type, operations) in _extensionOperations)
            {
                var extension = new MgmtExtension(operations, extensionClients, type);
                extensionDict.Add(type, extension);
            }
            // add the ArmClientExtension
            extensionDict.Add(typeof(ArmClient), new ArmClientExtension(_extensionOperations[typeof(TenantResource)]));

            // construct all possible extension clients
            // first we collection all possible combinations of the resource on operations
            var resourceToOperationsDict = new Dictionary<CSharpType, List<MgmtClientOperation>>();
            foreach (var type in RequestPath.ExtensionChoices.Keys)
            {
                // we add an empty list for the type to ensure that the corresponding extension client will always be constructed, even empty
                resourceToOperationsDict.Add(type, new());
                foreach (var operation in extensionDict[type].AllOperations)
                {
                    if (operation.Resource != null)
                    {
                        resourceToOperationsDict.AddInList(operation.Resource.Type, operation);
                    }
                    else
                    {
                        resourceToOperationsDict.AddInList(type, operation);
                    }
                }
            }
            // then we construct the extension clients
            // here we sort the keys so that the sequence of extension clients are deterministic
            foreach (var resourceType in resourceToOperationsDict.Keys.OrderBy(type => type.Name))
            {
                var operations = resourceToOperationsDict[resourceType];
                // find the extension if the resource type here is a framework type (when it is ResourceGroupResource, SubscriptionResource, etc) to ensure the ExtensionClient could property have the child resources
                extensionDict.TryGetValue(resourceType, out var extensionForChildResources);
                extensionClients.Add(new MgmtExtensionClient(resourceType, operations, extensionForChildResources));
            }

            return new(extensionDict, extensionClients);
        }
    }
}
