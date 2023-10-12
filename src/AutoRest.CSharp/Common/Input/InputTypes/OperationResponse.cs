// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input;

internal record OperationResponse(IReadOnlyList<int> StatusCodes, InputType? BodyType, BodyMediaType BodyMediaType, IReadOnlyList<OperationResponseHeader> Headers, bool IsErrorResponse, string? ResultPath)
{
    public OperationResponse() : this(StatusCodes: Array.Empty<int>(), BodyType: null, BodyMediaType: BodyMediaType.None, Headers: Array.Empty<OperationResponseHeader>(), IsErrorResponse: false, ResultPath: null) { }

    /// <summary>
    /// Meaninngful return type of the long running operation.
    /// </summary>
    public InputType? ReturnType
    {
        get
        {
            if (BodyType is null)
                return null;

            if (ResultPath is null)
                return BodyType;

            var rawResponseType = (InputModelType)BodyType;
            return rawResponseType.Properties.FirstOrDefault(p => p.SerializedName == ResultPath)!.Type;
        }
    }
}
