// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal class XmlElementValueSerialization: XmlElementSerialization
    {
        public XmlElementValueSerialization(string name, XmlValueSerialization value)
        {
            Name = name;
            Value = value;
        }

        public override string Name { get; }
        public override TypeReference Type => Value.Type;
        public XmlValueSerialization Value { get; }
    }
}
