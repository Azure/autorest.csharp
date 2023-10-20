// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtMockAndSample.Models
{
    /// <summary> This is a single property of string. </summary>
    internal partial class VeryDeepSinglePropertyModel
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="VeryDeepSinglePropertyModel"/>. </summary>
        public VeryDeepSinglePropertyModel()
        {
        }

        /// <summary> Initializes a new instance of <see cref="VeryDeepSinglePropertyModel"/>. </summary>
        /// <param name="very"> This is a single property of string. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal VeryDeepSinglePropertyModel(DeepSinglePropertyModel very, IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Very = very;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> This is a single property of string. </summary>
        internal DeepSinglePropertyModel Very { get; set; }
        /// <summary> This is a string property. </summary>
        public string DeepSomething
        {
            get => Very is null ? default : Very.DeepSomething;
            set
            {
                if (Very is null)
                    Very = new DeepSinglePropertyModel();
                Very.DeepSomething = value;
            }
        }
    }
}
