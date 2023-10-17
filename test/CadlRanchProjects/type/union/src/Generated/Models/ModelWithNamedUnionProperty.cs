// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Union.Models
{
    /// <summary> The ModelWithNamedUnionProperty. </summary>
    internal partial class ModelWithNamedUnionProperty
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="ModelWithNamedUnionProperty"/>. </summary>
        /// <param name="namedUnion"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="namedUnion"/> is null. </exception>
        public ModelWithNamedUnionProperty(object namedUnion)
        {
            Argument.AssertNotNull(namedUnion, nameof(namedUnion));

            NamedUnion = namedUnion;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithNamedUnionProperty"/>. </summary>
        /// <param name="namedUnion"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal ModelWithNamedUnionProperty(object namedUnion, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            NamedUnion = namedUnion;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="ModelWithNamedUnionProperty"/> for deserialization. </summary>
        internal ModelWithNamedUnionProperty()
        {
        }

        /// <summary> Gets the named union. </summary>
        public object NamedUnion { get; }
    }
}
