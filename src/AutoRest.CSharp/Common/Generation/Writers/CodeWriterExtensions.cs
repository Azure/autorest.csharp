// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Azure.Core;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Microsoft.CodeAnalysis.Options;
using System.Diagnostics.CodeAnalysis;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static class CodeWriterExtensions
    {
        public static CodeWriter AppendIf(this CodeWriter writer, FormattableString formattableString, bool condition)
        {
            if (condition)
            {
                writer.Append(formattableString);
            }

            return writer;
        }

        public static CodeWriter AppendNullableValue(this CodeWriter writer, CSharpType type)
        {
            if (type.IsNullable && type.IsValueType)
            {
                writer.Append($".Value");
            }

            return writer;
        }

        public static CodeWriter.CodeWriterScope WriteMethodDeclaration(this CodeWriter writer, MethodSignature method)
        {
            writer.WriteXmlDocumentationSummary(method.Description);
            writer.WriteXmlDocumentationParameters(method.Parameters);
            writer.WriteXmlDocumentationRequiredParametersException(method.Parameters);
            if (method.ReturnDescription != null)
            {
                writer.WriteXmlDocumentationReturns(method.ReturnDescription);
            }

            writer
                .Append($"{method.Modifiers} ")
                .AppendIf($"{method.ReturnType} ", method.ReturnType != null)
                .Append($"{method.Name}(");

            foreach (var parameter in method.Parameters)
            {
                writer.WriteParameter(parameter);
            }
            writer.RemoveTrailingComma();
            writer.Append($")");

            if (method.BaseMethod?.Parameters.Length > 0)
            {
                writer.Append($": base(");
                foreach (var parameter in method.BaseMethod.Parameters)
                {
                    writer.Append($"{parameter.Name:I}, ");
                }
                writer.RemoveTrailingComma();
                writer.Append($")");
            }

            writer.Line();
            return writer.Scope();
        }

        public static void WriteParameter(this CodeWriter writer, Parameter clientParameter, bool enforceDefaultValue = false)
        {
            writer.Append($"{clientParameter.Type} {clientParameter.Name:D}");
            if (clientParameter.DefaultValue != null)
            {
                var defaultValue = clientParameter.DefaultValue.Value;
                if (defaultValue.IsNewInstanceSentinel || !TypeFactory.CanBeInitializedInline(clientParameter.Type, defaultValue))
                {
                    // initialize with default
                    if (defaultValue.Type.IsValueType)
                    {
                        writer.Append($" = default");
                    }
                    else
                    {
                        writer.Append($" = null");
                    }
                }
                else
                {
                    writer.Append($" = ");
                    writer.WriteConstant(clientParameter.DefaultValue.Value);
                }
            }
            else if (enforceDefaultValue)
            {
                // initialize with default
                writer.Append($" = default");
            }

            writer.AppendRaw(",");
        }

        public static void WriteParameterNullChecks(this CodeWriter writer, IReadOnlyCollection<Parameter> parameters)
        {
            foreach (Parameter parameter in parameters)
            {
                writer.WriteVariableAssignmentWithNullCheck(parameter.Name, parameter);
            }

            writer.Line();
        }

        public static void WriteVariableAssignmentWithNullCheck(this CodeWriter writer, string variableName, Parameter parameter)
        {
            // Temporary check to minimize amount of changes in existing generated code
            var assignToSelf = parameter.Name == variableName;
            if (parameter.DefaultValue != null && !TypeFactory.CanBeInitializedInline(parameter.Type, parameter.DefaultValue))
            {
                if (assignToSelf)
                {
                    writer.Append($"{variableName:I} ??= ");
                }
                else
                {
                    writer.Append($"{variableName:I} = {parameter.Name:I} ?? ");
                }

                var defaultValue = parameter.DefaultValue.Value;
                if (defaultValue.IsNewInstanceSentinel || TypeFactory.IsExtendableEnum(parameter.Type) || parameter.DefaultValue.Value.Type.Equals(parameter.Type))
                {
                    WriteConstant(writer, defaultValue);
                }
                else
                {
                    writer.Append($"new {parameter.Type}(");
                    WriteConstant(writer, parameter.DefaultValue.Value);
                    writer.Append($")");
                }

                writer.Line($";");
            }
            else if (CanWriteNullCheck(parameter))
            {
                // Temporary check to minimize amount of changes in existing generated code
                if (assignToSelf)
                {
                    using (writer.Scope($"if ({parameter.Name:I} == null)"))
                    {
                        writer.Line($"throw new {typeof(ArgumentNullException)}(nameof({parameter.Name:I}));");
                    }
                }
                else
                {
                    writer.Line($"{variableName:I} = {parameter.Name:I} ?? throw new {typeof(ArgumentNullException)}(nameof({parameter.Name:I}));");
                }
            }
            else if (!assignToSelf)
            {
                writer.Line($"{variableName:I} = {parameter.Name:I};");
            }
        }

        private static bool CanWriteNullCheck(Parameter parameter) => parameter.ValidateNotNull && !parameter.Type.IsValueType;

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

            if (constant.IsNewInstanceSentinel)
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

        public static CodeWriter AppendEnumFromString(this CodeWriter writer, EnumType enumType, CodeWriterDelegate value)
        {
            if (enumType.IsExtendable)
            {
                writer.Append($"new {enumType.Type}({value})");
            }
            else
            {
                writer.UseNamespace(enumType.Type.Namespace);
                writer.Append($"{value}.To{enumType.Declaration.Name}()");
            }

            return writer;
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
            var initializersSet = initializers.ToHashSet();

            // Find longest satisfiable ctor
            List<PropertyInitializer> selectedCtorInitializers = constructor.Signature.Parameters
                .Select(constructor.FindPropertyInitializedByParameter)
                .Select(property => initializersSet.SingleOrDefault(i => i.Property == property))
                .ToList();

            // Checks if constructor parameters can be satisfied by the provided initializer list
            Debug.Assert(!selectedCtorInitializers.Contains(default));

            // Find properties that would have to be initialized using a foreach loop
            var collectionInitializers = initializersSet
                .Except(selectedCtorInitializers)
                .Where(i => i.Property.IsReadOnly && TypeFactory.IsCollectionType(i.Property.Declaration.Type))
                .ToArray();

            // Find properties that would have to be initialized via property initializers
            var restOfInitializers = initializersSet
                .Except(selectedCtorInitializers)
                .Except(collectionInitializers)
                .ToArray();

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
                        codeWriter.Append(initializer.Value);
                        codeWriter.WriteConversion(initializer.Type, initializer.Property.Declaration.Type);
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
                                codeWriter.Append(propertyInitializer.Value);
                                codeWriter.WriteConversion(propertyInitializer.Type, propertyInitializer.Property.Declaration.Type);
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
                    using (writer1.Scope($"if ({propertyInitializer.Value} != null)"))
                    {
                        using (writer1.Scope($"foreach (var {valueVariable:D} in {propertyInitializer.Value})"))
                        {
                            writer1.Append($"{codeWriterDeclaration}.{propertyInitializer.Property.Declaration.Name}.Add({valueVariable});");
                        }
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

                valueCallback(writer, w => w.Append(modelVariable));
            }
            else
            {
                valueCallback(writer, WriteObjectInitializer);
            }


            return writer;
        }

        public static CodeWriter WriteConversion(this CodeWriter writer, CSharpType from, CSharpType to)
        {
            if (to.IsFrameworkType && from.IsFrameworkType)
            {
                if (to.FrameworkType == typeof(IReadOnlyList<>) &&
                    from.FrameworkType == typeof(IEnumerable<>))
                {
                    writer.UseNamespace(typeof(Enumerable).Namespace!);
                    writer.AppendIf($"?", from.IsNullable).Append($".ToList()");
                }
                else if (to.FrameworkType == typeof(IList<>) &&
                    from.FrameworkType == typeof(IEnumerable<>))
                {
                    writer.UseNamespace(typeof(Enumerable).Namespace!);
                    writer.AppendIf($"?", from.IsNullable).Append($".ToList()");
                }
            }

            return writer;
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
