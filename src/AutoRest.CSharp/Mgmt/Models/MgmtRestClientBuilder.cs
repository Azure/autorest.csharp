// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class MgmtRestClientBuilder : CmcRestClientBuilder
    {
        private class ParameterCompareer : IEqualityComparer<RequestParameter>
        {
            public bool Equals([AllowNull] RequestParameter x, [AllowNull] RequestParameter y)
            {
                if (x is null)
                    return y is null;

                if (y is null)
                    return false;

                return x.Language.Default.Name == y.Language.Default.Name && x.Implementation == y.Implementation;
            }

            public int GetHashCode([DisallowNull] RequestParameter obj)
            {
                return obj.Language.Default.Name.GetHashCode() ^ obj.Implementation.GetHashCode();
            }
        }

        public MgmtRestClientBuilder(OperationGroup operationGroup)
            : base(GetMgmtParametersFromOperations(operationGroup.Operations), MgmtContext.Context)
        {
        }

        private static IReadOnlyList<RequestParameter> GetMgmtParametersFromOperations(ICollection<Operation> operations)
        {
            var parameters = operations
                .SelectMany(op => op.Parameters.Concat(op.Requests.SelectMany(r => r.Parameters)))
                .Where(p => p.Implementation == ImplementationLocation.Client)
                .Distinct(new ParameterCompareer()).ToList();
            ValidateMgmtOperationParameters(parameters);
            return parameters;
        }

        private static void ValidateMgmtOperationParameters(IReadOnlyList<RequestParameter> parameters)
        {
            var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "$host", "apiVersion" };
            foreach (var parameter in parameters)
            {
                var parameterName = parameter.Language.Default.Name;
                if (!set.Contains(parameterName))
                {
                    throw new InvalidOperationException($"{parameterName} should be method parameter for operation");
                }
            }
        }

        public override Parameter BuildConstructorParameter(RequestParameter requestParameter)
        {
            var parameter = base.BuildConstructorParameter(requestParameter);
            return parameter.IsApiVersionParameter
                ? parameter with { DefaultValue = Constant.Default(parameter.Type.WithNullable(true)), Initializer = parameter.DefaultValue?.GetConstantFormattable() }
                : parameter;
        }

        protected override Parameter[] BuildMethodParameters(IReadOnlyDictionary<RequestParameter, Parameter> allParameters)
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
