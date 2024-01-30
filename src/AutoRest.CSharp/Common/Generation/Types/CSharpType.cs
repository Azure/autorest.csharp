// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Microsoft.CodeAnalysis;

namespace AutoRest.CSharp.Generation.Types
{
    internal abstract class CSharpType
    {
        protected CSharpType(string @namespace, string name, bool isValueType, bool isEnum, bool isPublic, IReadOnlyList<CSharpType> arguments, bool isNullable, Type? serializeAs)
        {
            Namespace = @namespace;
            Name = name;
            IsValueType = isValueType;
            IsEnum = isEnum;
            IsPublic = isPublic;
            Arguments = arguments;
            IsNullable = isNullable;
            SerializeAs = serializeAs;
        }

        public string Namespace { get; }
        public string Name { get; }
        public bool IsValueType { get; }
        public bool IsEnum { get; }
        public bool IsLiteral => Literal is not null;
        public Constant? Literal { get; private init; }
        public bool IsUnion => UnionItemTypes.Count > 0;
        public IReadOnlyList<CSharpType> UnionItemTypes { get; private init; } = Array.Empty<CSharpType>();
        public bool IsPublic { get; }
        public IReadOnlyList<CSharpType> Arguments { get; } = Array.Empty<CSharpType>();
        public bool IsGenericType => Arguments.Count > 0;
        public bool IsNullable { get; }

        public Type? SerializeAs { get; init; }

        protected abstract bool Equals(CSharpType other, bool ignoreNullable);

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is CSharpType csType && Equals(csType, ignoreNullable: false);
        }

        public bool EqualsIgnoreNullable(CSharpType other) => Equals(other, ignoreNullable: true);

        public abstract bool Equals(Type type);

        private int? _hashCode;

        public override int GetHashCode()
        {
            // we cache the hashcode since `CSharpType` is meant to be immuttable.
            return _hashCode ??= BuildHashCode();
        }

        protected abstract int BuildHashCode();

        public abstract CSharpType GetGenericTypeDefinition();

        public abstract CSharpType WithNullable(bool isNullable);

        public static implicit operator CSharpType(Type type) => new FrameworkType(type);

        public override string ToString()
        {
            return new CodeWriter().Append($"{this}").ToString(false);
        }

        public abstract bool TryGetCSharpFriendlyName([MaybeNullWhen(false)] out string name);

        internal static CSharpType FromSystemType(Type type, string defaultNamespace, SourceInputModel? sourceInputModel, IEnumerable<ObjectTypeProperty>? backingProperties = null)
        {
            var genericTypes = type.GetGenericArguments().Select(t => new FrameworkType(t));
            var systemObjectType = SystemObjectType.Create(type, defaultNamespace, sourceInputModel, backingProperties);
            // TODO -- why we do not just return systemObjectType.Type here? because of the generic types?
            return new TypeProviderType(
                systemObjectType,
                type.Namespace ?? defaultNamespace,
                systemObjectType.Declaration.Name,
                type.IsValueType,
                type.IsEnum,
                false,
                genericTypes.ToArray());
        }

        /// <summary>
        /// This function is used to create a new CSharpType instance with a literal value.
        /// If the type is a framework type, the CSharpType will be created with the literal value Constant
        /// object.
        /// </summary>
        /// <param name="type">The original type to create a new CSharpType instance from.</param>
        /// <param name="literalValue">The literal value of the type, if any.</param>
        /// <returns>An instance of CSharpType with a literal value property.</returns>
        internal static CSharpType FromLiteral(CSharpType type, object literalValue)
        {
            if (type is FrameworkType frameworkType)
            {
                Constant? literal;
                try
                {
                    literal = new Constant(literalValue, type);
                }
                catch
                {
                    literal = null;
                }

                type = new FrameworkType(frameworkType.Type, type.IsNullable)
                {
                    Literal = literal
                };
            }

            return type;
        }

        /// <summary>
        /// Constructs a CSharpType that represents a union type.
        /// </summary>
        /// <param name="unionItemTypes">The list of union item types.</param>
        /// <param name="isNullable">Flag used to determine if a type is nullable.</param>
        /// <returns></returns>
        public static CSharpType FromUnion(IReadOnlyList<CSharpType> unionItemTypes, bool isNullable)
        {
            return new FrameworkType(typeof(BinaryData), isNullable)
            {
                UnionItemTypes = unionItemTypes
            };
        }

        internal static CSharpType FromSystemType(BuildContext context, Type type, IEnumerable<ObjectTypeProperty>? backingProperties = null)
            => FromSystemType(type, context.DefaultNamespace, context.SourceInputModel, backingProperties);

        /// <summary>
        /// Check whether two CSharpType instances equal or not
        /// This is not the same as left.Equals(right) because this function only checks the names
        /// </summary>
        /// <param name="left"></param>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool EqualsByName(CSharpType? other)
        {
            if (ReferenceEquals(this, other))
            {
                return true;
            }

            if (other is null)
            {
                return false;
            }

            if (Namespace != other.Namespace)
                return false;

            if (Name != other.Name)
                return false;

            if (Arguments.Count != other.Arguments.Count)
                return false;

            for (int i = 0; i < Arguments.Count; i++)
            {
                if (!Arguments[i].EqualsByName(other.Arguments[i]))
                    return false;
            }

            return true;
        }
    }
}
