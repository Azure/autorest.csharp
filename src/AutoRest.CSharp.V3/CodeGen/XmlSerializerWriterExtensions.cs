// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.V3.ClientModels;
using AutoRest.CSharp.V3.ClientModels.Serialization;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal static class XmlSerializerWriterExtensions
    {
        public static void ToSerializeCall(this CodeWriter writer, XmlElementSerialization serialization, TypeFactory typeFactory, CodeWriterDelegate name, CodeWriterDelegate? writerName = null, CodeWriterDelegate? nameHint = null)
        {
            writerName ??= w => w.AppendRaw("writer");

            switch (serialization)
            {
                case XmlArraySerialization array:

                    if (array.Wrapped)
                    {
                        writer.Line($"{writerName}.WriteStartElement({array.Name:L});");
                    }

                    var itemVariable = writer.GetTemporaryVariable("item");

                    using (writer.Scope($"foreach (var {itemVariable:D} in {name})"))
                    {
                        writer.ToSerializeCall(
                            array.ValueSerialization,
                            typeFactory,
                            w => w.Append($"{itemVariable}"),
                            writerName);
                    }

                    if (array.Wrapped)
                    {
                        writer.Line($"{writerName}.WriteEndElement();");
                    }

                    break;
                case XmlDictionarySerialization dictionarySerialization:
                    var pairVariable = writer.GetTemporaryVariable("pair");
                    using (writer.Scope($"foreach (var {pairVariable:D} in {name})"))
                    {
                        writer.ToSerializeCall(
                            dictionarySerialization.ValueSerialization,
                            typeFactory,
                            w => w.Append($"{pairVariable}.Value"),
                            writerName);
                    }

                    break;

                case XmlObjectSerialization objectSerialization:
                    if (nameHint != null)
                    {
                        writer.Line($"{writerName}.WriteStartElement({nameHint} ?? {objectSerialization.Name:L});");
                    }
                    else
                    {
                        writer.Line($"{writerName}.WriteStartElement({objectSerialization.Name:L});");
                    }

                    foreach (XmlObjectAttributeSerialization property in objectSerialization.Attributes)
                    {
                        using (property.Type.IsNullable ? writer.If($"{property.MemberName} != null") : default)
                        {
                            writer.Line($"{writerName}.WriteStartAttribute({property.Name:L});");
                            writer.ToSerializeValueCall(
                                typeFactory,
                                w => w.Append($"{property.MemberName}"),
                                writerName,
                                property.ValueSerialization);
                            writer.Line($"{writerName}.WriteEndAttribute();");
                        }
                    }

                    foreach (XmlObjectElementSerialization property in objectSerialization.Elements)
                    {
                        using (property.Type.IsNullable ? writer.If($"{property.MemberName} != null") : default)
                        {
                            writer.ToSerializeCall(
                                property.ValueSerialization,
                                typeFactory,
                                w => w.Append($"{property.MemberName}"));
                        }
                    }

                    foreach (XmlObjectArraySerialization property in objectSerialization.EmbeddedArrays)
                    {
                        using (property.ArraySerialization.Type.IsNullable ? writer.If($"{property.MemberName} != null") : default)
                        {
                            writer.ToSerializeCall(
                                property.ArraySerialization,
                                typeFactory,
                                w => w.Append($"{property.MemberName}"));
                        }
                    }

                    writer.Line($"{writerName}.WriteEndElement();");
                    return;

                case XmlElementValueSerialization elementValueSerialization:

                    var type = elementValueSerialization.Value.Type;

                    string elementName = elementValueSerialization.Name;

                    if ((type is SchemaTypeReference schemaReference && typeFactory.ResolveReference(schemaReference) is ClientObject) ||
                        (type is FrameworkTypeReference frameworkReference && frameworkReference.Type == typeof(object)))
                    {
                        writer.Line($"{writerName}.WriteObjectValue({name}, {elementName:L});");
                        return;
                    }

                    writer.Line($"{writerName}.WriteStartElement({elementName:L});");

                    writer.ToSerializeValueCall(typeFactory, name, writerName, elementValueSerialization.Value);

                    writer.Line($"{writerName}.WriteEndElement();");

                    return;
                default:
                    throw new NotSupportedException();
            }
        }

        private static void ToSerializeValueCall(this CodeWriter writer, TypeFactory typeFactory, CodeWriterDelegate name, CodeWriterDelegate writerName, XmlValueSerialization valueSerialization)
        {
            CSharpType implementationType = typeFactory.CreateType(valueSerialization.Type);
            switch (valueSerialization.Type)
            {
                case SchemaTypeReference schemaTypeReference:
                    switch (typeFactory.ResolveReference(schemaTypeReference))
                    {
                        case ClientObject _:
                            throw new NotSupportedException("Object type references are only supported as elements");

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
                    if (frameworkType == typeof(object))
                    {
                        throw new NotSupportedException("Object references are only supported as elements");
                    }

                    bool writeFormat = frameworkType == typeof(byte[]) ||
                                       frameworkType == typeof(DateTimeOffset) ||
                                       frameworkType == typeof(DateTime) ||
                                       frameworkType == typeof(TimeSpan);

                    writer.Append($"{writerName}.WriteValue({name}")
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
        }

        public static void ToDeserializeCall(this CodeWriter writer, XmlElementSerialization serialization, TypeFactory typeFactory, CodeWriterDelegate element, ref string destination)
        {
            var type = serialization.Type;

            // if (serialization is XmlElementValueSerialization valueSerialization)
            // {
            //     writer.Append($"var {destination:D} =")
            //         .ToDeserializeCall(valueSerialization, typeFactory, element);
            //     writer.LineRaw(";");
            // }
            // else
            {
                destination = writer.GetTemporaryVariable(destination);

                string s = destination;

                writer
                    .Line($"{typeFactory.CreateType(type)} {destination:D} = default;")
                    .ToDeserializeCall(serialization, typeFactory, w => w.AppendRaw(s), element);
            }
        }

        public static void ToDeserializeCall(this CodeWriter writer, XmlElementSerialization serialization, TypeFactory typeFactory, CodeWriterDelegate destination, CodeWriterDelegate element)
        {
            switch (serialization)
            {
                case XmlArraySerialization arraySerialization:
                {
                    string childElementVariable = writer.GetTemporaryVariable("e");

                    if (arraySerialization.Wrapped)
                    {
                        string elementVariable = writer.GetTemporaryVariable(arraySerialization.Name.ToVariableName());

                        writer.Line($"var {elementVariable:D} = {element}.Element({arraySerialization.Name:L});");

                        element = w => w.AppendRaw(elementVariable);
                    }

                    writer.Line($"{destination} = new {typeFactory.CreateConcreteType(serialization.Type)}();");

                    using (writer.Scope($"foreach (var {childElementVariable:D} in {element}.Elements({arraySerialization.ValueSerialization.Name:L}))"))
                    {
                        var itemVariableName = "value";
                        writer.ToDeserializeCall(
                            arraySerialization.ValueSerialization,
                            typeFactory,
                            w => w.AppendRaw(childElementVariable),
                            ref itemVariableName);

                        writer.Line($"{destination}.Add({itemVariableName});");
                    }

                    break;
                }
                case XmlDictionarySerialization dictionarySerialization:
                {
                    string elementsVariable = writer.GetTemporaryVariable("elements");
                    string elementVariable = writer.GetTemporaryVariable("e");

                    writer.Line($"var {elementsVariable:D} = {element}.Elements();");
                    using (writer.Scope($"foreach (var {elementVariable:D} in {elementsVariable})"))
                    {
                        var itemVariableName = "value";
                        writer.ToDeserializeCall(
                            dictionarySerialization.ValueSerialization,
                            typeFactory,
                            w => w.AppendRaw(elementVariable),
                            ref itemVariableName);

                        writer.Line($"{destination}.Add({elementVariable}.Name.LocalName, {itemVariableName});");
                    }

                    break;
                }
                case XmlObjectSerialization elementSerialization:
                    foreach (XmlObjectAttributeSerialization attribute in elementSerialization.Attributes)
                    {
                        string elementVariable = writer.GetTemporaryVariable(attribute.MemberName.ToVariableName());

                        writer.Line($"var {elementVariable:D} = {element}.Attribute({attribute.Name:L});");
                        using (writer.Scope($"if ({elementVariable} != null)"))
                        {
                            writer.Append($"{destination}.{attribute.MemberName} = ");
                            writer.ToDeserializeValueCall(attribute.ValueSerialization, typeFactory, w => w.AppendRaw(elementVariable));
                            writer.Line($";");
                        }
                    }

                    foreach (XmlObjectElementSerialization elem in elementSerialization.Elements)
                    {
                        var itemVariableName = "value";
                        writer.ToDeserializeCall(
                            elem.ValueSerialization,
                            typeFactory,
                            element,
                            ref itemVariableName);

                        writer.Line($"{destination}.{elem.MemberName} = {itemVariableName};");
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
                case XmlElementValueSerialization valueSerialization:
                {
                    string elementVariable = writer.GetTemporaryVariable(valueSerialization.Name.ToVariableName());
                    writer.Line($"var {elementVariable:D} = {element}.Element({valueSerialization.Name:L});");

                    using (writer.Scope($"if ({elementVariable} != null)"))
                    {
                        writer.Append($"{destination} = ");
                        writer.ToDeserializeValueCall(valueSerialization.Value, typeFactory, w => w.Append($"{elementVariable}"));
                        writer.Line($";");
                    }

                    break;
                }
            }
        }

        public static void ToDeserializeValueCall(this CodeWriter writer, XmlValueSerialization serialization, TypeFactory typeFactory, CodeWriterDelegate element)
        {
            switch (serialization.Type)
            {
                case SchemaTypeReference schemaTypeReference:
                    CSharpType cSharpType = typeFactory.CreateType(schemaTypeReference).WithNullable(false);

                    switch (typeFactory.ResolveReference(schemaTypeReference))
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

                    break;
                case FrameworkTypeReference frameworkTypeReference:

                    var frameworkType = frameworkTypeReference.Type;

                    if (frameworkType == typeof(bool) ||
                        frameworkType == typeof(char) ||
                        frameworkType == typeof(short) ||
                        frameworkType == typeof(int) ||
                        frameworkType == typeof(long) ||
                        frameworkType == typeof(float) ||
                        frameworkType == typeof(double) ||
                        frameworkType == typeof(decimal) ||
                        frameworkType == typeof(string)
                    )
                    {
                        var type = typeFactory.CreateType(frameworkTypeReference);
                        writer.Append($"({type}){element}");
                        return;
                    }

                    writer.Append($"{element}.");

                    if (frameworkType == typeof(byte[]))
                    {
                        writer.AppendRaw("GetBytesFromBase64");
                    }

                    if (frameworkType == typeof(DateTimeOffset))
                    {
                        writer.AppendRaw("GetDateTimeOffsetValue");
                    }

                    if (frameworkType == typeof(TimeSpan))
                    {
                        writer.AppendRaw("GetTimeSpanValue");
                    }

                    writer.Append($"({serialization.Format.ToFormatSpecifier():L})");

                    break;
                default:
                    throw new NotImplementedException(serialization.Type.ToString());
            }
        }
    }
}
