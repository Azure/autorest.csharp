// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtensionBuilder
    {
        private readonly MgmtOutputLibrary _library;
        private readonly SourceInputModel? _sourceInputModel;

        private record MgmtExtensionInfo(IReadOnlyDictionary<CSharpType, MgmtExtension> ExtensionDict, IEnumerable<MgmtMockableExtension> MockableExtensions, MgmtOutputLibrary Library, SourceInputModel? SourceInputModel)
        {
            private IEnumerable<MgmtExtension>? _extensions;
            public IEnumerable<MgmtExtension> Extensions => _extensions ??= ExtensionDict.Values;

            private MgmtExtensionWrapper? _extensionWrapper;
            public MgmtExtensionWrapper ExtensionWrapper => _extensionWrapper ??= new MgmtExtensionWrapper(Extensions, MockableExtensions, Library, SourceInputModel);
        }

        private readonly IReadOnlyDictionary<Type, IEnumerable<InputOperation>> _extensionOperations;
        private readonly IReadOnlyDictionary<RequestPath, IEnumerable<InputOperation>> _armResourceExtensionOperations;

        public MgmtExtensionBuilder(Dictionary<Type, IEnumerable<InputOperation>> extensionOperations, Dictionary<RequestPath, IEnumerable<InputOperation>> armResourceExtensionOperations, MgmtOutputLibrary library, SourceInputModel? sourceInputModel)
        {
            _extensionOperations = extensionOperations;
            _armResourceExtensionOperations = armResourceExtensionOperations;
            _library = library;
            _sourceInputModel = sourceInputModel;
        }

        public MgmtExtensionWrapper ExtensionWrapper => ExtensionInfo.ExtensionWrapper;

        public IEnumerable<MgmtExtension> Extensions => ExtensionInfo.Extensions;

        public IEnumerable<MgmtMockableExtension> MockableExtensions => ExtensionInfo.MockableExtensions;

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
            var mockingExtensions = new SortedSet<MgmtMockableExtension>(new MgmtExtensionClientComparer());
            // create the extensions
            foreach (var (type, operations) in _extensionOperations)
            {
                var extension = new MgmtExtension(operations, mockingExtensions, type, _library, _sourceInputModel);
                extensionDict.Add(type, extension);
            }
            // add ArmResourceExtension methods
            var armResourceExtension = new ArmResourceExtension(_armResourceExtensionOperations, mockingExtensions, _library, _sourceInputModel);
            // add ArmClientExtension methods (which is also the TenantResource extension methods)
            var armClientExtension = new ArmClientExtension(_armResourceExtensionOperations, mockingExtensions, armResourceExtension, _library, _sourceInputModel);
            extensionDict.Add(typeof(ArmResource), armResourceExtension);
            extensionDict.Add(typeof(ArmClient), armClientExtension);

            // construct all possible extension clients
            // first we collection all possible combinations of the resource on operations
            var resourceToOperationsDict = new Dictionary<CSharpType, List<MgmtClientOperation>>();
            foreach (var (type, extension) in extensionDict)
            {
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
                var extensionClient = resourceType.Equals(typeof(ArmClient)) ?
                    new MgmtMockableArmClient(resourceType, operations, extensionForChildResources, _library, _sourceInputModel) :
                    new MgmtMockableExtension(resourceType, operations, extensionForChildResources, _library, _sourceInputModel);
                mockingExtensions.Add(extensionClient);
            }

            return new(extensionDict, mockingExtensions, _library, _sourceInputModel);
        }

        private struct CSharpTypeNameComparer : IComparer<CSharpType>
        {
            public int Compare(CSharpType? x, CSharpType? y)
            {
                return string.Compare(x?.Name, y?.Name);
            }
        }

        private struct MgmtExtensionClientComparer : IComparer<MgmtMockableExtension>
        {
            public int Compare(MgmtMockableExtension? x, MgmtMockableExtension? y)
            {
                return string.Compare(x?.Declaration.Name, y?.Declaration.Name);
            }
        }
    }
}
