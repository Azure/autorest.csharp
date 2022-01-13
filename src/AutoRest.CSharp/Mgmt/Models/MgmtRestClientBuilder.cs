// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Models
{
    internal class MgmtRestClientBuilder : RestClientBuilder
    {
        public MgmtRestClientBuilder(OperationGroup operationGroup, BuildContext context)
            : base(operationGroup.Operations, context)
        {
        }

        public string? DefaultVersion { get; private set; }

        public override Parameter BuildConstructorParameter(RequestParameter requestParameter)
        {
            return base.BuildConstructorParameter(requestParameter);

            //    if (requestParameter.CSharpName() != "apiVersion")
            //        return base.BuildConstructorParameter(requestParameter);

            //    CSharpType type = _context.TypeFactory.CreateType(requestParameter.Schema, true);

            //    var defaultValue = ParseConstant(requestParameter);
            //    DefaultVersion = defaultValue!.ToString();

            //    return new Parameter(
            //        requestParameter.CSharpName(),
            //        CreateDescription(requestParameter, type),
            //        TypeFactory.GetInputType(type),
            //        null,
            //        true,
            //        IsApiVersionParameter: requestParameter.Origin == "modelerfour:synthesized/api-version",
            //        SkipUrlEncoding: requestParameter.Extensions?.SkipEncoding ?? false,
            //        RequestLocation: GetRequestLocation(requestParameter));
            //}
        }
    }
}
