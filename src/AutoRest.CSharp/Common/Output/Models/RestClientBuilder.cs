// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using Response = AutoRest.CSharp.Output.Models.Responses.Response;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Output.Models
{
    internal class RestClientBuilder
    {
        public static IReadOnlyList<InputParameter> GetParametersFromOperations(IEnumerable<InputOperation> operations) =>
            operations
                .SelectMany(op => op.Parameters)
                .Where(p => p.Kind == InputOperationParameterKind.Client)
                .Distinct()
                .ToList();

        public static Parameter BuildConstructorParameter(InputParameter inputParameter, TypeFactory typeFactory)
        {
            var parameter = Parameter.FromInputParameter(inputParameter, typeFactory.CreateType(inputParameter.Type), typeFactory);
            if (!inputParameter.IsEndpoint)
            {
                return parameter;
            }

            var defaultValue = parameter.DefaultValue;
            var description = parameter.Description;
            var location = parameter.RequestLocation;

            return defaultValue != null
                ? KnownParameters.Endpoint with { Description = description, RequestLocation = location, DefaultValue = Constant.Default(new CSharpType(typeof(Uri), true)), Initializer = $"new {typeof(Uri)}({defaultValue.Value.GetConstantFormattable()})"}
                : KnownParameters.Endpoint with { Description = description, RequestLocation = location, Validation = parameter.Validation };
        }

        public static Response[] BuildResponses(InputOperation operation, CSharpType? resourceDataType, TypeFactory typeFactory)
        {
            if (operation.HttpMethod == RequestMethod.Head && Configuration.HeadAsBoolean)
            {
                return new[]
                {
                    new Response(new ConstantResponseBody(new Constant(true, typeof(bool))), new[] {new StatusCodes(null, 2)}),
                    new Response(new ConstantResponseBody(new Constant(false, typeof(bool))), new[] {new StatusCodes(null, 4)}),
                };
            }

            var clientResponse = new List<Response>();
            foreach (var response in operation.Responses.Where(r => !r.IsErrorResponse))
            {
                ResponseBody? responseBody;
                var bodyType = response.BodyType;
                if (operation.LongRunning != null || bodyType == null)
                {
                    responseBody = null;
                }
                else if (response.BodyMediaType == BodyMediaType.Text)
                {
                    responseBody = new StringResponseBody();
                }
                else if (bodyType is InputPrimitiveType { Kind: InputTypeKind.Stream })
                {
                    responseBody = new StreamResponseBody();
                }
                else
                {
                    CSharpType responseType1 = TypeFactory.GetOutputType(typeFactory.CreateType(bodyType));
                    ObjectSerialization serialization = SerializationBuilder.Build(response.BodyMediaType, bodyType, responseType1);
                    responseBody = new ObjectResponseBody(responseType1, serialization);
                }

                clientResponse.Add(new Response(responseBody, response.StatusCodes.Select(statusCode => new StatusCodes(statusCode, null)).ToArray()));
            }

            if (resourceDataType is not null && clientResponse.Any())
            {
                var responseBodyTypeName = clientResponse[0].ResponseBody?.Type.Name;
                if (responseBodyTypeName == resourceDataType.Name && operation.Responses.Any(r => r.BodyType is {} type && resourceDataType.EqualsIgnoreNullable(typeFactory.CreateType(type))))
                {
                    clientResponse.Add(new Response(null, new[] { new StatusCodes(404, null) }));
                }
            }

            foreach (var typeGroup in clientResponse.GroupBy(r => r.ResponseBody))
            {
                foreach (var individualResponse in typeGroup)
                {
                    clientResponse.Remove(individualResponse);
                }

                clientResponse.Add(new Response(
                    typeGroup.Key,
                    typeGroup.SelectMany(r => r.StatusCodes).Distinct().ToArray()));
            }

            return clientResponse.ToArray();
        }

        // Merges operations without response types types together

        public static IEnumerable<Parameter> GetRequiredParameters(IEnumerable<Parameter> parameters)
            => parameters.Where(parameter => !parameter.IsOptionalInSignature).ToList();

        public static IEnumerable<Parameter> GetOptionalParameters(IEnumerable<Parameter> parameters, bool includeAPIVersion = false)
            => parameters.Where(parameter => parameter.IsOptionalInSignature && (includeAPIVersion || !parameter.IsApiVersionParameter)).ToList();

        public static IReadOnlyCollection<Parameter> GetConstructorParameters(IReadOnlyList<Parameter> parameters, CSharpType? credentialType, bool includeAPIVersion = false)
        {
            var constructorParameters = new List<Parameter>();

            constructorParameters.AddRange(GetRequiredParameters(parameters));

            if (credentialType != null)
            {
                var credentialParam = new Parameter(
                    "credential",
                    "A credential used to authenticate to an Azure Service.",
                    credentialType,
                    null,
                    Validation.AssertNotNull,
                    null);
                constructorParameters.Add(credentialParam);
            }

            constructorParameters.AddRange(GetOptionalParameters(parameters, includeAPIVersion));

            return constructorParameters;
        }
    }

    internal record RequestPartSource(string NameInRequest, InputParameter? InputParameter, Parameter OutputParameter, SerializationFormat SerializationFormat);
}
