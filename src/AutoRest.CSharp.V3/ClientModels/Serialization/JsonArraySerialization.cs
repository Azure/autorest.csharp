// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal class JsonArraySerialization: JsonSerialization
    {
        public JsonArraySerialization(ClientTypeReference type, JsonSerialization valueSerialization)
        {
            Type = type;
            ValueSerialization = valueSerialization;
        }

        public override ClientTypeReference Type { get; }
        public JsonSerialization ValueSerialization { get; }
    }
}
