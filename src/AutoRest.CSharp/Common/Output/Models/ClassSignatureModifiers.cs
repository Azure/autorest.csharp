﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.Common.Output.Models
{
    [Flags]
    internal enum ClassSignatureModifiers
    {
        None = 0,
        Public = 1,
        Internal = 2,
        Private = 8,
        Static = 16,
        Partial = 32,
        Sealed = 64,
    }
}
