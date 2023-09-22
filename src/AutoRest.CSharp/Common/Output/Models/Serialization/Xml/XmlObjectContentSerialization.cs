// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal class XmlObjectContentSerialization : XmlPropertySerialization
    {
        public XmlObjectContentSerialization(ObjectTypeProperty property, XmlValueSerialization valueSerialization)
            : base(property.Declaration.Name, property)
        {
            ValueSerialization = valueSerialization;
        }

        public XmlValueSerialization ValueSerialization { get; }
    }
}
