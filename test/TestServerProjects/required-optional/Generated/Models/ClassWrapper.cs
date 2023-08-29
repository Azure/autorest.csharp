// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace required_optional.Models
{
    /// <summary> The ClassWrapper. </summary>
    public partial class ClassWrapper
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::required_optional.Models.ClassWrapper
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public ClassWrapper(Product value)
        {
            Argument.AssertNotNull(value, nameof(value));

            Value = value;
        }

        /// <summary>
        /// Initializes a new instance of global::required_optional.Models.ClassWrapper
        ///
        /// </summary>
        /// <param name="value"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ClassWrapper(Product value, Dictionary<string, BinaryData> rawData)
        {
            Value = value;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="ClassWrapper"/> for deserialization. </summary>
        internal ClassWrapper()
        {
        }

        /// <summary> Gets the value. </summary>
        public Product Value { get; }
    }
}
