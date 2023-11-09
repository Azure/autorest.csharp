// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input;

internal record InputOperation(
    string Name,
    string? ResourceName,
    string? Summary,
    string? Deprecated,
    string Description,
    string? Accessibility,
    IReadOnlyList<InputParameter> Parameters,
    IReadOnlyList<OperationResponse> Responses,
    IReadOnlyList<InputOperationExample> Examples,
    RequestMethod HttpMethod,
    BodyMediaType RequestBodyMediaType,
    string Uri,
    string Path,
    string? ExternalDocsUrl,
    IReadOnlyList<string>? RequestMediaTypes,
    bool BufferResponse,
    OperationLongRunning? LongRunning,
    OperationPaging? Paging,
    bool GenerateProtocolMethod,
    bool GenerateConvenienceMethod,
    bool KeepClientDefaultValue)
{
    public InputOperation() : this(
        Name: string.Empty,
        ResourceName: null,
        Summary: null,
        Deprecated: null,
        Description: string.Empty,
        Accessibility: null,
        Parameters: Array.Empty<InputParameter>(),
        Responses: Array.Empty<OperationResponse>(),
        Examples: Array.Empty<InputOperationExample>(),
        HttpMethod: RequestMethod.Get,
        RequestBodyMediaType: BodyMediaType.None,
        Uri: string.Empty,
        Path: string.Empty,
        ExternalDocsUrl: null,
        RequestMediaTypes: Array.Empty<string>(),
        BufferResponse: false,
        LongRunning: null,
        Paging: null,
        GenerateProtocolMethod: true,
        GenerateConvenienceMethod: false,
        KeepClientDefaultValue: false)
    { }

    public string CleanName => Name.IsNullOrEmpty() ? string.Empty : Name.ToCleanName();
}
