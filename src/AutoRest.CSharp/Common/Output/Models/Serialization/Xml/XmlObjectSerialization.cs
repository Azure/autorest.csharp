// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal class XmlObjectSerialization
    {
        public XmlObjectSerialization(string name,
            SerializableObjectType model,
            XmlObjectElementSerialization[] elements,
            XmlObjectAttributeSerialization[] attributes,
            XmlObjectArraySerialization[] embeddedArrays,
            XmlObjectContentSerialization? contentSerialization,
            string? writeXmlMethodName = null)
        {
            Type = model.Type;
            Elements = elements;
            Attributes = attributes;
            Name = name;
            EmbeddedArrays = embeddedArrays;
            ContentSerialization = contentSerialization;
            WriteXmlMethodName = writeXmlMethodName ?? "WriteInternal";
        }

        public string Name { get; }
        public XmlObjectElementSerialization[] Elements { get; }
        public XmlObjectAttributeSerialization[] Attributes { get; }
        public XmlObjectArraySerialization[] EmbeddedArrays { get; }
        public XmlObjectContentSerialization? ContentSerialization { get; }
        public CSharpType Type { get; }

        public string WriteXmlMethodName { get; }
    }
}
