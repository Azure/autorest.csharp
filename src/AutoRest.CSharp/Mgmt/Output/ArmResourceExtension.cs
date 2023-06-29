// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Models;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ArmResourceExtension : MgmtExtension
    {
        private readonly List<MgmtExtension> _extensions;
        public ArmResourceExtension(IReadOnlyDictionary<RequestPath, IEnumerable<Operation>> armResourceExtensionOperations, IEnumerable<MgmtExtensionClient> extensionClients) : base(Enumerable.Empty<Operation>(), extensionClients, typeof(ArmResource), RequestPath.Any)
        {
            _extensions = new();
            foreach (var (parentRequestPath, operations) in armResourceExtensionOperations)
            {
                _extensions.Add(new(operations, extensionClients, typeof(ArmResource), parentRequestPath));
            }
        }

        protected override IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            foreach (var extension in _extensions)
            {
                foreach (var operation in extension.ClientOperations)
                    yield return operation;
            }
        }
    }
}
