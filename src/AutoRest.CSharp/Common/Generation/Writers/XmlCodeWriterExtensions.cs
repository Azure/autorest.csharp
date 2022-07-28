// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class XmlCodeWriterExtensions
    {
        public static void ToSerializeCall(this CodeWriter writer, XmlElementSerialization serialization, FormattableString name, FormattableString? writerName = null, string? nameHint = null)
        {
            writerName ??= $"writer";

            switch (serialization)
            {
                case XmlArraySerialization array:

                    if (array.Wrapped)
                    {
                        writer.Line($"{writerName}.WriteStartElement({array.Name:L});");
                    }

                    var itemVariable = new CodeWriterDeclaration("item");

                    using (writer.Scope($"foreach (var {itemVariable:D} in {name})"))
                    {
                        writer.ToSerializeCall(array.ValueSerialization, $"{itemVariable}", writerName);
                    }

                    if (array.Wrapped)
                    {
                        writer.Line($"{writerName}.WriteEndElement();");
                    }

                    break;
                case XmlDictionarySerialization dictionarySerialization:
                    var pairVariable = new CodeWriterDeclaration("pair");
                    using (writer.Scope($"foreach (var {pairVariable:D} in {name})"))
                    {
                        writer.ToSerializeCall(dictionarySerialization.ValueSerialization, $"{pairVariable}.Value", writerName);
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
                        using (writer.WriteDefinedCheck(property.Property))
                        using (writer.WritePropertyNullCheckIf(property.Property))
                        {
                            writer.Line($"{writerName}.WriteStartAttribute({property.Name:L});");
                            writer.ToSerializeValueCall(
                                $"{property.Property.Declaration.Name}",
                                writerName,
                                property.ValueSerialization);
                            writer.Line($"{writerName}.WriteEndAttribute();");
                        }
                    }

                    foreach (XmlObjectElementSerialization property in objectSerialization.Elements)
                    {
                        using (writer.WriteDefinedCheck(property.Property))
                        using (writer.WritePropertyNullCheckIf(property.Property))
                        {
                            writer.ToSerializeCall(property.ValueSerialization, $"{property.Property.Declaration.Name}");
                        }
                    }

                    foreach (XmlObjectArraySerialization property in objectSerialization.EmbeddedArrays)
                    {
                        using (writer.WriteDefinedCheck(property.Property))
                        using (writer.WritePropertyNullCheckIf(property.Property))
                        {
                            writer.ToSerializeCall(property.ArraySerialization, $"{property.Property.Declaration.Name}");
                        }
                    }

                    if (objectSerialization.ContentSerialization is XmlObjectContentSerialization contentSerialization)
                    {
                        writer.ToSerializeValueCall(
                            $"{contentSerialization.Property.Declaration.Name}",
                            writerName,
                            contentSerialization.ValueSerialization);
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

        private static void ToSerializeValueCall(this CodeWriter writer, FormattableString name, FormattableString writerName, XmlValueSerialization valueSerialization)
        {
            writer.UseNamespace(typeof(XmlWriterExtensions).Namespace!);
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
                            .AppendEnumToString(clientEnum)
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

        public static void ToDeserializeCall(this CodeWriter writer, XmlElementSerialization serialization, FormattableString element, Action<FormattableString> valueCallback, bool isElement = false)
        {
            if (isElement)
            {
                writer.ToDeserializeElementCall(serialization, valueCallback, element);
            }
            else
            {
                writer.ToDeserializeCall(serialization, valueCallback, element);
            }
        }

        private static void ToDeserializeCall(this CodeWriter writer, XmlElementSerialization serialization, Action<FormattableString> valueCallback, FormattableString element)
        {
            if (serialization is XmlArraySerialization arraySerialization && !arraySerialization.Wrapped)
            {
                writer.ToDeserializeElementCall(serialization, valueCallback, element);
                return;
            }

            var elementVariable = new CodeWriterDeclaration(serialization.Name.ToVariableName() + "Element");
            writer.Line($"if ({element}.Element({serialization.Name:L}) is {typeof(XElement)} {elementVariable:D})");
            using (writer.Scope())
            {
                writer.ToDeserializeElementCall(serialization, valueCallback, $"{elementVariable}");
            }
        }

        private static void ToDeserializeElementCall(this CodeWriter writer, XmlElementSerialization serialization, Action<FormattableString> valueCallback, FormattableString element)
        {
            switch (serialization)
            {
                case XmlArraySerialization arraySerialization:
                {
                    var arrayVariable = new CodeWriterDeclaration("array");
                    var childElementVariable = new CodeWriterDeclaration("e");

                    writer.Line($"var {arrayVariable:D} = new {arraySerialization.Type}();");

                    using (writer.Scope($"foreach (var {childElementVariable:D} in {element}.Elements({arraySerialization.ValueSerialization.Name:L}))"))
                    {
                        writer.ToDeserializeCall(arraySerialization.ValueSerialization, $"{childElementVariable}", v => writer.Line($"{arrayVariable}.Add({v});"), true);
                    }

                    valueCallback($"{arrayVariable:I}");
                    return;
                }
                case XmlDictionarySerialization dictionarySerialization:
                {
                    var dictionaryVariable = new CodeWriterDeclaration("dictionary");
                    writer.Line($"var {dictionaryVariable:D} = new {dictionarySerialization.Type}();");

                    var elementVariable = new CodeWriterDeclaration("e");

                    using (writer.Scope($"foreach (var {elementVariable:D} in {element}.Elements())"))
                    {
                        writer.ToDeserializeCall(dictionarySerialization.ValueSerialization, $"{elementVariable}", v => writer.Line($"{dictionaryVariable}.Add({elementVariable}.Name.LocalName, {v});"), true);
                    }

                    valueCallback($"{dictionaryVariable}");
                    return;
                }
                case XmlObjectSerialization elementSerialization:

                    var propertyVariables = new Dictionary<ObjectTypeProperty, CodeWriterDeclaration>();

                    CollectProperties(propertyVariables, elementSerialization);

                    foreach (var variable in propertyVariables)
                    {
                        var objectTypeProperty = variable.Key;
                        writer.Line($"{objectTypeProperty.Declaration.Type} {variable.Value:D} = default;");
                    }


                    foreach (XmlObjectAttributeSerialization attribute in elementSerialization.Attributes)
                    {
                        var attributeVariable = new CodeWriterDeclaration(attribute.Property.Declaration.Name.ToVariableName() + "Attribute");
                        using (writer.Scope($"if ({element}.Attribute({attribute.Name:L}) is {typeof(XAttribute)} {attributeVariable:D})"))
                        {
                            writer.Append($"{propertyVariables[attribute.Property]} = ");
                            writer.Append(GetDeserializeValueCallFormattable(attribute.ValueSerialization, $"{attributeVariable}"));
                            writer.Line($";");
                        }
                    }

                    foreach (XmlObjectElementSerialization elem in elementSerialization.Elements)
                    {
                        writer.ToDeserializeCall(elem.ValueSerialization, element, v => writer.Line($"{propertyVariables[elem.Property]} = {v};"));
                    }

                    foreach (var embeddedArray in elementSerialization.EmbeddedArrays)
                    {
                        writer.ToDeserializeCall(embeddedArray.ArraySerialization, v => writer.Line($"{propertyVariables[embeddedArray.Property]} = {v};"), element);
                    }

                    if (elementSerialization.ContentSerialization is { } contentSerialization)
                    {
                        writer.Append($"{propertyVariables[contentSerialization.Property]} = ");
                        writer.Append(GetDeserializeValueCallFormattable(contentSerialization.ValueSerialization, $"{element}.Value"));
                        writer.Line($";");
                    }

                    var initializers = new List<PropertyInitializer>();
                    foreach (var variable in propertyVariables)
                    {
                        var property = variable.Key;
                        initializers.Add(new PropertyInitializer(property, $"{variable.Value.ActualName}", property.Declaration.Type));
                    }

                    var objectType = (ObjectType) elementSerialization.Type.Implementation;

                    writer.WriteInitialization(valueCallback, objectType, objectType.SerializationConstructor, initializers);

                    return;
                case XmlElementValueSerialization valueSerialization:
                {
                    writer.UseNamespace(typeof(XElementExtensions).Namespace!);
                    valueCallback(GetDeserializeValueCallFormattable(valueSerialization.Value, element));
                    return;
                }
            }
        }

        private static FormattableString GetDeserializeValueCallFormattable(XmlValueSerialization serialization, FormattableString element)
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
                    return $"({type}){element}";
                }

                if (frameworkType == typeof(Azure.Core.ResourceIdentifier))
                {
                    return $"new {typeof(Azure.Core.ResourceIdentifier)}(({typeof(string)}){element})";
                }

                if (frameworkType == typeof(Azure.Core.ResourceType))
                {
                    return $"({typeof(string)}){element}";
                }

                if (frameworkType == typeof(Guid))
                {
                    return $"new {typeof(Guid)}({element}.Value)";
                }

                if (frameworkType == typeof(Uri))
                {
                    return $"new {typeof(Uri)}(({typeof(string)}){element})";
                }

                var methodName = string.Empty;

                if (frameworkType == typeof(byte[]))
                {
                    methodName = "GetBytesFromBase64Value";
                }

                if (frameworkType == typeof(DateTimeOffset))
                {
                    methodName = "GetDateTimeOffsetValue";
                }

                if (frameworkType == typeof(TimeSpan))
                {
                    methodName = "GetTimeSpanValue";
                }

                if (frameworkType == typeof(object))
                {
                    methodName = "GetObjectValue";
                }

                return $"{element}.{methodName}({serialization.Format.ToFormatSpecifier():L})";
            }

            switch (type.Implementation)
            {
                case ObjectType _:
                    var nonNullable = type.WithNullable(false);
                    return $"{nonNullable}.Deserialize{nonNullable.Name}({element})";

                case EnumType clientEnum:
                    return clientEnum.IsExtendable
                        ? $"new {clientEnum.Type}({element}.Value)"
                        : (FormattableString)$"{element}.Value.To{clientEnum.Type:D}()";

                default:
                    throw new NotSupportedException();
            }
        }

        public static void WriteDeserializationForMethods(this CodeWriter writer, XmlElementSerialization serialization, Action<FormattableString> valueCallback, string response)
        {
            var document = new CodeWriterDeclaration("document");
            writer.Line($"var {document:D} = {typeof(XDocument)}.Load({response}.ContentStream, LoadOptions.PreserveWhitespace);");
            writer.ToDeserializeCall(serialization, $"{document}", valueCallback);
        }

        private static void CollectProperties(Dictionary<ObjectTypeProperty, CodeWriterDeclaration> propertyVariables, XmlObjectSerialization element)
        {
            foreach (var attribute in element.Attributes)
            {
                propertyVariables.Add(attribute.Property, new CodeWriterDeclaration(attribute.Property.Declaration.Name.ToVariableName()));
            }

            foreach (var attribute in element.Elements)
            {
                propertyVariables.Add(attribute.Property, new CodeWriterDeclaration(attribute.Property.Declaration.Name.ToVariableName()));
            }

            foreach (var attribute in element.EmbeddedArrays)
            {
                propertyVariables.Add(attribute.Property, new CodeWriterDeclaration(attribute.Property.Declaration.Name.ToVariableName()));
            }

            if (element.ContentSerialization != null)
            {
                propertyVariables.Add(
                    element.ContentSerialization.Property,
                    new CodeWriterDeclaration(element.ContentSerialization.Property.Declaration.Name.ToVariableName()));
            }
        }
    }
}
