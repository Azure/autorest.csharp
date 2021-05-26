// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.Common.Generation.Writers;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using AutoRest.CSharp.Output.Models;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal abstract class MgmtClientBaseWriter : ClientWriter
    {
        protected const string RestClientField = "_restClient";

        protected MgmtRestClient? _restClient;

        protected void WriteFields(CodeWriter writer, RestClient restClient)
        {
            writer.Line();
            writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsField};");
            writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineField};");

            writer.Line();
            writer.WriteXmlDocumentationSummary($"Represents the REST operations.");
            // subscriptionId might not always be needed. For example `RestOperations` does not have it.
            var subIdIfNeeded = restClient.Parameters.FirstOrDefault()?.Name == "subscriptionId" ? ", Id.SubscriptionId" : "";
            writer.Line($"private {restClient.Type} {RestClientField} => new {restClient.Type}({ClientDiagnosticsField}, {PipelineField}{subIdIfNeeded});");
        }

        protected void WriteContainerCtors(CodeWriter writer, string typeOfThis, Type contextArgumentType)
        {
            // write protected default constructor
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{typeOfThis}\"/> class for mocking.");
            using (writer.Scope($"protected {typeOfThis}()"))
            { }

            // write "parent resource" constructor
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {typeOfThis} class.");
            var parentArgument = "parent";
            writer.WriteXmlDocumentationParameter(parentArgument, "The resource representing the parent resource.");
            using (writer.Scope($"internal {typeOfThis}({contextArgumentType} {parentArgument}) : base({parentArgument})"))
            {
                writer.Line($"{ClientDiagnosticsField} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                // todo: after a shared pipeline field is implemented in the base class, replace this with that
                writer.Line($"{PipelineField} = {typeof(ManagementPipelineBuilder)}.Build(Credential, BaseUri, ClientOptions);");
            }
        }

        protected void WriteContainerProperties(CodeWriter writer, string resourceType)
        {
            // TODO: Remove this if condition after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5800
            if (!resourceType.Contains(".ResourceType"))
            {
                resourceType = $"\"{resourceType}\"";
            }

            writer.Line();
            writer.WriteXmlDocumentationSummary($"Gets the valid resource type for this object");
            writer.Line($"protected override {typeof(ResourceType)} ValidResourceType => {resourceType};");
        }
    }
}
