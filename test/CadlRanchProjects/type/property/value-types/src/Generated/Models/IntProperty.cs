// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace _Type.Property.ValueTypes.Models
{
    /// <summary> Model with a int property. </summary>
    public partial class IntProperty
    {
        /// <summary> Initializes a new instance of IntProperty. </summary>
        /// <param name="property"> Property. </param>
        public IntProperty(int property)
        {
            Property = property;
        }

        /// <summary> Property. </summary>
        public int Property { get; set; }
    }
}
