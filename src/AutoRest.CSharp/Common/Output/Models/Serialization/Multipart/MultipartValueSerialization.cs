// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Output.Models.Serialization.Multipart
{
    internal class MultipartValueSerialization: MultipartSerialization
    {
        public MultipartValueSerialization(CSharpType type, SerializationFormat format, ValueExpression serializedValue, ValueExpression? deserializedValue, bool isNullable) : base(isNullable)
        {
            Type = type;
            Format = format;
            SerializedValue = serializedValue;
            DeserializedValue = deserializedValue;
        }
        public CSharpType Type { get; }
        public SerializationFormat Format { get; }
        public ValueExpression SerializedValue { get; }
        public ValueExpression? DeserializedValue { get; }
    }
}
