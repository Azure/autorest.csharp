﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
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
        private const int PropertyBagThreshold = 5;
        private readonly Parameter? _extensionParameter;
        public static MgmtClientOperation? FromOperations(IReadOnlyList<MgmtRestOperation> operations, FormattableString idVariableName, Parameter? extensionParameter = null, bool isConvenientOperation = false)
        {
            if (operations.Count > 0)
            {
                return new MgmtClientOperation(operations.OrderBy(operation => operation.Name).ToArray(), idVariableName, extensionParameter, isConvenientOperation);
            }

            return null;
        }

        public static MgmtClientOperation FromOperation(MgmtRestOperation operation, FormattableString idVariableName, Parameter? extensionParameter = null, bool isConvenientOperation = false)
        {
            return new MgmtClientOperation(new List<MgmtRestOperation> { operation }, idVariableName, extensionParameter, isConvenientOperation);
        }

        public static MgmtClientOperation FromClientOperation(MgmtClientOperation other, FormattableString idVariableName, Parameter? extensionParameter = null, bool isConvenientOperation = false, IReadOnlyList<Parameter>? parameterOverride = null)
        {
            return new MgmtClientOperation(other._operations, idVariableName, extensionParameter, isConvenientOperation, parameterOverride);
        }

        internal FormattableString IdVariableName { get; }

        public Func<bool, FormattableString>? ReturnsDescription => _operations.First().ReturnsDescription;

        private IReadOnlyDictionary<RequestPath, MgmtRestOperation>? _operationMappings;
        public IReadOnlyDictionary<RequestPath, MgmtRestOperation> OperationMappings => _operationMappings ??= EnsureOperationMappings();

        private IReadOnlyDictionary<RequestPath, IEnumerable<ParameterMapping>>? _parameterMappings;
        public IReadOnlyDictionary<RequestPath, IEnumerable<ParameterMapping>> ParameterMappings => _parameterMappings ??= EnsureParameterMappings();

        private IReadOnlyList<Parameter>? _methodParameters;
        public IReadOnlyList<Parameter> MethodParameters => _methodParameters ??= EnsureMethodParameters();

        public IReadOnlyList<Parameter> PropertyBagUnderlyingParameters => IsPropertyBagOperation ? _passThroughParams : Array.Empty<Parameter>();

        private readonly IReadOnlyList<MgmtRestOperation> _operations;

        private MgmtClientOperation(IReadOnlyList<MgmtRestOperation> operations, FormattableString idVariableName, Parameter? extensionParameter, bool isConvenientOperation = false)
        {
            _operations = operations;
            _extensionParameter = extensionParameter;
            IdVariableName = idVariableName;
            IsConvenientOperation = isConvenientOperation;
        }

        private MgmtClientOperation(IReadOnlyList<MgmtRestOperation> operations, FormattableString idVariableName, Parameter? extensionParameter, bool isConvenientOperation = false, IReadOnlyList<Parameter>? parameterOverride = null) : this(operations, idVariableName, extensionParameter, isConvenientOperation)
        {
            _methodParameters = parameterOverride;
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
        private FormattableString? _description;
        public FormattableString Description => _description ??= BuildDescription();

        private FormattableString BuildDescription()
        {
            var pathInformation = _operations.Select(operation =>
                (FormattableString)$@"<item>
<term>Request Path</term>
<description>{operation.Operation.GetHttpPath()}</description>
</item>
<item>
<term>Operation Id</term>
<description>{operation.OperationId}</description>
</item>").ToArray().Join(Environment.NewLine);
            pathInformation = $@"<list type=""bullet"">
{pathInformation}
</list>";
            FormattableString? mockingInformation;
            if (_extensionParameter == null)
            {
                mockingInformation = null;
            }
            else
            {
                // find the corresponding extension of this method
                var extendType = _extensionParameter.Type;
                var mockingExtensionTypeName = MgmtMockableExtension.GetMockableExtensionDefaultName(extendType.Name);
                // construct the cref name
                var builder = new StringBuilder(Name);
                builder.Append("(");
                var paramList = MethodParameters.Skip(1).Select(p => p.Type.ToStringForDocs());
                builder.Append(string.Join(",", paramList));
                builder.Append(")");
                var methodRef = builder.ToString();

                mockingInformation = $@"<item>
<term>Mocking</term>
<description>To mock this method, please mock <see cref=""{mockingExtensionTypeName}.{methodRef}""/> instead.</description>
</item>";
            }

            FormattableString extraInformation = mockingInformation != null ? $"{pathInformation}{Environment.NewLine}{mockingInformation}" : pathInformation;
            var descriptionOfOperation = _operations.First().Description;
            if (descriptionOfOperation != null)
                return $"{descriptionOfOperation}{Environment.NewLine}{extraInformation}";
            return extraInformation;
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

        public bool IsPropertyBagOperation => _passThroughParams.Count() > PropertyBagThreshold && _passThroughParams.All(p => p.IsPropertyBag);

        private IReadOnlyList<Parameter> _passThroughParams => ParameterMappings.Values.First().GetPassThroughParameters();

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

            var parameterMappings = new Dictionary<RequestPath, IEnumerable<ParameterMapping>>();
            foreach (var operationMappings in OperationMappings)
            {
                var parameterMapping = operationMappings.Value.BuildParameterMapping(contextualParameterMappings[operationMappings.Key]).ToList();
                if (parameterMapping.Where(p => p.IsPassThru).Count() > PropertyBagThreshold)
                {
                    for (int i = 0; i < parameterMapping.Count; ++i)
                    {
                        if (parameterMapping[i].IsPassThru)
                        {
                            parameterMapping[i] = new ParameterMapping(parameterMapping[i].Parameter with { IsPropertyBag = true }, true, $"{parameterMapping[i].Parameter.GetPropertyBagValueExpression()}", Enumerable.Empty<string>());
                        }
                    }
                }
                parameterMappings.Add(operationMappings.Key, parameterMapping);
            }
            return parameterMappings;
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
                if (IsPropertyBagOperation)
                {
                    parameters.Add(_operations.First().GetPropertyBagParameter(_passThroughParams));
                }
                else
                {
                    parameters.AddRange(_passThroughParams);
                }
            }
            parameters.Add(KnownParameters.CancellationTokenParameter);
            return parameters;
        }
    }
}
