﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Plugins;
using AutoRest.CSharp.V3.Utilities;
using Azure.Core;
using HttpHeader = AutoRest.CSharp.V3.Pipeline.Generated.HttpHeader;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientBuilder
    {
        public static ServiceClient BuildClient(OperationGroup arg)
        {
            List<ClientMethod> methods = new List<ClientMethod>();
            Dictionary<string, ServiceClientParameter> clientParameters = new Dictionary<string, ServiceClientParameter>();

            var allClientParameters = arg.Operations
                .SelectMany(op => op.Request.Parameters)
                .Where(p => p.Implementation == ImplementationLocation.Client)
                .Distinct();

            // Deduplication required because of https://github.com/Azure/autorest.modelerfour/issues/100
            foreach (Parameter clientParameter in allClientParameters)
            {
                clientParameters[clientParameter.Language.Default.Name] = BuildParameter(clientParameter);
            }

            string clientName = arg.CSharpName();

            foreach (Operation operation in arg.Operations)
            {
                var method = BuildMethod(operation, clientName, clientParameters);
                if (method != null)
                {
                    methods.Add(method);
                }
            }

            return new ServiceClient(clientName,
                OrderParameters(clientParameters.Values),
                methods.ToArray());
        }

        private static ServiceClientParameter[] OrderParameters(IEnumerable<ServiceClientParameter> parameters)
        {
            return parameters.OrderBy(p => p.DefaultValue != null).ToArray();
        }

        private static ClientConstant? CreateDefaultValueConstant(Parameter requestParameter)
        {
            if (requestParameter.ClientDefaultValue != null)
            {
                return ClientModelBuilderHelpers.ParseClientConstant(
                    requestParameter.ClientDefaultValue,
                    (FrameworkTypeReference)ClientModelBuilderHelpers.CreateType(requestParameter.Schema, requestParameter.IsNullable()));
            }

            return null;
        }

        private static ClientMethod? BuildMethod(Operation operation, string clientName, Dictionary<string, ServiceClientParameter> clientParameters)
        {
            var httpRequest = operation.Request.Protocol.Http as HttpRequest;
            var httpRequestWithBody = httpRequest as HttpWithBodyRequest;

            //TODO: Handle multiple responses
            var response = operation.Responses.FirstOrDefault();
            var httpResponse = response?.Protocol.Http as HttpResponse;

            if (httpRequest == null || httpResponse == null)
            {
                return null;
            }

            Dictionary<string, ConstantOrParameter> uriParameters = new Dictionary<string, ConstantOrParameter>();
            Dictionary<string, PathSegment> pathParameters = new Dictionary<string, PathSegment>();
            List<QueryParameter> query = new List<QueryParameter>();
            List<RequestHeader> headers = new List<RequestHeader>();
            List<ServiceClientParameter> methodParameters = new List<ServiceClientParameter>();

            ObjectRequestBody? body = null;
            foreach (Parameter requestParameter in operation.Request.Parameters ?? Array.Empty<Parameter>())
            {
                string defaultName = requestParameter.Language.Default.Name;
                string serializedName = requestParameter.Language.Default.SerializedName ?? defaultName;
                ConstantOrParameter constantOrParameter;
                Schema valueSchema = requestParameter.Schema;

                if (requestParameter.Implementation == ImplementationLocation.Method)
                {
                    switch (requestParameter.Schema)
                    {
                        case ConstantSchema constant:
                            constantOrParameter = ClientModelBuilderHelpers.ParseClientConstant(constant);
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
                    SerializationFormat serializationFormat = ClientModelBuilderHelpers.GetSerializationFormat(valueSchema);
                    switch (httpParameter.In)
                    {
                        case ParameterLocation.Header:
                            headers.Add(new RequestHeader(serializedName, constantOrParameter, serializationFormat));
                            break;
                        case ParameterLocation.Query:
                            query.Add(new QueryParameter(serializedName, constantOrParameter, GetSerializationStyle(httpParameter, valueSchema), true, serializationFormat));
                            break;
                        case ParameterLocation.Path:
                            pathParameters.Add(serializedName, new PathSegment(constantOrParameter, true, serializationFormat));
                            break;
                        case ParameterLocation.Body:
                            Debug.Assert(httpRequestWithBody != null);
                            var serialization = SerializationBuilder.Build(httpRequestWithBody.KnownMediaType, requestParameter.Schema, requestParameter.IsNullable());

                            body = new ObjectRequestBody(constantOrParameter, serialization);
                            break;
                        case ParameterLocation.Uri:
                            uriParameters[defaultName] = constantOrParameter;
                            break;
                    }
                }

            }

            if (httpRequestWithBody != null)
            {
                headers.AddRange(httpRequestWithBody.MediaTypes.Select(mediaType => new RequestHeader("Content-Type", ClientModelBuilderHelpers.StringConstant(mediaType))));
            }

            var request = new ClientMethodRequest(
                ToCoreRequestMethod(httpRequest.Method) ?? RequestMethod.Get,
                ToParts(httpRequest.Uri, uriParameters),
                ToPathParts(httpRequest.Path, pathParameters),
                query.ToArray(),
                headers.ToArray(),
                body
            );

            ResponseBody? responseBody = null;
            if (response is SchemaResponse schemaResponse)
            {
                var schema = schemaResponse.Schema is ConstantSchema constantSchema ? constantSchema.ValueType : schemaResponse.Schema;
                var responseType = ClientModelBuilderHelpers.CreateType(schema, isNullable: false);

                ObjectSerialization serialization = SerializationBuilder.Build(httpResponse.KnownMediaType, schema, isNullable: false);

                responseBody = new ObjectResponseBody(responseType, serialization);
            }
            else if (response is BinaryResponse)
            {
                responseBody = new StreamResponseBody();
            }

            ClientMethodResponse clientResponse = new ClientMethodResponse(
                responseBody,
                httpResponse.StatusCodes.Select(ToStatusCode).ToArray(),
                BuildResponseHeaderModel(operation, httpResponse)
            );

            string operationName = operation.CSharpName();
            return new ClientMethod(
                operationName,
                request,
                OrderParameters(methodParameters),
                clientResponse,
                new ClientMethodDiagnostics($"{clientName}.{operationName}", Array.Empty<DiagnosticScopeAttributes>())
            );
        }

        private static ServiceClientParameter BuildParameter(Parameter requestParameter)
        {
            ClientConstant? defaultValue = null;
            if (requestParameter.Schema is ConstantSchema constantSchema)
            {
                defaultValue = ClientModelBuilderHelpers.ParseClientConstant(constantSchema);
            }

            return new ServiceClientParameter(
                requestParameter.CSharpName(),
                ClientModelBuilderHelpers.CreateType(requestParameter.Schema, requestParameter.IsNullable()),
                CreateDefaultValueConstant(requestParameter) ?? defaultValue,
                requestParameter.Required == true);
        }

        private static ResponseHeaderModel? BuildResponseHeaderModel(Operation operation, HttpResponse httpResponse)
        {
            if (!httpResponse.Headers.Any())
            {
                return null;
            }

            ResponseHeader CreateResponseHeader(HttpHeader header) =>
                new ResponseHeader(header.Header.ToCleanName(), header.Header, ClientModelBuilderHelpers.CreateType(header.Schema, true));

            return new ResponseHeaderModel(
                operation.CSharpName() + "Headers",
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

        private static ConstantOrParameter[] ToParts(string httpRequestUri, Dictionary<string, ConstantOrParameter> parameters)
        {
            List<ConstantOrParameter> host = new List<ConstantOrParameter>();
            foreach ((string text, bool isLiteral) in StringExtensions.GetPathParts(httpRequestUri))
            {
                host.Add(isLiteral ? ClientModelBuilderHelpers.StringConstant(text) : parameters[text]);
            }

            return host.ToArray();
        }

        private static PathSegment[] ToPathParts(string httpRequestUri, Dictionary<string, PathSegment> parameters)
        {
            PathSegment TextSegment(string text)
            {
                return new PathSegment(ClientModelBuilderHelpers.StringConstant(text), false, SerializationFormat.Default);
            }

            List<PathSegment> host = new List<PathSegment>();
            foreach ((string text, bool isLiteral) in StringExtensions.GetPathParts(httpRequestUri))
            {
                host.Add(isLiteral ? TextSegment(text) : parameters[text]);
            }

            return host.ToArray();
        }

        private static int ToStatusCode(StatusCodes arg) => int.Parse(arg.ToString().Trim('_'));

        private static RequestMethod? ToCoreRequestMethod(HttpMethod method) => method switch
        {
            HttpMethod.Delete => RequestMethod.Delete,
            HttpMethod.Get => RequestMethod.Get,
            HttpMethod.Head => RequestMethod.Head,
            HttpMethod.Options => (RequestMethod?)null,
            HttpMethod.Patch => RequestMethod.Patch,
            HttpMethod.Post => RequestMethod.Post,
            HttpMethod.Put => RequestMethod.Put,
            HttpMethod.Trace => null,
            _ => null
        };

    }
}
