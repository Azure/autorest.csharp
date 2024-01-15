// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

public interface IPrimitiveType : IType
{
    InputPrimitiveTypeKind Kind { get; }

    public bool IsNumber => Kind is InputPrimitiveTypeKind.Int32 or InputPrimitiveTypeKind.Int64 or InputPrimitiveTypeKind.Float32 or InputPrimitiveTypeKind.Float64 or InputPrimitiveTypeKind.Float128;
}
