﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace AutoRest.CSharp.Common.Input;

internal record InputListType(string Name, InputType ElementType, bool IsEmbeddingsVector) : InputType(Name) { }
