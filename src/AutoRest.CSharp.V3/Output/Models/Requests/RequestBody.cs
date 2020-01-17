﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.Serialization;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class RequestBody
    {
        public ParameterOrConstant Value { get; }
        public ObjectSerialization Serialization { get; }

        public RequestBody(ParameterOrConstant value, ObjectSerialization serialization)
        {
            Value = value;
            Serialization = serialization;
        }
    }
}
