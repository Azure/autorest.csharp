// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputLiteralType(InputType ValueType, object Value) : InputType("Literal"); // TODO -- name?
