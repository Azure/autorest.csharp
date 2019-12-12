// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class RequestBody
    {
        public ConstantOrParameter Value { get; }
        public SerializationFormat Format { get; }

        public RequestBody(ConstantOrParameter value, SerializationFormat format = SerializationFormat.Default)
        {
            Value = value;
            Format = format;
        }
    }
}
