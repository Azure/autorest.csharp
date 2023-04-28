// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Types;
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

            return new IfElseStatement(IsNotNull(serialization.Value), statement, null);
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
    }
}
