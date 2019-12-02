// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModel
{
    internal struct ClientConstant
    {
        public ClientConstant(object value, FrameworkTypeReference type)
        {
            Value = value;
            Type = type;
        }

        public object Value { get; }
        public FrameworkTypeReference Type { get; }
    }
}
