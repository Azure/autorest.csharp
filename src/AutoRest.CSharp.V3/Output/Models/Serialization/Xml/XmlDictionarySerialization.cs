// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Xml
{
    internal class XmlDictionarySerialization : XmlElementSerialization
    {
        public XmlDictionarySerialization(CSharpType type, XmlElementSerialization valueSerialization, string name, CSharpType implementationType)
        {
            Type = type;
            ValueSerialization = valueSerialization;
            Name = name;
            ImplementationType = implementationType;
        }

        public override string Name { get; }
        public override CSharpType Type { get; }
        public CSharpType ImplementationType { get; }
        public XmlElementSerialization ValueSerialization { get; }
    }
}
