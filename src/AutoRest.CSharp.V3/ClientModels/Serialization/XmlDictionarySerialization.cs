// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal class XmlDictionarySerialization : XmlSerialization
    {
        public XmlDictionarySerialization(ClientTypeReference type, XmlSerialization valueSerialization)
        {
            Type = type;
            ValueSerialization = valueSerialization;
        }

        public override ClientTypeReference Type { get; }
        public XmlSerialization ValueSerialization { get; }
    }
}
