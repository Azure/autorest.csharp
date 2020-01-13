// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class RequestHeader
    {
        public string Name { get; }
        public RequestParameter Value { get; }
        public SerializationFormat Format { get; }

        public RequestHeader(string name, RequestParameter value, SerializationFormat format = SerializationFormat.Default)
        {
            Name = name;
            Value = value;
            Format = format;
        }
    }
}
