// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Generation.Writers;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class MgmtRestClientBuilder : CmcRestClientBuilder
    {
        private class ParameterCompareer : IEqualityComparer<InputParameter>
        {
            public bool Equals([AllowNull] InputParameter x, [AllowNull] InputParameter y)
            {
                if (x is null)
                    return y is null;

                if (y is null)
                    return false;

                return x.Name == y.Name && x.Kind == y.Kind;
            }

            public int GetHashCode([DisallowNull] InputParameter obj)
            {
                return obj.Name.GetHashCode() ^ obj.Kind.GetHashCode();
            }
        }

        public MgmtRestClientBuilder(InputClient inputClient)
            : base(inputClient.Parameters.Concat(GetMgmtParametersFromOperations(inputClient.Operations)), MgmtContext.Context)
        {
        }

        private static IReadOnlyList<InputParameter> GetMgmtParametersFromOperations(IReadOnlyList<InputOperation> operations)
        {
            var parameters = new HashSet<InputParameter>(new ParameterCompareer());
            foreach (var operation in operations)
            {
                var clientParameters = operation.Parameters.Where(p => p.Kind == InputOperationParameterKind.Client);
                foreach (var parameter in clientParameters)
                {
                    if (!parameter.IsEndpoint && !parameter.IsApiVersion)
                    {
                        throw new InvalidOperationException($"'{parameter.Name}' should be method parameter for operation '{operation.OperationId}'");
                    }
                    parameters.Add(parameter);
                }
            }
            return parameters.ToList();
        }

        public override Parameter BuildConstructorParameter(InputParameter requestParameter)
        {
            var parameter = base.BuildConstructorParameter(requestParameter);
            return parameter.IsApiVersionParameter
                ? parameter with { DefaultValue = Constant.Default(parameter.Type.WithNullable(true)), Initializer = parameter.DefaultValue?.GetConstantFormattable() }
                : parameter;
        }

        protected override Parameter[] BuildMethodParameters(IReadOnlyDictionary<InputParameter, Parameter> allParameters)
        {
            List<Parameter> requiredParameters = new();
            List<Parameter> optionalParameters = new();
            List<Parameter> bodyParameters = new();
            foreach (var (requestParameter, parameter) in allParameters)
            {
                // Grouped and flattened parameters shouldn't be added to methods
                if (IsMethodParameter(requestParameter))
                {
                    // sort the parameters by the following sequence:
                    // 1. required parameters
                    // 2. body parameters (if exists), note that form data can generate multiple body parameters (e.g. "in": "formdata")
                    //    see test project `body-formdata` for more details
                    // 3. optional parameters
                    if (parameter.RequestLocation == RequestLocation.Body)
                    {
                        bodyParameters.Add(parameter);
                    }
                    else if (parameter.IsOptionalInSignature)
                    {
                        optionalParameters.Add(parameter);
                    }
                    else
                    {
                        requiredParameters.Add(parameter);
                    }
                }
            }

            requiredParameters.AddRange(bodyParameters.OrderBy(p => p.IsOptionalInSignature)); // move required body parameters at the beginning
            requiredParameters.AddRange(optionalParameters);

            return requiredParameters.ToArray();
        }
    }
}
