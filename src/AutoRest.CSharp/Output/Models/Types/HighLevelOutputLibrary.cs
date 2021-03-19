// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class HighLevelOutputLibrary : OutputLibrary
    {
        protected Dictionary<OperationGroup, RestClient>? _restClients;
        private Dictionary<OperationGroup, Client>? _clients;
        private Dictionary<Operation, LongRunningOperation>? _operations;
        private Dictionary<Operation, ResponseHeaderGroupType>? _headerModels;
        private BuildContext<HighLevelOutputLibrary> _context;
        private CodeModel _codeModel;

        public HighLevelOutputLibrary(CodeModel codeModel, BuildContext<HighLevelOutputLibrary> context) : base(codeModel, context)
        {
            _context = context;
            _codeModel = codeModel;
        }

        public override IEnumerable<Client> Clients => EnsureClients().Values;
        public override IEnumerable<LongRunningOperation> LongRunningOperations => EnsureLongRunningOperations().Values;
        public override IEnumerable<ResponseHeaderGroupType> HeaderModels => (_headerModels ??= EnsureHeaderModels()).Values;

        private Dictionary<Operation, ResponseHeaderGroupType> EnsureHeaderModels()
        {
            if (_headerModels != null)
            {
                return _headerModels;
            }

            _headerModels = new Dictionary<Operation, ResponseHeaderGroupType>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    var headers = ResponseHeaderGroupType.TryCreate(operationGroup, operation, _context);
                    if (headers != null)
                    {
                        _headerModels.Add(operation, headers);
                    }
                }
            }

            return _headerModels;
        }

        private Dictionary<Operation, LongRunningOperation> EnsureLongRunningOperations()
        {
            if (_operations != null)
            {
                return _operations;
            }

            _operations = new Dictionary<Operation, LongRunningOperation>();

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    foreach (var operation in operationGroup.Operations)
                    {
                        if (operation.IsLongRunning)
                        {
                            _operations.Add(operation, new LongRunningOperation(operationGroup, operation, _context));
                        }
                    }
                }
            }

            return _operations;
        }

        private Dictionary<OperationGroup, Client> EnsureClients()
        {
            if (_clients != null)
            {
                return _clients;
            }

            _clients = new Dictionary<OperationGroup, Client>();

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    _clients.Add(operationGroup, new Client(operationGroup, _context));
                }
            }

            return _clients;
        }

        public override LongRunningOperation? FindLongRunningOperation(Operation operation)
        {
            Debug.Assert(operation.IsLongRunning);

            return EnsureLongRunningOperations()[operation];
        }

        public override Client? FindClient(OperationGroup operationGroup)
        {
            EnsureClients().TryGetValue(operationGroup, out var client);
            return client;
        }

        public override ResponseHeaderGroupType? FindHeaderModel(Operation operation)
        {
            EnsureHeaderModels().TryGetValue(operation, out var model);
            return model;
        }

        protected override Dictionary<OperationGroup, RestClient> EnsureRestClients()
        {
            if (_restClients != null)
            {
                return _restClients;
            }

            _restClients = new Dictionary<OperationGroup, RestClient>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                _restClients.Add(operationGroup, new RestClient(operationGroup, _context));
            }

            return _restClients;
        }
    }
}
