// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Serialization;

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

    internal InputParameter(
        string name,
        string nameInRequest,
        string? description,
        InputType type,
        RequestLocation location,
        InputConstant? defaultValue,
        VirtualParameter? virtualParameter,
        InputParameter? groupedBy,
        InputOperationParameterKind kind,
        bool isRequired,
        bool isApiVersion,
        bool isResourceParameter,
        bool isContentType,
        bool isEndpoint,
        bool skipUrlEncoding,
        bool explode,
        string? arraySerializationDelimiter,
        string? headerCollectionPrefix,
        SerializationFormat serializationFormat) : this(
            name,
            nameInRequest,
            description,
            type,
            location,
            defaultValue,
            virtualParameter,
            groupedBy,
            kind,
            isRequired,
            isApiVersion,
            isResourceParameter,
            isContentType,
            isEndpoint,
            skipUrlEncoding,
            explode,
            arraySerializationDelimiter,
            headerCollectionPrefix)
    {
        _serializationFormat = serializationFormat;
    }

    private SerializationFormat? _serializationFormat;
    public SerializationFormat SerializationFormat => _serializationFormat ??= GetSerializationFormat(Type, Location);

    private static SerializationFormat GetSerializationFormat(InputType parameterType, RequestLocation requestLocation)
    {
        var affectType = parameterType switch
        {
            InputListType listType => listType.ElementType,
            InputDictionaryType dictionaryType => dictionaryType.ValueType,
            _ => parameterType
        };
        if (affectType is InputPrimitiveType { Kind: InputTypeKind.DateTime })
        {
            if (requestLocation == RequestLocation.Header)
            {
                return SerializationFormat.DateTime_RFC7231;
            }

            if (requestLocation == RequestLocation.Body)
            {
                return SerializationFormat.DateTime_RFC3339;
            }
        }

        return SerializationBuilder.GetSerializationFormat(affectType);
    }
}
