// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Buffers;
using System.Diagnostics;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Generation.Types
{
    internal class CSharpType
    {
        private readonly TypeProvider? _implementation;
        private readonly Type? _type;

        public CSharpType(Type type) : this(
            type.IsGenericType ? type.GetGenericTypeDefinition() : type,
            type.IsGenericType ? type.GetGenericArguments().Select(p => new CSharpType(p)).ToArray() : Array.Empty<CSharpType>())
        {
        }

        public CSharpType(Type type, params CSharpType[] arguments) : this(type, false, arguments)
        {
        }

        public CSharpType(Type type, bool isNullable, params CSharpType[] arguments)
        {
            Debug.Assert(type.Namespace != null, "type.Namespace != null");
            _type = type;

            Namespace = type.Namespace;
            Name = type.IsGenericType ? type.Name.Substring(0, type.Name.IndexOf('`')) : type.Name;
            IsNullable = isNullable;
            Arguments = arguments;
            IsValueType = type.IsValueType;
            IsPublic = type.IsPublic && arguments.All(t => t.IsPublic);
        }

        public CSharpType(TypeProvider implementation, string ns, string name, bool isValueType = false, bool isNullable = false, CSharpType[]? arguments = default)
        {
            _implementation = implementation;
            Name = name;
            IsValueType = isValueType;
            IsNullable = isNullable;
            Namespace = ns;
            if (arguments != null)
                Arguments = arguments;

            IsPublic = implementation.Declaration.Accessibility == "public"
                && Arguments.All(t => t.IsPublic);
        }

        public string Namespace { get; }
        public string Name { get; }
        public bool IsValueType { get; }
        public bool IsPublic { get; }
        public CSharpType[] Arguments { get; } = Array.Empty<CSharpType>();
        public bool IsFrameworkType => _type != null;
        public Type FrameworkType => _type ?? throw new InvalidOperationException("Not a framework type");
        public TypeProvider Implementation => _implementation ?? throw new InvalidOperationException("Not implemented type");
        public bool IsNullable { get; }

        protected bool Equals(CSharpType other)
        {
            return Equals(_implementation, other._implementation) && Equals(_type, other._type) && Arguments.SequenceEqual(other.Arguments);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CSharpType) obj);
        }

        public bool Equals(Type type)
        {
            return IsFrameworkType && type == FrameworkType;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(_implementation, _type, Arguments);
        }

        public CSharpType WithNullable(bool isNullable) => IsFrameworkType
            ? new CSharpType(FrameworkType, isNullable, Arguments)
            : new CSharpType(Implementation, Namespace, Name, IsValueType, isNullable);

        public static implicit operator CSharpType(Type type) => new CSharpType(type);

        public override string ToString()
        {
            return new CodeWriter().Append($"{this}").ToString(false);
        }

        internal static CSharpType FromSystemType(BuildContext context, Type type)
        {
            var genericTypes = type.GetGenericArguments().Select(t => new CSharpType(t));
            var systemObjectType = new SystemObjectType(type, context);
            return new CSharpType(
                systemObjectType,
                type.Namespace ?? context.DefaultNamespace,
                systemObjectType.Declaration.Name,
                false,
                false,
                genericTypes.ToArray());
        }
    }
}
