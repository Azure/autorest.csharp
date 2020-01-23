// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.V3.Generation.Types;

namespace AutoRest.CSharp.V3.Output.Models.Types
{
    internal interface ITypeProvider
    {
        CSharpType Type { get; }
    }
}
