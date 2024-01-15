// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputEnumType(string Name, string? Namespace, string? Accessibility, string? Deprecated, string Description, InputModelTypeUsage Usage, IPrimitiveType EnumValueType, IReadOnlyList<IEnumTypeValue> AllowedValues, bool IsExtensible, bool IsNullable)
    : InputType(Name, IsNullable), IEnumType;
