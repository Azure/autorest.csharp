// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Output.Models
{
    internal record ConvenienceMethod(MethodSignature Signature, IReadOnlyList<ProtocolToConvenienceParameterConverter> ProtocolToConvenienceParameterConverters, CSharpType? ResponseType, Diagnostic? Diagnostic)
    {
        public (IReadOnlyList<FormattableString> ParameterValues, Action<CodeWriter> Converter) GetParameterValues(CodeWriterDeclaration contextVariable)
        {
            var (parameterValues, spreadVariable) = PrepareConvenienceMethodParameters(contextVariable);

            var converter = EnsureConvenienceBodyConverter(spreadVariable, contextVariable);

            return (parameterValues, converter);
        }

        private (IReadOnlyList<FormattableString> ParameterValues, CodeWriterDeclaration? SpreadVariable) PrepareConvenienceMethodParameters(CodeWriterDeclaration contextVariable)
        {
            CodeWriterDeclaration? spreadVariable = null;
            var parameters = new List<FormattableString>();
            foreach (var converter in ProtocolToConvenienceParameterConverters)
            {
                var protocolParameter = converter.Protocol;
                var convenienceParameter = converter.Convenience;
                if (convenienceParameter == KnownParameters.CancellationTokenParameter)
                {
                    parameters.Add($"{contextVariable:I}");
                }
                else if (convenienceParameter != null)
                {
                    if (converter.ConvenienceSpread == null)
                        parameters.Add(convenienceParameter.GetConversionFormattable(protocolParameter.Type));
                    else
                    {
                        // we put a declaration here to avoid possible local variable naming collisions
                        spreadVariable = new CodeWriterDeclaration(convenienceParameter.Name);
                        parameters.Add($"{spreadVariable:I}{FormattableStringHelpers.GetConversionMethod(convenienceParameter.Type, protocolParameter.Type)}");
                    }
                }
                else
                {
                    throw new InvalidOperationException($"{protocolParameter.Name} protocol method parameter doesn't have matching field or parameter in convenience method {Signature.Name}");
                }
            }

            return (parameters, spreadVariable);
        }

        private Action<CodeWriter> EnsureConvenienceBodyConverter(CodeWriterDeclaration? spreadVariable, CodeWriterDeclaration contextVariable)
        {
            var convenienceSpread = ProtocolToConvenienceParameterConverters.Select(c => c.ConvenienceSpread).WhereNotNull().SingleOrDefault();
            if (spreadVariable == null || convenienceSpread == null)
                return writer => WriteCancellationTokenToRequestContext(writer, contextVariable);

            var ctor = convenienceSpread.BackingModel.InitializationConstructor; // use initialization constructor here because our parameters here do not have initializers, we get null reference exception if we use serialization constructor.
            var initializers = new List<PropertyInitializer>();
            foreach (var parameter in convenienceSpread.SpreadedParameters)
            {
                var property = ctor.FindPropertyInitializedByParameter(parameter);
                if (property == null)
                    continue;
                initializers.Add(new PropertyInitializer(property.Declaration.Name, property.Declaration.Type, property.IsReadOnly, $"{parameter.Name:I}", parameter.Type));
            }

            return writer =>
            {
                WriteCancellationTokenToRequestContext(writer, contextVariable);
                writer.WriteInitialization(v => writer.Line($"{convenienceSpread.BackingModel.Type} {spreadVariable:D} = {v};"), convenienceSpread.BackingModel, ctor, initializers);
            };
        }

        // RequestContext context = FromCancellationToken(cancellationToken);
        private static void WriteCancellationTokenToRequestContext(CodeWriter writer, CodeWriterDeclaration contextVariable)
        {
            writer.Line($"{typeof(RequestContext)} {contextVariable:D} = FromCancellationToken({KnownParameters.CancellationTokenParameter.Name});");
        }
    }

    internal record ProtocolToConvenienceParameterConverter(Parameter Protocol, Parameter Convenience, ConvenienceParameterSpread? ConvenienceSpread);

    internal record ConvenienceParameterSpread(ModelTypeProvider BackingModel, IEnumerable<Parameter> SpreadedParameters);
}
