// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class DocumentationWriterExtensions
    {
        private static readonly char[] _newLineChars = { '\r', '\n' };

        public static CodeWriter WriteXmlDocumentationInheritDoc(this CodeWriter writer, FormattableString? cref = null)
            => cref == null
                ? writer.Line($"/// <inheritdoc />")
                : writer.Line($"/// <inheritdoc cref=\"{cref}\"/>");

        public static CodeWriter WriteXmlDocumentationSummary(this CodeWriter writer, FormattableString? text)
        {
            return writer.WriteXmlDocumentation("summary", text);
        }

        public static CodeWriter WriteXmlDocumentation(this CodeWriter writer, string tag, FormattableString? text)
        {
            return writer.WriteDocumentationLines($"<{tag}>", $"</{tag}>", text);
        }

        public static CodeWriter WriteXmlDocumentationParameters(this CodeWriter writer, IEnumerable<Parameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                writer.WriteXmlDocumentationParameter(parameter);
            }

            return writer;
        }

        public static CodeWriter WriteXmlDocumentationParameter(this CodeWriter writer, string name, FormattableString? text)
        {
            return writer.WriteDocumentationLines($"<param name=\"{name}\">", $"</param>", text);
        }

        /// <summary>
        /// Writes XML documentation for a parameter of a method using a "param" tag.
        /// </summary>
        /// <param name="writer">Writer to which code is written to.</param>
        /// <param name="parameter">The definition of the parameter, including name and description.</param>
        /// <returns></returns>
        public static CodeWriter WriteXmlDocumentationParameter(this CodeWriter writer, Parameter parameter)
        {
            return writer.WriteXmlDocumentationParameter(parameter.Name, $"{parameter.Description}");
        }

        public static CodeWriter WriteXmlDocumentationException(this CodeWriter writer, Type exception, FormattableString? description)
        {
            return writer.WriteDocumentationLines($"<exception cref=\"{exception.FullName}\">", $"</exception>", description);
        }

        public static CodeWriter WriteXmlDocumentationReturns(this CodeWriter writer, FormattableString text)
        {
            return writer.WriteDocumentationLines($"<returns>", $"</returns>", text);
        }

        public static CodeWriter WriteXmlDocumentationRequiredParametersException(this CodeWriter writer, IReadOnlyCollection<Parameter> parameters)
        {
            if (parameters.TryGetRequiredParameters(out var requiredParameters))
            {
                static string FormatParameters(IReadOnlyCollection<Parameter> parameters)
                {
                    var sb = new StringBuilder();

                    var i = 0;
                    for (; i < parameters.Count - 1; ++i)
                    {
                        sb.Append($"<paramref name=\"{{{i}}}\"/>, ");
                    }

                    sb.Append($"or <paramref name=\"{{{i}}}\"/> is null.");
                    return sb.ToString();
                }

                var delimitedParameters = requiredParameters.Count switch
                {
                    1 => "<paramref name=\"{0}\"/> is null.",
                    2 => "<paramref name=\"{0}\"/> or <paramref name=\"{1}\"/> is null.",
                    _ => FormatParameters(requiredParameters),
                };

                var description = FormattableStringFactory.Create(delimitedParameters, requiredParameters.Select(p => (object)p.Name).ToArray());
                return writer.WriteXmlDocumentationException(typeof(ArgumentNullException), description);
            }

            return writer;
        }

        public static CodeWriter WriteDocumentationLines(this CodeWriter writer, FormattableString startTag, FormattableString endTag, FormattableString? text)
            => writer.AppendXmlDocumentation(startTag, endTag, text ?? $"");
    }
}
