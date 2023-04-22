// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Common.Output.Models.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Models.Statements;
using AutoRest.CSharp.Common.Output.Models.ValueExpressions;
using AutoRest.CSharp.Generation.Types;
using SwitchExpression = AutoRest.CSharp.Common.Output.Models.ValueExpressions.SwitchExpression;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static partial class CodeWriterExtensions
    {
        public static void WriteMethodBodyStatement(this CodeWriter writer, MethodBodyStatement bodyStatement)
        {
            switch (bodyStatement)
            {
                case InvokeInstanceMethodStatement(var instance, var methodName, var arguments, var callAsAsync):
                    writer.WriteValueExpression(new InvokeInstanceMethodExpression(instance, methodName, arguments, null, callAsAsync));
                    writer.LineRaw(";");
                    break;
                case InvokeStaticMethodStatement(var methodType, var methodName, var arguments, var typeArguments, var callAsExtension, var callAsAsync):
                    writer.WriteValueExpression(new InvokeStaticMethodExpression(methodType, methodName, arguments, typeArguments, callAsExtension, callAsAsync));
                    writer.LineRaw(";");
                    break;
                case ParameterValidationBlock parameterValidation:
                    writer.WriteParametersValidation(parameterValidation.Parameters);
                    break;
                case DiagnosticScopeMethodBodyBlock diagnosticScope:
                    using (writer.WriteDiagnosticScope(diagnosticScope.Diagnostic, diagnosticScope.ClientDiagnosticsReference))
                    {
                        WriteMethodBodyStatement(writer, diagnosticScope.InnerStatement);
                    }
                    break;
                case IfElseStatement(var condition, var ifBlock, var elseBlock, var inline):
                    writer.AppendRaw("if (");
                    writer.WriteValueExpression(condition);

                    if (inline)
                    {
                        writer.AppendRaw(") ");
                        using (writer.AmbientScope())
                        {
                            WriteMethodBodyStatement(writer, ifBlock);
                        }
                    }
                    else
                    {
                        writer.LineRaw(")");
                        using (writer.Scope())
                        {
                            WriteMethodBodyStatement(writer, ifBlock);
                        }
                    }

                    if (elseBlock is not null)
                    {
                        if (inline)
                        {
                            using (writer.AmbientScope())
                            {
                                writer.AppendRaw("else ");
                                WriteMethodBodyStatement(writer, elseBlock);
                            }
                        }
                        else
                        {
                            using (writer.Scope($"else"))
                            {
                                WriteMethodBodyStatement(writer, elseBlock);
                            }
                        }
                    }

                    break;
                case IfElsePreprocessorDirective(var condition, var ifBlock, var elseBlock):
                    writer.Line($"#if {condition}");
                    writer.AppendRaw("\t\t\t\t");
                    writer.WriteMethodBodyStatement(ifBlock);
                    if (elseBlock is not null)
                    {
                        writer.LineRaw("#else");
                        writer.WriteMethodBodyStatement(elseBlock);
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
                        WriteMethodBodyStatement(writer, body);
                        writer.LineRaw("}");
                    }

                    break;
                case DeclarationStatement line:
                    writer.WriteDeclaration(line);
                    break;

                case SwitchStatement(var matchExpression, var cases):
                    using (writer.AmbientScope())
                    {
                        writer.Append($"switch (");
                        writer.WriteValueExpression(matchExpression);
                        writer.LineRaw(")");
                        writer.LineRaw("{");
                        foreach (var switchCase in cases)
                        {
                            if (switchCase.Inline)
                            {
                                writer.Append($"case {switchCase.Case:L}: ");
                            }
                            else
                            {
                                writer.Line($"case {switchCase.Case:L}: ");
                            }

                            writer.WriteMethodBodyStatement(switchCase.Statement);
                        }
                        writer.LineRaw("}");
                    }
                    break;

                case KeywordStatement(var keyword, var expression):
                    writer.AppendRaw(keyword);
                    if (expression is not null)
                    {
                        writer.AppendRaw(" ").WriteValueExpression(expression);
                    }
                    writer.LineRaw(";");
                    break;

                case MethodBodyStatements(var statements):
                    foreach (var statement in statements)
                    {
                        writer.WriteMethodBodyStatement(statement);
                    }

                    break;
            }
        }

        private static void WriteDeclaration(this CodeWriter writer, DeclarationStatement declaration)
        {
            switch (declaration)
            {
                case AssignValueStatement setValue:
                    writer.WriteValueExpression(setValue.To);
                    writer.AppendRaw(" = ");
                    writer.WriteValueExpression(setValue.From);
                    break;
                case DeclareVariableStatement { Type: { } type } declareVariable:
                    writer.Append($"{type} {declareVariable.Name:D} = ");
                    writer.WriteValueExpression(declareVariable.Value);
                    break;
                case DeclareVariableStatement declareVariable:
                    writer.Append($"var {declareVariable.Name:D} = ");
                    writer.WriteValueExpression(declareVariable.Value);
                    break;
                case UsingDeclareVariableStatement { Type: { } type } declareVariable:
                    writer.Append($"using {type} {declareVariable.Name:D} = ");
                    writer.WriteValueExpression(declareVariable.Value);
                    break;
                case UsingDeclareVariableStatement declareVariable:
                    writer.Append($"using var {declareVariable.Name:D} = ");
                    writer.WriteValueExpression(declareVariable.Value);
                    break;
                case DeclareLocalFunctionStatement localFunction:
                    writer.Append($"{localFunction.ReturnType} {localFunction.Name:D}(");
                    foreach (var parameter in localFunction.Parameters)
                    {
                        writer.Append($"{parameter.Type} {parameter.Name}, ");
                    }

                    writer.RemoveTrailingComma();
                    writer.AppendRaw(") => ");
                    writer.WriteValueExpression(localFunction.Body);
                    break;
            }

            writer.LineRaw(";");
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
                case MemberReference(var inner, var memberName):
                    if (inner is not null)
                    {
                        writer.WriteValueExpression(inner);
                        writer.AppendRaw(".");
                    }
                    writer.AppendRaw(memberName);
                    break;
                case InvokeStaticMethodExpression { CallAsExtension: true } methodCall:
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
                case InvokeStaticMethodExpression { CallAsExtension: false } methodCall:
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
                case InvokeInstanceMethodExpression methodCall:
                    writer.AppendRawIf("await ", methodCall.CallAsAsync);
                    if (methodCall.InstanceReference != null)
                    {
                        writer.WriteValueExpression(methodCall.InstanceReference);
                        writer.AppendRaw(".");
                    }

                    writer.AppendRaw(methodCall.MethodName);
                    WriteTypeArguments(writer, methodCall.TypeArguments);
                    WriteArguments(writer, methodCall.Arguments);
                    writer.AppendRawIf(".ConfigureAwait(false)", methodCall.CallAsAsync);
                    break;
                case FuncExpression { Parameters: var parameters, Inner: var inner }:
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

                case SwitchExpression(var matchExpression, var cases):
                    using (writer.AmbientScope())
                    {
                        writer.WriteValueExpression(matchExpression);
                        writer.LineRaw(" switch");
                        writer.LineRaw("{");
                        foreach (var switchCase in cases)
                        {
                            writer.WriteValueExpression(switchCase.Case);
                            writer.AppendRaw(" => ");
                            writer.WriteValueExpression(switchCase.Expression);
                            writer.LineRaw(",");
                        }
                        writer.RemoveTrailingComma();
                        writer.Line();
                        writer.AppendRaw("}");
                    }

                    break;

                case NewInstanceExpression(var type, var arguments, var properties):
                    writer.Append($"new {type}");
                    if (arguments.Count > 0 || properties is not { Count: > 0 })
                    {
                        WriteArguments(writer, arguments);
                    }

                    if (properties is { Count: > 0 })
                    {
                        writer.AppendRaw(" { ");
                        foreach (var (name, value) in properties)
                        {
                            writer.Append($"{name} = ");
                            writer.WriteValueExpression(value);
                            writer.AppendRaw(", ");
                        }

                        writer.RemoveTrailingComma();
                        writer.AppendRaw(" }");
                    }

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
                    writer.Append($"{parameterReference.Parameter.Name:I}");
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
                case TypedValueExpression typed:
                    writer.WriteValueExpression(typed.Untyped);
                    break;
                case KeywordExpression(var keyword, var inner):
                    writer.AppendRaw(keyword);
                    if (inner is not null)
                    {
                        writer.AppendRaw(" ").WriteValueExpression(inner);
                    }
                    break;
                case ConstantExpression(var constant):
                    writer.WriteConstant(constant);
                    break;
                case LiteralExpression(var literal, true):
                    writer.Literal(literal).AppendRaw("u8");
                    break;
                case LiteralExpression(var literal, false):
                    writer.Literal(literal);
                    break;
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
