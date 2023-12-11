// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Inheritance.Models
{
    /// <summary> The SomeProperties. </summary>
    public partial class SomeProperties
    {
        /// <summary> Initializes a new instance of <see cref="SomeProperties"/>. </summary>
        public SomeProperties()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SomeProperties"/>. </summary>
        /// <param name="someProperty"></param>
        /// <param name="someOtherProperty"></param>
        internal SomeProperties(string someProperty, string someOtherProperty)
        {
            SomeProperty = someProperty;
            SomeOtherProperty = someOtherProperty;
        }

        /// <summary> Gets or sets the some property. </summary>
        public string SomeProperty { get; set; }
        /// <summary> Gets or sets the some other property. </summary>
        public string SomeOtherProperty { get; set; }
    }
}
