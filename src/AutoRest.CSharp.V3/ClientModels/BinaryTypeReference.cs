// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class BinaryTypeReference : ClientTypeReference
    {
        public BinaryTypeReference(bool isNullable)
        {
            IsNullable = isNullable;
        }

        public override bool IsNullable { get; }
    }
}
