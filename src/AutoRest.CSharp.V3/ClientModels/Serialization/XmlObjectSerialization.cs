// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#pragma warning disable SA1402, SA1649
namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal abstract class XmlSerialization: ObjectSerialization
    {
    }

    internal class XmlDictionarySerialization : XmlSerialization
    {
        public XmlDictionarySerialization(ClientTypeReference type, XmlSerialization valueSerialization)
        {
            Type = type;
            ValueSerialization = valueSerialization;
        }

        public override ClientTypeReference Type { get; }
        public XmlSerialization ValueSerialization { get; }
    }
    internal class XmlArraySerialization : XmlSerialization
    {
        public XmlArraySerialization(ClientTypeReference type, XmlSerialization valueSerialization, string name)
        {
            Type = type;
            ValueSerialization = valueSerialization;
            Name = name;
        }

        public override ClientTypeReference Type { get; }
        public XmlSerialization ValueSerialization { get; }
        public string Name { get; }
    }

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

    internal class XmlObjectElementSerialization
    {
        public XmlObjectElementSerialization(
            string name,
            string memberName,
            XmlSerialization valueSerialization)
        {
            Name = name;
            MemberName = memberName;
            ValueSerialization = valueSerialization;
        }

        public string Name { get; }
        public string MemberName { get; }
        public XmlSerialization ValueSerialization { get; }
    }

    internal class XmlObjectAttributeSerialization
    {
        public XmlObjectAttributeSerialization(
            string name,
            string memberName,
            XmlValueSerialization valueSerialization)
        {
            Name = name;
            MemberName = memberName;
            ValueSerialization = valueSerialization;
        }

        public string Name { get; }
        public string MemberName { get; }
        public XmlValueSerialization ValueSerialization { get; }
    }

    internal class XmlObjectArraySerialization
    {
        public XmlObjectArraySerialization(string memberName, XmlArraySerialization arraySerialization)
        {
            MemberName = memberName;
            ArraySerialization = arraySerialization;
        }

        public string MemberName { get; }
        public XmlArraySerialization ArraySerialization { get; }
    }

    internal class XmlObjectSerialization: XmlSerialization
    {
        public XmlObjectSerialization(
            ClientTypeReference type,
            XmlObjectElementSerialization[] elements,
            XmlObjectAttributeSerialization[] attributes,
            string elementName,
            XmlObjectArraySerialization[] embeddedArrays)
        {
            Type = type;
            Elements = elements;
            Attributes = attributes;
            ElementName = elementName;
            EmbeddedArrays = embeddedArrays;
        }
        public string ElementName { get; }
        public XmlObjectElementSerialization[] Elements { get; }
        public XmlObjectAttributeSerialization[] Attributes { get; }
        public XmlObjectArraySerialization[] EmbeddedArrays { get; }
        public override ClientTypeReference Type { get; }
    }
}
