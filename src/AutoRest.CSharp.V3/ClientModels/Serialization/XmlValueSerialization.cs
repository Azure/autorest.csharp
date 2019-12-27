// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal class XmlValueSerialization: XmlSerialization
    {
        public XmlValueSerialization(ClientTypeReference type, SerializationFormat format)
        {
            Type = type;
            Format = format;
        }

        public override ClientTypeReference Type { get; }
        public SerializationFormat Format { get; }
    }
}
