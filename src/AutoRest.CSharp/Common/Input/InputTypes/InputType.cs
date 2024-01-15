// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal abstract record InputType(string Name, bool IsNullable) : IType
{
    public IType WithNullable(bool isNullable)
    {
        if (IsNullable == isNullable)
        {
            return this;
        }

        return this with { IsNullable = isNullable };
    }
}
