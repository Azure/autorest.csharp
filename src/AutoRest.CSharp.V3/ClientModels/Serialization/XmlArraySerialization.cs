// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal class XmlArraySerialization : XmlSerialization
    {
        public XmlArraySerialization(ClientTypeReference type, XmlSerialization valueSerialization, string name)
        {
            Type = type;
            ValueSerialization = valueSerialization;
            Name = name;
        }

        public override ClientTypeReference Type { get; }
        public XmlSerialization ValueSerialization { get; }
        public string Name { get; }
    }
}
