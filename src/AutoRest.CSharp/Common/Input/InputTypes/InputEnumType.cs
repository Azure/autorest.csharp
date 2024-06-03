// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;

namespace AutoRest.CSharp.Common.Input;

internal record InputEnumType(string Name, string? Namespace, string? Accessibility, string? Deprecated, string Description, InputModelTypeUsage Usage, InputPrimitiveType ValueType, IReadOnlyList<InputEnumTypeValue> Values, bool IsExtensible, bool IsNullable)
    : InputType(Name, IsNullable)
{
    public InputModelTypeUsage Usage { get; internal set; } = Usage;

    public static IEqualityComparer<InputEnumType> IgnoreNullabilityComparer { get; } = new IgnoreNullabilityComparerImplementation();

    private struct IgnoreNullabilityComparerImplementation : IEqualityComparer<InputEnumType>
    {
        public bool Equals(InputEnumType? x, InputEnumType? y)
        {
            if (x is null || y is null)
            {
                return ReferenceEquals(x, y);
            }

            if (x.GetType() != y.GetType())
            {
                return false;
            }

            return x.Name == y.Name
                   && x.Namespace == y.Namespace
                   && x.Accessibility == y.Accessibility
                   && x.Description == y.Description
                   && x.ValueType.Equals(y.ValueType)
                   && x.Values.SequenceEqual(y.Values)
                   && x.IsExtensible == y.IsExtensible;
        }

        public int GetHashCode(InputEnumType obj)
        {
            var hashCode = new HashCode();
            hashCode.Add(obj.Name);
            hashCode.Add(obj.Namespace);
            hashCode.Add(obj.Accessibility);
            hashCode.Add(obj.Description);
            hashCode.Add(obj.ValueType);
            hashCode.Add(obj.IsExtensible);
            foreach (var item in obj.Values)
            {
                hashCode.Add(item);
            }

            return hashCode.ToHashCode();
        }
    }
}
