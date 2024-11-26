// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Mgmt.Models;
using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Mgmt.Output.Samples
{
    internal class OperationExample
    {
        private readonly Lazy<IReadOnlyDictionary<string, string>> _parameterNameToSerializedNameMapping;

        internal protected InputOperationExample _example;
        internal protected InputOperation _inputOperation;
        public string OperationId { get; }
        public string Name => _example.Name!;

        public MgmtTypeProvider Carrier { get; }

        public MgmtClientOperation Operation { get; }

        private MgmtRestOperation? _restOperation;
        public MgmtRestOperation RestOperation => _restOperation ??= GetRestOperationFromOperationId();
        public RequestPath RequestPath => RestOperation.RequestPath;

        /// <summary>
        /// All the parameters defined in this test case
        /// We do not need to distiguish between ClientParameters and MethodParameters because we usually change that in code model transformation
        /// </summary>
        public IEnumerable<InputParameterExample> AllParameters => _example.Parameters;
        private IEnumerable<InputParameterExample>? _pathParameters;
        public IEnumerable<InputParameterExample> PathParameters => _pathParameters ??= AllParameters.Where(p => p.Parameter.Location == RequestLocation.Path);

        protected OperationExample(string operationId, MgmtTypeProvider carrier, MgmtClientOperation operation, InputOperation inputOperation, InputOperationExample example)
        {
            OperationId = operationId;
            _example = example;
            _inputOperation = inputOperation;
            Carrier = carrier;
            Operation = operation;
            _parameterNameToSerializedNameMapping = new Lazy<IReadOnlyDictionary<string, string>>(EnsureParameterSerializedNames);
        }

        private MgmtRestOperation GetRestOperationFromOperationId()
        {
            foreach (var operation in Operation)
            {
                if (operation.OperationId == OperationId)
                    return operation;
            }

            throw new InvalidOperationException($"Cannot find operationId {OperationId} in example {_inputOperation.Name}");
        }

        public InputExampleValue? FindInputExampleValueFromReference(Reference reference)
        {
            // find a path parameter in our path parameters for one with same name
            var serializedName = GetParameterSerializedName(reference.Name);
            var parameter = FindExampleParameterBySerializedName(PathParameters, serializedName);
            return parameter?.ExampleValue;
        }

        private Dictionary<string, string> EnsureParameterSerializedNames()
        {
            var result = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            foreach (var requestParameter in _inputOperation.Parameters)
            {
                result.Add(requestParameter.Name, requestParameter.NameInRequest ?? requestParameter.Name);
            }

            return result;
        }

        // there are possibilities that we cannot find the corresponding parameter's serialized name. We have to return an empty here to ensure everything is going fine
        protected string GetParameterSerializedName(string name) => _parameterNameToSerializedNameMapping.Value.TryGetValue(name, out var serializedName) ? serializedName : string.Empty;

        protected InputParameterExample? FindExampleParameterBySerializedName(IEnumerable<InputParameterExample> parameters, string name)
            => parameters.FirstOrDefault(p => p.Parameter.NameInRequest == name);
    }
}
