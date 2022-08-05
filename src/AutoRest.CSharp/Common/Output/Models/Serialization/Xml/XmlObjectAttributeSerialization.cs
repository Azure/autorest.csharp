// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal class XmlObjectAttributeSerialization : PropertySerialization
    {
        public XmlObjectAttributeSerialization(string serializedName, ObjectTypeProperty property, XmlValueSerialization valueSerialization)
            : base(property.Declaration.Name, serializedName, property.Declaration.Type, property.ValueType, property.SchemaProperty?.Required ?? false, property.SchemaProperty?.ReadOnly ?? false)
        {
            ValueSerialization = valueSerialization;
        }

        public XmlValueSerialization ValueSerialization { get; }
    }
}
