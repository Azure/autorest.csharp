// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class DataPlaneLegacyMethodBuilder : DataPlaneLegacyMethodBuilderBase
    {
        private readonly ValueExpression _restClient;
        private readonly MethodSignature _method;

        public DataPlaneLegacyMethodBuilder(string clientName, ClientFields fields, ValueExpression restClientReference, MethodSignature restClientMethod)
            : base(clientName, fields)
        {
            _restClient = restClientReference;
            _method = restClientMethod;
        }

        protected override Method BuildLegacyConvenienceMethod(bool async)
        {
            var body = WrapInDiagnosticScopeLegacy(_method.Name, Return(_restClient.Invoke(_method.WithAsync(async), async)));
            return new Method(_method.WithAsync(async), body);
        }
    }
}
