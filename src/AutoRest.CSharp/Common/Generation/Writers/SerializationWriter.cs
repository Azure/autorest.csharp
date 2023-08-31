// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Linq;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Azure.Core;
using Azure.Core.Serialization;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class SerializationWriter
    {
        internal static readonly FormattableString DefaultWireOptionsString = $"{typeof(ModelSerializerOptions)}.{nameof(ModelSerializerOptions.DefaultWireOptions)}";

        public void WriteSerialization(CodeWriter writer, TypeProvider schema)
        {
            switch (schema)
            {
                case SerializableObjectType objectSchema:
                    WriteObjectSerialization(writer, objectSchema);
                    break;
                case EnumType { IsExtensible: false } sealedChoiceSchema:
                    WriteEnumSerialization(writer, sealedChoiceSchema);
                    break;
            }
        }

        private void WriteObjectSerialization(CodeWriter writer, SerializableObjectType model)
            => WriteObjectSerialization(writer, model, model.Declaration, model.JsonSerialization, model.XmlSerialization);

        private void WriteObjectSerialization(CodeWriter writer, SerializableObjectType model, TypeDeclarationOptions declaration, JsonObjectSerialization? jsonSerialization, XmlObjectSerialization? xmlSerialization)
        {
            var hasJson = jsonSerialization != null;
            var hasXml = xmlSerialization != null;

            var typeOfT = model.IsUnknownDerivedType ? model.Inherits!.Implementation!.Type : model.Type;
            CSharpType iModelSerializableType = new CSharpType(typeof(IModelSerializable<>), typeOfT);
            CSharpType iModelJsonSerializableType = new CSharpType(typeof(IModelJsonSerializable<>), typeOfT);

            if (!hasJson && !hasXml)
            {
                return;
            }

            using (writer.Namespace(declaration.Namespace))
            {
                if (jsonSerialization is { IncludeConverter: true })
                {
                    writer.Append($"[{typeof(JsonConverter)}(typeof({declaration.Name}Converter))]");
                }

                writer.Append($"{declaration.Accessibility} partial {(model.IsStruct ? "struct" : "class")} {declaration.Name}");

                writer
                    .AppendIf($": ", hasJson || hasXml)
                    .AppendIf($"{typeof(IUtf8JsonSerializable)}, ", hasJson)
                    .AppendIf($"{iModelJsonSerializableType}, ", hasJson)
                    .AppendIf($"{typeof(IModelJsonSerializable<object>)}, ", hasJson && model.IsStruct)
                    .AppendIf($"{typeof(IXmlSerializable)}, ", hasXml)
                    .AppendIf($"{iModelSerializableType}, ", hasXml)
                    .RemoveTrailingComma();

                writer.Line();
                using (writer.Scope())
                {
                    if (xmlSerialization != null)
                    {
                            WriteXmlSerialize(writer, xmlSerialization, iModelSerializableType);
                            WriteXmlDeserialize(writer, declaration, xmlSerialization, hasJson, iModelSerializableType);
                    }

                    if (jsonSerialization != null)
                    {
                            WriteJsonSerialize(writer, jsonSerialization, hasXml, iModelSerializableType, iModelJsonSerializableType);
                            WriteJsonDeserialize(writer, declaration, jsonSerialization, hasXml, iModelSerializableType, iModelJsonSerializableType, model.IsUnknownDerivedType);
                    }

                    WriteIModelSerializableSerialize(writer, iModelSerializableType, false, hasXml, hasJson);
                    WriteIModelSerializableDeserialize(writer, iModelSerializableType, false, hasXml, hasJson);
                    if (model.IsStruct)
                    {
                        WriteIModelSerializableSerialize(writer, iModelSerializableType, true, hasXml, hasJson);
                        WriteIModelSerializableDeserialize(writer, iModelSerializableType, true, hasXml, hasJson);
                    }

                    FormattableString castString = hasXml && !model.IsStruct ? $"({iModelSerializableType})" : (FormattableString)$"";
                    WriteImplicitCastToRequestContent(writer, iModelSerializableType.Arguments[0], castString, model.IsUnknownDerivedType, model.IsStruct);
                    WriteExplicitCastFromResponse(writer, iModelSerializableType.Arguments[0], model.IsStruct, model.IsUnknownDerivedType, hasXml);

                    foreach (var methodDefinition in model.Methods)
                    {
                        using (writer.WriteCommonMethod(methodDefinition.Signature, null, false, methodDefinition.Signature.Modifiers.HasFlag(MethodSignatureModifiers.Public)))
                        {
                            methodDefinition.BodyImplementation(writer, model);
                        }
                        writer.Line();
                    }

                    if (jsonSerialization is { IncludeConverter: true })
                    {
                        WriteCustomJsonConverter(writer, declaration, jsonSerialization.Type);
                    }
                }
            }
        }

        private static void WriteCustomJsonConverter(CodeWriter writer, TypeDeclarationOptions declaration, CSharpType type)
        {
            writer.Append($"internal partial class {declaration.Name}Converter : {typeof(JsonConverter)}<{type}>");
            using (writer.Scope())
            {
                using (writer.Scope($"public override void Write({typeof(Utf8JsonWriter)} writer, {type} model, {typeof(JsonSerializerOptions)} options)"))
                {
                    writer.Append($"writer.{nameof(Utf8JsonWriterExtensions.WriteObjectValue)}(model);");
                }

                using (writer.Scope($"public override {type} Read(ref {typeof(Utf8JsonReader)} reader, {typeof(Type)} typeToConvert, {typeof(JsonSerializerOptions)} options)"))
                {
                    var document = new CodeWriterDeclaration("document");
                    writer.Line($"using var {document:D} = {typeof(JsonDocument)}.ParseValue(ref reader);");
                    writer.Line($"return Deserialize{declaration.Name}({document}.RootElement);");
                }
            }
        }

        private static void WriteXmlSerialize(CodeWriter writer, XmlObjectSerialization serialization, CSharpType iModelSerializableType)
        {
            WiteXmlSerializeImplementation(writer, serialization, iModelSerializableType);
            WriteIXmlSerializableSerialize(writer, serialization, iModelSerializableType);
        }

        private static void WriteValidateFormat(CodeWriter writer, CSharpType modelType)
        {
            writer.Line($"{typeof(ModelSerializerHelper)}.{nameof(ModelSerializerHelper.ValidateFormat)}<{modelType}>(this, options.Format);");
            writer.Line();
        }

        private static void WriteIXmlSerializableSerialize(CodeWriter writer, XmlObjectSerialization serialization, CSharpType iModelSerializableType)
        {
            writer.Append($"void {typeof(IXmlSerializable)}.{nameof(IXmlSerializable.Write)}({typeof(XmlWriter)} writer, {typeof(string)} nameHint)");
            writer.Line($" => Serialize(writer, nameHint, {DefaultWireOptionsString});");
            writer.Line();
        }

        private static void WiteXmlSerializeImplementation(CodeWriter writer, XmlObjectSerialization serialization, CSharpType iModelSerializableType)
        {
            CodeWriterDeclaration nameHint = new CodeWriterDeclaration("nameHint");
            writer.Append($"private void Serialize({typeof(XmlWriter)} writer, {typeof(string)} {nameHint:D}, {typeof(ModelSerializerOptions)} options)");
            using (writer.Scope())
            {
                writer.ToSerializeCall(serialization, nameHint);
            }
            writer.Line();
        }

        private static void WriteXmlDeserialize(CodeWriter writer, TypeDeclarationOptions declaration, XmlObjectSerialization serialization, bool hasJson, CSharpType iModelSerializableType)
        {
            string deserializeMethod = $"Deserialize{declaration.Name}";

            var element = new CodeWriterDeclaration("element");
            using (writer.Scope($"internal static {serialization.Type} {deserializeMethod}({typeof(XElement)} {element:D}, {typeof(ModelSerializerOptions)} options = default)"))
            {
                writer.Line($"options ??= {DefaultWireOptionsString};");
                var propertyVariables = writer.ToDeserializeObjectCall(serialization, element);
                var initializers = new List<PropertyInitializer>();
                foreach (var propertyVariable in propertyVariables)
                {
                    var property = propertyVariable.Key;
                    initializers.Add(new PropertyInitializer(property.PropertyName, property.PropertyType, property.ShouldSkipSerialization, $"{propertyVariable.Value.ActualName}"));
                }

                var objectType = (ObjectType)serialization.Type.Implementation;
                writer.WriteInitialization(v => writer.Line($"return {v};"), objectType, objectType.SerializationConstructor, initializers, true);
            }
            writer.Line();
        }

        private static void WriteXmlInterfaceBody(CodeWriter writer, string deserializeMethod)
        {
            writer.Line($"return {deserializeMethod}({typeof(XElement)}.{nameof(XElement.Load)}(data.ToStream()), options);");
        }

        private static void WriteJsonInterfaceBody(CodeWriter writer, string deserializeMethod)
        {
            writer.Line($"using var doc = {typeof(JsonDocument)}.{nameof(JsonDocument.Parse)}(data);");
            writer.Line($"return {deserializeMethod}(doc.RootElement, options);");
        }

        private static void WriteJsonDeserialize(CodeWriter writer, TypeDeclarationOptions declaration, JsonObjectSerialization serialization, bool hasXml, CSharpType iModelSerializableType, CSharpType iModelJsonSerializableType, bool isUnknownDerivedType)
        {
            string deserializeMethod = $"Deserialize{declaration.Name}";

            bool isStruct = serialization.ObjectType is not null && serialization.ObjectType.IsStruct;

            WriteInternalDeserialize(writer, declaration, serialization, iModelSerializableType, isUnknownDerivedType, deserializeMethod);

            WriteIModelJsonSerializableDeserialize(writer, iModelJsonSerializableType, deserializeMethod, false);

            //add the IModelJsonSerializable<object> if its a struct
            if (isStruct)
            {
                WriteIModelJsonSerializableDeserialize(writer, iModelJsonSerializableType, deserializeMethod, true);
            }
        }

        private static void WriteExplicitCastFromResponse(CodeWriter writer, CSharpType modelType, bool isStruct, bool isUnknownDerivedType, bool isXmlWireFormat)
        {
            string deserializeMethod = $"Deserialize{modelType.Name}";

            if (!isUnknownDerivedType)
            {
                using (writer.Scope($"public static explicit operator {modelType}({typeof(Response)} response)"))
                {
                    if (isStruct)
                    {
                        writer.Line($"{typeof(Argument)}.{nameof(Argument.AssertNotNull)}(response, nameof(response));");
                    }
                    else
                    {
                        using (writer.Scope($"if (response is null)"))
                        {
                            writer.Line($"return null;");
                        }
                    }
                    writer.Line();

                    if (isXmlWireFormat)
                    {
                        writer.Line($"return {deserializeMethod}({typeof(XElement)}.{nameof(XElement.Load)}(response.{nameof(Response.ContentStream)}), {DefaultWireOptionsString});");
                    }
                    else
                    {
                        writer.Line($"using {typeof(JsonDocument)} doc = {typeof(JsonDocument)}.{nameof(JsonDocument.Parse)}(response.{nameof(Response.ContentStream)});");
                        writer.Line($"return {deserializeMethod}(doc.{nameof(JsonDocument.RootElement)}, {DefaultWireOptionsString});");
                    }
                }
                writer.Line();
            }
        }

        private static void WriteIModelJsonSerializableDeserialize(CodeWriter writer, CSharpType iModelJsonSerializableType, string deserializeMethod, bool writeAsObject)
        {
            var modelType = writeAsObject ? typeof(object) : iModelJsonSerializableType.Arguments[0];
            var interfaceType = writeAsObject ? typeof(IModelJsonSerializable<object>) : iModelJsonSerializableType;

            using (writer.Scope($"{modelType} {interfaceType}.{nameof(IModelJsonSerializable<object>.Deserialize)}(ref {typeof(Utf8JsonReader)} reader, {typeof(ModelSerializerOptions)} options)"))
            {
                WriteValidateFormat(writer, iModelJsonSerializableType.Arguments[0]);
                writer.Line($"using var doc = {typeof(JsonDocument)}.{nameof(JsonDocument.ParseValue)}(ref reader);");
                writer.Line($"return {deserializeMethod}(doc.RootElement, options);");
            }
            writer.Line();
        }

        private static void WriteInternalDeserialize(CodeWriter writer, TypeDeclarationOptions declaration, JsonObjectSerialization serialization, CSharpType iModelSerializableType, bool isUnknownDerivedType, string deserializeMethod)
        {
            FormattableString signatureLine = $"internal static {iModelSerializableType.Arguments[0]} {deserializeMethod}({typeof(JsonElement)} element, {typeof(ModelSerializerOptions)} options = default)";
            if (isUnknownDerivedType)
            {
                writer.Line($"{signatureLine} => Deserialize{serialization.ObjectType!.Inherits!.Name}(element, options);");
            }
            else
            {
                using (writer.Scope(signatureLine))
                {
                    writer.Line($"options ??= {DefaultWireOptionsString};");
                    writer.Line();

                    if (!serialization.Type.IsValueType) // only return null for reference type (e.g. no enum)
                    {
                        using (writer.Scope($"if (element.{nameof(JsonElement.ValueKind)} == {typeof(JsonValueKind)}.Null)"))
                        {
                            writer.Line($"return null;");
                        }
                    }

                    var discriminator = serialization.Discriminator;

                    if (discriminator is not null && discriminator.HasDescendants)
                    {
                        using (writer.Scope($"if (element.TryGetProperty({discriminator.SerializedName:L}, out {typeof(JsonElement)} discriminator))"))
                        {
                            writer.Line($"switch (discriminator.GetString())");
                            using (writer.Scope())
                            {
                                foreach (var implementation in discriminator.Implementations)
                                {
                                    var implementationFormattable = JsonCodeWriterExtensions.GetDeserializeImplementationFormattable(implementation.Type.Implementation, $"element", JsonSerializationOptions.None);
                                    writer.Line($"case {implementation.Key:L}: return {implementationFormattable};");
                                }
                            }
                        }
                        writer.Line();
                        writer.Line($"// Unknown type found so we will deserialize the base properties only");
                    }

                    writer.WriteObjectInitialization(serialization);
                }
            }
            writer.Line();
        }

        private static void WriteIModelSerializableDeserialize(CodeWriter writer, CSharpType iModelSerializableType, bool writeAsObject, bool hasXml, bool hasJson)
        {
            var modelType = writeAsObject ? typeof(object) : iModelSerializableType.Arguments[0];
            var interfaceType = writeAsObject ? typeof(IModelSerializable<object>) : iModelSerializableType;

            string deserializeMethod = $"Deserialize{iModelSerializableType.Arguments[0].Name}";

            using (writer.Scope($"{modelType} {interfaceType}.{nameof(IModelSerializable<object>.Deserialize)}({typeof(BinaryData)} data, {typeof(ModelSerializerOptions)} options)"))
            {
                WriteValidateFormat(writer, iModelSerializableType.Arguments[0]);

                if (hasXml && hasJson)
                {
                    using (writer.Scope($"if (data.ToMemory().Span.StartsWith(\"{{\"u8))"))
                    {
                        WriteJsonInterfaceBody(writer, deserializeMethod);
                    }
                    using (writer.Scope($"else"))
                    {
                        WriteXmlInterfaceBody(writer, deserializeMethod);
                    }
                }
                else if (hasJson)
                {
                    WriteJsonInterfaceBody(writer, deserializeMethod);
                }
                else
                {
                    WriteXmlInterfaceBody(writer, deserializeMethod);
                }
            }
            writer.Line();
        }

        private static void WriteJsonSerialize(CodeWriter writer, JsonObjectSerialization jsonSerialization, bool hasXml, CSharpType iModelSerializableType, CSharpType iModelJsonSerializableType)
        {
            bool isStruct = jsonSerialization.ObjectType is not null && jsonSerialization.ObjectType.IsStruct;

            WriteIUtf8JsonSerializableSerialize(writer, iModelJsonSerializableType);

            WriteIModelJsonSerializableSerialize(writer, jsonSerialization, iModelJsonSerializableType, false);

            if (isStruct)
            {
                WriteIModelJsonSerializableSerialize(writer, jsonSerialization, iModelJsonSerializableType, true);
            }
        }

        private static void WriteImplicitCastToRequestContent(CodeWriter writer, CSharpType modelType, FormattableString modelCast, bool isUnknownDerivedType, bool isStruct)
        {
            if (!isUnknownDerivedType)
            {
                using (writer.Scope($"public static implicit operator {typeof(RequestContent)}({modelType} model)"))
                {
                    if (!isStruct)
                    {
                        using (writer.Scope($"if (model is null)"))
                        {
                            writer.Line($"return null;");
                        }
                        writer.Line();

                    }

                    writer.Line($"return {typeof(RequestContent)}.{nameof(RequestContent.Create)}({modelCast}model, {DefaultWireOptionsString});");
                }
                writer.Line();
            }
        }

        private static void WriteIModelSerializableSerialize(CodeWriter writer, CSharpType iModelSerializableType, bool writeAsObject, bool hasXml, bool hasJson)
        {
            var interfaceType = writeAsObject ? typeof(IModelSerializable<object>) : iModelSerializableType;

            using (writer.Scope($"{typeof(BinaryData)} {interfaceType}.{nameof(IModelSerializable<object>.Serialize)}({typeof(ModelSerializerOptions)} options)"))
            {
                WriteValidateFormat(writer, iModelSerializableType.Arguments[0]);

                if (hasXml && hasJson)
                {
                    using (writer.Scope($"if (options.{nameof(ModelSerializerOptions.Format)} == {typeof(ModelSerializerFormat)}.{nameof(ModelSerializerFormat.Json)})"))
                    {
                        WriteJsonPortionOfIModelSerializableSerialize(writer);
                    }
                    using (writer.Scope($"else"))
                    {
                        WriteXmlPortionOfIModelSerializableSerialize(writer);
                    }

                }
                else if (hasJson)
                {
                    WriteJsonPortionOfIModelSerializableSerialize(writer);
                }
                else
                {
                    WriteXmlPortionOfIModelSerializableSerialize(writer);
                }
            }
            writer.Line();
        }

        private static void WriteXmlPortionOfIModelSerializableSerialize(CodeWriter writer)
        {
            writer.Line($"options ??= {DefaultWireOptionsString};");
            writer.Line($"using {typeof(MemoryStream)} stream = new {typeof(MemoryStream)}();");
            writer.Line($"using {typeof(XmlWriter)} writer = {typeof(XmlWriter)}.{nameof(XmlWriter.Create)}(stream);");
            writer.Line($"Serialize(writer, null, options);");
            writer.Line($"writer.{nameof(XmlWriter.Flush)}();");
            using (writer.Scope($"if (stream.{nameof(MemoryStream.Position)} > {typeof(int)}.{nameof(int.MaxValue)})"))
            {
                writer.Line($"return {typeof(BinaryData)}.{nameof(BinaryData.FromStream)}(stream);");
            }
            using (writer.Scope($"else"))
            {
                writer.Line($"return new {typeof(BinaryData)}(stream.{nameof(MemoryStream.GetBuffer)}().AsMemory(0, ({typeof(int)})stream.{nameof(MemoryStream.Position)}));");
            }
        }

        private static void WriteJsonPortionOfIModelSerializableSerialize(CodeWriter writer)
        {
            writer.Line($"return {typeof(ModelSerializer)}.{nameof(ModelSerializer.SerializeCore)}(this, options);");
        }

        private static void WriteIModelJsonSerializableSerialize(CodeWriter writer, JsonObjectSerialization jsonSerialization, CSharpType iModelJsonSerializableType, bool writeAsObject)
        {
            var interfaceType = writeAsObject ? typeof(IModelJsonSerializable<object>) : iModelJsonSerializableType;

            using (writer.Scope($"void {interfaceType}.{nameof(IModelJsonSerializable<object>.Serialize)}({typeof(Utf8JsonWriter)} writer, {typeof(ModelSerializerOptions)} options)"))
            {
                WriteValidateFormat(writer, iModelJsonSerializableType.Arguments[0]);
                writer.ToSerializeCall(jsonSerialization);
            }
            writer.Line();
        }

        private static void WriteIUtf8JsonSerializableSerialize(CodeWriter writer, CSharpType iModelJsonSerializableType)
        {
            writer.Line($"void {typeof(IUtf8JsonSerializable)}.{nameof(IUtf8JsonSerializable.Write)}({typeof(Utf8JsonWriter)} writer) => (({iModelJsonSerializableType})this).Serialize(writer, {DefaultWireOptionsString});");
            writer.Line();
        }

        public static void WriteEnumSerialization(CodeWriter writer, EnumType enumType)
        {
            using (writer.Namespace(enumType.Declaration.Namespace))
            {
                string declaredTypeName = enumType.Declaration.Name;

                var isString = enumType.ValueType.FrameworkType == typeof(string);

                using (writer.Scope($"internal static partial class {declaredTypeName}Extensions"))
                {
                    if (!enumType.IsIntValueType)
                    {
                        WriteEnumSerializationMethod(writer, enumType, declaredTypeName);
                    }

                    WriteEnumDeserializationMethod(writer, enumType, declaredTypeName, isString);
                }
            }
        }

        private static void WriteEnumSerializationMethod(CodeWriter writer, EnumType enumType, string declaredTypeName)
        {
            using (writer.Scope($"public static {enumType.ValueType} {enumType.SerializationMethodName}(this {declaredTypeName} value) => value switch", end: "};"))
            {
                foreach (EnumTypeValue value in enumType.Values)
                {
                    writer.Line($"{declaredTypeName}.{value.Declaration.Name} => {value.Value.Value:L},");
                }

                writer.Line($"_ => throw new {typeof(ArgumentOutOfRangeException)}(nameof(value), value, \"Unknown {declaredTypeName} value.\")");
            }
            writer.Line();
        }

        private static void WriteEnumDeserializationMethod(CodeWriter writer, EnumType schema, string declaredTypeName, bool isString)
        {
            using (writer.Scope($"public static {declaredTypeName} To{declaredTypeName}(this {schema.ValueType} value)"))
            {
                if (isString)
                {
                    foreach (EnumTypeValue value in schema.Values)
                    {
                        if (value.Value.Value is string strValue && strValue.All(char.IsAscii))
                        {
                            writer.Append($"if ({typeof(StringComparer)}.{nameof(StringComparer.OrdinalIgnoreCase)}.{nameof(StringComparer.Equals)}(value, {strValue:L}))");
                        }
                        else
                        {
                            writer.Append($"if ({schema.ValueType}.Equals(value, {value.Value.Value:L}");
                            writer.Append($", {typeof(StringComparison)}.InvariantCultureIgnoreCase))");
                        }
                        writer.Line($" return {declaredTypeName}.{value.Declaration.Name};");
                    }
                }
                else// int, and float
                {
                    foreach (EnumTypeValue value in schema.Values)
                    {
                        writer.Line($"if (value == {value.Value.Value:L}) return {declaredTypeName}.{value.Declaration.Name};");
                    }
                }

                writer.Line($"throw new {typeof(ArgumentOutOfRangeException)}(nameof(value), value, \"Unknown {declaredTypeName} value.\");");
            }
            writer.Line();
        }
    }
}
