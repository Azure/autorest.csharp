// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Pipeline;
using AutoRest.CSharp.V3.Pipeline.Generated;
using AutoRest.CSharp.V3.Plugins;
using AutoRest.CSharp.V3.Utilities;
using Azure.Core;
using HttpHeader = AutoRest.CSharp.V3.Pipeline.Generated.HttpHeader;

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientBuilder
    {
        public static ServiceClient BuildClient(OperationGroup arg) =>
            new ServiceClient(arg.CSharpName(), arg.Operations.Select(BuildMethod).Where(method => method != null).ToArray()!);

        private static ClientConstant? CreateDefaultValueConstant(Parameter requestParameter) =>
            requestParameter.ClientDefaultValue != null ?
                ClientModelBuilderHelpers.ParseClientConstant(requestParameter.ClientDefaultValue, (FrameworkTypeReference)ClientModelBuilderHelpers.CreateType(requestParameter.Schema, requestParameter.IsNullable())) :
                (ClientConstant?)null;

        private static ClientMethod? BuildMethod(Operation operation)
        {
            var httpRequest = operation.Request.Protocol.Http as HttpRequest;
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

            List<ServiceClientMethodParameter> methodParameters = new List<ServiceClientMethodParameter>();

            RequestBody? body = null;
            foreach (Parameter requestParameter in operation.Request.Parameters ?? Array.Empty<Parameter>())
            {
                string defaultName = requestParameter.Language.Default.Name;
                string serializedName = requestParameter.Language.Default.SerializedName ?? defaultName;
                ConstantOrParameter? constantOrParameter;
                Schema valueSchema = requestParameter.Schema;

                switch (requestParameter.Schema)
                {
                    case ConstantSchema constant:
                        constantOrParameter = ClientModelBuilderHelpers.ParseClientConstant(constant);
                        valueSchema = constant.ValueType;
                        break;
                    case BinarySchema _:
                        // skip
                        continue;
                    //TODO: Workaround for https://github.com/Azure/autorest.csharp/pull/275
                    case ArraySchema arraySchema when arraySchema.ElementType is ConstantSchema constantInnerType:
                        constantOrParameter = new ServiceClientMethodParameter(requestParameter.CSharpName(),
                            new CollectionTypeReference(ClientModelBuilderHelpers.CreateType(constantInnerType.ValueType, false), false),
                            CreateDefaultValueConstant(requestParameter), false);
                        break;
                    //TODO: Workaround for https://github.com/Azure/autorest.csharp/pull/275
                    case DictionarySchema dictionarySchema when dictionarySchema.ElementType is ConstantSchema constantInnerType:
                        constantOrParameter = new ServiceClientMethodParameter(requestParameter.CSharpName(),
                            new CollectionTypeReference(ClientModelBuilderHelpers.CreateType(constantInnerType.ValueType, false), false),
                            CreateDefaultValueConstant(requestParameter), false);
                        break;
                    default:
                        constantOrParameter = new ServiceClientMethodParameter(
                            requestParameter.CSharpName(),
                            ClientModelBuilderHelpers.CreateType(requestParameter.Schema, requestParameter.IsNullable()),
                            CreateDefaultValueConstant(requestParameter),
                            requestParameter.Required == true);
                        break;
                }

                if (requestParameter.Protocol.Http is HttpParameter httpParameter)
                {
                    SerializationFormat serializationFormat = ClientModelBuilderHelpers.GetSerializationFormat(valueSchema);
                    switch (httpParameter.In)
                    {
                        case ParameterLocation.Header:
                            headers.Add(new RequestHeader(serializedName, constantOrParameter.Value, serializationFormat));
                            break;
                        case ParameterLocation.Query:
                            query.Add(new QueryParameter(serializedName, constantOrParameter.Value, GetSerializationStyle(httpParameter, valueSchema), true, serializationFormat));
                            break;
                        case ParameterLocation.Path:
                            pathParameters.Add(serializedName, new PathSegment(constantOrParameter.Value, true, serializationFormat));
                            break;
                        case ParameterLocation.Body when constantOrParameter is ConstantOrParameter constantOrParameterValue:
                            body = new RequestBody(constantOrParameterValue, ClientModelBuilderHelpers.CreateSerialization(requestParameter.Schema, requestParameter.IsNullable()));
                            break;
                        case ParameterLocation.Uri:
                            uriParameters[defaultName] = constantOrParameter.Value;
                            break;
                    }
                }

                if (!constantOrParameter.Value.IsConstant)
                {
                    methodParameters.Add(constantOrParameter.Value.Parameter);
                }
            }

            if (httpRequest is HttpWithBodyRequest httpWithBodyRequest)
            {
                headers.AddRange(httpWithBodyRequest.MediaTypes.Select(mediaType => new RequestHeader("Content-Type", ClientModelBuilderHelpers.StringConstant(mediaType))));
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
                responseBody = new ResponseBody(responseType, ClientModelBuilderHelpers.CreateSerialization(schema, false));
            }

            ClientMethodResponse clientResponse = new ClientMethodResponse(
                responseBody,
                httpResponse.StatusCodes.Select(ToStatusCode).ToArray(),
                BuildResponseHeaderModel(operation, httpResponse)
            );

            return new ClientMethod(
                operation.CSharpName(),
                request,
                methodParameters.ToArray(),
                clientResponse
            );
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
                if (!isLiteral)
                {

                    if (!parameters.TryGetValue(text, out var segment))
                    {
                        //TODO: WORKAROUND FOR https://github.com/Azure/autorest.modelerfour/issues/58
                        segment = TextSegment(text);
                    }
                    host.Add(segment);
                }
                else
                {
                    host.Add(TextSegment(text));
                }
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
