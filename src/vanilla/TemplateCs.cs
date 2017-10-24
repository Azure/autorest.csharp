// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
// 

using System.Collections.Generic;
using System.Linq;
using AutoRest.Core;
using AutoRest.Core.Model;
using AutoRest.Core.Utilities;
using AutoRest.CSharp.Model;
using AutoRest.Extensions;

namespace AutoRest.CSharp
{
    public class TemplateCs<T> : Template<T>
    {
        private readonly string xmlDocPrefix = "/// ";
        private readonly string baseUriOfTheService = "base URI of the service";


        public string XmlDoc(string tag, Dictionary<string, string> arguments, string content)
        {
            return $@"
{xmlDocPrefix}<{tag}{string.Concat(arguments.Select(arg => $" {arg.Key}='{arg.Value}'"))}>
{WrapComment(xmlDocPrefix, content)}
{xmlDocPrefix}</{tag}>
".TrimStart();
        }


        public string XmlDocSummary(string content)
            => XmlDoc(
                "summary",
                new Dictionary<string, string> { },
                content);
        public string XmlDocRemarks(string content)
            => XmlDoc(
                "remarks",
                new Dictionary<string, string> { },
                content);
        public string XmlDocHandleDescriptionSummaryExternalDocs(string description, string summary, string externalDocsUrl)
        {
            bool haveDescription = !string.IsNullOrEmpty(description);
            bool haveSummary = !string.IsNullOrEmpty(summary);
            string result = "";
            if (haveDescription || haveSummary)
            {
                result += XmlDocSummary((haveSummary ? summary.EscapeXmlComment() : description.EscapeXmlComment()) + (string.IsNullOrEmpty(externalDocsUrl) ? "" : $"\n<see href='{externalDocsUrl}' />"));
            }
            if (haveDescription && haveSummary)
            {
                result += "\n";
                result += XmlDocRemarks(description.EscapeXmlComment());
            }
            return result;
        }
        public string XmlDocParamRaw(string name, string description)
            => XmlDoc(
                "param",
                new Dictionary<string, string> { { "name", name } },
                description);
        public string XmlDocParam(string name, string descriptionThe, bool optional = false)
            => XmlDocParamRaw(name, (optional ? "Optional. " : "") + $"The {descriptionThe}.");
        public string XmlDocException(string type, string descriptionThrownWhen)
            => XmlDoc(
                "exception",
                new Dictionary<string, string> { { "cref", type } },
                $"Thrown when {descriptionThrownWhen}.");
                

        public string XmlDocProp(bool settable, string descriptionGetsSets)
            => XmlDocSummary($"Gets{(settable ? " or sets" : "")} {descriptionGetsSets}.");
        public string XmlDocCtor(string type)
            => XmlDocSummary($"Initializes a new instance of the {type.EscapeXmlComment()} class.");

        public string XmlDocParamCustomHeaders()
            => XmlDocParam("customHeaders", "headers that will be added to request");
        public string XmlDocParamCancellationToken()
            => XmlDocParam("cancellationToken", "cancellation token");
        public string XmlDocParamBaseUriOptional()
            => XmlDocParam("baseUri", baseUriOfTheService, true);

        public string XmlDocPropSerializationSettings()
            => XmlDocProp(true, "JSON serialization settings");
        public string XmlDocPropDeserializationSettings()
            => XmlDocProp(true, "JSON deserialization settings");
        public string XmlDocPropBaseUri()
            => XmlDocProp(true, "the " + baseUriOfTheService);

        public string ParamNullCheck(string name)
        {
            return $@"
if ({name} == null)
{{
    throw new System.ArgumentNullException(nameof({name}));
}}
".TrimStart();
        }
    }
}