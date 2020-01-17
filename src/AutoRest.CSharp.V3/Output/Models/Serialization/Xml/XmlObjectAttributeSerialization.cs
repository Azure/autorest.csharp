// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Output.Models.TypeReferences;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Xml
{
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
        public TypeReference Type => ValueSerialization.Type;
        public XmlValueSerialization ValueSerialization { get; }
    }
}
