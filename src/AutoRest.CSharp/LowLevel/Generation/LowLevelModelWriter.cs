// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
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
                writer.WriteXmlDocumentationSummary($"{model.Description}");
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

        private static void WriteFields(CodeWriter writer, IEnumerable<FieldDeclaration> fields)
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
                var initializedFields = WriteFieldsInitialization(writer, signature, model);
                foreach (var field in model.Fields.Where(f => !initializedFields.Contains(f)))
                {
                    if (field.DefaultValue is not null)
                    {
                        writer.Line($"{field.Name:I} = {field.DefaultValue};");
                    }
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

        private static ISet<FieldDeclaration> WriteFieldsInitialization(CodeWriter writer, ConstructorSignature signature, ModelTypeProvider model)
        {
            writer.WriteParametersValidation(signature.Parameters);
            writer.Line();

            var initializedFields = new HashSet<FieldDeclaration>();
            foreach (var parameter in signature.Parameters)
            {
                var field = model.Fields.GetFieldByParameter(parameter);
                writer
                    .Append($"{field.Name:I} = {parameter.Name:I}")
                    .WriteConversion(parameter.Type, field.Type)
                    .LineRaw(";");
                initializedFields.Add(field);
            }
            return initializedFields;
        }
    }
}
