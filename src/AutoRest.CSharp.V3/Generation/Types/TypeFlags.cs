// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.V3.Generation.Types
{
    [Flags]
    internal enum TypeFlags
    {
        Normal = 1,
        Input = 1 << 1,
        Output = 1 << 2,
        Implementation = 1 << 3,
    }
}