// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal static class DocumentationWriterExtensions
    {
        private static readonly char[] _newLineChars = {'\r', '\n'};

        public static CodeWriter WriteXmlDocumentationInheritDoc(this CodeWriter writer)
        {
            return writer.Line($"/// <inheritdoc />");
        }

        public static CodeWriter WriteXmlDocumentationSummary(this CodeWriter writer, string? text)
        {
            return writer.WriteXmlDocumentation("summary", text);
        }

        public static CodeWriter WriteXmlDocumentation(this CodeWriter writer, string tag, string? text)
        {
            return writer.WriteDocumentationLines($"<{tag}>", $"</{tag}>", text);
        }

        public static CodeWriter WriteXmlDocumentationParameter(this CodeWriter writer, string name, string? text)
        {
            return writer.WriteDocumentationLines($"<param name=\"{name}\">", "</param>", text);
        }

        private static CodeWriter WriteDocumentationLines(this CodeWriter writer, string prefix, string suffix, string? text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return writer;
            }

            var splitLines = SplitDocLines(text);
            if (splitLines.Length == 1)
            {
                writer.Line($"/// {prefix} {splitLines[0]} {suffix}");
            }
            else
            {
                writer.Line($"/// {prefix}");
                foreach (string line in splitLines)
                {
                    writer.Line($"/// {line}");
                }
                writer.Line($"/// {suffix}");
            }

            return writer;
        }

        private static string[] SplitDocLines(string text)
        {
            var lines = text.Split(_newLineChars);
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = lines[i].TrimEnd();
            }

            if (lines.Length > 0 && !lines[^1].EndsWith("."))
            {
                lines[^1] = lines[^1] + ".";
            }

            return lines;
        }
    }
}
