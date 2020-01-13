// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.ClientModels.Serialization;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ObjectResponseBody: ResponseBody
    {
        public ObjectResponseBody(TypeReference type, ObjectSerialization serialization)
        {
            Serialization = serialization;
            Type = type;
        }

        public ObjectSerialization Serialization { get; }
        public override TypeReference Type { get; }
    }
}
