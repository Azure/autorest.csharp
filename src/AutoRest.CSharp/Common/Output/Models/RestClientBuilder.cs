// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;

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
            var parameter = Parameter.FromInputParameter(inputParameter, typeFactory.CreateType(inputParameter.Type), false, typeFactory);
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
                    $"A credential used to authenticate to an Azure Service.",
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

    internal record RequestPartSource(string NameInRequest, InputParameter? InputParameter, Parameter? OutputParameter, SerializationFormat SerializationFormat);
}
