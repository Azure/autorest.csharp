// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal class XmlObjectSerialization
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

        public string Name { get; }
        public XmlObjectElementSerialization[] Elements { get; }
        public XmlObjectAttributeSerialization[] Attributes { get; }
        public XmlObjectArraySerialization[] EmbeddedArrays { get; }
        public XmlObjectContentSerialization? ContentSerialization { get; }
        public CSharpType Type { get; }

        public ObjectType? ObjectType => Type.IsFrameworkType ? null : Type.Implementation as ObjectType;
    }
}
