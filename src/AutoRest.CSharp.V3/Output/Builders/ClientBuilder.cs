// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Models;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Responses;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;
using Azure.Core;
using Microsoft.CodeAnalysis;
using AzureResponse = Azure.Response;
using Diagnostic = AutoRest.CSharp.V3.Output.Models.Requests.Diagnostic;
using Request = AutoRest.CSharp.V3.Output.Models.Requests.Request;

namespace AutoRest.CSharp.V3.Output.Builders
{
    internal class ClientBuilder
    {
        private static string[] _knownResponseHeaders = new[]
        {
            "Date",
            "ETag",
            "x-ms-client-request-id",
            "x-ms-request-id"
        };

        private readonly BuildContext _context;
        private readonly SerializationBuilder _serializationBuilder;
        private readonly TypeFactory _typeFactory;

        public ClientBuilder(BuildContext context)
        {
            _context = context;
            _serializationBuilder = new SerializationBuilder();
            _typeFactory = _context.TypeFactory;
        }

        public (Client Client, RestClient RestClient) BuildClient(OperationGroup operationGroup)
        {
            var clientName = GetClientName(operationGroup, "Client");

            var clientParameters = operationGroup.Operations
                .SelectMany(op => op.Parameters.Concat(op.Requests.SelectMany(r => r.Parameters)))
                .Where(p => p.Implementation == ImplementationLocation.Client)
                .Distinct()
                .ToDictionary(p => p.Language.Default.Name, BuildParameter);

            List<OperationMethod> operationMethods = new List<OperationMethod>();
            foreach (Operation operation in operationGroup.Operations)
            {
                foreach (ServiceRequest serviceRequest in operation.Requests)
                {
                    HttpRequest? httpRequest = serviceRequest.Protocol.Http as HttpRequest;
                    if (httpRequest == null)
                    {
                        // Only handles HTTP requests
                        continue;
                    }

                    RestClientMethod method = BuildMethod(operation, clientName, clientParameters, httpRequest, serviceRequest.Parameters);
                    operationMethods.Add(new OperationMethod(operation, method));
                }
            }

            List<RestClientMethod> nextPageMethods = new List<RestClientMethod>();
            List<PagingInfo> pagingMethods = new List<PagingInfo>();
            List<LongRunningOperation> longRunningOperationMethods = new List<LongRunningOperation>();
            List<ClientMethod> clientMethods = new List<ClientMethod>();
            foreach ((Operation operation, RestClientMethod method) in operationMethods)
            {
                if (operation.IsLongRunning)
                {
                    longRunningOperationMethods.Add(BuildLongRunningOperation(operation, method));
                    continue;
                }

                Paging? paging = operation.Language.Default.Paging;
                if (paging != null)
                {
                    RestClientMethod? next = null;
                    if (paging.NextLinkOperation != null)
                    {
                        OperationMethod? nextOperationMethod = operationMethods.SingleOrDefault(m => m.Operation == paging.NextLinkOperation);

                        if (nextOperationMethod == null)
                        {
                            throw new Exception($"The x-ms-pageable operationName \"{paging.Group}_{paging.Member}\" for operation {operationGroup.Key}_{operation.Language.Default.Name} was not found.");
                        }

                        next = nextOperationMethod.Method;
                    }
                    // If there is no operationName or we didn't find an existing operation, we use the original method to construct the nextPageMethod.
                    RestClientMethod nextPageMethod = next ?? BuildNextPageMethod(method);
                    // Only add the method if it didn't previously exist
                    if (next == null)
                    {
                        nextPageMethods.Add(nextPageMethod);
                    }

                    if (!(method.Response.ResponseBody is ObjectResponseBody objectResponseBody))
                    {
                        throw new InvalidOperationException($"Method {method.Name} has to have a return value");
                    }

                    ITypeProvider implementation = objectResponseBody.Type.Implementation;
                    if (!(implementation is ObjectType objectType))
                    {
                        throw new InvalidOperationException($"The return type of {method.Name} has to be and object schema to be used in paging");
                    }

                    PagingInfo pagingInfo = GetPagingInfo(method, nextPageMethod, paging, objectType);
                    pagingMethods.Add(pagingInfo);

                    continue;
                }

                clientMethods.Add(new ClientMethod(
                    operation.CSharpName(),
                    method,
                    BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description)
                ));
            }

            RestClientMethod[] methods = operationMethods.Select(om => om.Method).Concat(nextPageMethods).ToArray();

            var restClient = new RestClient(
                BuilderHelpers.CreateTypeAttributes(GetClientName(operationGroup, "RestClient"), _context.DefaultNamespace, "internal"),
                operationGroup.Language.Default.Description,
                OrderParameters(clientParameters.Values),
                methods);

            var existingClient = _context.SourceInputModel.FindForOperationGroup(operationGroup.Key);
            var client = new Client(
                BuilderHelpers.CreateTypeAttributes(clientName, _context.DefaultNamespace, "public", existingClient?.ExistingType),
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description),
                restClient,
                clientMethods.ToArray(),
                pagingMethods.ToArray(),
                longRunningOperationMethods.ToArray());

            return (client, restClient);
        }

        private string GetClientName(OperationGroup operationGroup, string suffix)
        {
            var name = operationGroup.Language.Default.Name;
            name = string.IsNullOrEmpty(name) ? "Service" : name.ToCleanName();

            var operationsSuffix = "Operations";
            if (name.EndsWith(operationsSuffix) && name.Length > operationsSuffix.Length)
            {
                name = name.Substring(0, name.Length - operationsSuffix.Length);
            }

            return name + suffix;
        }

        private class OperationMethod
        {
            public OperationMethod(Operation operation, RestClientMethod method)
            {
                Operation = operation;
                Method = method;
            }

            public void Deconstruct(out Operation operation, out RestClientMethod method)
            {
                operation = Operation;
                method = Method;
            }

            public Operation Operation { get; }
            public RestClientMethod Method { get; }
        }

        private static Parameter[] OrderParameters(IEnumerable<Parameter> parameters) => parameters.OrderBy(p => p.DefaultValue != null).ToArray();

        private RestClientMethod BuildMethod(Operation operation, string clientName, IReadOnlyDictionary<string, Parameter> clientParameters, HttpRequest httpRequest, IEnumerable<RequestParameter> requestParameters)
        {
            HttpWithBodyRequest? httpRequestWithBody = httpRequest as HttpWithBodyRequest;
            Dictionary<string, PathSegment> uriParameters = new Dictionary<string, PathSegment>();
            Dictionary<string, PathSegment> pathParameters = new Dictionary<string, PathSegment>();
            List<QueryParameter> query = new List<QueryParameter>();
            List<RequestHeader> headers = new List<RequestHeader>();
            Dictionary<RequestParameter, Parameter> methodParameters = new Dictionary<RequestParameter, Parameter>();

            RequestBody? body = null;
            (RequestParameter, ReferenceOrConstant)? bodyParameter = null;
            RequestParameter[] parameters = operation.Parameters.Concat(requestParameters).ToArray();
            foreach (RequestParameter requestParameter in parameters)
            {
                string defaultName = requestParameter.Language.Default.Name;
                string serializedName = requestParameter.Language.Default.SerializedName ?? defaultName;
                ReferenceOrConstant constantOrReference;
                Schema valueSchema = requestParameter.Schema;

                if (requestParameter.Implementation == ImplementationLocation.Method)
                {
                    Parameter? parameter = null;
                    // TODO: always generate virtual paramters
                    if (!(requestParameter is VirtualParameter) &&
                        requestParameter.Schema is ConstantSchema constant)
                    {
                        constantOrReference = ParseConstant(constant);
                        valueSchema = constant.ValueType;
                    }
                    else
                    {
                        constantOrReference = parameter = BuildParameter(requestParameter);
                    }

                    if (parameter != null && requestParameter.Flattened != true)
                    {
                        methodParameters.Add(requestParameter, parameter);
                    }
                }
                else
                {
                    constantOrReference = clientParameters[requestParameter.Language.Default.Name];
                }

                if (requestParameter.Protocol.Http is HttpParameter httpParameter)
                {
                    SerializationFormat serializationFormat = BuilderHelpers.GetSerializationFormat(valueSchema);
                    bool skipEncoding = requestParameter.Extensions!.TryGetValue("x-ms-skip-url-encoding", out var value) && Convert.ToBoolean(value);
                    switch (httpParameter.In)
                    {
                        case ParameterLocation.Header:
                            headers.Add(new RequestHeader(serializedName, constantOrReference, serializationFormat));
                            break;
                        case ParameterLocation.Query:
                            query.Add(new QueryParameter(serializedName, constantOrReference, GetSerializationStyle(httpParameter, valueSchema), !skipEncoding, serializationFormat));
                            break;
                        case ParameterLocation.Path:
                            pathParameters.Add(serializedName, new PathSegment(constantOrReference, !skipEncoding, serializationFormat));
                            break;
                        case ParameterLocation.Body:
                            bodyParameter = (requestParameter, constantOrReference);
                            break;
                        case ParameterLocation.Uri:
                            if (defaultName == "$host")
                            {
                                skipEncoding = true;
                            }
                            uriParameters[serializedName] = new PathSegment(constantOrReference, !skipEncoding, serializationFormat);
                            break;
                    }
                }
            }


            if (bodyParameter is var (bodyRequestParameter, bodyParameterValue))
            {
                Debug.Assert(httpRequestWithBody != null);
                if (httpRequestWithBody.KnownMediaType == KnownMediaType.Binary)
                {
                    body = new BinaryRequestBody(bodyParameterValue);
                }
                else
                {
                    var serialization = _serializationBuilder.Build(
                        httpRequestWithBody.KnownMediaType,
                        bodyRequestParameter.Schema,
                        bodyParameterValue.Type);

                    // This method has a flattened body
                    if (bodyRequestParameter.Flattened == true)
                    {
                        var objectType = (ObjectType)_context.Library.FindTypeForSchema(bodyRequestParameter.Schema);
                        var virtualParameters = requestParameters.OfType<VirtualParameter>().ToArray();

                        List<ObjectPropertyInitializer> initializationMap = new List<ObjectPropertyInitializer>();
                        foreach (var virtualParameter in virtualParameters)
                        {
                            var actualParameter = methodParameters[virtualParameter];

                            initializationMap.Add(new ObjectPropertyInitializer(
                                objectType.GetPropertyForSchemaProperty(virtualParameter.TargetProperty, true),
                                actualParameter));
                        }


                        body = new FlattenedSchemaRequestBody(objectType, initializationMap.ToArray(), serialization);
                    }
                    else
                    {
                        body = new SchemaRequestBody(bodyParameterValue, serialization);
                    }
                }
            }

            Request request = new Request(
                httpRequest.Method.ToCoreRequestMethod() ?? RequestMethod.Get,
                ToPathParts(httpRequest.Uri, uriParameters),
                ToPathParts(httpRequest.Path, pathParameters),
                query.ToArray(),
                headers.ToArray(),
                body
            );

            ResponseBody? responseBody = null;
            ResponseHeaderGroupType? responseHeaderModel = null;
            string operationName = operation.CSharpName();

            //TODO: Handle multiple responses: https://github.com/Azure/autorest.csharp/issues/413
            ServiceResponse? response = null;

            // if operation is a long-running operation than we're generating an initial call here so find a response with non 200/204 code
            // fallback to the first on otherwise

            if (operation.IsLongRunning)
            {
                response = operation.LongRunningInitialResponse;
            }

            response ??= operation.Responses.FirstOrDefault();

            Response clientResponse;
            if (response != null)
            {
                // Ignore response body and headers for LROs as the ArmOperationHelpers figures out them dynamically
                if (!operation.IsLongRunning)
                {
                    responseBody = BuildResponseBody(response);

                    responseHeaderModel = BuildResponseHeaderModel(operation, response);
                }

                var responseCodes = new HashSet<int>(response.HttpResponse.IntStatusCodes);

                // Long running operations can respond with both initial or final status code
                if (operation.IsLongRunning)
                {
                    foreach (var statusCode in operation.LongRunningFinalResponse.HttpResponse.IntStatusCodes)
                    {
                        responseCodes.Add(statusCode);
                    }
                }

                clientResponse = new Response(
                    responseBody,
                    responseCodes.ToArray(),
                    responseHeaderModel
                );
            }
            else
            {
                // Special case for httpInfrastructure testServer swagger, service method always fails
                clientResponse = new Response(null, Array.Empty<int>(), null);
            }

            return new RestClientMethod(
                operationName,
                BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description),
                request,
                OrderParameters(methodParameters.Values),
                clientResponse,
                new Diagnostic($"{clientName}.{operationName}", Array.Empty<DiagnosticAttribute>())
            );
        }

        private ResponseBody? BuildResponseBody(ServiceResponse response)
        {
            ResponseBody? responseBody = null;
            if (response is SchemaResponse schemaResponse)
            {
                Schema schema = schemaResponse.Schema is ConstantSchema constantSchema ? constantSchema.ValueType : schemaResponse.Schema;
                CSharpType responseType = TypeFactory.GetOutputType(_typeFactory.CreateType(schema, isNullable: false));

                ObjectSerialization serialization = _serializationBuilder.Build(response.HttpResponse.KnownMediaType, schema, responseType);

                responseBody = new ObjectResponseBody(responseType, serialization);
            }
            else if (response is BinaryResponse)
            {
                responseBody = new StreamResponseBody();
            }

            return responseBody;
        }

        private static RestClientMethod BuildNextPageMethod(RestClientMethod method)
        {
            var nextPageUrlParameter = new Parameter(
                "nextLink",
                "The URL to the next page of results.",
                typeof(string),
                null,
                true);
            var headerParameterNames = method.Request.Headers.Where(h => !h.Value.IsConstant).Select(h => h.Value.Reference.Name).ToArray();
            var parameters = method.Parameters.Where(p =>  headerParameterNames.Contains(p.Name)).Append(nextPageUrlParameter).ToArray();
            var request = new Request(
                method.Request.HttpMethod,
                new[] { new PathSegment(nextPageUrlParameter, false, SerializationFormat.Default),  },
                Array.Empty<PathSegment>(),
                Array.Empty<QueryParameter>(),
                method.Request.Headers,
                null
            );

            return new RestClientMethod(
                $"{method.Name}NextPage",
                method.Description,
                request,
                parameters,
                method.Response,
                method.Diagnostics);
        }

        private PagingInfo GetPagingInfo(RestClientMethod method, RestClientMethod nextPageMethod, Paging paging, ObjectType type)
        {
            string? nextLinkName = paging.NextLinkName;
            string itemName = paging.ItemName ?? "value";

            ObjectTypeProperty itemProperty = type.GetPropertyBySerializedName(itemName);

            ObjectTypeProperty? nextLinkProperty = null;
            if (nextLinkName != null)
            {
                nextLinkProperty = type.GetPropertyBySerializedName(nextLinkName);
            }

            if (itemProperty.SchemaProperty?.Schema is ArraySchema arraySchema)
            {
                CSharpType itemType = _typeFactory.CreateType(arraySchema.ElementType, false);
                return new PagingInfo(method, nextPageMethod, method.Name, nextLinkProperty?.Declaration.Name, itemProperty.Declaration.Name, itemType);
            }

            throw new InvalidOperationException($"{itemName} property has to be an array schema, actual {itemProperty.SchemaProperty}");
        }

        private LongRunningOperation BuildLongRunningOperation(Operation operation, RestClientMethod startMethod)
        {
            var originalResponseParameter = new Parameter(
                "originalResponse",
                "The original response from starting the operation.",
                typeof(AzureResponse),
                null,
                true);
            var httpMessageParameter = new Parameter(
                "createOriginalHttpMessage",
                "Creates the HTTP message used for the original request.",
                typeof(Func<HttpMessage>),
                null,
                true);

            string name = operation.CSharpName();

            var finalStateVia = operation.LongRunningFinalStateVia switch
            {
                "azure-async-operation" => OperationFinalStateVia.AzureAsyncOperation,
                "location" => OperationFinalStateVia.Location,
                "original-uri" => OperationFinalStateVia.OriginalUri,
                null => OperationFinalStateVia.Location,
                _ => throw new ArgumentException($"Unknown final-state-via value: {operation.LongRunningFinalStateVia}")
            };

            ServiceResponse finalResponse = operation.LongRunningFinalResponse;

            return new LongRunningOperation(
                startMethod,
                new Response(BuildResponseBody(finalResponse),
                    finalResponse.HttpResponse.IntStatusCodes,
                    BuildResponseHeaderModel(operation, finalResponse)),
                name,
                new[] { originalResponseParameter, httpMessageParameter },
                finalStateVia);
        }

        private Parameter BuildParameter(RequestParameter requestParameter)
        {
            var type = _typeFactory.CreateType(requestParameter.Schema, requestParameter.IsNullable());

            return new Parameter(
                requestParameter.CSharpName(),
                CreateDescription(requestParameter),
                TypeFactory.GetInputType(type),
                ParseConstant(requestParameter),
                requestParameter.Required == true);
        }

        private ResponseHeaderGroupType? BuildResponseHeaderModel(Operation operation, ServiceResponse response)
        {
            var httpResponseHeaders = response.HttpResponse.Headers
                .Where(h => !_knownResponseHeaders.Contains(h.Header, StringComparer.InvariantCultureIgnoreCase))
                .ToArray();

            if (!httpResponseHeaders.Any())
            {
                return null;
            }

            ResponseHeader CreateResponseHeader(HttpResponseHeader header) =>
                new ResponseHeader(header.Header.ToCleanName(), header.Header, _typeFactory.CreateType(header.Schema, true));

            string operationName = operation.CSharpName();

            return new ResponseHeaderGroupType(
                BuilderHelpers.CreateTypeAttributes(operationName + "Headers", _context.DefaultNamespace, "internal"),
                $"Header model for {operationName}",
                httpResponseHeaders.Select(CreateResponseHeader).ToArray()
                );
        }

        private static QuerySerializationStyle GetSerializationStyle(HttpParameter httpParameter, Schema valueSchema)
        {
            Debug.Assert(httpParameter.In == ParameterLocation.Query);

            switch (httpParameter.Style)
            {
                case null:
                case SerializationStyle.Form:
                    return valueSchema is ArraySchema ? QuerySerializationStyle.CommaDelimited : QuerySerializationStyle.Simple;
                case SerializationStyle.PipeDelimited:
                    return QuerySerializationStyle.PipeDelimited;
                case SerializationStyle.SpaceDelimited:
                    return QuerySerializationStyle.SpaceDelimited;
                case SerializationStyle.TabDelimited:
                    return QuerySerializationStyle.TabDelimited;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static PathSegment[] ToPathParts(string httpRequestUri, Dictionary<string, PathSegment> parameters)
        {
            PathSegment TextSegment(string text)
            {
                return new PathSegment(BuilderHelpers.StringConstant(text), false, SerializationFormat.Default);
            }

            List<PathSegment> host = new List<PathSegment>();
            foreach ((string text, bool isLiteral) in StringExtensions.GetPathParts(httpRequestUri))
            {
                host.Add(isLiteral ? TextSegment(text) : parameters[text]);
            }

            return host.ToArray();
        }

        private Constant ParseConstant(ConstantSchema constant) =>
            BuilderHelpers.ParseConstant(constant.Value.Value, _typeFactory.CreateType(constant.ValueType, constant.Value.Value == null));

        private Constant? ParseConstant(RequestParameter parameter)
        {
            if (parameter.ClientDefaultValue != null)
            {
                CSharpType constantTypeReference = _typeFactory.CreateType(parameter.Schema, parameter.IsNullable());
                return BuilderHelpers.ParseConstant(parameter.ClientDefaultValue, constantTypeReference);
            }

            if (parameter.Schema is ConstantSchema constantSchema)
            {
                return ParseConstant(constantSchema);
            }

            return null;
        }

        private static string CreateDescription(RequestParameter requestParameter)
        {
            return string.IsNullOrWhiteSpace(requestParameter.Language.Default.Description) ?
                $"The {requestParameter.Schema.Name} to use." :
                BuilderHelpers.EscapeXmlDescription(requestParameter.Language.Default.Description);
        }
    }
}
