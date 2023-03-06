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

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class MgmtExtensionBuilder
    {
        private record MgmtExtensionInfo(MgmtExtensionWrapper ExtensionWrapper, IEnumerable<MgmtExtension> Extensions, IEnumerable<NewMgmtExtensionClient> ExtensionClients);

        private readonly IReadOnlyDictionary<Type, IEnumerable<Operation>> _extensionOperations;

        public MgmtExtensionBuilder(Dictionary<Type, IEnumerable<Operation>> extensionOperations, bool shouldSplit = true)
        {
            _extensionOperations = extensionOperations;
        }

        public MgmtExtensionWrapper ExtensionWrapper => ExtensionInfo.ExtensionWrapper;

        public IEnumerable<MgmtExtension> Extensions => ExtensionInfo.Extensions;

        public IEnumerable<NewMgmtExtensionClient> ExtensionClients => ExtensionInfo.ExtensionClients;

        private MgmtExtensionInfo? _info;
        private MgmtExtensionInfo ExtensionInfo => _info ??= EnsureMgmtExtensionInfo();

        private MgmtExtensionInfo EnsureMgmtExtensionInfo()
        {
            var extensions = new List<MgmtExtension>();
            var extensionClients = new List<NewMgmtExtensionClient>();
            // create the extensions
            foreach (var (type, operations) in _extensionOperations)
            {
                var extension = new MgmtExtension(operations, extensionClients, type);
                extensions.Add(extension);
            }
            // construct all possible extension clients
            // first we collection all possible combinations of the resource on operations
            var resourceToOperationsDict = new Dictionary<CSharpType, List<MgmtClientOperation>>();
            foreach (var extension in extensions)
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
                extensionClients.Add(new NewMgmtExtensionClient(resourceType, operations));
            }

            return new(new MgmtExtensionWrapper(extensions), extensions, extensionClients);
        }
    }
}
