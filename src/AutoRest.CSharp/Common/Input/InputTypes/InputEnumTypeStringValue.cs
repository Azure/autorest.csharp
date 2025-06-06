﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputEnumTypeStringValue(string Name, string StringValue, InputPrimitiveType ValueType, InputEnumType EnumType, string? Summary, string? Doc) : InputEnumTypeValue(Name, StringValue, ValueType, EnumType, Summary, Doc);
