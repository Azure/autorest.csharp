// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Output.Models.TypeReferences;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Xml
{
    internal class XmlDictionarySerialization : XmlElementSerialization
    {
        public XmlDictionarySerialization(TypeReference type, XmlElementSerialization valueSerialization, string name)
        {
            Type = type;
            ValueSerialization = valueSerialization;
            Name = name;
        }

        public override string Name { get; }
        public override TypeReference Type { get; }
        public XmlElementSerialization ValueSerialization { get; }
    }
}
