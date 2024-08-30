// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Common.Output.Models.Types;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Shared;
using static AutoRest.CSharp.Common.Output.Models.Snippets;

namespace AutoRest.CSharp.Common.Output.Builders
{
    internal static class SerializationMethodsBuilder
    {
        public static IEnumerable<Method> BuildSerializationMethods(SerializableObjectType model)
        {
            var serialization = model.Serialization;
            // xml has to be the first to minimize the amount of changes
            if (serialization.Xml is { } xml)
            {
                if (model.IncludeSerializer)
                {
                    foreach (var method in XmlSerializationMethodsBuilder.BuildXmlSerializationMethods(xml))
                    {
                        yield return method;
                    }
                }

                if (model.IncludeDeserializer)
                {
                    yield return XmlSerializationMethodsBuilder.BuildDeserialize(model.Declaration, xml);
                }
            }

            if (serialization.Json is { } json)
            {
                if (model.IncludeSerializer)
                {
                    bool hasInherits = model.Inherits is { IsFrameworkType: false };
                    bool isSealed = model.GetExistingType()?.IsSealed == true;
                    foreach (var method in JsonSerializationMethodsBuilder.BuildJsonSerializationMethods(json, serialization.Interfaces, hasInherits, isSealed))
                    {
                        yield return method;
                    }
                }

                // the deserialize static method
                if (model.IncludeDeserializer)
                {
                    if (JsonSerializationMethodsBuilder.BuildDeserialize(model.Declaration, json, model.GetExistingType()) is { } deserialize)
                    {
                        yield return deserialize;
                    }
                }
            }

            if (serialization.Bicep is { } bicep)
            {
                foreach (var method in BicepSerializationMethodsBuilder.BuildPerTypeBicepSerializationMethods(bicep))
                {
                    yield return method;
                }
            }

            if (serialization.Multipart is { } multipart)
            {
                foreach (var method in MultipartSerializationMethodsBuilder.BuildMultipartSerializationMethods(multipart))
                {
                    yield return method;
                }
            }

            foreach (var method in BuildIModelMethods(model.Serialization))
            {
                yield return method;
            }
        }

        private static IEnumerable<Method> BuildIModelMethods(ObjectTypeSerialization serialization)
        {
            var interfaces = serialization.Interfaces;

            var iModelTInterface = interfaces?.IPersistableModelTInterface;
            var iModelObjectInterface = interfaces?.IPersistableModelObjectInterface;

            if (iModelTInterface is not null)
            {
                var typeOfT = iModelTInterface.Arguments[0];
                var model = typeOfT.Implementation as SerializableObjectType;
                Debug.Assert(model != null, $"{typeOfT} should be a SerializableObjectType");

                var options = new ModelReaderWriterOptionsExpression(KnownParameters.Serializations.Options);
                // BinaryData IPersistableModel<T>.Write(ModelReaderWriterOptions options)
                yield return new
                (
                    new MethodSignature(nameof(IPersistableModel<object>.Write), null, null, MethodSignatureModifiers.None, typeof(BinaryData), null, new[] { KnownParameters.Serializations.Options }, ExplicitInterface: iModelTInterface),
                    BuildModelWriteMethodBody(serialization, options, iModelTInterface).ToArray()
                );

                // T IPersistableModel<T>.Create(BinaryData data, ModelReaderWriterOptions options)
                var data = new BinaryDataExpression(KnownParameters.Serializations.Data);
                yield return new
                (
                    new MethodSignature(nameof(IPersistableModel<object>.Create), null, null, MethodSignatureModifiers.None, typeOfT, null, new[] { KnownParameters.Serializations.Data, KnownParameters.Serializations.Options }, ExplicitInterface: iModelTInterface),
                    BuildModelCreateMethodBody(model, serialization, data, options, iModelTInterface).ToArray()
                );

                // ModelReaderWriterFormat IPersistableModel<T>.GetFormatFromOptions(ModelReaderWriterOptions options)
                yield return new
                (
                    new MethodSignature(nameof(IPersistableModel<object>.GetFormatFromOptions), null, null, MethodSignatureModifiers.None, typeof(string), null, new[] { KnownParameters.Serializations.Options }, ExplicitInterface: iModelTInterface),
                    serialization.WireFormat
                );

                // if the model is a struct, it needs to implement IPersistableModel<object> as well which leads to another 2 methods
                if (iModelObjectInterface is not null)
                {
                    // BinaryData IPersistableModel<object>.Write(ModelReaderWriterOptions options)
                    yield return new
                    (
                        new MethodSignature(nameof(IPersistableModel<object>.Write), null, null, MethodSignatureModifiers.None, typeof(BinaryData), null, new[] { KnownParameters.Serializations.Options }, ExplicitInterface: iModelObjectInterface),
                        // => (IPersistableModel<T>this).Write(options);
                        This.CastTo(iModelTInterface).Invoke(nameof(IPersistableModel<object>.Write), options)
                    );

                    // object IPersistableModel<object>.Create(BinaryData data, ModelReaderWriterOptions options)
                    yield return new
                    (
                        new MethodSignature(nameof(IPersistableModel<object>.Create), null, null, MethodSignatureModifiers.None, typeof(object), null, new[] { KnownParameters.Serializations.Data, KnownParameters.Serializations.Options }, ExplicitInterface: iModelObjectInterface),
                        // => (IPersistableModel<T>this).Read(options);
                        This.CastTo(iModelTInterface).Invoke(nameof(IPersistableModel<object>.Create), data, options)
                    );

                    // ModelReaderWriterFormat IPersistableModel<object>.GetFormatFromOptions(ModelReaderWriterOptions options)
                    yield return new
                    (
                        new MethodSignature(nameof(IPersistableModel<object>.GetFormatFromOptions), null, null, MethodSignatureModifiers.None, typeof(string), null, new[] { KnownParameters.Serializations.Options }, ExplicitInterface: iModelObjectInterface),
                        // => (IPersistableModel<T>this).GetFormatFromOptions(options);
                        This.CastTo(iModelTInterface).Invoke(nameof(IPersistableModel<object>.GetFormatFromOptions), options)
                    );
                }
            }
        }

        private static IEnumerable<MethodBodyStatement> BuildModelWriteMethodBody(ObjectTypeSerialization serialization, ModelReaderWriterOptionsExpression options, CSharpType iModelTInterface)
        {
            // var format = options.Format == "W" ? GetFormatFromOptions(options) : options.Format;
            yield return Serializations.GetConcreteFormat(options, iModelTInterface, out var format);

            yield return EmptyLine;

            var switchStatement = new SwitchStatement(format);

            if (serialization.Json is { } json)
            {
                switchStatement.Add(JsonSerializationMethodsBuilder.BuildJsonWriteSwitchCase(json, options));
            }

            if (serialization.Xml is { } xml)
            {
                switchStatement.Add(XmlSerializationMethodsBuilder.BuildXmlWriteSwitchCase(xml, options));
            }

            if (serialization.Bicep is { } bicep)
            {
                switchStatement.Add(BicepSerializationMethodsBuilder.BuildBicepWriteSwitchCase(bicep, options));
            }

            if (serialization.Multipart is { } multipart)
            {
                switchStatement.Add(MultipartSerializationMethodsBuilder.BuildMultipartWriteSwitchCase(multipart, options));
            }

            // default case
            /*
             * throw new FormatException($"The model {nameof(T)} does not support '{options.Format}' format.");
             */
            var typeOfT = iModelTInterface.Arguments[0];
            var defaultCase = SwitchCase.Default(
                Serializations.ThrowValidationFailException(options.Format, typeOfT, Serializations.ValidationType.Write)
            );
            switchStatement.Add(defaultCase);

            yield return switchStatement;
        }

        private static IEnumerable<MethodBodyStatement> BuildModelCreateMethodBody(SerializableObjectType model, ObjectTypeSerialization serialization, BinaryDataExpression data, ModelReaderWriterOptionsExpression options, CSharpType iModelTInterface)
        {
            // var format = options.Format == "W" ? GetFormatFromOptions(options) : options.Format;
            yield return Serializations.GetConcreteFormat(options, iModelTInterface, out var format);

            yield return EmptyLine;

            var switchStatement = new SwitchStatement(format);

            if (serialization.Json is not null)
            {
                switchStatement.Add(JsonSerializationMethodsBuilder.BuildJsonCreateSwitchCase(model, data, options));
            }

            if (serialization.Xml is not null)
            {
                switchStatement.Add(XmlSerializationMethodsBuilder.BuildXmlCreateSwitchCase(model, data, options));
            }

            // default case
            /*
             * throw new FormatException($"The model {nameof(T)} does not support reading in '{options.Format}' format.");
             */
            var typeOfT = iModelTInterface.Arguments[0];
            var defaultCase = SwitchCase.Default(
                Serializations.ThrowValidationFailException(options.Format, typeOfT, Serializations.ValidationType.Read)
            );
            switchStatement.Add(defaultCase);

            yield return switchStatement;
        }
    }
}
