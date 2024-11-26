// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputEnumTypeFloatValue(string Name, float FloatValue, string? Summary, string? Doc) : InputEnumTypeValue(Name, FloatValue, Summary, Doc);
