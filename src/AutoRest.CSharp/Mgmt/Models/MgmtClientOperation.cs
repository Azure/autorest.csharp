// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Mgmt.Models
{
    /// <summary>
    /// A <see cref="MgmtClientOperation"/> includes at least one <see cref="MgmtRestOperation"/>.
    /// This is a collection of multiple methods with the same purpose but belong to different parents.
    /// For instance, one resource might how two different parents, and we can invoke the `CreateOrUpdate` under either of those parents.
    /// To make the SDK more user-friendly and considering that our SDK has been built in the "context aware" way,
    /// we group these methods together and invoke them by the current context
    /// </summary>
    internal class MgmtClientOperation : IReadOnlyList<MgmtRestOperation>
    {
        private const string IdVariableName = "Id";
        private readonly Parameter? _extensionParameter;
        public static MgmtClientOperation? FromOperations(IReadOnlyList<MgmtRestOperation> operations)
        {
            if (operations.Count > 0)
            {
                return new MgmtClientOperation(operations.OrderBy(operation => operation.Name).ToArray(), null);
            }

            return null;
        }

        public Func<bool, FormattableString>? ReturnsDescription => _operations.First().ReturnsDescription;

        private IReadOnlyDictionary<RequestPath, MgmtRestOperation>? _operationMappings;
        public IReadOnlyDictionary<RequestPath, MgmtRestOperation> OperationMappings => _operationMappings ??= EnsureOperationMappings();

        private IReadOnlyDictionary<RequestPath, IEnumerable<ParameterMapping>>? _parameterMappings;
        public IReadOnlyDictionary<RequestPath, IEnumerable<ParameterMapping>> ParameterMappings => _parameterMappings ??= EnsureParameterMappings();

        private IReadOnlyList<Parameter>? _methodParameters;
        public IReadOnlyList<Parameter> MethodParameters => _methodParameters ??= EnsureMethodParameters();

        public IReadOnlyList<Parameter> PropertyBagUnderlyingParameters => IsPropertyBagOperation ? ParameterMappings.Values.First().GetPassThroughParameters() : Array.Empty<Parameter>();
        public static MgmtClientOperation FromOperation(MgmtRestOperation operation, Parameter? extensionParameter = null, bool isConvenientOperation = false)
        {
            return new MgmtClientOperation(new List<MgmtRestOperation> { operation }, extensionParameter, isConvenientOperation);
        }

        private readonly IReadOnlyList<MgmtRestOperation> _operations;

        private MgmtClientOperation(IReadOnlyList<MgmtRestOperation> operations, Parameter? extensionParameter, bool isConvenientOperation = false)
        {
            _operations = operations;
            _extensionParameter = extensionParameter;
            IsConvenientOperation = isConvenientOperation;
        }

        public bool IsConvenientOperation { get; }

        public MgmtRestOperation this[int index] => _operations[index];

        private MethodSignature? _methodSignature;
        public MethodSignature MethodSignature => _methodSignature ??= new MethodSignature(
            Name,
            null,
            Description,
            Accessibility == Public
                ? _extensionParameter != null
                    ? Public | Static | Extension
                    : Public | Virtual
                : Accessibility,
            IsPagingOperation
                ? new CSharpType(typeof(Pageable<>), ReturnType)
                : ReturnType, null, MethodParameters.ToArray());

        // TODO -- we need a better way to get the name of this
        public string Name => _operations.First().Name;

        // TODO -- we need a better way to get the description of this
        private string? _description;
        public string Description => _description ??= BuildDescription();

        private string BuildDescription()
        {
            var pathInformation = string.Join('\n', _operations.Select(operation => $"Request Path: {operation.Operation.GetHttpPath()}\nOperation Id: {operation.OperationId}"));
            var descriptionOfOperation = _operations.First().Description;
            if (descriptionOfOperation != null)
                return $"{descriptionOfOperation}\n{pathInformation}";
            return $"{pathInformation}";
        }

        // TODO -- we need a better way to get this
        public IEnumerable<Parameter> Parameters => _operations.First().Parameters;

        public CSharpType? MgmtReturnType => _operations.First().MgmtReturnType;

        public CSharpType ReturnType => _operations.First().ReturnType;

        public MethodSignatureModifiers Accessibility => _operations.First().Accessibility;

        public int Count => _operations.Count;

        public Resource? Resource => _operations.First().Resource;

        public IEnumerator<MgmtRestOperation> GetEnumerator() => _operations.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _operations.GetEnumerator();

        public MgmtRestClient RestClient => _operations.First().RestClient;

        public bool IsLongRunningOperation => _operations.First().IsLongRunningOperation;

        public bool IsPagingOperation => _operations.First().IsPagingOperation;

        public bool IsPropertyBagOperation => _operations.First().IsPropertyBagOperation;

        private IReadOnlyDictionary<RequestPath, MgmtRestOperation> EnsureOperationMappings()
        {
            return this.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
        }

        private IReadOnlyDictionary<RequestPath, IEnumerable<ParameterMapping>> EnsureParameterMappings()
        {
            var contextParams = Resource?.ResourceCollection?.ExtraContextualParameterMapping ?? Enumerable.Empty<ContextualParameterMapping>();

            var contextualParameterMappings = new Dictionary<RequestPath, IEnumerable<ContextualParameterMapping>>();
            foreach (var contextualPath in OperationMappings.Keys)
            {
                var adjustedPath = Resource is not null ? contextualPath.ApplyHint(Resource.ResourceType) : contextualPath;
                contextualParameterMappings.Add(contextualPath, adjustedPath.BuildContextualParameters(IdVariableName).Concat(contextParams));
            }
            return OperationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.BuildParameterMapping(contextualParameterMappings[pair.Key]));
        }

        private IReadOnlyList<Parameter> EnsureMethodParameters()
        {
            List<Parameter> parameters = new List<Parameter>();
            if (_extensionParameter is not null)
                parameters.Add(_extensionParameter);
            if (IsLongRunningOperation)
                parameters.Add(KnownParameters.WaitForCompletion);
            var overrideParameters = OperationMappings.Values.First().OverrideParameters;
            if (overrideParameters.Length > 0)
            {
                parameters.AddRange(overrideParameters);
            }
            else
            {
                var passThroughParameters = ParameterMappings.Values.First().GetPassThroughParameters();
                if (IsPropertyBagOperation)
                {
                    parameters.Add(_operations.First().GetPropertyBagParameter(passThroughParameters.Select(p => p.Name)));
                }
                else
                {
                    parameters.AddRange(passThroughParameters);
                }
            }
            parameters.Add(KnownParameters.CancellationTokenParameter);
            return parameters;
        }
    }
}
