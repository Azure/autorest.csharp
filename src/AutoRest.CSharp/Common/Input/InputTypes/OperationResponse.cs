// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record OperationResponse(IReadOnlyList<int> StatusCodes, InputType? BodyType, IReadOnlyList<OperationResponseHeader> Headers, bool IsErrorResponse, IReadOnlyList<string> ContentTypes)
{
    public OperationResponse() : this(StatusCodes: Array.Empty<int>(), BodyType: null, Headers: Array.Empty<OperationResponseHeader>(), IsErrorResponse: false, ContentTypes: Array.Empty<string>()) { }

    public OperationResponse(IReadOnlyList<int> StatusCodes, InputType? BodyType, BodyMediaType BodyMediaType, IReadOnlyList<OperationResponseHeader> Headers, bool IsErrorResponse, IReadOnlyList<string> ContentTypes) : this(StatusCodes, BodyType, Headers, IsErrorResponse, ContentTypes)
    {
        _bodyMediaType = BodyMediaType;
    }

    private BodyMediaType? _bodyMediaType;

    public BodyMediaType BodyMediaType => _bodyMediaType ??= (ContentTypes.Count > 0 ? BodyMediaTypeHelper.DetermineBodyMediaType(ContentTypes) : BodyMediaType.None);
}
