// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class FrameworkTypeReference: ClientTypeReference
    {
        public FrameworkTypeReference(Type type, bool isNullable = false)
        {
            Type = type;
            IsNullable = isNullable;
        }

        public Type Type { get; }
        public override bool IsNullable { get; }
    }
}
