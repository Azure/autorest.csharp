// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static DeclarationStatement Declare(CSharpType responseType, string name, FrameworkTypeExpression value, out FrameworkTypeExpression variable)
            => Var(responseType, name, value, d => new FrameworkTypeExpression(responseType, d), out variable);

        public static DeclarationStatement Declare(CSharpType responseType, string name, ResponseExpression value, out ResponseExpression variable)
            => Var(responseType, name, value, d => new ResponseExpression(d), out variable);

        public static DeclarationStatement Declare(RequestContextExpression value, out RequestContextExpression variable)
            => Var(typeof(RequestContext), KnownParameters.RequestContext.Name, value, d => new RequestContextExpression(d), out variable);

        public static DeclarationStatement Declare(string name, HttpMessageExpression value, out HttpMessageExpression variable)
            => UsingVar(typeof(HttpMessage), name, value, d => new HttpMessageExpression(d), out variable);

        public static DeclarationStatement UsingVar(string name, JsonDocumentExpression value, out JsonDocumentExpression variable)
            => UsingVar(null, name, value, d => new JsonDocumentExpression(d), out variable);

        public static DeclarationStatement Var(string name, Utf8JsonRequestContentExpression value, out Utf8JsonRequestContentExpression variable)
            => Var(null, name, value, d => new Utf8JsonRequestContentExpression(d), out variable);

        public static DeclarationStatement Var(string name, RawRequestUriBuilderExpression value, out RawRequestUriBuilderExpression variable)
            => Var(null, name, value, d => new RawRequestUriBuilderExpression(d), out variable);

        public static DeclarationStatement Var(string name, Utf8JsonWriterExpression value, out Utf8JsonWriterExpression variable)
            => Var(null, name, value, d => new Utf8JsonWriterExpression(d), out variable);

        public static DeclarationStatement Var(string name, RequestExpression value, out RequestExpression variable)
            => Var(null, name, value, d => new RequestExpression(d), out variable);

        public static DeclarationStatement Var(string name, HttpMessageExpression value, out HttpMessageExpression variable)
            => Var(null, name, value, d => new HttpMessageExpression(d), out variable);


        private static DeclarationStatement UsingVar<T>(CSharpType? type, string name, T value, Func<CodeWriterDeclaration, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(declaration);
            return new UsingDeclareVariableStatement(type, declaration, value);
        }

        private static DeclarationStatement Var<T>(CSharpType? type, string name, T value, Func<CodeWriterDeclaration, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(declaration);
            return new DeclareVariableStatement(type, declaration, value);
        }
    }
}
