// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Generation.Types
{
    internal sealed class TypeProviderType : CSharpType
    {
        public TypeProviderType(TypeProvider implementation, bool isValueType = false, bool isEnum = false, bool isNullable = false, IReadOnlyList<CSharpType>? arguments = null)
            : this(implementation, implementation.Declaration.Namespace, implementation.Declaration.Name, isValueType, isEnum, isNullable, arguments)
        {
        }

        public TypeProviderType(TypeProvider implementation, string ns, string name, bool isValueType = false, bool isEnum = false, bool isNullable = false, IReadOnlyList<CSharpType>? arguments = null)
            : base(@namespace: ns,
                  name: name,
                  isValueType: isValueType,
                  isEnum: isEnum,
                  isPublic: implementation.Declaration.Accessibility == "public" && (arguments?.All(t => t.IsPublic) ?? true),
                  arguments: arguments ?? Array.Empty<CSharpType>(),
                  isNullable: isNullable,
                  serializeAs: implementation.SerializeAs)
        {
            TypeProvider = implementation;
        }

        public TypeProvider TypeProvider { get; }

        protected override bool Equals(CSharpType otherType, bool ignoreNullable)
        {
            if (otherType is not TypeProviderType other)
                return false;

            return Equals(TypeProvider, other.TypeProvider) &&
                Arguments.SequenceEqual(other.Arguments) &&
                (ignoreNullable || IsNullable == other.IsNullable);
        }

        public override bool Equals(Type type) => false;

        protected override int BuildHashCode()
        {
            var arguments = new HashCode();
            foreach (var arg in Arguments)
            {
                arguments.Add(arg);
            }
            return HashCode.Combine(TypeProvider, arguments.ToHashCode(), IsNullable);
        }

        public override CSharpType GetGenericTypeDefinition()
            => throw new NotSupportedException($"{nameof(TypeProviderType)} doesn't support generics.");

        public override CSharpType WithNullable(bool isNullable) =>
            isNullable == IsNullable ? this : new TypeProviderType(TypeProvider, Namespace, Name, IsValueType, IsEnum, isNullable);

        public override bool TryGetCSharpFriendlyName([MaybeNullWhen(false)] out string name)
        {
            name = null;
            return false;
        }
    }
}
