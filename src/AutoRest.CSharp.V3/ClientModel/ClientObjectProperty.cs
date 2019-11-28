// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModel
{
    internal class ClientObjectProperty
    {
        public ClientObjectProperty(string name, ClientTypeReference type, bool isReadOnly)
        {
            Name = name;
            Type = type;
            IsReadOnly = isReadOnly;
        }

        public string Name { get; }
        public ClientTypeReference Type { get; }
        public bool IsReadOnly { get; }
    }
}
