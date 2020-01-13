// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal class XmlValueSerialization
    {
        public XmlValueSerialization(TypeReference type, SerializationFormat format)
        {
            Type = type;
            Format = format;
        }
        public TypeReference Type { get; }
        public SerializationFormat Format { get; }
    }
}
