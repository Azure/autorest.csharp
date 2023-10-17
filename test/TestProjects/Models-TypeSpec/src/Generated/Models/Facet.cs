// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Facet. </summary>
    public partial class Facet
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Facet"/>. </summary>
        /// <param name="field"> A field to facet by, where the field is attributed as 'facetable'. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="field"/> is null. </exception>
        internal Facet(string field)
        {
            Argument.AssertNotNull(field, nameof(field));

            Field = field;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="Facet"/>. </summary>
        /// <param name="field"> A field to facet by, where the field is attributed as 'facetable'. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Facet(string field, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Field = field;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Facet"/> for deserialization. </summary>
        internal Facet()
        {
        }

        /// <summary> A field to facet by, where the field is attributed as 'facetable'. </summary>
        public string Field { get; }
    }
}
