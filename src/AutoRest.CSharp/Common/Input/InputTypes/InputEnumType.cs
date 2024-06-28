// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputEnumType(string Name, string CrossLanguageDefinitionId, string? Accessibility, string? Deprecated, string Description, InputModelTypeUsage Usage, InputPrimitiveType ValueType, IReadOnlyList<InputEnumTypeValue> Values, bool IsExtensible)
    : InputType(Name);
