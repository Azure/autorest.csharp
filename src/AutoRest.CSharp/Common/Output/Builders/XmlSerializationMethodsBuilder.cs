// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Xml.Linq;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal static class XmlSerializationMethodsBuilder
    {
        public static IEnumerable<MethodBodyStatement> SerializeExpression(XmlWriterExpression xmlWriter, XmlObjectSerialization objectSerialization, ValueExpression nameHint)
        {
            yield return xmlWriter.WriteStartElement(NullCoalescing(nameHint, Literal(objectSerialization.Name)));

            foreach (XmlObjectAttributeSerialization serialization in objectSerialization.Attributes)
            {
                yield return InvokeOptional.WrapInIsDefined(serialization, WrapInNullCheck(serialization, new[]
                {
                    xmlWriter.WriteStartAttribute(serialization.SerializedName),
                    SerializeValueExpression(xmlWriter, serialization.ValueSerialization, serialization.Value),
                    xmlWriter.WriteEndAttribute()
                }));
            }

            foreach (XmlObjectElementSerialization serialization in objectSerialization.Elements)
            {
                yield return InvokeOptional.WrapInIsDefined(serialization, WrapInNullCheck(serialization, SerializeExpression(xmlWriter, serialization.ValueSerialization, serialization.Value)));
            }

            foreach (XmlObjectArraySerialization serialization in objectSerialization.EmbeddedArrays)
            {
                yield return InvokeOptional.WrapInIsDefined(serialization, WrapInNullCheck(serialization, SerializeExpression(xmlWriter, serialization.ArraySerialization, serialization.Value)));
            }

            if (objectSerialization.ContentSerialization is { } contentSerialization)
            {
                yield return SerializeValueExpression(xmlWriter, contentSerialization.ValueSerialization, contentSerialization.Value);
            }

            yield return xmlWriter.WriteEndElement();
        }

        private static MethodBodyStatement WrapInNullCheck(PropertySerialization serialization, MethodBodyStatement statement)
        {
            if (serialization.SerializedType is null || !serialization.SerializedType.IsNullable)
            {
                return statement;
            }

            return new IfElseStatement(NotEqual(serialization.Value, Null), statement, null);
        }

        public static MethodBodyStatement SerializeExpression(XmlWriterExpression xmlWriter, XmlElementSerialization serialization, ValueExpression expression)
            => serialization switch
            {
                XmlArraySerialization array => SerializeArray(xmlWriter, array, new EnumerableExpression(expression)).AsStatement(),
                XmlDictionarySerialization dictionary => SerializeDictionary(xmlWriter, dictionary, new DictionaryExpression(expression)),
                XmlElementValueSerialization value => SerializeElement(xmlWriter, value, expression),
                _ => throw new NotSupportedException()
            };

        private static IEnumerable<MethodBodyStatement> SerializeArray(XmlWriterExpression xmlWriter, XmlArraySerialization arraySerialization, EnumerableExpression array)
        {
            if (arraySerialization.Wrapped)
            {
                yield return xmlWriter.WriteStartElement(arraySerialization.Name);
            }

            yield return new ForeachStatement("item", array, out var item)
            {
                SerializeExpression(xmlWriter, arraySerialization.ValueSerialization, item)
            };

            if (arraySerialization.Wrapped)
            {
                yield return xmlWriter.WriteEndElement();
            }
        }

        private static MethodBodyStatement SerializeDictionary(XmlWriterExpression xmlWriter, XmlDictionarySerialization dictionarySerialization, DictionaryExpression dictionary)
        {
            return new ForeachStatement("pair", dictionary, out var pair)
            {
                SerializeExpression(xmlWriter, dictionarySerialization.ValueSerialization, pair.Value)
            };
        }

        private static MethodBodyStatement SerializeElement(XmlWriterExpression xmlWriter, XmlElementValueSerialization elementValueSerialization, ValueExpression element)
        {
            var type = elementValueSerialization.Value.Type;
            string elementName = elementValueSerialization.Name;

            if (type is { IsFrameworkType: false, Implementation: ObjectType })
            {
                return xmlWriter.WriteObjectValue(element, elementName);
            }

            if (type.IsFrameworkType && type.FrameworkType == typeof(object))
            {
                return xmlWriter.WriteObjectValue(element, elementName);
            }

            return new[]
            {
                xmlWriter.WriteStartElement(elementName),
                SerializeValueExpression(xmlWriter, elementValueSerialization.Value, element),
                xmlWriter.WriteEndElement()
            };
        }

        private static MethodBodyStatement SerializeValueExpression(XmlWriterExpression xmlWriter, XmlValueSerialization valueSerialization, ValueExpression value)
        {
            var type = valueSerialization.Type;
            value = value.NullableStructValue(type);

            if (!type.IsFrameworkType)
            {
                return type.Implementation switch
                {
                    EnumType clientEnum => xmlWriter.WriteValue(new EnumExpression(clientEnum, value).ToSerial()),
                    _ => throw new NotSupportedException("Object type references are only supported as elements")
                };
            }

            var frameworkType = type.FrameworkType;
            if (frameworkType == typeof(object))
            {
                throw new NotSupportedException("Object references are only supported as elements");
            }

            return xmlWriter.WriteValue(value, frameworkType, valueSerialization.Format);

        }

        public static IEnumerable<MethodBodyStatement> BuildDeserializationForMethods(XmlElementSerialization serialization, ValueExpression? variable, ResponseExpression response)
        {
            yield return Var("document", XDocumentExpression.Load(response.ContentStream, LoadOptions.PreserveWhitespace), out var document);
            if (serialization is XmlArraySerialization { Wrapped: false } arraySerialization)
            {
                var deserializedDocument = BuildDeserializationForArray(arraySerialization, document, out var deserialization);
                yield return deserialization;
                yield return AssignOrReturn(variable, deserializedDocument);
            }
            else
            {
                var elementName = serialization.Name.ToVariableName() + "Element";
                yield return new IfStatement(Is(document.Element(serialization.Name), elementName, out var element))
                {
                    BuildDeserializationForXContainer(serialization, element, out var deserializedContainer),
                    AssignOrReturn(variable, deserializedContainer)
                };
            }
        }

        private static MethodBodyStatement BuildDeserializationForXContainer(XmlElementSerialization serialization, XElementExpression element, out ValueExpression deserializedContainer)
        {
            var deserialization = new MethodBodyStatement();
            switch (serialization)
            {
                case XmlArraySerialization arraySerialization:
                    deserializedContainer = BuildDeserializationForArray(arraySerialization, element, out deserialization);
                    break;

                case XmlDictionarySerialization dictionarySerialization:
                    deserializedContainer = BuildDeserializationForDictionary(dictionarySerialization, element, out deserialization);
                    break;

                case XmlElementValueSerialization valueSerialization:
                    deserializedContainer = DeserializeValue(valueSerialization.Value, element);
                    break;

                default:
                    throw new InvalidOperationException($"Unexpected {nameof(XmlElementSerialization)} type.");
            }

            return deserialization;
        }

        private static ValueExpression BuildDeserializationForArray(XmlArraySerialization arraySerialization, XContainerExpression container, out MethodBodyStatement deserializationStatement)
        {
            deserializationStatement = new MethodBodyStatement[]
            {
                Var("array", ListExpression.New(arraySerialization.Type), out var array),
                new ForeachStatement("e", container.Elements(arraySerialization.ValueSerialization.Name), out var child)
                {
                    BuildDeserializationForXContainer(arraySerialization.ValueSerialization, new XElementExpression(child), out var deserializedChild),
                    array.Add(deserializedChild)
                }
            };
            return array;
        }

        private static ValueExpression BuildDeserializationForDictionary(XmlDictionarySerialization dictionarySerialization, XContainerExpression container, out MethodBodyStatement deserializationStatement)
        {
            deserializationStatement = new MethodBodyStatement[]
            {
                Var("dictionary", DictionaryExpression.New(dictionarySerialization.Type), out var dictionary),
                new ForeachStatement("e", container.Elements(), out var element)
                {
                    BuildDeserializationForXContainer(dictionarySerialization.ValueSerialization, new XElementExpression(element), out var deserializedElement),
                    dictionary.Add(new XElementExpression(element).Name.LocalName, deserializedElement)
                }
            };
            return dictionary;
        }

        private static ValueExpression DeserializeValue(XmlValueSerialization serialization, XElementExpression element)
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
                    return new CastExpression(element, type);
                }

                if (frameworkType == typeof(ResourceIdentifier))
                {
                    return New(typeof(ResourceIdentifier), new CastExpression(element, typeof(string)));
                }

                if (frameworkType == typeof(ResourceType))
                {
                    return new CastExpression(element, typeof(string));
                }

                if (frameworkType == typeof(Guid))
                {
                    return New(typeof(Guid), element.Value);
                }

                if (frameworkType == typeof(Uri))
                {
                    return New(typeof(Uri), new CastExpression(element, typeof(string)));
                }

                if (frameworkType == typeof(byte[]))
                {
                    return element.GetBytesFromBase64Value(serialization.Format.ToFormatSpecifier());
                }

                if (frameworkType == typeof(DateTimeOffset))
                {
                    return element.GetDateTimeOffsetValue(serialization.Format.ToFormatSpecifier());
                }

                if (frameworkType == typeof(TimeSpan))
                {
                    return element.GetTimeSpanValue(serialization.Format.ToFormatSpecifier());
                }

                if (frameworkType == typeof(object))
                {
                    return element.GetObjectValue(serialization.Format.ToFormatSpecifier());
                }
            }

            switch (type.Implementation)
            {
                case SerializableObjectType serializableObjectType:
                    return SerializableObjectTypeExpression.Deserialize(serializableObjectType, element);

                case EnumType clientEnum:
                    return clientEnum.IsExtensible ? New(clientEnum.Type, element.Value) : InvokeToEnum(clientEnum.Type, element.Value);

                default:
                    throw new NotSupportedException();
            }
        }
    }
}
