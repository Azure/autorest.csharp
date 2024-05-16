// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Utilities;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Utilities;
using Azure.Core.Expressions.DataFactory;

namespace AutoRest.CSharp.Common.Input
{
    internal class CodeModelConverter
    {
        private readonly CodeModel _codeModel;
        private readonly SchemaUsageProvider _schemaUsageProvider;
        private readonly Dictionary<ServiceRequest, Func<InputOperation>> _operationsCache;
        private readonly Dictionary<RequestParameter, Func<InputParameter>> _parametersCache;
        private readonly Dictionary<Schema, InputEnumType> _enumsCache;
        private readonly Dictionary<string, InputEnumType> _enumsNamingCache;
        private readonly Dictionary<ObjectSchema, InputModelType> _modelsCache;
        private readonly Dictionary<ObjectSchema, List<InputModelProperty>> _modelPropertiesCache;
        private readonly Dictionary<ObjectSchema, List<InputModelType>> _derivedModelsCache;

        public CodeModelConverter(CodeModel codeModel, SchemaUsageProvider schemaUsageProvider)
        {
            _codeModel = codeModel;
            _schemaUsageProvider = schemaUsageProvider;
            _enumsCache = new Dictionary<Schema, InputEnumType>();
            _enumsNamingCache = new Dictionary<string, InputEnumType>();
            _operationsCache = new Dictionary<ServiceRequest, Func<InputOperation>>();
            _parametersCache = new Dictionary<RequestParameter, Func<InputParameter>>();
            _modelsCache = new Dictionary<ObjectSchema, InputModelType>();
            _modelPropertiesCache = new Dictionary<ObjectSchema, List<InputModelProperty>>();
            _derivedModelsCache = new Dictionary<ObjectSchema, List<InputModelType>>();
        }

        public InputNamespace CreateNamespace() => CreateNamespace(null, null);

        public (InputNamespace Namespace, IReadOnlyDictionary<ServiceRequest, InputOperation> ServiceRequestToInputOperation, IReadOnlyDictionary<InputOperation, Operation> InputOperationToOperation) CreateNamespaceWithMaps()
        {
            var serviceRequestToInputOperation = new Dictionary<ServiceRequest, InputOperation>();
            var inputOperationToOperation = new Dictionary<InputOperation, Operation>();
            var inputNamespace = CreateNamespace(serviceRequestToInputOperation, inputOperationToOperation);
            return (inputNamespace, serviceRequestToInputOperation, inputOperationToOperation);
        }

        private InputNamespace CreateNamespace(Dictionary<ServiceRequest, InputOperation>? serviceRequestToInputOperation, Dictionary<InputOperation, Operation>? inputOperationToOperation)
        {
            CreateEnums();
            var models = CreateModels();
            var clients = CreateClients(_codeModel.OperationGroups, serviceRequestToInputOperation, inputOperationToOperation);

            return new(Name: _codeModel.Language.Default.Name,
                Description: _codeModel.Language.Default.Description,
                Clients: clients,
                Models: models,
                Enums: _enumsCache.Values.ToArray(),
                ApiVersions: GetApiVersions(),
                Auth: GetAuth(_codeModel.Security.Schemes.OfType<SecurityScheme>()));
        }

        private IReadOnlyList<InputClient> CreateClients(IEnumerable<OperationGroup> operationGroups, Dictionary<ServiceRequest, InputOperation>? serviceRequestToInputOperation, Dictionary<InputOperation, Operation>? inputOperationToOperation)
            => operationGroups.Select(operationGroup => CreateClient(operationGroup, serviceRequestToInputOperation, inputOperationToOperation)).ToList();

        private InputClient CreateClient(OperationGroup operationGroup, Dictionary<ServiceRequest, InputOperation>? serviceRequestToInputOperation, Dictionary<InputOperation, Operation>? inputOperationToOperation)
            => new(
                Name: operationGroup.Language.Default.Name,
                Description: operationGroup.Language.Default.Description,
                Operations: CreateOperations(operationGroup.Operations, serviceRequestToInputOperation, inputOperationToOperation),
                Parameters: Array.Empty<InputParameter>(),
                Parent: null)
            {
                Key = operationGroup.Key,
            };

        private IReadOnlyList<InputOperation> CreateOperations(ICollection<Operation> operations, Dictionary<ServiceRequest, InputOperation>? serviceRequestToInputOperation, Dictionary<InputOperation, Operation>? inputOperationToOperation)
        {
            var serviceRequests = new List<ServiceRequest>();
            var inputOperations = new List<InputOperation>();
            foreach (var operation in operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    if (serviceRequest.Protocol.Http is not HttpRequest httpRequest)
                    {
                        continue;
                    }

                    serviceRequests.Add(serviceRequest);
                    _operationsCache.CreateAndCacheResult(serviceRequest, () => CreateOperation(serviceRequest, operation, httpRequest));

                    if (operation.RequestMediaTypes != null && !Configuration.Generation1ConvenienceClient)
                    {
                        break;
                    }
                }
            }

            foreach (var serviceRequest in serviceRequests)
            {
                var inputOperation = _operationsCache[serviceRequest]();
                inputOperations.Add(inputOperation);
                if (serviceRequestToInputOperation is not null)
                {
                    serviceRequestToInputOperation[serviceRequest] = inputOperation;
                }
            }

            if (serviceRequestToInputOperation is not null && inputOperationToOperation is not null)
            {
                foreach (var operation in operations)
                {
                    foreach (var serviceRequest in operation.Requests)
                    {
                        if (serviceRequestToInputOperation.TryGetValue(serviceRequest, out var inputOperation))
                        {
                            inputOperationToOperation[inputOperation] = operation;
                        }
                    }
                }
            }

            return inputOperations;
        }

        private InputOperation CreateOperation(ServiceRequest serviceRequest, Operation operation, HttpRequest httpRequest)
        {
            var parameters = CreateOperationParameters(operation.Parameters.Concat(serviceRequest.Parameters).ToList());
            var inputOperation = new InputOperation(
                name: operation.Language.Default.Name,
                resourceName: null,
                summary: operation.Language.Default.Summary,
                deprecated: operation.Deprecated?.Reason,
                description: operation.Language.Default.Description,
                accessibility: operation.Accessibility,
                parameters: parameters,
                responses: operation.Responses.Select(CreateOperationResponse).ToList(),
                httpMethod: httpRequest.Method.ToCoreRequestMethod(),
                requestBodyMediaType: GetBodyFormat((httpRequest as HttpWithBodyRequest)?.KnownMediaType),
                uri: httpRequest.Uri,
                path: httpRequest.Path,
                externalDocsUrl: operation.ExternalDocs?.Url,
                requestMediaTypes: operation.RequestMediaTypes?.Keys.ToList(),
                bufferResponse: operation.Extensions?.BufferResponse ?? true,
                longRunning: CreateLongRunning(operation),
                paging: CreateOperationPaging(serviceRequest, operation),
                generateProtocolMethod: true,
                generateConvenienceMethod: false,
                keepClientDefaultValue: Configuration.MethodsToKeepClientDefaultValue.Contains(operation.OperationId),
                operationId: operation.OperationId)
            {
                SpecName = operation.Language.Default.SerializedName ?? operation.Language.Default.Name
            };
            inputOperation.CodeModelExamples = CreateOperationExamples(inputOperation);
            return inputOperation;
        }

        private IReadOnlyList<InputOperationExample> CreateOperationExamples(InputOperation operation)
        {
            var result = new List<InputOperationExample>();
            var exampleOperation = _codeModel.TestModel?.MockTest.ExampleGroups?.FirstOrDefault(g => g.OperationId == operation.OperationId);
            if (exampleOperation is null)
            {
                return result;
            }
            foreach (var example in exampleOperation.Examples)
            {
                var parameters = example.AllParameters
                    .Select(p => new InputParameterExample(CreateOperationParameter(p.Parameter), CreateExampleValue(p.ExampleValue)))
                    .ToList();
                result.Add(new InputOperationExample(operation, parameters, example.Name, example.OriginalFile));
            }
            return result;
        }

        private InputExampleValue CreateExampleValue(ExampleValue exampleValue)
        {
            var inputType = CreateType(exampleValue.Schema, exampleValue.Schema.Extensions?.Format, _modelsCache, false);
            if (exampleValue.RawValue != null)
            {
                return new InputExampleRawValue(inputType, exampleValue.RawValue);
            }
            if (exampleValue.Elements != null && exampleValue.Elements.Any())
            {
                return new InputExampleListValue(inputType, exampleValue.Elements.Select(CreateExampleValue).ToList());
            }
            if (exampleValue.Properties is null)
            {
                return InputExampleValue.Null(inputType);
            }
            else
            {
                return new InputExampleObjectValue(inputType, exampleValue.Properties.ToDictionary(p => p.Key, p => CreateExampleValue(p.Value)));
            }
        }

        private List<InputParameter> CreateOperationParameters(IReadOnlyCollection<RequestParameter> requestParameters)
        {
            foreach (var parameter in requestParameters)
            {
                _parametersCache.CreateAndCacheResult(parameter, () => CreateOperationParameter(parameter));
            }

            return requestParameters.Select(rp => _parametersCache[rp]()).ToList();
        }

        private InputParameter CreateOperationParameter(RequestParameter input) => new(
            Name: input.Language.Default.Name,
            NameInRequest: input.Language.Default.SerializedName ?? input.Language.Default.Name,
            Description: input.Language.Default.Description,
            Type: GetOrCreateType(input),
            Location: GetRequestLocation(input),
            DefaultValue: GetDefaultValue(input),
            IsRequired: input.IsRequired,
            GroupedBy: input.GroupedBy is { } groupedBy ? _parametersCache[groupedBy]() : null,
            Kind: GetOperationParameterKind(input),
            IsApiVersion: input.IsApiVersion,
            IsResourceParameter: Convert.ToBoolean(input.Extensions.GetValue<string>("x-ms-resource-identifier")),
            IsContentType: input.Origin == "modelerfour:synthesized/content-type",
            IsEndpoint: input.Origin == "modelerfour:synthesized/host",
            ArraySerializationDelimiter: GetArraySerializationDelimiter(input),
            Explode: input.Protocol.Http is HttpParameter { Explode: true },
            SkipUrlEncoding: input.Extensions?.SkipEncoding ?? false,
            HeaderCollectionPrefix: input.Extensions?.HeaderCollectionPrefix,
            FlattenedBodyProperty: input is VirtualParameter vp and ({ Schema: not ConstantSchema } or { Required: not true })
                ? CreateProperty(vp.TargetProperty)
                : null
        );

        private OperationResponse CreateOperationResponse(ServiceResponse response) => new(
            StatusCodes: response.HttpResponse.IntStatusCodes.ToList(),
            BodyType: GetResponseBodyType(response),
            BodyMediaType: GetBodyFormat(response.HttpResponse.KnownMediaType),
            Headers: GetResponseHeaders(response.HttpResponse.Headers),
            IsErrorResponse: false,
            ContentTypes: Array.Empty<string>()
        );

        private OperationResponseHeader CreateResponseHeader(HttpResponseHeader header) => new(
            Name: header.CSharpName(),
            NameInResponse: header.Extensions?.HeaderCollectionPrefix ?? header.Header,
            Description: header.Language.Default.Description,
            Type: GetOrCreateType(header.Schema, header.Extensions?.Format, _modelsCache, true)
        );

        private OperationLongRunning? CreateLongRunning(Operation operation)
        {
            if (!operation.IsLongRunning)
            {
                return null;
            }

            return new OperationLongRunning(
                FinalStateVia: operation.LongRunningFinalStateVia,
                FinalResponse: CreateOperationResponse(operation.LongRunningFinalResponse),
                ResultPath: null
            );
        }

        private OperationPaging? CreateOperationPaging(ServiceRequest serviceRequest, Operation operation)
        {
            var paging = operation.Language.Default.Paging;
            if (paging == null)
            {
                return null;
            }

            var nextLinkServiceRequest = paging.NextLinkOperation?.Requests.Single();
            if (nextLinkServiceRequest != null && nextLinkServiceRequest != serviceRequest && _operationsCache.TryGetValue(nextLinkServiceRequest, out var nextLinkOperationRef))
            {
                return new OperationPaging(NextLinkName: paging.NextLinkName, ItemName: paging.ItemName, nextLinkOperationRef(), false);
            }

            return new OperationPaging(NextLinkName: paging.NextLinkName, ItemName: paging.ItemName, null, nextLinkServiceRequest == serviceRequest);
        }

        private void CreateEnums()
        {
            foreach (var choiceSchema in _codeModel.Schemas.Choices)
            {
                var enumType = CreateEnumType(choiceSchema, choiceSchema.ChoiceType, choiceSchema.Choices, true);
                _enumsCache[choiceSchema] = enumType;
                _enumsNamingCache[choiceSchema.Language.Default.Name] = enumType;
            }

            foreach (var sealedChoiceSchema in _codeModel.Schemas.SealedChoices)
            {
                var enumType = CreateEnumType(sealedChoiceSchema, sealedChoiceSchema.ChoiceType, sealedChoiceSchema.Choices, false);
                _enumsCache[sealedChoiceSchema] = enumType;
                _enumsNamingCache[sealedChoiceSchema.Language.Default.Name] = enumType;
            }
        }

        private IReadOnlyList<InputModelType> CreateModels()
        {
            var schemas = _codeModel.Schemas.Objects.Concat(_codeModel.Schemas.Groups).ToList();

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

            var usage = _schemaUsageProvider.GetUsage(schema);
            var properties = new List<InputModelProperty>();
            var derived = new List<InputModelType>();
            var baseModelSchema = GetBaseModelSchema(schema);
            var compositeSchemas = schema.Parents?.Immediate?.OfType<ObjectSchema>().Where(s => s != baseModelSchema);
            var dictionarySchema = schema.Parents?.Immediate?.OfType<DictionarySchema>().FirstOrDefault();

            model = new InputModelType(
                Name: schema.Language.Default.Name,
                Namespace: schema.Extensions?.Namespace,
                Accessibility: schema.Extensions?.Accessibility ?? (usage.HasFlag(SchemaTypeUsage.Model) ? "public" : "internal"),
                Deprecated: schema.Deprecated?.Reason,
                Description: schema.CreateDescription(),
                Usage: (schema.Extensions != null && schema.Extensions.Formats.Contains("multipart/form-data") ? InputModelTypeUsage.Multipart : InputModelTypeUsage.None)
                        | GetUsage(usage),
                Properties: properties,
                BaseModel: baseModelSchema is not null ? GetOrCreateModel(baseModelSchema) : null,
                DerivedModels: derived,
                DiscriminatorValue: schema.DiscriminatorValue,
                DiscriminatorPropertyName: schema.Discriminator?.Property.SerializedName,
                InheritedDictionaryType: dictionarySchema is not null ? (InputDictionaryType)GetOrCreateType(dictionarySchema, _modelsCache, false) : null,
                IsNullable: false,
                Parents: schema.Parents?.All is null ? null : schema.Parents.All.OfType<ObjectSchema>().Select(GetOrCreateModel).ToArray(),
                IsBasePolyType: IsBasePolyType(schema))
            {
                CompositionModels = compositeSchemas is not null ? compositeSchemas.Select<global::AutoRest.CSharp.Input.ObjectSchema, global::AutoRest.CSharp.Common.Input.InputModelType>(GetOrCreateModel).ToList<global::AutoRest.CSharp.Common.Input.InputModelType>() : global::System.Array.Empty<global::AutoRest.CSharp.Common.Input.InputModelType>(),
                Serialization = GetSerialization(schema, usage),
                SpecName = schema.Language.Default.SerializedName
            };

            _modelsCache[schema] = model;
            _modelPropertiesCache[schema] = properties;
            _derivedModelsCache[schema] = derived;

            return model;
        }

        private bool IsBasePolyType(ObjectSchema schema)
        {
            return schema.Discriminator?.All is not null ||
                (schema.Discriminator is not null && !HasParentsWithDiscriminator(schema)); //this is the case where I am a solo placeholder but might have derived types later
        }

        private bool HasParentsWithDiscriminator(ObjectSchema schema)
        {
            return schema.Parents?.All.Count > 0 && schema.Parents.All.Any(parent => parent is ObjectSchema objectSchema && objectSchema.Discriminator is not null);
        }

        private static InputModelTypeUsage GetUsage(SchemaTypeUsage usage)
        {
            var result = InputModelTypeUsage.None;
            if (usage.HasFlag(SchemaTypeUsage.Input))
            {
                result |= InputModelTypeUsage.Input;
            }
            if (usage.HasFlag(SchemaTypeUsage.Output))
            {
                result |= InputModelTypeUsage.Output;
            }
            if (usage.HasFlag(SchemaTypeUsage.RoundTrip))
            {
                result |= InputModelTypeUsage.RoundTrip;
            }
            return result;
        }

        private static ObjectSchema? GetBaseModelSchema(ObjectSchema schema)
        => schema.Parents?.Immediate is { } parents
                ? parents.OfType<ObjectSchema>().FirstOrDefault(s => s.Discriminator is not null) ?? parents.OfType<ObjectSchema>().FirstOrDefault()
                : null;

        private InputModelProperty CreateProperty(Property property) => new(
            Name: property.Language.Default.Name,
            SerializedName: property.SerializedName,
            Description: property.Language.Default.Description,
            Type: GetOrCreateType(property),
            ConstantValue: property.Schema is ConstantSchema constantSchema ? CreateConstant(constantSchema, constantSchema.Extensions?.Format, _modelsCache, property.IsNullable) : null,
            IsRequired: property.IsRequired,
            IsReadOnly: property.IsReadOnly,
            IsDiscriminator: property.IsDiscriminator ?? false,
            IsNullable: property.IsNullable,
            FlattenedNames: property.FlattenedNames.ToList(),
            GroupParameterNames: property is GroupProperty groupProperty ? groupProperty.OriginalParameter.Select(x => x.Language.Default.Name).ToArray() : null);

        private static InputOperationParameterKind GetOperationParameterKind(RequestParameter input) => input switch
        {
            { Implementation: ImplementationLocation.Client } => InputOperationParameterKind.Client,

            // only required constant parameter can be Constant kind which will be optimized to disappear from method signature
            { Schema: ConstantSchema, IsRequired: true } => InputOperationParameterKind.Constant,

            // Grouped and flattened parameters shouldn't be added to methods
            { IsFlattened: true } => InputOperationParameterKind.Flattened,
            { GroupedBy: not null } => InputOperationParameterKind.Grouped,
            _ => InputOperationParameterKind.Method
        };

        private static InputTypeSerialization GetSerialization(Schema schema, SchemaTypeUsage typeUsage)
        {
            var formats = schema is ObjectSchema objectSchema ? objectSchema.SerializationFormats : new List<KnownMediaType> { KnownMediaType.Json, KnownMediaType.Xml };
            if (Configuration.SkipSerializationFormatXml)
            {
                formats.Remove(KnownMediaType.Xml);
            }

            if (schema.Extensions != null)
            {
                foreach (var format in schema.Extensions.Formats)
                {
                    formats.Add(Enum.Parse<KnownMediaType>(format, true));
                }
            }

            var xmlSerialization = schema.Serialization?.Xml;
            var jsonFormat = formats.Contains(KnownMediaType.Json);
            var xmlFormat = formats.Contains(KnownMediaType.Xml)
                ? new InputTypeXmlSerialization(xmlSerialization?.Name, xmlSerialization?.Attribute == true, xmlSerialization?.Text == true, xmlSerialization?.Wrapped == true)
                : null;

            return new InputTypeSerialization(jsonFormat, xmlFormat, typeUsage.HasFlag(SchemaTypeUsage.Converter));
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

        private InputType? GetResponseBodyType(ServiceResponse response) => response switch
        {
            { HttpResponse.KnownMediaType: KnownMediaType.Text } => InputPrimitiveType.String,
            BinaryResponse => InputPrimitiveType.Stream,
            SchemaResponse schemaResponse => GetOrCreateType(schemaResponse.Schema, _modelsCache, schemaResponse.IsNullable),
            _ => null
        };

        private IReadOnlyList<OperationResponseHeader> GetResponseHeaders(ICollection<HttpResponseHeader>? headers)
        {
            if (headers == null)
            {
                return Array.Empty<OperationResponseHeader>();
            }
            return headers.Select(CreateResponseHeader).ToList();
        }

        private InputType GetOrCreateType(RequestParameter requestParameter)
        {
            var schema = requestParameter is { Schema: ConstantSchema constantSchema }
                ? constantSchema.ValueType
                : requestParameter.Schema;

            return GetOrCreateType(schema, requestParameter.Extensions?.Format, _modelsCache, requestParameter.IsNullable || !requestParameter.IsRequired);
        }

        private InputType GetOrCreateType(Property property)
        {
            var name = property.Schema.Name;
            var type = typeof(DataFactoryElement<>);
            object? elementType = null;
            if ((property.Schema is AnyObjectSchema || property.Schema is StringSchema) && true == property.Extensions?.TryGetValue("x-ms-format-element-type", out elementType))
            {
                return ToXMsFormatType(name, property.Extensions?.Format, property.IsNullable, (Schema)elementType!) ?? GetOrCreateType(property.Schema, property.Schema.Extensions?.Format, _modelsCache, property.IsNullable);
            }
            else
            {
                return GetOrCreateType(property.Schema, GetPropertyFormat(property), _modelsCache, property.IsNullable);
            }
        }

        private string? GetPropertyFormat(Property property)
        {
            if (!string.IsNullOrEmpty(property.Extensions?.Format))
            {
                return property.Extensions.Format;
            }
            return property.Schema.Extensions?.Format;
        }

        private InputType GetOrCreateType(Schema schema, IReadOnlyDictionary<ObjectSchema, InputModelType>? modelsCache, bool isNullable)
            => GetOrCreateType(schema, schema.Extensions?.Format, modelsCache, isNullable);

        private InputType GetOrCreateType(Schema schema, string? format, IReadOnlyDictionary<ObjectSchema, InputModelType>? modelsCache, bool isNullable)
        {
            if (schema is ObjectSchema objectSchema && modelsCache != null)
            {
                if (!Configuration.AzureArm)
                {
                    return modelsCache[objectSchema] with { IsNullable = isNullable };
                }
                else
                {
                    return modelsCache[objectSchema];
                }
            }

            if (_enumsCache.TryGetValue(schema, out var enumType))
            {
                return enumType with { IsNullable = isNullable };
            }

            var type = CreateType(schema, format, modelsCache, isNullable);
            if (type.Serialization == InputTypeSerialization.Default)
            {
                return type with
                {
                    Serialization = GetSerialization(schema, SchemaTypeUsage.None),
                    IsNullable = isNullable,
                };
            }

            return type;
        }

        private InputType CreateType(Schema schema, string? format, IReadOnlyDictionary<ObjectSchema, InputModelType>? modelsCache, bool isNullable) => schema switch
        {
            // Respect schema.Type firstly since we might have applied the type change based on rename-mapping
            { Type: AllSchemaTypes.ArmId } => new InputPrimitiveType(InputTypeKind.ResourceIdentifier, isNullable),
            { Type: AllSchemaTypes.Boolean } => new InputPrimitiveType(InputTypeKind.Boolean, isNullable),
            { Type: AllSchemaTypes.Binary } => new InputPrimitiveType(InputTypeKind.Stream, isNullable),
            ByteArraySchema { Type: AllSchemaTypes.ByteArray, Format: ByteArraySchemaFormat.Base64url } => new InputPrimitiveType(InputTypeKind.BytesBase64Url, isNullable),
            ByteArraySchema { Type: AllSchemaTypes.ByteArray, Format: ByteArraySchemaFormat.Byte } => new InputPrimitiveType(InputTypeKind.Bytes, isNullable),
            { Type: AllSchemaTypes.Credential } => new InputPrimitiveType(InputTypeKind.String, isNullable),
            { Type: AllSchemaTypes.Date } => new InputPrimitiveType(InputTypeKind.Date, isNullable),
            DateTimeSchema { Type: AllSchemaTypes.DateTime, Format: DateTimeSchemaFormat.DateTime } => new InputPrimitiveType(InputTypeKind.DateTimeISO8601, isNullable),
            DateTimeSchema { Type: AllSchemaTypes.DateTime, Format: DateTimeSchemaFormat.DateTimeRfc1123 } => new InputPrimitiveType(InputTypeKind.DateTimeRFC1123, isNullable),
            { Type: AllSchemaTypes.DateTime } => new InputPrimitiveType(InputTypeKind.DateTime, isNullable),
            DurationSchema when format == XMsFormat.DurationConstant => new InputPrimitiveType(InputTypeKind.DurationConstant, isNullable),
            { Type: AllSchemaTypes.Duration } => new InputPrimitiveType(InputTypeKind.DurationISO8601, isNullable),
            NumberSchema { Type: AllSchemaTypes.Number, Precision: 32 } => new InputPrimitiveType(InputTypeKind.Float32, isNullable),
            NumberSchema { Type: AllSchemaTypes.Number, Precision: 128 } => new InputPrimitiveType(InputTypeKind.Float128, isNullable),
            { Type: AllSchemaTypes.Number } => new InputPrimitiveType(InputTypeKind.Float64, isNullable),
            NumberSchema { Type: AllSchemaTypes.Integer, Precision: 64 } => new InputPrimitiveType(InputTypeKind.Int64, isNullable),
            { Type: AllSchemaTypes.Integer } => new InputPrimitiveType(InputTypeKind.Int32, isNullable),
            { Type: AllSchemaTypes.Time } => new InputPrimitiveType(InputTypeKind.Time, isNullable),
            { Type: AllSchemaTypes.Unixtime } => new InputPrimitiveType(InputTypeKind.DateTimeUnix, isNullable),
            { Type: AllSchemaTypes.Uri } => new InputPrimitiveType(InputTypeKind.Uri, isNullable),
            { Type: AllSchemaTypes.Uuid } => new InputPrimitiveType(InputTypeKind.Guid, isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.DateTime => new InputPrimitiveType(InputTypeKind.DateTimeISO8601, isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.DateTimeRFC1123 => new InputPrimitiveType(InputTypeKind.DateTimeRFC1123, isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.DateTimeUnix => new InputPrimitiveType(InputTypeKind.DateTimeUnix, isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.DurationConstant => new InputPrimitiveType(InputTypeKind.DurationConstant, isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.ArmId => new InputPrimitiveType(InputTypeKind.ResourceIdentifier, isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.AzureLocation => new InputPrimitiveType(InputTypeKind.AzureLocation, isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.ContentType => new InputPrimitiveType(InputTypeKind.ContentType, isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.ETag => new InputPrimitiveType(InputTypeKind.ETag, isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.ResourceType => new InputPrimitiveType(InputTypeKind.ResourceType, isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.RequestMethod => new InputPrimitiveType(InputTypeKind.RequestMethod, isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.Object => new InputPrimitiveType(InputTypeKind.Object, isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.IPAddress => new InputPrimitiveType(InputTypeKind.IPAddress, isNullable),
            { Type: AllSchemaTypes.String } => ToXMsFormatType(schema.Name, format, isNullable) ?? new InputPrimitiveType(InputTypeKind.String, isNullable),
            { Type: AllSchemaTypes.Char } => new InputPrimitiveType(InputTypeKind.Char, isNullable),
            { Type: AllSchemaTypes.Any } => InputIntrinsicType.Unknown,
            { Type: AllSchemaTypes.AnyObject } => ToXMsFormatType(schema.Name, format, isNullable) ?? InputIntrinsicType.Unknown,

            ConstantSchema constantSchema => CreateConstant(constantSchema, format, modelsCache, isNullable).Type,
            ChoiceSchema choiceSchema => GetInputTypeForChoiceSchema(choiceSchema),
            SealedChoiceSchema choiceSchema => GetInputTypeForChoiceSchema(choiceSchema),
            ArraySchema array => new InputListType(array.Name, GetOrCreateType(array.ElementType, modelsCache, array.NullableItems ?? false), array.Extensions?.IsEmbeddingsVector == true, isNullable),
            DictionarySchema dictionary => new InputDictionaryType(dictionary.Name, InputPrimitiveType.String, GetOrCreateType(dictionary.ElementType, modelsCache, dictionary.NullableItems ?? false), isNullable),
            ObjectSchema objectSchema => CreateTypeForObjectSchema(objectSchema),

            _ => throw new InvalidCastException($"Unknown schema type {schema.GetType()}")
        };

        // For ExampleValue.Schema, the schema is ChoiceSchema or SealedChoiceSchema, but the ChoiceSchema is not the same instance as the one in CodeModel.ChoiceSchemas or CodeModel.SealedChoiceSchemas
        private InputType GetInputTypeForChoiceSchema(SealedChoiceSchema schema)
        {
            if (_enumsCache.TryGetValue(schema, out var result))
            {
                return result;
            }
            return _enumsNamingCache[schema.Language.Default.Name];
        }

        private InputType GetInputTypeForChoiceSchema(ChoiceSchema schema)
        {
            if (_enumsCache.TryGetValue(schema, out var result))
            {
                return result;
            }
            return _enumsNamingCache[schema.Language.Default.Name];
        }

        private InputType CreateTypeForObjectSchema(ObjectSchema objectSchema)
        {
            const string DFE_OBJECT_SCHEMA_PREFIX = "DataFactoryElement-";
            if (objectSchema.Language.Default.Name.StartsWith(DFE_OBJECT_SCHEMA_PREFIX))
            {
                return new InputGenericType(typeof(DataFactoryElement<>), InputPrimitiveType.String, false);
            }
            return _modelsCache[objectSchema];
        }

        private InputType CreateTypeForStringSchema(StringSchema schema, bool isNullable) => schema.Type switch
        {
            AllSchemaTypes.Date => new InputPrimitiveType(InputTypeKind.DateTime, isNullable),
            AllSchemaTypes.DateTime => new InputPrimitiveType(InputTypeKind.DateTime, isNullable),
            AllSchemaTypes.Duration => new InputPrimitiveType(InputTypeKind.DurationConstant, isNullable),
            AllSchemaTypes.OdataQuery => new InputPrimitiveType(InputTypeKind.String, isNullable),
            AllSchemaTypes.ArmId => new InputPrimitiveType(InputTypeKind.ResourceIdentifier, isNullable),
            AllSchemaTypes.String => new InputPrimitiveType(InputTypeKind.String, isNullable),
            AllSchemaTypes.Time => new InputPrimitiveType(InputTypeKind.DurationConstant, isNullable),
            AllSchemaTypes.Unixtime => new InputPrimitiveType(InputTypeKind.DateTime, isNullable),
            AllSchemaTypes.Uri => new InputPrimitiveType(InputTypeKind.Uri, isNullable),
            AllSchemaTypes.Uuid => new InputPrimitiveType(InputTypeKind.Guid, isNullable),
            AllSchemaTypes.Binary => new InputPrimitiveType(InputTypeKind.Bytes, isNullable),
            AllSchemaTypes.Integer => new InputPrimitiveType(InputTypeKind.Int32, isNullable),
            AllSchemaTypes.Boolean => new InputPrimitiveType(InputTypeKind.Boolean, isNullable),
            AllSchemaTypes.AnyObject => InputIntrinsicType.Unknown,
            AllSchemaTypes.Any => InputIntrinsicType.Unknown,
            _ => InputIntrinsicType.Null
        };

        private InputType? ToXMsFormatType(string name, string? format, bool isNullable, Schema? elementType = null)
        {
            var type = typeof(DataFactoryElement<>);
            return format switch
            {
                XMsFormat.DataFactoryElementOfObject => new InputGenericType(type, InputPrimitiveType.BinaryData, isNullable),
                XMsFormat.DataFactoryElementOfString => new InputGenericType(type, InputPrimitiveType.String, isNullable),
                XMsFormat.DataFactoryElementOfInt => new InputGenericType(type, InputPrimitiveType.Int32, isNullable),
                XMsFormat.DataFactoryElementOfDouble => new InputGenericType(type, InputPrimitiveType.Float64, isNullable),
                XMsFormat.DataFactoryElementOfBool => new InputGenericType(type, InputPrimitiveType.Boolean, isNullable),
                XMsFormat.DataFactoryElementOfListOfT => new InputGenericType(type, new InputListType(name, GetOrCreateType(elementType!, _modelsCache, false), false, false), isNullable),
                XMsFormat.DataFactoryElementOfListOfString => new InputGenericType(type, new InputListType(name, InputPrimitiveType.String, false, false), isNullable),
                XMsFormat.DataFactoryElementOfKeyValuePairs => new InputGenericType(type, new InputDictionaryType(name, InputPrimitiveType.String, InputPrimitiveType.String, false), isNullable),
                XMsFormat.DataFactoryElementOfDateTime => new InputGenericType(type, InputPrimitiveType.DateTime, isNullable),
                XMsFormat.DataFactoryElementOfDuration => new InputGenericType(type, InputPrimitiveType.Time, isNullable),
                XMsFormat.DataFactoryElementOfUri => new InputGenericType(type, InputPrimitiveType.Uri, isNullable),
                XMsFormat.DataFactoryElementOfKeyObjectValuePairs => new InputGenericType(type, new InputDictionaryType(name, InputPrimitiveType.String, InputPrimitiveType.BinaryData, false), isNullable),
                _ => null
            };
        }

        private InputConstant CreateConstant(ConstantSchema constantSchema, string? format, IReadOnlyDictionary<ObjectSchema, InputModelType>? modelsCache, bool isNullable)
        {
            var valueType = CreateType(constantSchema.ValueType, format, modelsCache, isNullable);
            // normalize the value, because the "value" coming from the code model is always a string
            var kind = valueType switch
            {
                InputPrimitiveType primitiveType => primitiveType.Kind,
                InputEnumType enumType => enumType.EnumValueType.Kind,
                _ => throw new InvalidCastException($"Unknown value type {valueType.GetType()} for literal types")
            };
            var rawValue = constantSchema.Value.Value;
            object normalizedValue = kind switch
            {
                InputTypeKind.Boolean => bool.Parse(rawValue.ToString()!),
                InputTypeKind.Int32 => int.Parse(rawValue.ToString()!),
                InputTypeKind.Int64 => long.Parse(rawValue.ToString()!),
                InputTypeKind.Float32 => float.Parse(rawValue.ToString()!),
                InputTypeKind.Float64 => double.Parse(rawValue.ToString()!),
                _ => rawValue
            };

            return new InputConstant(normalizedValue, valueType);
        }

        private InputEnumType CreateEnumType(Schema schema, PrimitiveSchema choiceType, IEnumerable<ChoiceValue> choices, bool isExtensible)
        {
            var usage = _schemaUsageProvider.GetUsage(schema);
            var inputEnumType = new InputEnumType(
                Name: schema.Name,
                Namespace: schema.Extensions?.Namespace,
                Accessibility: schema.Extensions?.Accessibility ?? (usage.HasFlag(SchemaTypeUsage.Model) ? "public" : "internal"),
                Deprecated: schema.Deprecated?.Reason,
                Description: schema.CreateDescription(),
                Usage: GetUsage(usage),
                EnumValueType: (InputPrimitiveType)CreateType(choiceType, schema.Extensions?.Format, null, false),
                AllowedValues: choices.Select(CreateEnumValue).ToList(),
                IsExtensible: isExtensible,
                IsNullable: false
            )
            {
                Serialization = GetSerialization(schema, usage)
            };
            return inputEnumType;
        }

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

        private InputConstant? GetDefaultValue(RequestParameter parameter)
        {
            if (parameter.ClientDefaultValue != null)
            {
                if (parameter.Origin == "modelerfour:synthesized/host" && (string)parameter.ClientDefaultValue == "")
                {
                    return null;
                }

                return new InputConstant(Value: parameter.ClientDefaultValue, Type: GetOrCreateType(parameter.Schema, _modelsCache, parameter.IsNullable));
            }

            if (parameter is { Schema: ConstantSchema constantSchema } && (!Configuration.AzureArm || parameter.IsRequired))
            {
                return new InputConstant(Value: constantSchema.Value.Value, Type: GetOrCreateType(constantSchema.ValueType, _modelsCache, constantSchema.Value.Value == null));
            }

            return null;
        }

        private IReadOnlyList<string> GetApiVersions()
            => _codeModel.OperationGroups
                .SelectMany(g => g.Operations.SelectMany(o => o.ApiVersions))
                .Select(v => v.Version)
                .Distinct()
                .OrderBy(v => v)
                .ToList();

        private static InputAuth GetAuth(IEnumerable<SecurityScheme> securitySchemes)
        {
            InputApiKeyAuth? apiKey = null;
            InputOAuth2Auth? oAuth2 = null;

            foreach (var scheme in securitySchemes.Distinct(SecuritySchemesComparer.Instance))
            {
                switch (scheme)
                {
                    case AzureKeySecurityScheme:
                        throw new NotSupportedException($"{typeof(AzureKeySecurityScheme)} is not supported. Use {typeof(KeySecurityScheme)} instead");
                    case AADTokenSecurityScheme:
                        throw new NotSupportedException($"{typeof(AADTokenSecurityScheme)} is not supported. Use {typeof(OAuth2SecurityScheme)} instead");
                    case KeySecurityScheme when apiKey is not null:
                        // Tolerate second KeySecurityScheme to support TranslatorText: https://github.com/Azure/azure-rest-api-specs/blob/3196a62202976da192d6da86f44b02246ca2aa97/specification/cognitiveservices/data-plane/TranslatorText/stable/v3.0/TranslatorText.json#L14
                        // See https://github.com/Azure/autorest.csharp/issues/2637
                        //throw new NotSupportedException($"Only one {typeof(KeySecurityScheme)} is supported. Remove excess");
                        break;
                    case OAuth2SecurityScheme when oAuth2 is not null:
                        throw new NotSupportedException($"Only one {typeof(OAuth2SecurityScheme)} is not supported. Remove excess");
                    case KeySecurityScheme apiKeyScheme:
                        apiKey = new InputApiKeyAuth(apiKeyScheme.Name);
                        break;
                    case OAuth2SecurityScheme oAuth2Scheme:
                        oAuth2 = new InputOAuth2Auth(oAuth2Scheme.Scopes.ToList());
                        break;
                }
            }

            return new InputAuth(apiKey, oAuth2);
        }

        private class SecuritySchemesComparer : IEqualityComparer<SecurityScheme>
        {
            public static IEqualityComparer<SecurityScheme> Instance { get; } = new SecuritySchemesComparer();

            private SecuritySchemesComparer() { }

            public bool Equals(SecurityScheme? x, SecurityScheme? y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }

                if (ReferenceEquals(x, null))
                {
                    return false;
                }

                if (ReferenceEquals(y, null))
                {
                    return false;
                }

                if (x.GetType() != y.GetType())
                {
                    return false;
                }

                return (x, y) switch
                {
                    (KeySecurityScheme apiKeyX, KeySecurityScheme apiKeyY)
                        => apiKeyX.Type == apiKeyY.Type && apiKeyX.Name == apiKeyY.Name,
                    (OAuth2SecurityScheme oAuth2X, OAuth2SecurityScheme oAuth2Y)
                        => oAuth2X.Type == oAuth2Y.Type && oAuth2X.Scopes.SequenceEqual(oAuth2Y.Scopes, StringComparer.Ordinal),
                    _ => x.Type == y.Type
                };
            }

            public int GetHashCode(SecurityScheme obj) =>
                obj switch
                {
                    AzureKeySecurityScheme azure => HashCode.Combine(azure.Type, azure.HeaderName),
                    AADTokenSecurityScheme aad => GetAADTokenSecurityHashCode(aad),
                    _ => HashCode.Combine(obj.Type)
                };

            private static int GetAADTokenSecurityHashCode(AADTokenSecurityScheme aad)
            {
                var hashCode = new HashCode();
                hashCode.Add(aad.Type);
                foreach (var value in aad.Scopes)
                {
                    hashCode.Add(value);
                }
                return hashCode.ToHashCode();
            }
        }

    }
}
