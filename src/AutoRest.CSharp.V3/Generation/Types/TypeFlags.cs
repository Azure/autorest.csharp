// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.V3.Generation.Types
{
    [Flags]
    internal enum TypeFlags
    {
        Normal = 0,
        Input = 1,
        Output = 1 << 1
    }
}