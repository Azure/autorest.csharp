// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Expressions.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models
{
    internal class LroDataPlaneLegacyMethodBuilder : DataPlaneLegacyMethodBuilderBase
    {
        private readonly TypedValueExpression _restClient;
        private readonly MethodSignature _convenienceMethod;
        private readonly MethodSignature _createMessageMethod;
        private readonly CSharpType _lroType;

        public LroDataPlaneLegacyMethodBuilder(string clientName, ClientFields fields, TypedValueExpression restClientReference, MethodSignature convenienceMethod, MethodSignature createMessageMethod, CSharpType lroType)
            : base(clientName, fields)
        {
            _restClient = restClientReference;
            _convenienceMethod = convenienceMethod;
            _createMessageMethod = createMessageMethod;
            _lroType = lroType;
        }

        protected override Method BuildLegacyConvenienceMethod(bool async)
        {
            var signature = _convenienceMethod with {Name = $"Start{_convenienceMethod.Name}", Modifiers = _convenienceMethod.Modifiers | MethodSignatureModifiers.Virtual, ReturnType = _lroType};
            var body = new[]
            {
                new ParameterValidationBlock(signature.Parameters, true),
                WrapInDiagnosticScopeLegacy(signature.Name,
                    Var("originalResponse", new ResponseExpression(_restClient.Invoke(_convenienceMethod.WithAsync(async), async)), out var response),
                    Return(New.Instance(_lroType, new MemberExpression(null, $"_{KnownParameters.ClientDiagnostics.Name}"), PipelineField, new HttpMessageExpression(_restClient.Invoke(_createMessageMethod)).Request, response))
                )
            };

            return new Method(signature.WithAsync(async), body);
        }
    }
}
