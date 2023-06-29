// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Utilities;
using Azure;
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
    bool GenerateConvenienceMethod)
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
        GenerateConvenienceMethod: false)
    { }

    private string? _cleanName;
    public string CleanName
    {
        get
        {
            if (_cleanName == null)
            {
                _cleanName = Name.IsNullOrEmpty() ? string.Empty : Name.ToCleanName();
            }

            return _cleanName;
        }
    }

    public bool IsKeepClientDefaultValue { get; set; } = Configuration.MethodsToKeepClientDefaultValue.Contains(Name);
}
