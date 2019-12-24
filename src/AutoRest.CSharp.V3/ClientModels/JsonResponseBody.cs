// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.ClientModels.Serialization;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class JsonResponseBody: ResponseBody
    {
        public JsonResponseBody(ClientTypeReference type, JsonSerialization serialization)
        {
            Serialization = serialization;
            Type = type;
        }

        public JsonSerialization Serialization { get; }
        public override ClientTypeReference Type { get; }
    }
}
