// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Bicep
{
    internal class BicepDictionarySerialization : BicepSerialization
    {
        public BicepDictionarySerialization(CSharpType type, BicepSerialization valueSerialization, bool isNullable) : base(isNullable)
        {
            Type = type;
            ValueSerialization = valueSerialization;
        }

        public CSharpType Type { get; }
        public BicepSerialization ValueSerialization { get; }
    }
}
