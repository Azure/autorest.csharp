// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientObjectProperty
    {
        public ClientObjectProperty(string name, ClientTypeReference type, bool isReadOnly, bool isRequired, string serializedName,
            SerializationFormat format = SerializationFormat.Default, ClientConstant? defaultValue = null)
        {
            Name = name;
            Type = type;
            IsReadOnly = isReadOnly;
            IsRequired = isRequired;
            SerializedName = serializedName;
            Format = format;
            DefaultValue = defaultValue;
        }

        public string Name { get; }
        public ClientConstant? DefaultValue { get; }
        public ClientTypeReference Type { get; }
        public bool IsReadOnly { get; }
        public bool IsRequired { get; }
        public string SerializedName { get; set; }
        public SerializationFormat Format { get; }
    }
}
