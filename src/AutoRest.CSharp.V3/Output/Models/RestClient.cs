﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Output.Builders;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Responses;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;
using Azure.Core;
using Request = AutoRest.CSharp.V3.Output.Models.Requests.Request;

namespace AutoRest.CSharp.V3.Output.Models
{
    internal class RestClient: ClientBase
    {
        protected const string RestClientSuffix = "RestClient";

        private readonly OperationGroup _operationGroup;
        private readonly BuildContext _context;
        private readonly Dictionary<string, Parameter> _parameters;
        private readonly SerializationBuilder _serializationBuilder;
        private Dictionary<ServiceRequest, RestClientMethod>? _requestMethods;
        private Dictionary<ServiceRequest, RestClientMethod>? _nextPageMethods;
        private RestClientMethod[]? _allMethods;

        public RestClient(OperationGroup operationGroup, BuildContext context) : base(context)
        {
            _operationGroup = operationGroup;
            _context = context;
            _parameters = operationGroup.Operations
                .SelectMany(op => op.Parameters.Concat(op.Requests.SelectMany(r => r.Parameters)))
                .Where(p => p.Implementation == ImplementationLocation.Client)
                .Distinct()
                .ToDictionary(p => p.Language.Default.Name, BuildClientParameter);
            _serializationBuilder = new SerializationBuilder();

            Parameters = OrderParameters(_parameters.Values);

            var mainClient = context.Library.FindClient(operationGroup);

            ClientPrefix = GetClientPrefix(mainClient?.Declaration.Name ?? operationGroup.Language.Default.Name);
            DefaultName = ClientPrefix + RestClientSuffix;
            Description = "";
        }

        public Parameter[] Parameters { get; }
        public string Description { get; }
        public RestClientMethod[] Methods => _allMethods ??= BuildAllMethods().ToArray();
        public string ClientPrefix { get; }
        protected override string DefaultName { get; }
        protected override string DefaultAccessibility { get; } = "internal";

        private IEnumerable<RestClientMethod> BuildAllMethods()
        {
            foreach (var operation in _operationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod method = GetOperationMethod(serviceRequest);
                    yield return method;
                }
            }

            foreach (var operation in _operationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    // remove duplicates when GetNextPage method is not autogenerated
                    if (GetNextOperationMethod(serviceRequest) is {} nextOperationMethod &&
                        operation.Language.Default.Paging?.NextLinkOperation == null)
                    {
                        yield return nextOperationMethod;
                    }
                }
            }
        }


        private Dictionary<ServiceRequest, RestClientMethod> EnsureNormalMethods()
        {
            if (_requestMethods != null)
            {
                return _requestMethods;
            }

            _requestMethods = new Dictionary<ServiceRequest, RestClientMethod>();

            foreach (var operation in _operationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    if (!(serviceRequest.Protocol.Http is HttpRequest httpRequest))
                    {
                        continue;
                    }

                    var headerModel = _context.Library.FindHeaderModel(operation);
                    _requestMethods.Add(serviceRequest, BuildMethod(operation, httpRequest, serviceRequest.Parameters, headerModel));
                }
            }

            return _requestMethods;
        }

        private Dictionary<ServiceRequest, RestClientMethod> EnsureGetNextPageMethods()
        {
            if (_nextPageMethods != null)
            {
                return _nextPageMethods;
            }

            _nextPageMethods = new Dictionary<ServiceRequest, RestClientMethod>();
            foreach (var operation in _operationGroup.Operations)
            {
                var paging = operation.Language.Default.Paging;
                if (paging == null)
                {
                    continue;
                }
                foreach (var serviceRequest in operation.Requests)
                {
                    RestClientMethod? nextMethod = null;
                    if (paging.NextLinkOperation != null)
                    {
                        nextMethod = GetOperationMethod(paging.NextLinkOperation.Requests.Single());
                    }
                    else if (paging.NextLinkName != null)
                    {
                        var method = GetOperationMethod(serviceRequest);
                        nextMethod = BuildNextPageMethod(method, operation);
                    }

                    if (nextMethod != null)
                    {
                        _nextPageMethods.Add(serviceRequest, nextMethod);
                    }
                }
            }

            return _nextPageMethods;
        }

        private RestClientMethod BuildMethod(Operation operation, HttpRequest httpRequest, ICollection<RequestParameter> requestParameters, ResponseHeaderGroupType? responseHeaderModel)
        {
            HttpWithBodyRequest? httpRequestWithBody = httpRequest as HttpWithBodyRequest;
            Dictionary<string, PathSegment> uriParameters = new Dictionary<string, PathSegment>();
            Dictionary<string, PathSegment> pathParameters = new Dictionary<string, PathSegment>();
            List<QueryParameter> query = new List<QueryParameter>();
            List<RequestHeader> headers = new List<RequestHeader>();
            Dictionary<RequestParameter, ReferenceOrConstant> allParameters = new Dictionary<RequestParameter, ReferenceOrConstant>();
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
                    // TODO: always generate virtual parameters
                    if (!(requestParameter is VirtualParameter) &&
                        requestParameter.Schema is ConstantSchema constant)
                    {
                        constantOrReference = ParseConstant(constant);
                        valueSchema = constant.ValueType;
                    }
                    else
                    {
                        parameter = BuildParameter(requestParameter);

                        if (requestParameter.GroupedBy is RequestParameter groupedByParameter)
                        {
                            var groupModel = (ObjectType)_context.TypeFactory.CreateType(groupedByParameter.Schema, false).Implementation;
                            var property = groupModel.GetPropertyForGroupedParameter(requestParameter);

                            constantOrReference = new Reference($"{groupedByParameter.CSharpName()}.{property.Declaration.Name}", property.Declaration.Type);
                        }
                        else
                        {
                            constantOrReference = parameter;
                        }
                    }

                    allParameters.Add(requestParameter, constantOrReference);

                    if (parameter != null &&
                        requestParameter.Flattened != true &&
                        requestParameter.GroupedBy == null)
                    {
                        methodParameters.Add(requestParameter, parameter);
                    }
                }
                else
                {
                    constantOrReference = _parameters[requestParameter.Language.Default.Name];
                }

                if (requestParameter.Protocol.Http is HttpParameter httpParameter)
                {
                    SerializationFormat serializationFormat = BuilderHelpers.GetSerializationFormat(valueSchema);
                    bool skipEncoding = requestParameter.Extensions!.TryGetValue("x-ms-skip-url-encoding", out var value) && Convert.ToBoolean(value);
                    switch (httpParameter.In)
                    {
                        case ParameterLocation.Header:
                            headers.Add(new RequestHeader(serializedName, constantOrReference, GetSerializationStyle(httpParameter, valueSchema), serializationFormat));
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
                            uriParameters.Add(serializedName, new PathSegment(constantOrReference, !skipEncoding, serializationFormat, isRaw: true));
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
                else if (httpRequestWithBody.KnownMediaType == KnownMediaType.Text)
                {
                    body = new TextRequestBody(bodyParameterValue);
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
                            var actualParameter = allParameters[virtualParameter];

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

            PathSegment[] pathSegments = GetPathSegments(httpRequest.Uri, uriParameters, isRaw: true)
                .Concat(GetPathSegments(httpRequest.Path, pathParameters))
                .ToArray();
            Request request = new Request(
                httpRequest.Method.ToCoreRequestMethod() ?? RequestMethod.Get,
                pathSegments,
                query.ToArray(),
                headers.ToArray(),
                body
            );

            string operationName = operation.CSharpName();

            List<Response> clientResponse = new List<Response>();

            if (operation.IsLongRunning)
            {
                // Ignore response body and headers for LROs as the ArmOperationHelpers figures out them dynamically
                responseHeaderModel = null;
            }

            foreach (var response in operation.Responses)
            {
                clientResponse.Add(new Response(
                    operation.IsLongRunning ? null : BuildResponseBody(response),
                    response.HttpResponse.IntStatusCodes.ToArray()
                ));
            }

            var responseType = ReduceResponses(clientResponse);

            return new RestClientMethod(
                operationName,
                BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description),
                responseType,
                request,
                OrderParameters(methodParameters.Values),
                clientResponse.ToArray(),
                responseHeaderModel
            );
        }

        private ResponseBody? BuildResponseBody(ServiceResponse response)
        {
            ResponseBody? responseBody = null;
            if (response is SchemaResponse schemaResponse)
            {
                Schema schema = schemaResponse.Schema is ConstantSchema constantSchema ? constantSchema.ValueType : schemaResponse.Schema;
                CSharpType responseType = TypeFactory.GetOutputType(_context.TypeFactory.CreateType(schema, isNullable: false));

                ObjectSerialization serialization = _serializationBuilder.Build(response.HttpResponse.KnownMediaType, schema, responseType);

                responseBody = new ObjectResponseBody(responseType, serialization);
            }
            else if (response is BinaryResponse)
            {
                responseBody = new StreamResponseBody();
            }

            return responseBody;
        }

        private static RequestParameterSerializationStyle GetSerializationStyle(HttpParameter httpParameter, Schema valueSchema)
        {
            Debug.Assert(httpParameter.In == ParameterLocation.Query || httpParameter.In == ParameterLocation.Header);

            switch (httpParameter.Style)
            {
                case null:
                case SerializationStyle.Form:
                case SerializationStyle.Simple:
                    return valueSchema is ArraySchema ? RequestParameterSerializationStyle.CommaDelimited : RequestParameterSerializationStyle.Simple;
                case SerializationStyle.PipeDelimited:
                    return RequestParameterSerializationStyle.PipeDelimited;
                case SerializationStyle.SpaceDelimited:
                    return RequestParameterSerializationStyle.SpaceDelimited;
                case SerializationStyle.TabDelimited:
                    return RequestParameterSerializationStyle.TabDelimited;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static IEnumerable<PathSegment> GetPathSegments(string httpRequestUri, Dictionary<string, PathSegment> parameters, bool isRaw = false)
        {
            PathSegment TextSegment(string text)
            {
                return new PathSegment(BuilderHelpers.StringConstant(text), false, SerializationFormat.Default, isRaw);
            }

            foreach ((string text, bool isLiteral) in StringExtensions.GetPathParts(httpRequestUri))
            {
                yield return isLiteral ? TextSegment(text) : parameters[text];
            }
        }

        private static Parameter[] OrderParameters(IEnumerable<Parameter> parameters) => parameters.OrderBy(p => p.DefaultValue != null).ToArray();

        // Merges operations without response types types together
        private CSharpType? ReduceResponses(List<Response> responses)
        {
            foreach (var typeGroup in responses.GroupBy(r=> r.ResponseBody))
            {
                foreach (var individualResponse in typeGroup)
                {
                    responses.Remove(individualResponse);
                }

                responses.Add(new Response(
                    typeGroup.Key,
                    typeGroup.SelectMany(r => r.StatusCodes).Distinct().ToArray()));
            }

            var bodyTypes = responses.Select(r => r.ResponseBody?.Type)
                .OfType<CSharpType>()
                .Distinct()
                .ToArray();

            return bodyTypes.Length switch
            {
                0 => null,
                1 => bodyTypes[0],
                _ => typeof(object)
            };
        }

        private static RestClientMethod BuildNextPageMethod(RestClientMethod method, Operation operation)
        {
            var nextPageUrlParameter = new Parameter(
                "nextLink",
                "The URL to the next page of results.",
                typeof(string),
                defaultValue: null,
                isRequired: true);

            PathSegment[] pathSegments = method.Request.PathSegments
                .Where(ps => ps.IsRaw)
                .Append(new PathSegment(nextPageUrlParameter, false, SerializationFormat.Default, isRaw: true))
                .ToArray();
            var request = new Request(
                RequestMethod.Get,
                pathSegments,
                Array.Empty<QueryParameter>(),
                method.Request.Headers,
                null
            );

            Parameter[] parameters = method.Parameters.Where(p => p.Name != nextPageUrlParameter.Name)
                .Prepend(nextPageUrlParameter)
                .ToArray();

            var responses = method.Responses;

            // We hardcode 200 as expected response code for paged LRO results
            if (operation.IsLongRunning)
            {
                responses = new[]
                {
                    new Response(null, new[] { 200 })
                };
            }

            return new RestClientMethod(
                $"{method.Name}NextPage",
                method.Description,
                method.ReturnType,
                request,
                parameters,
                responses,
                method.HeaderModel);
        }

        public RestClientMethod? GetNextOperationMethod(ServiceRequest request)
        {
            EnsureGetNextPageMethods().TryGetValue(request, out RestClientMethod? value);
            return value;
        }

        public RestClientMethod GetOperationMethod(ServiceRequest request)
        {
            return EnsureNormalMethods()[request];
        }

        private Parameter BuildClientParameter(RequestParameter requestParameter)
        {
            var parameter = BuildParameter(requestParameter);
            if (requestParameter.Origin == "modelerfour:synthesized/host")
            {
                parameter = new Parameter(
                    "endpoint",
                    parameter.Description,
                    typeof(Uri),
                    parameter.DefaultValue,
                    parameter.IsRequired
                );
            }

            return parameter;
        }
    }
}
