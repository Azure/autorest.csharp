// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class SerializationWriter
    {
        public void WriteSerialization(CodeWriter writer, TypeProvider schema)
        {
            switch (schema)
            {
                case SerializableObjectType objectSchema:
                    if (objectSchema.IncludeSerializer || objectSchema.IncludeDeserializer)
                    {
                        WriteObjectSerialization(writer, objectSchema);
                    }
                    break;
                case EnumType { IsExtensible: false } sealedChoiceSchema:
                    WriteEnumSerialization(writer, sealedChoiceSchema);
                    break;
            }
        }

        private void WriteObjectSerialization(CodeWriter writer, SerializableObjectType model)
            => WriteObjectSerialization(writer, model, model.Declaration, model.JsonSerialization, model.XmlSerialization, model.IsStruct, model.IncludeSerializer, model.IncludeDeserializer);

        private void WriteObjectSerialization(CodeWriter writer, SerializableObjectType model, TypeDeclarationOptions declaration, JsonObjectSerialization? jsonSerialization, XmlObjectSerialization? xmlSerialization, bool isStruct, bool includeSerializer, bool includeDeserializer)
        {
            var hasJson = jsonSerialization != null;
            var hasXml = xmlSerialization != null;

            if (!hasJson && !hasXml)
            {
                return;
            }

            using (writer.Namespace(declaration.Namespace))
            {
                writer.Append($"{declaration.Accessibility} partial {(isStruct ? "struct" : "class")} {declaration.Name}");

                if (includeSerializer)
                {
                    writer
                        .AppendIf($": ", hasJson || hasXml)
                        .AppendIf($"{Configuration.ApiTypes.IUtf8JsonSerializableType}, ", hasJson)
                        .AppendIf($"{typeof(IXmlSerializable)}, ", hasXml)
                        .RemoveTrailingComma();
                }

                writer.Line();
                using (writer.Scope())
                {
                    foreach (var method in model.Methods)
                    {
                        writer.WriteMethodDocumentation(method.Signature);
                        writer.WriteMethod(method);
                    }
                }
            }
        }

        public static void WriteEnumSerialization(CodeWriter writer, EnumType enumType)
        {
            using (writer.Namespace(enumType.Declaration.Namespace))
            {
                string declaredTypeName = enumType.Declaration.Name;
                using (writer.Scope($"internal static partial class {declaredTypeName}Extensions"))
                {
                    if (enumType.SerializationMethod is { } serializationMethod)
                    {
                        writer.WriteMethod(serializationMethod);
                    }
                    writer.WriteMethod(enumType.DeserializationMethod);
                }
            }
        }
    }
}
