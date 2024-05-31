// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input.InputTypes
{
    internal record InputNullableType(InputType ValueType): InputType("nullable")
    {
    }
}
