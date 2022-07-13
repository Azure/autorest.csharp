// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using AutoRest.CSharp.Input;
using Azure.Core;

#pragma warning disable SA1649
namespace AutoRest.CSharp.Common.Input
{
    internal record CodeModelOperation(
            string Name,
            string Description,
            string? OperationId,
            string? Accessibility,
            IReadOnlyList<InputOperationParameter> Parameters,
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
            Operation Source)
        : InputOperation(Name, Description, Accessibility, Parameters, Responses, HttpMethod, RequestBodyMediaType, Uri, Path, ExternalDocsUrl, RequestMediaTypes, BufferResponse, LongRunning, Paging);

    internal record CodeModelType(Schema Schema, InputTypeKind Kind, bool IsNullable = false, InputTypeSerializationFormat SerializationFormat = InputTypeSerializationFormat.Default)
        : InputType(Schema.Name, Kind, IsNullable, SerializationFormat);
}
