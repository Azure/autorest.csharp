// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.


namespace AutoRest.CSharp.V3.ClientModels
{
    internal class StreamRequestBody
    {
        public StreamRequestBody(ConstantOrParameter value)
        {
            Value = value;
        }

        public ConstantOrParameter Value { get; }
    }
}
