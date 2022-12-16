// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Models.Property.Types.Models
{
    /// <summary> Model with extensible enum properties. </summary>
    public partial class ExtensibleEnumProperty
    {
        /// <summary> Initializes a new instance of ExtensibleEnumProperty. </summary>
        /// <param name="property"></param>
        public ExtensibleEnumProperty(InnerEnum property)
        {
            Property = property;
        }

        /// <summary> Gets or sets the property. </summary>
        public InnerEnum Property { get; set; }
    }
}
