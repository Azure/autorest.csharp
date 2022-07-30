// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Types;
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
                using (writer.Scope($"{model.Declaration.Accessibility} partial class {model.Type:D}"))
                {
                    // TODO: add inherits or implements
                    WriteFields(writer, model);
                    WriteConstructor(writer, model.PublicConstructor, model);
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

        private static void WriteConstructor(CodeWriter writer, ConstructorSignature signature, ModelTypeProvider model)
        {
            writer.WriteMethodDocumentation(signature);
            using (writer.WriteMethodDeclaration(signature))
            {
                writer.WriteParametersValidation(signature.Parameters);
                writer.Line();
                foreach (var parameter in signature.Parameters)
                {
                    writer.Line($"{model.GetFieldByParameter(parameter).Name:I} = {parameter.Name:I};");
                }
            }
        }

        public static void WriteSerialization(CodeWriter writer, ModelTypeProvider model)
        {
            var serialization = model.CreateSerialization();
            using (writer.Namespace(model.Type.Namespace))
            {
                using (writer.Scope($"{model.Declaration.Accessibility} partial class {model.Type:D} : {typeof(IUtf8JsonSerializable)}"))
                {
                    using (writer.Scope($"void {typeof(IUtf8JsonSerializable)}.{nameof(IUtf8JsonSerializable.Write)}({typeof(Utf8JsonWriter)} writer)"))
                    {
                        writer.ToSerializeCall(serialization, $"this");
                    }
                    writer.Line();
                    using (writer.Scope($"internal static {model.Type} Deserialize{model.Declaration.Name}({typeof(JsonElement)} element)"))
                    {
                        var initializers = writer.WritePropertiesDeserialization(serialization, $"element").ToDictionary(pi => pi.Name);

                        var parameters = model.SerializationConstructor.Parameters
                            .Select(p => initializers[model.GetFieldByParameter(p).Name].Value)
                            .ToArray();

                        if (parameters.Length == initializers.Count)
                        {
                            writer.Append($"return new {model.Type}({parameters.Join(", ")});");
                        }
                        else
                        {
                            throw new NotSupportedException("Initialization of properties outside of serialization constructor is not supported yet.");
                        }
                    }
                }
            }
        }
    }
}
