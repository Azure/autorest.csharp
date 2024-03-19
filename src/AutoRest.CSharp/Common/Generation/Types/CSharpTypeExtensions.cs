// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoRest.CSharp.Common.Input;
using AutoRest.CSharp.Output.Models.Shared;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Generation.Types
{
    internal static class CSharpTypeExtensions
    {
        /// <summary>
        /// Method checks if object of "<c>from</c>" type can be converted to "<c>to</c>" type by calling `ToList` extension method.
        /// It returns true if "<c>from</c>" is <see cref="IEnumerable{T}"/> and "<c>to</c>" is <see cref="IReadOnlyList{T}"/> or <see cref="IList{T}"/>.
        /// </summary>
        public static bool RequiresToList(this CSharpType from, CSharpType to)
        {
            if (!to.IsFrameworkType || !from.IsFrameworkType || from.FrameworkType != typeof(IEnumerable<>))
            {
                return false;
            }

            return to.FrameworkType == typeof(IReadOnlyList<>) || to.FrameworkType == typeof(IList<>);
        }

        public static CSharpType GetImplementationType(this CSharpType type)
            => type switch
            {
                { IsReadOnlyMemory: true } => new CSharpType(type.Arguments[0].FrameworkType.MakeArrayType()),
                { IsList: true } => new CSharpType(typeof(List<>), type.Arguments),
                { IsDictionary: true } => new CSharpType(typeof(Dictionary<,>), type.Arguments),
                _ => type
            };

        public static CSharpType GetPropertyImplementationType(this CSharpType type)
            => type switch
            {
                { IsReadOnlyMemory: true } => new CSharpType(typeof(ReadOnlyMemory<>), type.Arguments),
                { IsList: true } => new CSharpType(ChangeTrackingListProvider.Instance, type.Arguments),
                { IsDictionary: true } => new CSharpType(ChangeTrackingDictionaryProvider.Instance, type.Arguments),
                _ => type
            };

        public static CSharpType GetInputType(this CSharpType type)
            => type switch
            {
                { IsReadOnlyMemory: true } => new CSharpType(typeof(ReadOnlyMemory<>), isNullable: type.IsNullable, type.Arguments),
                { IsList: true } => new CSharpType(typeof(IEnumerable<>), isNullable: type.IsNullable, type.Arguments),
                _ => type
            };

        public static CSharpType GetOutputType(this CSharpType type)
            => type switch
            {
                { IsReadOnlyMemory: true } => new CSharpType(typeof(ReadOnlyMemory<>), type.IsNullable, type.Arguments),
                { IsList: true } => new CSharpType(typeof(IReadOnlyList<>), type.IsNullable, type.Arguments),
                { IsDictionary: true } => new CSharpType(typeof(IReadOnlyDictionary<,>), type.IsNullable, type.Arguments),
                _ => type
            };

        public static bool CanBeInitializedInline(this CSharpType type, Constant? defaultValue)
        {
            Debug.Assert(defaultValue.HasValue);

            if (!type.Equals(defaultValue.Value.Type) && !CanBeInitializedInline(defaultValue.Value.Type, defaultValue))
            {
                return false;
            }

            if (type.Equals(typeof(string)))
            {
                return true;
            }

            if (type is { IsFrameworkType: false, Implementation: EnumType { IsExtensible: true } } && defaultValue.Value.Value != null)
            {
                return defaultValue.Value.IsNewInstanceSentinel;
            }

            return type.IsValueType || defaultValue.Value.Value == null;
        }

        public static CSharpType GetElementType(this CSharpType type)
            => type switch
            {
                { IsFrameworkType: true, FrameworkType: { IsArray: true } arrayType } => new CSharpType(arrayType.GetElementType()!),
                { IsReadOnlyMemory: true } or { IsList: true } => type.Arguments[0],
                { IsDictionary: true } => type.Arguments[1],
                _ => throw new NotSupportedException(type.Name)
            };
    }
}
