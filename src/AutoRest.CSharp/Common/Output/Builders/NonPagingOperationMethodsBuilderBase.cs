// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class NonPagingOperationMethodsBuilderBase : OperationMethodsBuilderBase
    {
        protected NonPagingOperationMethodsBuilderBase(InputOperation operation, ValueExpression? restClient, ClientFields fields, string clientName, TypeFactory typeFactory, ClientMethodReturnTypes returnTypes, ClientMethodParameters clientMethodParameters)
            : base(operation, restClient, fields, clientName, typeFactory, returnTypes, clientMethodParameters)
        {
            ResponseType = returnTypes.ResponseType;
        }

        protected override bool ShouldConvenienceMethodGenerated() => ResponseType is not null || base.ShouldConvenienceMethodGenerated();

        protected CSharpType? ResponseType { get; }

        protected static CSharpType? GetResponseType(InputOperation operation, TypeFactory typeFactory)
        {
            if (operation.HttpMethod == RequestMethod.Head && Input.Configuration.HeadAsBoolean)
            {
                return null;
            }

            var firstResponseBodyType = operation.Responses.Where(r => !r.IsErrorResponse).Select(r => r.BodyType).Distinct().FirstOrDefault();
            var responseType = firstResponseBodyType is not null ? typeFactory.CreateType(firstResponseBodyType) : null;
            return responseType is null ? null : TypeFactory.GetOutputType(responseType);
        }
    }
}
