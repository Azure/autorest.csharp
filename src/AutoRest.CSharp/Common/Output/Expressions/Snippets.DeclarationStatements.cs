// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions.Base;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Common.Output.Models
{
    internal static partial class Snippets
    {
        public static DeclarationStatement UsingDeclare(string name, StreamExpression value, out StreamExpression variable)
            => UsingDeclare(name, value, d => new StreamExpression(d), out variable);

        public static DeclarationStatement UsingDeclare(string name, HttpMessageExpression value, out HttpMessageExpression variable)
            => UsingDeclare(name, value, d => new HttpMessageExpression(d), out variable);

        public static DeclarationStatement Declare(CSharpType responseType, string name, BaseResponseExpression value, out BaseResponseExpression response)
        {
            var variable = new VariableReference(responseType, name);
            response = Configuration.ApiTypes.GetResponseExpression(variable);
            return Declare(variable, value);
        }

        public static DeclarationStatement Declare(RequestContextExpression value, out RequestContextExpression variable)
            => Declare(KnownParameters.RequestContext.Name, value, d => new RequestContextExpression(d), out variable);

        public static DeclarationStatement Declare(string name, BinaryDataExpression value, out BinaryDataExpression variable)
            => Declare(name, value, d => new BinaryDataExpression(d), out variable);

        public static DeclarationStatement Declare(string name, JsonElementExpression value, out JsonElementExpression variable)
            => Declare(name, value, d => new JsonElementExpression(d), out variable);

        public static DeclarationStatement Declare(string name, BaseResponseExpression value, out BaseResponseExpression variable)
            => Declare(name, value, d => Configuration.ApiTypes.GetResponseExpression(d), out variable);

        public static DeclarationStatement Declare(string name, StreamReaderExpression value, out StreamReaderExpression variable)
            => Declare(name, value, d => new StreamReaderExpression(d), out variable);

        public static DeclarationStatement Declare(string name, TypedValueExpression value, out ValueExpression variable)
        {
            var declaration = new VariableReference(value.Type, name);
            variable = declaration;
            return Declare(declaration, value);
        }

        public static DeclarationStatement Declare(VariableReference variable, ValueExpression value)
            => new DeclareVariableStatement(variable.Type, variable.Declaration, value);

        public static DeclarationStatement UsingVar(string name, HttpMessageExpression value, out HttpMessageExpression variable)
            => UsingVar(name, value, d => new HttpMessageExpression(d), out variable);

        public static DeclarationStatement UsingVar(string name, JsonDocumentExpression value, out JsonDocumentExpression variable)
            => UsingVar(name, value, d => new JsonDocumentExpression(d), out variable);

        public static DeclarationStatement Var(string name, DictionaryExpression value, out DictionaryExpression variable)
            => Var(name, value, d => new DictionaryExpression(value.ValueType, d), out variable);

        public static DeclarationStatement Var(string name, FormUrlEncodedContentExpression value, out FormUrlEncodedContentExpression variable)
            => Var(name, value, d => new FormUrlEncodedContentExpression(d), out variable);

        public static DeclarationStatement Var(string name, HttpMessageExpression value, out HttpMessageExpression variable)
            => Var(name, value, d => new HttpMessageExpression(d), out variable);

        public static DeclarationStatement Var(string name, ListExpression value, out ListExpression variable)
            => Var(name, value, d => new ListExpression(d), out variable);

        public static DeclarationStatement Var(string name, MultipartFormDataContentExpression value, out MultipartFormDataContentExpression variable)
            => Var(name, value, d => new MultipartFormDataContentExpression(d), out variable);

        public static DeclarationStatement Var(string name, OperationExpression value, out OperationExpression variable)
            => Var(name, value, d => new OperationExpression(d), out variable);

        public static DeclarationStatement Var(string name, RawRequestUriBuilderExpression value, out RawRequestUriBuilderExpression variable)
            => Var(name, value, d => new RawRequestUriBuilderExpression(d), out variable);

        public static DeclarationStatement Var(string name, RequestExpression value, out RequestExpression variable)
            => Var(name, value, d => new RequestExpression(d), out variable);

        public static DeclarationStatement Var(string name, BaseResponseExpression value, out BaseResponseExpression variable)
            => Var(name, value, d => Configuration.ApiTypes.GetResponseExpression(d), out variable);

        public static DeclarationStatement Var(string name, Utf8JsonRequestContentExpression value, out Utf8JsonRequestContentExpression variable)
            => Var(name, value, d => new Utf8JsonRequestContentExpression(d), out variable);

        public static DeclarationStatement Var(string name, Utf8JsonWriterExpression value, out Utf8JsonWriterExpression variable)
            => Var(name, value, d => new Utf8JsonWriterExpression(d), out variable);

        public static DeclarationStatement Var(string name, XDocumentExpression value, out XDocumentExpression variable)
            => Var(name, value, d => new XDocumentExpression(d), out variable);

        public static DeclarationStatement Var(string name, XmlWriterContentExpression value, out XmlWriterContentExpression variable)
            => Var(name, value, d => new XmlWriterContentExpression(d), out variable);

        public static DeclarationStatement Var(string name, TypedValueExpression value, out ValueExpression variable)
        {
            var reference = new VariableReference(value.Type, name);
            variable = reference;
            return Var(reference, value);
        }

        public static DeclarationStatement Var(VariableReference variable, ValueExpression value)
            => new DeclareVariableStatement(null, variable.Declaration, value);

        private static DeclarationStatement UsingDeclare<T>(string name, T value, Func<ValueExpression, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(new VariableReference(value.Type, declaration));
            return new UsingDeclareVariableStatement(value.Type, declaration, value);
        }

        private static DeclarationStatement UsingVar<T>(string name, T value, Func<ValueExpression, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(new VariableReference(value.Type, declaration));
            return new UsingDeclareVariableStatement(null, declaration, value);
        }

        private static DeclarationStatement Declare<T>(string name, T value, Func<ValueExpression, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(new VariableReference(value.Type, declaration));
            return new DeclareVariableStatement(value.Type, declaration, value);
        }

        private static DeclarationStatement Var<T>(string name, T value, Func<ValueExpression, T> factory, out T variable) where T : TypedValueExpression
        {
            var declaration = new CodeWriterDeclaration(name);
            variable = factory(new VariableReference(value.Type, declaration));
            return new DeclareVariableStatement(null, declaration, value);
        }
    }
}
