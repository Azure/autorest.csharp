// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using AutoRest.CSharp.LowLevel.Output;
using AutoRest.CSharp.Output.Models;
using Azure.Core.Extensions;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class AspDotNetExtensionWriter
    {
        private CodeWriter _writer;

        private AspDotNetExtension This { get; }

        public AspDotNetExtensionWriter(AspDotNetExtension aspDotNetExtension)
        {
            _writer = new CodeWriter();
            This = aspDotNetExtension;
        }

        public void Write()
        {
            using (_writer.Namespace(This.Declaration.Namespace))
            {
                WriteClassDeclaration();
                using (_writer.Scope())
                {
                    WriteImplementations();
                }
            }
        }

        private void WriteClassDeclaration()
        {
            _writer.WriteXmlDocumentationSummary(This.Description);
            _writer.AppendRaw(This.Declaration.Accessibility)
                .AppendRaw(" static")
                .Append($" partial class {This.Type.Name}");
        }

        private void WriteImplementations()
        {
            foreach (var (signature, (declarations, values)) in This.ExtesnsionMethodsNew)
            {
                using (_writer.WriteCommonMethodWithoutValidation(signature, null, false, false))
                {
                    var builder = signature.Parameters.First();
                    var arguments = signature.ReturnType!.Arguments;
                    var clientType = arguments.First();
                    _writer.Append($"return {builder.Name:I}.{nameof(IAzureClientFactoryBuilderWithCredential.RegisterClientFactory)}")
                        .AppendRaw("<");
                    foreach (var argument in arguments)
                    {
                        _writer.Append($"{argument},");
                    }
                    _writer.RemoveTrailingComma();
                    _writer.AppendRaw(">((");
                    foreach (var declaration in declarations)
                    {
                        _writer.Append($"{declaration},");
                    }
                    _writer.RemoveTrailingComma();
                    _writer.Append($") => new {clientType}(");
                    foreach (var value in values)
                    {
                        _writer.Append($"{value},");
                    }
                    _writer.RemoveTrailingComma();
                    _writer.LineRaw("));");
                }
                _writer.Line();
            }
        }

        private static string MethodSignatureDistinctFunc(MethodSignature signature)
        {
            return string.Join(",", signature.Parameters.Select(parameter => parameter.Type.ToString()));
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
