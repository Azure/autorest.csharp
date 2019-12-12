// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Pipeline;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class RequestBody
    {
        public ConstantOrParameter Value { get; }
        public SerializationFormat Format { get; }
        public string Name { get; }
        public ClientTypeReference Type { get; }

        public RequestBody(ConstantOrParameter value, SerializationFormat format = SerializationFormat.Default)
        {
            Value = value;
            Format = format;
            Name = Value.IsConstant ? Value.Constant.ToValueString() : Value.Parameter.Name;
            Type = Value.IsConstant ? Value.Constant.Type : Value.Parameter.Type;
        }
    }
}
