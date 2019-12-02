﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModel
{
    internal class ClientObjectProperty
    {
        public ClientObjectProperty(string name, ClientTypeReference type, bool isReadOnly, string serializedName)
        {
            Name = name;
            Type = type;
            IsReadOnly = isReadOnly;
            SerializedName = serializedName;
        }

        public string Name { get; }
        public ClientTypeReference Type { get; }
        public bool IsReadOnly { get; }
        public string SerializedName { get; set; }
    }
}
