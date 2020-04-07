// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.Serialization;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class RequestHeader
    {
        public string Name { get; }
        public ReferenceOrConstant Value { get; }
        public RequestSerializationStyle SerializationStyle { get; }
        public SerializationFormat Format { get; }

        public RequestHeader(string name, ReferenceOrConstant value, RequestSerializationStyle serializationStyle, SerializationFormat format = SerializationFormat.Default)
        {
            Name = name;
            Value = value;
            SerializationStyle = serializationStyle;
            Format = format;
        }
    }
}
