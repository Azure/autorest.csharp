﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Common.Output.Builders;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Serialization;
using AutoRest.CSharp.Output.Models.Serialization.Json;
using AutoRest.CSharp.Output.Models.Serialization.Xml;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using AutoRest.CSharp.Utilities;
using AutoRest.CSharp.Common.Output.Models;
using Azure.Core;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static partial class CodeWriterExtensions
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
            var outerScope = writer.WriteMethodDeclarationNoScope(methodBase, disabledWarnings);
            writer.Line();
            var innerScope = writer.Scope();
            return Disposable.Create(() =>
            {
                innerScope.Dispose();
                outerScope.Dispose();
            });
        }

        private static IDisposable WriteMethodDeclarationNoScope(this CodeWriter writer, MethodSignatureBase methodBase, params string[] disabledWarnings)
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
                .AppendRawIf("private ", methodBase.Modifiers.HasFlag(Private))
                .AppendRawIf("static ", methodBase.Modifiers.HasFlag(Static));

            if (methodBase is MethodSignature method)
            {
                writer
                    .AppendRawIf("virtual ", methodBase.Modifiers.HasFlag(Virtual))
                    .AppendRawIf("override ", methodBase.Modifiers.HasFlag(Override))
                    .AppendRawIf("new ", methodBase.Modifiers.HasFlag(New))
                    .AppendRawIf("async ", methodBase.Modifiers.HasFlag(Async));

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
            }
            else if (methodBase is OperatorSignature operatorSignature)
            {
                writer
                    .AppendRaw(operatorSignature.IsExplicit ? "explicit " : "implicit ")
                    .AppendRaw("operator ")
                    .Append($"{operatorSignature.ToType}");
            }
            else
            {
                writer.Append($"{methodBase.Name}");
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

            if (methodBase is MethodSignature { GenericParameterConstraints: { } constraints})
            {
                writer.Line();
                foreach (var (argument, constraint) in constraints)
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
                        writer.WriteValueExpression(argument);
                        writer.AppendRaw(", ");
                    }
                    writer.RemoveTrailingComma();
                    writer.AppendRaw(")");
                }
            }

            foreach (var disabledWarning in disabledWarnings)
            {
                writer.Line();
                writer.Append($"#pragma warning restore {disabledWarning}");
            }

            return outerScope;
        }

        public static CodeWriter WriteMethodDocumentation(this CodeWriter writer, MethodSignatureBase methodBase)
        {
            if (methodBase.NonDocumentComment is { } comment)
            {
                writer.Line($"// {comment}");
            }

            if (methodBase.SummaryText is { } summaryText)
            {
                writer.WriteXmlDocumentationSummary(summaryText);
            }

            return writer.WriteMethodDocumentationSignature(methodBase);
        }

        public static CodeWriter WriteMethodDocumentationSignature(this CodeWriter writer, MethodSignatureBase methodBase)
        {
            writer.WriteXmlDocumentationParameters(methodBase.Modifiers.HasFlag(Public) && methodBase is not OperatorSignature ? methodBase.Parameters : methodBase.Parameters.Where(p => p.Description is not null));

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
                writer.WriteMethodBodyStatement(Snippets.AssignIfNull(parameter, parameter.Initializer));
                return writer;
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
                ValidationType.AssertNotNullOrEmpty => writer.Line($"{Configuration.ApiTypes.ArgumentType}.{Configuration.ApiTypes.AssertNotNullOrEmptyName}({parameter.Name:I}, nameof({parameter.Name:I}));"),
                ValidationType.AssertNotNull => writer.Line($"{Configuration.ApiTypes.ArgumentType}.{Configuration.ApiTypes.AssertNotNullName}({parameter.Name:I}, nameof({parameter.Name:I}));"),
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
                    writer
                        .Append($"{variableName:I} ??= ")
                        .WriteValueExpression(parameter.Initializer);
                }
                else
                {
                    writer
                        .Append($"{variableName:I} = {parameter.Name:I} ?? ")
                        .WriteValueExpression(parameter.Initializer);
                }

                writer.LineRaw(";");
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

        public static void WriteDeserializationForMethods(this CodeWriter writer, ObjectSerialization serialization, bool async, StreamExpression stream, CSharpType? type)
        {
            switch (serialization)
            {
                case JsonSerialization jsonSerialization:
                    writer.WriteMethodBodyStatement(JsonSerializationMethodsBuilder.BuildDeserializationForMethods(jsonSerialization, async, null, stream, type is not null && type.Equals(typeof(BinaryData))));
                    break;
                case XmlElementSerialization xmlSerialization:
                    writer.WriteMethodBodyStatement(XmlSerializationMethodsBuilder.BuildDeserializationForMethods(xmlSerialization, null, stream));
                    break;
                default:
                    throw new NotImplementedException(serialization.ToString());
            }
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

        public static CodeWriter WriteConversion(this CodeWriter writer, CSharpType from, CSharpType to)
        {
            if (TypeFactory.RequiresToList(from, to))
            {
                writer.UseNamespace(typeof(Enumerable).Namespace!);
                return writer.AppendRaw(from.IsNullable ? "?.ToList()" : ".ToList()");
            }

            return writer;
        }

        public static IDisposable WriteCommonMethodWithoutValidation(this CodeWriter writer, MethodSignature signature, FormattableString? returnDescription, bool isAsync, bool isPublicType)
        {
            writer.WriteXmlDocumentationSummary(signature.SummaryText);
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

        public static IDisposable WriteCommonMethod(this CodeWriter writer, MethodSignature signature, FormattableString? returnDescription, bool isAsync, bool isPublicType, bool skipValidation = false)
        {
            var scope = WriteCommonMethodWithoutValidation(writer, signature, returnDescription, isAsync, isPublicType);
            if (isPublicType && !skipValidation)
                writer.WriteParametersValidation(signature.Parameters);

            return scope;
        }

        public static void WriteMethod(this CodeWriter writer, Method method)
        {
            if (method.Body is {} body)
            {
                using (writer.WriteMethodDeclaration(method.Signature))
                {
                    writer.WriteMethodBodyStatement(body);
                }
            }
            else if (method.BodyExpression is {} expression)
            {
                using (writer.WriteMethodDeclarationNoScope(method.Signature))
                {
                    writer.AppendRaw(" => ");
                    writer.WriteValueExpression(expression);
                    writer.LineRaw(";");
                }
            }

            writer.Line();
        }
    }
}
