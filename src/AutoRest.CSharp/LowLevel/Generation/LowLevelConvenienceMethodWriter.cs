// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelConvenienceMethodWriter : ClientWriter
    {
        private CodeWriter _writer;
        private LowLevelConvenienceMethod _convenienceMethod;

        internal LowLevelConvenienceMethodWriter(CodeWriter writer, LowLevelConvenienceMethod convenienceMethod)
        {
            _writer = writer;
            _convenienceMethod = convenienceMethod;
        }

        internal void WriteClientConvenienceMethod(string diagnosticsPropertyName)
        {
            WriteClientConvenienceMethod(diagnosticsPropertyName, true);
            WriteClientConvenienceMethod(diagnosticsPropertyName, false);
        }

        internal static void WriteCancellationTokenToRequestContextMethod(CodeWriter writer)
        {
            string defaultRequestContextName = "DefaultRequestContext";
            writer.Line($"private static {typeof(RequestContext)} {defaultRequestContextName} = new {typeof(RequestContext)}();");

            var methodSignature = new MethodSignature("FromCancellationToken", null, null, MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static, typeof(RequestContext), null, new List<Parameter> { KnownParameters.CancellationTokenParameter });
            using (writer.WriteMethodDeclaration(methodSignature))
            {
                using (writer.Scope($"if ({KnownParameters.CancellationTokenParameter.Name} == {typeof(CancellationToken)}.None)"))
                {
                    writer.Line($"return {defaultRequestContextName};");
                }

                writer.Line().Line($"return new {typeof(RequestContext)}() {{ CancellationToken = {KnownParameters.CancellationTokenParameter.Name} }};");
            }
            writer.Line();
        }

        private void WriteClientConvenienceMethod(string diagnosticsPropertyName, bool async)
        {
            using (WriteConvenienceMethodDeclaration(async))
            {
                if (_convenienceMethod.Diagnostic != null)
                {
                    using (WriteDiagnosticScope(_writer, _convenienceMethod.Diagnostic, diagnosticsPropertyName))
                    {
                        WriteClientConvenienceMethodBody(async);
                    }
                }
                else
                {
                    WriteClientConvenienceMethodBody(async);
                }
            }

            _writer.Line();
        }

        private CodeWriter.CodeWriterScope WriteConvenienceMethodDeclaration(bool async)
        {
            var methodSignature = _convenienceMethod.Signature.WithAsync(async);
            _writer
                .WriteMethodDocumentation(methodSignature)
                .WriteXmlDocumentation("remarks", $"{methodSignature.DescriptionText}");
            var scope = _writer.WriteMethodDeclaration(methodSignature);
            if (_convenienceMethod.BodyParameter != null)
            {
                _writer.WriteParametersValidation(new[] { _convenienceMethod.BodyParameter });
            }
            return scope;
        }

        private void WriteClientConvenienceMethodBody(bool async)
        {
            string contextVariableName = _convenienceMethod.Signature.Parameters.FirstOrDefault(parameter => parameter.Name == KnownParameters.RequestContext.Name) != null ? $"{KnownParameters.RequestContext.Name}1" : KnownParameters.RequestContext.Name;
            _writer.Line($"{typeof(RequestContext)} {contextVariableName} = FromCancellationToken({KnownParameters.CancellationTokenParameter.Name});");

            string responseVariableName = _convenienceMethod.Signature.Parameters.FirstOrDefault(parameter => parameter.Name == "response") != null ? "response1" : "response";
            var protocolSignature = _convenienceMethod.LowLevelClientMethod.Signature;
            _writer.Line($"{typeof(Response)} {responseVariableName} = {(async ? "await " : String.Empty)}{protocolSignature.Name}{(async ? "Async" : String.Empty)}({string.Join(", ", protocolSignature.Parameters.Select(parameter => ParameterToItsName(parameter)))}){(async ? ".ConfigureAwait(false)" : String.Empty)};");

            if (_convenienceMethod.ResponseType == null)
            {
                _writer.Line($"return {responseVariableName};");
            }
            else
            {
                _writer.Line($"return Response.FromValue({_convenienceMethod.ResponseType}.FromResponse({responseVariableName}), {responseVariableName});");
            }

            string ParameterToItsName(Parameter parameter)
            {
                if (parameter.Name == KnownParameters.RequestContext.Name)
                {
                    return contextVariableName;
                }

                if (parameter.Name == KnownParameters.RequestContent.Name)
                {
                    return $"{_convenienceMethod.BodyParameter!.Name}.ToRequestContent()";
                }

                return parameter.Name;
            }
        }
    }
}
