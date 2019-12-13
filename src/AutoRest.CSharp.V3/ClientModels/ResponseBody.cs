// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ResponseBody
    {
        public ClientTypeReference Value { get; }
        public SerializationFormat Format { get; }

        public ResponseBody(ClientTypeReference value, SerializationFormat format = SerializationFormat.Default)
        {
            Value = value;
            Format = format;
        }
    }
}
