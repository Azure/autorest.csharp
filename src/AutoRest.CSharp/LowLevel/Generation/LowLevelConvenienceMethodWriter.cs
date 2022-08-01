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
        internal static void WriteClientConvenienceMethod(CodeWriter writer, LowLevelConvenienceMethod convenienceMethod, string diagnosticsPropertyName, bool async)
        {
            using (WriteConvenienceMethodDeclaration(writer, convenienceMethod, async))
            {
                if (convenienceMethod.Diagnostic != null)
                {
                    using (WriteDiagnosticScope(writer, convenienceMethod.Diagnostic, diagnosticsPropertyName))
                    {
                        WriteClientConvenienceMethodBody(writer, convenienceMethod, async);
                    }
                }
                else
                {
                    WriteClientConvenienceMethodBody(writer, convenienceMethod, async);
                }
            }

            writer.Line();
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

        private static CodeWriter.CodeWriterScope WriteConvenienceMethodDeclaration(CodeWriter writer, LowLevelConvenienceMethod convenienceMethod, bool async)
        {
            var methodSignature = convenienceMethod.Signature.WithAsync(async);
            writer
                .WriteMethodDocumentation(methodSignature)
                .WriteXmlDocumentation("remarks", $"{methodSignature.DescriptionText}");
            var scope = writer.WriteMethodDeclaration(methodSignature);
            if (convenienceMethod.BodyParameter != null)
            {
                writer.WriteParametersValidation(new[] { convenienceMethod.BodyParameter });
            }
            return scope;
        }

        private static void WriteClientConvenienceMethodBody(CodeWriter writer, LowLevelConvenienceMethod convenienceMethod, bool async)
        {
            string contextVariableName = convenienceMethod.Signature.Parameters.FirstOrDefault(parameter => parameter.Name == KnownParameters.RequestContext.Name) != null ? $"{KnownParameters.RequestContext.Name}1" : KnownParameters.RequestContext.Name;
            writer.Line($"{typeof(RequestContext)} {contextVariableName} = FromCancellationToken({KnownParameters.CancellationTokenParameter.Name});");

            string responseVariableName = convenienceMethod.Signature.Parameters.FirstOrDefault(parameter => parameter.Name == "response") != null ? "response1" : "response";
            var protocolSignature = convenienceMethod.LowLevelClientMethod.Signature;
            writer.Line($"{typeof(Response)} {responseVariableName} = {(async ? "await " : String.Empty)}{protocolSignature.Name}{(async ? "Async" : String.Empty)}({string.Join(", ", protocolSignature.Parameters.Select(parameter => ParameterToItsName(parameter)))}){(async ? ".ConfigureAwait(false)" : String.Empty)};");

            if (convenienceMethod.ResponseType == null)
            {
                writer.Line($"return {responseVariableName};");
            }
            else
            {
                writer.Line($"return Response.FromValue({convenienceMethod.ResponseType}.FromResponse({responseVariableName}), {responseVariableName});");
            }

            string ParameterToItsName(Parameter parameter)
            {
                if (parameter.Name == KnownParameters.RequestContext.Name)
                {
                    return contextVariableName;
                }

                if (parameter.Name == KnownParameters.RequestContent.Name)
                {
                    return $"{convenienceMethod.BodyParameter!.Name}.ToRequestContent()";
                }

                return parameter.Name;
            }
        }
    }
}
