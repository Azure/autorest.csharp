// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class RestApiWriter : ClientWriter
    {
        public void Write(CodeWriter writer, OperationGroup operationGroup, BuildContext context)
        {
            using (writer.Namespace(context.DefaultNamespace))
            {
                writer.WriteXmlDocumentationSummary(operationGroup.Language?.CSharp?.Description);
                string baseClass = $"ContainerBase";
                using (writer.Scope($"public partial class RestApiContainer : {baseClass}"))
                {
                    WriteConstructor(writer);
                    WriteMethods(writer, operationGroup);
                }
            }
        }

        private void WriteMethods(CodeWriter writer, OperationGroup operationGroup)
        {
            throw new NotImplementedException();
        }

        private void WriteConstructor(CodeWriter writer)
        {
            writer.WriteXmlDocumentationSummary("Initializes a new instance of RestApiContainer for mocking.");
            using (writer.Scope($"protected RestApiContainer()"))
            { }

            // write "parent resource" constructor
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of RestApiContainer class.");
            var context = "context";
            writer.WriteXmlDocumentationParameter(context, "The resource representing the parent resource.");
            using (writer.Scope($"internal RestApiContainer({typeof(ContainerBase)} {context}) : base({context})"))
            {
                writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                // todo: after a shared pipeline field is implemented in the base class, replace this with that
                writer.Line($"{PipelineField} = {typeof(ManagementPipelineBuilder)}.Build(Credential, BaseUri, ClientOptions);");
            }
        }
    }
}
