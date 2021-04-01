// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Runtime.InteropServices.ComTypes;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Responses;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using Response = Azure.Response;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class DataPlaneResponseHeaderGroupWriter
    {
        private const string ResponseParameter = "response";
        private const string ResponseField = "_" + ResponseParameter;

        public void WriteHeaderModel(CodeWriter writer, DataPlaneResponseHeaderGroupType responseHeaderGroup)
        {
            using (writer.Namespace(responseHeaderGroup.Declaration.Namespace))
            {
                writer.UseNamespace(new CSharpType(typeof(ResponseHeadersExtensions)).Namespace);

                using (writer.Scope($"{responseHeaderGroup.Declaration.Accessibility} partial class {responseHeaderGroup.Declaration.Name}"))
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

        private void WriteConstructor(CodeWriter writer, DataPlaneResponseHeaderGroupType responseHeaderGroup)
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
            writer.Append($"public {type} {header.Name} => ");
            if (!type.IsFrameworkType && type.Implementation is EnumType enumType)
            {
                writer.Append($"{ResponseField}.Headers.TryGetValue({header.SerializedName:L}, out {typeof(string)} value) ? ");
                writer.AppendEnumFromString(enumType, w => w.AppendRaw("value"));
                writer.Append($" : ({type.WithNullable(true)}) null;");
            }
            else
            {
                writer.Append($"{ResponseField}.Headers.TryGetValue({header.SerializedName:L}, out {type} value) ? value : null;");
            }

            writer.Line();
        }
    }
}