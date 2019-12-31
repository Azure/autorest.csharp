// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal class XmlObjectElementSerialization
    {
        public XmlObjectElementSerialization(
            string memberName,
            XmlElementSerialization valueSerialization)
        {
            MemberName = memberName;
            ValueSerialization = valueSerialization;
        }

        public string MemberName { get; }
        public ClientTypeReference Type => ValueSerialization.Type;
        public XmlElementSerialization ValueSerialization { get; }
    }
}
