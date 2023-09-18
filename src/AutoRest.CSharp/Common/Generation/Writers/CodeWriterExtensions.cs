﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.Common.Output.Models;
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
using Azure.Core;
using Azure.Core.Pipeline;
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


        public static CodeWriter WriteParseJsonDocument(this CodeWriter writer, CodeWriterDeclaration responseVariable, bool async, out CodeWriterDeclaration documentVariable)
        {
            documentVariable = new CodeWriterDeclaration("document");

            return async
                ? writer.Line($"using var {documentVariable:D} = await {typeof(JsonDocument)}.{nameof(JsonDocument.ParseAsync)}({responseVariable}.{nameof(Response.ContentStream)}, default, cancellationToken).ConfigureAwait(false);")
                : writer.Line($"using var {documentVariable:D} = {typeof(JsonDocument)}.{nameof(JsonDocument.Parse)}({responseVariable}.{nameof(Response.ContentStream)});");
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
            if (methodBase.Attributes is { } attributes)
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

            var method = methodBase as MethodSignature;
            if (method != null)
            {
                writer
                    .AppendRawIf("virtual ", methodBase.Modifiers.HasFlag(Virtual))
                    .AppendRawIf("override ", methodBase.Modifiers.HasFlag(Override))
                    .AppendRawIf("static ", methodBase.Modifiers.HasFlag(Static))
                    .AppendRawIf("async ", methodBase.Modifiers.HasFlag(Async));

                // SA1206: 'new' should be after static
                writer.AppendRawIf("new ", methodBase.Modifiers.HasFlag(New));

                if (method.ReturnType != null)
                {
                    writer.Append($"{method.ReturnType} ");
                }
                else
                {
                    writer.AppendRaw("void ");
                }
            }
            else
            {
                writer.AppendRawIf("new ", methodBase.Modifiers.HasFlag(New));
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

        public static CodeWriter WriteMethodDocumentation(this CodeWriter writer, MethodSignatureBase methodBase, FormattableString? summaryText = null)
        {
            return writer
                .WriteXmlDocumentationSummary(summaryText ?? $"{methodBase.SummaryText}")
                .WriteMethodDocumentationSignature(methodBase);
        }

        public static CodeWriter WriteMethodDocumentationSignature(this CodeWriter writer, MethodSignatureBase methodBase)
        {
            writer.WriteXmlDocumentationParameters(methodBase.Parameters);
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
            if (parameter.Validation == ValidationType.None && parameter.Initializer != null)
            {
                return writer.Line($"{parameter.Name:I} ??= {parameter.Initializer};");
            }

            return parameter.Validation switch
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
        public static CodeWriter WriteRequestConditionParameterChecks(this CodeWriter writer, IReadOnlyCollection<Parameter> parameters, RequestConditionHeaders requestConditionFlag)
        {
            foreach (Parameter parameter in parameters)
            {
                if (parameter.Type.Equals(typeof(RequestConditions)))
                {
                    foreach (RequestConditionHeaders val in Enum.GetValues(typeof(RequestConditionHeaders)).Cast<RequestConditionHeaders>())
                    {
                        if (val != RequestConditionHeaders.None && !requestConditionFlag.HasFlag(val))
                        {
                            writer.Line($"Argument.AssertNull({parameter.Name:I}.{requestConditionFieldNames[val]}, nameof({parameter.Name:I}), \"Service does not support the {requestConditionHeaderNames[val]} header for this operation.\");");
                        }
                    }
                }
            }
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

        public static CodeWriter WriteMethodCall(this CodeWriter writer, MethodSignature method, IEnumerable<FormattableString> parameters, bool asyncCall)
        {
            var parametersFs = parameters.ToArray().Join(", ");
            if (asyncCall)
            {
                return writer.Append($"await {method.WithAsync(true).Name}({parametersFs}).ConfigureAwait(false)");
            }

            return writer.Append($"{method.WithAsync(false).Name}({parametersFs})");
        }

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
            else if (parameter.Validation != ValidationType.None)
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
                    writer.WriteDeserializationForMethods(jsonSerialization, async, variable, responseVariable, type is not null && type.Equals(typeof(BinaryData)));
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
            return writer.Append($".{enumType.SerializationMethodName}()");
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
            if (TypeFactory.IsCollectionType(property.ValueType) && property.IsRequired)
                return writer.Scope($"if ({propertyName} != null && {typeof(Optional)}.{nameof(Optional.IsCollectionDefined)}({propertyName}))");

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

        public static CodeWriter WriteEnableHttpRedirectIfNecessary(this CodeWriter writer, RestClientMethod restClientMethod, CodeWriterDeclaration messageVariable)
        {
            if (restClientMethod.ShouldEnableRedirect)
            {
                writer.Line($"{nameof(RedirectPolicy)}.{nameof(RedirectPolicy.SetAllowAutoRedirect)}({messageVariable}, true);");
            }
            return writer;
        }

        public static void WriteOverloadMethod(this CodeWriter writer, OverloadMethodSignature overloadMethod)
        {
            writer.WriteXmlDocumentationSummary(overloadMethod.Description);
            if (overloadMethod.IsHiddenFromUser)
            {
                writer.Line($"[{typeof(EditorBrowsableAttribute)}({typeof(EditorBrowsableState)}.{nameof(EditorBrowsableState.Never)})]");
            }
            using (writer.WriteMethodDeclaration(overloadMethod.PreviousMethodSignature))
            {
                writer.Line();
                var awaitOperation = overloadMethod.PreviousMethodSignature.Modifiers.HasFlag(MethodSignatureModifiers.Async) ? "await " : "";
                writer.Append($"return {awaitOperation}{overloadMethod.MethodSignature.Name}(");
                var set = overloadMethod.MissingParameters.ToHashSet(Parameter.TypeAndNameEqualityComparer);
                foreach (var parameter in overloadMethod.MethodSignature.Parameters)
                {
                    if (set.Contains(parameter))
                    {
                        writer.Append($"{parameter.DefaultValue?.Value ?? "default"}, ");
                    }
                    else
                    {
                        writer.Append($"{parameter.Name}, ");
                    }
                }
                writer.RemoveTrailingComma();
                writer.Line($");");
            }
        }
    }
}
