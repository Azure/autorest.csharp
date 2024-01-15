// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

public interface ILiteralType : IType
{
    IType LiteralValueType { get; }

    object Value { get; }
}
