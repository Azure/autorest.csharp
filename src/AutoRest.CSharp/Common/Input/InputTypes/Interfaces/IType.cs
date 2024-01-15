// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

public interface IType
{
    string Name { get; }
    bool IsNullable { get; }

    IType WithNullable(bool isNullable);
}
