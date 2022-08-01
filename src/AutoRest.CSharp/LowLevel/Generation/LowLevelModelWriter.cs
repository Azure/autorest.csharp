// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class LowLevelModelWriter
    {
        public static void WriteModel(CodeWriter writer, TypeProvider model)
        {
            switch (model)
            {
                case ModelTypeProvider modelType:
                    WriteModelType(writer, modelType);
                    break;
                // TODO: enum types
                //case EnumType e when e.IsExtendable:
                //    WriteExtensibleEnumType(writer, e);
                //    break;
                //case EnumType e when !e.IsExtendable:
                //    WriteSealedEnumType(writer, e);
                //    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private static void WriteModelType(CodeWriter writer, ModelTypeProvider model)
        {
            using (writer.Namespace(model.Type.Namespace))
            {
                // TODO: need add @doc/@summary support
                //writer.WriteXmlDocumentationSummary($"{model.Summary});
                // TODO: do we have a case to generate struct?
                using (writer.Scope($"{model.Declaration.Accessibility} partial class {model.Type:D}"))
                {
                    // TODO: add inherits or implements
                    WriteFields(writer, model);
                    WriteConstructor(writer, model.PublicConstructor, model.Fields);
                }
            }
        }

        private static void WriteFields(CodeWriter writer, ModelTypeProvider model)
        {
            foreach (var field in model.Fields)
            {
                writer.WriteFieldDeclaration(field);
            }
            writer.Line();
        }

        private static void WriteConstructor(CodeWriter writer, ConstructorSignature signature, IReadOnlyList<FieldDeclaration> fields)
        {
            writer.WriteMethodDocumentation(signature);
            using (writer.WriteMethodDeclaration(signature))
            {
                writer.WriteParametersValidation(signature.Parameters);
                writer.Line();
                var fieldDictionary = fields.ToImmutableDictionary(f => f.Name);
                foreach (var parameter in signature.Parameters)
                {
                    if (fieldDictionary.TryGetValue(parameter.Name.FirstCharToUpperCase(), out var field))
                    {
                        writer.Line($"{field.Name} = {parameter.Name};");
                        // TODO: potential type conversion
                    }
                }
            }
        }
    }
}
