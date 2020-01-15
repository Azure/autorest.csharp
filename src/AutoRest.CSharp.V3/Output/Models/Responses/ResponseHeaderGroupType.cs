// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.Output.Models.Responses
{
    internal class ResponseHeaderGroupType
    {
        public ResponseHeaderGroupType(string name, string description, ResponseHeader[] headers)
        {
            Name = name;
            Headers = headers;
            Description = description;
        }

        public string Name { get; }
        public string Description { get; }
        public ResponseHeader[] Headers { get; }
    }
}
