// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientEnumValue
    {
        public ClientEnumValue(string name, string description, ClientConstant value)
        {
            Name = name;
            Description = description;
            Value = value;
        }

        public string Name { get; }
        public ClientConstant Value { get; }
        public string Description { get; }
    }
}
