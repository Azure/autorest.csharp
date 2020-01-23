// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace CognitiveSearch.Models
{
    internal static class EntityCategoryExtensions
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

        public static EntityCategory ToEntityCategory(this string value) => value switch
        {
            "location" => EntityCategory.Location,
            "organization" => EntityCategory.Organization,
            "person" => EntityCategory.Person,
            "quantity" => EntityCategory.Quantity,
            "datetime" => EntityCategory.Datetime,
            "url" => EntityCategory.Url,
            "email" => EntityCategory.Email,
            _ => throw new ArgumentOutOfRangeException(nameof(value), value, "Unknown EntityCategory value.")
        };
    }
}
