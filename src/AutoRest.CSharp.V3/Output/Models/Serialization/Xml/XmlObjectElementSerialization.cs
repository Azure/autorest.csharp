// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Xml
{
    internal class XmlObjectElementSerialization
    {
        public XmlObjectElementSerialization(
            string memberName,
            XmlElementSerialization valueSerialization)
        {
            MemberName = memberName;
            ValueSerialization = valueSerialization;
        }

        public string MemberName { get; }
        public CSharpType Type => ValueSerialization.Type;
        public XmlElementSerialization ValueSerialization { get; }
    }
}
