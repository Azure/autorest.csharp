// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Xml
{
    internal class XmlArraySerialization : XmlElementSerialization
    {
        public XmlArraySerialization(CSharpType type, XmlElementSerialization valueSerialization, string name, bool wrapped, CSharpType implementationType)
        {
            Type = type;
            ValueSerialization = valueSerialization;
            Name = name;
            Wrapped = wrapped;
            ImplementationType = implementationType;
        }

        public override CSharpType Type { get; }
        public CSharpType ImplementationType { get; }
        public XmlElementSerialization ValueSerialization { get; }
        public override string Name { get; }
        public bool Wrapped { get; }
    }
}
