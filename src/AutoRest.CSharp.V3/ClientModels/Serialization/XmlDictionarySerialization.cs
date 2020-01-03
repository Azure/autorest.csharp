// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal class XmlDictionarySerialization : XmlElementSerialization
    {
        public XmlDictionarySerialization(ClientTypeReference type, XmlElementSerialization valueSerialization, string name)
        {
            Type = type;
            ValueSerialization = valueSerialization;
            Name = name;
        }

        public override string Name { get; }
        public override ClientTypeReference Type { get; }
        public XmlElementSerialization ValueSerialization { get; }
    }
}
