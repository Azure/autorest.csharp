// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace AutoRest.CSharp.Common.Input;

internal record InputParameter(
    string Name,
    string NameInRequest,
    string? Description,
    InputType Type,
    RequestLocation Location,
    InputConstant? DefaultValue,
    // TODO: This should be removed, tracking it in https://github.com/Azure/autorest.csharp/issues/4779
    InputParameter? GroupedBy,
    InputModelProperty? FlattenedBodyProperty,
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
        Type: InputPrimitiveType.Unknown,
        Location: RequestLocation.None,
        DefaultValue: null,
        FlattenedBodyProperty: null,
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
    public bool IsRequired { get; internal set; } = IsRequired;
    public InputType Type { get; internal set; } = Type;
    public InputOperationParameterKind Kind { get; internal set; } = Kind;
    public IReadOnlyList<InputDecoratorInfo> Decorators { get; internal set; } = new List<InputDecoratorInfo>();
}
