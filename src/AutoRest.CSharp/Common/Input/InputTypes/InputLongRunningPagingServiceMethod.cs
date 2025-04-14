// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputLongRunningPagingServiceMethod : InputServiceMethod
{
    public InputLongRunningPagingServiceMethod(
        string name,
        string? accessibility,
        string[] apiVersions,
        string? documentation,
        string? summary,
        InputOperation operation,
        IReadOnlyList<InputParameter> parameters,
        InputServiceMethodResponse response,
        InputServiceMethodResponse? exception,
        bool isOverride,
        bool generateConvenient,
        bool generateProtocol,
        string crossLanguageDefinitionId) : base(
            name,
            accessibility,
            apiVersions,
            documentation,
            summary,
            operation,
            parameters,
            response,
            exception,
            isOverride,
            generateConvenient,
            generateProtocol,
            crossLanguageDefinitionId)
    { }

    internal InputLongRunningPagingServiceMethod() : this(
       string.Empty,
       string.Empty,
       [],
       string.Empty,
       string.Empty,
       new InputOperation(),
       [],
       new InputServiceMethodResponse(),
       null,
       false,
       false,
       false,
       string.Empty)
    { }
}
