// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Input;
using Azure.Core;

#pragma warning disable SA1649
namespace AutoRest.CSharp.Common.Input
{
    internal record InputOperation(
        string Name,
        string Description,
        string? Accessibility,
        IReadOnlyList<OperationParameter> Parameters,
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
        Operation Source);

    internal record OperationParameter(
        string Name,
        string NameInRequest,
        string? Description,
        InputType Type,
        RequestLocation Location,
        InputConstant? DefaultValue,
        RequestParameter Source,
        OperationParameter? GroupedBy,
        bool IsConstant,
        bool IsRequired,
        bool IsApiVersion,
        bool IsResourceParameter,
        bool IsContentType,
        bool IsEndpoint,
        bool IsInMethod,
        bool IsInClient,
        bool SkipUrlEncoding,
        bool Explode,
        string? ArraySerializationDelimiter,
        string? HeaderCollectionPrefix);

    internal record OperationResponse(IReadOnlyList<int> StatusCodes, InputType? BodyType, BodyMediaType BodyMediaType);

    internal record OperationLongRunning(OperationFinalStateVia FinalStateVia, CodeModelType? FinalResponseType);

    internal record OperationPaging(string? NextLinkName, string? ItemName)
    {
        public InputOperation? NextLinkOperation => NextLinkOperationRef?.Invoke() ?? null;
        public Func<InputOperation>? NextLinkOperationRef { get; init; }
    }

    internal record InputType(string Name, InputTypeKind Kind, bool IsNullable = false, InputTypeSerializationFormat SerializationFormat = InputTypeSerializationFormat.Default)
    {
        public InputType? ValuesType { get; init; }
        public IReadOnlyList<InputTypeValue>? AllowedValues { get; init; }
    }

    internal record CodeModelType(Schema Schema, InputTypeKind Kind, bool IsNullable = false, InputTypeSerializationFormat SerializationFormat = InputTypeSerializationFormat.Default)
        : InputType(Schema.Name, Kind, IsNullable, SerializationFormat);

    internal record InputConstant(object? Value, InputType Type);

    internal record InputTypeValue(string Name, string Value, string? Description);

    internal static class KnownInputTypes
    {
        public static InputType AzureLocation { get; } = new(nameof(InputTypeKind.AzureLocation), InputTypeKind.AzureLocation);
        public static InputType Boolean { get; } = new(nameof(InputTypeKind.Boolean), InputTypeKind.Boolean);
        public static InputType ByteArray { get; } = new(nameof(InputTypeKind.Bytes), InputTypeKind.Bytes);
        public static InputType DateTime { get; } = new(nameof(InputTypeKind.DateTime), InputTypeKind.DateTime);
        public static InputType Dictionary { get; } = new(nameof(InputTypeKind.Dictionary), InputTypeKind.Dictionary);
        public static InputType ETag { get; } = new(nameof(InputTypeKind.ETag), InputTypeKind.DateTime);
        public static InputType Float32 { get; } = new(nameof(InputTypeKind.Float32), InputTypeKind.Float32);
        public static InputType Float64 { get; } = new(nameof(InputTypeKind.Float64), InputTypeKind.Float64);
        public static InputType Float128 { get; } = new(nameof(InputTypeKind.Float128), InputTypeKind.Float128);
        public static InputType Int32 { get; } = new(nameof(InputTypeKind.Int32), InputTypeKind.Int32);
        public static InputType Int64 { get; } = new(nameof(InputTypeKind.Int64), InputTypeKind.Int64);
        public static InputType List { get; } = new(nameof(InputTypeKind.List), InputTypeKind.List);
        public static InputType ResourceIdentifier { get; } = new(nameof(InputTypeKind.DateTime), InputTypeKind.ResourceIdentifier);
        public static InputType ResourceType { get; } = new(nameof(InputTypeKind.DateTime), InputTypeKind.ResourceType);
        public static InputType Stream { get; } = new(nameof(InputTypeKind.Stream), InputTypeKind.Stream);
        public static InputType String { get; } = new(nameof(InputTypeKind.String), InputTypeKind.String);
        public static InputType Time { get; } = new(nameof(InputTypeKind.Time), InputTypeKind.Time);
        public static InputType Uri { get; } = new(nameof(InputTypeKind.Uri), InputTypeKind.Uri);
    }

    internal enum BodyMediaType
    {
        None,
        Binary,
        Form,
        Json,
        Multipart,
        Text,
        Xml
    }

    internal enum InputTypeKind
    {
        AzureLocation,
        Boolean,
        Bytes,
        DateTime,
        Dictionary,
        Enum,
        ETag,
        ExtensibleEnum,
        Float32,
        Float64,
        Float128,
        Int32,
        Int64,
        List,
        Model,
        Object,
        ResourceIdentifier,
        ResourceType,
        Stream,
        String,
        Time,
        Uri,
    }

    internal enum InputTypeSerializationFormat
    {
        Default,
        Base64Url,
        Byte,
        Date,
        Time,
        DateTime,
        DateTimeUnix,
        DateTimeRFC1123,
        Duration,
        DurationConstant,
        Json,
        Xml
    }
}
