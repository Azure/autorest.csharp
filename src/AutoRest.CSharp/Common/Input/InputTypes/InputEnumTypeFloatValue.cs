// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputEnumTypeFloatValue(string Name, float FloatValue, InputPrimitiveType ValueType, string? Description) : InputEnumTypeValue(Name, FloatValue, ValueType, Description);
