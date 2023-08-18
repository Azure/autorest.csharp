// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Serialization;

namespace AutoRest.CSharp.Common.Input;

internal record InputParameter(
    string Name,
    string NameInRequest,
    string? Description,
    InputType Type,
    RequestLocation Location,
    InputConstant? DefaultValue,
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
        Type: InputPrimitiveType.Object,
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
}
