﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Input;

namespace AutoRest.CSharp.Common.Input;

internal record InputParameter(
    string Name,
    string NameInRequest,
    string? Description,
    InputType Type,
    RequestLocation Location,
    InputConstant? DefaultValue,
    VirtualParameter? VirtualParameter,
    InputParameter? GroupedBy,
    InputOperationParameterKind Kind,
    bool IsRequired,
    bool IsApiVersion,
    bool IsResourceParameter,
    bool IsContentType,
    bool IsEndpoint,
    bool SkipUrlEncoding,
    bool Explode,
    string? ArraySerializationDelimiter,
    string? HeaderCollectionPrefix)
{
    public InputParameter() : this(
        Name: string.Empty,
        NameInRequest: string.Empty,
        Description: null,
        Type: InputPrimitiveType.Object,
        Location: RequestLocation.None,
        DefaultValue: null,
        VirtualParameter: null,
        GroupedBy: null,
        Kind: InputOperationParameterKind.Method,
        IsRequired: false,
        IsApiVersion: false,
        IsResourceParameter: false,
        IsContentType: false,
        IsEndpoint: false,
        SkipUrlEncoding: false,
        Explode: false,
        ArraySerializationDelimiter: null,
        HeaderCollectionPrefix: null)
    { }

    public string Name { get; internal set; } = Name;
    public string NameInRequest { get; internal set; } = NameInRequest;
    public bool IsRequired { get; internal set; } = IsRequired;
}
