// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
using Humanizer;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.Utilities
{
    internal static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string? text) => String.IsNullOrEmpty(text);
        public static bool IsNullOrWhiteSpace(this string? text) => String.IsNullOrWhiteSpace(text);

        [return: NotNullIfNotNull("name")]
        public static string ToCleanName(this string name, bool camelCase = true)
        {
            StringBuilder nameBuilder = new StringBuilder();

            int i = 0;

            if (char.IsDigit(name[0]))
            {
                nameBuilder.Append("_");
            }
            else
            {
                while (!SyntaxFacts.IsIdentifierStartCharacter(name[i]))
                {
                    i++;
                }
            }

            bool upperCase = false;
            for (; i < name.Length; i++)
            {
                var c = name[i];
                if (!SyntaxFacts.IsIdentifierPartCharacter(c) || c == '_')
                {
                    upperCase = true;
                    continue;
                }

                if (nameBuilder.Length == 0)
                {
                    c = camelCase ? char.ToUpper(c) : char.ToLower(c);
                }

                if (upperCase)
                {
                    c = char.ToUpper(c);
                    upperCase = false;
                }

                nameBuilder.Append(c);
            }

            return nameBuilder.ToString();
        }

        [return: NotNullIfNotNull("name")]
        public static string ToVariableName(this string name) => ToCleanName(name, camelCase: false);

        public static GetPathPartsEnumerator GetPathParts(string? path) => new GetPathPartsEnumerator(path);

        public ref struct GetPathPartsEnumerator
        {
            private ReadOnlySpan<char> _path;
            public Part Current { get; private set; }

            public GetPathPartsEnumerator(ReadOnlySpan<char> path)
            {
                _path = path;
                Current = default;
            }

            public GetPathPartsEnumerator GetEnumerator() => this;

            public bool MoveNext()
            {
                var span = _path;
                if (span.Length == 0)
                {
                    return false;
                }

                var separatorIndex = span.IndexOfAny('{', '}');

                if (separatorIndex == -1)
                {
                    Current = new Part(span, true);
                    _path = ReadOnlySpan<char>.Empty;
                    return true;
                }

                var separator = span[separatorIndex];
                // Handle {{ and }} escape sequences
                if (separatorIndex + 1 < span.Length && span[separatorIndex + 1] == separator)
                {
                    Current = new Part(span.Slice(0, separatorIndex + 1), true);
                    _path = span.Slice(separatorIndex + 2);
                    return true;
                }

                var isLiteral = separator == '{';

                // Skip empty literals
                if (isLiteral && separatorIndex == 0 && span.Length > 1)
                {
                    separatorIndex = span.IndexOf('}');
                    if (separatorIndex == -1)
                    {
                        Current = new Part(span.Slice(1), true);
                        _path = ReadOnlySpan<char>.Empty;
                        return true;
                    }

                    Current = new Part(span.Slice(1, separatorIndex - 1), false);
                }
                else
                {
                    Current = new Part(span.Slice(0, separatorIndex), isLiteral);
                }

                _path = span.Slice(separatorIndex + 1);
                return true;
            }

            public readonly ref struct Part
            {
                public Part(ReadOnlySpan<char> span, bool isLiteral)
                {
                    Span = span;
                    IsLiteral = isLiteral;
                }

                public ReadOnlySpan<char> Span { get; }
                public bool IsLiteral { get; }

                public void Deconstruct(out ReadOnlySpan<char> span, out bool isLiteral)
                {
                    span = Span;
                    isLiteral = IsLiteral;
                }
            }
        }


        public static bool IsCSharpKeyword(string? name)
        {
            switch (name)
            {
                case "abstract":
                case "add":
                case "alias":
                case "as":
                case "ascending":
                case "async":
                case "await":
                case "base":
                case "bool":
                case "break":
                case "by":
                case "byte":
                case "case":
                case "catch":
                case "char":
                case "checked":
                case "class":
                case "const":
                case "continue":
                case "decimal":
                case "default":
                case "delegate":
                case "descending":
                case "do":
                case "double":
                case "dynamic":
                case "else":
                case "enum":
                case "equals":
                case "event":
                case "explicit":
                case "extern":
                case "false":
                case "finally":
                case "fixed":
                case "float":
                case "for":
                case "foreach":
                case "from":
                case "get":
                case "global":
                case "goto":
                // `group` is a contextual to linq queries that we don't generate
                //case "group":
                case "if":
                case "implicit":
                case "in":
                case "int":
                case "interface":
                case "internal":
                case "into":
                case "is":
                case "join":
                case "let":
                case "lock":
                case "long":
                case "nameof":
                case "namespace":
                case "new":
                case "null":
                case "object":
                case "on":
                case "operator":
                // `orderby` is a contextual to linq queries that we don't generate
                //case "orderby":
                case "out":
                case "override":
                case "params":
                case "partial":
                case "private":
                case "protected":
                case "public":
                case "readonly":
                case "ref":
                case "remove":
                case "return":
                case "sbyte":
                case "sealed":
                // `select` is a contextual to linq queries that we don't generate
                // case "select":
                case "set":
                case "short":
                case "sizeof":
                case "stackalloc":
                case "static":
                case "string":
                case "struct":
                case "switch":
                case "this":
                case "throw":
                case "true":
                case "try":
                case "typeof":
                case "uint":
                case "ulong":
                case "unchecked":
                case "unmanaged":
                case "unsafe":
                case "ushort":
                case "using":
                // `value` is a contextual to getters that we don't generate
                // case "value":
                case "var":
                case "virtual":
                case "void":
                case "volatile":
                case "when":
                case "where":
                case "while":
                case "yield":
                    return true;
                default:
                    return false;
            }
        }


        public static string ToPlural(this string single, bool inputIsKnownToBeSingular = true)
        {
            return single.Pluralize(inputIsKnownToBeSingular);
        }

        public static string ToSingular(this string plural, bool inputIsKnownToBePlural = true)
        {
            return plural.Singularize(inputIsKnownToBePlural);
        }
    }
}
