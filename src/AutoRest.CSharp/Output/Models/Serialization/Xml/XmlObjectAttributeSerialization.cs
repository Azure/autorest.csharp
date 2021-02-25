// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal class XmlObjectAttributeSerialization
    {
        public XmlObjectAttributeSerialization(
            string name,
            ObjectTypeProperty property,
            XmlValueSerialization valueSerialization)
        {
            Name = name;
            Property = property;
            ValueSerialization = valueSerialization;
        }

        public string Name { get; }
        public ObjectTypeProperty Property { get; }
        public XmlValueSerialization ValueSerialization { get; }
    }
}
