// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        public static MgmtClientOperation? FromOperations(IReadOnlyList<MgmtRestOperation> operations)
        {
            if (operations.Count > 0)
                return new MgmtClientOperation(operations);

            return null;
        }

        public static MgmtClientOperation FromOperation(MgmtRestOperation operation)
        {
            return new MgmtClientOperation(new List<MgmtRestOperation> { operation });
        }

        private IReadOnlyList<MgmtRestOperation> _operations;

        private MgmtClientOperation(IReadOnlyList<MgmtRestOperation> operations)
        {
            _operations = operations;
        }

        public MgmtRestOperation this[int index] => _operations[index];

        // TODO -- we need a better way to get the name of this
        public string Name => _operations.First().Name;

        // TODO -- we need a better way to get the description of this
        public string? Description => _operations.First().Description;

        public int Count => _operations.Count;

        public IEnumerator<MgmtRestOperation> GetEnumerator() => _operations.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _operations.GetEnumerator();
    }
}
