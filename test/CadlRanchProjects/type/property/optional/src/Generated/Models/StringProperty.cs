// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace _Type.Property.Optional.Models
{
    /// <summary> Template type for testing models with optional property. Pass in the type of the property you are looking for. </summary>
    public partial class StringProperty
    {
        /// <summary> Initializes a new instance of StringProperty. </summary>
        public StringProperty()
        {
        }

        /// <summary> Initializes a new instance of StringProperty. </summary>
        /// <param name="property"> Property. </param>
        internal StringProperty(string property)
        {
            Property = property;
        }

        /// <summary> Property. </summary>
        public string Property { get; set; }
    }
}
