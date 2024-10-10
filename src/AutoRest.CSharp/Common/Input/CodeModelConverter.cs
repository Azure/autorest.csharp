// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input.Examples;
using AutoRest.CSharp.Common.Input.InputTypes;
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
        private readonly Dictionary<ObjectSchema, (List<InputModelProperty> Properties, IReadOnlyList<ObjectSchema> CompositSchemas)> _modelPropertiesCache;
        private readonly Dictionary<ObjectSchema, (List<InputModelType> DerivedModels, Dictionary<string, InputModelType> DiscriminatedSubtypes)> _derivedModelsCache;
        private readonly Dictionary<Property, InputModelProperty> _propertiesCache;

        public CodeModelConverter(CodeModel codeModel, SchemaUsageProvider schemaUsageProvider)
        {
            _codeModel = codeModel;
            _schemaUsageProvider = schemaUsageProvider;
            _enumsCache = new Dictionary<Schema, InputEnumType>();
            _enumsNamingCache = new Dictionary<string, InputEnumType>();
            _operationsCache = new Dictionary<ServiceRequest, Func<InputOperation>>();
            _parametersCache = new Dictionary<RequestParameter, Func<InputParameter>>();
            _modelsCache = new Dictionary<ObjectSchema, InputModelType>();
            _modelPropertiesCache = new Dictionary<ObjectSchema, (List<InputModelProperty> Properties, IReadOnlyList<ObjectSchema> CompositSchemas)>();
            _derivedModelsCache = new Dictionary<ObjectSchema, (List<InputModelType> DerivedModels, Dictionary<string, InputModelType> DiscriminatedSubtypes)>();
            _propertiesCache = new Dictionary<Property, InputModelProperty>();
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
            var operationId = operation.OperationId;
            var inputOperation = new InputOperation(
                name: operation.Language.Default.Name,
                // Keep the behavior for non-mgmt scenarios
                resourceName: Configuration.AzureArm ? GetResoureName(operationId) : null,
                summary: operation.Language.Default.Summary,
                deprecated: operation.Deprecated?.Reason,
                description: operation.Language.Default.Description,
                accessibility: operation.Accessibility,
                parameters: parameters,
                responses: operation.Responses.Select<ServiceResponse, OperationResponse>(CreateOperationResponse).ToList(),
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
                crossLanguageDefinitionId: string.Empty, // in typespec input, this is to determine whether an operation has been renamed. We have separated configuration for that in swagger input, therefore we leave it empty here
                keepClientDefaultValue: operationId is null ? false : Configuration.MethodsToKeepClientDefaultValue.Contains(operationId),
                examples: CreateOperationExamplesFromTestModeler(operation))
            {
                SpecName = operation.Language.Default.SerializedName ?? operation.Language.Default.Name
            };
            return inputOperation;
        }

        private static string? GetResoureName(string? operationId)
        {
            if (operationId is null || operationId.IndexOf("_") == -1)
            {
                return null;
            }
            return operationId.Split('_')[0];
        }

        private IReadOnlyList<InputOperationExample>? CreateOperationExamplesFromTestModeler(Operation operation)
        {
            if (!Configuration.AzureArm)
                return null;

            var result = new List<InputOperationExample>();
            var exampleOperation = _codeModel.TestModel?.MockTest.ExampleGroups?.FirstOrDefault(g => g.Operation == operation);
            if (exampleOperation is null)
            {
                return result;
            }
            foreach (var example in exampleOperation.Examples)
            {
                var parameters = example.AllParameters
                    .Select(p => new InputParameterExample(_parametersCache[p.Parameter](), CreateExampleValue(p.ExampleValue)))
                    .ToList();
                result.Add(new InputOperationExample(example.Name, null, example.OriginalFile!, parameters));
            }
            return result;
        }

        private InputExampleValue CreateExampleValue(ExampleValue exampleValue)
        {
            var inputType = CreateType(exampleValue.Schema, exampleValue.Schema.Extensions?.Format, false);
            if (exampleValue.RawValue != null)
            {
                // test modeler has a bug that all the primitive types are deserialized as strings, here we should convert them according to its real type
                return new InputExampleRawValue(inputType, ConvertRawValue(inputType, exampleValue.RawValue));
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

        private static object? ConvertRawValue(InputType inputType, object? originalValue)
        {
            if (originalValue == null)
            {
                return null;
            }

            if (originalValue is string strValue)
            {
                var effectiveInputType = inputType switch
                {
                    InputEnumType enumType => enumType.ValueType,
                    InputDurationType durationType => durationType.WireType,
                    InputDateTimeType dateTimeType => dateTimeType.WireType,
                    _ => inputType
                };
                switch (effectiveInputType)
                {
                    case InputPrimitiveType { Kind: InputPrimitiveTypeKind.Int32 or InputPrimitiveTypeKind.UInt32 }:
                        return int.TryParse(strValue, out var intValue) ? intValue : default(int);
                    case InputPrimitiveType { Kind: InputPrimitiveTypeKind.Int64 or InputPrimitiveTypeKind.UInt64 or InputPrimitiveTypeKind.Integer }:
                        return long.TryParse(strValue, out var longValue) ? longValue : default(long);
                    case InputPrimitiveType { Kind: InputPrimitiveTypeKind.Float32 or InputPrimitiveTypeKind.Float64 or InputPrimitiveTypeKind.Float }:
                        return double.TryParse(strValue, out var doubleValue) ? doubleValue : default(double);
                    case InputPrimitiveType { Kind: InputPrimitiveTypeKind.Decimal or InputPrimitiveTypeKind.Decimal128 }:
                        return decimal.TryParse(strValue, out var decimalValue) ? decimalValue : default(decimal);
                    case InputPrimitiveType { Kind: InputPrimitiveTypeKind.Boolean }:
                        return bool.TryParse(strValue, out var boolValue) ? boolValue : default(bool);
                    default:
                        return strValue;
                }
            }

            return originalValue;
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
                ? GetOrCreateProperty(vp.TargetProperty)
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
            Type: GetOrCreateType(header.Schema, header.Extensions?.Format, true)
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

            foreach (var (schema, (properties, compositionSchemas)) in _modelPropertiesCache)
            {
                properties.AddRange(schema.Properties.Select(GetOrCreateProperty));
                properties.AddRange(compositionSchemas.SelectMany(EnumerateBase).SelectMany(x => x.Properties).Select(GetOrCreateProperty));
            }

            foreach (var schema in schemas)
            {
                var derived = schema.Children?.Immediate.OfType<ObjectSchema>().Select(s => _modelsCache[s]);
                if (derived != null)
                {
                    _derivedModelsCache[schema].DerivedModels.AddRange(derived);
                }
                if (schema.Discriminator != null && schema.Children != null)
                {
                    foreach (var child in schema.Children.Immediate.OfType<ObjectSchema>())
                    {
                        if (child.DiscriminatorValue != null)
                        {
                            // TODO -- change it to the throw exception version when https://github.com/Azure/azure-rest-api-specs/issues/29320 and https://github.com/Azure/azure-rest-api-specs/issues/29321 are resolved
                            //_derivedModelsCache[schema].DiscriminatedSubtypes.Add(child.DiscriminatorValue, GetOrCreateModel(child));
                            _derivedModelsCache[schema].DiscriminatedSubtypes[child.DiscriminatorValue] = GetOrCreateModel(child);
                        }
                    }
                }
            }

            return schemas.Select(s => _modelsCache[s]).ToList();
        }

        private static IEnumerable<ObjectSchema> EnumerateBase(ObjectSchema? schema)
        {
            while (schema != null)
            {
                yield return schema;
                schema = GetBaseModelSchema(schema);
            }
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
            var discriminatedSubtypes = new Dictionary<string, InputModelType>();
            var baseModelSchema = GetBaseModelSchema(schema);
            var baseModel = baseModelSchema is not null ? GetOrCreateModel(baseModelSchema) : null;
            IReadOnlyList<ObjectSchema> compositeSchemas = schema.Parents?.Immediate?.OfType<ObjectSchema>().Where(s => s != baseModelSchema).ToArray() ?? Array.Empty<ObjectSchema>();
            var dictionarySchema = schema.Parents?.Immediate?.OfType<DictionarySchema>().FirstOrDefault();

            model = new InputModelType(
                Name: schema.Language.Default.Name,
                CrossLanguageDefinitionId: GetCrossLanguageDefinitionId(schema),
                Access: schema.Extensions?.Accessibility ?? (usage.HasFlag(SchemaTypeUsage.Model) ? "public" : "internal"),
                Deprecation: schema.Deprecated?.Reason,
                Description: schema.CreateDescription(),
                Usage: (schema.Extensions != null && schema.Extensions.Formats.Contains("multipart/form-data") ? InputModelTypeUsage.MultipartFormData : InputModelTypeUsage.None)
                        | GetUsage(usage),
                Properties: properties,
                BaseModel: baseModel,
                DerivedModels: derived,
                DiscriminatorValue: schema.DiscriminatorValue,
                DiscriminatorProperty: schema.Discriminator?.Property is { } discriminatorProperty ? GetOrCreateProperty(discriminatorProperty) : null,
                DiscriminatedSubtypes: discriminatedSubtypes,
                AdditionalProperties: dictionarySchema is not null ? GetOrCreateType(dictionarySchema.ElementType, false) : null)
            {
                Serialization = GetSerialization(schema),
                UseSystemTextJsonConverter = usage.HasFlag(SchemaTypeUsage.Converter),
                SpecName = schema.Language.Default.SerializedName ?? schema.Language.Default.Name
            };

            _modelsCache[schema] = model;
            _modelPropertiesCache[schema] = (properties, compositeSchemas);
            _derivedModelsCache[schema] = (derived, discriminatedSubtypes);

            return model;
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
            return result;
        }

        private static ObjectSchema? GetBaseModelSchema(ObjectSchema schema)
        => schema.Parents?.Immediate is { } parents
                ? parents.OfType<ObjectSchema>().FirstOrDefault(s => s.Discriminator is not null) ?? parents.OfType<ObjectSchema>().FirstOrDefault()
                : null;

        private InputModelProperty GetOrCreateProperty(Property property)
        {
            if (_propertiesCache.TryGetValue(property, out var inputProperty))
            {
                return inputProperty;
            }
            inputProperty = new(
                Name: property.Language.Default.Name,
                SerializedName: property.SerializedName,
                Description: property.Language.Default.Description,
                Type: GetOrCreateType(property),
                ConstantValue: property.Schema is ConstantSchema constantSchema ? CreateConstant(constantSchema, constantSchema.Extensions?.Format, property.IsNullable) : null,
                IsRequired: property.IsRequired,
                IsReadOnly: property.IsReadOnly,
                IsDiscriminator: property.IsDiscriminator ?? false)
            {
                FlattenedNames = property.FlattenedNames.ToList(),
            };
            _propertiesCache.Add(property, inputProperty);

            return inputProperty;
        }

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

        private static InputTypeSerialization GetSerialization(Schema schema)
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

            return new InputTypeSerialization(jsonFormat, xmlFormat);
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
            SchemaResponse schemaResponse => GetOrCreateType(schemaResponse.Schema, schemaResponse.IsNullable),
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

            return GetOrCreateType(schema, requestParameter.Extensions?.Format, Configuration.AzureArm ? requestParameter.IsNullable : requestParameter.IsNullable || !requestParameter.IsRequired);
        }

        private InputType GetOrCreateType(Property property)
        {
            var name = property.Schema.Name;
            object? elementType = null;
            if ((property.Schema is AnyObjectSchema || property.Schema is StringSchema) && true == property.Extensions?.TryGetValue("x-ms-format-element-type", out elementType))
            {
                return ToDataFactoryElementType(name, property.Extensions?.Format, property.IsNullable, (Schema)elementType!) ?? GetOrCreateType(property.Schema, property.Schema.Extensions?.Format, property.IsNullable);
            }
            else
            {
                return GetOrCreateType(property.Schema, GetPropertyFormat(property), property.IsNullable);
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

        private InputType GetOrCreateType(Schema schema, bool isNullable)
            => GetOrCreateType(schema, schema.Extensions?.Format, isNullable);

        private InputType GetOrCreateType(Schema schema, string? format, bool isNullable)
        {
            if (schema is ObjectSchema objectSchema)
            {
                var resolvedType = _modelsCache[objectSchema];
                return resolvedType.WithNullable(isNullable);
            }

            if (_enumsCache.TryGetValue(schema, out var enumType))
            {
                var resolvedType = enumType;
                return resolvedType.WithNullable(isNullable);
            }

            var type = CreateType(schema, format, isNullable);
            if (type.Serialization == InputTypeSerialization.Default)
            {
                return type with
                {
                    Serialization = GetSerialization(schema),
                };
            }

            return type;
        }

        private InputType CreateType(Schema schema, string? format, bool isNullable) => schema switch
        {
            // Respect schema.Type firstly since we might have applied the type change based on rename-mapping
            { Type: AllSchemaTypes.ArmId } => InputPrimitiveType.ResourceIdentifier.WithNullable(isNullable),
            { Type: AllSchemaTypes.Boolean } => InputPrimitiveType.Boolean.WithNullable(isNullable),
            { Type: AllSchemaTypes.Binary } => InputPrimitiveType.Stream.WithNullable(isNullable),
            ByteArraySchema { Type: AllSchemaTypes.ByteArray, Format: ByteArraySchemaFormat.Base64url } => InputPrimitiveType.Base64Url.WithNullable(isNullable),
            ByteArraySchema { Type: AllSchemaTypes.ByteArray, Format: ByteArraySchemaFormat.Byte } => InputPrimitiveType.Base64.WithNullable(isNullable),
            { Type: AllSchemaTypes.Credential } => InputPrimitiveType.String.WithNullable(isNullable),
            { Type: AllSchemaTypes.Date } => InputPrimitiveType.PlainDate.WithNullable(isNullable),
            DateTimeSchema { Type: AllSchemaTypes.DateTime, Format: DateTimeSchemaFormat.DateTime } => new InputDateTimeType(DateTimeKnownEncoding.Rfc3339, "dateTime", string.Empty, InputPrimitiveType.String).WithNullable(isNullable),
            DateTimeSchema { Type: AllSchemaTypes.DateTime, Format: DateTimeSchemaFormat.DateTimeRfc1123 } => new InputDateTimeType(DateTimeKnownEncoding.Rfc7231, "dateTime", string.Empty, InputPrimitiveType.String).WithNullable(isNullable),
            { Type: AllSchemaTypes.DateTime } => new InputDateTimeType(DateTimeKnownEncoding.Rfc3339, "dateTime", string.Empty, InputPrimitiveType.String).WithNullable(isNullable),
            DurationSchema when format == XMsFormat.DurationConstant => new InputDurationType(DurationKnownEncoding.Constant, "dateTime", string.Empty, InputPrimitiveType.String).WithNullable(isNullable),
            { Type: AllSchemaTypes.Duration } => new InputDurationType(DurationKnownEncoding.Iso8601, "duration", string.Empty, InputPrimitiveType.String).WithNullable(isNullable),
            NumberSchema { Type: AllSchemaTypes.Number, Precision: 32 } => InputPrimitiveType.Float32.WithNullable(isNullable),
            NumberSchema { Type: AllSchemaTypes.Number, Precision: 128 } => InputPrimitiveType.Decimal128.WithNullable(isNullable),
            { Type: AllSchemaTypes.Number } => InputPrimitiveType.Float64.WithNullable(isNullable),
            NumberSchema { Type: AllSchemaTypes.Integer, Precision: 64 } => InputPrimitiveType.Int64.WithNullable(isNullable),
            { Type: AllSchemaTypes.Integer } => InputPrimitiveType.Int32.WithNullable(isNullable),
            { Type: AllSchemaTypes.Time } => InputPrimitiveType.PlainTime.WithNullable(isNullable),
            { Type: AllSchemaTypes.Unixtime } => new InputDateTimeType(DateTimeKnownEncoding.UnixTimestamp, "dateTime", string.Empty, InputPrimitiveType.String).WithNullable(isNullable),
            { Type: AllSchemaTypes.Uri } => InputPrimitiveType.Url.WithNullable(isNullable),
            { Type: AllSchemaTypes.Uuid } => InputPrimitiveType.Uuid.WithNullable(isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.ArmId => InputPrimitiveType.ResourceIdentifier.WithNullable(isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.AzureLocation => InputPrimitiveType.AzureLocation.WithNullable(isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.ContentType => InputPrimitiveType.ContentType.WithNullable(isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.DateTime => new InputDateTimeType(DateTimeKnownEncoding.Rfc3339, "dateTime", string.Empty, InputPrimitiveType.String).WithNullable(isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.DateTimeRFC1123 => new InputDateTimeType(DateTimeKnownEncoding.Rfc7231, "dateTime", string.Empty, InputPrimitiveType.String).WithNullable(isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.DateTimeUnix => new InputDateTimeType(DateTimeKnownEncoding.UnixTimestamp, "dateTime", string.Empty, InputPrimitiveType.Int64).WithNullable(isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.DurationConstant => new InputDurationType(DurationKnownEncoding.Constant, "dateTime", string.Empty, InputPrimitiveType.String).WithNullable(isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.ETag => InputPrimitiveType.ETag.WithNullable(isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.IPAddress => InputPrimitiveType.IPAddress.WithNullable(isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.ResourceType => InputPrimitiveType.ResourceType.WithNullable(isNullable),
#pragma warning disable CS0618 // Type or member is obsolete
            { Type: AllSchemaTypes.String } when format == XMsFormat.RequestMethod => InputPrimitiveType.RequestMethod.WithNullable(isNullable),
            { Type: AllSchemaTypes.String } when format == XMsFormat.Object => InputPrimitiveType.Object.WithNullable(isNullable),
#pragma warning restore CS0618 // Type or member is obsolete
            { Type: AllSchemaTypes.String } => ToDataFactoryElementType(schema.Name, format, isNullable) ?? InputPrimitiveType.String.WithNullable(isNullable),
            { Type: AllSchemaTypes.Char } => InputPrimitiveType.Char.WithNullable(isNullable),
            { Type: AllSchemaTypes.Any } => InputPrimitiveType.Unknown.WithNullable(isNullable),
            { Type: AllSchemaTypes.AnyObject } => ToDataFactoryElementType(schema.Name, format, isNullable) ?? InputPrimitiveType.Unknown.WithNullable(isNullable),

            ConstantSchema constantSchema => CreateConstant(constantSchema, format, isNullable).Type,
            ChoiceSchema choiceSchema => GetInputTypeForChoiceSchema(choiceSchema),
            SealedChoiceSchema choiceSchema => GetInputTypeForChoiceSchema(choiceSchema),
            ArraySchema array => new InputListType(array.Name, array.Extensions?.IsEmbeddingsVector == true ? "Azure.Core.EmbeddingVector" : "TypeSpec.Array", GetOrCreateType(array.ElementType, array.NullableItems ?? false)).WithNullable(isNullable),
            DictionarySchema dictionary => new InputDictionaryType(dictionary.Name, InputPrimitiveType.String, GetOrCreateType(dictionary.ElementType, dictionary.NullableItems ?? false)).WithNullable(isNullable),
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
            if (objectSchema.Language.Default.Name.StartsWith("DataFactoryElement-"))
            {
                return CreateDataFactoryElementInputType(false, InputPrimitiveType.String);
            }
            return _modelsCache[objectSchema];
        }

        private InputType? ToDataFactoryElementType(string name, string? format, bool isNullable, Schema? elementType = null)
        {
            var type = typeof(DataFactoryElement<>);
            return format switch
            {
                XMsFormat.DataFactoryElementOfObject => CreateDataFactoryElementInputType(isNullable, InputPrimitiveType.Unknown),
                XMsFormat.DataFactoryElementOfString => CreateDataFactoryElementInputType(isNullable, InputPrimitiveType.String),
                XMsFormat.DataFactoryElementOfInt => CreateDataFactoryElementInputType(isNullable, InputPrimitiveType.Int32),
                XMsFormat.DataFactoryElementOfDouble => CreateDataFactoryElementInputType(isNullable, InputPrimitiveType.Float64),
                XMsFormat.DataFactoryElementOfBool => CreateDataFactoryElementInputType(isNullable, InputPrimitiveType.Boolean),
                XMsFormat.DataFactoryElementOfListOfT => CreateDataFactoryElementInputType(isNullable, new InputListType(name, "TypeSpec.Array", GetOrCreateType(elementType!, false))),
                XMsFormat.DataFactoryElementOfListOfString => CreateDataFactoryElementInputType(isNullable, new InputListType(name, "TypeSpec.Array", InputPrimitiveType.String)),
                XMsFormat.DataFactoryElementOfKeyValuePairs => CreateDataFactoryElementInputType(isNullable, new InputDictionaryType(name, InputPrimitiveType.String, InputPrimitiveType.String)),
                XMsFormat.DataFactoryElementOfDateTime => CreateDataFactoryElementInputType(isNullable, new InputDateTimeType(DateTimeKnownEncoding.Rfc3339, "dateTime", string.Empty, InputPrimitiveType.String)),
                XMsFormat.DataFactoryElementOfDuration => CreateDataFactoryElementInputType(isNullable, InputPrimitiveType.PlainTime),
                XMsFormat.DataFactoryElementOfUri => CreateDataFactoryElementInputType(isNullable, InputPrimitiveType.Url),
                XMsFormat.DataFactoryElementOfKeyObjectValuePairs => CreateDataFactoryElementInputType(isNullable, new InputDictionaryType(name, InputPrimitiveType.String, InputPrimitiveType.Unknown)),
                _ => null
            };
        }

        private static InputType CreateDataFactoryElementInputType(bool isNullable, InputType argumentType)
            => new InputModelType("DataFactoryElement", "Azure.Core.Resources.DataFactoryElement", null, null, null, InputModelTypeUsage.None, Array.Empty<InputModelProperty>(), null, Array.Empty<InputModelType>(), null, null, new Dictionary<string, InputModelType>(), null, new List<InputType> { argumentType }).WithNullable(isNullable);

        private InputConstant CreateConstant(ConstantSchema constantSchema, string? format, bool isNullable)
        {
            var rawValue = constantSchema.Value.Value;
            var valueType = CreateType(constantSchema.ValueType, format, isNullable);
            if (isNullable && rawValue == null)
            {
                return new InputConstant(null, valueType);
            }

            // normalize the value, because the "value" coming from the code model is always a string
            var kind = valueType.GetImplementType() switch
            {
                InputPrimitiveType primitiveType => primitiveType.Kind,
                InputEnumType enumType => enumType.ValueType.Kind,
                _ => throw new InvalidCastException($"Unknown value type {valueType.GetType()} for literal types")
            };

            object normalizedValue = kind switch
            {
                InputPrimitiveTypeKind.Boolean => bool.Parse(rawValue.ToString()!),
                InputPrimitiveTypeKind.Int32 => int.Parse(rawValue.ToString()!),
                InputPrimitiveTypeKind.Int64 => long.Parse(rawValue.ToString()!),
                InputPrimitiveTypeKind.Float32 => float.Parse(rawValue.ToString()!),
                InputPrimitiveTypeKind.Float64 => double.Parse(rawValue.ToString()!),
                _ => rawValue
            };

            return new InputConstant(normalizedValue, valueType);
        }

        private InputEnumType CreateEnumType(Schema schema, PrimitiveSchema choiceType, IEnumerable<ChoiceValue> choices, bool isExtensible)
        {
            var usage = _schemaUsageProvider.GetUsage(schema);
            var valueType = (InputPrimitiveType)CreateType(choiceType, schema.Extensions?.Format, false);
            var inputEnumType = new InputEnumType(
                Name: schema.Name,
                CrossLanguageDefinitionId: GetCrossLanguageDefinitionId(schema),
                Accessibility: schema.Extensions?.Accessibility ?? (usage.HasFlag(SchemaTypeUsage.Model) ? "public" : "internal"),
                Deprecated: schema.Deprecated?.Reason,
                Description: schema.CreateDescription(),
                Usage: GetUsage(usage),
                ValueType: valueType,
                Values: choices.Select(c => CreateEnumValue(c, valueType)).ToList(),
                IsExtensible: isExtensible
            )
            {
                Serialization = GetSerialization(schema)
            };
            return inputEnumType;
        }

        private static string GetCrossLanguageDefinitionId(Schema schema)
        {
            var ns = schema.Extensions?.Namespace;
            var name = schema.Language.Default.Name;
            if (ns == null)
            {
                return name;
            }

            return $"{ns}.{name}";
        }

        private static InputEnumTypeValue CreateEnumValue(ChoiceValue choiceValue, InputPrimitiveType valueType)
        {
            // in code model, the value of choices are defined to be strings. We need to convert them back to their real values
            var value = ConvertRawValue(valueType, choiceValue.Value);
            return new(
                Name: choiceValue.Language.Default.Name,
                Description: choiceValue.Language.Default.Description,
                Value: value!);
        }

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

                return new InputConstant(Value: parameter.ClientDefaultValue, Type: GetOrCreateType(parameter.Schema, parameter.IsNullable));
            }

            if (parameter is { Schema: ConstantSchema constantSchema } && (!Configuration.AzureArm || parameter.IsRequired))
            {
                return new InputConstant(Value: constantSchema.Value.Value, Type: GetOrCreateType(constantSchema.ValueType, constantSchema.Value.Value == null));
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
