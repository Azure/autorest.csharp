// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input.InputTypes
{
    internal sealed record InputNullableType(InputType Type, IReadOnlyList<InputDecoratorInfo> Decorators) : InputType("nullable", Decorators)
    {
    }
}
