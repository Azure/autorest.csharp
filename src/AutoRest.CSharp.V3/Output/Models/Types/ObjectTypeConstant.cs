// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientObjectConstant
    {
        public ClientObjectConstant(string name, FrameworkTypeReference type, ClientConstant value)
        {
            Name = name;
            Type = type;
            Value = value;
        }

        public string Name { get; }
        public ClientTypeReference Type { get; }
        public ClientConstant Value { get; }
    }
}
