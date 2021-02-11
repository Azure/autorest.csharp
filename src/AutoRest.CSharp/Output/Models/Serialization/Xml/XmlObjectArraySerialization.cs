// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Xml
{
    internal class XmlObjectArraySerialization
    {
        public XmlObjectArraySerialization(ObjectTypeProperty property, XmlArraySerialization arraySerialization)
        {
            Property = property;
            ArraySerialization = arraySerialization;
        }

        public ObjectTypeProperty Property { get; }
        public XmlArraySerialization ArraySerialization { get; }
    }
}
