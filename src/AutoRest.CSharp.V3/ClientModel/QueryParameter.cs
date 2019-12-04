// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModel
{
    internal class QueryParameter
    {
        public QueryParameter(string name, ConstantOrParameter value, bool escape)
        {
            Name = name;
            Value = value;
            Escape = escape;
        }

        public string Name { get; }
        public ConstantOrParameter Value { get; }
        public bool Escape { get; }
    }
}
