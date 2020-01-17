// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Output.Models.TypeReferences;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Xml
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
