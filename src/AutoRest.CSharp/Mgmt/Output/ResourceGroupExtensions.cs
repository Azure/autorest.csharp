// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceGroupExtensions : TypeProvider
    {
        protected BuildContext<MgmtOutputLibrary> _context;

        private IEnumerable<Operation> _allOperations;

        public ResourceGroupExtensions(IEnumerable<Operation> allOperations, BuildContext<MgmtOutputLibrary> context) : base(context)
        {
            _context = context;
            _allOperations = allOperations;
        }

        protected override string DefaultName => "ResourceGroupExtensions";

        protected override string DefaultAccessibility => "public";

        public IEnumerable<MgmtClientOperation> ClientOperations => _clientOperations ??= EnsureClientOperations();

        private IEnumerable<MgmtClientOperation>? _clientOperations;
        private IEnumerable<MgmtClientOperation> EnsureClientOperations()
        {
            return _allOperations.Select(operation => MgmtClientOperation.FromOperation(
                new MgmtRestOperation(
                    _context.Library.RestClientMethods[operation],
                    _context.Library.GetRestClient(operation.GetHttpPath()),
                    RequestPath.ResourceGroup)));
        }

        private IEnumerable<MgmtRestClient>? _restClients;
        public IEnumerable<MgmtRestClient> RestClients => _restClients ??= EnsureRestClients();

        private IEnumerable<MgmtRestClient> EnsureRestClients()
        {
            return ClientOperations.SelectMany(operation => operation.Select(restOperation => restOperation.RestClient)).Distinct();
        }
    }
}
