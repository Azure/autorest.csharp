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
    internal record ConvenienceMethod(MethodSignature Signature, IReadOnlyList<ProtocolToConvenienceParameterConverter> ProtocolToConvenienceParameterConverters, CSharpType? ResponseType, Diagnostic? Diagnostic, bool IsPageable, bool IsLongRunning, string? Deprecated)
    {
        public (IReadOnlyList<FormattableString> ParameterValues, Action<CodeWriter> Converter) GetParameterValues(CodeWriterDeclaration contextVariable)
        {
            var (parameterValues, contentInfo, spreadVariable) = PrepareConvenienceMethodParameters(contextVariable);

            var converter = EnsureConvenienceBodyConverter(spreadVariable, contextVariable, contentInfo);

            return (parameterValues, converter);
        }

        private record RequestContentParameterInfo(CodeWriterDeclaration ContentVariable, FormattableString ContentValue);

        private (IReadOnlyList<FormattableString> ParameterValues, RequestContentParameterInfo? ContentInfo,  CodeWriterDeclaration? SpreadVariable) PrepareConvenienceMethodParameters(CodeWriterDeclaration contextVariable)
        {
            CodeWriterDeclaration? spreadVariable = null;
            var parameters = new List<FormattableString>();
            RequestContentParameterInfo? contentInfo = null;
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
                    {
                        var parameter = convenienceParameter.GetConversionFormattable(protocolParameter.Type);
                        if (protocolParameter.Type.EqualsIgnoreNullable(typeof(RequestContent)))
                        {
                            contentInfo = new RequestContentParameterInfo(new CodeWriterDeclaration(KnownParameters.RequestContent.Name), $"{parameter:I}");
                            parameters.Add($"{contentInfo.ContentVariable:I}");
                        }
                        else
                        {
                            parameters.Add(parameter);
                        }
                    }
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

            return (parameters, contentInfo, spreadVariable);
        }

        private Action<CodeWriter> EnsureConvenienceBodyConverter(CodeWriterDeclaration? spreadVariable, CodeWriterDeclaration contextVariable, RequestContentParameterInfo? contentInfo)
        {
            var convenienceSpread = ProtocolToConvenienceParameterConverters.Select(c => c.ConvenienceSpread).WhereNotNull().SingleOrDefault();
            if (spreadVariable == null || convenienceSpread == null)
                return writer =>
                {
                    WriteCancellationTokenToRequestContext(writer, contextVariable);
                    if (contentInfo != null)
                    {
                        WriteBodyToRequestContent(writer, contentInfo.ContentVariable, contentInfo.ContentValue);
                    }
                };

            // we need to get all the property initializers therefore here we use serialization constructor
            var serializationCtor = convenienceSpread.BackingModel.SerializationConstructor;
            var initializers = new List<PropertyInitializer>();
            foreach (var parameter in convenienceSpread.SpreadedParameters)
            {
                var property = serializationCtor.FindPropertyInitializedByParameter(parameter);
                if (property == null)
                    continue;
                initializers.Add(new PropertyInitializer(property.Declaration.Name, property.Declaration.Type, property.IsReadOnly, $"{parameter.Name:I}", parameter.Type));
            }

            return writer =>
            {
                WriteCancellationTokenToRequestContext(writer, contextVariable);
                // when writing the initialization of the model, since values of the parameters we have here might be null, and the serialization constructor will not have initializers in its implementation, we use initialization constructor to initialize the instance.
                writer.WriteInitialization(v => writer.Line($"{convenienceSpread.BackingModel.Type} {spreadVariable:D} = {v};"), convenienceSpread.BackingModel, convenienceSpread.BackingModel.InitializationConstructor, initializers);
            };
        }

        // RequestContext context = FromCancellationToken(cancellationToken);
        private static void WriteCancellationTokenToRequestContext(CodeWriter writer, CodeWriterDeclaration contextVariable)
        {
            writer.Line($"{typeof(RequestContext)} {contextVariable:D} = FromCancellationToken({KnownParameters.CancellationTokenParameter.Name});");
        }

        private static void WriteBodyToRequestContent(CodeWriter writer, CodeWriterDeclaration contentVariable, FormattableString requestContentValue)
        {
            writer.Line($"using {typeof(RequestContent)} {contentVariable:D} = {requestContentValue};");
        }

        public bool IsDeprecatedForExamples()
        {
            if (Deprecated is not null)
                return true;

            var bodyParam = Signature.Parameters.FirstOrDefault(p => p.RequestLocation == RequestLocation.Body);
            if (bodyParam is not null && !bodyParam.Type.IsFrameworkType && bodyParam.Type.Implementation is ModelTypeProvider mtp)
            {
                if (mtp.Deprecated is not null)
                    return true;

                foreach (var property in mtp.Properties)
                {
                    if (!property.ValueType.IsFrameworkType && property.ValueType.Implementation.Deprecated is not null)
                        return true;
                }
            }

            return false;
        }
    }

    internal record ProtocolToConvenienceParameterConverter(Parameter Protocol, Parameter Convenience, ConvenienceParameterSpread? ConvenienceSpread);

    internal record ConvenienceParameterSpread(ModelTypeProvider BackingModel, IEnumerable<Parameter> SpreadedParameters);
}
