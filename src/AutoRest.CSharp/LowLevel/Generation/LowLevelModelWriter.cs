// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;

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
                    WritePublicConstructor(writer, model.PublicConstructor, model);
                    if (model.PublicConstructor != model.SerializationConstructor)
                    {
                        WriteSerializationConstructor(writer, model.SerializationConstructor, model);
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

        private static void WritePublicConstructor(CodeWriter writer, ConstructorSignature signature, ModelTypeProvider model)
        {
            writer.WriteMethodDocumentation(signature);
            using (writer.WriteMethodDeclaration(signature))
            {
                WriteFieldsInitialization(writer, signature, model);
                // TODO: Add IReadOnlyDictionary
                foreach (var field in model.Fields.Where(f => TypeFactory.IsReadOnlyList(f.Type)))
                {
                    writer.Line($"{field.Name:I} = new List<{field.Type.Arguments[0]}>(0).AsReadOnly();");
                }
            }
        }

        private static void WriteSerializationConstructor(CodeWriter writer, ConstructorSignature signature, ModelTypeProvider model)
        {
            writer.WriteMethodDocumentation(signature);
            using (writer.WriteMethodDeclaration(signature))
            {
                WriteFieldsInitialization(writer, signature, model);
            }
        }

        private static void WriteFieldsInitialization(CodeWriter writer, ConstructorSignature signature, ModelTypeProvider model)
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
