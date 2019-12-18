// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.ClientModels;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class ResponseHeaderModelModelWriter
    {
        private const string ResponseParameter = "response";
        private const string ResponseField = "_" + ResponseParameter;

        private readonly TypeFactory _typeFactory;

        public ResponseHeaderModelModelWriter(TypeFactory typeFactory)
        {
            _typeFactory = typeFactory;
        }

        public void WriteHeaderModel(CodeWriter writer, ResponseHeaderModel responseHeaderModel)
        {
            var cs = _typeFactory.CreateType(responseHeaderModel.Name);
            using (writer.Namespace(cs.Namespace))
            {
                writer.UseNamespace(new CSharpType(typeof(ResponseHeadersExtensions)).Namespace);

                using (writer.Class("internal", null, cs.Name))
                {
                    WriteField(writer);
                    WriteConstructor(writer, cs);

                    foreach (var method in responseHeaderModel.Headers)
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

        private void WriteConstructor(CodeWriter writer, CSharpType cs)
        {
            using (writer.Method("public", null, cs.Name, writer.Pair(typeof(Response), ResponseParameter)))
            {
                writer.Line($"{ResponseField} = {ResponseParameter};");
            }
        }

        private void WriteHeaderProperty(CodeWriter writer, ResponseHeader header)
        {
            var type = _typeFactory.CreateType(header.Type);
            writer.Line($"public {type} {header.Name} => {ResponseField}.Headers.TryGetValue({header.SerializedName:L}, out {type} value) ? value : null;");
        }
    }
}
