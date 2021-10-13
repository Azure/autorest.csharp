// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.Decorator;

namespace AutoRest.CSharp.Mgmt.Models
{
    /// <summary>
    /// An <see cref="OperationSet"/> represents a collection of <see cref="Operation"/> with the same request path.
    /// </summary>
    internal class OperationSet : IReadOnlyCollection<Operation>, IEquatable<OperationSet>
    {
        private IDictionary<Operation, OperationGroup> _operationGroupCache = new Dictionary<Operation, OperationGroup>();

        /// <summary>
        /// The raw request path of string of the operations in this <see cref="OperationSet"/>
        /// </summary>
        public string RequestPath { get; }

        /// <summary>
        /// The operation set
        /// </summary>
        public HashSet<Operation> Operations { get; }

        public int Count => Operations.Count;

        public OperationSet(string requestPath)
        {
            RequestPath = requestPath;
            Operations = new HashSet<Operation>();
        }

        /// <summary>
        /// Add a new operation to this <see cref="OperationSet"/>
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="operationGroup"></param>
        /// <exception cref="InvalidOperationException">when trying to add an operation with a different path from <see cref="RequestPath"/></exception>
        public void Add(Operation operation, OperationGroup operationGroup)
        {
            var path = operation.GetHttpPath();
            if (path != RequestPath)
                throw new InvalidOperationException($"Cannot add operation with path {path} to OperationSet with path {RequestPath}");
            Operations.Add(operation);
            _operationGroupCache.TryAdd(operation, operationGroup);
        }

        /// <summary>
        /// Get the corresponding <see cref="OperationGroup"/> for the given <see cref="Operation"/>
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        /// <exception cref="KeyNotFoundException">the given operation was not found in this <see cref="OperationSet"/></exception>
        internal OperationGroup this[Operation operation] => _operationGroupCache[operation];

        public IEnumerator<Operation> GetEnumerator() => Operations.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Operations.GetEnumerator();

        public override int GetHashCode()
        {
            return RequestPath.GetHashCode();
        }

        public bool Equals([AllowNull] OperationSet other)
        {
            if (other is null)
                return false;

            return RequestPath == other.RequestPath;
        }

        /// <summary>
        /// Get the operation with the given verb.
        /// We cannot have two operations with the same verb under the same request path, therefore this method is only returning one operation or null
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public Operation? GetOperation(HttpMethod method)
        {
            foreach (var operation in Operations)
            {
                if (operation.GetHttpRequest()!.Method == method)
                    return operation;
            }

            return null;
        }

        public override string? ToString()
        {
            return RequestPath;
        }
    }
}
