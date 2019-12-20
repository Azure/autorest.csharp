// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.ClientModels.Serialization;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class QueryParameter
    {
        public QueryParameter(string name, ClientTypeReference type, FlatSerialization serialization, bool escape)
        {
            Name = name;
            Type = type;
            Escape = escape;
            Serialization = serialization;
        }

        public string Name { get; }
        public ClientTypeReference Type { get; }
        public bool Escape { get; }

        public FlatSerialization Serialization { get; set; }
    }
}
