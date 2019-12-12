﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.ClientModels;
using Azure;

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
                using (writer.Class("internal", null, cs.Name))
                {
                    WriteField(writer);
                    WriteConstructor(writer, cs);

                    foreach (var method in responseHeaderModel.Headers)
                    {
                        WriteHeaderProperty(writer, method, cs.Namespace);
                    }
                }
            }
        }

        private void WriteField(CodeWriter writer)
        {
            writer.Append("private readonly ")
                .AppendType(typeof(Response))
                .Space()
                .Append(ResponseField)
                .Semicolon();
        }

        private void WriteConstructor(CodeWriter writer, CSharpType cs)
        {
            using (writer.Method("public", null, cs.Name, writer.Pair(typeof(Response), ResponseParameter)))
            {
                writer.Append(ResponseField)
                    .Append("=")
                    .Append(ResponseParameter)
                    .Semicolon();
            }
        }

        private void WriteHeaderProperty(CodeWriter writer, ResponseHeader header, CSharpNamespace csNamespace)
        {
            writer.Append("public ")
                .AppendType(typeof(string), true)
                .Space()
                .Append(header.Name)
                .Append("=>")
                .Append(ResponseField)
                .Append(".Headers.TryGetValue(")
                .Literal(header.Name)
                .Append(", out string value) ? value : null")
                .Semicolon();
        }
    }
}
