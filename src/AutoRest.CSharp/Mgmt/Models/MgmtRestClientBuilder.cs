﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO.MemoryMappedFiles;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class MgmtRestClientBuilder : RestClientBuilder
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

        public MgmtRestClientBuilder(OperationGroup operationGroup, BuildContext context)
            : base(GetMgmtParametersFromOperations(operationGroup.Operations), context)
        {
        }

        public static IEnumerable<RequestParameter> GetMgmtParametersFromOperations(ICollection<Operation> operations) =>
            operations
                .SelectMany(op => op.Parameters.Concat(op.Requests.SelectMany(r => r.Parameters)))
                .Where(p => p.Implementation == ImplementationLocation.Client)
                .Distinct(new ParameterCompareer());

        public override Parameter BuildConstructorParameter(RequestParameter requestParameter)
        {
            var parameter = base.BuildConstructorParameter(requestParameter);
            return parameter.IsApiVersionParameter ? parameter with { UseDefaultValueInCtorParam = false } : parameter;
        }
    }
}
