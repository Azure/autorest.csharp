// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Input;
using Azure.Core;

#pragma warning disable SA1649
namespace AutoRest.CSharp.Common.Input
{
    internal record InputNamespace(string Name, string Description, IReadOnlyList<string> ApiVersions, IReadOnlyList<InputClient> Clients, InputAuth Auth)
    {
        public InputNamespace() : this(Name: string.Empty, Description: string.Empty, ApiVersions: Array.Empty<string>(), Clients: Array.Empty<InputClient>(), Auth: new InputAuth()) {}
    }

    internal record InputAuth();

    internal record InputClient(string Name, string Key, string Description, IReadOnlyList<InputOperation> Operations);

    internal record InputOperation(
        string Name,
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
        OperationPaging? Paging);

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
            Type: new InputType("", InputTypeKind.Object),
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
    }

    internal record OperationResponse(IReadOnlyList<int> StatusCodes, InputType? BodyType, BodyMediaType BodyMediaType, IReadOnlyList<HttpResponseHeader> Headers)
    {
        public OperationResponse() : this(StatusCodes: Array.Empty<int>(), BodyType: null, BodyMediaType: BodyMediaType.None, Headers: Array.Empty<HttpResponseHeader>()) { }
    }

    internal record OperationLongRunning(OperationFinalStateVia FinalStateVia, OperationResponse FinalResponse);

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

    internal record InputConstant(object? Value, InputType Type);

    internal record InputTypeValue(string Name, string Value, string? Description);

    internal static class KnownInputTypes
    {
        public static InputType AzureLocation { get; } = new(nameof(InputTypeKind.AzureLocation), InputTypeKind.AzureLocation);
        public static InputType Boolean { get; } = new(nameof(InputTypeKind.Boolean), InputTypeKind.Boolean);
        public static InputType ByteArray { get; } = new(nameof(InputTypeKind.Bytes), InputTypeKind.Bytes);
        public static InputType DateTime { get; } = new(nameof(InputTypeKind.DateTime), InputTypeKind.DateTime);
        public static InputType Dictionary { get; } = new(nameof(InputTypeKind.Dictionary), InputTypeKind.Dictionary);
        public static InputType ETag { get; } = new(nameof(InputTypeKind.ETag), InputTypeKind.ETag);
        public static InputType Float32 { get; } = new(nameof(InputTypeKind.Float32), InputTypeKind.Float32);
        public static InputType Float64 { get; } = new(nameof(InputTypeKind.Float64), InputTypeKind.Float64);
        public static InputType Float128 { get; } = new(nameof(InputTypeKind.Float128), InputTypeKind.Float128);
        public static InputType Int32 { get; } = new(nameof(InputTypeKind.Int32), InputTypeKind.Int32);
        public static InputType Int64 { get; } = new(nameof(InputTypeKind.Int64), InputTypeKind.Int64);
        public static InputType List { get; } = new(nameof(InputTypeKind.List), InputTypeKind.List);
        public static InputType ResourceIdentifier { get; } = new(nameof(InputTypeKind.ResourceIdentifier), InputTypeKind.ResourceIdentifier);
        public static InputType ResourceType { get; } = new(nameof(InputTypeKind.ResourceType), InputTypeKind.ResourceType);
        public static InputType Stream { get; } = new(nameof(InputTypeKind.Stream), InputTypeKind.Stream);
        public static InputType String { get; } = new(nameof(InputTypeKind.String), InputTypeKind.String);
        public static InputType Time { get; } = new(nameof(InputTypeKind.Time), InputTypeKind.Time);
        public static InputType Uri { get; } = new(nameof(InputTypeKind.Uri), InputTypeKind.Uri);
    }

    internal enum InputOperationParameterKind
    {
        Method = 0,
        Client = 1,
        Constant = 2,
        Flattened = 3,
        Grouped = 4,
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
