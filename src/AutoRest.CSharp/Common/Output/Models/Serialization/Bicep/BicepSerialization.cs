// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.Output.Models.Serialization.Bicep
{
    internal abstract class BicepSerialization : ObjectSerialization
    {
        protected BicepSerialization(bool isNullable)
        {
            IsNullable = isNullable;
        }

        public bool IsNullable { get; }
    }
}
