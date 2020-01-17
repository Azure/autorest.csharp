// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Utilities;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal class CodeWriter
    {
        private readonly List<string> _usingNamespaces = new List<string>();
        private readonly StringBuilder _builder = new StringBuilder();
        private readonly string _definitionAccessDefault = "public";
        private readonly Stack<CodeWriterScope> _scopes;
        private string? _currentNamespace;

        public CodeWriter()
        {
            _scopes = new Stack<CodeWriterScope>();
            _scopes.Push(new CodeWriterScope(this, ""));
        }

        public CodeWriterScope Scope(FormattableString line, string start = "{", string end = "}")
        {
            return Line(line).ScopeRaw(start, end);
        }

        public CodeWriterScope Scope()
        {
            return ScopeRaw();
        }

        public CodeWriterScope ScopeRaw(string start = "{", string end = "}")
        {
            LineRaw(start);
            CodeWriterScope codeWriterScope = new CodeWriterScope(this, end);
            _scopes.Push(codeWriterScope);
            return codeWriterScope;
        }

        public CodeWriterScope Namespace(string @namespace)
        {
            _currentNamespace = @namespace;
            Line($"namespace {@namespace}");
            return Scope();
        }

        public CodeWriter Append(FormattableString formattableString)
        {
            if (formattableString.ArgumentCount == 0)
            {
                return AppendRaw(formattableString.ToString());
            }

            const string literalFormatString = ":L";
            const string declarationFormatString = ":D"; // :D :)
            foreach ((string Text, bool IsLiteral) part in StringExtensions.GetPathParts(formattableString.Format))
            {
                string text = part.Text;
                if (part.IsLiteral)
                {
                    AppendRaw(text);
                    continue;
                }

                var formatSeparatorIndex = text.IndexOf(':');

                int index = int.Parse(formatSeparatorIndex == -1
                    ? text.AsSpan()
                    : text.AsSpan(0, formatSeparatorIndex));

                var argument = formattableString.GetArgument(index);
                var isLiteral = text.EndsWith(literalFormatString);
                var isDeclaration = text.EndsWith(declarationFormatString);
                switch (argument)
                {
                    case CodeWriterDelegate d:
                        Append(d);
                        break;
                    case Type t:
                        AppendType(t);
                        break;
                    case CSharpType t:
                        AppendType(t);
                        break;
                    default:
                        if (isLiteral)
                        {
                            Literal(argument);
                            continue;
                        }

                        string? s = argument?.ToString();

                        if (s == null)
                        {
                            throw new ArgumentNullException(index.ToString());
                        }


                        if (isDeclaration)
                        {
                            Declaration(s);
                        }
                        else
                        {
                            AppendRaw(s);
                        }
                        break;
                }
            }

            return this;
        }

        private string DefinitionLine(string? access, string? modifiers, string kind, string? name, string? implements = null) =>
            new[] { access ?? _definitionAccessDefault, modifiers, kind, name , !string.IsNullOrWhiteSpace(implements)? $": {implements}" : null }.JoinIgnoreEmpty(" ");

        public CodeWriterScope Class(string? access, string? modifiers, string? name, string? implements = null)
        {
            LineRaw(DefinitionLine(access, modifiers, "class", name, implements));
            return Scope();
        }

        private static string MethodDeclaration(string? modifiers, string? returnType, string? name, params string[] parameters)
        {
            var headerText = new[] { modifiers, returnType, name }.JoinIgnoreEmpty(" ");
            var parametersText = parameters.JoinIgnoreEmpty(", ");
            return $"{headerText}({parametersText})";
        }

        public CodeWriterScope Method(string? modifiers, string? returnType, string? name, params string[] parameters)
        {
            LineRaw(MethodDeclaration(modifiers, returnType, name, parameters));
            return Scope();
        }

        public CodeWriterScope If(string condition)
        {
            LineRaw($"if({condition})");
            return Scope();
        }

        public CodeWriterScope Switch(string value)
        {
            LineRaw($"switch({value})");
            return Scope();
        }

        public void UseNamespace(string @namespace)
        {
            _usingNamespaces.Add(@namespace);
        }

        public string GetTemporaryVariable(string s)
        {
            if (IsAvailable(s))
            {
                return s;
            }

            for (int i = 0; i < 100; i++)
            {
                var name = s + i;
                if (IsAvailable(name))
                {
                    return name;
                }
            }
            throw new InvalidOperationException("Can't find suitable variable name.");
        }

        private bool IsAvailable(string s)
        {
            foreach (CodeWriterScope codeWriterScope in _scopes)
            {
                if (codeWriterScope.Identifiers.Contains(s))
                {
                    return false;
                }
            }

            return true;
        }

        public string Type(CSharpType type)
        {
            string? mappedName = GetKeywordMapping(type.FrameworkType);
            string name = mappedName ?? type.Name;
            if (mappedName == null)
            {
                if (_currentNamespace != type.Namespace)
                {
                    UseNamespace(type.Namespace);
                }

                name = type.Namespace + "." + type.Name;
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
            return AppendRaw(Type(type));
        }

        public CodeWriter AppendType(Type type, bool isNullable = false)
        {
            return AppendRaw(Type(type, isNullable));
        }

        public string Type(Type type, bool isNullable = false) => Type(new CSharpType(type, isNullable));
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
            return AppendRaw(o switch
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

        public CodeWriter Line(FormattableString formattableString)
        {
            Append(formattableString);
            Line();
            return this;
        }

        public CodeWriter Line()
        {
            _builder.AppendLine();
            return this;
        }

        public CodeWriter LineRaw(string str)
        {
            _builder.AppendLine(str);
            return this;
        }

        public CodeWriter AppendRaw(string str)
        {
            _builder.Append(str);
            return this;
        }

        public CodeWriter Declaration(string name)
        {
            _scopes.Peek().Identifiers.Add(name);

            return AppendRaw(name);
        }

        public CodeWriter Append(CodeWriterDelegate writerDelegate)
        {
            writerDelegate(this);
            return this;
        }

        public string ToFormattedCode()
        {
            if (_builder.Length == 0)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            string[] namespaces = _usingNamespaces
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

            builder.Append(_builder);

            return builder.ToString();
        }

        public override string? ToString() => _builder.ToString();

        internal class CodeWriterScope : IDisposable
        {
            private readonly CodeWriter _writer;
            private readonly string _end;

            public List<string> Identifiers { get; } = new List<string>();

            public CodeWriterScope(CodeWriter writer, string end)
            {
                _writer = writer;
                _end = end;
            }

            public void Dispose()
            {
                _writer.PopScope(this);
                _writer?.LineRaw(_end);
            }
        }

        private void PopScope(CodeWriterScope expected)
        {
            var actual = _scopes.Pop();
            Debug.Assert(actual == expected);
        }

        public void RemoveTrailingComma()
        {
            for (int i = _builder.Length - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(_builder[i]))
                {
                    continue;
                }

                if (_builder[i] == ',')
                {
                    _builder.Remove(i, _builder.Length - i);
                }

                break;
            }
        }
    }
}
