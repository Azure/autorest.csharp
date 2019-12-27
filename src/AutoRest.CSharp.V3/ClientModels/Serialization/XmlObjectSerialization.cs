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
        public XmlArraySerialization(ClientTypeReference type, XmlSerialization valueSerialization)
        {
            Type = type;
            ValueSerialization = valueSerialization;
        }

        public override ClientTypeReference Type { get; }
        public XmlSerialization ValueSerialization { get; }
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

    internal class XmlNamedElementSerialization
    {
        public XmlNamedElementSerialization(
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

    internal class XmlNamedAttributeSerialization
    {
        public XmlNamedAttributeSerialization(
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

    internal class XmlObjectSerialization: XmlSerialization
    {
        public XmlObjectSerialization(
            ClientTypeReference type,
            XmlNamedElementSerialization[] elements,
            XmlNamedAttributeSerialization[] attributes,
            string elementName)
        {
            Type = type;
            Elements = elements;
            Attributes = attributes;
            ElementName = elementName;
        }
        public string ElementName { get; }
        public XmlNamedElementSerialization[] Elements { get; }
        public XmlNamedAttributeSerialization[] Attributes { get; }
        public override ClientTypeReference Type { get; }
    }
}
