// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using Azure;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class DataPlaneLegacyMethodBuilder : DataPlaneLegacyMethodBuilderBase
    {
        private readonly TypedValueExpression _restClient;
        private readonly MethodSignature _method;

        public DataPlaneLegacyMethodBuilder(string clientName, ClientFields fields, TypedValueExpression restClientReference, MethodSignature restClientMethod)
            : base(clientName, fields)
        {
            _restClient = restClientReference;
            _method = restClientMethod;
        }

        protected override Method BuildLegacyConvenienceMethod(bool async)
        {
            var returnType = _method.ReturnType is null
                ? null
                : _method.ReturnType.FrameworkType == typeof(ResponseWithHeaders<,>)
                    ? new CSharpType(typeof(Response<>), _method.ReturnType.Arguments[0])
                    : _method.ReturnType.FrameworkType == typeof(ResponseWithHeaders<>)
                        ? new CSharpType(typeof(Response)) : _method.ReturnType;

            var signature = _method with
            {
                ReturnType = returnType,
                Modifiers = _method.Modifiers | MethodSignatureModifiers.Virtual
            };
            var body = WrapInDiagnosticScopeLegacy(_method.Name, Return(_restClient.Invoke(_method.WithAsync(async))));
            return new Method(signature.WithAsync(async), body);
        }
    }
}
