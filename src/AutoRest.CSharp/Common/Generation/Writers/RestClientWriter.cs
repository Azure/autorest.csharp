// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Output.Models;
using Parameter = AutoRest.CSharp.Output.Models.Shared.Parameter;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class RestClientWriter
    {
        public void WriteClient(CodeWriter writer, RestClient restClient)
        {
            using (writer.Namespace(restClient.Type.Namespace))
            {
                using (writer.Scope($"{restClient.Declaration.Accessibility} partial class {restClient.Type:D}", scopeDeclarations: restClient.Fields.ScopeDeclarations))
                {
                    var responseClassifierTypes = new List<ResponseClassifierType>();
                    writer.WriteFieldDeclarations(restClient.Fields);
                    WriteClientCtor(writer, restClient);

                    foreach (var methods in restClient.Methods)
                    {
                        writer.WriteMethod(methods.CreateRequest);

                        WriteMethod(writer, methods.ConvenienceAsync);
                        WriteMethod(writer, methods.Convenience);

                        if (restClient.ProtocolMethods?.FirstOrDefault(m => m.Operation == methods.Operation) is {} protocolMethod)
                        {
                            LowLevelClientWriter.WriteProtocolMethods(writer, restClient.Fields, protocolMethod);
                            responseClassifierTypes.Add(protocolMethod.ResponseClassifier);
                        }
                    }

                    foreach (var methods in restClient.Methods)
                    {
                        if (methods.CreateNextPageMessage is {} nextPageMethod)
                        {
                            writer.WriteMethod(nextPageMethod);
                        }

                        WriteMethod(writer, methods.NextPageConvenienceAsync);
                        WriteMethod(writer, methods.NextPageConvenience);
                    }

                    LowLevelClientWriter.WriteResponseClassifierMethod(writer, responseClassifierTypes.Distinct());
                }
            }
        }

        private static void WriteClientCtor(CodeWriter writer, RestClient restClient)
        {
            var constructor = restClient.Constructor;
            writer.WriteMethodDocumentation(constructor);
            using (writer.WriteMethodDeclaration(constructor))
            {
                foreach (Parameter clientParameter in constructor.Parameters)
                {
                    var field = restClient.Fields.GetFieldByParameter(clientParameter);
                    if (field != null)
                    {
                        writer.WriteVariableAssignmentWithNullCheck($"{field.Name}", clientParameter);
                    }
                }
            }
            writer.Line();
        }

        private static void WriteMethod(CodeWriter writer, Method? method)
        {
            if (method is null)
            {
                return;
            }

            var signature = method.Signature;
            writer.WriteXmlDocumentationSummary($"{signature.SummaryText}")
                .WriteXmlDocumentationParameters(signature.Parameters)
                .WriteXmlDocumentationRequiredParametersException(signature.Parameters)
                .WriteXmlDocumentation("remarks", $"{signature.DescriptionText}");

            if (signature is MethodSignature { ReturnDescription: { } returnDescription })
            {
                writer.WriteXmlDocumentationReturns(returnDescription);
            }

            writer.WriteMethod(method);
        }
    }
}
