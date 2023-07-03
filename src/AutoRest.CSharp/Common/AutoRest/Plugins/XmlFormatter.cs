// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using AutoRest.CSharp.Output.Models;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.AutoRest.Plugins
{
    internal class XmlFormatter
    {
        internal static async Task<string> FormatAsync(XDocument document, SyntaxTree syntaxTree)
        {
            var methods = await GetMethods(syntaxTree);
            // first we need to get the members
            var members = document.Element("doc")!
                .Element("members")!
                .Elements("member")!;

            foreach (var member in members)
            {
                // get the example element
                var exampleElement = member.Element("example");
                if (exampleElement == null)
                    continue;

                foreach (var codeElement in exampleElement.Elements("code"))
                {
                    var testMethodName = codeElement.Value;
                    // find the magic comment and replace it with real code
                    if (methods.TryGetValue(testMethodName, out var methodDeclaration))
                    {
                        var lines = GetLines(methodDeclaration.Body!);
                        var content = FormatContent(lines);
                        // this will give you
                        // <[[CDATA
                        // var our = code;
                        // ]]>
                        codeElement.ReplaceAll(new XCData(content));
                    }
                }
            }

            var writer = new XmlStringWriter();
            XmlWriterSettings settings = new XmlWriterSettings { OmitXmlDeclaration = false, Indent = true };
            using (XmlWriter xw = XmlWriter.Create(writer, settings))
            {
                document.Save(xw);
            }

            return writer.ToString();
        }

        private static IEnumerable<string> GetLines(BlockSyntax methodBlock)
        {
            if (!methodBlock.Statements.Any())
                return Array.Empty<string>();

            // here we have to get the string of all statements and then split by new lines
            // this is because in the StatementSyntax, the NewLines (\n or \r\n) could appear at the end of the statement or at the beginning of the statement
            // therefore to keep it simple, we just combine all the text together and then split by the new lines to trim the extra spaces in front of every line
            var builder = new StringBuilder();
            foreach (var statement in methodBlock.Statements)
            {
                builder.Append(statement.ToFullString());
            }

            return builder.ToString().Split(Environment.NewLine);
        }

        /// <summary>
        /// This method trims the leading spaces of the lines, and it also adds proper amount of spaces to the content of spaces because of the bug of Roslyn: https://github.com/dotnet/roslyn/issues/8269
        /// </summary>
        /// <param name="lines"></param>
        /// <returns></returns>
        private static string FormatContent(IEnumerable<string> lines)
        {
            if (!lines.Any())
                return string.Empty;

            var builder = new StringBuilder();

            var first = lines.First();
            var trimed = first.TrimStart();
            var spaces = first.Length - trimed.Length;
            //int level = 0;
            foreach (var line in lines)
            {
                if (line.Length >= spaces)
                    builder.AppendLine().Append(line.Substring(spaces));
                else
                    builder.AppendLine().Append(line.TrimStart());
            }

            return builder.ToString();
        }

        private static async Task<Dictionary<string, MethodDeclarationSyntax>> GetMethods(SyntaxTree syntaxTree)
        {
            var result = new Dictionary<string, MethodDeclarationSyntax>();
            var root = await syntaxTree.GetRootAsync();

            foreach (var method in root.DescendantNodes().OfType<MethodDeclarationSyntax>())
            {
                result.Add(method.Identifier.Text, method);
            }

            return result;
        }

        private class XmlStringWriter : StringWriter
        {
            public override Encoding Encoding => Encoding.UTF8;
        }
    }
}
