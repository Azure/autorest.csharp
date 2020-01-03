// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.ClientModels.Serialization;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ObjectRequestBody
    {
        public ConstantOrParameter Value { get; }
        public ObjectSerialization Serialization { get; }

        public ObjectRequestBody(ConstantOrParameter value, ObjectSerialization serialization)
        {
            Value = value;
            Serialization = serialization;
        }
    }
}
