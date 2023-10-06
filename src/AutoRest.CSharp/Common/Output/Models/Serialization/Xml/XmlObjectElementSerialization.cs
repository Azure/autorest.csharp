// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal class XmlObjectElementSerialization : XmlPropertySerialization
    {
        public XmlObjectElementSerialization(string serializedName, CSharpType serializedType, ObjectTypeProperty property, XmlElementSerialization valueSerialization)
            : base(serializedName, serializedType, property)
        {
            ValueSerialization = valueSerialization;
        }

        public XmlElementSerialization ValueSerialization { get; }
    }
}
