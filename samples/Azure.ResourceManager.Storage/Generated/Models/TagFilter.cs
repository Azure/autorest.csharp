// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Blob index tag based filtering for blob objects. </summary>
    public partial class TagFilter
    {
        /// <summary> Initializes a new instance of TagFilter. </summary>
        /// <param name="name"> This is the filter tag name, it can have 1 - 128 characters. </param>
        /// <param name="op"> This is the comparison operator which is used for object comparison and filtering. Only == (equality operator) is currently supported. </param>
        /// <param name="value"> This is the filter tag value field used for tag based filtering, it can have 0 - 256 characters. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="op"/> or <paramref name="value"/> is null. </exception>
        public TagFilter(string name, string op, string value)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(op, nameof(op));
            Argument.AssertNotNull(value, nameof(value));

            Name = name;
            Op = op;
            Value = value;
        }

        /// <summary> This is the filter tag name, it can have 1 - 128 characters. </summary>
        public string Name { get; set; }
        /// <summary> This is the comparison operator which is used for object comparison and filtering. Only == (equality operator) is currently supported. </summary>
        public string Op { get; set; }
        /// <summary> This is the filter tag value field used for tag based filtering, it can have 0 - 256 characters. </summary>
        public string Value { get; set; }
    }
}
