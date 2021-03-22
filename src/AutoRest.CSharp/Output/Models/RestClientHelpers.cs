// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Request = AutoRest.CSharp.Output.Models.Requests.Request;
using StatusCodes = AutoRest.CSharp.Output.Models.Responses.StatusCodes;

namespace AutoRest.CSharp.Output.Models
{
    internal static class RestClientHelpers
    {
        internal static IEnumerable<ServiceRequest> AllRequests(this OperationGroup operationGroup)
        {
            foreach (var operation in operationGroup.Operations)
            {
                foreach (var serviceRequest in operation.Requests)
                {
                    yield return serviceRequest;
                }
            }
        }

        private static IEnumerable<Parameter> GetRequiredParameters(Parameter[] parameters)
        {
            List<Parameter> requiredParameters = new List<Parameter>();
            foreach (var parameter in parameters)
            {
                if (parameter.DefaultValue == null)
                {
                    requiredParameters.Add(parameter);
                }
            }

            return requiredParameters;
        }

        private static IEnumerable<Parameter> GetOptionalParameters(Parameter[] parameters)
        {
            List<Parameter> optionalParameters = new List<Parameter>();
            foreach (var parameter in parameters)
            {
                if (parameter.DefaultValue != null && !parameter.IsApiVersionParameter)
                {
                    optionalParameters.Add(parameter);
                }
            }

            return optionalParameters;
        }

        public static IReadOnlyCollection<Parameter> GetConstructorParameters(Parameter[] parameters, CSharpType credentialType, bool includeProtocolOptions = false)
        {
            List<Parameter> constructorParameters = new List<Parameter>();

            constructorParameters.AddRange(GetRequiredParameters(parameters));

            var credentialParam = new Parameter(
                "credential",
                "A credential used to authenticate to an Azure Service.",
                credentialType,
                null,
                true);
            constructorParameters.Add(credentialParam);

            if (includeProtocolOptions)
            {
                var protocolParam = new Parameter(
                    "options",
                    "Options to control the underlying operations.",
                    typeof(Azure.Core.ProtocolClientOptions),
                    Constant.NewInstanceOf(typeof(Azure.Core.ProtocolClientOptions)),
                    true);
                constructorParameters.Add(protocolParam);
            }

            constructorParameters.AddRange(GetOptionalParameters(parameters));

            return constructorParameters;
        }
    }
}
