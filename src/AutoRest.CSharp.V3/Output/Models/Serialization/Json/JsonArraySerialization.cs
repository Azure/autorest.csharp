// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Serialization.Json
{
    internal class JsonArraySerialization: JsonSerialization
    {
        public JsonArraySerialization(CSharpType type, JsonSerialization valueSerialization)
        {
            Type = type;
            ValueSerialization = valueSerialization;
        }

        public override CSharpType Type { get; }
        public JsonSerialization ValueSerialization { get; }
    }
}
