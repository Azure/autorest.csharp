﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using Azure.ResourceManager.Models;
using static AutoRest.CSharp.Common.Output.Models.Snippets;
using ValidationType = AutoRest.CSharp.Output.Models.Shared.ValidationType;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal static class XmlSerializationMethodsBuilder
    {
        public static Method BuildXmlSerializableWrite(XmlObjectSerialization serialization)
        {
            var xmlWriter = new Parameter("writer", null, typeof(XmlWriter), null, ValidationType.None, null);
            var nameHint = new Parameter("nameHint", null, typeof(string), null, ValidationType.None, null);
            return new Method
            (
                new MethodSignature(nameof(IXmlSerializable.Write), null, null, MethodSignatureModifiers.None, null, null, new[]{xmlWriter, nameHint}, ExplicitInterface: typeof(IXmlSerializable)),
                SerializeExpression(new XmlWriterExpression(xmlWriter), serialization, nameHint).AsStatement()
            );
        }

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
            if (serialization.SerializedType is {IsNullable: true} serializedType)
            {
                if (TypeFactory.IsCollectionType(serializedType) && serialization.IsRequired)
                {
                    return new IfElseStatement(And(NotEqual(serialization.Value, Null), InvokeOptional.IsCollectionDefined(serialization.Value)), statement, null);
                }

                return new IfElseStatement(NotEqual(serialization.Value, Null), statement, null);
            }

            return statement;
        }

        public static MethodBodyStatement SerializeExpression(XmlWriterExpression xmlWriter, XmlElementSerialization serialization, ValueExpression expression)
            => serialization switch
            {
                XmlArraySerialization array => SerializeArray(xmlWriter, array, new EnumerableExpression(TypeFactory.GetElementType(array.Type), expression)).AsStatement(),
                XmlDictionarySerialization dictionary => SerializeDictionary(xmlWriter, dictionary, new DictionaryExpression(dictionary.Type.Arguments[0], dictionary.Type.Arguments[1], expression)),
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

        public static Method BuildDeserialize(TypeDeclarationOptions declaration, XmlObjectSerialization serialization)
        {
            var methodName = $"Deserialize{declaration.Name}";
            var element = new Parameter("element", null, typeof(XElement), null, ValidationType.None, null);
            return new Method
            (
                new MethodSignature(methodName, null, null, MethodSignatureModifiers.Internal | MethodSignatureModifiers.Static, serialization.Type, null, new[]{element}),
                BuildDeserializeBody(new XElementExpression(element), serialization).ToArray()
            );
        }

        private static IEnumerable<MethodBodyStatement> BuildDeserializeBody(XElementExpression element, XmlObjectSerialization objectSerialization)
        {
            var propertyVariables = new Dictionary<XmlPropertySerialization, VariableReference>();

            CollectProperties(propertyVariables, objectSerialization);

            foreach (var (property, variable) in propertyVariables)
            {
                yield return new DeclareVariableStatement(variable.Type, variable.Declaration, Default);
            }

            foreach (XmlObjectAttributeSerialization attribute in objectSerialization.Attributes)
            {
                var attributeVariableName = attribute.SerializationConstructorParameterName + "Attribute";
                yield return new IfStatement(Is(element.Attribute(attribute.SerializedName), attributeVariableName, out var attributeVariable))
                {
                    Assign(propertyVariables[attribute], DeserializeValue(attribute.ValueSerialization, attributeVariable))
                };
            }

            foreach (XmlObjectElementSerialization elem in objectSerialization.Elements)
            {
                yield return BuildDeserialization(elem.ValueSerialization, propertyVariables[elem], element);
            }

            foreach (XmlObjectArraySerialization embeddedArray in objectSerialization.EmbeddedArrays)
            {
                yield return BuildDeserialization(embeddedArray.ArraySerialization, propertyVariables[embeddedArray], element);
            }

            if (objectSerialization.ContentSerialization is { } contentSerialization)
            {
                yield return Assign(propertyVariables[contentSerialization], DeserializeValue(contentSerialization.ValueSerialization, element));
            }

            var objectType = (ObjectType)objectSerialization.Type.Implementation;
            var parameterValues = propertyVariables.ToDictionary(v => v.Key.SerializationConstructorParameterName, v => (ValueExpression)v.Value);
            var parameters = objectType.SerializationConstructor.Signature.Parameters
                .Select(p => parameterValues[p.Name])
                .ToArray();

            yield return Return(New.Instance(objectSerialization.Type, parameters));
        }

        public static MethodBodyStatement BuildDeserializationForMethods(XmlElementSerialization serialization, ValueExpression? variable, StreamExpression stream)
        {
            return new[]
            {
                Var("document", XDocumentExpression.Load(stream, LoadOptions.PreserveWhitespace), out var document),
                BuildDeserialization(serialization, variable, document)
            };
        }

        private static MethodBodyStatement BuildDeserialization(XmlElementSerialization serialization, ValueExpression? variable, XContainerExpression document)
        {
            if (serialization is XmlArraySerialization { Wrapped: false } arraySerialization)
            {
                var deserializedDocument = BuildDeserializationForArray(arraySerialization, document, out var deserialization);
                return new[] { deserialization, AssignOrReturn(variable, deserializedDocument) };
            }

            var elementName = serialization.Name.ToVariableName() + "Element";
            return new IfStatement(Is(document.Element(serialization.Name), elementName, out var element))
            {
                BuildDeserializationForXContainer(serialization, element, out var deserializedContainer),
                AssignOrReturn(variable, deserializedContainer)
            };
        }

        private static MethodBodyStatement BuildDeserializationForXContainer(XmlElementSerialization serialization, XElementExpression element, out ValueExpression deserializedContainer)
        {
            var deserialization = EmptyStatement;
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
                Var("array", New.List(arraySerialization.Type.Arguments[0]), out var array),
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
                Var("dictionary", New.Dictionary(dictionarySerialization.Type.Arguments[0], dictionarySerialization.Type.Arguments[1]), out var dictionary),
                new ForeachStatement("e", container.Elements(), out var element)
                {
                    BuildDeserializationForXContainer(dictionarySerialization.ValueSerialization, new XElementExpression(element), out var deserializedElement),
                    dictionary.Add(new XElementExpression(element).Name.LocalName, deserializedElement)
                }
            };
            return dictionary;
        }

        private static ValueExpression DeserializeValue(XmlValueSerialization serialization, ValueExpression value)
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
                    return new CastExpression(value, type);
                }

                if (frameworkType == typeof(ResourceIdentifier))
                {
                    return New.Instance(typeof(ResourceIdentifier), value.CastTo(typeof(string)));
                }

                if (frameworkType == typeof(SystemData))
                {
                    // XML Deserialization of SystemData isn't supported yet.
                    return Null;
                }

                if (frameworkType == typeof(ResourceType))
                {
                    return new CastExpression(value, typeof(string));
                }

                if (frameworkType == typeof(Guid))
                {
                    return value is XElementExpression xElement
                        ? New.Instance(typeof(Guid), xElement.Value)
                        : new CastExpression(value, typeof(Guid));
                }

                if (frameworkType == typeof(Uri))
                {
                    return New.Instance(typeof(Uri), new CastExpression(value, typeof(string)));
                }

                if (value is XElementExpression element)
                {
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
            }

            switch (type.Implementation)
            {
                case SerializableObjectType serializableObjectType:
                    return SerializableObjectTypeExpression.Deserialize(serializableObjectType, value);

                case EnumType clientEnum when value is XElementExpression xe:
                    return EnumExpression.ToEnum(clientEnum, xe.Value);

                case EnumType clientEnum when value is XAttributeExpression xa:
                    return EnumExpression.ToEnum(clientEnum, xa.Value);

                default:
                    throw new NotSupportedException();
            }
        }

        private static void CollectProperties(Dictionary<XmlPropertySerialization, VariableReference> propertyVariables, XmlObjectSerialization element)
        {
            foreach (var attribute in element.Attributes)
            {
                propertyVariables.Add(attribute, new VariableReference(attribute.Value.Type, attribute.SerializationConstructorParameterName));
            }

            foreach (var attribute in element.Elements)
            {
                propertyVariables.Add(attribute, new VariableReference(attribute.Value.Type, attribute.SerializationConstructorParameterName));
            }

            foreach (var attribute in element.EmbeddedArrays)
            {
                propertyVariables.Add(attribute, new VariableReference(attribute.Value.Type, attribute.SerializationConstructorParameterName));
            }

            if (element.ContentSerialization is {} contentSerialization)
            {
                propertyVariables.Add(contentSerialization, new VariableReference(contentSerialization.Value.Type, contentSerialization.SerializationConstructorParameterName));
            }
        }
    }
}
