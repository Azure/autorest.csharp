// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Output.Models
{
    internal abstract class DataPlaneLegacyMethodBuilderBase
    {
        private readonly string _clientName;

        protected HttpPipelineExpression PipelineField { get; }
        protected Reference ClientDiagnosticsField { get; }

        protected DataPlaneLegacyMethodBuilderBase(string clientName, ClientFields fields)
        {
            _clientName = clientName;
            PipelineField = new HttpPipelineExpression(fields.PipelineField.Declaration);
            ClientDiagnosticsField = new Reference($"_{KnownParameters.ClientDiagnostics.Name}", KnownParameters.ClientDiagnostics.Type);
        }

        public virtual IReadOnlyList<Method> Build()
        {
            return new[] { BuildLegacyConvenienceMethod(true), BuildLegacyConvenienceMethod(false) };
        }

        protected abstract Method BuildLegacyConvenienceMethod(bool async);

        protected string CreateScopeName(string methodName) => $"{_clientName}.{methodName}";

        protected MethodBodyStatement WrapInDiagnosticScopeLegacy(string methodName, params MethodBodyStatement[] statements)
            => new DiagnosticScopeMethodBodyBlock(new Diagnostic(CreateScopeName(methodName)), ClientDiagnosticsField, statements);
    }
}
