// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Xml
{
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
}
