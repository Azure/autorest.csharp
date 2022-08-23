// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal class XmlObjectArraySerialization : PropertySerialization
    {
        public XmlObjectArraySerialization(ObjectTypeProperty property, XmlArraySerialization arraySerialization)
            : base(property.Declaration.Name, property.Declaration.Name, property.Declaration.Type, property.ValueType, property.SchemaProperty?.Required ?? false, property.SchemaProperty?.ReadOnly ?? false)
        {
            ArraySerialization = arraySerialization;
        }

        public XmlArraySerialization ArraySerialization { get; }
    }
}
