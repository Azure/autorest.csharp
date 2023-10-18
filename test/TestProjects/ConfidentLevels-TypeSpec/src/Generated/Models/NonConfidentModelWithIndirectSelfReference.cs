// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ConfidentLevelsInTsp.Models
{
    /// <summary> The model that contains self reference. </summary>
    public partial class NonConfidentModelWithIndirectSelfReference
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="NonConfidentModelWithIndirectSelfReference"/>. </summary>
        /// <param name="name"> The name. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public NonConfidentModelWithIndirectSelfReference(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Reference = new ChangeTrackingList<IndirectSelfReferenceModel>();
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="NonConfidentModelWithIndirectSelfReference"/>. </summary>
        /// <param name="name"> The name. </param>
        /// <param name="reference"> The self reference. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal NonConfidentModelWithIndirectSelfReference(string name, IList<IndirectSelfReferenceModel> reference, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Reference = reference;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="NonConfidentModelWithIndirectSelfReference"/> for deserialization. </summary>
        internal NonConfidentModelWithIndirectSelfReference()
        {
        }

        /// <summary> The name. </summary>
        public string Name { get; }
        /// <summary> The self reference. </summary>
        public IList<IndirectSelfReferenceModel> Reference { get; }
    }
}
