﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
using Diagnostic = AutoRest.CSharp.V3.Output.Models.Requests.Diagnostic;
using Request = AutoRest.CSharp.V3.Output.Models.Requests.Request;
using AzureResponse = Azure.Response;

namespace AutoRest.CSharp.V3.Output.Builders
{
    internal class ClientBuilder
    {
        private readonly BuildContext _context;
        private readonly SerializationBuilder _serializationBuilder;
        private readonly TypeFactory _typeFactory;

        public ClientBuilder(BuildContext context)
        {
            _context = context;
            _serializationBuilder = new SerializationBuilder(context.TypeFactory);
            _typeFactory = _context.TypeFactory;
        }

        public (Client Client, RestClient RestClient) BuildClient(OperationGroup operationGroup)
        {
            var clientName = GetClientName(operationGroup, "Client");

            var allClientParameters = operationGroup.Operations
                .SelectMany(op => op.Parameters.Concat(op.Requests.SelectMany(r => r.Parameters)))
                .Where(p => p.Implementation == ImplementationLocation.Client)
                .Distinct();
            Dictionary<string, Parameter> clientParameters = new Dictionary<string, Parameter>();
            foreach (RequestParameter clientParameter in allClientParameters)
            {
                clientParameters[clientParameter.Language.Default.Name] = BuildParameter(clientParameter);
            }

            Dictionary<string, OperationMethod> operationMethods = new Dictionary<string, OperationMethod>(StringComparer.InvariantCultureIgnoreCase);
            foreach (Operation operation in operationGroup.Operations)
            {
                RestClientMethod? method = BuildMethod(operation, clientName, clientParameters);
                if (method != null)
                {
                    operationMethods.Add(operation.Language.Default.Name, new OperationMethod(operation, method));
                }
            }

            List<RestClientMethod> nextPageMethods = new List<RestClientMethod>();
            List<PagingInfo> pagingMethods = new List<PagingInfo>();
            List<LongRunningOperation> longRunningOperationMethods = new List<LongRunningOperation>();
            List<ClientMethod> clientMethods = new List<ClientMethod>();
            foreach ((string operationName, (Operation operation, RestClientMethod method)) in operationMethods)
            {
                Paging? paging = operation.Language.Default.Paging;
                if (paging != null)
                {
                    RestClientMethod? next = null;
                    if (paging.NextLinkOperation != null)
                    {
                        //TODO: This assumes the operation is within this operationGroup
                        string nextOperationName = paging.NextLinkOperation.Language.Default.Name;
                        if (!operationMethods.TryGetValue(nextOperationName, out OperationMethod? nextOperationMethod))
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

                // For some reason, booleans in dictionaries are deserialized as string instead of bool.
                bool longRunningOperation = Convert.ToBoolean(operation.Extensions.GetValue<string>("x-ms-long-running-operation") ?? "false");
                if (longRunningOperation)
                {
                    Response originalResponse = method.Response;
                    operationMethods[operationName].Method = new RestClientMethod(
                        method.Name,
                        method.Description,
                        method.Request,
                        method.Parameters,
                        new Response(null, originalResponse.SuccessfulStatusCodes, null),
                        method.Diagnostics
                    );

                    IDictionary<object, object> options = operation.Extensions.GetValue<IDictionary<object, object>>("x-ms-long-running-operation-options")
                                                          ?? ImmutableDictionary<object, object>.Empty;
                    LongRunningOperation longRunningOperationMethod = BuildLongRunningOperation(method, originalResponse, options);
                    longRunningOperationMethods.Add(longRunningOperationMethod);

                    continue;
                }

                clientMethods.Add(new ClientMethod(
                    operation.CSharpName(),
                    method,
                    BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description)
                ));
            }

            RestClientMethod[] methods = operationMethods.Select(om => om.Value.Method).Concat(nextPageMethods).ToArray();

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
            if (name.EndsWith(operationsSuffix))
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
            public RestClientMethod Method { get; set; }
        }

        private static Parameter[] OrderParameters(IEnumerable<Parameter> parameters) => parameters.OrderBy(p => p.DefaultValue != null).ToArray();

        private RestClientMethod? BuildMethod(Operation operation, string clientName, IReadOnlyDictionary<string, Parameter> clientParameters)
        {
            //TODO: Handle multiple requests: https://github.com/Azure/autorest.csharp/issues/455
            ServiceRequest? serviceRequest = operation.Requests.FirstOrDefault();
            HttpRequest? httpRequest = serviceRequest?.Protocol.Http as HttpRequest;
            //TODO: Handle multiple responses: https://github.com/Azure/autorest.csharp/issues/413
            ServiceResponse? response = operation.Responses.FirstOrDefault();
            HttpResponse? httpResponse = response?.Protocol.Http as HttpResponse;
            if (httpRequest == null)
            {
                return null;
            }

            HttpWithBodyRequest? httpRequestWithBody = httpRequest as HttpWithBodyRequest;
            Dictionary<string, PathSegment> uriParameters = new Dictionary<string, PathSegment>();
            Dictionary<string, PathSegment> pathParameters = new Dictionary<string, PathSegment>();
            List<QueryParameter> query = new List<QueryParameter>();
            List<RequestHeader> headers = new List<RequestHeader>();
            List<Parameter> methodParameters = new List<Parameter>();

            RequestBody? body = null;
            RequestParameter[] parameters = operation.Parameters.Concat(serviceRequest?.Parameters ?? Enumerable.Empty<RequestParameter>()).ToArray();
            foreach (RequestParameter requestParameter in parameters)
            {
                string defaultName = requestParameter.Language.Default.Name;
                string serializedName = requestParameter.Language.Default.SerializedName ?? defaultName;
                ParameterOrConstant constantOrParameter;
                Schema valueSchema = requestParameter.Schema;

                if (requestParameter.Implementation == ImplementationLocation.Method)
                {
                    switch (requestParameter.Schema)
                    {
                        case ConstantSchema constant:
                            constantOrParameter = ParseConstant(constant);
                            valueSchema = constant.ValueType;
                            break;
                        case BinarySchema _:
                            // skip
                            continue;
                        default:
                            constantOrParameter = BuildParameter(requestParameter);
                            break;
                    }

                    if (!constantOrParameter.IsConstant)
                    {
                        methodParameters.Add(constantOrParameter.Parameter);
                    }
                }
                else
                {
                    constantOrParameter = clientParameters[requestParameter.Language.Default.Name];
                }

                if (requestParameter.Protocol.Http is HttpParameter httpParameter)
                {
                    SerializationFormat serializationFormat = BuilderHelpers.GetSerializationFormat(valueSchema);
                    bool skipEncoding = requestParameter.Extensions!.TryGetValue("x-ms-skip-url-encoding", out var value) && Convert.ToBoolean(value);
                    switch (httpParameter.In)
                    {
                        case ParameterLocation.Header:
                            headers.Add(new RequestHeader(serializedName, constantOrParameter, serializationFormat));
                            break;
                        case ParameterLocation.Query:
                            query.Add(new QueryParameter(serializedName, constantOrParameter, GetSerializationStyle(httpParameter, valueSchema), !skipEncoding, serializationFormat));
                            break;
                        case ParameterLocation.Path:
                            pathParameters.Add(serializedName, new PathSegment(constantOrParameter, !skipEncoding, serializationFormat));
                            break;
                        case ParameterLocation.Body:
                            Debug.Assert(httpRequestWithBody != null);
                            var serialization = _serializationBuilder.Build(httpRequestWithBody.KnownMediaType, requestParameter.Schema, requestParameter.IsNullable());
                            body = new RequestBody(constantOrParameter, serialization);
                            break;
                        case ParameterLocation.Uri:
                            if (defaultName == "$host")
                            {
                                skipEncoding = true;
                            }
                            uriParameters[serializedName] = new PathSegment(constantOrParameter, !skipEncoding, serializationFormat);
                            break;
                    }
                }
            }

            if (httpRequestWithBody != null)
            {
                headers.AddRange(httpRequestWithBody.MediaTypes.Select(mediaType => new RequestHeader("Content-Type", BuilderHelpers.StringConstant(mediaType))));
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
            if (response is SchemaResponse schemaResponse && httpResponse != null)
            {
                Schema schema = schemaResponse.Schema is ConstantSchema constantSchema ? constantSchema.ValueType : schemaResponse.Schema;
                CSharpType responseType = _typeFactory.CreateType(schema, isNullable: false);

                ObjectSerialization serialization = _serializationBuilder.Build(httpResponse.KnownMediaType, schema, isNullable: false);

                responseBody = new ObjectResponseBody(responseType, serialization);
            }
            else if (response is BinaryResponse)
            {
                responseBody = new StreamResponseBody();
            }

            Response clientResponse = new Response(
                responseBody,
                httpResponse?.StatusCodes.Select(ToStatusCode).ToArray() ?? Array.Empty<int>(),
                BuildResponseHeaderModel(operation, httpResponse)
            );

            string operationName = operation.CSharpName();
            return new RestClientMethod(
                operationName,
                BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description),
                request,
                OrderParameters(methodParameters),
                clientResponse,
                new Diagnostic($"{clientName}.{operationName}", Array.Empty<DiagnosticAttribute>())
            );
        }

        private static RestClientMethod BuildNextPageMethod(RestClientMethod method)
        {
            var nextPageUrlParameter = new Parameter(
                "nextLink",
                "The URL to the next page of results.",
                new CSharpType(typeof(string)),
                null,
                true);
            var headerParameterNames = method.Request.Headers.Where(h => !h.Value.IsConstant).Select(h => h.Value.Parameter.Name).ToArray();
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

            if (itemProperty.SchemaProperty.Schema is ArraySchema arraySchema)
            {
                CSharpType itemType = _typeFactory.CreateType(arraySchema.ElementType, false);
                return new PagingInfo(method, nextPageMethod, method.Name, nextLinkProperty?.DeclarationOptions.Name, itemProperty.DeclarationOptions.Name, itemType);
            }

            throw new InvalidOperationException($"{itemName} property has to be an array schema, actual {itemProperty.SchemaProperty}");
        }

        private static LongRunningOperation BuildLongRunningOperation(RestClientMethod method, Response originalResponse, IDictionary<object, object> options)
        {
            var originalResponseParameter = new Parameter(
                "originalResponse",
                "The original response from starting the operation.",
                new CSharpType(typeof(AzureResponse)),
                null,
                true);
            var httpMessageParameter = new Parameter(
                "createOriginalHttpMessage",
                "Creates the HTTP message used for the original request.",
                new CSharpType(typeof(Func<>), new CSharpType(typeof(HttpMessage))),
                null,
                true);
            OperationFinalStateVia finalStateVia = GetFinalStateVia(options.GetValue<string>("final-state-via"));
            string name = $"{method.Name}Operation";
            return new LongRunningOperation(method, originalResponse, name, new[] { originalResponseParameter, httpMessageParameter }, finalStateVia);
        }

        private static OperationFinalStateVia GetFinalStateVia(string? rawValue) => rawValue switch
        {
            "azure-async-operation" => OperationFinalStateVia.AzureAsyncOperation,
            "location" => OperationFinalStateVia.Location,
            "original-uri" => OperationFinalStateVia.OriginalUri,
            null => OperationFinalStateVia.Location,
            _ => throw new ArgumentException($"Unknown final-state-via value: {rawValue}")
        };

        private Parameter BuildParameter(RequestParameter requestParameter) => new Parameter(
            requestParameter.CSharpName(),
            CreateDescription(requestParameter),
            _typeFactory.CreateInputType(requestParameter.Schema, requestParameter.IsNullable()),
            ParseConstant(requestParameter),
            requestParameter.Required == true);

        private ResponseHeaderGroupType? BuildResponseHeaderModel(Operation operation, HttpResponse? httpResponse)
        {
            if (httpResponse == null || !httpResponse.Headers.Any())
            {
                return null;
            }

            ResponseHeader CreateResponseHeader(HttpResponseHeader header) =>
                new ResponseHeader(header.Header.ToCleanName(), header.Header, _typeFactory.CreateType(header.Schema, true));

            string operationName = operation.CSharpName();

            return new ResponseHeaderGroupType(
                BuilderHelpers.CreateTypeAttributes(operationName + "Headers", _context.DefaultNamespace, "internal"),
                $"Header model for {operationName}",
                httpResponse.Headers.Select(CreateResponseHeader).ToArray()
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

        private static int ToStatusCode(StatusCodes arg) => int.Parse(arg.ToString().Trim('_'));

        private static string CreateDescription(RequestParameter requestParameter)
        {
            return string.IsNullOrWhiteSpace(requestParameter.Language.Default.Description) ?
                $"The {requestParameter.Schema.Name} to use." :
                BuilderHelpers.EscapeXmlDescription(requestParameter.Language.Default.Description);
        }
    }
}
