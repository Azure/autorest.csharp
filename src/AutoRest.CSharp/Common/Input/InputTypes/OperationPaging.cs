// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace AutoRest.CSharp.Common.Input;

internal record OperationPaging(string? NextLinkName, string? ItemName, InputOperation? NextLinkOperation)
{
    public OperationPaging() : this(null, null, null) { }
}
