// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class MgmtClientOperation : IReadOnlyList<MgmtRestOperation>
    {
        private IReadOnlyList<MgmtRestOperation> _operations;

        public MgmtClientOperation(IReadOnlyList<MgmtRestOperation> operations)
        {
            _operations = operations;
        }

        public MgmtRestOperation this[int index] => _operations[index];

        public int Count => _operations.Count;

        public IEnumerator<MgmtRestOperation> GetEnumerator() => _operations.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _operations.GetEnumerator();
    }
}
