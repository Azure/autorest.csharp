// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRest.CSharp.Utilities
{
    internal class ValuesEqualList<T> : List<T>
    {
        public ValuesEqualList() : base() {}

        public ValuesEqualList(IEnumerable<T> collection) : base(collection) { }

        public override bool Equals(object? obj)
        {
            return obj is IEnumerable<T> list && this.SequenceEqual(list);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();

            foreach (var item in this)
            {
                hashCode.Add(item);
            }

            return hashCode.ToHashCode();
        }
    }
}
