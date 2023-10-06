// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal class XmlObjectAttributeSerialization : XmlPropertySerialization
    {
        public XmlObjectAttributeSerialization(string serializedName, CSharpType serializedType, ObjectTypeProperty property, XmlValueSerialization valueSerialization)
            : base(serializedName, serializedType, property)
        {
            ValueSerialization = valueSerialization;
        }

        public XmlValueSerialization ValueSerialization { get; }
    }
}
