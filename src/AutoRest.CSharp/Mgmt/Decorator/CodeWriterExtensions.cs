// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;

namespace AutoRest.CSharp.Mgmt.Decorator
{
    internal static class CodeWriterExtensions
    {
        public static CodeWriter WriteParameterNullOrEmptyChecks(this CodeWriter writer, IReadOnlyList<Parameter> parameters)
        {
            foreach (var parameter in parameters)
            {
                writer.WriteParameterNullOrEmptyCheck(parameter);
            }

            writer.Line();
            return writer;
        }

        private static CodeWriter WriteParameterNullOrEmptyCheck(this CodeWriter writer, Parameter parameter)
        {
            if (HasEmptyCheck(parameter) && CSharp.Generation.Writers.CodeWriterExtensions.HasNullCheck(parameter))
                writer.WriteVariableNullOrEmptyCheck(parameter);
            else
                writer.WriteVariableAssignmentWithNullCheck(parameter.Name, parameter);
            return writer;
        }

        public static CodeWriter WriteXmlDocumentationMgmtRequiredParametersException(this CodeWriter writer, IReadOnlyList<Parameter> parameters)
        {
            if (parameters.TryGetRequiredParameters(out var requiredParameters))
            {
                // filter the parameters that cannot be empty
                var nonEmptyParameters = requiredParameters.Where(p => HasEmptyCheck(p)).ToArray();
                if (nonEmptyParameters.Any())
                {
                    var nullOrEmptyDescription = GetExceptionDescription(nonEmptyParameters, true);
                    writer.WriteXmlDocumentationException(typeof(ArgumentException), nullOrEmptyDescription);
                }

                var nonNullParameters = requiredParameters.Except(nonEmptyParameters).ToArray();
                if (nonNullParameters.Any())
                {
                    var nullDescription = GetExceptionDescription(nonNullParameters, false);
                    writer.WriteXmlDocumentationException(typeof(ArgumentNullException), nullDescription);
                }
            }

            return writer;
        }

        private static FormattableString GetExceptionDescription(IReadOnlyList<Parameter> parameters, bool canBeEmpy)
        {
            var message = canBeEmpy ? "null or empty" : "null";
            static string FormatParameters(IReadOnlyList<Parameter> parameters, string message)
            {
                var sb = new StringBuilder();

                var i = 0;
                for (; i < parameters.Count - 1; ++i)
                {
                    sb.Append($"<paramref name=\"{{{i}}}\"/>, ");
                }

                sb.Append($"or <paramref name=\"{{{i}}}\"/> is {message}.");
                return sb.ToString();
            }

            var delimitedParameters = parameters.Count switch
            {
                1 => "<paramref name=\"{0}\"/> is " + message + ".",
                2 => "<paramref name=\"{0}\"/> or <paramref name=\"{1}\"/> is " + message + ".",
                _ => FormatParameters(parameters, message),
            };

            return FormattableStringFactory.Create(delimitedParameters, parameters.Select(p => (object)p.Name).ToArray());
        }

        private static CodeWriter WriteVariableNullOrEmptyCheck(this CodeWriter writer, Parameter parameter)
        {
            using (writer.Scope($"if ({typeof(string)}.IsNullOrEmpty({parameter.Name:I}))"))
            {
                writer.Line($"throw new {typeof(ArgumentException)}($\"Parameter {{nameof({parameter.Name:I})}} cannot be null or empty\", nameof({parameter.Name:I}));");
            }

            return writer;
        }

        private static bool HasEmptyCheck(Parameter parameter) => parameter.RequestLocation == RequestLocation.Path && parameter.Type.IsStringLike() && !parameter.SkipUrlEncoding;
    }
}
