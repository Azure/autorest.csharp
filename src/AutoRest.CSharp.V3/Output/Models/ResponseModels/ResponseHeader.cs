// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ResponseHeader
    {
        public ResponseHeader(string name, string serializedName, ClientTypeReference type)
        {
            Name = name;
            SerializedName = serializedName;
            Type = type;
        }

        public string Name { get; }
        public string SerializedName { get; }
        public ClientTypeReference Type { get; }
    }
}
