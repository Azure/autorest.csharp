// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record OperationResponseHeader(string Name, string NameInResponse, string Description, IType Type)
{
    public OperationResponseHeader() : this("", "", "", InputPrimitiveType.String) { }
}
