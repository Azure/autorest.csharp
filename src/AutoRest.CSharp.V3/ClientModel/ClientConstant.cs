// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Diagnostics;

namespace AutoRest.CSharp.V3.ClientModel
{
    internal struct ClientConstant
    {
        public ClientConstant(object value, FrameworkTypeReference type)
        {
            Debug.Assert(value == null || value.GetType().Namespace?.StartsWith("System") == true);
            Value = value;
            Type = type;
        }

        public object? Value { get; }
        public FrameworkTypeReference Type { get; }
    }
}
