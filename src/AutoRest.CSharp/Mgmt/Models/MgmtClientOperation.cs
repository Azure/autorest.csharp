// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Mgmt.Generation;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using static AutoRest.CSharp.Mgmt.Decorator.ParameterMappingBuilder;

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

        public static MgmtClientOperation? FromOperations(IReadOnlyList<MgmtRestOperation> operations, BuildContext<MgmtOutputLibrary> context)
        {
            if (operations.Count > 0)
            {
                return new MgmtClientOperation(operations.OrderBy(operation => operation.Name).ToArray(), context);
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

        public static MgmtClientOperation FromOperation(MgmtRestOperation operation, BuildContext<MgmtOutputLibrary> context)
        {
            return new MgmtClientOperation(new List<MgmtRestOperation> { operation }, context);
        }

        private IReadOnlyList<MgmtRestOperation> _operations;

        private BuildContext<MgmtOutputLibrary> _context;
        private MgmtClientOperation(IReadOnlyList<MgmtRestOperation> operations, BuildContext<MgmtOutputLibrary> context)
        {
            _operations = operations;
            _context = context;
        }

        public MgmtRestOperation this[int index] => _operations[index];

        private MethodSignature? _methodSignature;
        public MethodSignature MethodSignature => _methodSignature ??= new MethodSignature(Name, Description, Accessibility, ReturnType, null, MethodParameters.ToArray(), IsPagingOperation);

        // TODO -- we need a better way to get the name of this
        public string Name => _operations.First().Name;

        // TODO -- we need a better way to get the description of this
        public string? Description => _operations.First().Description;

        // TODO -- we need a better way to get this
        public IEnumerable<Parameter> Parameters => _operations.First().Parameters;

        public CSharpType ReturnType => _operations.First().ReturnType;

        public string Accessibility => _operations.First().Accessibility;

        public int Count => _operations.Count;

        public Resource? Resource => _operations.First().Resource;

        public IEnumerator<MgmtRestOperation> GetEnumerator() => _operations.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _operations.GetEnumerator();

        public MgmtRestClient RestClient => _operations.First().RestClient;

        public bool IsLongRunningOperation => _operations.First().IsLongRunningOperation;

        public bool IsPagingOperation => _operations.First().IsPagingOperation;
        public CSharpType? OriginalReturnType => _operations.First().OriginalReturnType;

        public CSharpType? ListItemType => _operations.First().ListItemType;

        private IReadOnlyDictionary<RequestPath, MgmtRestOperation> EnsureOperationMappings()
        {
            return this.ToDictionary(
                operation => operation.ContextualPath,
                operation => operation);
        }

        private IReadOnlyDictionary<RequestPath, IEnumerable<ParameterMapping>> EnsureParameterMappings()
        {
            var contextualParameterMappings = OperationMappings.Keys.ToDictionary(
                contextualPath => contextualPath,
                contextualPath => contextualPath.BuildContextualParameters(_context, IdVariableName));
            return OperationMappings.ToDictionary(
                pair => pair.Key,
                pair => pair.Value.BuildParameterMapping(contextualParameterMappings[pair.Key]));
        }

        private IReadOnlyList<Parameter> EnsureMethodParameters()
        {
            List<Parameter> parameters = new List<Parameter>();
            if (IsLongRunningOperation)
                parameters.Add(MgmtClientBaseWriter.WaitForCompletionParameter);
            parameters.AddRange(ParameterMappings.Values.First().GetPassThroughParameters());
            parameters.Add(MgmtClientBaseWriter.CancellationTokenParameter);
            return parameters;
        }
    }
}
