// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class MgmtRestClientWriter : RestClientWriter
    {
        private const string UserAgentVariable = "userAgent";
        private const string UserAgentField = "_" + UserAgentVariable;
        private const string ApplicationIdVariable = "applicationId";

        protected override void WriteAdditionalFields(CodeWriter writer)
        {
            writer.Line($"private readonly {typeof(TelemetryDetails)} {UserAgentField};");
        }

        protected override void WriteAdditionalParameters(CodeWriter writer)
        {
            writer.Append($"{typeof(string)} {ApplicationIdVariable},");
        }

        protected override bool UseSDKUserAgent()
        {
            return true;
        }

        protected override bool IsMgmtPlaneLRO(RestClientMethod operation)
        {
            return operation.Operation.IsLongRunning;
        }

        protected override void WriteAdditionalCtorBody(CodeWriter writer)
        {
            writer.Line($"_userAgent = new {typeof(TelemetryDetails)}(GetType().Assembly, {ApplicationIdVariable});");
        }

        protected override void WriteAdditionalXmlDocumentationParameters(CodeWriter writer)
        {
            writer.WriteXmlDocumentationParameter(ApplicationIdVariable, $"The application id to use for user agent.");
        }
    }
}
