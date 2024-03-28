// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.Common.Input
{
    internal record InputSystemType(Type Type, InputType ElementType, bool IsNullable) : InputType(Type.Name, IsNullable, ElementType.OriginalName);
}
