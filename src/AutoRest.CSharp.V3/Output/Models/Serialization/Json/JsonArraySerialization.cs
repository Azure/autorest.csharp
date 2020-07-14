// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonArraySerialization: JsonSerialization
    {
        public JsonArraySerialization(CSharpType implementationType, JsonSerialization valueSerialization, bool isNullable) : base(isNullable)
        {
            ImplementationType = implementationType;
            ValueSerialization = valueSerialization;
        }

        public CSharpType ImplementationType { get; }
        public JsonSerialization ValueSerialization { get; }
    }
}
