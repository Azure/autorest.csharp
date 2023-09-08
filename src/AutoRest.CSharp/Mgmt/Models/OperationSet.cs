// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;

namespace AutoRest.CSharp.Mgmt.Models
{
    /// <summary>
    /// An <see cref="OperationSet"/> represents a collection of <see cref="Operation"/> with the same request path.
    /// </summary>
    internal class OperationSet : IReadOnlyCollection<Operation>, IEquatable<OperationSet>
    {
        private readonly OperationGroup? _operationGroup;
        private readonly IReadOnlyDictionary<string, OperationSet> _rawRequestPathToOperationSets;
        private readonly TypeFactory _typeFactory;

        /// <summary>
        /// The raw request path of string of the operations in this <see cref="OperationSet"/>
        /// </summary>
        public string RequestPath { get; }

        /// <summary>
        /// The operation set
        /// </summary>
        private HashSet<Operation> Operations { get; }

        public int Count => Operations.Count;

        public OperationSet(string requestPath, OperationGroup? operationGroup, IReadOnlyDictionary<string, OperationSet> rawRequestPathToOperationSets, TypeFactory typeFactory)
        {
            _operationGroup = operationGroup;
            _rawRequestPathToOperationSets = rawRequestPathToOperationSets;
            _typeFactory = typeFactory;
            RequestPath = requestPath;
            Operations = new HashSet<Operation>();
        }

        /// <summary>
        /// Add a new operation to this <see cref="OperationSet"/>
        /// </summary>
        /// <param name="operation">The operation to be added</param>
        /// <exception cref="InvalidOperationException">when trying to add an operation with a different path from <see cref="RequestPath"/></exception>
        public void Add(Operation operation)
        {
            var path = operation.GetHttpPath();
            if (path != RequestPath)
                throw new InvalidOperationException($"Cannot add operation with path {path} to OperationSet with path {RequestPath}");
            Operations.Add(operation);
        }

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

        public RequestPath GetRequestPath(ResourceTypeSegment? hint = null)
        {
            return hint.HasValue ? NonHintRequestPath.ApplyHint(hint.Value) : NonHintRequestPath;
        }

        private RequestPath? _nonHintRequestPath;
        public RequestPath NonHintRequestPath => _nonHintRequestPath ??= GetNonHintRequestPath();
        private RequestPath GetNonHintRequestPath()
        {
            var operation = FindBestOperation();
            if (_operationGroup is not null && Operations.Any())
            {
                if (operation != null)
                {
                    return Models.RequestPath.FromOperation(operation, _operationGroup, _typeFactory);
                }
            }

            // we do not have an operation in this operation set to construct the RequestPath
            // therefore this must be a request path for a virtual resource
            // we find an operation with a prefix of this and take that many segment from its path as the request path of this operation set
            OperationSet? hintOperationSet = null;
            foreach (var operationSet in _rawRequestPathToOperationSets.Values)
            {
                // skip myself
                if (operationSet == this)
                    continue;
                // also skip the sets that with zero operations, they are operation set of partial resources as well
                if (operationSet.Count == 0)
                    continue;

                if (operationSet.RequestPath.StartsWith(RequestPath))
                {
                    hintOperationSet = operationSet;
                    break;
                }
            }

            Debug.Assert(hintOperationSet != null);
            return BuildRequestPathFromHint(hintOperationSet);
        }

        private RequestPath BuildRequestPathFromHint(OperationSet hint)
        {
            var hintPath = hint.GetRequestPath();
            var segmentsCount = RequestPath.Split('/', StringSplitOptions.RemoveEmptyEntries).Length;
            var segments = hintPath.Take(segmentsCount);
            return Models.RequestPath.FromSegments(segments);
        }

        private Operation? FindBestOperation()
        {
            // first we try GET operation
            var getOperation = FindOperation(HttpMethod.Get);
            if (getOperation != null)
                return getOperation;
            // if no GET operation, we return PUT operation
            var putOperation = FindOperation(HttpMethod.Put);
            if (putOperation != null)
                return putOperation;

            // if no PUT or GET, we just return the first one
            return Operations.FirstOrDefault();
        }

        public Operation? FindOperation(HttpMethod method)
        {
            return this.FirstOrDefault(operation => operation.GetHttpMethod() == method);
        }

        public bool IsById => NonHintRequestPath.IsById;

        public override string? ToString()
        {
            return RequestPath;
        }
    }
}
