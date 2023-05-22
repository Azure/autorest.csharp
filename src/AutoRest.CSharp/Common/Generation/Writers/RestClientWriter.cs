// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.Responses;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Utilities;
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

                    foreach (var legacyMethod in restClient.Methods)
                    {
                        writer.WriteMethod(legacyMethod.CreateRequest);

                        foreach (var method in legacyMethod.RestClientConvenience)
                        {
                            WriteDocumentation(writer, method.Signature);
                            writer.WriteMethod(method);
                        }

                        if (legacyMethod.ProtocolMethod is {} protocolMethod)
                        {
                            LowLevelClientWriter.WriteProtocolMethods(writer, restClient.Fields, protocolMethod);
                            responseClassifierTypes.Add(protocolMethod.ResponseClassifier);
                        }
                    }

                    foreach (var legacyMethod in restClient.Methods)
                    {
                        if (legacyMethod.CreateNextPageRequest is {} nextPageMethod)
                        {
                            writer.WriteMethod(nextPageMethod);

                            foreach (var method in legacyMethod.RestClientNextPageConvenience)
                            {
                                WriteDocumentation(writer, method.Signature);
                                writer.WriteMethod(method);
                            }
                        }
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

        private static void WriteDocumentation(CodeWriter writer, MethodSignatureBase signature)
        {
            writer.WriteXmlDocumentationSummary($"{signature.SummaryText}")
                .WriteXmlDocumentationParameters(signature.Parameters)
                .WriteXmlDocumentationRequiredParametersException(signature.Parameters)
                .WriteXmlDocumentation("remarks", $"{signature.DescriptionText}");

            if (signature is MethodSignature { ReturnDescription: { } returnDescription })
            {
                writer.WriteXmlDocumentationReturns(returnDescription);
            }
        }
    }
}
