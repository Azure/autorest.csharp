// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Serialization.Multipart;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static AutoRest.CSharp.Common.Input.Configuration;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal class MultipartSerializationMethodsBuilder
    {
        public static IEnumerable<Method> BuildMultipartSerializationMethods(MultipartFormDataObjectSerialization multipart)
        {
            var data = new BinaryDataExpression(KnownParameters.Serializations.Data);
            var options = new ModelReaderWriterOptionsExpression(KnownParameters.Serializations.Options);
            yield return new Method(
                new MethodSignature(
                    "SerializeMultipart",
                    null,
                    null,
                    MethodSignatureModifiers.Private,
                    typeof(BinaryData),
                    null,
                    new Parameter[] { KnownParameters.Serializations.Options }),
                BuildMultipartSerializationMethodBody(multipart).ToArray());
            yield return new Method(
                new MethodSignature(
                    Configuration.ApiTypes.ToMultipartRequestContentName,
                    null,
                    null,
                    MethodSignatureModifiers.Public,
                    typeof(RequestContent),
                    null,
                    new Parameter[] {KnownParameters.Serializations.Options }),
                BuildMultipartSerializationMethodBody(multipart).ToArray());
            yield return new Method(
                new MethodSignature(
                    "DeserializeMultipart",
                    null,
                    null,
                    MethodSignatureModifiers.Private,
                    multipart.Type,
                    null,
                    new Parameter[] { KnownParameters.Serializations.Options }),
                BuildMultipartDeSerializationMethodBody(multipart!, data, options).ToArray());
            yield return new Method(
                new MethodSignature(
                    "FromResponse",
                    null,
                    null,
                    MethodSignatureModifiers.Public,
                    multipart.Type,
                    null,
                    new Parameter[] { KnownParameters.Serializations.Options }),
                BuildMultipartDeSerializationMethodBody(multipart, data, options).ToArray());
        }
        public static SwitchCase BuildMultipartWriteSwitchCase(MultipartFormDataObjectSerialization multipart, ModelReaderWriterOptionsExpression options)
        {
            return new SwitchCase(
                Serializations.MultipartFormat,
                Return(
                    new InvokeInstanceMethodExpression(
                        null,
                        new MethodSignature(
                            $"SerializeMultipart",
                            null,
                            null,
                            MethodSignatureModifiers.Private,
                            typeof(BinaryData),
                            null,
                            new[]
                            {
                                KnownParameters.Serializations.Options
                            }),
                        new ValueExpression[]
                        {
                            options
                        })));
        }

        public static SwitchCase BuildMultipartReadSwitchCase(SerializableObjectType model, BinaryDataExpression data, ModelReaderWriterOptionsExpression options)
        {
            return new SwitchCase(
                Serializations.MultipartFormat,
                Return(
                    new InvokeInstanceMethodExpression(
                        null,
                        new MethodSignature(
                            $"DeserializeMultipart",
                            null,
                            null,
                            MethodSignatureModifiers.Private,
                            typeof(BinaryData),
                            null,
                            new[]
                            {
                                KnownParameters.Serializations.Options
                            }),
                        new ValueExpression[]
                        {
                            options
                        })));
        }
        public static IEnumerable<MethodBodyStatement> BuildMultipartSerializationMethodBody(MultipartFormDataObjectSerialization? multipart)
        {
            return new MethodBodyStatement[]
                        {
                            Declare(typeof(string), "boundary", new InvokeInstanceMethodExpression(new InvokeStaticMethodExpression(typeof(Guid), nameof(Guid.NewGuid), Array.Empty<ValueExpression>()), nameof(Guid.ToString), Array.Empty<ValueExpression>(), null, false), out var boundary),
                            UsingDeclare("content", typeof(MultipartFormDataBinaryContent), New.Instance(typeof(MultipartFormDataBinaryContent), new[]{boundary}), out var content),
                            WriteMultiParts(new MultipartFormDataExpression(content), multipart!.Properties/*, options*/).ToArray(),
                            //Declare(typeof(BinaryData), "binaryData", new InvokeInstanceMethodExpression(content, nameof(MultipartFormData.ToContent), Array.Empty<ValueExpression>(),
                            Declare(typeof(BinaryData), "binaryData", new InvokeStaticMethodExpression(typeof(ModelReaderWriter), nameof(ModelReaderWriter.Write), new List<ValueExpression>(){ content, ModelReaderWriterOptionsExpression.MultipartFormData},null, false), out var binaryData),
                            Snippets.Return(binaryData)
                        };
        }
        public static IEnumerable<MethodBodyStatement> BuildMultipartDeSerializationMethodBody(MultipartFormDataObjectSerialization multipart, BinaryDataExpression data, ModelReaderWriterOptionsExpression options)
        {
            return new MethodBodyStatement[]
                        {
                            UsingDeclare("content", typeof(MultipartFormDataBinaryContent), MultipartFormDataExpression.Create(data), out var content),
                            InitialObject(multipart, new MultipartFormDataExpression(content)).ToArray()
                        };
        }
        /*TODO: handle additionalProperties. */
        private static IEnumerable<MethodBodyStatement> WriteMultiParts(MultipartFormDataExpression multipartContent, IEnumerable<MultipartPropertySerialization> properties/*, ModelReaderWriterOptionsExpression? options*/)
        {
            foreach (MultipartPropertySerialization property in properties)
            {
                if (property.SerializedType is { IsNullable: true })
                {
                    var checkPropertyIsInitialized = TypeFactory.IsCollectionType(property.SerializedType) && !TypeFactory.IsReadOnlyMemory(property.SerializedType) && property.IsRequired
                        ? And(NotEqual(property.Value, Null), InvokeOptional.IsCollectionDefined(property.Value))
                        : NotEqual(property.Value, Null);

                    yield return Serializations.WrapInCheckNotWire(
                        property,
                        /*options?.Format*/Literal("MFD"),
                        InvokeOptional.WrapInIsDefined(
                            property,
                    new IfElseStatement(checkPropertyIsInitialized,
                    WritePropertySerialization(multipartContent, property), null)
                    ));
                }
                else
                {
                    yield return Serializations.WrapInCheckNotWire(
                        property,
                    /*options?.Format*/Literal("MFD"),
                        InvokeOptional.WrapInIsDefined(property, WritePropertySerialization(multipartContent, property)));
                }
                /*
                yield return Serializations.WrapInCheckNotWire(
                    property, options?.Format,
                    WritePropertySerialization(multipartContent, property));
                */
            }
        }
        private static MethodBodyStatement WritePropertySerialization(MultipartFormDataExpression mulitpartContent, MultipartPropertySerialization serialization)
        {
            return new[]
            {
                SerializationExression(mulitpartContent, serialization.ValueSerialization,serialization.Value, serialization.SerializedName)
            };
        }
        private static MethodBodyStatement SerializationExression(MultipartFormDataExpression mulitpartContent, ObjectSerialization serialization, TypedValueExpression value, string serializedName) => serialization switch
        {
            MultipartArraySerialization arraySerialization => SerializeArray(mulitpartContent, arraySerialization, value, serializedName),
            MultipartValueSerialization valueSerialization => SerializeValue(mulitpartContent, valueSerialization, value.NullableStructValue(), serializedName),
            _ => throw new NotImplementedException()
        };
        private static MethodBodyStatement SerializeArray(MultipartFormDataExpression mulitpartContent, MultipartArraySerialization serialization, ValueExpression value, string serializedName)
        {
            return new[]
            {
                //new EnumerableExpression(TypeFactory.GetElementType(array.ImplementationType)
                new ForeachStatement(TypeFactory.GetElementType(serialization.Type), "item", value, false, out var item)
                {
                    SerializationExression(mulitpartContent, serialization.ValueSerialization, item, serializedName)
                }
            };
        }

        private static MethodBodyStatement SerializeValue(MultipartFormDataExpression mulitpartContent, MultipartValueSerialization serialization, ValueExpression valueExpression, string serializedName) => serialization switch
        {
            _ when serialization.Type != null && serialization.Type.IsFrameworkType && serialization.Type.FrameworkType == typeof(BinaryData) => mulitpartContent.Add(BuildValueSerizationExpression(serialization.Type, valueExpression), serializedName, serializedName + ".wav", Null),
            _ when serialization.Type != null  => mulitpartContent.Add(BuildValueSerizationExpression(serialization.Type, valueExpression), serializedName),
            _ => mulitpartContent.Add(valueExpression, serializedName)//TODO: check when no serialization Type scenario
        };
        private static ValueExpression BuildValueSerizationExpression(CSharpType valueType,  ValueExpression valueExpression) => valueType switch
        {
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(string) => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.FromString), new[] { valueExpression }),
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(byte[]) => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.FromBytes), new[] { valueExpression }),
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(Stream) => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.FromStream), new[] { valueExpression }),
            //_ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(BinaryData) => new InvokeInstanceMethodExpression(valueExpression, nameof(BinaryData.WithMediaType), new[] { Literal("application/octet-stream") }, null, false),
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(BinaryData) => valueExpression,
            _ => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.FromObjectAsJson), new[] { valueExpression }, new[] { valueType })
        };

        private static ValueExpression BuildValueDeserializationExpression(CSharpType valueType, ValueExpression valueExpression) => valueType switch
        {
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(string) => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.ToString), new[] { valueExpression }),
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(byte[]) => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.ToArray), new[] { valueExpression }),
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(Stream) => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.ToStream), new[] { valueExpression }),
            _ when valueType.IsFrameworkType && valueType.FrameworkType == typeof(BinaryData) => valueExpression,
            _ => new InvokeStaticMethodExpression(typeof(BinaryData), nameof(BinaryData.ToObjectFromJson), new[] { valueExpression }, new[] { valueType})

        };

        /*TODO: handle additionalProperties and polymorphism.*/
        /// Collects a list of properties being read from all level of object hierarchy
        private static void CollectPropertiesForDeserialization(IDictionary<MultipartPropertySerialization, VariableReference> propertyVariables, MultipartFormDataObjectSerialization multipart)
        {
            foreach (MultipartPropertySerialization mpProperty in multipart.Properties)
            {
                if (mpProperty.ValueSerialization is { } valueSerialization)
                {
                    var type = mpProperty.SerializedType is not null && TypeFactory.IsCollectionType(mpProperty.SerializedType)
                        ? mpProperty.SerializedType
                        : valueSerialization.Type;
                    var propertyDeclaration = new CodeWriterDeclaration(mpProperty.SerializedName.ToVariableName());
                    propertyVariables.Add(mpProperty, new VariableReference(type, propertyDeclaration));
                }
                /*
                else if (mpProperty.PropertySerializations != null)
                {
                    CollectPropertiesForDeserialization(propertyVariables, jsonProperty.PropertySerializations);
                }
                */
            }
        }
        /*
        private static IEnumerable<MethodBodyStatement> DeserializeMultiParts(MultipartFormDataContentExpression multipartContent, MultipartFormDataObjectSerialization multipart, IReadOnlyDictionary<MultipartPropertySerialization, VariableReference> propertyVariables, ModelReaderWriterOptionsExpression? options)
        {
            return new MethodBodyStatement[]
            {
                new ForeachStatement(typeof(MultipartContentPart), "part", multipartContent.ContentParts, false, out var part)
                {
                    DeserializeIntoObjectProperties(multipart.Properties, propertyVariables).ToArray()
                }
            };
        }
        */
        private static IEnumerable<MethodBodyStatement> DeserializeIntoObjectProperties(IEnumerable<MultipartPropertySerialization> properties, ValueExpression partContent, IReadOnlyDictionary<MultipartPropertySerialization, VariableReference> propertyVariables)
        {
            /*
             var result = s.Substring("form-data".Length + 1).Trim()
                 .Split(';')
                 .Select(x => x.Trim().Split('='))
                 .ToDictionary(x => x[0], x => x[1].Trim('"'));
            */
            yield return Declare(typeof(string), "propertyName", new MemberExpression(partContent, nameof(FormDataItem.Name)), out var propertyName);
            foreach (var property in properties)
            {
                yield return new IfStatement(Equal(propertyName, Literal(property.SerializedName)))
                {
                    DeserializeIntoObjectProperty(property, partContent, propertyVariables)
                };
            }
        }
        private static MethodBodyStatement DeserializeIntoObjectProperty(MultipartPropertySerialization property, ValueExpression partContent, IReadOnlyDictionary<MultipartPropertySerialization, VariableReference> propertyVariables)
        {
            ValueExpression propertyValue;
            if (property.SerializedType is { IsFrameworkType: true } framework && framework.FrameworkType == typeof(BinaryData))
            {
                propertyValue = new MemberExpression(partContent, nameof(FormDataItem.Content));
            }
            else
            {
                propertyValue = new InvokeInstanceMethodExpression(new MemberExpression(partContent, nameof(FormDataItem.Content)), GetPropertyDeserializationMethod(property), Array.Empty<ValueExpression>(), GetArguments(property), false);
            }
            List <MethodBodyStatement> statements = new List<MethodBodyStatement>
            {
                /*
                Declare(property.SerializedType!, "content", new InvokeInstanceMethodExpression(partContent, nameof(BinaryData.ToObjectFromJson), Array.Empty<ValueExpression>(), null, false), out var value),
                TypeFactory.IsReadOnlyMemory(property.SerializedType!)
                ? Assign(propertyVariables[property], New.Instance(property.SerializedType!, value))
                    : Assign(propertyVariables[property], value),
                */
                TypeFactory.IsReadOnlyMemory(property.SerializedType!)
                ? Assign(propertyVariables[property], New.Instance(property.SerializedType!, propertyValue))
                    : Assign(propertyVariables[property], propertyValue),
                Continue
            };
            return statements;
        }
        private static string GetPropertyDeserializationMethod(MultipartPropertySerialization property)
        {
            if (property.SerializedType is { IsFrameworkType: true } frameworkType)
            {
                return frameworkType switch
                {
                    _ when frameworkType.FrameworkType == typeof(string) => nameof(BinaryData.ToString),
                    _ when frameworkType.FrameworkType == typeof(byte[]) => nameof(BinaryData.ToArray),
                    _ when frameworkType.FrameworkType == typeof(Stream) => nameof(BinaryData.ToStream),
                    _  => nameof(BinaryData.ToObjectFromJson),
                    /*
                    _ when frameworkType.FrameworkType == typeof(Int32) => nameof(BinaryData.ToObjectFromJson),
                    _ when frameworkType.FrameworkType == typeof(float) => nameof(BinaryData.ToObjectFromJson),
                    _ => throw new InvalidOperationException($"Unsupported type {frameworkType.FrameworkType.Name} for deserialization")
                    */
                };
            }
            else
            {
                return nameof(BinaryData.ToObjectFromJson);
            }
        }
        private static IReadOnlyList<CSharpType>? GetArguments(MultipartPropertySerialization property)
        {
            if (property.SerializedType is { IsFrameworkType: true } frameworkType)
            {
                return frameworkType switch
                {
                    _ when frameworkType.FrameworkType == typeof(string) => null,
                    _ when frameworkType.FrameworkType == typeof(byte[]) => null,
                    _ when frameworkType.FrameworkType == typeof(Stream) => null,
                    _ => new List<CSharpType>() { frameworkType },
                    /*
                    _ when frameworkType.FrameworkType == typeof(Int32) => new List<CSharpType>() { frameworkType },
                    _ when frameworkType.FrameworkType == typeof(float) => new List<CSharpType>() { frameworkType },
                    _ => throw new InvalidOperationException($"Unsupported type {frameworkType.FrameworkType.Name} for serialization")
                    */
                };
            } else
            {
                if (property.SerializedType != null)
                {
                    return new List<CSharpType>() { property.SerializedType };
                } else
                {
                    return null;
                }
            }
        }
        private static IEnumerable<MethodBodyStatement> InitialObject(MultipartFormDataObjectSerialization multipart, MultipartFormDataExpression multipartContent)
        {
            /* collect properties. */
            var propertyVariables = new Dictionary<MultipartPropertySerialization, VariableReference>();

            CollectPropertiesForDeserialization(propertyVariables, multipart);
            var additionalProperties = multipart.AdditionalProperties;
            if (additionalProperties != null)
            {
                propertyVariables.Add(additionalProperties, new VariableReference(additionalProperties.Value.Type, additionalProperties.SerializationConstructorParameterName));
            }
            /* Declare properties. */
            foreach (var variable in propertyVariables)
            {
                /*
                if (serialization.Discriminator?.SerializedName == variable.Key.SerializedName &&
                    isThisTheDefaultDerivedType &&
                    serialization.Discriminator.Value is not null &&
                    (!serialization.Discriminator.Property.ValueType.IsEnum || serialization.Discriminator.Property.ValueType.Implementation is EnumType { IsExtensible: true }))
                {
                    var defaultValue = serialization.Discriminator.Value.Value.Value?.ToString();
                    yield return Declare(variable.Value, Literal(defaultValue));
                }
                else
                {
                    yield return Declare(variable.Value, Default);
                }
                */
                yield return Declare(variable.Value, Default);
            }
            /* Deserialize multiparts to properties. */
            if (additionalProperties != null)
            {
                var dictionary = new VariableReference(additionalProperties.Type, "additionalPropertiesDictionary");
                yield return Declare(dictionary, New.Instance(additionalProperties.Type));
                /*
                yield return new ForeachStatement(typeof(MultipartContentPart), "part", multipartContent.ContentParts, false, out var part)
                {
                    DeserializeIntoObjectProperties(multipart.Properties, part, propertyVariables).ToArray()
                };
                */
                yield return Declare(typeof(IReadOnlyList<FormDataItem>), "multiParts", new InvokeInstanceMethodExpression(multipartContent, nameof(MultipartFormDataExtensions.ParseToFormData), Array.Empty<ValueExpression>(), null, false), out var multiParts);

                yield return new ForeachStatement(typeof(FormDataItem), "part", multiParts, false, out var part)
                {
                    DeserializeIntoObjectProperties(multipart.Properties, part, propertyVariables).ToArray()
                };
                yield return Assign(propertyVariables[additionalProperties], dictionary);
            } else
            {
                /*
                yield return new ForeachStatement(typeof(MultipartContentPart), "part", multipartContent.ContentParts, false, out var part)
                {
                    DeserializeIntoObjectProperties(multipart.Properties, part, propertyVariables).ToArray()
                };
                */
                yield return Declare(typeof(IReadOnlyList<FormDataItem>), "multiParts", new InvokeInstanceMethodExpression(multipartContent, nameof(MultipartFormDataExtensions.ParseToFormData), Array.Empty<ValueExpression>(), null, false), out var multiParts);
                yield return new ForeachStatement(typeof(FormDataItem), "part", multiParts, false, out var part)
                {
                    DeserializeIntoObjectProperties(multipart.Properties, part, propertyVariables).ToArray()
                };
            }
            /* Create object. */
            var parameterValues = propertyVariables.ToDictionary(v => v.Key.SerializationConstructorParameterName, v => GetOptional(v.Key, v.Value));
            var parameters = multipart.ConstructorParameters
                .Select(p => parameterValues[p.Name])
                .ToArray();
            yield return Return(New.Instance(multipart.Type, parameters));
        }
        private static ValueExpression GetOptional(PropertySerialization propertySerialization, TypedValueExpression variable)
        {
            var sourceType = variable.Type;
            if (!sourceType.IsFrameworkType || propertySerialization.SerializationConstructorParameterName == "serializedAdditionalRawData")
            {
                return variable;
            }
            else if (!propertySerialization.IsRequired)
            {
                return InvokeOptional.FallBackToChangeTrackingCollection(variable, propertySerialization.SerializedType);
            }
            return variable;
        }
    }
}
