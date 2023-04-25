// Copyright(c) Microsoft Corporation.All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Models.ValueExpressions
{
    [DebuggerDisplay("{GetDebuggerDisplay(),nq}")]
    internal record ValueExpression
    {
        public static implicit operator ValueExpression(Type type) => new TypeReference(type);
        public static implicit operator ValueExpression(CSharpType type) => new TypeReference(type);
        public static implicit operator ValueExpression(Parameter parameter) => new ParameterReference(parameter);
        public static implicit operator ValueExpression(CodeWriterDeclaration name) => new VariableReference(name);
        public static implicit operator ValueExpression(FieldDeclaration name) => new VariableReference(name.Declaration);

        public ValueExpression NullConditional(CSharpType type) => type.IsNullable ? new NullConditionalExpression(this) : this;
        public ValueExpression NullableStructValue(CSharpType candidateType) => candidateType is { IsNullable: true, IsValueType: true } ? new MemberReference(this, nameof(Nullable<int>.Value)) : this;

        private string GetDebuggerDisplay()
        {
            using var writer = new DebuggerCodeWriter();
            writer.WriteValueExpression(this);
            return writer.ToString();
        }
    }
}
