// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.Generation.Types;

namespace AutoRest.CSharp.Output.Models.Serialization.Bicep
{
    internal class BicepArraySerialization : BicepSerialization
    {
        public BicepArraySerialization(CSharpType implementationType, BicepSerialization valueSerialization, bool isNullable) : base(isNullable)
        {
            ImplementationType = implementationType;
            ValueSerialization = valueSerialization;
        }

        public CSharpType ImplementationType { get; }
        public BicepSerialization ValueSerialization { get; }
    }
}
