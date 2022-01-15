// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtRestClientWriter : RestClientWriter
    {
        private const string UserAgentVariable = "userAgent";
        private const string UserAgentField = "_" + UserAgentVariable;
        private const string ClientOptionsVariable = "options";

        protected override void WriteAdditionalFields(CodeWriter writer)
        {
            writer.Line($"private readonly {typeof(string)} {UserAgentField};");
        }

        protected override void WriteAdditionalParameters(CodeWriter writer)
        {
            writer.Append($"{typeof(ArmClientOptions)} {ClientOptionsVariable},");
        }

        protected override bool UseUserAgentOverride()
        {
            return true;
        }

        protected override void WriteAdditionalCtorBody(CodeWriter writer)
        {
            writer.UseNamespace("Azure.ResourceManager.Core");
            writer.Line($"_userAgent = HttpMessageUtilities.GetUserAgentName(this, options);");
        }

        protected override void WriteAdditionalXmlDocumentationParameters(CodeWriter writer)
        {
            writer.WriteXmlDocumentationParameter(ClientOptionsVariable, $"The client options used to construct the current client.");
        }
    }
}
