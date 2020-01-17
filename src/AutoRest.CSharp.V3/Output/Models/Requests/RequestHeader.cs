﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.Serialization;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class RequestHeader
    {
        public string Name { get; }
        public ParameterOrConstant Value { get; }
        public SerializationFormat Format { get; }

        public RequestHeader(string name, ParameterOrConstant value, SerializationFormat format = SerializationFormat.Default)
        {
            Name = name;
            Value = value;
            Format = format;
        }
    }
}
