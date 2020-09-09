// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class BinaryCollectionRequestBody : RequestBody
    {
        public ReferenceOrConstant Value { get; }

        public BinaryCollectionRequestBody(ReferenceOrConstant value)
        {
            Value = value;
        }
    }
}
