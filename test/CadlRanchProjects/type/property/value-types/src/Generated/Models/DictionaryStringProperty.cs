// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with dictionary string properties. </summary>
    public partial class DictionaryStringProperty
    {
        /// <summary> Initializes a new instance of DictionaryStringProperty. </summary>
        /// <param name="property"> Property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="property"/> is null. </exception>
        public DictionaryStringProperty(IDictionary<string, string> property)
        {
            Argument.AssertNotNull(property, nameof(property));

            Property = property;
        }

        /// <summary> Property. </summary>
        public IDictionary<string, string> Property { get; }
    }
}
