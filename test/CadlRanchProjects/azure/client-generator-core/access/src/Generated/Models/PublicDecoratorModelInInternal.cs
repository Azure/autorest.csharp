// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Specs_.Azure.ClientGenerator.Core.Access.Models
{
    /// <summary> Used in an internal operation but with public decorator, should be generated and exported. </summary>
    public partial class PublicDecoratorModelInInternal
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="PublicDecoratorModelInInternal"/>. </summary>
        /// <param name="name"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        internal PublicDecoratorModelInInternal(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="PublicDecoratorModelInInternal"/>. </summary>
        /// <param name="name"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal PublicDecoratorModelInInternal(string name, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="PublicDecoratorModelInInternal"/> for deserialization. </summary>
        internal PublicDecoratorModelInInternal()
        {
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
