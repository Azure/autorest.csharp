// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputListType(InputType ValueType, bool IsEmbeddingsVector, bool IsNullable) : InputType("Array", IsNullable) { }
