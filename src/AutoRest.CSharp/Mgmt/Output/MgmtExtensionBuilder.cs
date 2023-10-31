// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
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
            public IEnumerable<MgmtExtension> Extensions => _extensions ??= ExtensionDict.Values;

            private MgmtExtensionWrapper? _extensionWrapper;
            public MgmtExtensionWrapper ExtensionWrapper => _extensionWrapper ??= new MgmtExtensionWrapper(Extensions, ExtensionClients);
        }

        private readonly IReadOnlyDictionary<Type, IEnumerable<InputOperation>> _extensionOperations;
        private readonly IReadOnlyDictionary<RequestPath, IEnumerable<InputOperation>> _armResourceExtensionOperations;

        public MgmtExtensionBuilder(Dictionary<Type, IEnumerable<InputOperation>> extensionOperations, Dictionary<RequestPath, IEnumerable<InputOperation>> armResourceExtensionOperations)
        {
            _extensionOperations = extensionOperations;
            _armResourceExtensionOperations = armResourceExtensionOperations;
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
            // we use a SortedDictionary or SortedSet here to make sure the order of extensions or extension clients is deterministic
            var extensionDict = new SortedDictionary<CSharpType, MgmtExtension>(new CSharpTypeNameComparer());
            var extensionClients = new SortedSet<MgmtExtensionClient>(new MgmtExtensionClientComparer());
            // create the extensions
            foreach (var (type, operations) in _extensionOperations)
            {
                var extension = new MgmtExtension(operations, extensionClients, type);
                extensionDict.Add(type, extension);
            }
            // add ArmResourceExtension methods
            extensionDict.Add(typeof(ArmResource), new ArmResourceExtension(_armResourceExtensionOperations, extensionClients));
            // add the ArmClientExtension
            extensionDict.Add(typeof(ArmClient), new ArmClientExtension(_extensionOperations[typeof(TenantResource)]));

            // construct all possible extension clients
            // first we collection all possible combinations of the resource on operations
            var resourceToOperationsDict = new Dictionary<CSharpType, List<MgmtClientOperation>>();
            foreach (var (type, extension) in extensionDict)
            {
                // explicitly skip ArmClient because it should not have an extension client
                if (type.Equals(typeof(ArmClient)))
                    continue;
                // we add an empty list for the type to ensure that the corresponding extension client will always be constructed, even empty
                resourceToOperationsDict.Add(type, new());
                foreach (var operation in extension.AllOperations)
                {
                    resourceToOperationsDict.AddInList(type, operation);
                }
            }
            // then we construct the extension clients
            foreach (var (resourceType, operations) in resourceToOperationsDict)
            {
                // find the extension if the resource type here is a framework type (when it is ResourceGroupResource, SubscriptionResource, etc) to ensure the ExtensionClient could property have the child resources
                extensionDict.TryGetValue(resourceType, out var extensionForChildResources);
                extensionClients.Add(new MgmtExtensionClient(resourceType, operations, extensionForChildResources));
            }

            return new(extensionDict, extensionClients);
        }

        private struct CSharpTypeNameComparer : IComparer<CSharpType>
        {
            public int Compare(CSharpType? x, CSharpType? y)
            {
                return string.Compare(x?.Name, y?.Name);
            }
        }

        private struct MgmtExtensionClientComparer : IComparer<MgmtExtensionClient>
        {
            public int Compare(MgmtExtensionClient? x, MgmtExtensionClient? y)
            {
                return string.Compare(x?.Declaration.Name, y?.Declaration.Name);
            }
        }
    }
}
