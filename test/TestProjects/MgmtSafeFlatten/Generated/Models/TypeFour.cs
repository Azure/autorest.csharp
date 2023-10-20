// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtSafeFlatten.Models
{
    /// <summary> The TypeFour. </summary>
    internal partial class TypeFour
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="TypeFour"/>. </summary>
        internal TypeFour()
        {
        }

        /// <summary> Initializes a new instance of <see cref="TypeFour"/>. </summary>
        /// <param name="myType"> The details of the type. </param>
        /// <param name="properties"> The single value prop. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal TypeFour(string myType, LayerOneProperties properties, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            MyType = myType;
            Properties = properties;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> The details of the type. </summary>
        public string MyType { get; }
        /// <summary> The single value prop. </summary>
        internal LayerOneProperties Properties { get; }
        /// <summary> The id of layer one. </summary>
        public string LayerOneUniqueId
        {
            get => Properties?.UniqueId;
        }
    }
}
