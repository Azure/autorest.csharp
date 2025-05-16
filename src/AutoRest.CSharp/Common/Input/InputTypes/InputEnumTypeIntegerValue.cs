// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputEnumTypeIntegerValue(string Name, int IntegerValue, InputPrimitiveType ValueType, InputEnumType EnumType, string? Summary, string? Doc) : InputEnumTypeValue(Name, IntegerValue, ValueType, EnumType, Summary, Doc);
