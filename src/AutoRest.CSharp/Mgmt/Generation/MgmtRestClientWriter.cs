// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Generation.Writers;
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
            writer.Line($"private readonly {typeof(string)} {UserAgentField};");
        }

        protected override void WriteAdditionalParameters(CodeWriter writer)
        {
            writer.Append($"{typeof(string)} {ApplicationIdVariable},");
        }

        protected override bool UseSDKUserAgent()
        {
            return true;
        }

        protected override void WriteAdditionalCtorBody(CodeWriter writer)
        {
            writer.Line($"_userAgent = {typeof(HttpMessageUtilities)}.GetUserAgentName(this, {ApplicationIdVariable});");
        }

        protected override void WriteAdditionalXmlDocumentationParameters(CodeWriter writer)
        {
            writer.WriteXmlDocumentationParameter(ApplicationIdVariable, $"The application id to use for user agent.");
        }
    }
}
