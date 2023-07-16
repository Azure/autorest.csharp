// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models
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

        public IEnumerable<OperationMethodsBuilderBase> Build(ValueExpression? restClientReference, ClientFields fields, string clientName, string clientNamespace)
        {
            foreach (var operation in _operations)
            {
                var statusCodeSwitchBuilder = operation.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean
                    ? StatusCodeSwitchBuilder.CreateHeadAsBooleanOperationSwitch()
                    : StatusCodeSwitchBuilder.CreateSwitch(operation, _library, _typeFactory);

                var args = new OperationMethodsBuilderBaseArgs(operation, restClientReference, fields, clientNamespace, clientName, statusCodeSwitchBuilder, _typeFactory, _sourceInputModel);

                yield return (operation.Paging, operation.LongRunning) switch
                {
                    (not null, not null) => new LroPagingOperationMethodsBuilder(args, operation.Paging, operation.LongRunning),
                    (not null, null) => new PagingOperationMethodsBuilder(args, operation.Paging),
                    (null, not null) => new LroOperationMethodsBuilder(args, operation.LongRunning),
                    (null, null) when operation.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean => new HeadAsBooleanOperationMethodsBuilder(args),
                    _ => new OperationMethodsBuilder(args)
                };
            }
        }
    }
}
