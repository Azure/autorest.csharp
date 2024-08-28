// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input;

internal record InputOperation
{
    public InputOperation(
    string name,
    string? resourceName,
    string? summary,
    string? deprecated,
    string description,
    string? accessibility,
    IReadOnlyList<InputParameter> parameters,
    IReadOnlyList<OperationResponse> responses,
    RequestMethod httpMethod,
    BodyMediaType requestBodyMediaType,
    string uri,
    string path,
    string? externalDocsUrl,
    IReadOnlyList<string>? requestMediaTypes,
    bool bufferResponse,
    OperationLongRunning? longRunning,
    OperationPaging? paging,
    bool generateProtocolMethod,
    bool generateConvenienceMethod,
    string crossLanguageDefinitionId,
    bool keepClientDefaultValue,
    IReadOnlyList<InputOperationExample>? examples = null)
    {
        Name = name;
        SpecName = name;
        ResourceName = resourceName;
        Summary = summary;
        Deprecated = deprecated;
        Description = description;
        Accessibility = accessibility;
        Parameters = parameters;
        Responses = responses;
        HttpMethod = httpMethod;
        RequestBodyMediaType = requestBodyMediaType;
        Uri = uri;
        Path = path;
        ExternalDocsUrl = externalDocsUrl;
        RequestMediaTypes = requestMediaTypes;
        BufferResponse = bufferResponse;
        LongRunning = longRunning;
        Paging = paging;
        GenerateProtocolMethod = generateProtocolMethod;
        GenerateConvenienceMethod = generateConvenienceMethod;
        CrossLanguageDefinitionId = crossLanguageDefinitionId;
        KeepClientDefaultValue = keepClientDefaultValue;
        _examples = examples;
    }

    public InputOperation() : this(
        name: string.Empty,
        resourceName: null,
        summary: null,
        deprecated: null,
        description: string.Empty,
        accessibility: null,
        parameters: Array.Empty<InputParameter>(),
        responses: Array.Empty<OperationResponse>(),
        httpMethod: RequestMethod.Get,
        requestBodyMediaType: BodyMediaType.None,
        uri: string.Empty,
        path: string.Empty,
        externalDocsUrl: null,
        requestMediaTypes: Array.Empty<string>(),
        bufferResponse: false,
        longRunning: null,
        paging: null,
        generateProtocolMethod: true,
        generateConvenienceMethod: false,
        crossLanguageDefinitionId: string.Empty,
        keepClientDefaultValue: false)
    {
        SpecName = string.Empty;
    }

    public static InputOperation RemoveApiVersionParam(InputOperation operation)
    {
        return new InputOperation(
            operation.Name,
            operation.ResourceName,
            operation.Summary,
            operation.Deprecated,
            operation.Description,
            operation.Accessibility,
            operation.Parameters.Where(p => !p.IsApiVersion).ToList(),
            operation.Responses,
            operation.HttpMethod,
            operation.RequestBodyMediaType,
            operation.Uri,
            operation.Path,
            operation.ExternalDocsUrl,
            operation.RequestMediaTypes,
            operation.BufferResponse,
            operation.LongRunning,
            operation.Paging,
            operation.GenerateProtocolMethod,
            operation.GenerateConvenienceMethod,
            operation.CrossLanguageDefinitionId,
            operation.KeepClientDefaultValue)
        {
            SpecName = operation.SpecName
        };
    }

    public string CleanName => Name.IsNullOrEmpty() ? string.Empty : Name.ToCleanName();

    private IReadOnlyList<InputOperationExample>? _examples;
    public IReadOnlyList<InputOperationExample> Examples => _examples ??= EnsureExamples();

    private IReadOnlyList<InputOperationExample> EnsureExamples()
    {
        // see if we need to generate the mock examples
        if (Configuration.ExamplesDirectory != null || Configuration.AzureArm)
        {
            return Array.Empty<InputOperationExample>();
        }

        // build the mock examples
        return ExampleMockValueBuilder.BuildOperationExamples(this);
    }

    public bool IsLongRunning => LongRunning != null;
    public string Name { get; internal set; }
    public string? ResourceName { get; }
    public string? Summary { get; }
    public string? Deprecated { get; }
    public string Description { get; }
    public string? Accessibility { get; }
    public IReadOnlyList<InputParameter> Parameters { get; init; }
    public IReadOnlyList<OperationResponse> Responses { get; }
    public RequestMethod HttpMethod { get; }
    public BodyMediaType RequestBodyMediaType { get; }
    public string Uri { get; init; }
    public string Path { get; }
    public string? ExternalDocsUrl { get; }
    public IReadOnlyList<string>? RequestMediaTypes { get; }
    public bool BufferResponse { get; }
    public OperationLongRunning? LongRunning { get; }
    public OperationPaging? Paging { get; init; }
    public bool GenerateProtocolMethod { get; }
    public bool GenerateConvenienceMethod { get; }
    public string CrossLanguageDefinitionId { get; }
    public bool KeepClientDefaultValue { get; }
    public string? OperationName { get; }
    public string? OperationVersion { get; }
    public string? OperationType { get; }
    public string OperationId => ResourceName is null ? Name : $"{ResourceName}_{Name.FirstCharToUpperCase()}";
    public IReadOnlyList<InputDecoratorInfo> Decorators { get; internal set; } = new List<InputDecoratorInfo>();
    //TODO: Remove this until the SDK nullable is enabled, tracking in https://github.com/Azure/autorest.csharp/issues/4780
    internal string SpecName { get; init; }

    internal bool IsNameChanged { get; init; }
}
