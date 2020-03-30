﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using CaseExtensions;
using Microsoft.CodeAnalysis.CSharp;

namespace AutoRest.CSharp.V3.Utilities
{
    internal static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string? text) => String.IsNullOrEmpty(text);
        public static bool IsNullOrWhiteSpace(this string? text) => String.IsNullOrWhiteSpace(text);

        [return: NotNullIfNotNull("text")]
        private static string? RemoveNonWordCharacters(this string? text) => !text.IsNullOrEmpty() ? Regex.Replace(text, @"\W+", String.Empty) : text;
        [return: NotNullIfNotNull("text")]
        private static string? PrependUnderscoreIfNumbers(this string? text) => Regex.IsMatch(text ?? String.Empty, @"^\d") ? $"_{text}" : text;
        [return: NotNullIfNotNull("text")]
        private static string EscapeKeyword(this string text) => IsCSharpKeyword(text) ? "@" + text : text;

        [return: NotNullIfNotNull("name")]
        public static string ToCleanName(this string name) => name.ToPascalCase().RemoveNonWordCharacters().PrependUnderscoreIfNumbers();
        [return: NotNullIfNotNull("name")]
        public static string? ToVariableName(this string? name) => name?.ToCamelCase().RemoveNonWordCharacters().PrependUnderscoreIfNumbers().EscapeKeyword();

        public static IEnumerable<(string Text, bool IsLiteral)> GetPathParts(string? path)
        {
            if (path == null)
            {
                yield break;
            }

            var index = 0;
            var currentPart = new StringBuilder();
            var innerPart = new StringBuilder();
            while (index < path.Length)
            {
                if (path[index] == '{')
                {
                    var innerIndex = index + 1;
                    while (innerIndex < path.Length)
                    {
                        if (path[innerIndex] == '}')
                        {
                            if (currentPart.Length > 0)
                            {
                                yield return (currentPart.ToString(), true);
                                currentPart.Clear();
                            }

                            yield return (innerPart.ToString(), false);
                            innerPart.Clear();

                            break;
                        }

                        innerPart.Append(path[innerIndex]);
                        innerIndex++;
                    }

                    if (innerPart.Length > 0)
                    {
                        currentPart.Append('{');
                        currentPart.Append(innerPart);
                    }
                    index = innerIndex + 1;
                    continue;
                }
                currentPart.Append(path[index]);
                index++;
            }

            if (currentPart.Length > 0)
            {
                yield return (currentPart.ToString(), true);
            }
        }

        private static bool IsCSharpKeyword(this string? name)
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
                case "group":
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
                case "orderby":
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
                case "select":
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
                case "value":
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

    }
}
