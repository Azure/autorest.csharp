// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.ClientModels.Serialization;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class JsonRequestBody
    {
        public ConstantOrParameter Value { get; }
        public JsonSerialization Serialization { get; }

        public JsonRequestBody(ConstantOrParameter value, JsonSerialization serialization)
        {
            Value = value;
            Serialization = serialization;
        }
    }
}
