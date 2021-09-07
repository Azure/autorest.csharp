// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal class RawOperationSet : IReadOnlyCollection<Tuple<Operation, OperationGroup>>
    {
        public string RequestPath { get; }

        public List<Tuple<Operation, OperationGroup>> Operations { get; }

        public int Count => Operations.Count;

        public RawOperationSet(string requestPath, List<Tuple<Operation, OperationGroup>> operations)
        {
            RequestPath = requestPath;
            Operations = operations;
        }

        public void Add(Tuple<Operation, OperationGroup> item)
        {
            var path = item.Item1.GetHttpPath();
            if (path != RequestPath)
                throw new InvalidOperationException($"Cannot add operation with path {path} to RawOperationSet with path {RequestPath}");
            Operations.Add(item);
        }

        public IEnumerator<Tuple<Operation, OperationGroup>> GetEnumerator() => Operations.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Operations.GetEnumerator();
    }
}
