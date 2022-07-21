// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Input;
using Azure.Core;

#pragma warning disable SA1649
namespace AutoRest.CSharp.Common.Input
{
    internal record InputNamespace(string Name, string Description, IReadOnlyList<string> ApiVersions, IReadOnlyList<InputModel> Models, IReadOnlyList<InputClient> Clients, InputAuth Auth)
    {
        public InputNamespace() : this(Name: string.Empty, Description: string.Empty, ApiVersions: new List<string>(), Models: new List<InputModel>(), Clients: new List<InputClient>(), Auth: new InputAuth()) {}
    }

    internal record InputAuth();

    internal record InputClient(string Name, string Description, IReadOnlyList<InputOperation> Operations)
    {
        private readonly string? _key;

        public string Key
        {
            get => _key ?? Name;
            init => _key = value;
        }

        public InputClient() : this(string.Empty, string.Empty, new List<InputOperation>()) { }
    }

    internal record InputOperation(
        string Name,
        string? Summary,
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
        OperationPaging? Paging)
    {
        public InputOperation() : this(
            Name: string.Empty,
            Summary: null,
            Description: string.Empty,
            Accessibility: null,
            Parameters: new List<InputParameter>(),
            Responses: new List<OperationResponse>(),
            HttpMethod: RequestMethod.Get,
            RequestBodyMediaType: BodyMediaType.None,
            Uri: string.Empty,
            Path: string.Empty,
            ExternalDocsUrl: null,
            RequestMediaTypes: new List<string>(),
            BufferResponse: false,
            LongRunning: null,
            Paging: null)
        { }
    }

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
            Type: new InputType(InputTypeKind.Object),
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
        public OperationResponse() : this(StatusCodes: new List<int>(), BodyType: null, BodyMediaType: BodyMediaType.None, Headers: new List<HttpResponseHeader>()) { }
    }

    internal record OperationLongRunning(OperationFinalStateVia FinalStateVia, OperationResponse FinalResponse);

    internal record OperationPaging(string? NextLinkName, string? ItemName)
    {
        public InputOperation? NextLinkOperation => NextLinkOperationRef?.Invoke() ?? null;
        public Func<InputOperation>? NextLinkOperationRef { get; init; }
    }

    internal record InputType(InputTypeKind Kind, bool IsNullable = false, InputTypeSerializationFormat SerializationFormat = InputTypeSerializationFormat.Default)
    {
        private readonly string? _name;
        public InputType? ValuesType { get; init; }
        public IReadOnlyList<InputTypeValue>? AllowedValues { get; init; }
        public InputModel? Model { get; init; }

        public string Name
        {
            get => _name ?? Model?.Name ?? Kind.ToString();
            init => _name = value;
        }

        public InputType() : this(InputTypeKind.Object) { }

        public InputType(string name, InputTypeKind kind, bool isNullable, InputTypeSerializationFormat serializationFormat) : this(kind, isNullable, serializationFormat)
        {
            Name = name;
        }
    }

    internal record InputModel(string Name, string? Namespace, string? Accessibility, IReadOnlyList<InputModelProperty> Properties, InputModel? BaseModel, IReadOnlyList<InputModel> DerivedModels)
    {
        public InputModel() : this(string.Empty, null, null, new List<InputModelProperty>(), null, new List<InputModel>()) { }

        public IEnumerable<InputModel> GetSelfAndBaseModels() => EnumerateBase(this);

        public IEnumerable<InputModel> GetAllBaseModels() => EnumerateBase(BaseModel);

        private static IEnumerable<InputModel> EnumerateBase(InputModel? model)
        {
            while (model != null)
            {
                yield return model;
                model = model.BaseModel;
            }
        }
    }

    internal record InputModelProperty(string Name, string SerializedName, string Description, InputType Type, bool IsRequired, bool IsReadOnly, bool IsDiscriminator)
    {
        public InputModelProperty() : this(string.Empty, string.Empty, string.Empty, new InputType(), false, false, false) { }
    }

    internal record InputConstant(object? Value, InputType Type);

    internal record InputTypeValue(string Name, string Value, string? Description);

    internal static class KnownInputTypes
    {
        public static InputType AzureLocation { get; } = new(InputTypeKind.AzureLocation);
        public static InputType Boolean { get; } = new(InputTypeKind.Boolean);
        public static InputType ByteArray { get; } = new(InputTypeKind.Bytes);
        public static InputType DateTime { get; } = new(InputTypeKind.DateTime);
        public static InputType Dictionary { get; } = new(InputTypeKind.Dictionary);
        public static InputType ETag { get; } = new(InputTypeKind.ETag);
        public static InputType Float32 { get; } = new(InputTypeKind.Float32);
        public static InputType Float64 { get; } = new(InputTypeKind.Float64);
        public static InputType Float128 { get; } = new(InputTypeKind.Float128);
        public static InputType Guid { get; } = new(InputTypeKind.Guid);
        public static InputType Int32 { get; } = new(InputTypeKind.Int32);
        public static InputType Int64 { get; } = new(InputTypeKind.Int64);
        public static InputType List { get; } = new(InputTypeKind.List);
        public static InputType ResourceIdentifier { get; } = new(InputTypeKind.ResourceIdentifier);
        public static InputType ResourceType { get; } = new(InputTypeKind.ResourceType);
        public static InputType Stream { get; } = new(InputTypeKind.Stream);
        public static InputType String { get; } = new(InputTypeKind.String);
        public static InputType Time { get; } = new(InputTypeKind.Time);
        public static InputType Uri { get; } = new(InputTypeKind.Uri);
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
        Guid,
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
