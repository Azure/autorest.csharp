﻿// Copyright (c) Microsoft Corporation. All rights reserved.
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
        private readonly Stack<CodeWriterScope> _scopes;
        private string? _currentNamespace;

        public CodeWriter()
        {
            _scopes = new Stack<CodeWriterScope>();
            _scopes.Push(new CodeWriterScope(this, "", false));
        }

        public CodeWriterScope Scope(FormattableString line, string start = "{", string end = "}", bool newLine = true)
        {
            return Line(line).ScopeRaw(start, end, newLine);
        }

        public CodeWriterScope Scope()
        {
            return ScopeRaw();
        }

        private CodeWriterScope ScopeRaw(string start = "{", string end = "}", bool newLine = true)
        {
            LineRaw(start);
            CodeWriterScope codeWriterScope = new CodeWriterScope(this, end, newLine);
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
                        AppendType(new CSharpType(t, false));
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

        private void AppendType(CSharpType type)
        {
            string? mappedName = type.IsFrameworkType ? GetKeywordMapping(type.FrameworkType) : null;
            if (mappedName == null)
            {
                if (_currentNamespace != type.Namespace)
                {
                    UseNamespace(type.Namespace);
                }

                AppendRaw(type.Namespace);
                AppendRaw(".");
                AppendRaw(type.Name);
            }
            else
            {
                AppendRaw(mappedName);
            }

            if (type.Arguments.Any())
            {
                AppendRaw("<");
                foreach (var typeArgument in type.Arguments)
                {
                    AppendType(typeArgument);
                    AppendRaw(", ");
                }
                RemoveTrailingComma();
                AppendRaw(">");
            }

            if (type.IsNullable && type.IsValueType)
            {
                AppendRaw("?");
            }
        }

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
        {;
            if (!PreviousLineIsOpenBrace())
            {
                LineRaw();
            }

            return this;
        }

        private bool PreviousLineIsOpenBrace()
        {
            int? lastCharIndex = FindLastNonWhitespaceCharacterIndex();
            if (!lastCharIndex.HasValue || _builder[lastCharIndex.Value] != '{')
            {
                return false;
            }

            for (int i = lastCharIndex.Value - 1; i >= 0; i--)
            {
                var c = _builder[i];
                if (c == '\r' || c == '\n')
                {
                    return true;
                }

                if (char.IsWhiteSpace(c))
                {
                    continue;
                }

                return false;
            }

            return true;

        }

        private CodeWriter LineRaw()
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
            builder.AppendLine("// <auto-generated/>");
            builder.AppendLine();
            builder.AppendLine("#nullable disable");
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
            private readonly bool _newLine;

            public List<string> Identifiers { get; } = new List<string>();

            public CodeWriterScope(CodeWriter writer, string end, bool newLine)
            {
                _writer = writer;
                _end = end;
                _newLine = newLine;
            }

            public void Dispose()
            {
                _writer.PopScope(this);
                _writer?.AppendRaw(_end);

                if (_newLine)
                {
                    _writer?.LineRaw();
                }
            }
        }

        private void PopScope(CodeWriterScope expected)
        {
            var actual = _scopes.Pop();
            Debug.Assert(actual == expected);
        }

        private int? FindLastNonWhitespaceCharacterIndex()
        {
            for (int i = _builder.Length - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(_builder[i]))
                {
                    continue;
                }

                return i;
            }

            return null;
        }

        public void RemoveTrailingComma()
        {
            int? lastCharIndex = FindLastNonWhitespaceCharacterIndex();
            if (lastCharIndex.HasValue && _builder[lastCharIndex.Value] == ',')
            {
                _builder.Remove(lastCharIndex.Value, _builder.Length - lastCharIndex.Value);
            }
        }
    }
}
