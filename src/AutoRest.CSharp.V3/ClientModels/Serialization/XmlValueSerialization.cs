// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal class XmlValueSerialization
    {
        public XmlValueSerialization(ClientTypeReference type, SerializationFormat format)
        {
            Type = type;
            Format = format;
        }
        public ClientTypeReference Type { get; }
        public SerializationFormat Format { get; }
    }
}
