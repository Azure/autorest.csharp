﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace AutoRest.CSharp.V3.ClientModels.Serialization
{
    internal class JsonValueSerialization: JsonSerialization
    {
        public JsonValueSerialization(ClientTypeReference type, SerializationFormat format)
        {
            Type = type;
            Format = format;
        }

        public override ClientTypeReference Type { get; }
        public SerializationFormat Format { get; }
    }
}
