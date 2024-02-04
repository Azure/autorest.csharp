// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Input.Source;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;
using Azure;
using Response = Azure.Response;

namespace AutoRest.CSharp.Generation.Types
{
    internal class CSharpType
    {
        private readonly TypeProvider? _implementation;
        private readonly Type? _type;

        public CSharpType(Type type) : this(
            type,
            type.IsGenericType ? type.GetGenericArguments().Select(p => new CSharpType(p)).ToArray() : Array.Empty<CSharpType>())
        {
        }

        public CSharpType(Type type, bool isNullable) : this(
            type,
            isNullable,
            type.IsGenericType ? type.GetGenericArguments().Select(p => new CSharpType(p)).ToArray() : Array.Empty<CSharpType>())
        {
        }

        public CSharpType(Type type, params CSharpType[] arguments) : this(type, false, arguments as IReadOnlyList<CSharpType>)
        { }

        public CSharpType(Type type, IReadOnlyList<CSharpType> arguments) : this(type, false, arguments)
        { }

        public CSharpType(Type type, bool isNullable, params CSharpType[] arguments) : this(type, isNullable, arguments as IReadOnlyList<CSharpType>)
        {
        }

        public CSharpType(Type type, bool isNullable, IReadOnlyList<CSharpType> arguments)
        {
            // here we ensure the framework type is always the open generic type, aka List<>, not List<int> or List<string> with concrete generic arguments
            type = type.IsGenericType ? type.GetGenericTypeDefinition() : type;
            Debug.Assert(type.Namespace != null, "type.Namespace != null");
            ValidateArguments(type, arguments);
            _type = type;

            Namespace = type.Namespace;
            Name = type.IsGenericType ? type.Name.Substring(0, type.Name.IndexOf('`')) : type.Name;
            IsNullable = isNullable;
            Arguments = arguments;
            IsValueType = type.IsValueType;
            IsEnum = type.IsEnum;
            IsPublic = type.IsPublic && arguments.All(t => t.IsPublic);

            #region Assign the attributes of this type
            IsIEnumerable = type == typeof(IEnumerable);
            IsIEnumerableOfT = type == typeof(IEnumerable<>);
            IsIAsyncEnumerableOfT = type == typeof(IAsyncEnumerable<>);
            IsReadOnlyDictionary = type == typeof(IReadOnlyDictionary<,>);
            IsReadWriteDictionary = type == typeof(IDictionary<,>);
            IsDictionary = IsReadOnlyDictionary || IsReadWriteDictionary;
            IsReadOnlyMemory = type == typeof(ReadOnlyMemory<>);
            IsReadWriteList = type == typeof(IList<>) || type == typeof(ICollection<>) || type == typeof(List<>);
            IsReadOnlyList = type == typeof(IEnumerable<>) || type == typeof(IReadOnlyList<>);
            IsList = IsReadOnlyList || IsReadWriteList || IsReadOnlyMemory;
            IsCollection = IsDictionary || IsList;
            IsArray = type.IsArray;

            IsTask = type == typeof(Task);
            IsTaskOfT = type == typeof(Task<>);
            // TODO -- these are azure-specific. We might need to generalize these using ApiTypes
            IsResponse = type == typeof(Response);
            IsResponseOfT = type == typeof(Response<>);
            IsPageable = type == typeof(Pageable<>);
            IsAsyncPageable = type == typeof(AsyncPageable<>);
            IsOperation = type == typeof(Operation);
            IsOperationOfT = type == typeof(Operation<>);
            IsOperationOfAsyncPageable = IsOperationOfT && arguments.Count == 1 && arguments[0].IsAsyncPageable;
            IsOperationOfPageable = IsOperationOfT && arguments.Count == 1 && arguments[0].IsPageable;
            #endregion
        }

        [Conditional("DEBUG")]
        private static void ValidateArguments(Type type, IReadOnlyList<CSharpType> arguments)
        {
            if (type.IsGenericTypeDefinition)
            {
                Debug.Assert(arguments.Count > 0, "arguments can be added only to the generic type definition.");
                Debug.Assert(arguments.Count == type.GetGenericArguments().Length, $"the count of arguments given ({string.Join(", ", arguments.Select(a => a.ToString()))}) does not match the arguments in the definition {type}");
            }
        }

        public CSharpType(TypeProvider implementation, bool isNullable = false)
        {
            _implementation = implementation;
            Namespace = implementation.Declaration.Namespace;
            Name = implementation.Declaration.Name;
            IsValueType = implementation.IsValueType;
            IsEnum = implementation.IsEnum;
            IsNullable = isNullable;
            Arguments = Array.Empty<CSharpType>(); // currently we do not have generic TypeProviders
            SerializeAs = _implementation?.SerializeAs;
            IsPublic = implementation.Declaration.Accessibility == "public" && Arguments.All(t => t.IsPublic);
        }

        public virtual string Namespace { get; }
        public virtual string Name { get; }
        public bool IsValueType { get; }
        public bool IsEnum { get; }
        public bool IsLiteral => Literal is not null;
        public Constant? Literal { get; private init; }
        public bool IsUnion => UnionItemTypes.Count > 0;
        public IReadOnlyList<CSharpType> UnionItemTypes { get; private init; } = Array.Empty<CSharpType>();
        public bool IsPublic { get; }
        public IReadOnlyList<CSharpType> Arguments { get; } = Array.Empty<CSharpType>();
        public bool IsFrameworkType => _type != null;
        public Type FrameworkType => _type ?? throw new InvalidOperationException("Not a framework type");
        public TypeProvider Implementation => _implementation ?? throw new InvalidOperationException($"Not implemented type: '{Namespace}.{Name}'");
        public bool IsNullable { get; }

        public Type? SerializeAs { get; init; }

        #region Attributes of the type
        public bool IsArray { get; }
        public bool IsCollection { get; }
        public bool IsIEnumerable { get; }
        public bool IsIEnumerableOfT { get; }
        public bool IsIAsyncEnumerableOfT { get; }

        public bool IsDictionary { get; }
        public bool IsReadOnlyDictionary { get; }
        public bool IsReadWriteDictionary { get; }

        public bool IsList { get; }
        public bool IsReadOnlyMemory { get; }
        public bool IsReadOnlyList { get; }
        public bool IsReadWriteList { get; }

        public bool IsTask { get; }
        public bool IsTaskOfT { get; }
        public bool IsResponse { get; }
        public bool IsResponseOfT { get; }
        public bool IsPageable { get; }
        public bool IsAsyncPageable { get; }
        public bool IsOperation { get; }
        public bool IsOperationOfT { get; }
        public bool IsOperationOfAsyncPageable { get; }
        public bool IsOperationOfPageable { get; }
        #endregion

        protected bool Equals(CSharpType other, bool ignoreNullable)
            => Equals(_implementation, other._implementation) &&
               _type == other._type &&
               Arguments.SequenceEqual(other.Arguments) &&
               (ignoreNullable || IsNullable == other.IsNullable);

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return obj is CSharpType csType && Equals(csType, ignoreNullable: false);
        }

        public bool EqualsIgnoreNullable(CSharpType other) => Equals(other, ignoreNullable: true);

        public bool Equals(Type type) =>
            IsFrameworkType && (type.IsGenericType ? type.GetGenericTypeDefinition() == FrameworkType && ArgumentsEquals(type.GetGenericArguments()) : type == FrameworkType);

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

        private int? _hashCode;

        public override int GetHashCode()
        {
            // we cache the hashcode since `CSharpType` is meant to be immuttable.
            if (_hashCode != null)
                return _hashCode.Value;

            var hashCode = new HashCode();
            foreach (var arg in Arguments)
            {
                hashCode.Add(arg);
            }
            _hashCode = HashCode.Combine(_implementation, _type, hashCode.ToHashCode(), IsNullable);

            return _hashCode.Value;
        }

        public CSharpType GetGenericTypeDefinition()
            => _type is null
                ? throw new NotSupportedException($"{nameof(TypeProvider)} doesn't support generics.")
                : new(_type, IsNullable);

        public bool IsGenericType => Arguments.Count > 0;

        public virtual CSharpType WithNullable(bool isNullable) => // make it virtual to ensure this is mockable
            isNullable == IsNullable ? this : IsFrameworkType
                ? new CSharpType(FrameworkType, isNullable, Arguments)
                : new CSharpType(Implementation, isNullable);

        public static implicit operator CSharpType(Type type) => new CSharpType(type);

        public override string ToString()
        {
            return new CodeWriter().Append($"{this}").ToString(false);
        }

        public bool TryGetCSharpFriendlyName([MaybeNullWhen(false)] out string name)
        {
            name = _type switch
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

        internal static CSharpType FromSystemType(Type type, string defaultNamespace, SourceInputModel? sourceInputModel, IEnumerable<ObjectTypeProperty>? backingProperties = null)
        {
            var systemObjectType = SystemObjectType.Create(type, defaultNamespace, sourceInputModel, backingProperties);
            return systemObjectType.Type;
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
            if (type.IsFrameworkType)
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

                type = new CSharpType(type.FrameworkType, type.IsNullable)
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
            return new CSharpType(typeof(BinaryData), isNullable)
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
