// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Core;
using AutoRest.CSharp.V3.Generation.Types;
using AutoRest.CSharp.V3.Output.Models.Requests;
using AutoRest.CSharp.V3.Output.Models.Serialization;
using AutoRest.CSharp.V3.Output.Models.Serialization.Json;
using AutoRest.CSharp.V3.Output.Models.Serialization.Xml;
using AutoRest.CSharp.V3.Output.Models.Shared;
using AutoRest.CSharp.V3.Output.Models.Types;
using AutoRest.CSharp.V3.Utilities;
using Microsoft.CodeAnalysis.Options;
using System.Diagnostics.CodeAnalysis;

namespace AutoRest.CSharp.V3.Generation.Writers
{
    internal static class CodeWriterExtensions
    {
        public static CodeWriter AppendNullableValue(this CodeWriter writer, CSharpType type)
        {
            if (type.IsNullable && type.IsValueType)
            {
                writer.Append($".Value");
            }

            return writer;
        }

        public static void WriteParameter(this CodeWriter writer, Parameter clientParameter, bool includeDefaultValue = true)
        {
            writer.Append($"{clientParameter.Type} {clientParameter.Name:D}");
            if (includeDefaultValue &&
                clientParameter.DefaultValue != null)
            {
                if (TypeFactory.CanBeInitializedInline(clientParameter.Type, clientParameter.DefaultValue))
                {
                    writer.Append($" = ");
                    CodeWriterExtensions.WriteConstant(writer, clientParameter.DefaultValue.Value);
                }
                else
                {
                    // initialize with null and set the default later
                    writer.Append($" = null");
                }
            }

            writer.AppendRaw(",");
        }

        public static void WriteParameterNullChecks(this CodeWriter writer, IReadOnlyCollection<Parameter> parameters)
        {
            foreach (Parameter parameter in parameters)
            {
                if (parameter.DefaultValue != null && !TypeFactory.CanBeInitializedInline(parameter.Type, parameter.DefaultValue))
                {
                    if (TypeFactory.IsStruct(parameter.Type))
                    {
                        writer.Append($"{parameter.Name} ??= ");
                        WriteConstant(writer, parameter.DefaultValue.Value);
                    }
                    else
                    {
                        writer.Append($"{parameter.Name} ??= new {parameter.Type}(");
                        WriteConstant(writer, parameter.DefaultValue.Value);
                        writer.Append($")");
                    }
                    writer.Line($";");
                }
                else if (CanWriteNullCheck(parameter))
                {
                    using (writer.Scope($"if ({parameter.Name:I} == null)"))
                    {
                        writer.Line($"throw new {typeof(ArgumentNullException)}(nameof({parameter.Name:I}));");
                    }
                }
            }

            writer.Line();
        }

        private static bool CanWriteNullCheck(Parameter parameter) => parameter.ValidateNotNull && (parameter.Type.IsNullable || !parameter.Type.IsValueType) && parameter.DefaultValue == null;

        private static bool HasNullCheck(Parameter parameter) => !(parameter.DefaultValue != null && !TypeFactory.CanBeInitializedInline(parameter.Type, parameter.DefaultValue)) && CanWriteNullCheck(parameter);

        public static bool HasAnyNullCheck(this IReadOnlyCollection<Parameter> parameters) => parameters.Any(p => HasNullCheck(p));

        public static bool TryGetRequiredParameters(this IReadOnlyCollection<Parameter> parameters, [NotNullWhen(true)] out IReadOnlyCollection<Parameter>? requiredParameters)
        {
            var required = parameters
                .Where(p => HasNullCheck(p))
                .ToArray();

            if (required.Length > 0)
            {
                requiredParameters = required;
                return true;
            }

            requiredParameters = null;
            return false;
        }

        public static void WriteConstant(this CodeWriter writer, Constant constant)
        {
            if (constant.Value == null)
            {
                // Cast helps the overload resolution
                writer.Append($"({constant.Type}){null:L}");
                return;
            }

            if (constant.Value == Constant.NewInstanceSentinel)
            {
                writer.Append($"new {constant.Type}()");
                return;
            }

            if (!constant.Type.IsFrameworkType && constant.Value is EnumTypeValue enumTypeValue)
            {
                writer.Append($"{constant.Type}.{enumTypeValue.Declaration.Name}");
                return;
            }

            if (!constant.Type.IsFrameworkType && constant.Value is string enumValue)
            {
                writer.Append($"new {constant.Type}({enumValue:L})");
                return;
            }

            Type frameworkType = constant.Type.FrameworkType;
            if (frameworkType == typeof(DateTimeOffset))
            {
                var d = (DateTimeOffset)constant.Value;
                d = d.ToUniversalTime();
                writer.Append($"new {typeof(DateTimeOffset)}({d.Year:L}, {d.Month:L}, {d.Day:L} ,{d.Hour:L}, {d.Minute:L}, {d.Second:L}, {d.Millisecond:L}, {typeof(TimeSpan)}.{nameof(TimeSpan.Zero)})");
            }
            else if (frameworkType == typeof(byte[]))
            {
                var value = (byte[])constant.Value;
                writer.Append($"new byte[] {{");
                foreach (byte b in value)
                {
                    writer.Append($"{b}, ");
                }

                writer.Append($"}}");
            }
            else
            {
                writer.Literal(constant.Value);
            }
        }

        public static void WriteDeserializationForMethods(this CodeWriter writer, ObjectSerialization serialization, bool async,
            Action<CodeWriter, CodeWriterDelegate> valueCallback, string responseVariable)
        {
            switch (serialization)
            {
                case JsonSerialization jsonSerialization:
                    writer.WriteDeserializationForMethods(jsonSerialization, async, valueCallback, responseVariable);
                    break;
                case XmlElementSerialization xmlSerialization:
                    writer.WriteDeserializationForMethods(xmlSerialization, valueCallback, responseVariable);
                    break;
                default:
                    throw new NotImplementedException(serialization.ToString());
            }
        }

        public static CodeWriter AppendEnumToString(this CodeWriter writer, EnumType enumType)
        {
            if (!enumType.IsExtendable)
            {
                writer.UseNamespace(enumType.Type.Namespace);
            }
            return writer.AppendRaw(enumType.IsExtendable ? ".ToString()" : ".ToSerialString()");
        }

        public static CodeWriter WriteReferenceOrConstant(this CodeWriter writer, ReferenceOrConstant value)
        {
            if (value.IsConstant)
            {
                writer.WriteConstant(value.Constant);
            }
            else
            {
                var parts = value.Reference.Name.Split(".");

                bool first = true;
                foreach (var part in parts)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        writer.AppendRaw(".");
                    }
                    writer.Identifier(part);
                }
            }

            return writer;
        }

        public static CodeWriter WriteInitialization(
            this CodeWriter writer,
            Action<CodeWriter, CodeWriterDelegate> valueCallback,
            ObjectType objectType,
            ObjectTypeConstructor constructor,
            IEnumerable<PropertyInitializer> initializers)
        {
            PropertyInitializer? FindInitializerForParameter(ObjectTypeConstructor constructor, Parameter constructorParameter)
            {
                var property = constructor.FindPropertyInitializedByParameter(constructorParameter);
                return initializers.SingleOrDefault(i => i.Property == property);
            }

            // Checks if constructor parameters can be satisfied by the provided initializer list
            List<PropertyInitializer>? TryGetParameters(ObjectTypeConstructor constructor)
            {
                List<PropertyInitializer> constructorInitializers = new List<PropertyInitializer>();
                foreach (var constructorParameter in constructor.Parameters)
                {
                    var objectPropertyInitializer = FindInitializerForParameter(constructor, constructorParameter);
                    if (objectPropertyInitializer == null)
                        return null;

                    constructorInitializers.Add(objectPropertyInitializer.Value);
                }

                return constructorInitializers;
            }

            // Find longest satisfiable ctor
            List<PropertyInitializer>? selectedCtorInitializers = TryGetParameters(constructor);

            Debug.Assert(selectedCtorInitializers != null);

            // Find properties that would have to be initialized using a foreach loop
            var collectionInitializers = initializers
                .Except(selectedCtorInitializers)
                .Where(i => i.Property.IsReadOnly && TypeFactory.IsCollectionType(i.Property.Declaration.Type))
                .ToArray();

            // Find properties that would have to be initialized via property initializers
            var restOfInitializers = initializers.Except(selectedCtorInitializers).Except(collectionInitializers).ToArray();

            void WriteObjectInitializer(CodeWriter codeWriter)
            {
                // writes the new Model(param1, param2)
                // {
                //    property = param3
                // }
                // part

                codeWriter.Append($"new {objectType.Type}(");
                foreach (var initializer in selectedCtorInitializers)
                {
                    if (initializer.Type != null)
                    {
                        codeWriter.WriteConversion(initializer.Type, initializer.Property.Declaration.Type, w => w.Append(initializer.Value));
                    }

                    codeWriter.Append($", ");
                }

                codeWriter.RemoveTrailingComma();
                codeWriter.Append($")");

                if (restOfInitializers.Any())
                {
                    using (codeWriter.Scope($"", newLine: false))
                    {
                        foreach (var propertyInitializer in restOfInitializers)
                        {
                            codeWriter.Append($"{propertyInitializer.Property.Declaration.Name} = ");

                            if (propertyInitializer.Type != null)
                            {
                                codeWriter.WriteConversion(propertyInitializer.Type, propertyInitializer.Property.Declaration.Type, w => w.Append(propertyInitializer.Value));
                            }

                            codeWriter.Line($",");
                        }

                        codeWriter.RemoveTrailingComma();
                    }
                }
            }

            void WriteCollectionInitializer(CodeWriter writer1, CodeWriterDeclaration codeWriterDeclaration)
            {
                // Writes the:
                // foreach (var value in param)
                // {
                //     model.CollectionProperty = value;
                // }
                foreach (var propertyInitializer in collectionInitializers)
                {
                    var valueVariable = new CodeWriterDeclaration("value");
                    using (writer1.Scope($"foreach (var {valueVariable:D} in {propertyInitializer.Value})"))
                    {
                        writer1.Append($"{codeWriterDeclaration}.{propertyInitializer.Property.Declaration.Name}.Add({valueVariable});");
                    }
                }
            }

            if (collectionInitializers.Any())
            {
                var modelVariable = new CodeWriterDeclaration(objectType.Declaration.Name.ToVariableName());
                writer.Append($"{objectType.Type} {modelVariable:D} = ");
                WriteObjectInitializer(writer);
                writer.Line($";");

                WriteCollectionInitializer(writer, modelVariable);

                valueCallback(writer, writer => writer.Append(modelVariable));
            }
            else
            {
                valueCallback(writer, WriteObjectInitializer);
            }


            return writer;
        }

        public static void WriteConversion(this CodeWriter writer, CSharpType from, CSharpType to, CodeWriterDelegate value)
        {
            if (to.IsFrameworkType && from.IsFrameworkType)
            {
                if (to.FrameworkType == typeof(IReadOnlyList<>) &&
                    from.FrameworkType == typeof(IEnumerable<>))
                {
                    writer.UseNamespace(typeof(Enumerable).Namespace!);
                    writer.Append(value);
                    if (from.IsNullable)
                    {
                        writer.Append($"?");
                    }
                    writer.Append($".ToList()");
                    return;
                }

                if (to.FrameworkType == typeof(IList<>) &&
                    from.FrameworkType == typeof(IEnumerable<>))
                {
                    writer.UseNamespace(typeof(Enumerable).Namespace!);
                    writer.Append(value);
                    if (from.IsNullable)
                    {
                        writer.Append($"?");
                    }
                    writer.Append($".ToList()");
                    return;
                }
            }

            writer.Append(value);
        }

        internal static CodeWriter.CodeWriterScope? WriteDefinedCheck(this CodeWriter writer, ObjectTypeProperty? property)
        {
            CodeWriter.CodeWriterScope? scope = default;
            if (property != null &&
                property.SchemaProperty != null &&
                !property.SchemaProperty.IsRequired)
            {
                var method = TypeFactory.IsCollectionType(property.Declaration.Type) ? nameof(Optional.IsCollectionDefined) : nameof(Optional.IsDefined);

                var propertyName = property!.Declaration.Name;
                return writer.Scope($"if ({typeof(Optional)}.{method}({propertyName:I}))");
            }

            return scope;
        }

        internal static CodeWriter.CodeWriterScope? WritePropertyNullCheckIf(this CodeWriter writer, ObjectTypeProperty? property)
        {
            if (property == null)
            {
                return null;
            }

            bool hasNullableType = property.ValueType.IsNullable;
            if (hasNullableType)
            {
                var propertyName = property.Declaration.Name;
                return writer.Scope($"if ({propertyName} != null)");
            }

            return null;
        }
    }
}
