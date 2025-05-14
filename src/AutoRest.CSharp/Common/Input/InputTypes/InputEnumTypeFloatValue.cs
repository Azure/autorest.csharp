// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputEnumTypeFloatValue(string Name, float FloatValue, InputPrimitiveType ValueType, InputEnumType EnumType, string? Summary, string? Doc) : InputEnumTypeValue(Name, FloatValue, ValueType, EnumType, Summary, Doc);
