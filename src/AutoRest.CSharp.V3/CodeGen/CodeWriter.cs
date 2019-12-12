﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.V3.Utilities;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Formatting;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class CodeWriter
    {
        private readonly List<CSharpNamespace> _usingNamespaces = new List<CSharpNamespace>();
        private readonly StringBuilder _builder = new StringBuilder();
        private readonly string _definitionAccessDefault = "public";
        private CSharpNamespace? _currentNamespace;

        protected virtual CodeWriterScope Scope(string start = "{", string end = "}")
        {
            Line(start);
            return new CodeWriterScope(this, end);
        }

        public CodeWriterScope Namespace(CSharpNamespace @namespace)
        {
            _currentNamespace = @namespace;
            Line($"namespace {@namespace?.FullName}");
            return Scope();
        }

        private string DefinitionLine(string? access, string? modifiers, string kind, string? name, string? implements = null) =>
            new[] { access ?? _definitionAccessDefault, modifiers, kind, name , implements != null ? $": {implements}" : null }.JoinIgnoreEmpty(" ");

        private CodeWriterScope Definition(string? access, string? modifiers, string kind, string? name, string? implements = null)
        {
            Line(DefinitionLine(access, modifiers, kind, name, implements));
            return Scope();
        }

        public CodeWriterScope Class(string? access, string? modifiers, string? name, string? implements = null)
        {
            Line(DefinitionLine(access, modifiers, "class", name, implements));
            return Scope();
        }
        public CodeWriterScope Enum(string? access, string? modifiers, string? name, string? implements = null) => Definition(access, modifiers, "enum", name, implements);
        public CodeWriterScope Struct(string? access, string? modifiers, string? name, string? implements = null) => Definition(access, modifiers, "struct", name, implements);

        private static string MethodDeclaration(string? modifiers, string? returnType, string? name, params string[] parameters)
        {
            var headerText = new[] { modifiers, returnType, name }.JoinIgnoreEmpty(" ");
            var parametersText = parameters.JoinIgnoreEmpty(", ");
            return $"{headerText}({parametersText})";
        }

        public CodeWriterScope Method(string? modifiers, string? returnType, string? name, params string[] parameters)
        {
            Line(MethodDeclaration(modifiers, returnType, name, parameters));
            return Scope();
        }

        public CodeWriterScope Try()
        {
            Line("try");
            return Scope();
        }

        public CodeWriterScope Catch(params string[] parameters)
        {
            var parametersText = parameters.JoinIgnoreEmpty(", ");
            Line($"catch{(parameters.Length > 0 ? $"({parametersText})" : String.Empty)}");
            return Scope();
        }

        public CodeWriterScope If(string condition)
        {
            Line($"if({condition})");
            return Scope();
        }

        public CodeWriterScope Else()
        {
            Line("else");
            return Scope();
        }

        public CodeWriterScope ForEach(string statement)
        {
            Line($"foreach({statement})");
            return Scope();
        }

        public CodeWriterScope Switch(string value)
        {
            Line($"switch({value})");
            return Scope();
        }

        public void MethodExpression(string modifiers, string? returnType, string name, string[]? parameters, string expression) =>
            Line($"{MethodDeclaration(modifiers, returnType, name, parameters ?? new string[0])} => {expression};");

        public void EnumValue(string value, bool includeComma = true) =>
            Line($"{value}{(includeComma ? "," : String.Empty)}");

        public void AutoProperty(string modifiers, CSharpType type, string name, bool isReadOnly = false, string? initializer = null) =>
            Line($"{modifiers} {Pair(type, name)} {{ get; {(isReadOnly ? String.Empty : "set; ")}}}{initializer}");


        public string Type(CSharpType type)
        {
            string? mappedName = GetKeywordMapping(type.FrameworkType);
            string name = mappedName ?? type.Name;
            if (mappedName == null)
            {
                if (_currentNamespace?.FullName != type.Namespace.FullName)
                {
                    _usingNamespaces.Add(type.Namespace);
                }
            }

            if (type.Arguments.Any())
            {
                var subTypes = type.Arguments.Select(Type).JoinIgnoreEmpty(", ");
                name += $"<{subTypes}>";
            }

            if (type.IsNullable)
            {
                name += "?";
            }

            return name;
        }

        public CodeWriter AppendType(CSharpType type)
        {
            return Append(Type(type));
        }

        public CodeWriter AppendType(Type type, bool isNullable = false)
        {
            return Append(Type(type, isNullable));
        }

        public string Type(Type type, bool isNullable = false) => Type(new CSharpType(type, isNullable));
        public string AttributeType(Type type) => Type(type).Replace("Attribute", String.Empty);

        public string Pair(string typeText, string name) => $"{typeText} {name}";
        public string Pair(CSharpType type, string name) => $"{Type(type)} {name}";
        public string Pair(Type type, string name, bool isNullable = false) => $"{Type(type, isNullable)} {name}";

        private static string? GetKeywordMapping(Type? type) => type switch
        {
            null => null,
            var t when t == typeof(bool) => "bool",
            var t when t == typeof(byte) => "byte",
            var t when t == typeof(sbyte) => "sbyte",
            var t when t == typeof(short) => "short",
            var t when t == typeof(ushort) => "ushort",
            var t when t == typeof(int) => "int",
            var t when t == typeof(uint) => "uint",
            var t when t == typeof(long) => "long",
            var t when t == typeof(ulong) => "ulong",
            var t when t == typeof(char) => "char",
            var t when t == typeof(double) => "double",
            var t when t == typeof(float) => "float",
            var t when t == typeof(object) => "object",
            var t when t == typeof(decimal) => "decimal",
            var t when t == typeof(string) => "string",
            _ => null
        };

        public CodeWriter Literal(object? o)
        {
            return Append(o switch
            {
                null => "null",
                string s => SyntaxFactory.Literal(s).ToString(),
                int i => SyntaxFactory.Literal(i).ToString(),
                decimal d => SyntaxFactory.Literal(d).ToString(),
                double d => SyntaxFactory.Literal(d).ToString(),
                float f => SyntaxFactory.Literal(f).ToString(),
                bool b => b ? "true" : "false",
                _ => throw new NotImplementedException()
            });
        }

        public CodeWriter Line(string str = "")
        {
            _builder.AppendLine(str);
            return this;
        }

        public CodeWriter Append(string str)
        {
            _builder.Append(str);
            return this;
        }

        public CodeWriter Comma() => Append(", ");

        public CodeWriter Space() => Append(" ");

        public CodeWriter Semicolon() => Append(";").Line();

        public string ToFormattedCode()
        {
            if (_builder.Length == 0)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            string[] namespaces = _usingNamespaces
                    .Select(ns=>ns.FullName)
                    .Distinct()
                    .OrderByDescending(ns => ns.StartsWith("System"))
                    .ThenBy(ns=>ns)
                    .ToArray();

            builder.AppendLine("// Copyright (c) Microsoft Corporation. All rights reserved.");
            builder.AppendLine("// Licensed under the MIT License.");
            builder.AppendLine();

            foreach (string ns in namespaces)
            {
                builder.Append("using ").Append(ns).AppendLine(";");
            }

            if (namespaces.Any())
            {
                builder.AppendLine();
            }

            SyntaxNode syntax = SyntaxFactory.ParseCompilationUnit(ToString());
            syntax = Formatter.Format(syntax, new AdhocWorkspace());
            builder.Append(syntax);

            return builder.ToString();
        }

        public override string? ToString() => _builder.ToString();

        internal readonly struct CodeWriterScope : IDisposable
        {
            private readonly CodeWriter _writer;
            private readonly string _end;

            public CodeWriterScope(CodeWriter writer, string end)
            {
                _writer = writer;
                _end = end;
            }

            public void Dispose() => _writer?.Line(_end);
        }
    }
}
