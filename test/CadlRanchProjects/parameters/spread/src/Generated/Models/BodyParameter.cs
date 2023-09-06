// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Parameters.Spread.Models
{
    /// <summary> This is a simple model. </summary>
    public partial class BodyParameter
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of BodyParameter. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public BodyParameter(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Initializes a new instance of BodyParameter. </summary>
        /// <param name="name"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal BodyParameter(string name, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="BodyParameter"/> for deserialization. </summary>
        internal BodyParameter()
        {
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
