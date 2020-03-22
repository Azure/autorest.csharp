// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Output.Models.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Xml
{
    internal class XmlObjectElementSerialization
    {
        public XmlObjectElementSerialization(
            ObjectTypeProperty property,
            XmlElementSerialization valueSerialization)
        {
            Property = property;
            ValueSerialization = valueSerialization;
        }

        public ObjectTypeProperty Property { get; }
        public XmlElementSerialization ValueSerialization { get; }
    }
}
