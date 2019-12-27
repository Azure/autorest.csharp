// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal static class XmlSerializerExtensions
    {
        public static void ToSerializeCall(this CodeWriter writer, XmlSerialization serialization, TypeFactory typeFactory, CodeWriterDelegate name, CodeWriterDelegate? writerName = null, CodeWriterDelegate? nameHint = null)
        {
            writerName ??= w => w.AppendRaw("writer");

            var type = serialization.Type;
            CSharpType implementationType = typeFactory.CreateType(type);

            switch (serialization)
            {
                case XmlArraySerialization array:
                case XmlDictionarySerialization dictionarySerialization:
                    break;

                case XmlObjectSerialization dictionary:
                    if (nameHint != null)
                    {
                        writer.Line($"{writerName}.WriteStartElement({nameHint} ?? {dictionary.ElementName:L});");
                    }
                    else
                    {
                        writer.Line($"{writerName}.WriteStartElement({dictionary.ElementName:L});");
                    }

                    foreach (XmlObjectElementSerialization property in dictionary.Elements)
                    {
                        using (property.ValueSerialization.Type.IsNullable ? writer.If($"{property.MemberName} != null") : default)
                        {
                            writer.Line($"{writerName}.WriteStartElement({property.Name:L});");
                            writer.ToSerializeCall(
                                property.ValueSerialization,
                                typeFactory,
                                w => w.Append($"{property.MemberName}"));
                            writer.Line($"{writerName}.WriteEndElement();");
                        }
                    }
                    return;

                case XmlValueSerialization valueSerialization:
                    switch (valueSerialization.Type)
                    {
                        case SchemaTypeReference schemaTypeReference:
                            switch (typeFactory.ResolveReference(schemaTypeReference))
                            {
                                case ClientObject _:
                                    writer.Line($"{writerName}.WriteObjectValue({name}, null);");
                                    return;

                                case ClientEnum clientEnum:
                                    writer.Append($"{writerName}.WriteValue({name}")
                                        .AppendNullableValue(implementationType)
                                        .AppendRaw(clientEnum.IsStringBased ? ".ToString()" : ".ToSerialString()")
                                        .Line($");");
                                    return;
                            }
                            return;

                        case FrameworkTypeReference frameworkTypeReference:
                            var frameworkType = frameworkTypeReference.Type;
                            bool writeFormat = false;

                            writer.Append($"{writerName}.");
                            if (frameworkType == typeof(decimal) ||
                                frameworkType == typeof(double) ||
                                frameworkType == typeof(float) ||
                                frameworkType == typeof(long) ||
                                frameworkType == typeof(int) ||
                                frameworkType == typeof(short))
                            {
                                writer.AppendRaw("WriteValue");
                            }
                            else if (frameworkType == typeof(object))
                            {
                                writer.AppendRaw("WriteObjectValue");
                            }
                            else if (frameworkType == typeof(string) ||
                                     frameworkType == typeof(char))
                            {
                                writer.AppendRaw("WriteValue");
                            }
                            else if (frameworkType == typeof(bool))
                            {
                                writer.AppendRaw("WriteValue");
                            }
                            else if (frameworkType == typeof(byte[]))
                            {
                                writer.AppendRaw("WriteValue");
                                writeFormat = true;
                            }
                            else if (frameworkType == typeof(DateTimeOffset) ||
                                     frameworkType == typeof(DateTime) ||
                                     frameworkType == typeof(TimeSpan))
                            {
                                writer.AppendRaw("WriteValue");
                                writeFormat = true;
                            }

                            writer.Append($"({name}")
                                .AppendNullableValue(implementationType);

                            if (writeFormat && valueSerialization.Format.ToFormatSpecifier() is string formatString)
                            {
                                writer.Append($", {formatString:L}");
                            }

                            writer.LineRaw(");");
                            return;
                        default:
                            throw new NotSupportedException();
                    }
                default:
                    throw new NotSupportedException();
            }
        }

        public static void ToDeserializeCall(this CodeWriter writer, XmlSerialization serialization, TypeFactory typeFactory, CodeWriterDelegate element, ref string destination)
        {
            var type = serialization.Type;

            destination = writer.GetTemporaryVariable(destination);

            if (serialization is XmlValueSerialization valueSerialization)
            {
                writer
                    .Append($"{typeFactory.CreateType(type)} {destination:D} = ")
                    .ToDeserializeCall(valueSerialization, typeFactory, element);
                writer.Line($";");
            }
            else
            {
                string s = destination;

                writer
                    .Line($"{typeFactory.CreateType(type)} {destination:D} = new {typeFactory.CreateConcreteType(type)}();")
                    .ToDeserializeCall(serialization, typeFactory, w => w.AppendRaw(s), element);
            }
        }

        public static void ToDeserializeCall(this CodeWriter writer, XmlSerialization serialization, TypeFactory typeFactory, CodeWriterDelegate destination, CodeWriterDelegate element)
        {
            switch (serialization)
            {
                case XmlArraySerialization arraySerialization:
                {
                    string elementsVariable = writer.GetTemporaryVariable("elements");
                    string elementVariable = writer.GetTemporaryVariable("e");

                    writer.Line($"var {elementsVariable:D} = {element}.Elements({arraySerialization.Name:L});");
                    using (writer.Scope($"foreach (var {elementVariable:D} in {elementsVariable})"))
                    {
                        if (arraySerialization.ValueSerialization is XmlValueSerialization valueSerialization)
                        {
                            writer.Append($"{destination}.Add(");
                            writer.ToDeserializeCall(valueSerialization, typeFactory, w=> w.AppendRaw(elementVariable));
                            writer.Line($");");
                        }
                        else
                        {
                            var itemVariableName = "value";
                            writer.ToDeserializeCall(
                                arraySerialization.ValueSerialization,
                                typeFactory,
                                w => w.AppendRaw(elementVariable),
                                ref itemVariableName);

                            writer.Append($"{destination}.Add({itemVariableName});");
                        }
                    }

                    break;
                }
                case XmlDictionarySerialization dictionarySerialization:
                    break;
                case XmlObjectSerialization elementSerialization:
                    foreach (XmlObjectAttributeSerialization attribute in elementSerialization.Attributes)
                    {
                        string elementVariable = writer.GetTemporaryVariable(attribute.MemberName.ToVariableName());

                        writer.Line($"var {elementVariable:D} = {element}.Attribute({attribute.Name:L});");
                        using (writer.Scope($"if ({elementVariable} != null)"))
                        {
                            writer.Append($"{destination}.{attribute.MemberName} = ");
                            writer.ToDeserializeCall(attribute.ValueSerialization, typeFactory, w=> w.AppendRaw(elementVariable));
                            writer.Line($";");
                        }
                    }
                    foreach (XmlObjectElementSerialization elem in elementSerialization.Elements)
                    {
                        string elementVariable = writer.GetTemporaryVariable(elem.MemberName.ToVariableName());

                        writer.Line($"var {elementVariable:D} = {element}.Element({elem.Name:L});");
                        using (writer.Scope($"if ({elementVariable} != null)"))
                        {
                            if (elem.ValueSerialization is XmlValueSerialization valueSerialization)
                            {
                                writer.Append($"{destination}.{elem.MemberName} = ");
                                writer.ToDeserializeCall(valueSerialization, typeFactory, w=> w.AppendRaw(elementVariable));
                                writer.Line($";");
                            }
                            else
                            {
                                var itemVariableName = "value";
                                writer.ToDeserializeCall(
                                    elem.ValueSerialization,
                                    typeFactory,
                                    w => w.AppendRaw(elementVariable),
                                    ref itemVariableName);

                                writer.Append($"{destination}.{elem.MemberName} = {itemVariableName};");
                            }
                        }
                    }

                    foreach (var embeddedArray in elementSerialization.EmbeddedArrays)
                    {
                        CodeWriterDelegate arrayDestination = w => w.Append($"{destination}.{embeddedArray.MemberName}");

                        ClientTypeReference type = embeddedArray.ArraySerialization.Type;
                        writer.Line($"{arrayDestination:D} = new {typeFactory.CreateConcreteType(type)}();");
                        writer.ToDeserializeCall(
                            embeddedArray.ArraySerialization,
                            typeFactory,
                            arrayDestination,
                            element);
                    }

                    break;
                case XmlValueSerialization valueSerialization:
                    writer.Append($"{destination} = ");
                    writer.ToDeserializeCall(valueSerialization, typeFactory, element);
                    writer.Line($";");
                    break;
            }
        }

        public static void ToDeserializeCall(this CodeWriter writer, XmlValueSerialization valueSerialization, TypeFactory typeFactory, CodeWriterDelegate element)
        {
            switch (valueSerialization.Type)
            {
                case SchemaTypeReference schemaTypeReference:
                    writer.ToXmlDeserializeCall(schemaTypeReference, typeFactory, element);
                    break;
                case FrameworkTypeReference frameworkTypeReference:
                    var type = typeFactory.CreateType(frameworkTypeReference);
                    writer.Append($"({type}){element}");
                    break;
                default:
                    throw new NotImplementedException(valueSerialization.Type.ToString());
            }
        }

        public static void ToXmlDeserializeCall(this CodeWriter writer, SchemaTypeReference type, TypeFactory typeFactory, CodeWriterDelegate element)
        {
            CSharpType cSharpType = typeFactory.CreateType(type).WithNullable(false);

            switch (typeFactory.ResolveReference(type))
            {
                case ClientObject _:
                    writer.Append($"{cSharpType}.Deserialize{cSharpType.Name}({element})");
                    break;

                case ClientEnum clientEnum when clientEnum.IsStringBased:
                    writer.Append($"new {cSharpType}({element}.Value)");
                    break;

                case ClientEnum clientEnum when !clientEnum.IsStringBased:
                    writer.Append($"{element}.Value.To{cSharpType.Name}()");
                    break;
            }
        }

    }
}
