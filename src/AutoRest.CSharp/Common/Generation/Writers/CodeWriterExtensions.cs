// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

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

        public static CodeWriter AppendRawIf(this CodeWriter writer, string str, bool condition)
        {
            if (condition)
            {
                writer.AppendRaw(str);
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

        public static CodeWriter WriteFieldDeclaration(this CodeWriter writer, FieldDeclaration field)
        {
            if (field.Description != null)
            {
                writer.Line().WriteXmlDocumentationSummary(field.Description);
            }

            var modifiers = field.Modifiers;

            if (field.WriteAsProperty)
            {
                writer
                    .AppendRaw(modifiers.HasFlag(FieldModifiers.Public) ? "public " : (modifiers.HasFlag(FieldModifiers.Internal) ? "internal " : "private "));
            }
            else
            {
                writer
                    .AppendRaw(modifiers.HasFlag(FieldModifiers.Public) ? "public " : (modifiers.HasFlag(FieldModifiers.Internal) ? "internal " : "private "))
                    .AppendRawIf("const ", modifiers.HasFlag(FieldModifiers.Const))
                    .AppendRawIf("static ", modifiers.HasFlag(FieldModifiers.Static))
                    .AppendRawIf("readonly ", modifiers.HasFlag(FieldModifiers.ReadOnly));
            }

            writer.Append($"{field.Type} {field.Declaration:D}");

            if (field.WriteAsProperty)
            {
                writer.AppendRaw(modifiers.HasFlag(FieldModifiers.ReadOnly) ? "{ get; }" : "{ get; set; }");
            }

            if (field.DefaultValue != null)
            {
                return writer.AppendRaw(" = ").Append(field.DefaultValue).Line($";");
            }

            return field.WriteAsProperty ? writer.Line() : writer.Line($";");
        }

        public static CodeWriter.CodeWriterScope WriteMethodDeclaration(this CodeWriter writer, MethodSignatureBase methodBase, params string[] disabledWarnings)
        {
            foreach (var disabledWarning in disabledWarnings)
            {
                writer.Line($"#pragma warning disable {disabledWarning}");
            }

            writer
                .AppendRawIf("public ", methodBase.Modifiers.HasFlag(Public))
                .AppendRawIf("internal ", methodBase.Modifiers.HasFlag(Internal))
                .AppendRawIf("protected ", methodBase.Modifiers.HasFlag(Protected))
                .AppendRawIf("private ", methodBase.Modifiers.HasFlag(Private));


            if (methodBase is MethodSignature method)
            {
                writer
                    .AppendRawIf("async ", methodBase.Modifiers.HasFlag(Async) && Configuration.AzureArm)
                    .AppendRawIf("virtual ", methodBase.Modifiers.HasFlag(Virtual))
                    .AppendRawIf("static ", methodBase.Modifiers.HasFlag(Static))
                    .AppendRawIf("async ", methodBase.Modifiers.HasFlag(Async) && !Configuration.AzureArm);

                if (method.ReturnType != null)
                {
                    writer.Append($"{method.ReturnType} ");
                }
                else
                {
                    writer.AppendRaw("void ");
                }
            }

            writer
                .Append($"{methodBase.Name}(")
                .AppendRawIf("this ", methodBase.Modifiers.HasFlag(Extension));

            foreach (var parameter in methodBase.Parameters)
            {
                writer.WriteParameter(parameter);
            }

            writer.RemoveTrailingComma();
            writer.Append($")");

            if (methodBase is ConstructorSignature { Initializer: { } } constructor)
            {
                var (isBase, arguments) = constructor.Initializer;

                if (!isBase || arguments.Any())
                {
                    writer.AppendRaw(isBase ? ": base(" : ": this(");
                    foreach (var argument in arguments)
                    {
                        writer.Append($"{argument}, ");
                    }
                    writer.RemoveTrailingComma();
                    writer.Append($")");
                }
            }

            writer.Line();
            foreach (var disabledWarning in disabledWarnings)
            {
                writer.Line($"#pragma warning restore {disabledWarning}");
            }

            return writer.Scope();
        }

        public static CodeWriter WriteMethodDocumentation(this CodeWriter writer, MethodSignatureBase methodBase)
        {
            writer.WriteXmlDocumentationSummary($"{methodBase.Description}");
            writer.WriteXmlDocumentationParameters(methodBase.Parameters);
            writer.WriteXmlDocumentationRequiredParametersException(methodBase.Parameters);
            writer.WriteXmlDocumentationNonEmptyParametersException(methodBase.Parameters);
            if (methodBase is MethodSignature {ReturnDescription: { }} method)
            {
                writer.WriteXmlDocumentationReturns(method.ReturnDescription);
            }

            return writer;
        }

        public static void WriteParameter(this CodeWriter writer, Parameter clientParameter, bool enforceDefaultValue = false)
        {
            if (clientParameter.Attributes.Any())
            {
                writer.AppendRaw("[");
                foreach (var attribute in clientParameter.Attributes)
                {
                    writer.Append($"{attribute.Type}, ");
                }
                writer.RemoveTrailingComma();
                writer.AppendRaw("]");
            }

            writer.Append($"{clientParameter.Type} {clientParameter.Name:D}");
            if (clientParameter.DefaultValue != null && clientParameter.UseDefaultValueInCtorParam)
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
            else if (!clientParameter.IsRequired || enforceDefaultValue)
            {
                // initialize with default
                writer.Append($" = default");
            }

            writer.AppendRaw(",");
        }

        public static CodeWriter WriteParametersValidation(this CodeWriter writer, IReadOnlyCollection<Parameter> parameters)
        {
            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameterValidation(parameter);
            }

            writer.Line();
            return writer;
        }

        private static void WriteParameterValidation(this CodeWriter writer, Parameter parameter)
        {
            if (parameter.DefaultValue != null && parameter.Type.Equals(typeof(Uri)) && parameter.DefaultValue.Value.Type.Equals(typeof(string)))
            {
                writer
                    .Append($"{parameter.Name:I} ??= new {typeof(Uri)}(")
                    .WriteConstant(parameter.DefaultValue.Value)
                    .LineRaw(");");
            }
            else if (parameter.DefaultValue != null && !TypeFactory.CanBeInitializedInline(parameter.Type, parameter.DefaultValue))
            {
                writer
                    .Append($"{parameter.Name:I} ??= ")
                    .WriteConstant(parameter.DefaultValue.Value)
                    .LineRaw(";");
            }
            else if (HasEmptyCheck(parameter))
            {
                writer.Line($"{typeof(Argument)}.{nameof(Argument.AssertNotNullOrEmpty)}({parameter.Name:I}, nameof({parameter.Name:I}));");
            }
            else if (CanWriteNullCheck(parameter))
            {
                writer.Line($"{typeof(Argument)}.{nameof(Argument.AssertNotNull)}({parameter.Name:I}, nameof({parameter.Name:I}));");
            }
        }

        public static CodeWriter WriteParameterNullChecks(this CodeWriter writer, IReadOnlyCollection<Parameter> parameters)
        {
            foreach (Parameter parameter in parameters)
            {
                writer.WriteVariableAssignmentWithNullCheck(parameter.Name, parameter);
            }

            writer.Line();
            return writer;
        }

        public static CodeWriter.CodeWriterScope WriteUsingStatement(this CodeWriter writer, string variableName, bool asyncCall, FormattableString asyncMethodName, FormattableString syncMethodName, FormattableString parameters, out CodeWriterDeclaration variable)
        {
            variable = new CodeWriterDeclaration(variableName);
            return writer.Scope($"using (var {variable:D} = {GetMethodCallFormattableString(asyncCall, asyncMethodName, syncMethodName, parameters)})");
        }

        public static CodeWriter WriteMethodCall(this CodeWriter writer, bool asyncCall, FormattableString methodName, FormattableString parameters)
            => writer.WriteMethodCall(asyncCall, methodName, methodName, parameters);

        public static CodeWriter WriteMethodCall(this CodeWriter writer, bool asyncCall, FormattableString asyncMethodName, FormattableString syncMethodName, FormattableString parameters)
            => writer.Append(GetMethodCallFormattableString(asyncCall, asyncMethodName, syncMethodName, parameters)).LineRaw(";");

        private static FormattableString GetMethodCallFormattableString(bool asyncCall, FormattableString asyncMethodName, FormattableString syncMethodName, FormattableString parameters)
            => asyncCall ? (FormattableString)$"await {asyncMethodName}({parameters}).ConfigureAwait(false)" : (FormattableString)$"{syncMethodName}({parameters})";

        public static void WriteVariableAssignmentWithNullCheck(this CodeWriter writer, string variableName, Parameter parameter)
        {
            // Temporary check to minimize amount of changes in existing generated code
            var assignToSelf = parameter.Name == variableName;
            if (parameter.DefaultValue != null && (!parameter.UseDefaultValueInCtorParam || !TypeFactory.CanBeInitializedInline(parameter.Type, parameter.DefaultValue)))
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
                if (defaultValue.IsNewInstanceSentinel || TypeFactory.IsExtendableEnum(parameter.Type) || parameter.DefaultValue.Value.Type.Equals(parameter.Type) || parameter.Type.Equals(typeof(string)))
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

        private static bool CanWriteNullCheck(Parameter parameter) => parameter.Validate && !parameter.Type.IsValueType;

        public static bool HasNullCheck(Parameter parameter) => !(parameter.DefaultValue != null && !TypeFactory.CanBeInitializedInline(parameter.Type, parameter.DefaultValue)) && CanWriteNullCheck(parameter);

        public static bool HasEmptyCheck(Parameter parameter) => (parameter.RequestLocation == RequestLocation.Uri || parameter.RequestLocation == RequestLocation.Path) && HasNullCheck(parameter) && TypeFactory.IsStringLike(parameter.Type) && !parameter.SkipUrlEncoding;

        public static CodeWriter WriteConstant(this CodeWriter writer, Constant constant)
        {
            if (constant.Value == null)
            {
                // Cast helps the overload resolution
                return writer.Append($"({constant.Type}){null:L}");
            }

            if (constant.IsNewInstanceSentinel)
            {
                return writer.Append($"new {constant.Type}()");
            }

            if (!constant.Type.IsFrameworkType && constant.Value is EnumTypeValue enumTypeValue)
            {
                return writer.Append($"{constant.Type}.{enumTypeValue.Declaration.Name}");
            }

            if (!constant.Type.IsFrameworkType && constant.Value is string enumValue)
            {
                return writer.Append($"new {constant.Type}({enumValue:L})");
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

            return writer;
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
