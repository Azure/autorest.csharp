// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Xml
{
    internal class XmlObjectSerialization: XmlElementSerialization
    {
        public XmlObjectSerialization(string name,
            CSharpType type,
            XmlObjectElementSerialization[] elements,
            XmlObjectAttributeSerialization[] attributes,
            XmlObjectArraySerialization[] embeddedArrays,
            XmlObjectContentSerialization? contentSerialization)
        {
            Type = type;
            Elements = elements;
            Attributes = attributes;
            Name = name;
            EmbeddedArrays = embeddedArrays;
            ContentSerialization = contentSerialization;
        }

        public override string Name { get; }
        public XmlObjectElementSerialization[] Elements { get; }
        public XmlObjectAttributeSerialization[] Attributes { get; }
        public XmlObjectArraySerialization[] EmbeddedArrays { get; }
        public XmlObjectContentSerialization? ContentSerialization { get; }
        public CSharpType Type { get; }
    }
}
