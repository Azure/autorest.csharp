// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace CognitiveSearch.Models
{
    internal static partial class EntityCategoryExtensions
    {
        public static string ToSerialString(this EntityCategory value) => value switch
        {
            EntityCategory.Location => "location",
            EntityCategory.Organization => "organization",
            EntityCategory.Person => "person",
            EntityCategory.Quantity => "quantity",
            EntityCategory.Datetime => "datetime",
            EntityCategory.Url => "url",
            EntityCategory.Email => "email",
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EntityCategory value.")
        };

        public static EntityCategory ToEntityCategory(this string value)
        {
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "location")) return EntityCategory.Location;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "organization")) return EntityCategory.Organization;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "person")) return EntityCategory.Person;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "quantity")) return EntityCategory.Quantity;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "datetime")) return EntityCategory.Datetime;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "url")) return EntityCategory.Url;
            if (StringComparer.OrdinalIgnoreCase.Equals(value, "email")) return EntityCategory.Email;
            throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EntityCategory value.");
        }
    }
}
