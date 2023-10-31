// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class ClientMethodsBuilder
    {
        private readonly IEnumerable<InputOperation> _operations;
        private readonly TypeFactory _typeFactory;
        private readonly OutputLibrary? _library;
        private readonly SourceInputModel? _sourceInputModel;

        public ClientMethodsBuilder(IEnumerable<InputOperation> operations, OutputLibrary? library, SourceInputModel? sourceInputModel, TypeFactory typeFactory)
        {
            _operations = operations;
            _library = library;
            _sourceInputModel = sourceInputModel;
            _typeFactory = typeFactory;
        }

        public IEnumerable<RestClientOperationMethods> Build(ClientFields fields, DpgOperationSampleBuilder sampleBuilder, string clientName, string clientNamespace, string clientKey)
        {
            var requireProtocolMethods = _library is DataPlaneOutputLibrary dpLibrary && dpLibrary.ProtocolMethodsDictionary.TryGetValue(clientKey, out var protocolMethodNames)
                ? _operations.Where(o => protocolMethodNames.Any(m => m.Equals(o.Name, StringComparison.OrdinalIgnoreCase))).ToArray()
                : Array.Empty<InputOperation>();

            foreach (var operation in _operations)
            {
                var generateProtocolMethods = !Configuration.AzureArm && !Configuration.Generation1ConvenienceClient || requireProtocolMethods.Contains(operation);
                var builder = SelectBuilder(operation, fields, sampleBuilder, clientName, clientNamespace, generateProtocolMethods);
                yield return builder.Build();
            }
        }

        private OperationMethodsBuilderBase SelectBuilder(InputOperation operation, ClientFields fields, DpgOperationSampleBuilder sampleBuilder, string clientName, string clientNamespace, bool generateProtocolMethods)
        {
            var statusCodeSwitchBuilder = operation.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean
                ? StatusCodeSwitchBuilder.CreateHeadAsBooleanOperationSwitch()
                : StatusCodeSwitchBuilder.CreateSwitch(operation, _library, _typeFactory);


            var args = new OperationMethodsBuilderBaseArgs(operation, fields, clientNamespace, clientName, generateProtocolMethods, statusCodeSwitchBuilder, sampleBuilder, _typeFactory, _sourceInputModel);

            return (operation.Paging, operation.LongRunning) switch
            {
                (not null, not null) => new LroPagingOperationMethodsBuilder(args, operation.Paging, operation.LongRunning),
                (not null, null) => args.StatusCodeSwitchBuilder.PageItemType is {} pageItemType ? new PagingOperationMethodsBuilder(args, operation.Paging, pageItemType) : new OperationMethodsBuilder(args),
                (null, not null) => new LroOperationMethodsBuilder(args, operation.LongRunning),
                (null, null) when operation.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean => new HeadAsBooleanOperationMethodsBuilder(args),
                _ => new OperationMethodsBuilder(args)
            };
        }
    }
}
