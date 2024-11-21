// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record OperationResponseHeader(string Name, string NameInResponse, string Summary, string Doc, InputType Type)
{
    public OperationResponseHeader() : this(string.Empty, string.Empty, string.Empty, string.Empty, InputPrimitiveType.String) { }

    public string Description { get; init; } = string.IsNullOrEmpty(Summary) ? Doc : Summary;
}
