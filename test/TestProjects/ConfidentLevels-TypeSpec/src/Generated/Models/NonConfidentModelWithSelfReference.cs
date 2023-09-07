// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using Azure.Core;

namespace ConfidentLevelsInTsp.Models
{
    /// <summary> Non-confident model that contains self reference. </summary>
    internal partial class NonConfidentModelWithSelfReference
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of NonConfidentModelWithSelfReference. </summary>
        /// <param name="name"> The name. </param>
        /// <param name="selfReference"> The self reference. </param>
        /// <param name="unionProperty"> The non-confident part. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="selfReference"/> or <paramref name="unionProperty"/> is null. </exception>
        public NonConfidentModelWithSelfReference(string name, IEnumerable<NonConfidentModelWithSelfReference> selfReference, object unionProperty)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(selfReference, nameof(selfReference));
            Argument.AssertNotNull(unionProperty, nameof(unionProperty));

            Name = name;
            SelfReference = selfReference.ToList();
            UnionProperty = unionProperty;
        }

        /// <summary> Initializes a new instance of NonConfidentModelWithSelfReference. </summary>
        /// <param name="name"> The name. </param>
        /// <param name="selfReference"> The self reference. </param>
        /// <param name="unionProperty"> The non-confident part. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal NonConfidentModelWithSelfReference(string name, IList<NonConfidentModelWithSelfReference> selfReference, object unionProperty, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            SelfReference = selfReference;
            UnionProperty = unionProperty;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="NonConfidentModelWithSelfReference"/> for deserialization. </summary>
        internal NonConfidentModelWithSelfReference()
        {
        }

        /// <summary> The name. </summary>
        public string Name { get; }
        /// <summary> The self reference. </summary>
        public IList<NonConfidentModelWithSelfReference> SelfReference { get; }
        /// <summary> The non-confident part. </summary>
        public object UnionProperty { get; }
    }
}
