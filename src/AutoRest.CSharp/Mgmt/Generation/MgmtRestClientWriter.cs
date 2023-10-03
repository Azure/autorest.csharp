// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtRestClientWriter
    {
        private const string UserAgentVariable = "userAgent";
        private const string UserAgentField = "_" + UserAgentVariable;

        public void WriteClient(CodeWriter writer, MgmtRestClient restClient)
        {
            using (writer.Namespace(restClient.Type.Namespace))
            {
                using (writer.Scope($"{restClient.Declaration.Accessibility} partial class {restClient.Type:D}"))
                {
                    writer.WriteFieldDeclarations(restClient.Fields);
                    WriteClientCtor(writer, restClient);

                    foreach (var methods in restClient.Methods)
                    {
                        writer.WriteMethod(methods.CreateRequest);

                        WriteMethod(writer, methods.ConvenienceAsync);
                        WriteMethod(writer, methods.Convenience);
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
                }
            }
        }

        private static void WriteMethod(CodeWriter writer, Method? method)
        {
            if (method is null)
            {
                return;
            }

            writer.WriteXmlDocumentationSummary($"{method.Signature.Description}");
            writer.WriteMethodDocumentationSignature(method.Signature);
            writer.WriteMethod(method);

        }

        private static void WriteClientCtor(CodeWriter writer, MgmtRestClient restClient)
        {
            var constructorParameters = restClient.Parameters;
            var constructor = new ConstructorSignature(restClient.Type, null, $"Initializes a new instance of {restClient.Type.Name}", MethodSignatureModifiers.Public, restClient.Parameters);

            writer.WriteMethodDocumentation(constructor);
            using (writer.WriteMethodDeclaration(constructor))
            {
                foreach (Parameter clientParameter in constructorParameters)
                {
                    var field = restClient.Fields.GetFieldByParameter(clientParameter);
                    if (field != null)
                    {
                        writer.WriteVariableAssignmentWithNullCheck($"{field.Name}", clientParameter);
                    }
                }
                writer.Line($"{UserAgentField} = new {typeof(TelemetryDetails)}(GetType().Assembly, {KnownParameters.ApplicationId.Name});");
            }
            writer.Line();
        }
    }
}
