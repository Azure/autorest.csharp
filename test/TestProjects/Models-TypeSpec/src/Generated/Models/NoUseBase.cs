// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace ModelsTypeSpec.Models
{
    /// <summary> Base model. </summary>
    public partial class NoUseBase
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of NoUseBase. </summary>
        /// <param name="baseModelProp"> base model property. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="baseModelProp"/> is null. </exception>
        internal NoUseBase(string baseModelProp)
        {
            Argument.AssertNotNull(baseModelProp, nameof(baseModelProp));

            BaseModelProp = baseModelProp;
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of NoUseBase. </summary>
        /// <param name="baseModelProp"> base model property. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal NoUseBase(string baseModelProp, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            BaseModelProp = baseModelProp;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> base model property. </summary>
        public string BaseModelProp { get; }
    }
}
