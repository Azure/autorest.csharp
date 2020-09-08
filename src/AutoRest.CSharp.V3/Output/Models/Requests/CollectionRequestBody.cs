// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class CollectionRequestBody : RequestBody
    {
        public ReferenceOrConstant Value { get; }

        public CollectionRequestBody(ReferenceOrConstant value)
        {
            Value = value;
        }
    }
}
