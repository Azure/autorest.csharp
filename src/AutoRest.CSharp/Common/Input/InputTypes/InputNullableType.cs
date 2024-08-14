// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input.InputTypes
{
    internal sealed record InputNullableType(InputType Type) : InputType("nullable")
    {
    }
}
