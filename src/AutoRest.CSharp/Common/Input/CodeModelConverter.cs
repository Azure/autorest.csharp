// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Utilities;
using Humanizer;

namespace AutoRest.CSharp.Common.Input
{
    internal class CodeModelConverter
    {
        private readonly Dictionary<ServiceRequest, Func<InputOperation>> _operationsCache;
        private readonly Dictionary<RequestParameter, Func<InputParameter>> _parametersCache;
        private readonly Dictionary<ObjectSchema, InputModelType> _modelsCache;
        private readonly Dictionary<ObjectSchema, List<InputModelProperty>> _modelPropertiesCache;
        private readonly Dictionary<ObjectSchema, List<InputModelType>> _derivedModelsCache;
        private readonly Dictionary<InputOperation, Operation> _inputOperationToOperationMap;

        public CodeModelConverter()
        {
            _operationsCache = new Dictionary<ServiceRequest, Func<InputOperation>>();
            _parametersCache = new Dictionary<RequestParameter, Func<InputParameter>>();
            _modelsCache = new Dictionary<ObjectSchema, InputModelType>();
            _modelPropertiesCache = new Dictionary<ObjectSchema, List<InputModelProperty>>();
            _derivedModelsCache = new Dictionary<ObjectSchema, List<InputModelType>>();
            _inputOperationToOperationMap = new Dictionary<InputOperation, Operation>();
        }

        public IReadOnlyDictionary<InputOperation, Operation> InputOperationToOperationMap => _inputOperationToOperationMap;

        public InputNamespace CreateNamespace(CodeModel codeModel)
        {
            var enums = CreateEnums(codeModel.Schemas.Choices, codeModel.Schemas.SealedChoices);
            var models = CreateModels(codeModel.Schemas.Objects);
            var clients = CreateClients(codeModel.OperationGroups);

            return new(Name: codeModel.Language.Default.Name,
                Description: codeModel.Language.Default.Description,
                Clients: clients,
                Models: models,
                Enums: enums,
                ApiVersions: GetApiVersions(codeModel),
                Auth: new CodeModelSecurity(Schemes: codeModel.Security.Schemes.OfType<SecurityScheme>().ToList()));
        }

        public IReadOnlyList<InputClient> CreateClients(IEnumerable<OperationGroup> operationGroups)
            => operationGroups.Select(CreateClient).ToList();

        public InputClient CreateClient(OperationGroup operationGroup)
            => new(
                Name: operationGroup.Language.Default.Name,
                Description: operationGroup.Language.Default.Description,
                Operations: CreateOperations(operationGroup.Operations).Values.ToArray())
            {
                Key = operationGroup.Key,
            };

        public IReadOnlyDictionary<ServiceRequest, InputOperation> CreateOperations(IEnumerable<Operation> operations)
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

        private InputOperation CreateOperation(ServiceRequest serviceRequest, Operation operation, HttpRequest httpRequest)
        {
            var inputOperation = new InputOperation(
                Name: operation.Language.Default.Name,
                Summary: operation.Language.Default.Summary,
                Description: operation.Language.Default.Description,
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
                Paging: CreateOperationPaging(operation));

            _inputOperationToOperationMap[inputOperation] = operation;
            return inputOperation;
        }

        public List<InputParameter> CreateOperationParameters(IReadOnlyCollection<RequestParameter> requestParameters)
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

        public OperationResponse CreateOperationResponse(ServiceResponse response) => new(
            StatusCodes: response.HttpResponse.IntStatusCodes.ToList(),
            BodyType: GetResponseBodyType(response),
            BodyMediaType: GetBodyFormat(response.HttpResponse.KnownMediaType),
            Headers: response.HttpResponse.Headers.ToList()
        );

        private OperationLongRunning? CreateLongRunning(Operation operation)
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

        private IReadOnlyList<InputEnumType> CreateEnums(IEnumerable<ChoiceSchema> schemasChoices, IEnumerable<SealedChoiceSchema> schemasSealedChoices)
            => schemasChoices.Select(c => CreateType(c, null, null))
                .Concat(schemasSealedChoices.Select(c => CreateType(c, null, null)))
                .OfType<InputEnumType>()
                .ToList();

        private IReadOnlyList<InputModelType> CreateModels(ICollection<ObjectSchema> schemas)
        {
            foreach (var schema in schemas)
            {
                GetOrCreateModel(schema);
            }

            foreach (var (schema, properties) in _modelPropertiesCache)
            {
                properties.AddRange(schema.Properties.Select(CreateProperty));
            }

            foreach (var schema in schemas)
            {
                var derived = schema.Children?.Immediate.OfType<ObjectSchema>().Select(s => _modelsCache[s]);
                if (derived != null)
                {
                    _derivedModelsCache[schema].AddRange(derived);
                }
            }

            return schemas.Select(s => _modelsCache[s]).ToList();
        }

        private InputModelType GetOrCreateModel(ObjectSchema schema)
        {
            if (_modelsCache.TryGetValue(schema, out var model))
            {
                return model;
            }

            var properties = new List<InputModelProperty>();
            var derived = new List<InputModelType>();
            model = new InputModelType(
                Name: schema.Language.Default.Name,
                Namespace: schema.Extensions?.Namespace,
                Accessibility: schema.Extensions?.Accessibility,
                Properties: properties,
                BaseModel: schema.Parents?.Immediate.FirstOrDefault() is ObjectSchema parent
                    ? GetOrCreateModel(parent)
                    : null,
                DerivedModels: derived,
                DiscriminatorValue: schema.DiscriminatorValue
            );

            _modelsCache[schema] = model;
            _modelPropertiesCache[schema] = properties;
            _derivedModelsCache[schema] = derived;

            return model;
        }

        private InputModelProperty CreateProperty(Property property) => new(
            Name: property.Language.Default.Name,
            SerializedName: property.SerializedName,
            Description: property.Language.Default.Description,
            Type: CreateType(property.Schema, _modelsCache, property.IsNullable),
            IsRequired: property.IsRequired,
            IsReadOnly: property.IsReadOnly,
            IsDiscriminator: property.IsDiscriminator ?? false
        );

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

        private InputType? GetResponseBodyType(ServiceResponse response) => response switch
        {
            { HttpResponse.KnownMediaType: KnownMediaType.Text } => InputPrimitiveType.String,
            BinaryResponse => InputPrimitiveType.Stream,
            SchemaResponse schemaResponse => CreateType(schemaResponse.Schema, _modelsCache, schemaResponse.IsNullable),
            _ => null
        };

        public InputType CreateType(RequestParameter requestParameter)
            => CreateType(requestParameter.Schema, requestParameter.Extensions?.Format, _modelsCache, requestParameter.IsNullable || !requestParameter.IsRequired);

        private static InputType CreateType(Schema schema, IReadOnlyDictionary<ObjectSchema, InputModelType>? modelsCache, bool isNullable)
            => CreateType(schema, schema.Extensions?.Format, modelsCache, isNullable);

        private static InputType CreateType(Schema schema, string? format, IReadOnlyDictionary<ObjectSchema, InputModelType>? modelsCache, bool isNullable)
            => CreateType(schema, format, modelsCache) with {IsNullable = isNullable};

        private static InputType CreateType(Schema schema, string? format, IReadOnlyDictionary<ObjectSchema, InputModelType>? modelsCache) => schema switch
        {
            BinarySchema => InputPrimitiveType.Stream,

            ByteArraySchema { Format: ByteArraySchemaFormat.Base64url } => InputPrimitiveType.BytesBase64Url,
            ByteArraySchema                                             => InputPrimitiveType.Bytes,

            DateSchema                                                      => InputPrimitiveType.Date,
            DateTimeSchema { Format: DateTimeSchemaFormat.DateTime }        => InputPrimitiveType.DateTimeISO8601,
            DateTimeSchema { Format: DateTimeSchemaFormat.DateTimeRfc1123 } => InputPrimitiveType.DateTimeRFC1123,
            DateTimeSchema                                                  => InputPrimitiveType.DateTime,
            UnixTimeSchema                                                  => InputPrimitiveType.DateTimeUnix,

            TimeSchema                                               => InputPrimitiveType.Time,
            DurationSchema when format == XMsFormat.DurationConstant => InputPrimitiveType.DurationConstant,
            DurationSchema                                           => InputPrimitiveType.DurationISO8601,

            NumberSchema { Type: AllSchemaTypes.Number, Precision: 32 }  => InputPrimitiveType.Float32,
            NumberSchema { Type: AllSchemaTypes.Number, Precision: 128 } => InputPrimitiveType.Float128,
            NumberSchema { Type: AllSchemaTypes.Number }                 => InputPrimitiveType.Float64,
            NumberSchema { Type: AllSchemaTypes.Integer, Precision: 64 } => InputPrimitiveType.Int64,
            NumberSchema { Type: AllSchemaTypes.Integer }                => InputPrimitiveType.Int32,

            { Type: AllSchemaTypes.String } when format == XMsFormat.DurationConstant => InputPrimitiveType.DurationConstant,
            { Type: AllSchemaTypes.String } when format == XMsFormat.ArmId            => InputPrimitiveType.ResourceIdentifier,
            { Type: AllSchemaTypes.String } when format == XMsFormat.AzureLocation    => InputPrimitiveType.AzureLocation,
            { Type: AllSchemaTypes.String } when format == XMsFormat.ContentType      => InputPrimitiveType.ContentType,
            { Type: AllSchemaTypes.String } when format == XMsFormat.ETag             => InputPrimitiveType.ETag,
            { Type: AllSchemaTypes.String } when format == XMsFormat.ResourceType     => InputPrimitiveType.ResourceType,
            { Type: AllSchemaTypes.String } when format == XMsFormat.RequestMethod    => InputPrimitiveType.RequestMethod,

            ConstantSchema constantSchema => CreateType(constantSchema.ValueType, format, modelsCache),

            CredentialSchema                 => InputPrimitiveType.String,
            { Type: AllSchemaTypes.String }  => InputPrimitiveType.String,
            { Type: AllSchemaTypes.Boolean } => InputPrimitiveType.Boolean,
            { Type: AllSchemaTypes.Uuid }    => InputPrimitiveType.Guid,
            { Type: AllSchemaTypes.Uri }     => InputPrimitiveType.Uri,

            ArraySchema array               when IsDPG => new InputListType(array.Name, CreateType(array.ElementType, modelsCache, array.NullableItems ?? false)),
            DictionarySchema dictionary     when IsDPG => new InputDictionaryType(dictionary.Name, InputPrimitiveType.String, CreateType(dictionary.ElementType, modelsCache, dictionary.NullableItems ?? false)),
            ChoiceSchema choiceSchema       when !Configuration.AzureArm => CreateEnumType(choiceSchema, choiceSchema.ChoiceType, choiceSchema.Choices, true),
            SealedChoiceSchema choiceSchema when !Configuration.AzureArm => CreateEnumType(choiceSchema, choiceSchema.ChoiceType, choiceSchema.Choices, false),
            ObjectSchema objectSchema       when IsDPG && modelsCache != null => modelsCache[objectSchema],

            _ => new CodeModelType(schema)
        };

        public static InputEnumType CreateEnumType(Schema schema, PrimitiveSchema choiceType, IEnumerable<ChoiceValue> choices, bool isExtendable) => new(
            Name: schema.Name,
            Namespace: schema.Extensions?.Namespace,
            Accessibility: schema.Extensions?.Accessibility,
            Description: schema.CreateDescription(),
            EnumValueType: (InputPrimitiveType)CreateType(choiceType, schema.Extensions?.Format, null),
            AllowedValues: choices.Select(CreateEnumValue).ToList(),
            IsExtendable: isExtendable
        );

        private static InputEnumTypeValue CreateEnumValue(ChoiceValue choiceValue) => new(
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

        private static bool IsDPG => !Configuration.Generation1ConvenienceClient && !Configuration.AzureArm;

        private InputConstant? GetDefaultValue(RequestParameter parameter)
        {
            if (parameter.ClientDefaultValue != null)
            {
                return new InputConstant(Value: parameter.ClientDefaultValue, Type: CreateType(parameter.Schema, _modelsCache, parameter.IsNullable));
            }

            if (parameter.Schema is ConstantSchema constantSchema)
            {
                return new InputConstant(Value: constantSchema.Value.Value, Type: CreateType(constantSchema.ValueType, _modelsCache, constantSchema.Value.Value == null));
            }

            return null;
        }

        private static Func<TResult> CacheResult<TSource, TResult>(TSource source, IDictionary<TSource, Func<TResult>> cache, Func<TResult> create) where TSource : notnull
        {
            if (cache.TryGetValue(source, out var createCache))
            {
                return createCache;
            }

            TResult? value = default;
            createCache = () => value ??= create();
            cache[source] = createCache;
            return createCache;
        }

        public static IReadOnlyList<string> GetApiVersions(CodeModel codeModel)
            => codeModel.OperationGroups
                .SelectMany(g => g.Operations.SelectMany(o => o.ApiVersions))
                .Select(v => v.Version)
                .Distinct()
                .OrderBy(v => v)
                .ToList();
    }
}
