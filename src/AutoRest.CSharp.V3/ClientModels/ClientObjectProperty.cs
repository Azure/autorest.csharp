// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientObjectProperty
    {
        public ClientObjectProperty(string name, ClientTypeReference type, bool isReadOnly, string serializedName, SerializationFormat format = SerializationFormat.Default)
        {
            Name = name;
            Type = type;
            IsReadOnly = isReadOnly;
            SerializedName = serializedName;
            Format = format;
        }

        public string Name { get; }
        public ClientTypeReference Type { get; }
        public bool IsReadOnly { get; }
        public string SerializedName { get; set; }
        public SerializationFormat Format { get; }
    }
}
