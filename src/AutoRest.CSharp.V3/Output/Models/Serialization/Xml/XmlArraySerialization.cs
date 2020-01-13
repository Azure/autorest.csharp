// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal class XmlArraySerialization : XmlElementSerialization
    {
        public XmlArraySerialization(TypeReference type, XmlElementSerialization valueSerialization, string name, bool wrapped)
        {
            Type = type;
            ValueSerialization = valueSerialization;
            Name = name;
            Wrapped = wrapped;
        }

        public override TypeReference Type { get; }
        public XmlElementSerialization ValueSerialization { get; }
        public override string Name { get; }
        public bool Wrapped { get; }
    }
}
