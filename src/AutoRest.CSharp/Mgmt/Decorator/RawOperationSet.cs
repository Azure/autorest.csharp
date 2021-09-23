// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal class RawOperationSet : IReadOnlyCollection<Operation>, IEquatable<RawOperationSet>
    {
        private IDictionary<Operation, OperationGroup> _operationGroupCache = new Dictionary<Operation, OperationGroup>();
        public string RequestPath { get; }

        public HashSet<Operation> Operations { get; }

        public int Count => Operations.Count;

        public RawOperationSet(string requestPath)
        {
            RequestPath = requestPath;
            Operations = new HashSet<Operation>();
        }

        public void Add(Operation operation, OperationGroup operationGroup)
        {
            var path = operation.GetHttpPath();
            if (path != RequestPath)
                throw new InvalidOperationException($"Cannot add operation with path {path} to RawOperationSet with path {RequestPath}");
            Operations.Add(operation);
            _operationGroupCache.TryAdd(operation, operationGroup);
        }

        public Operation? GetOperation(HttpMethod method)
        {
            foreach (var operation in Operations)
            {
                if (operation.GetHttpRequest()!.Method == method)
                    return operation;
            }

            return null;
        }

        public OperationGroup this[Operation operation] => _operationGroupCache[operation];

        public IEnumerator<Operation> GetEnumerator() => Operations.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Operations.GetEnumerator();

        public override int GetHashCode()
        {
            return RequestPath.GetHashCode();
        }

        public bool Equals([AllowNull] RawOperationSet other)
        {
            if (other is null)
                return false;

            return RequestPath == other.RequestPath;
        }
    }
}
