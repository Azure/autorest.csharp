// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Generation.Types
{
    internal sealed class FrameworkType : CSharpType
    {
        public FrameworkType(Type type) : this(
            type.IsGenericType ? type.GetGenericTypeDefinition() : type,
            type.IsGenericType ? type.GetGenericArguments().Select(p => new FrameworkType(p)).ToArray() : Array.Empty<CSharpType>())
        {
        }

        public FrameworkType(Type type, bool isNullable) : this(
            type.IsGenericType ? type.GetGenericTypeDefinition() : type,
            isNullable,
            type.IsGenericType ? type.GetGenericArguments().Select(p => new FrameworkType(p)).ToArray() : Array.Empty<CSharpType>())
        {
        }

        public FrameworkType(Type type, params CSharpType[] arguments) : this(type, false, arguments as IReadOnlyList<CSharpType>)
        { }

        public FrameworkType(Type type, IReadOnlyList<CSharpType> arguments) : this(type, false, arguments)
        { }

        public FrameworkType(Type type, bool isNullable, params CSharpType[] arguments) : this(type, isNullable, arguments as IReadOnlyList<CSharpType>)
        {
        }

        public FrameworkType(Type type, bool isNullable, IReadOnlyList<CSharpType> arguments)
            : base(@namespace: type.Namespace!,
                  name: type.IsGenericType ? type.Name.Substring(0, type.Name.IndexOf('`')) : type.Name,
                  isValueType: type.IsValueType,
                  isEnum: type.IsEnum,
                  isPublic: type.IsPublic && arguments.All(t => t.IsPublic),
                  arguments: arguments,
                  isNullable: isNullable,
                  serializeAs: null)
        {
            Debug.Assert(type.Namespace != null, "type.Namespace != null");
            Debug.Assert(type.IsGenericTypeDefinition || arguments.Count == 0, "arguments can be added only to the generic type definition.");

            Type = type;
        }

        public Type Type { get; }

        protected override bool Equals(CSharpType otherType, bool ignoreNullable)
        {
            if (otherType is not FrameworkType other)
            {
                return false;
            }

            return Type == other.Type &&
                Arguments.SequenceEqual(other.Arguments) &&
                (ignoreNullable || IsNullable == other.IsNullable);
        }

        public override bool Equals(Type type) =>
            type.IsGenericType ? type.GetGenericTypeDefinition() == Type && ArgumentsEquals(type.GetGenericArguments()) : type == Type;

        private bool ArgumentsEquals(IReadOnlyList<Type> genericArguments)
        {
            if (Arguments.Count != genericArguments.Count)
            {
                return false;
            }

            for (int i = 0; i < Arguments.Count; i++)
            {
                if (!Arguments[i].Equals(genericArguments[i]))
                {
                    return false;
                }
            }

            return true;
        }

        protected override int BuildHashCode()
        {
            var arguments = new HashCode();
            foreach (var arg in Arguments)
            {
                arguments.Add(arg);
            }
            return HashCode.Combine(Type, arguments.ToHashCode(), IsNullable);
        }

        public override CSharpType GetGenericTypeDefinition() => new FrameworkType(Type, IsNullable);

        public override CSharpType WithNullable(bool isNullable) =>
            isNullable == IsNullable ? this : new FrameworkType(Type, isNullable, Arguments);

        public override bool TryGetCSharpFriendlyName([MaybeNullWhen(false)] out string name)
        {
            name = Type switch
            {
                null => null,
                var t when t.IsGenericParameter => t.Name,
                var t when t == typeof(bool) => "bool",
                var t when t == typeof(byte) => "byte",
                var t when t == typeof(sbyte) => "sbyte",
                var t when t == typeof(short) => "short",
                var t when t == typeof(ushort) => "ushort",
                var t when t == typeof(int) => "int",
                var t when t == typeof(uint) => "uint",
                var t when t == typeof(long) => "long",
                var t when t == typeof(ulong) => "ulong",
                var t when t == typeof(char) => "char",
                var t when t == typeof(double) => "double",
                var t when t == typeof(float) => "float",
                var t when t == typeof(object) => "object",
                var t when t == typeof(decimal) => "decimal",
                var t when t == typeof(string) => "string",
                _ => null
            };

            return name != null;
        }
    }
}
