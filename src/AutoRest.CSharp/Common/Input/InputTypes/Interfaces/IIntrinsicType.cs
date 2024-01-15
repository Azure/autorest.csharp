// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

public interface IIntrinsicType : IType
{
    InputIntrinsicTypeKind Kind { get; }
}
