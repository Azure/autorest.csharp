// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Shared;
using Azure;
using static AutoRest.CSharp.Output.Models.MethodSignatureModifiers;

namespace AutoRest.CSharp.Output.Models
{
    internal record MethodSignature(string Name, string? Summary, string? Description, MethodSignatureModifiers Modifiers, CSharpType? ReturnType, FormattableString? ReturnDescription, IReadOnlyList<Parameter> Parameters, IReadOnlyList<CSharpAttribute>? Attributes = null)
        : MethodSignatureBase(Name, Summary, Description, Modifiers, Parameters, Attributes ?? Array.Empty<CSharpAttribute>())
    {
        public FormattableString? FormattableDescription => Description is null ? (FormattableString?)null : $"{Description}";

        public MethodSignature WithAsync(bool isAsync)
            => isAsync && !Modifiers.HasFlag(Async)
                ? MakeAsync()
                : Modifiers.HasFlag(Async)
                    ? MakeSync()
                    : this;

        private MethodSignature MakeAsync()
        {
            if (Modifiers.HasFlag(Async) || ReturnType != null && TypeFactory.IsAsyncPageable(ReturnType))
            {
                return this;
            }

            if (ReturnType != null && TypeFactory.IsPageable(ReturnType))
            {
                return this with
                {
                    Name = Name + "Async",
                    ReturnType = new CSharpType(typeof(AsyncPageable<>), ReturnType.Arguments)
                };
            }

            if (ReturnType != null && TypeFactory.IsIEnumerableOfT(ReturnType))
            {
                return this with
                {
                    Name = Name + "Async",
                    Modifiers = Modifiers | Async,
                    ReturnType = new CSharpType(typeof(IAsyncEnumerable<>), ReturnType.Arguments),
                    Parameters = Parameters.Append(KnownParameters.EnumeratorCancellationTokenParameter).ToArray()
                };
            }

            return this with
            {
                Name = Name + "Async",
                Modifiers = Modifiers | Async,
                ReturnType = ReturnType != null
                    ? TypeFactory.IsOperationOfPageable(ReturnType)
                        ? new CSharpType(typeof(Task<>), new CSharpType(typeof(Operation<>), new CSharpType(typeof(AsyncPageable<>), ReturnType.Arguments[0].Arguments[0])))
                        : new CSharpType(typeof(Task<>), ReturnType)
                    : typeof(Task)
            };
        }

        private MethodSignature MakeSync()
        {
            if (!Modifiers.HasFlag(Async) || ReturnType != null && TypeFactory.IsPageable(ReturnType))
            {
                return this;
            }

            if (ReturnType != null && TypeFactory.IsAsyncPageable(ReturnType))
            {
                return this with
                {
                    Name = Name[..^5],
                    ReturnType = new CSharpType(typeof(Pageable<>), ReturnType.Arguments)
                };
            }

            if (ReturnType != null && TypeFactory.IsIAsyncEnumerableOfT(ReturnType))
            {
                return this with
                {
                    Name = Name[..^5],
                    Modifiers = Modifiers ^ Async,
                    ReturnType = new CSharpType(typeof(IEnumerable<>), ReturnType.Arguments),
                    Parameters = Parameters.Where(p => p != KnownParameters.EnumeratorCancellationTokenParameter).ToArray()
                };
            }

            return this with
            {
                Name = Name[..^5],
                Modifiers = Modifiers ^ Async,
                ReturnType = ReturnType?.Arguments.Length == 1
                    ? TypeFactory.IsOperationOfAsyncPageable(ReturnType.Arguments[0])
                        ? new CSharpType(typeof(Operation<>), new CSharpType(typeof(Pageable<>), ReturnType.Arguments[0].Arguments[0].Arguments[0]))
                        : ReturnType.Arguments[0]
                    : null
            };
        }
    }

    internal record MethodBody(IReadOnlyList<MethodBodyBlock> Blocks);
    internal record MethodBodyBlock;
    internal record ArgumentValidationBlock : MethodBodyBlock;
    internal record TryCatchFinallyBlock(MethodBodyBlock Try, MethodBodyBlock? Catch, MethodBodyBlock? Finally) : MethodBodyBlock;
    internal record MethodBodySingleLine;
    internal record DeclareVariableLine(CSharpType Type, CodeWriterDeclaration Name, InlineableExpression Value);

    internal record InlineableExpression;

    internal record DefaultValueExpression(CSharpType Type) : InlineableExpression;

    internal record ParameterReference(Parameter Parameter) : InlineableExpression;
    internal record VariableReference(CodeWriterDeclaration Name) : InlineableExpression;
    internal record MethodCallExpression(CSharpType OwningType, string Name, IReadOnlyList<InlineableExpression> Arguments, bool CallAsExtension) : InlineableExpression;

    internal record OneLineLocalFunction(MethodSignature Signature, InlineableExpression Value);
}
