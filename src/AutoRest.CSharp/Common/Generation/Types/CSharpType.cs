// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
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

        public CSharpType(Type type, bool isNullable) : this(
            type.IsGenericType ? type.GetGenericTypeDefinition() : type,
            isNullable,
            type.IsGenericType ? type.GetGenericArguments().Select(p => new CSharpType(p)).ToArray() : Array.Empty<CSharpType>())
        {
        }

        public CSharpType(Type type, Type? serializeAs) : this(
            type.IsGenericType ? type.GetGenericTypeDefinition() : type,
            type.IsGenericType ? type.GetGenericArguments().Select(p => new CSharpType(p)).ToArray() : Array.Empty<CSharpType>())
        {
            SerializeAs = serializeAs;
        }

        public CSharpType(Type type, params CSharpType[] arguments) : this(type, false, arguments)
        {
        }

        public CSharpType(Type type, bool isNullable, params CSharpType[] arguments)
        {
            //flatten Nullable<int> into int with IsNullable true
            if (type.Equals(typeof(Nullable<>)) && arguments.Length == 1 && arguments[0].IsValueType)
            {
                type = arguments[0].FrameworkType;
                isNullable = true;
                arguments = Array.Empty<CSharpType>();
            }

            Debug.Assert(type.Namespace != null, "type.Namespace != null");
            Debug.Assert(type.IsGenericTypeDefinition || arguments.Length == 0, "arguments can be added only to the generic type definition.");

            _type = type;

            Namespace = type.Namespace;
            Name = type.IsGenericType ? type.Name.Substring(0, type.Name.IndexOf('`')) : type.Name;
            IsNullable = isNullable;
            Arguments = arguments;
            IsValueType = type.IsValueType;
            IsEnum = type.IsEnum;
            IsPublic = type.IsPublic && arguments.All(t => t.IsPublic);
        }

        public CSharpType(TypeProvider implementation, bool isValueType = false, bool isEnum = false, bool isNullable = false, CSharpType[]? arguments = default)
            : this(implementation, implementation.Declaration.Namespace, implementation.Declaration.Name, isValueType, isEnum, isNullable, arguments)
        {
        }

        public CSharpType(TypeProvider implementation, string ns, string name, bool isValueType = false, bool isEnum = false, bool isNullable = false, CSharpType[]? arguments = default)
        {
            _implementation = implementation;
            Name = name;
            IsValueType = isValueType;
            IsEnum = isEnum;
            IsNullable = isNullable;
            Namespace = ns;
            if (arguments != null)
                Arguments = arguments;
            SerializeAs = _implementation?.SerializeAs;
            IsPublic = implementation.Declaration.Accessibility == "public"
                && Arguments.All(t => t.IsPublic);
        }

        public string Namespace { get; }
        public string Name { get; }
        public bool IsValueType { get; }
        public bool IsEnum { get; }
        public bool IsPublic { get; }
        public CSharpType[] Arguments { get; } = Array.Empty<CSharpType>();
        public bool IsFrameworkType => _type != null;
        public Type FrameworkType => _type ?? throw new InvalidOperationException("Not a framework type");
        public TypeProvider Implementation => _implementation ?? throw new InvalidOperationException($"Not implemented type: '{Namespace}.{Name}'");
        public bool IsNullable { get; }

        public Type? SerializeAs { get; }

        public bool HasParent => IsFrameworkType ? false : Implementation is ObjectType objectType ? objectType.Inherits is not null : false;

        protected bool Equals(CSharpType other, bool ignoreNullable)
            => Equals(_implementation, other._implementation) &&
               _type == other._type &&
               Arguments.SequenceEqual(other.Arguments) &&
               (ignoreNullable || IsNullable == other.IsNullable);

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is CSharpType csType && Equals(csType, ignoreNullable: false);
        }

        public bool EqualsIgnoreNullable(CSharpType other) => Equals(other, ignoreNullable: true);

        public bool Equals(Type type) =>
            IsFrameworkType && (type.IsGenericType ? type.GetGenericTypeDefinition() == FrameworkType && ArgumentsEquals(type.GetGenericArguments()) : type == FrameworkType);

        private bool ArgumentsEquals(Type[] genericArguments)
        {
            if (Arguments.Length != genericArguments.Length)
            {
                return false;
            }

            for (int i = 0; i < Arguments.Length; i++)
            {
                if (!Arguments[i].Equals(genericArguments[i]))
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode() => HashCode.Combine(_implementation, _type, ((System.Collections.IStructuralEquatable)Arguments).GetHashCode(EqualityComparer<CSharpType>.Default));

        public bool IsGenericType => Arguments.Length > 0;

        public CSharpType WithNullable(bool isNullable) =>
            isNullable == IsNullable ? this : IsFrameworkType
                ? new CSharpType(FrameworkType, isNullable, Arguments)
                : new CSharpType(Implementation, Namespace, Name, IsValueType, IsEnum, isNullable);

        public static implicit operator CSharpType(Type type) => new CSharpType(type);

        public override string ToString()
        {
            return new CodeWriter().Append($"{this}").ToString(false);
        }

        internal static CSharpType FromSystemType(Type type, string defaultNamespace, SourceInputModel? sourceInputModel)
        {
            var genericTypes = type.GetGenericArguments().Select(t => new CSharpType(t));
            var systemObjectType = SystemObjectType.Create(type, defaultNamespace, sourceInputModel);
            // TODO -- why we do not just return systemObjectType.Type here? because of the generic types?
            return new CSharpType(
                systemObjectType,
                type.Namespace ?? defaultNamespace,
                systemObjectType.Declaration.Name,
                type.IsValueType,
                type.IsEnum,
                false,
                genericTypes.ToArray());
        }

        internal static CSharpType FromSystemType(BuildContext context, Type type)
            => FromSystemType(type, context.DefaultNamespace, context.SourceInputModel);

        public bool IsCollectionType()
        {
            if (!IsFrameworkType)
                return false;

            return FrameworkType.Equals(typeof(IList<>)) ||
                FrameworkType.Equals(typeof(IEnumerable<>)) ||
                FrameworkType == typeof(IReadOnlyList<>) ||
                FrameworkType.Equals(typeof(IDictionary<,>)) ||
                FrameworkType == typeof(IReadOnlyDictionary<,>);
        }

        public CSharpType GetNonNullable()
        {
            if (!IsNullable)
                return this;

            return new CSharpType(Implementation, Namespace, Name, IsValueType, IsEnum, false, Arguments);
        }

        public bool TryCast<T>([MaybeNullWhen(false)] out T provider) where T : TypeProvider
        {
            provider = null;
            if (this.IsFrameworkType)
                return false;

            provider = this.Implementation as T;
            return provider != null;
        }
    }
}
