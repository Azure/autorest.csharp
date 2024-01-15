// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input;

internal record InputUnionType(IReadOnlyList<IType> UnionItemTypes, bool IsNullable) : InputType("Union", IsNullable), IUnionType;
