// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Utilities;
using Azure.Core;

namespace AutoRest.CSharp.Common.Input
{
    internal static class CodeModelConverter
    {
        public static IReadOnlyDictionary<ServiceRequest, InputOperation> CreateOperations(IEnumerable<Operation> operations)
        {
            var inputOperations = new Dictionary<ServiceRequest, Func<InputOperation>>();

            foreach (var operation in operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    if (serviceRequest.Protocol.Http is not HttpRequest httpRequest)
                    {
                        continue;
                    }

                    inputOperations[serviceRequest] = CacheResult(() => CreateOperation(serviceRequest, operation, httpRequest, inputOperations));

                    if (operation.RequestMediaTypes != null && !Configuration.Generation1ConvenienceClient)
                    {
                        break;
                    }
                }
            }

            return inputOperations.ToDictionary(kvp => kvp.Key, kvp => kvp.Value());
        }

        private static InputOperation CreateOperation(ServiceRequest serviceRequest, Operation operation, HttpRequest httpRequest, IReadOnlyDictionary<ServiceRequest, Func<InputOperation>> operationsCache)
        {
            return new InputOperation(
                Name: operation.Language.Default.Name,
                Description: operation.Language.Default.Description,
                Accessibility: operation.Accessibility,
                Parameters: CreateOperationParameters(operation.Parameters.Concat(serviceRequest.Parameters).ToList()),
                Responses: operation.Responses.Select(CreateOperationResponse).ToList(),
                HttpMethod: httpRequest.Method.ToCoreRequestMethod() ?? RequestMethod.Get,
                RequestBodyMediaType: GetBodyFormat((httpRequest as HttpWithBodyRequest)?.KnownMediaType),
                Uri: httpRequest.Uri,
                Path: httpRequest.Path,
                ExternalDocsUrl: operation.ExternalDocs?.Url,
                RequestMediaTypes: operation.RequestMediaTypes?.Keys.ToList(),
                BufferResponse: operation.Extensions?.BufferResponse ?? true,
                LongRunning: CreateLongRunning(operation),
                Paging: CreateOperationPaging(operation, operationsCache),
                Source: operation);
        }

        public static List<OperationParameter> CreateOperationParameters(ICollection<RequestParameter> requestParameters)
        {
            var parametersCache = new Dictionary<RequestParameter, Func<OperationParameter>>();
            foreach (var parameter in requestParameters)
            {
                parametersCache.Add(parameter, CacheResult(() => CreateOperationParameter(parameter, parametersCache)));
            }

            return requestParameters.Select(rp => parametersCache[rp]()).ToList();
        }

        public static OperationParameter CreateOperationParameter(RequestParameter input, IReadOnlyDictionary<RequestParameter, Func<OperationParameter>> parametersCache) => new(
            Name: input.Language.Default.Name,
            NameInRequest: input.Language.Default.SerializedName ?? input.Language.Default.Name,
            Description: input.Language.Default.Description,
            Type: CreateType(input.Schema, input.IsNullable || !input.IsRequired),
            Location: GetRequestLocation(input),
            DefaultValue: GetDefaultValue(input),
            IsConstant: input.Schema is ConstantSchema,
            IsRequired: input.IsRequired,
            GroupedBy: input.GroupedBy != null ? parametersCache[input.GroupedBy]() : null,
            IsApiVersion: input.Origin == "modelerfour:synthesized/api-version",
            IsResourceParameter: Convert.ToBoolean(input.Extensions.GetValue<string>("x-ms-resource-identifier")),
            IsContentType: input.Origin == "modelerfour:synthesized/content-type",
            IsEndpoint: input.Origin == "modelerfour:synthesized/host",
            IsInMethod: input.Implementation == ImplementationLocation.Method && input.Schema is not ConstantSchema && !input.IsFlattened && input.GroupedBy == null,
            IsInClient: input.Implementation == ImplementationLocation.Client,
            ArraySerializationDelimiter: GetArraySerializationDelimiter(input),
            Explode: input.Protocol.Http is HttpParameter { Explode: true },
            SkipUrlEncoding: input.Extensions?.SkipEncoding ?? false,
            HeaderCollectionPrefix: input.Extensions?.HeaderCollectionPrefix,
            Source: input
        );

        public static OperationResponse CreateOperationResponse(ServiceResponse response) => new(
            StatusCodes: response.HttpResponse.IntStatusCodes.ToList(),
            BodyType: GetResponseBodyType(response),
            BodyMediaType: GetBodyFormat(response.HttpResponse.KnownMediaType)
        );

        private static OperationLongRunning? CreateLongRunning(Operation operation)
        {
            if (!operation.IsLongRunning)
            {
                return null;
            }

            var responseSchema = operation.LongRunningFinalResponse.ResponseSchema;

            return new OperationLongRunning(
                FinalStateVia: operation.LongRunningFinalStateVia,
                FinalResponseType: responseSchema != null ? new CodeModelType(responseSchema, InputTypeKind.Object) : null
            );
        }

        private static OperationPaging? CreateOperationPaging(Operation operation, IReadOnlyDictionary<ServiceRequest, Func<InputOperation>> operationsCache)
        {
            var paging = operation.Language.Default.Paging;
            if (paging == null)
            {
                return null;
            }

            var nextLinkServiceRequest = paging.NextLinkOperation?.Requests.Single();
            if (nextLinkServiceRequest == null || !operationsCache.TryGetValue(nextLinkServiceRequest, out var nextLinkOperationRef))
            {
                return new OperationPaging(NextLinkName: paging.NextLinkName, ItemName: paging.ItemName);
            }

            return new OperationPaging(NextLinkName: paging.NextLinkName, ItemName: paging.ItemName) { NextLinkOperationRef = nextLinkOperationRef };
        }

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

        private static InputType CreateType(Schema schema, bool isNullable)
            => CreateType(schema) with {IsNullable = isNullable};

        private static InputType CreateType(Schema schema) => schema switch
        {
            ArraySchema array           => new(schema.Name, InputTypeKind.List) { ValuesType = CreateType(array.ElementType, array.NullableItems ?? false) },
            DictionarySchema dictionary => new(schema.Name, InputTypeKind.Dictionary) { ValuesType = CreateType(dictionary.ElementType, dictionary.NullableItems ?? false) },

            BinarySchema => KnownInputTypes.Stream,

            ByteArraySchema { Format: ByteArraySchemaFormat.Base64url } => KnownInputTypes.ByteArray with { SerializationFormat = InputTypeSerializationFormat.Base64Url },
            ByteArraySchema { Format: ByteArraySchemaFormat.Byte }      => KnownInputTypes.ByteArray with { SerializationFormat = InputTypeSerializationFormat.Byte },
            ByteArraySchema                                             => KnownInputTypes.ByteArray,

            DateSchema                                                      => KnownInputTypes.DateTime with { SerializationFormat = InputTypeSerializationFormat.Date },
            DateTimeSchema { Format: DateTimeSchemaFormat.DateTime }        => KnownInputTypes.DateTime with { SerializationFormat = InputTypeSerializationFormat.DateTime },
            DateTimeSchema { Format: DateTimeSchemaFormat.DateTimeRfc1123 } => KnownInputTypes.DateTime with { SerializationFormat = InputTypeSerializationFormat.DateTimeRFC1123 },
            DateTimeSchema                                                  => KnownInputTypes.DateTime with { SerializationFormat = InputTypeSerializationFormat.Default },
            UnixTimeSchema                                                  => KnownInputTypes.DateTime with { SerializationFormat = InputTypeSerializationFormat.DateTimeUnix },

            TimeSchema                                                       => KnownInputTypes.Time with { SerializationFormat = InputTypeSerializationFormat.Time },
            DurationSchema { Extensions.Format: XMsFormat.DurationConstant } => KnownInputTypes.Time with { SerializationFormat = InputTypeSerializationFormat.DurationConstant },
            DurationSchema                                                   => KnownInputTypes.Time with { SerializationFormat = InputTypeSerializationFormat.Duration },

            NumberSchema { Type: AllSchemaTypes.Number, Precision: 32 } => KnownInputTypes.Float32,
            NumberSchema { Type: AllSchemaTypes.Number, Precision: 128 } => KnownInputTypes.Float128,
            NumberSchema { Type: AllSchemaTypes.Number } => KnownInputTypes.Float64,
            NumberSchema { Type: AllSchemaTypes.Integer, Precision: 64 } => KnownInputTypes.Int64,
            NumberSchema { Type: AllSchemaTypes.Integer } => KnownInputTypes.Int32,

            ChoiceSchema choiceSchema =>       CreateEnumType(choiceSchema),
            SealedChoiceSchema choiceSchema => CreateEnumType(choiceSchema),

            { Type: AllSchemaTypes.String, Extensions.Format: XMsFormat.DurationConstant } => KnownInputTypes.Time with { SerializationFormat = InputTypeSerializationFormat.DurationConstant },
            { Type: AllSchemaTypes.String, Extensions.Format: XMsFormat.ArmId }         => KnownInputTypes.ResourceIdentifier,
            { Type: AllSchemaTypes.String, Extensions.Format: XMsFormat.AzureLocation } => KnownInputTypes.AzureLocation,
            { Type: AllSchemaTypes.String, Extensions.Format: XMsFormat.ETag }          => KnownInputTypes.ETag,
            { Type: AllSchemaTypes.String, Extensions.Format: XMsFormat.ResourceType }  => KnownInputTypes.ResourceType,

            ConstantSchema constantSchema => CreateType(constantSchema.ValueType),

            CredentialSchema => KnownInputTypes.String,
            { Type: AllSchemaTypes.String } => KnownInputTypes.String,
            { Type: AllSchemaTypes.Boolean } => KnownInputTypes.Boolean,
            { Type: AllSchemaTypes.Uri } => KnownInputTypes.Uri,
            _ => new CodeModelType(schema, InputTypeKind.Object)
        };

        private static InputType CreateEnumType(ChoiceSchema choiceSchema) =>
            Configuration.Generation1ConvenienceClient || Configuration.AzureArm
                ? new CodeModelType(choiceSchema, InputTypeKind.Object)
                : CreateEnumType(choiceSchema.Name, CreateType(choiceSchema.ChoiceType), choiceSchema.Choices, InputTypeKind.ExtensibleEnum);

        private static InputType CreateEnumType(SealedChoiceSchema choiceSchema) =>
            Configuration.Generation1ConvenienceClient || Configuration.AzureArm
                ? new CodeModelType(choiceSchema, InputTypeKind.Object)
                : CreateEnumType(choiceSchema.Name, CreateType(choiceSchema.ChoiceType), choiceSchema.Choices, InputTypeKind.Enum);

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

        private static Func<T> CacheResult<T>(Func<T> create)
        {
            T? value = default;
            return () => value ??= create();
        }
    }
}
