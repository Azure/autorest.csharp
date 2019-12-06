// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class RequestHeader
    {
        public string Name { get; }
        public ConstantOrParameter Value { get; }
        public HeaderSerializationFormat Format { get; }

        public RequestHeader(string name, ConstantOrParameter value, HeaderSerializationFormat format = HeaderSerializationFormat.Default)
        {
            Name = name;
            Value = value;
            Format = format;
        }
    }
}
