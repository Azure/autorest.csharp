// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;

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
                writer.WriteVariableNullOrEmptyCheck(parameter.Name);
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
                    var nonEmptyDescription = GetExceptionDescription(nonEmptyParameters, "empty");
                    writer.WriteXmlDocumentationException(typeof(ArgumentException), nonEmptyDescription);
                }

                var nonNullParameters = requiredParameters;
                if (nonNullParameters.Any())
                {
                    var nullDescription = GetExceptionDescription(nonNullParameters, "null");
                    writer.WriteXmlDocumentationException(typeof(ArgumentNullException), nullDescription);
                }
            }

            return writer;
        }

        private static FormattableString GetExceptionDescription(IReadOnlyList<Parameter> parameters, string nullOrEmpty)
        {
            static string FormatParameters(IReadOnlyList<Parameter> parameters, string nullOrEmpty)
            {
                var sb = new StringBuilder();

                var i = 0;
                for (; i < parameters.Count - 1; ++i)
                {
                    sb.Append($"<paramref name=\"{{{i}}}\"/>, ");
                }

                sb.Append($"or <paramref name=\"{{{i}}}\"/> is {nullOrEmpty}.");
                return sb.ToString();
            }

            var delimitedParameters = parameters.Count switch
            {
                1 => "<paramref name=\"{0}\"/> is " + nullOrEmpty + ".",
                2 => "<paramref name=\"{0}\"/> or <paramref name=\"{1}\"/> is " + nullOrEmpty + ".",
                _ => FormatParameters(parameters, nullOrEmpty),
            };

            return FormattableStringFactory.Create(delimitedParameters, parameters.Select(p => (object)p.Name).ToArray());
        }

        public static CodeWriter WriteVariableNullOrEmptyCheck(this CodeWriter writer, string parameterName)
        {
            writer.Line($"{typeof(Argument)}.AssertNotNullOrEmpty({parameterName}, nameof({parameterName}));");

            return writer;
        }

        private static bool HasEmptyCheck(Parameter parameter) => parameter.RequestLocation == RequestLocation.Path && parameter.Type.IsStringLike() && !parameter.SkipUrlEncoding;
    }
}
