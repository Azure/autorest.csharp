// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Common.Input
{
    internal class CodeModelConverter
    {
        private readonly Dictionary<ServiceRequest, Func<CodeModelOperation>> _operationsCache;
        private readonly Dictionary<RequestParameter, Func<InputParameter>> _parametersCache;

        public CodeModelConverter()
        {
            _operationsCache = new Dictionary<ServiceRequest, Func<CodeModelOperation>>();
            _parametersCache = new Dictionary<RequestParameter, Func<InputParameter>>();
        }

        public InputNamespace CreateNamespace(CodeModel codeModel) => new(Name: codeModel.Language.Default.Name,
                Description: codeModel.Language.Default.Description,
                Clients: CreateClients(codeModel.OperationGroups),
                ApiVersions: GetApiVersions(codeModel),
                Auth: new CodeModelSecurity(Schemes: codeModel.Security.Schemes.OfType<SecurityScheme>().ToList()));

        public static IReadOnlyList<string> GetApiVersions(CodeModel codeModel)
            => codeModel.OperationGroups
                .SelectMany(g => g.Operations.SelectMany(o => o.ApiVersions))
                .Select(v => v.Version)
                .Distinct()
                .OrderBy(v => v)
                .ToList();

        public IReadOnlyList<InputClient> CreateClients(IEnumerable<OperationGroup> operationGroups)
            => operationGroups.Select(CreateClient).ToList();

        public InputClient CreateClient(OperationGroup operationGroup)
        {
            return new(
                Name: operationGroup.Language.Default.Name,
                Key: operationGroup.Key,
                Description: operationGroup.Language.Default.Description,
                Operations: CreateOperations(operationGroup.Operations).Values.ToArray());
        }

        public IReadOnlyDictionary<ServiceRequest, CodeModelOperation> CreateOperations(IEnumerable<Operation> operations)
        {
            var serviceRequests = new List<ServiceRequest>();
            foreach (var operation in operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    if (serviceRequest.Protocol.Http is not HttpRequest httpRequest)
                    {
                        continue;
                    }

                    serviceRequests.Add(serviceRequest);
                    CacheResult(serviceRequest, _operationsCache, () => CreateOperation(serviceRequest, operation, httpRequest));

                    if (operation.RequestMediaTypes != null && !Configuration.Generation1ConvenienceClient)
                    {
                        break;
                    }
                }
            }

            return serviceRequests.ToDictionary(sr => sr, sr => _operationsCache[sr]());
        }

        private CodeModelOperation CreateOperation(ServiceRequest serviceRequest, Operation operation, HttpRequest httpRequest) => new(
            Name: operation.Language.Default.Name,
            Description: operation.Language.Default.Description,
            OperationId: operation.OperationId,
            Accessibility: operation.Accessibility,
            Parameters: CreateOperationParameters(operation.Parameters.Concat(serviceRequest.Parameters).ToList()),
            Responses: operation.Responses.Select(CreateOperationResponse).ToList(),
            HttpMethod: httpRequest.Method.ToCoreRequestMethod(),
            RequestBodyMediaType: GetBodyFormat((httpRequest as HttpWithBodyRequest)?.KnownMediaType),
            Uri: httpRequest.Uri,
            Path: httpRequest.Path,
            ExternalDocsUrl: operation.ExternalDocs?.Url,
            RequestMediaTypes: operation.RequestMediaTypes?.Keys.ToList(),
            BufferResponse: operation.Extensions?.BufferResponse ?? true,
            LongRunning: CreateLongRunning(operation),
            Paging: CreateOperationPaging(operation),
            Source: operation);

        public List<InputParameter> CreateOperationParameters(ICollection<RequestParameter> requestParameters)
        {
            foreach (var parameter in requestParameters)
            {
                CacheResult(parameter, _parametersCache, () => CreateOperationParameter(parameter));
            }

            return requestParameters.Select(rp => _parametersCache[rp]()).ToList();
        }

        public InputParameter CreateOperationParameter(RequestParameter input) => new(
            Name: input.Language.Default.Name,
            NameInRequest: input.Language.Default.SerializedName ?? input.Language.Default.Name,
            Description: input.Language.Default.Description,
            Type: CreateType(input),
            Location: GetRequestLocation(input),
            DefaultValue: GetDefaultValue(input),
            IsRequired: input.IsRequired,
            GroupedBy: input.GroupedBy != null ? _parametersCache[input.GroupedBy]() : null,
            Kind: GetOperationParameterKind(input),
            IsApiVersion: input.Origin == "modelerfour:synthesized/api-version",
            IsResourceParameter: Convert.ToBoolean(input.Extensions.GetValue<string>("x-ms-resource-identifier")),
            IsContentType: input.Origin == "modelerfour:synthesized/content-type",
            IsEndpoint: input.Origin == "modelerfour:synthesized/host",
            ArraySerializationDelimiter: GetArraySerializationDelimiter(input),
            Explode: input.Protocol.Http is HttpParameter { Explode: true },
            SkipUrlEncoding: input.Extensions?.SkipEncoding ?? false,
            HeaderCollectionPrefix: input.Extensions?.HeaderCollectionPrefix,
            VirtualParameter: input is VirtualParameter {Schema: not ConstantSchema} vp ? vp : null
        );

        public static OperationResponse CreateOperationResponse(ServiceResponse response) => new(
            StatusCodes: response.HttpResponse.IntStatusCodes.ToList(),
            BodyType: GetResponseBodyType(response),
            BodyMediaType: GetBodyFormat(response.HttpResponse.KnownMediaType),
            Headers: response.HttpResponse.Headers.ToList()
        );

        private static OperationLongRunning? CreateLongRunning(Operation operation)
        {
            if (!operation.IsLongRunning)
            {
                return null;
            }

            return new OperationLongRunning(
                FinalStateVia: operation.LongRunningFinalStateVia,
                FinalResponse: CreateOperationResponse(operation.LongRunningFinalResponse)
            );
        }

        private OperationPaging? CreateOperationPaging(Operation operation)
        {
            var paging = operation.Language.Default.Paging;
            if (paging == null)
            {
                return null;
            }

            var nextLinkServiceRequest = paging.NextLinkOperation?.Requests.Single();
            if (nextLinkServiceRequest == null || !_operationsCache.TryGetValue(nextLinkServiceRequest, out var nextLinkOperationRef))
            {
                return new OperationPaging(NextLinkName: paging.NextLinkName, ItemName: paging.ItemName);
            }

            return new OperationPaging(NextLinkName: paging.NextLinkName, ItemName: paging.ItemName) { NextLinkOperationRef = nextLinkOperationRef };
        }

        private static InputOperationParameterKind GetOperationParameterKind(RequestParameter input) => input switch
        {
            { Implementation: ImplementationLocation.Client } => InputOperationParameterKind.Client,
            { Schema: ConstantSchema }                        => InputOperationParameterKind.Constant,

            // Grouped and flattened parameters shouldn't be added to methods
            { IsFlattened: true }                             => InputOperationParameterKind.Flattened,
            { GroupedBy: not null }                           => InputOperationParameterKind.Grouped,
            _                                                 => InputOperationParameterKind.Method
        };

        private static string? GetArraySerializationDelimiter(RequestParameter input) => input.In switch
        {
            HttpParameterIn.Query or HttpParameterIn.Header => (input.Protocol.Http as HttpParameter)?.Style switch
            {
                SerializationStyle.PipeDelimited => "|",
                SerializationStyle.TabDelimited => "\t",
                SerializationStyle.SpaceDelimited => " ",
                null or SerializationStyle.Form or SerializationStyle.Simple => input.Schema switch
                {
                    ArraySchema or ConstantSchema { ValueType: ArraySchema } => ",",
                    _ => null
                },
                _ => throw new ArgumentOutOfRangeException()
            },
            _ => null
        };

        private static BodyMediaType GetBodyFormat(KnownMediaType? knownMediaType) => knownMediaType switch
        {
            KnownMediaType.Binary => BodyMediaType.Binary,
            KnownMediaType.Form => BodyMediaType.Form,
            KnownMediaType.Json => BodyMediaType.Json,
            KnownMediaType.Multipart => BodyMediaType.Multipart,
            KnownMediaType.Text => BodyMediaType.Text,
            KnownMediaType.Xml => BodyMediaType.Xml,
            _ => BodyMediaType.None
        };

        private static InputType? GetResponseBodyType(ServiceResponse response) => response switch
        {
            { HttpResponse.KnownMediaType: KnownMediaType.Text } => KnownInputTypes.String,
            BinaryResponse => KnownInputTypes.Stream,
            SchemaResponse schemaResponse => CreateType(schemaResponse.Schema, schemaResponse.IsNullable),
            _ => null
        };

        public static InputType CreateType(RequestParameter requestParameter)
            => CreateType(requestParameter.Schema, requestParameter.Extensions?.Format, requestParameter.IsNullable || !requestParameter.IsRequired);

        private static InputType CreateType(Schema schema, bool isNullable)
            => CreateType(schema, schema.Extensions?.Format, isNullable);

        private static InputType CreateType(Schema schema, string? format, bool isNullable)
            => CreateType(schema, format) with {IsNullable = isNullable};

        private static InputType CreateType(Schema schema, string? format) => schema switch
        {
            ArraySchema array           => CreateType(schema, InputTypeKind.List, CreateType(array.ElementType, array.NullableItems ?? false)),
            DictionarySchema dictionary => CreateType(schema, InputTypeKind.Dictionary, CreateType(dictionary.ElementType, dictionary.NullableItems ?? false)),

            BinarySchema => KnownInputTypes.Stream,

            ByteArraySchema { Format: ByteArraySchemaFormat.Base64url } => KnownInputTypes.ByteArray with { SerializationFormat = InputTypeSerializationFormat.Base64Url },
            ByteArraySchema { Format: ByteArraySchemaFormat.Byte }      => KnownInputTypes.ByteArray with { SerializationFormat = InputTypeSerializationFormat.Byte },
            ByteArraySchema                                             => KnownInputTypes.ByteArray,

            DateSchema                                                      => KnownInputTypes.DateTime with { SerializationFormat = InputTypeSerializationFormat.Date },
            DateTimeSchema { Format: DateTimeSchemaFormat.DateTime }        => KnownInputTypes.DateTime with { SerializationFormat = InputTypeSerializationFormat.DateTime },
            DateTimeSchema { Format: DateTimeSchemaFormat.DateTimeRfc1123 } => KnownInputTypes.DateTime with { SerializationFormat = InputTypeSerializationFormat.DateTimeRFC1123 },
            DateTimeSchema                                                  => KnownInputTypes.DateTime with { SerializationFormat = InputTypeSerializationFormat.Default },
            UnixTimeSchema                                                  => KnownInputTypes.DateTime with { SerializationFormat = InputTypeSerializationFormat.DateTimeUnix },

            TimeSchema                                               => KnownInputTypes.Time with { SerializationFormat = InputTypeSerializationFormat.Time },
            DurationSchema when format == XMsFormat.DurationConstant => KnownInputTypes.Time with { SerializationFormat = InputTypeSerializationFormat.DurationConstant },
            DurationSchema                                           => KnownInputTypes.Time with { SerializationFormat = InputTypeSerializationFormat.Duration },

            NumberSchema { Type: AllSchemaTypes.Number, Precision: 32 } => KnownInputTypes.Float32,
            NumberSchema { Type: AllSchemaTypes.Number, Precision: 128 } => KnownInputTypes.Float128,
            NumberSchema { Type: AllSchemaTypes.Number } => KnownInputTypes.Float64,
            NumberSchema { Type: AllSchemaTypes.Integer, Precision: 64 } => KnownInputTypes.Int64,
            NumberSchema { Type: AllSchemaTypes.Integer } => KnownInputTypes.Int32,

            ChoiceSchema choiceSchema =>       CreateEnumType(choiceSchema),
            SealedChoiceSchema choiceSchema => CreateEnumType(choiceSchema),

            { Type: AllSchemaTypes.String } when format == XMsFormat.DurationConstant => KnownInputTypes.Time with { SerializationFormat = InputTypeSerializationFormat.DurationConstant },
            { Type: AllSchemaTypes.String } when format == XMsFormat.ArmId            => KnownInputTypes.ResourceIdentifier,
            { Type: AllSchemaTypes.String } when format == XMsFormat.AzureLocation    => KnownInputTypes.AzureLocation,
            { Type: AllSchemaTypes.String } when format == XMsFormat.ETag             => KnownInputTypes.ETag,
            { Type: AllSchemaTypes.String } when format == XMsFormat.ResourceType     => KnownInputTypes.ResourceType,

            ConstantSchema constantSchema => CreateType(constantSchema.ValueType, format),

            CredentialSchema => KnownInputTypes.String,
            { Type: AllSchemaTypes.String } => KnownInputTypes.String,
            { Type: AllSchemaTypes.Boolean } => KnownInputTypes.Boolean,
            { Type: AllSchemaTypes.Uri } => KnownInputTypes.Uri,
            _ => new CodeModelType(schema, InputTypeKind.Object)
        };

        private static InputType CreateType(Schema schema, InputTypeKind kind, InputType valuesType)
            => Configuration.Generation1ConvenienceClient || Configuration.AzureArm
                ? new CodeModelType(schema, kind) { ValuesType = valuesType }
                : new InputType(schema.Name, kind) { ValuesType = valuesType };

        private static InputType CreateEnumType(ChoiceSchema choiceSchema)
            => Configuration.Generation1ConvenienceClient || Configuration.AzureArm
                ? new CodeModelType(choiceSchema, InputTypeKind.Object)
                : CreateEnumType(choiceSchema.Name, CreateType(choiceSchema.ChoiceType, choiceSchema.Extensions?.Format), choiceSchema.Choices, InputTypeKind.ExtensibleEnum);

        private static InputType CreateEnumType(SealedChoiceSchema choiceSchema)
            => Configuration.Generation1ConvenienceClient || Configuration.AzureArm
                ? new CodeModelType(choiceSchema, InputTypeKind.Object)
                : CreateEnumType(choiceSchema.Name, CreateType(choiceSchema.ChoiceType, choiceSchema.Extensions?.Format), choiceSchema.Choices, InputTypeKind.Enum);

        private static InputType CreateEnumType(string name, InputType choiceType, IEnumerable<ChoiceValue> choices, InputTypeKind kind) => new(Name: name, Kind: kind)
        {
            ValuesType = choiceType,
            AllowedValues = choices.Select(CreateEnumValue).ToList()
        };

        private static InputTypeValue CreateEnumValue(ChoiceValue choiceValue) => new(
            Name: choiceValue.Language.Default.Name,
            Description: choiceValue.Language.Default.Description,
            Value: choiceValue.Value
        );

        private static RequestLocation GetRequestLocation(RequestParameter requestParameter) => requestParameter.In switch
        {
            HttpParameterIn.Uri => RequestLocation.Uri,
            HttpParameterIn.Path => RequestLocation.Path,
            HttpParameterIn.Query => RequestLocation.Query,
            HttpParameterIn.Header => RequestLocation.Header,
            HttpParameterIn.Body => RequestLocation.Body,
            _ => RequestLocation.None
        };

        private static InputConstant? GetDefaultValue(RequestParameter parameter)
        {
            if (parameter.ClientDefaultValue != null)
            {
                return new InputConstant(Value: parameter.ClientDefaultValue, Type: CreateType(parameter.Schema, parameter.IsNullable));
            }

            if (parameter.Schema is ConstantSchema constantSchema)
            {
                return new InputConstant(Value: constantSchema.Value.Value, Type: CreateType(constantSchema.ValueType, constantSchema.Value.Value == null));
            }

            return null;
        }

        private static void CacheResult<TSource, TResult>(TSource source, IDictionary<TSource, Func<TResult>> cache, Func<TResult> create) where TSource : notnull
        {
            if (cache.ContainsKey(source))
            {
                return;
            }

            TResult? value = default;
            cache[source] = () => value ??= create();
        }
    }
}
