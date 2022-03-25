// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Mgmt.Generation
{
    internal class ModelMockWriter
    {
        private CodeWriter _writer;

        public string FileName { get; }

        public ModelMockWriter()
        {
            _writer = new CodeWriter();
            FileName = $"{MgmtContext.RpName}ModelFactory";
        }

        public void Write()
        {
            using (_writer.Namespace($"{MgmtContext.Context.DefaultNamespace}.Models"))
            {
                using (_writer.Scope($"public static class {MgmtContext.RpName}ModelFactory"))
                {
                    foreach (var model in MgmtContext.Library.Models)
                    {
                        if (model is not SchemaObjectType schemaModel)
                            continue;

                        if (!schemaModel.IncludeDeserializer) // this means the full ctor won't be there
                            continue;

                        if (schemaModel.IsAbstract) // do not write method for abstract types
                            continue;

                        var serializationSignature = schemaModel.SerializationConstructor.Signature;
                        var factorySignature = new MethodSignature(
                            schemaModel.Type.Name,
                            serializationSignature.Description,
                            MethodSignatureModifiers.Public | MethodSignatureModifiers.Static,
                            schemaModel.Type,
                            null,
                            serializationSignature.Parameters);

                        _writer.WriteXmlDocumentationSummary($"{factorySignature.Description}");
                        _writer.WriteXmlDocumentationParameters(factorySignature.Parameters);
                        using (_writer.WriteMethodDeclaration(factorySignature, true))
                        {
                            _writer.Append($"return new {schemaModel.Type}(");
                            foreach (var param in factorySignature.Parameters)
                            {
                                _writer.Append($"{param.Name:I},");
                            }
                            _writer.RemoveTrailingComma();
                            _writer.Line($");");
                        }
                        _writer.Line();
                    }
                }
            }
        }

        public override string ToString()
        {
            return _writer.ToString();
        }
    }
}
