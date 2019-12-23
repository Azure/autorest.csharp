// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.ClientModels.Serialization;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ResponseBody
    {
        public ResponseBody(ClientTypeReference value, JsonSerialization serialization)
        {
            Serialization = serialization;
            Value = value;
        }

        public JsonSerialization Serialization { get; }
        public ClientTypeReference Value { get; }
    }
}
