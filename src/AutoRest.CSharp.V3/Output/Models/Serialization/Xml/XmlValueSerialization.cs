// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Xml
{
    internal class XmlValueSerialization
    {
        public XmlValueSerialization(CSharpType type, SerializationFormat format)
        {
            Type = type;
            Format = format;
        }
        public CSharpType Type { get; }
        public SerializationFormat Format { get; }
    }
}
