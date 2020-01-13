// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.TypeReferences;

namespace AutoRest.CSharp.V3.Output.Models.Responses
{
    internal class ResponseHeader
    {
        public ResponseHeader(string name, string serializedName, TypeReference type)
        {
            Name = name;
            SerializedName = serializedName;
            Type = type;
        }

        public string Name { get; }
        public string SerializedName { get; }
        public TypeReference Type { get; }
    }
}
