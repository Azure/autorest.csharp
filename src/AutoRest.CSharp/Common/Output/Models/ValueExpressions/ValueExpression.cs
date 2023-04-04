// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    internal record ValueExpression
    {
        public static implicit operator ValueExpression(Parameter parameter) => new ParameterReference(parameter);
        public static implicit operator ValueExpression(CodeWriterDeclaration name) => new VariableReference(name);
        public static implicit operator ValueExpression(FieldDeclaration name) => new VariableReference(name.Declaration);
    }
}
