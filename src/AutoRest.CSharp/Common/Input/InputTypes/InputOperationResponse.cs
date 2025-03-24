// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputOperationResponse(IReadOnlyList<int> StatusCodes, InputType? BodyType, IReadOnlyList<InputOperationResponseHeader> Headers, bool IsErrorResponse, IReadOnlyList<string> ContentTypes)
{
    public InputOperationResponse() : this(StatusCodes: Array.Empty<int>(), BodyType: null, Headers: Array.Empty<InputOperationResponseHeader>(), IsErrorResponse: false, ContentTypes: Array.Empty<string>()) { }

    [Obsolete("For swagger input only")]
    public InputOperationResponse(IReadOnlyList<int> StatusCodes, InputType? BodyType, BodyMediaType BodyMediaType, IReadOnlyList<InputOperationResponseHeader> Headers, bool IsErrorResponse, IReadOnlyList<string> ContentTypes) : this(StatusCodes, BodyType, Headers, IsErrorResponse, ContentTypes)
    {
        _bodyMediaType = BodyMediaType;
    }

    private BodyMediaType? _bodyMediaType;

    public BodyMediaType BodyMediaType => _bodyMediaType ??= (ContentTypes.Count > 0 ? BodyMediaTypeHelper.DetermineBodyMediaType(ContentTypes) : BodyMediaType.None);
}
