﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModel
{
    internal class ClientEnumValue
    {
        public ClientEnumValue(string name, ClientConstant value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public ClientConstant Value { get; }
    }
}
