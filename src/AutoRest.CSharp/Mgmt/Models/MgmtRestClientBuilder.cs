// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models;

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
            : base(GetMgmtParametersFromOperations(inputClient.Operations), MgmtContext.Context)
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
                        throw new InvalidOperationException($"'{parameter.Name}' should be method parameter for operation '{operation.Name}'");
                    }
                    parameters.Add(parameter);
                }
            }
            return parameters.ToList();
        }
    }
}
