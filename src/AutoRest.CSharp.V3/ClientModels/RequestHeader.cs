// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Pipeline.Generated;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class RequestHeader
    {
        public string Name { get; }
        public ConstantOrParameter Value { get; }
        public SerializationFormat Format { get; }

        public RequestHeader(string name, ConstantOrParameter value, SerializationFormat format = SerializationFormat.Default)
        {
            Name = name;
            Value = value;
            Format = format;
        }
    }
}
