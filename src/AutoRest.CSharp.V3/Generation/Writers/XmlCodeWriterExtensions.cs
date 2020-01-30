// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using AutoRest.CSharp.V3.Output.Models.Serialization.Xml;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal static class XmlCodeWriterExtensions
    {
        public static void ToSerializeCall(this CodeWriter writer, XmlElementSerialization serialization, CodeWriterDelegate name, CodeWriterDelegate? writerName = null, CodeWriterDelegate? nameHint = null)
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
                                w => w.Append($"{property.MemberName}"));
                        }
                    }

                    foreach (XmlObjectArraySerialization property in objectSerialization.EmbeddedArrays)
                    {
                        using (property.ArraySerialization.Type.IsNullable ? writer.If($"{property.MemberName} != null") : default)
                        {
                            writer.ToSerializeCall(
                                property.ArraySerialization,
                                w => w.Append($"{property.MemberName}"));
                        }
                    }

                    writer.Line($"{writerName}.WriteEndElement();");
                    return;

                case XmlElementValueSerialization elementValueSerialization:

                    var type = elementValueSerialization.Value.Type;

                    string elementName = elementValueSerialization.Name;

                    if ((!type.IsFrameworkType && type.Implementation is ObjectType) ||
                        (type.IsFrameworkType && type.FrameworkType == typeof(object)))
                    {
                        writer.Line($"{writerName}.WriteObjectValue({name}, {elementName:L});");
                        return;
                    }

                    writer.Line($"{writerName}.WriteStartElement({elementName:L});");

                    writer.ToSerializeValueCall(name, writerName, elementValueSerialization.Value);

                    writer.Line($"{writerName}.WriteEndElement();");

                    return;
                default:
                    throw new NotSupportedException();
            }
        }

        private static void ToSerializeValueCall(this CodeWriter writer, CodeWriterDelegate name, CodeWriterDelegate writerName, XmlValueSerialization valueSerialization)
        {
            CSharpType implementationType = valueSerialization.Type;

            if (!implementationType.IsFrameworkType)
            {
                switch (implementationType.Implementation)
                {
                    case ObjectType _:
                        throw new NotSupportedException("Object type references are only supported as elements");

                    case EnumType clientEnum:
                        writer.Append($"{writerName}.WriteValue({name}")
                            .AppendNullableValue(implementationType)
                            .AppendRaw(clientEnum.IsStringBased ? ".ToString()" : ".ToSerialString()")
                            .Line($");");
                        return;
                }
            }

            var frameworkType = implementationType.FrameworkType;

            if (frameworkType == null)
            {
                throw new NotSupportedException();
            }

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
        }

        public static void ToDeserializeCall(this CodeWriter writer, XmlElementSerialization serialization, CodeWriterDelegate element, ref string destination, bool isElement = false)
        {
            var type = serialization.Type;

            destination = writer.GetTemporaryVariable(destination);

            string s = destination;

            writer
                .Line($"{type} {destination:D} = default;");

            if (isElement)
            {
                writer.ToDeserializeElementCall(serialization, w=> w.AppendRaw(s), element);
            }
            else
            {
                writer.ToDeserializeCall(serialization, w => w.AppendRaw(s), element);
            }
        }

        private static void ToDeserializeCall(this CodeWriter writer, XmlElementSerialization serialization, CodeWriterDelegate destination, CodeWriterDelegate element)
        {
            if (serialization is XmlArraySerialization arraySerialization && !arraySerialization.Wrapped)
            {
                writer.ToDeserializeElementCall(serialization, destination, element);
                return;
            }

            string elementVariable = writer.GetTemporaryVariable(serialization.Name.ToVariableName());

            writer.Line($"var {elementVariable:D} = {element}.Element({serialization.Name:L});");

            element = w => w.AppendRaw(elementVariable);

            using (writer.Scope($"if ({elementVariable} != null)"))
            {
                writer.ToDeserializeElementCall(serialization, destination, element);
            }
        }

        private static void ToDeserializeElementCall(this CodeWriter writer, XmlElementSerialization serialization, CodeWriterDelegate destination, CodeWriterDelegate element, bool isElement = false)
        {
            switch (serialization)
            {
                case XmlArraySerialization arraySerialization:
                {
                    string childElementVariable = writer.GetTemporaryVariable("e");

                    writer.Line($"{destination} = new {serialization.Type}();");

                    using (writer.Scope($"foreach (var {childElementVariable:D} in {element}.Elements({arraySerialization.ValueSerialization.Name:L}))"))
                    {
                        var itemVariableName = writer.GetTemporaryVariable("value");
                        writer.ToDeserializeCall(
                            arraySerialization.ValueSerialization,
                            w => w.AppendRaw(childElementVariable),
                            ref itemVariableName,
                            true);

                        writer.Line($"{destination}.Add({itemVariableName});");
                    }

                    break;
                }
                case XmlDictionarySerialization dictionarySerialization:
                {
                    writer.Append($"{destination} = new {dictionarySerialization.Type}();");

                    string elementsVariable = writer.GetTemporaryVariable("elements");
                    string elementVariable = writer.GetTemporaryVariable("e");

                    writer.Line($"var {elementsVariable:D} = {element}.Elements();");
                    using (writer.Scope($"foreach (var {elementVariable:D} in {elementsVariable})"))
                    {
                        var itemVariableName = "value";
                        writer.ToDeserializeCall(
                            dictionarySerialization.ValueSerialization,
                            w => w.AppendRaw(elementVariable),
                            ref itemVariableName,
                            true);

                        writer.Line($"{destination}.Add({elementVariable}.Name.LocalName, {itemVariableName});");
                    }

                    break;
                }
                case XmlObjectSerialization elementSerialization:
                    writer.Append($"{destination} = new {elementSerialization.Type}();");

                    foreach (XmlObjectAttributeSerialization attribute in elementSerialization.Attributes)
                    {
                        string elementVariable = writer.GetTemporaryVariable(attribute.MemberName.ToVariableName());

                        writer.Line($"var {elementVariable:D} = {element}.Attribute({attribute.Name:L});");
                        using (writer.Scope($"if ({elementVariable} != null)"))
                        {
                            writer.Append($"{destination}.{attribute.MemberName} = ");
                            writer.ToDeserializeValueCall(attribute.ValueSerialization, w => w.AppendRaw(elementVariable));
                            writer.Line($";");
                        }
                    }

                    foreach (XmlObjectElementSerialization elem in elementSerialization.Elements)
                    {
                        var itemVariableName = "value";
                        writer.ToDeserializeCall(
                            elem.ValueSerialization,
                            element,
                            ref itemVariableName);

                        writer.Line($"{destination}.{elem.MemberName} = {itemVariableName};");
                    }

                    foreach (var embeddedArray in elementSerialization.EmbeddedArrays)
                    {
                        CodeWriterDelegate arrayDestination = w => w.Append($"{destination}.{embeddedArray.MemberName}");

                        writer.ToDeserializeCall(
                            embeddedArray.ArraySerialization,
                            arrayDestination,
                            element);
                    }

                    break;
                case XmlElementValueSerialization valueSerialization:
                {
                    writer.Append($"{destination} = ");
                    writer.ToDeserializeValueCall(valueSerialization.Value, w => w.Append(element));
                    writer.Line($";");

                    break;
                }
            }
        }

        private static void ToDeserializeValueCall(this CodeWriter writer, XmlValueSerialization serialization, CodeWriterDelegate element)
        {
            var type = serialization.Type;

            if (type.IsFrameworkType)
            {
                var frameworkType = type.FrameworkType;
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
                return;
            }

            CSharpType nonNullable = type.WithNullable(false);

            switch (type.Implementation)
            {
                case ObjectType _:
                    writer.Append($"{nonNullable}.Deserialize{nonNullable.Name}({element})");
                    break;

                case EnumType clientEnum when clientEnum.IsStringBased:
                    writer.Append($"new {nonNullable}({element}.Value)");
                    break;

                case EnumType clientEnum when !clientEnum.IsStringBased:
                    writer.Append($"{element}.Value.To{nonNullable.Name}()");
                    break;

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
