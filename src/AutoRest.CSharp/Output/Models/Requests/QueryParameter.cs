// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class QueryParameter
    {
        public QueryParameter(string name, ReferenceOrConstant value, RequestParameterSerializationStyle serializationStyle, bool escape, SerializationFormat serializationFormat)
        {
            Name = name;
            Value = value;
            SerializationStyle = serializationStyle;
            Escape = escape;
            SerializationFormat = serializationFormat;
        }

        public string Name { get; }
        public ReferenceOrConstant Value { get; }
        public RequestParameterSerializationStyle SerializationStyle { get; }
        public SerializationFormat SerializationFormat { get; }
        public bool Escape { get; }
    }
}
