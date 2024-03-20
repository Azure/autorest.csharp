// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal class XmlObjectArraySerialization : XmlPropertySerialization
    {
        public XmlObjectArraySerialization(string serializedName, CSharpType serializedType, ObjectTypeProperty property, XmlArraySerialization arraySerialization)
            : base(serializedName, serializedType, property)
        {
            ArraySerialization = arraySerialization;
        }

        public XmlArraySerialization ArraySerialization { get; }
    }
}
