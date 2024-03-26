// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Output.Models.Types.System
{
    internal class ErrorResultProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<ErrorResultProvider> _instance = new(() => new ErrorResultProvider());

        public static ErrorResultProvider Instance => _instance.Value;

        private class ErrorResultTemplate<T> { }

        private CSharpType _t = typeof(ErrorResultTemplate<>).GetGenericArguments()[0];
        private FieldDeclaration _responseField;
        private FieldDeclaration _exceptionField;
        private VariableReference _response;
        private VariableReference _exception;

        private ErrorResultProvider()
            : base(Configuration.HelperNamespace, null)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal;
            _responseField = new FieldDeclaration(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(PipelineResponse), "_response");
            _exceptionField = new FieldDeclaration(FieldModifiers.Private | FieldModifiers.ReadOnly, typeof(ClientResultException), "_exception");
            _response = new VariableReference(_responseField.Type, _responseField.Declaration);
            _exception = new VariableReference(_exceptionField.Type, _exceptionField.Declaration);
        }

        protected override string DefaultName => "ErrorResult";

        protected override IEnumerable<CSharpType> BuildTypeArguments()
        {
            yield return _t;
        }

        protected override IEnumerable<CSharpType> BuildImplements()
        {
            yield return new CSharpType(typeof(ClientResult<>), _t);
        }

        protected override IEnumerable<FieldDeclaration> BuildFields()
        {
            yield return _responseField;
            yield return _exceptionField;
        }

        protected override IEnumerable<Method> BuildConstructors()
        {
            yield return BuildCtor();
        }

        private Method BuildCtor()
        {
            var responseParam = new Parameter("response", null, typeof(PipelineResponse), null, ValidationType.None, null);
            var exceptionParam = new Parameter("exception", null, typeof(ClientResultException), null, ValidationType.None, null);
            var response = new ParameterReference(responseParam);
            var exception = new ParameterReference(exceptionParam);
            var baseInitializer = new ConstructorInitializer(true, new List<ValueExpression> { Default, response });
            var signature = new ConstructorSignature(Type, null, null, MethodSignatureModifiers.Public, new[] { responseParam, exceptionParam }, Initializer: baseInitializer);
            return new Method(signature, new MethodBodyStatement[]
            {
                Assign(_response, response),
                Assign(_exception, exception),
            });
        }

        protected override IEnumerable<PropertyDeclaration> BuildProperties()
        {
            yield return BuildValue();
        }

        private PropertyDeclaration BuildValue()
        {
            return new PropertyDeclaration(null, MethodSignatureModifiers.Public | MethodSignatureModifiers.Override, _t, "Value", new ExpressionPropertyBody(
                ThrowExpression(_exception)
            ));
        }
    }
}
