// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Inheritance.Models
{
    /// <summary> The SomeProperties. </summary>
    public partial class SomeProperties
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="SomeProperties"/>. </summary>
        public SomeProperties()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SomeProperties"/>. </summary>
        /// <param name="someProperty"></param>
        /// <param name="someOtherProperty"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SomeProperties(string someProperty, string someOtherProperty, Dictionary<string, BinaryData> rawData)
        {
            SomeProperty = someProperty;
            SomeOtherProperty = someOtherProperty;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the some property. </summary>
        public string SomeProperty { get; set; }
        /// <summary> Gets or sets the some other property. </summary>
        public string SomeOtherProperty { get; set; }
    }
}
