// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputServiceMethodResponse
{
    public InputServiceMethodResponse(InputType? type, IReadOnlyList<string>? resultSegments)
    {
        Type = type;
        ResultSegments = resultSegments;
    }

    internal InputServiceMethodResponse() : this(null, null) { }

    public InputType? Type { get; internal set; }
    public IReadOnlyList<string>? ResultSegments { get; internal set; }
}
