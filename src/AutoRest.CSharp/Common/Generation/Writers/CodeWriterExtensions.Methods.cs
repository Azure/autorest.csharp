// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using AutoRest.CSharp.Common.Output.Expressions.KnownCodeBlocks;
using AutoRest.CSharp.Common.Output.Expressions.KnownValueExpressions;
using AutoRest.CSharp.Common.Output.Expressions.Statements;
using AutoRest.CSharp.Common.Output.Expressions.ValueExpressions;
using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Utilities;
using Azure.ResourceManager.Models;
using SwitchExpression = AutoRest.CSharp.Common.Output.Expressions.ValueExpressions.SwitchExpression;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static partial class CodeWriterExtensions
    {

        public static void WriteMethodBodyStatement(this CodeWriter writer, MethodBodyStatement bodyStatement)
        {
            switch (bodyStatement)
            {
                case InvokeInstanceMethodStatement(var instance, var methodName, var arguments, var callAsAsync):
                    new InvokeInstanceMethodExpression(instance, methodName, arguments, null, callAsAsync).Write(writer);
                    writer.LineRaw(";");
                    break;
                case InvokeStaticMethodStatement(var methodType, var methodName, var arguments, var typeArguments, var callAsExtension, var callAsAsync):
                    new InvokeStaticMethodExpression(methodType, methodName, arguments, typeArguments, callAsExtension, callAsAsync).Write(writer);
                    writer.LineRaw(";");
                    break;
                case ParameterValidationBlock(var parameters, var isLegacy):
                    if (isLegacy)
                    {
                        writer.WriteParameterNullChecks(parameters);
                    }
                    else
                    {
                        writer.WriteParametersValidation(parameters);
                    }
                    break;
                case DiagnosticScopeMethodBodyBlock diagnosticScope:
                    using (writer.WriteDiagnosticScope(diagnosticScope.Diagnostic, diagnosticScope.ClientDiagnosticsReference))
                    {
                        WriteMethodBodyStatement(writer, diagnosticScope.InnerStatement);
                    }
                    break;
                case IfStatement ifStatement:
                    writer.AppendRaw("if (");
                    ifStatement.Condition.Write(writer);

                    if (ifStatement.Inline)
                    {
                        writer.AppendRaw(") ");
                        using (writer.AmbientScope())
                        {
                            WriteMethodBodyStatement(writer, ifStatement.Body);
                        }
                    }
                    else
                    {
                        writer.LineRaw(")");
                        using (ifStatement.AddBraces ? writer.Scope() : writer.AmbientScope())
                        {
                            WriteMethodBodyStatement(writer, ifStatement.Body);
                        }
                    }

                    break;
                case IfElseStatement(var ifBlock, var elseBlock):
                    writer.WriteMethodBodyStatement(ifBlock);
                    if (elseBlock is not null)
                    {
                        if (ifBlock.Inline || !ifBlock.AddBraces)
                        {
                            using (writer.AmbientScope())
                            {
                                writer.AppendRaw("else ");
                                if (!ifBlock.Inline)
                                {
                                    writer.Line();
                                }
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
                case ForeachStatement foreachStatement:
                    using (writer.AmbientScope())
                    {
                        writer.AppendRawIf("await ", foreachStatement.IsAsync);
                        writer.AppendRaw("foreach (");
                        if (foreachStatement.ItemType == null)
                            writer.AppendRaw("var ");
                        else
                            writer.Append($"{foreachStatement.ItemType} ");
                        writer.Append($"{foreachStatement.Item:D} in ");
                        foreachStatement.Enumerable.Write(writer);
                        //writer.AppendRawIf(".ConfigureAwait(false)", foreachStatement.IsAsync);
                        writer.LineRaw(")");
                        writer.LineRaw("{");
                        WriteMethodBodyStatement(writer, foreachStatement.Body.AsStatement());
                        writer.LineRaw("}");
                    }
                    break;
                case ForStatement(var assignment, var condition, var increment) forStatement:
                    using (writer.AmbientScope())
                    {
                        writer.AppendRaw("for (");
                        if (assignment != null)
                            assignment.Write(writer);
                        writer.AppendRaw("; ");
                        if (condition != null)
                            condition.Write(writer);
                        writer.AppendRaw("; ");
                        if (increment != null)
                            increment.Write(writer);
                        writer.LineRaw(")");
                        writer.LineRaw("{");
                        writer.LineRaw("");
                        WriteMethodBodyStatement(writer, forStatement.Body.AsStatement());
                        writer.LineRaw("}");
                    }
                    break;
                case UsingScopeStatement usingStatement:
                    using (writer.AmbientScope())
                    {
                        writer.AppendRaw("using (");
                        if (usingStatement.Type == null)
                            writer.AppendRaw("var ");
                        else
                            writer.Append($"{usingStatement.Type} ");
                        writer.Append($"{usingStatement.Variable:D} = ");
                        usingStatement.Value.Write(writer);
                        writer.LineRaw(")");
                        writer.LineRaw("{");
                        WriteMethodBodyStatement(writer, usingStatement.Body.AsStatement());
                        writer.LineRaw("}");
                    }
                    break;
                case DeclarationStatement line:
                    writer.WriteDeclaration(line);
                    break;

                case SwitchStatement switchStatement:
                    using (writer.AmbientScope())
                    {
                        writer.Append($"switch (");
                        switchStatement.MatchExpression.Write(writer);
                        writer.LineRaw(")");
                        writer.LineRaw("{");
                        foreach (var switchCase in switchStatement.Cases)
                        {
                            if (switchCase.Match.Any())
                            {
                                for (var i = 0; i < switchCase.Match.Count; i++)
                                {
                                    ValueExpression? match = switchCase.Match[i];
                                    writer.AppendRaw("case ");
                                    match.Write(writer);
                                    if (i < switchCase.Match.Count - 1)
                                    {
                                        writer.LineRaw(":");
                                    }
                                }
                            }
                            else
                            {
                                writer.AppendRaw("default");
                            }

                            writer.AppendRaw(": ");
                            if (!switchCase.Inline)
                            {
                                writer.Line();
                            }

                            if (switchCase.AddScope)
                            {
                                using (writer.Scope())
                                {
                                    writer.WriteMethodBodyStatement(switchCase.Statement);
                                }
                            }
                            else
                            {
                                writer.WriteMethodBodyStatement(switchCase.Statement);
                            }
                        }
                        writer.LineRaw("}");
                    }
                    break;

                case KeywordStatement(var keyword, var expression):
                    writer.AppendRaw(keyword);
                    if (expression is not null)
                    {
                        expression.Write(writer.AppendRaw(" "));
                    }
                    writer.LineRaw(";");
                    break;

                case EmptyLineStatement:
                    writer.Line();
                    break;

                case ThrowStatement throwStatement:
                    throwStatement.ThrowExpression.Write(writer);
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
                case AssignValueIfNullStatement setValue:
                    setValue.To.Write(writer);
                    writer.AppendRaw(" ??= ");
                    setValue.From.Write(writer);
                    writer.LineRaw(";");
                    break;
                case AssignValueStatement setValue:
                    setValue.To.Write(writer);
                    writer.AppendRaw(" = ");
                    setValue.From.Write(writer);
                    writer.LineRaw(";");
                    break;
                case DeclareVariableStatement { Type: { } type } declareVariable:
                    writer.Append($"{type} {declareVariable.Name:D} = ");
                    declareVariable.Value.Write(writer);
                    writer.LineRaw(";");
                    break;
                case DeclareVariableStatement declareVariable:
                    writer.Append($"var {declareVariable.Name:D} = ");
                    declareVariable.Value.Write(writer);
                    writer.LineRaw(";");
                    break;
                case UsingDeclareVariableStatement { Type: { } type } declareVariable:
                    writer.Append($"using {type} {declareVariable.Name:D} = ");
                    declareVariable.Value.Write(writer);
                    writer.LineRaw(";");
                    break;
                case UsingDeclareVariableStatement declareVariable:
                    writer.Append($"using var {declareVariable.Name:D} = ");
                    declareVariable.Value.Write(writer);
                    writer.LineRaw(";");
                    break;
                case DeclareLocalFunctionStatement localFunction:
                    writer.Append($"{localFunction.ReturnType} {localFunction.Name:D}(");
                    foreach (var parameter in localFunction.Parameters)
                    {
                        writer.Append($"{parameter.Type} {parameter.Name}, ");
                    }

                    writer.RemoveTrailingComma();
                    writer.AppendRaw(")");
                    if (localFunction.BodyExpression is not null)
                    {
                        writer.AppendRaw(" => ");
                        localFunction.BodyExpression.Write(writer);
                        writer.LineRaw(";");
                    }
                    else
                    {
                        using (writer.Scope())
                        {
                            writer.WriteMethodBodyStatement(localFunction.BodyStatement!);
                        }
                    }
                    break;
                case UnaryOperatorStatement unaryOperatorStatement:
                    unaryOperatorStatement.Expression.Write(writer);
                    writer.LineRaw(";");
                    break;
            }
        }
    }
}
