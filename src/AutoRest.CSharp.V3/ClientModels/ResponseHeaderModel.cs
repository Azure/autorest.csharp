// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ResponseHeaderModel
    {
        public ResponseHeaderModel(string name, ResponseHeader[] headers)
        {
            Name = name;
            Headers = headers;
        }

        public string Name { get; }

        public ResponseHeader[] Headers { get; }
    }
}
