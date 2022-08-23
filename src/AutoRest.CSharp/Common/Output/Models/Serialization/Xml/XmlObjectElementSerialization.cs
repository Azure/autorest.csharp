// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal class XmlObjectElementSerialization : PropertySerialization
    {
        public XmlObjectElementSerialization(ObjectTypeProperty property, XmlElementSerialization valueSerialization)
            : base(property.Declaration.Name, property.Declaration.Name, property.Declaration.Type, property.ValueType, property.SchemaProperty?.Required ?? false, property.SchemaProperty?.ReadOnly ?? false)
        {
            ValueSerialization = valueSerialization;
        }

        public XmlElementSerialization ValueSerialization { get; }
    }
}
