// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.AutoRest.Plugins;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class LowLevelOutputLibrary : OutputLibrary
    {
        private readonly CodeModel _codeModel;
        private readonly BuildContext<LowLevelOutputLibrary> _context;
        private CachedDictionary<OperationGroup, LowLevelRestClient> _internalRestClients;
        private CachedDictionary<OperationGroup, LowLevelDataPlaneClient> _publicClients;
        private CachedDictionary<LowLevelDataPlaneClient, IReadOnlyList<LowLevelDataPlaneClient>> _subClients;
        private Lazy<HashSet<string>> _subClientOperationGroups;
        private Lazy<HashSet<string>> _publicClientOperationGroups;

        public LowLevelOutputLibrary(CodeModel codeModel, BuildContext<LowLevelOutputLibrary> context) : base(codeModel, context)
        {
            _codeModel = codeModel;
            _context = context;
            _internalRestClients = new CachedDictionary<OperationGroup, LowLevelRestClient>(EnsureRestClients);
            _publicClients = new CachedDictionary<OperationGroup, LowLevelDataPlaneClient>(EnsureClients);
            _subClients = new CachedDictionary<LowLevelDataPlaneClient, IReadOnlyList<LowLevelDataPlaneClient>>(EnsureSubClients);
            _subClientOperationGroups = new Lazy<HashSet<string>>(EnsureSubClientOperationGroups);
            _publicClientOperationGroups = new Lazy<HashSet<string>>(EnsurePublicClientOperationGroups);
        }

        public IEnumerable<LowLevelRestClient> RestClients => _internalRestClients.Values;

        public IEnumerable<LowLevelDataPlaneClient> Clients => _publicClients.Values;

        private Dictionary<OperationGroup, LowLevelRestClient> EnsureRestClients()
        {
            var restClients = new Dictionary<OperationGroup, LowLevelRestClient>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                restClients.Add(operationGroup, new LowLevelRestClient(operationGroup, _context));
            }

            return restClients;
        }

        private Dictionary<OperationGroup, LowLevelDataPlaneClient> EnsureClients()
        {
            var clients = new Dictionary<OperationGroup, LowLevelDataPlaneClient>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                clients.Add(operationGroup, new LowLevelDataPlaneClient(operationGroup, _context));
            }

            return clients;
        }

        private Dictionary<LowLevelDataPlaneClient, IReadOnlyList<LowLevelDataPlaneClient>> EnsureSubClients()
        {
            // Returns a mapping of an operation group name to the names of operation groups which are direct sub-clients
            // of the operation group.
            IEnumerable<KeyValuePair<string, string[]>> CollectOperationGroupMappings(LowLevelClientConfiguration c)
            {
                if (!c.SubClients.Any())
                {
                    yield break;
                }

                yield return new KeyValuePair<string, string[]>(c.OperationGroupName, c.SubClients.Select(x => x.OperationGroupName).ToArray());

                foreach (var childMapping in c.SubClients.SelectMany(CollectOperationGroupMappings))
                {
                    yield return childMapping;
                }
            }

            var clientMappings = _codeModel.OperationGroups.ToDictionary(x => x.Key, x => FindClient(x));
            var childOperationGroupMap = new Dictionary<string, string[]>(_context.Configuration.SubClientConfiguration.ClientConfigurations.SelectMany(CollectOperationGroupMappings));

            return childOperationGroupMap.ToDictionary(v => clientMappings[v.Key], v => (IReadOnlyList<LowLevelDataPlaneClient>) v.Value.Select(x => clientMappings[x]).ToList());
        }

        private HashSet<string> EnsureSubClientOperationGroups()
        {
            IEnumerable<string> CollectSubClients(LowLevelClientConfiguration c)
            {
                foreach (LowLevelClientConfiguration subClient in c.SubClients)
                {
                    yield return subClient.OperationGroupName;

                    foreach (var subClientOperationGroupName in CollectSubClients(subClient))
                    {
                        yield return subClientOperationGroupName;
                    }
                }
            }

            return _context.Configuration.SubClientConfiguration.ClientConfigurations.SelectMany(CollectSubClients).ToHashSet();
        }

        private HashSet<string> EnsurePublicClientOperationGroups()
        {
            IEnumerable<string> CollectPublicClientsFromConfigurations(LowLevelClientConfiguration[] clientConfigrations, bool defaultPublicConstructor = true)
            {
                foreach (var clientConfigration in clientConfigrations)
                {
                    if (clientConfigration.EmitPublicConstructor ?? defaultPublicConstructor)
                    {
                        yield return clientConfigration.OperationGroupName;
                    }

                    foreach (var publicChild in CollectPublicClientsFromConfigurations(clientConfigration.SubClients, defaultPublicConstructor: false))
                    {
                        yield return publicChild;
                    }
                }
            }

            var explicitlyPublicClients = CollectPublicClientsFromConfigurations(_context.Configuration.SubClientConfiguration.ClientConfigurations).ToHashSet();
            var allPublicClients = new HashSet<string>(explicitlyPublicClients);

            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                if (!_subClientOperationGroups.Value.Contains(operationGroup.Key))
                {
                    allPublicClients.Add(operationGroup.Key);
                }
            }

            return allPublicClients;
        }

        public override CSharpType FindTypeForSchema(Schema schema)
        {
            switch (schema.Type)
            {
                case AllSchemaTypes.Choice:
                    return _context.TypeFactory.CreateType(((ChoiceSchema)schema).ChoiceType, false);
                case AllSchemaTypes.SealedChoice:
                    return _context.TypeFactory.CreateType(((SealedChoiceSchema)schema).ChoiceType, false);
                default:
                    // This is technically invalid behavior, we are hitting this in generating responses we throw away.
                    // https://github.com/Azure/autorest.csharp/issues/1108
                    // throw new InvalidOperationException($"FindTypeForSchema of invalid schema {schema.Name} in LowLevelOutputLibrary");
                    return new CSharpType(typeof(object));
            }
        }

        public override CSharpType? FindTypeByName(string originalName) => null;

        public bool EmitSubClientConstructor(OperationGroup operationGroup)
        {
            return _subClientOperationGroups.Value.Contains(operationGroup.Key);
        }

        public bool EmitPublicConstructor(OperationGroup operationGroup)
        {
            return _publicClientOperationGroups.Value.Contains(operationGroup.Key);
        }

        public LowLevelDataPlaneClient FindClient(OperationGroup operationGroup)
        {
            return _publicClients[operationGroup];
        }

        public LowLevelRestClient FindRestClient(OperationGroup operationGroup)
        {
            return _internalRestClients[operationGroup];
        }

        public IReadOnlyList<LowLevelDataPlaneClient> FindSubClents(LowLevelDataPlaneClient client)
        {
            if (_subClients.TryGetValue(client, out var subClients))
            {
                return subClients;
            }

            return Array.Empty<LowLevelDataPlaneClient>();
        }
    }
}
