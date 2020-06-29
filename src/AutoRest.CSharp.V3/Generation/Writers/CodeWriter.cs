﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Input;
using AutoRest.CSharp.V3.Utilities;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal class CodeWriter
    {
        private const int DefaultLength = 1024;
        private static readonly string _newLine = "\n";
        private static readonly string _braceNewLine = "{\n";

        private readonly List<string> _usingNamespaces = new List<string>();

        private readonly Stack<CodeWriterScope> _scopes;
        private string? _currentNamespace;

        private char[] _builder;
        private int _position;

        public CodeWriter()
        {
            _builder = ArrayPool<char>.Shared.Rent(DefaultLength);

            _scopes = new Stack<CodeWriterScope>();
            _scopes.Push(new CodeWriterScope(this, "", false));
        }

        public CodeWriterScope Scope(FormattableString line, string start = "{", string end = "}", bool newLine = true)
        {
            CodeWriterScope codeWriterScope = new CodeWriterScope(this, end, newLine);
            _scopes.Push(codeWriterScope);
            Line(line);
            LineRaw(start);
            return codeWriterScope;
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
            const string identifierFormatString = ":I";
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
                var isIdentifier = text.EndsWith(identifierFormatString);
                switch (argument)
                {
                    case CodeWriterDelegate d:
                        Append(d);
                        break;
                    case Type t:
                        AppendType(new CSharpType(t));
                        break;
                    case CSharpType t:
                        AppendType(t);
                        break;
                    case CodeWriterDeclaration declaration:
                        if (isDeclaration)
                        {
                            Declaration(declaration);
                        }
                        else
                        {
                            Identifier(declaration.ActualName);
                        }
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
                        else if (isIdentifier)
                        {
                            Identifier(s);
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
            if (_currentNamespace != @namespace)
            {
                _usingNamespaces.Add(@namespace);
            }
        }

        private string GetTemporaryVariable(string s)
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
            if (_scopes.TryPeek(out var currentScope))
            {
                if (currentScope.AllDefinedIdentifiers.Contains(s))
                {
                    return false;
                }
            }

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
                UseNamespace(type.Namespace);

                AppendRaw("global::");
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
                long l => SyntaxFactory.Literal(l).ToString(),
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
            LineRaw(string.Empty);

            return this;
        }

        private Span<char> WrittenText => _builder.AsSpan(0, _position);
        private Span<char> PreviousLine
        {
            get
            {
                var writtenText = WrittenText;

                var indexOfNewLine = writtenText.LastIndexOf(_newLine);
                if (indexOfNewLine == -1)
                {
                    return Span<char>.Empty;
                }

                var writtenTextBeforeLastLine = writtenText.Slice(0, indexOfNewLine);
                var indexOfPreviousNewLine = writtenTextBeforeLastLine.LastIndexOf(_newLine);
                if (indexOfPreviousNewLine == -1)
                {
                    return writtenText.Slice(0, indexOfNewLine + 1);
                }

                return writtenText.Slice(indexOfPreviousNewLine + 1, indexOfNewLine - indexOfPreviousNewLine);
            }
        }

        private Span<char> CurrentLine
        {
            get
            {
                var writtenText = WrittenText;

                var indexOfNewLine = writtenText.LastIndexOf(_newLine);
                if (indexOfNewLine == -1)
                {
                    return writtenText;
                }

                return writtenText.Slice(indexOfNewLine + 1);
            }
        }

        private void EnsureSpace(int space)
        {
            if (_builder.Length - _position < space)
            {
                var newBuilder = ArrayPool<char>.Shared.Rent(Math.Max(_builder.Length + space, _builder.Length * 2));
                _builder.AsSpan().CopyTo(newBuilder);

                ArrayPool<char>.Shared.Return(_builder);
                _builder = newBuilder;
            }
        }

        public CodeWriter LineRaw(string str)
        {
            AppendRaw(str);

            var previousLine = PreviousLine;

            if (previousLine.Contains('{'))
            {

            }
            if (CurrentLine.IsEmpty &&
                (previousLine.SequenceEqual(_newLine) || previousLine.EndsWith(_braceNewLine)))
            {
                return this;
            }

            AppendRaw(_newLine);

            return this;
        }

        public CodeWriter AppendRaw(string str)
        {
            EnsureSpace(str.Length);
            str.AsSpan().CopyTo(_builder.AsSpan().Slice(_position));
            _position += str.Length;
            return this;
        }

        public CodeWriter Identifier(string identifier)
        {
            if (StringExtensions.IsCSharpKeyword(identifier))
            {
                AppendRaw("@");
            }
            return AppendRaw(identifier);
        }

        private CodeWriter Declaration(string declaration)
        {
            foreach (var scope in _scopes)
            {
                scope.AllDefinedIdentifiers.Add(declaration);
            }

            _scopes.Peek().Identifiers.Add(declaration);

            return Identifier(declaration);
        }

        public CodeWriter Declaration(CodeWriterDeclaration declaration)
        {
            declaration.SetActualName(GetTemporaryVariable(declaration.RequestedName));
            return Declaration(declaration.ActualName);
        }

        public CodeWriter Append(CodeWriterDelegate writerDelegate)
        {
            writerDelegate(this);
            return this;
        }

        public override string ToString()
        {
            return ToString(true);
        }

        public string ToString(bool header)
        {
            if (_position == 0)
            {
                return string.Empty;
            }

            var builder = new StringBuilder();
            string[] namespaces = _usingNamespaces
                    .Distinct()
                    .OrderByDescending(ns => ns.StartsWith("System"))
                    .ThenBy(ns=>ns)
                    .ToArray();
            if (header)
            {
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
            }

            // Normalize newlines
            builder.AppendLine(new string(_builder.AsSpan(0, _position).Trim()).Replace(_newLine, Environment.NewLine));

            return builder.ToString();
        }

        internal class CodeWriterScope : IDisposable
        {
            private readonly CodeWriter _writer;
            private readonly string? _end;
            private readonly bool _newLine;

            public HashSet<string> Identifiers { get; } = new HashSet<string>();

            public HashSet<string> AllDefinedIdentifiers { get; } = new HashSet<string>();

            public CodeWriterScope(CodeWriter writer, string? end, bool newLine)
            {
                _writer = writer;
                _end = end;
                _newLine = newLine;
            }

            public void Dispose()
            {
                if (_writer != null)
                {
                    _writer.PopScope(this);
                    if (_end != null)
                    {
                        _writer.TrimNewLines();
                        _writer.AppendRaw(_end);
                    }

                    if (_newLine)
                    {
                        _writer.Line();
                    }
                }
            }
        }

        private void TrimNewLines()
        {
            while (PreviousLine.SequenceEqual(_newLine) &&
                CurrentLine.IsEmpty)
            {
                _position--;
            }
        }

        private void PopScope(CodeWriterScope expected)
        {
            var actual = _scopes.Pop();
            Debug.Assert(actual == expected);
        }

        private int? FindLastNonWhitespaceCharacterIndex()
        {
            var text = WrittenText;
            for (int i = text.Length - 1; i >= 0; i--)
            {
                if (char.IsWhiteSpace(text[i]))
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
            if (lastCharIndex.HasValue && WrittenText[lastCharIndex.Value] == ',')
            {
                _position = lastCharIndex.Value;
            }
        }

        public CodeWriterScope AmbientScope()
        {
            var codeWriterScope =new CodeWriterScope(this, null, false);
            _scopes.Push(codeWriterScope);
            return codeWriterScope;
        }

        public void Append(CodeWriterDeclaration declaration)
        {
            Identifier(declaration.ActualName);
        }
    }
}
