// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Responses;
using Azure.Core;
using Response = Azure.Response;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal class ResponseHeaderGroupWriter
    {
        private const string ResponseParameter = "response";
        private const string ResponseField = "_" + ResponseParameter;

        public void WriteHeaderModel(CodeWriter writer, ResponseHeaderGroupType responseHeaderGroup)
        {
            using (writer.Namespace(responseHeaderGroup.Declaration.Namespace))
            {
                writer.UseNamespace(new CSharpType(typeof(ResponseHeadersExtensions)).Namespace);

                using (writer.Scope($"{responseHeaderGroup.Declaration.Accessibility} class {responseHeaderGroup.Declaration.Name}"))
                {
                    WriteField(writer);
                    WriteConstructor(writer, responseHeaderGroup);

                    foreach (var method in responseHeaderGroup.Headers)
                    {
                        WriteHeaderProperty(writer, method);
                    }
                }
            }
        }

        private void WriteField(CodeWriter writer)
        {
            writer.Line($"private readonly {typeof(Response)} {ResponseField};");
        }

        private void WriteConstructor(CodeWriter writer, ResponseHeaderGroupType responseHeaderGroup)
        {
            using (writer.Scope($"public {responseHeaderGroup.Declaration.Name}({typeof(Response)} {ResponseParameter})"))
            {
                writer.Line($"{ResponseField} = {ResponseParameter};");
            }
        }

        private void WriteHeaderProperty(CodeWriter writer, ResponseHeader header)
        {
            var type = header.Type;
            writer.WriteXmlDocumentationSummary(header.Description);
            writer.Line($"public {type} {header.Name} => {ResponseField}.Headers.TryGetValue({header.SerializedName:L}, out {type} value) ? value : null;");
        }
    }
}
