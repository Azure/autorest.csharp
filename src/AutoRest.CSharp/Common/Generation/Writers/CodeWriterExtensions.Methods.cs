// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Models;

namespace AutoRest.CSharp.Generation.Writers
{
    internal static partial class CodeWriterExtensions
    {
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
                case SwitchCaseLine(var switchCase, var valueExpression):
                    writer.Append($"case {switchCase:L}: ");
                    writer.WriteLine(valueExpression);
                    break;

                case SwitchStatement(var matchExpression, var cases):
                    using (writer.AmbientScope())
                    {
                        writer.Append($"switch (");
                        writer.WriteValueExpression(matchExpression);
                        writer.LineRaw(")");
                        writer.LineRaw("{");
                        foreach (var statement in cases)
                        {
                            writer.WriteBodyBlock(statement);
                        }
                        writer.LineRaw("}");
                    }

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
                    writer.WriteValueExpression(new InstanceMethodCallExpression(instance, methodName, arguments,
                        callAsAsync));
                    break;
                case StaticMethodCallLine(var methodType, var methodName, var arguments, var typeArguments, var
                    callAsExtension, var callAsAsync):
                    writer.WriteValueExpression(new StaticMethodCallExpression(methodType, methodName, arguments,
                        typeArguments, callAsExtension, callAsAsync));
                    break;
                case SetValueLine setValue:
                    writer.WriteValueExpression(setValue.To);
                    writer.AppendRaw(" = ");
                    writer.WriteValueExpression(setValue.From);
                    break;
                case DeclareVariableLine { Type: { } type } declareVariable:
                    writer.Append($"{type} {declareVariable.Name:D} = ");
                    writer.WriteValueExpression(declareVariable.Value);
                    break;
                case DeclareVariableLine declareVariable:
                    writer.Append($"var {declareVariable.Name:D} = ");
                    writer.WriteValueExpression(declareVariable.Value);
                    break;
                case UsingDeclareVariableLine { Type: { } type } declareVariable:
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
                case TypedValueExpression typed:
                    writer.WriteValueExpression(typed.Untyped);
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
