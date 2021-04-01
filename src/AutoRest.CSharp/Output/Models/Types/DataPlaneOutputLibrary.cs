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
    internal class DataPlaneOutputLibrary : OutputLibrary
    {
        private Dictionary<OperationGroup, DataPlaneRestClient>? _restClients;
        private Dictionary<OperationGroup, DataPlaneClient>? _clients;
        private Dictionary<Operation, DataPlaneLongRunningOperation>? _operations;
        private Dictionary<Operation, DataPlaneResponseHeaderGroupType>? _headerModels;
        private BuildContext<DataPlaneOutputLibrary> _context;
        private CodeModel _codeModel;

        public DataPlaneOutputLibrary(CodeModel codeModel, BuildContext<DataPlaneOutputLibrary> context) : base(codeModel, context)
        {
            _context = context;
            _codeModel = codeModel;
        }

        public IEnumerable<DataPlaneClient> Clients => EnsureClients().Values;
        public IEnumerable<DataPlaneLongRunningOperation> LongRunningOperations => EnsureLongRunningOperations().Values;
        public IEnumerable<DataPlaneResponseHeaderGroupType> HeaderModels => (_headerModels ??= EnsureHeaderModels()).Values;

        public DataPlaneLongRunningOperation FindLongRunningOperation(Operation operation)
        {
            Debug.Assert(operation.IsLongRunning);

            return EnsureLongRunningOperations()[operation];
        }

        public DataPlaneClient? FindClient(OperationGroup operationGroup)
        {
            EnsureClients().TryGetValue(operationGroup, out var client);
            return client;
        }

        public DataPlaneResponseHeaderGroupType? FindHeaderModel(Operation operation)
        {
            EnsureHeaderModels().TryGetValue(operation, out var model);
            return model;
        }

        public IEnumerable<DataPlaneRestClient> RestClients => EnsureRestClients().Values;

        public DataPlaneRestClient FindRestClient(OperationGroup operationGroup)
        {
            return EnsureRestClients()[operationGroup];
        }

        private Dictionary<Operation, DataPlaneResponseHeaderGroupType> EnsureHeaderModels()
        {
            if (_headerModels != null)
            {
                return _headerModels;
            }

            _headerModels = new Dictionary<Operation, DataPlaneResponseHeaderGroupType>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                foreach (var operation in operationGroup.Operations)
                {
                    var headers = DataPlaneResponseHeaderGroupType.TryCreate(operationGroup, operation, _context);
                    if (headers != null)
                    {
                        _headerModels.Add(operation, headers);
                    }
                }
            }

            return _headerModels;
        }

        private Dictionary<Operation, DataPlaneLongRunningOperation> EnsureLongRunningOperations()
        {
            if (_operations != null)
            {
                return _operations;
            }

            _operations = new Dictionary<Operation, DataPlaneLongRunningOperation>();

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    foreach (var operation in operationGroup.Operations)
                    {
                        if (operation.IsLongRunning)
                        {
                            _operations.Add(operation, new DataPlaneLongRunningOperation(operationGroup, operation, _context));
                        }
                    }
                }
            }

            return _operations;
        }

        private Dictionary<OperationGroup, DataPlaneClient> EnsureClients()
        {
            if (_clients != null)
            {
                return _clients;
            }

            _clients = new Dictionary<OperationGroup, DataPlaneClient>();

            if (_context.Configuration.PublicClients)
            {
                foreach (var operationGroup in _codeModel.OperationGroups)
                {
                    _clients.Add(operationGroup, new DataPlaneClient(operationGroup, _context));
                }
            }

            return _clients;
        }

        private Dictionary<OperationGroup, DataPlaneRestClient> EnsureRestClients()
        {
            if (_restClients != null)
            {
                return _restClients;
            }

            _restClients = new Dictionary<OperationGroup, DataPlaneRestClient>();
            foreach (var operationGroup in _codeModel.OperationGroups)
            {
                _restClients.Add(operationGroup, new DataPlaneRestClient(operationGroup, _context));
            }

            return _restClients;
        }
    }
}
