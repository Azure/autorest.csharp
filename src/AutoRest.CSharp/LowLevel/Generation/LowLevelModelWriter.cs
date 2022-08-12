// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelModelWriter
    {
        public static void WriteType(CodeWriter writer, ModelTypeProvider model)
        {
            using (writer.Namespace(model.Type.Namespace))
            {
                // TODO: need add @doc/@summary support
                //writer.WriteXmlDocumentationSummary($"{model.Summary});
                // TODO: do we have a case to generate struct?
                var scopeDeclarations = new CodeWriterScopeDeclarations(model.Fields.Select(f => f.Declaration));
                using (writer.Scope($"{model.Declaration.Accessibility} partial class {model.Type:D}", scopeDeclarations: scopeDeclarations))
                {
                    // TODO: add inherits or implements
                    WriteConstructor(writer, model.PublicConstructor, model);
                    if (model.PublicConstructor != model.SerializationConstructor)
                    {
                        WriteConstructor(writer, model.SerializationConstructor, model);
                    }
                    writer.Line();
                    WriteFields(writer, model.Fields);
                }
            }
        }

        private static void WriteFields(CodeWriter writer, IReadOnlyList<FieldDeclaration> fields)
        {
            foreach (var field in fields)
            {
                writer.WriteField(field, declareInCurrentScope: false);
            }
            writer.Line();
        }

        private static void WriteConstructor(CodeWriter writer, ConstructorSignature signature, ModelTypeProvider model)
        {
            writer.WriteMethodDocumentation(signature);
            using (writer.WriteMethodDeclaration(signature))
            {
                writer.WriteParametersValidation(signature.Parameters);
                writer.Line();
                foreach (var parameter in signature.Parameters)
                {
                    var field = model.GetFieldByParameterName(parameter.Name);
                    writer
                        .Append($"{field.Name:I} = {parameter.Name:I}")
                        .WriteConversion(parameter.Type, field.Type)
                        .LineRaw(";");
                }
            }
        }
    }
}
