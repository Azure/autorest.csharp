// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputListType(string Name, InputType ValueType, bool IsEmbeddingsVector, bool IsNullable) : InputType(Name, IsNullable);
