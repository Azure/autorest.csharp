// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models.Types
{
    internal class BicepSerializationTypeProvider : ExpressionTypeProvider
    {
        private static readonly Lazy<BicepSerializationTypeProvider> _instance = new(() => new BicepSerializationTypeProvider(Configuration.HelperNamespace, null));
        public static BicepSerializationTypeProvider Instance => _instance.Value;

        private BicepSerializationTypeProvider(string defaultNamespace, SourceInputModel? sourceInputModel)
            : base(defaultNamespace, sourceInputModel)
        {
            DeclarationModifiers = TypeSignatureModifiers.Internal | TypeSignatureModifiers.Static;
        }

        protected override string DefaultName => "BicepSerializationHelpers";

        protected override IEnumerable<Method> BuildMethods() => BicepSerializationMethodsBuilder.BuildPerAssemblyBicepSerializationMethods();

        internal InvokeStaticMethodStatement AppendChildObject(
            ValueExpression stringBuilder,
            ValueExpression expression,
            ConstantExpression spaces,
            BoolExpression isArrayElement,
            StringExpression formattedPropertyName)
        {
            return new InvokeStaticMethodStatement(
                Type,
                "AppendChildObject",
                new[]
                {
                    stringBuilder, expression, KnownParameters.Serializations.Options, spaces, isArrayElement,
                    formattedPropertyName
                });
        }
    }
}
