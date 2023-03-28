﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using Azure;
using AutoRest.CSharp.Common.Output.Models;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;
using System.Text.Json;

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

        public static CodeWriter LineIf(this CodeWriter writer, FormattableString formattableString, bool condition)
        {
            if (condition)
            {
                writer.Line(formattableString);
            }

            return writer;
        }

        public static CodeWriter LineRawIf(this CodeWriter writer, string str, bool condition)
        {
            if (condition)
            {
                writer.LineRaw(str);
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


        public static CodeWriter WriteField(this CodeWriter writer, FieldDeclaration field, bool declareInCurrentScope = true)
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

            if (declareInCurrentScope)
            {
                writer.Append($"{field.Type} {field.Declaration:D}");
            }
            else
            {
                writer.Append($"{field.Type} {field.Declaration:I}");
            }

            if (field.WriteAsProperty)
            {
                writer.AppendRaw(modifiers.HasFlag(FieldModifiers.ReadOnly) ? "{ get; }" : "{ get; set; }");
            }

            if (field.DefaultValue != null &&
                (modifiers.HasFlag(FieldModifiers.Const) || modifiers.HasFlag(FieldModifiers.Static)))
            {
                return writer.AppendRaw(" = ").Append(field.DefaultValue).Line($";");
            }

            return field.WriteAsProperty ? writer.Line() : writer.Line($";");
        }

        public static CodeWriter WriteFieldDeclarations(this CodeWriter writer, IEnumerable<FieldDeclaration> fields)
        {
            foreach (var field in fields)
            {
                writer.WriteField(field, declareInCurrentScope: false);
            }

            return writer.Line();
        }

        public static IDisposable WriteMethodDeclaration(this CodeWriter writer, MethodSignatureBase methodBase, params string[] disabledWarnings)
        {
            if (methodBase.Attributes is {} attributes)
            {
                foreach (var attribute in attributes)
                {
                    if (attribute.Arguments.Any())
                    {
                        writer.Append($"[{attribute.Type}(");
                        foreach (var argument in attribute.Arguments)
                        {
                            writer.Append($"{argument:L}, ");
                        }
                        writer.RemoveTrailingComma();
                        writer.LineRaw(")]");
                    }
                    else
                    {
                        writer.Line($"[{attribute.Type}]");
                    }
                }
            }

            foreach (var disabledWarning in disabledWarnings)
            {
                writer.Line($"#pragma warning disable {disabledWarning}");
            }

            writer
                .AppendRawIf("public ", methodBase.Modifiers.HasFlag(Public))
                .AppendRawIf("internal ", methodBase.Modifiers.HasFlag(Internal))
                .AppendRawIf("protected ", methodBase.Modifiers.HasFlag(Protected))
                .AppendRawIf("private ", methodBase.Modifiers.HasFlag(Private));

            writer.AppendRawIf("new ", methodBase.Modifiers.HasFlag(New));

            var method = methodBase as MethodSignature;
            if (method != null)
            {
                if (method.ExplicitInterface is null)
                {
                    writer
                        .AppendRawIf("virtual ", methodBase.Modifiers.HasFlag(Virtual))
                        .AppendRawIf("override ", methodBase.Modifiers.HasFlag(Override))
                        .AppendRawIf("static ", methodBase.Modifiers.HasFlag(Static));
                }

                writer.AppendRawIf("async ", methodBase.Modifiers.HasFlag(Async));

                if (method.ReturnType != null)
                {
                    writer.Append($"{method.ReturnType} ");
                }
                else
                {
                    writer.AppendRaw("void ");
                }

                if (method.ExplicitInterface is not null)
                {
                    writer.Append($"{method.ExplicitInterface}.");
                }
            }

            writer.Append($"{methodBase.Name}");

            if (method?.GenericArguments != null)
            {
                writer.AppendRaw("<");
                foreach (var argument in method.GenericArguments)
                {
                    writer.Append($"{argument:D},");
                }
                writer.RemoveTrailingComma();
                writer.AppendRaw(">");
            }

            writer
                .AppendRaw("(")
                .AppendRawIf("this ", methodBase.Modifiers.HasFlag(Extension));

            var outerScope = writer.AmbientScope();

            foreach (var parameter in methodBase.Parameters)
            {
                writer.WriteParameter(parameter);
            }

            writer.RemoveTrailingComma();
            writer.Append($")");

            if (method?.GenericParameterConstraints != null)
            {
                writer.Line();
                foreach (var (argument, constraint) in method.GenericParameterConstraints)
                {
                    writer.Append($"where {argument:I}: {constraint}");
                }
            }

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

            var innerScope = writer.Scope();
            return Disposable.Create(() =>
            {
                innerScope.Dispose();
                outerScope.Dispose();
            });
        }

        public static CodeWriter WriteMethodDocumentation(this CodeWriter writer, MethodSignatureBase methodBase)
        {
            if (methodBase.SummaryText is { } summaryText)
            {
                writer.WriteXmlDocumentationSummary($"{summaryText}");
            }

            return writer.WriteMethodDocumentationSignature(methodBase);
        }

        public static CodeWriter WriteMethodDocumentationSignature(this CodeWriter writer, MethodSignatureBase methodBase)
        {
            writer.WriteXmlDocumentationParameters(methodBase.Modifiers.HasFlag(Public) ? methodBase.Parameters : methodBase.Parameters.Where(p => p.FormattableDescription is not null));

            writer.WriteXmlDocumentationRequiredParametersException(methodBase.Parameters);
            writer.WriteXmlDocumentationNonEmptyParametersException(methodBase.Parameters);
            if (methodBase is MethodSignature { ReturnDescription: { } } method)
            {
                writer.WriteXmlDocumentationReturns(method.ReturnDescription);
            }

            return writer;
        }

        public static void WriteParameter(this CodeWriter writer, Parameter clientParameter)
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
            if (clientParameter.DefaultValue != null)
            {
                var defaultValue = clientParameter.DefaultValue.Value;
                if (defaultValue.IsNewInstanceSentinel && defaultValue.Type.IsValueType || clientParameter.IsApiVersionParameter && clientParameter.Initializer != null)
                {
                    writer.Append($" = default");
                }
                else
                {
                    writer.Append($" = {clientParameter.DefaultValue.Value.GetConstantFormattable()}");
                }
            }

            writer.AppendRaw(",");
        }

        public static CodeWriter WriteParametersValidation(this CodeWriter writer, IEnumerable<Parameter> parameters)
        {
            foreach (Parameter parameter in parameters)
            {
                writer.WriteParameterValidation(parameter);
            }

            writer.Line();
            return writer;
        }

        private static CodeWriter WriteParameterValidation(this CodeWriter writer, Parameter parameter)
        {
            if (parameter.Validation == Validation.None && parameter.Initializer != null)
            {
                return writer.Line($"{parameter.Name:I} ??= {parameter.Initializer};");
            }

            if (parameter.Validation.Type == ValidationType.AssertNull && parameter.Validation.Data is RequestConditionHeaders requestConditionFlag)
            {
                foreach (RequestConditionHeaders val in Enum.GetValues(typeof(RequestConditionHeaders)).Cast<RequestConditionHeaders>())
                {
                    if (val == RequestConditionHeaders.None || requestConditionFlag.HasFlag(val))
                    {
                        continue;
                    }

                    var message = $"Service does not support the {requestConditionHeaderNames[val]} header for this operation.";
                    writer.Line($"{typeof(Argument)}.{nameof(Argument.AssertNull)}({parameter.Name:I}.{requestConditionFieldNames[val]}, nameof({parameter.Name:I}), {message:L});");
                }
            }

            return parameter.Validation.Type switch
            {
                ValidationType.AssertNotNullOrEmpty => writer.Line($"{typeof(Argument)}.{nameof(Argument.AssertNotNullOrEmpty)}({parameter.Name:I}, nameof({parameter.Name:I}));"),
                ValidationType.AssertNotNull => writer.Line($"{typeof(Argument)}.{nameof(Argument.AssertNotNull)}({parameter.Name:I}, nameof({parameter.Name:I}));"),
                _ => writer
            };
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

        private static Dictionary<RequestConditionHeaders, string> requestConditionHeaderNames = new Dictionary<RequestConditionHeaders, string> {
            {RequestConditionHeaders.None, "" },
            {RequestConditionHeaders.IfMatch, "If-Match" },
            {RequestConditionHeaders.IfNoneMatch, "If-None-Match" },
            {RequestConditionHeaders.IfModifiedSince, "If-Modified-Since" },
            {RequestConditionHeaders.IfUnmodifiedSince, "If-Unmodified-Since" }
        };

        private static Dictionary<RequestConditionHeaders, string> requestConditionFieldNames = new Dictionary<RequestConditionHeaders, string> {
            {RequestConditionHeaders.None, "" },
            {RequestConditionHeaders.IfMatch, "IfMatch" },
            {RequestConditionHeaders.IfNoneMatch, "IfNoneMatch" },
            {RequestConditionHeaders.IfModifiedSince, "IfModifiedSince" },
            {RequestConditionHeaders.IfUnmodifiedSince, "IfUnmodifiedSince" }
        };

        public static CodeWriter WriteMethodCall(this CodeWriter writer, bool asyncCall, FormattableString asyncMethodName, FormattableString syncMethodName, FormattableString parameters)
            => writer.Append(GetMethodCallFormattableString(asyncCall, asyncMethodName, syncMethodName, parameters)).LineRaw(";");

        private static FormattableString GetMethodCallFormattableString(bool asyncCall, FormattableString asyncMethodName, FormattableString syncMethodName, FormattableString parameters)
            => asyncCall ? (FormattableString)$"await {asyncMethodName}({parameters}).ConfigureAwait(false)" : (FormattableString)$"{syncMethodName}({parameters})";

        public static void WriteVariableAssignmentWithNullCheck(this CodeWriter writer, string variableName, Parameter parameter)
        {
            // Temporary check to minimize amount of changes in existing generated code
            var assignToSelf = parameter.Name == variableName;
            if (parameter.Initializer != null)
            {
                if (assignToSelf)
                {
                    writer.Line($"{variableName:I} ??= {parameter.Initializer};");
                }
                else
                {
                    writer.Line($"{variableName:I} = {parameter.Name:I} ?? {parameter.Initializer};");
                }
            }
            else if (parameter.Validation != Validation.None)
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

        public static CodeWriter WriteConstant(this CodeWriter writer, Constant constant) => writer.Append(constant.GetConstantFormattable());

        public static void WriteDeserializationForMethods(this CodeWriter writer, ObjectSerialization serialization, bool async, CodeWriterDeclaration? variable, FormattableString responseVariable, CSharpType? type)
        {
            switch (serialization)
            {
                case JsonSerialization jsonSerialization:
                    bool isBinaryData = type is not null && type.Equals(typeof(BinaryData));
                    writer.WriteBodyBlock(JsonSerializationMethodsBuilder.BuildDeserializationForMethods(jsonSerialization, async, variable, new FormattableStringToExpression(responseVariable), isBinaryData));
                    break;
                case XmlElementSerialization xmlSerialization:
                    writer.WriteDeserializationForMethods(xmlSerialization, variable, responseVariable);
                    break;
                default:
                    throw new NotImplementedException(serialization.ToString());
            }
        }

        public static CodeWriter AppendEnumToString(this CodeWriter writer, EnumType enumType)
        {
            if (!enumType.IsExtensible)
            {
                writer.UseNamespace(enumType.Type.Namespace);
            }
            return writer.AppendRaw(enumType.IsExtensible ? ".ToString()" : $".ToSerial{enumType.ValueType.Name.FirstCharToUpperCase()}()");
        }

        public static CodeWriter AppendEnumFromString(this CodeWriter writer, EnumType enumType, FormattableString value)
        {
            if (enumType.IsExtensible)
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
            => writer.Append(value.GetReferenceOrConstantFormattable());

        public static CodeWriter WriteInitialization(
            this CodeWriter writer,
            Action<FormattableString> valueCallback,
            TypeProvider objectType,
            ObjectTypeConstructor constructor,
            IEnumerable<PropertyInitializer> initializers)
        {
            var initializersSet = initializers.ToHashSet();

            // Find longest satisfiable ctor
            List<PropertyInitializer> selectedCtorInitializers = constructor.Signature.Parameters
                .Select(constructor.FindPropertyInitializedByParameter)
                .Select(property => initializersSet.SingleOrDefault(i => i.Name == property?.Declaration.Name && Equals(i.Type, property.Declaration.Type)))
                .ToList();

            // Checks if constructor parameters can be satisfied by the provided initializer list
            Debug.Assert(!selectedCtorInitializers.Contains(default));

            // Find properties that would have to be initialized using a foreach loop
            var collectionInitializers = initializersSet
                .Except(selectedCtorInitializers)
                .Where(i => i.IsReadOnly && TypeFactory.IsCollectionType(i.Type))
                .ToArray();

            // Find properties that would have to be initialized via property initializers
            var restOfInitializers = initializersSet
                .Except(selectedCtorInitializers)
                .Except(collectionInitializers)
                .ToArray();

            var constructorParameters = selectedCtorInitializers
                .Select<PropertyInitializer, FormattableString>(pi => $"{pi.Value}{GetConversion(writer, pi.ValueType!, pi.Type)}")
                .ToArray()
                .Join(", ");

            var propertyInitializers = restOfInitializers
                .Select<PropertyInitializer, FormattableString>(pi => $"{pi.Name} = {pi.Value}{GetConversion(writer, pi.ValueType!, pi.Type)}")
                .ToArray()
                .Join(",\n ");

            var objectInitializerFormattable = restOfInitializers.Any()
                ? $"new {objectType.Type}({constructorParameters}) {{\n{propertyInitializers}\n}}"
                : (FormattableString)$"new {objectType.Type}({constructorParameters})";

            if (collectionInitializers.Any())
            {
                var modelVariable = new CodeWriterDeclaration(objectType.Declaration.Name.ToVariableName());
                writer.Line($"{objectType.Type} {modelVariable:D} = {objectInitializerFormattable};");

                // Writes the:
                // foreach (var value in param)
                // {
                //     model.CollectionProperty = value;
                // }
                foreach (var propertyInitializer in collectionInitializers)
                {
                    var valueVariable = new CodeWriterDeclaration("value");
                    using (writer.Scope($"if ({propertyInitializer.Value} != null)"))
                    {
                        using (writer.Scope($"foreach (var {valueVariable:D} in {propertyInitializer.Value})"))
                        {
                            writer.Append($"{modelVariable:I}.{propertyInitializer.Name}.Add({valueVariable});");
                        }
                    }
                }

                valueCallback($"{modelVariable:I}");
            }
            else
            {
                valueCallback(objectInitializerFormattable);
            }


            return writer;
        }

        public static CodeWriter WriteConversion(this CodeWriter writer, CSharpType from, CSharpType to)
        {
            if (TypeFactory.RequiresToList(from, to))
            {
                writer.UseNamespace(typeof(Enumerable).Namespace!);
                return writer.AppendRaw(from.IsNullable ? "?.ToList()" : ".ToList()");
            }

            return writer;
        }

        internal static string GetConversion(CodeWriter writer, CSharpType from, CSharpType to)
        {
            if (TypeFactory.RequiresToList(from, to))
            {
                writer.UseNamespace(typeof(Enumerable).Namespace!);
                return from.IsNullable ? "?.ToList()" : ".ToList()";
            }

            return string.Empty;
        }

        public static CodeWriter.CodeWriterScope? WriteDefinedCheck(this CodeWriter writer, PropertySerialization property)
        {
            if (property.IsRequired)
            {
                return default;
            }

            var method = TypeFactory.IsCollectionType(property.PropertyType)
                ? nameof(Optional.IsCollectionDefined)
                : nameof(Optional.IsDefined);
            var propertyName = property.PropertyName;
            return writer.Scope($"if ({typeof(Optional)}.{method}({propertyName:I}))");

        }

        public static CodeWriter.CodeWriterScope? WritePropertyNullCheckIf(this CodeWriter writer, PropertySerialization property)
        {
            if (property.ValueType == null)
            {
                return null;
            }

            if (!property.ValueType.IsNullable)
            {
                return null;
            }

            var propertyName = property.PropertyName;
            return writer.Scope($"if ({propertyName} != null)");
        }

        public static IDisposable WriteCommonMethodWithoutValidation(this CodeWriter writer, MethodSignature signature, FormattableString? returnDescription, bool isAsync, bool isPublicType)
        {
            writer.WriteXmlDocumentationSummary(signature.FormattableDescription);
            writer.WriteXmlDocumentationParameters(signature.Parameters);
            if (isPublicType)
            {
                writer.WriteXmlDocumentationNonEmptyParametersException(signature.Parameters);
                writer.WriteXmlDocumentationRequiredParametersException(signature.Parameters);
            }

            FormattableString? returnDesc = returnDescription ?? signature.ReturnDescription;
            if (returnDesc is not null)
                writer.WriteXmlDocumentationReturns(returnDesc);

            return writer.WriteMethodDeclaration(signature.WithAsync(isAsync));
        }

        public static IDisposable WriteCommonMethod(this CodeWriter writer, MethodSignature signature, FormattableString? returnDescription, bool isAsync, bool isPublicType)
        {
            var scope = WriteCommonMethodWithoutValidation(writer, signature, returnDescription, isAsync, isPublicType);
            if (isPublicType)
                writer.WriteParametersValidation(signature.Parameters);

            return scope;
        }

        public static void WriteMethod(this CodeWriter writer, Method method)
        {
            using (writer.WriteMethodDeclaration(method.Signature))
            {
                writer.WriteBody(method.Body);
            }
            writer.Line();
        }

        public static CodeWriter WriteBody(this CodeWriter writer, MethodBody methodBody)
        {
            foreach (var block in methodBody.Blocks)
            {
                WriteBodyBlock(writer, block);
            }

            return writer;
        }

        public static void WriteBodyBlock(this CodeWriter writer, MethodBodyStatement bodyStatement)
        {
            switch (bodyStatement)
            {
                case ParameterValidationBlock parameterValidation:
                    writer.WriteParametersValidation(parameterValidation.Parameters);
                    break;
                case DiagnosticScopeMethodBodyBlock diagnosticScope:
                    using (writer.WriteDiagnosticScope(diagnosticScope.Diagnostic, diagnosticScope.ClientDiagnosticsReference))
                    {
                        WriteBodyBlock(writer, diagnosticScope.InnerStatement);
                    }
                    break;
                case IfElseStatement(var condition, var ifBlock, var elseBlock):
                    writer.Append($"if(");
                    writer.WriteValueExpression(condition);
                    writer.Line($")");
                    using (writer.Scope())
                    {
                        WriteBodyBlock(writer, ifBlock);
                    }

                    if (elseBlock is not null)
                    {
                        using (writer.Scope($"else"))
                        {
                            WriteBodyBlock(writer, elseBlock);
                        }
                    }
                    break;
                case IfElsePreprocessorDirective(var condition, var ifBlock, var elseBlock):
                    writer.Line($"#if {condition}");
                    writer.AppendRaw("\t\t\t\t");
                    writer.WriteBodyBlock(ifBlock);
                    if (elseBlock is not null)
                    {
                        writer.LineRaw("#else");
                        writer.WriteBodyBlock(elseBlock);
                    }
                    writer.LineRaw("#endif");
                    break;
                case ForeachStatement(var item, var enumerable, var body):
                    using (writer.AmbientScope())
                    {
                        writer.Append($"foreach(var {item:D} in ");
                        writer.WriteValueExpression(enumerable);
                        writer.LineRaw(")");
                        writer.LineRaw("{");
                        WriteBodyBlock(writer, body);
                        writer.LineRaw("}");
                    }
                    break;
                case MethodBodyLine line:
                    writer.WriteLine(line);
                    break;
                case MethodBodyStatements(var blocks):
                    foreach (var block in blocks)
                    {
                        writer.WriteBodyBlock(block);
                    }
                    break;
            }
        }

        public static CodeWriter WriteLine(this CodeWriter writer, MethodBodyLine line)
        {
            switch (line)
            {
                case InstanceMethodCallLine(var instance, var methodName, var arguments, var callAsAsync):
                    writer.WriteValueExpression(new InstanceMethodCallExpression(instance, methodName, arguments, callAsAsync));
                    break;
                case StaticMethodCallLine(var methodType, var methodName, var arguments, var typeArguments, var callAsExtension, var callAsAsync):
                    writer.WriteValueExpression(new StaticMethodCallExpression(methodType, methodName, arguments, typeArguments, callAsExtension, callAsAsync));
                    break;
                case SetValueLine setValue:
                    writer.WriteValueExpression(setValue.To);
                    writer.AppendRaw(" = ");
                    writer.WriteValueExpression(setValue.From);
                    break;
                case DeclareVariableLine {Type: {} type} declareVariable:
                    writer.Append($"{type} {declareVariable.Name:D} = ");
                    writer.WriteValueExpression(declareVariable.Value);
                    break;
                case DeclareVariableLine declareVariable:
                    writer.Append($"var {declareVariable.Name:D} = ");
                    writer.WriteValueExpression(declareVariable.Value);
                    break;
                case UsingDeclareVariableLine {Type: {} type} declareVariable:
                    writer.Append($"using {type} {declareVariable.Name:D} = ");
                    writer.WriteValueExpression(declareVariable.Value);
                    break;
                case UsingDeclareVariableLine declareVariable:
                    writer.Append($"using var {declareVariable.Name:D} = ");
                    writer.WriteValueExpression(declareVariable.Value);
                    break;
                case OneLineLocalFunction localFunction:
                    writer.Append($"{localFunction.ReturnType} {localFunction.Name:D}(");
                    foreach (var parameter in localFunction.Parameters)
                    {
                        writer.Append($"{parameter.Type} {parameter.Name}, ");
                    }
                    writer.RemoveTrailingComma();
                    writer.AppendRaw(") => ");
                    writer.WriteValueExpression(localFunction.Body);
                    break;
                case ReturnValueLine returnValue:
                    writer.AppendRaw("return ");
                    writer.WriteValueExpression(returnValue.Value);
                    break;
                case KeywordLine(var keyword):
                    writer.AppendRaw(keyword);
                    break;
            }

            return writer.LineRaw(";");
        }

        public static void WriteValueExpression(this CodeWriter writer, ValueExpression expression)
        {
            switch (expression)
            {
                case CastExpression cast:
                    writer.Append($"({cast.Type})");
                    writer.WriteValueExpression(cast.Inner);
                    break;
                case CollectionInitializerExpression(var items):
                    writer.AppendRaw("{ ");
                    foreach (var item in items)
                    {
                        writer.WriteValueExpression(item);
                        writer.AppendRaw(",");
                    }
                    writer.RemoveTrailingComma();
                    writer.AppendRaw(" }");
                    break;
                case MemberReference memberReference:
                    writer.WriteValueExpression(memberReference.Inner);
                    writer.Append($".{memberReference.MemberName}");
                    break;
                case StaticMethodCallExpression { CallAsExtension: true } methodCall:
                    writer.AppendRawIf("await ", methodCall.CallAsAsync);
                    if (methodCall.MethodType != null)
                    {
                        writer.UseNamespace(methodCall.MethodType.Namespace);
                    }
                    writer.WriteValueExpression(methodCall.Arguments[0]);
                    writer.AppendRaw(".");
                    writer.AppendRaw(methodCall.MethodName);
                    WriteTypeArguments(writer, methodCall.TypeArguments);
                    WriteArguments(writer, methodCall.Arguments.Skip(1));
                    writer.AppendRawIf(".ConfigureAwait(false)", methodCall.CallAsAsync);
                    break;
                case StaticMethodCallExpression { CallAsExtension: false } methodCall:
                    writer.AppendRawIf("await ", methodCall.CallAsAsync);
                    if (methodCall.MethodType != null)
                    {
                        writer.Append($"{methodCall.MethodType}.");
                    }
                    writer.AppendRaw(methodCall.MethodName);
                    WriteTypeArguments(writer, methodCall.TypeArguments);
                    WriteArguments(writer, methodCall.Arguments);
                    writer.AppendRawIf(".ConfigureAwait(false)", methodCall.CallAsAsync);
                    break;
                case InstanceMethodCallExpression methodCall:
                    writer.AppendRawIf("await ", methodCall.CallAsAsync);
                    if (methodCall.InstanceReference != null)
                    {
                        writer.WriteValueExpression(methodCall.InstanceReference);
                        writer.AppendRaw(".");
                    }
                    writer.AppendRaw(methodCall.MethodName);
                    WriteArguments(writer, methodCall.Arguments);
                    writer.AppendRawIf(".ConfigureAwait(false)", methodCall.CallAsAsync);
                    break;
                case FuncExpression {Parameters: var parameters, Inner: var inner}:
                    using (writer.AmbientScope())
                    {
                        if (parameters.Count == 1)
                        {
                            writer.Declaration(parameters[0]);
                        }
                        else
                        {
                            writer.AppendRaw("(");
                            foreach (var parameter in parameters)
                            {
                                writer.Declaration(parameter);
                                writer.AppendRaw(", ");
                            }
                            writer.RemoveTrailingComma();
                            writer.AppendRaw(")");
                        }

                        writer.AppendRaw(" => ");
                        writer.WriteValueExpression(inner);
                    }
                    break;
                case NewInstanceExpression newInstance:
                    WriteNewInstance(writer, newInstance);
                    break;
                case NullConditionalExpression nullConditional:
                    writer.WriteValueExpression(nullConditional.Inner);
                    writer.AppendRaw("?");
                    break;
                case BinaryOperatorExpression(var op, var left, var right):
                    writer.WriteValueExpression(left);
                    writer.AppendRaw(" ").AppendRaw(op).AppendRaw(" ");
                    writer.WriteValueExpression(right);
                    break;
                case TernaryConditionalOperator ternary:
                    writer.WriteValueExpression(ternary.Condition);
                    writer.AppendRaw(" ? ");
                    writer.WriteValueExpression(ternary.Consequent);
                    writer.AppendRaw(" : ");
                    writer.WriteValueExpression(ternary.Alternative);
                    break;
                case ParameterReference parameterReference:
                    writer.Append($"{parameterReference.Parameter.Name}");
                    break;
                case FormattableStringToExpression formattableString:
                    writer.Append(formattableString.Value);
                    break;
                case TypeReference typeReference:
                    writer.Append($"{typeReference.Type}");
                    break;
                case VariableReference variable:
                    writer.Append($"{variable.Name:I}");
                    break;
            }

            static void WriteNewInstance(CodeWriter writer, NewInstanceExpression newInstanceExpression)
            {
                writer.Append($"new {newInstanceExpression.Type}");
                if (newInstanceExpression.Arguments.Count > 0 || newInstanceExpression.Properties.Count == 0)
                {
                    WriteArguments(writer, newInstanceExpression.Arguments);
                }

                if (newInstanceExpression.Properties.Count > 0)
                {
                    writer.AppendRaw(" { ");
                    foreach (var (name, value) in newInstanceExpression.Properties)
                    {
                        writer.Append($"{name} = ");
                        writer.WriteValueExpression(value);
                        writer.AppendRaw(", ");
                    }
                    writer.RemoveTrailingComma();
                    writer.AppendRaw(" }");
                }
            }

            static void WriteArguments(CodeWriter writer, IEnumerable<ValueExpression> arguments)
            {
                writer.AppendRaw("(");
                foreach (var argument in arguments)
                {
                    writer.WriteValueExpression(argument);
                    writer.AppendRaw(", ");
                }
                writer.RemoveTrailingComma();
                writer.AppendRaw(")");
            }

            static void WriteTypeArguments(CodeWriter writer, IEnumerable<CSharpType>? typeArguments)
            {
                if (typeArguments is null)
                {
                    return;
                }

                writer.AppendRaw("<");
                foreach (var argument in typeArguments)
                {
                    writer.Append($"{argument}, ");
                }
                writer.RemoveTrailingComma();
                writer.AppendRaw(">");
            }
        }
    }
}
