// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputServiceMethodResponse(InputType? Type, IReadOnlyList<string> ResultSegments)
{
    internal InputServiceMethodResponse() : this(null, []) { }
}
