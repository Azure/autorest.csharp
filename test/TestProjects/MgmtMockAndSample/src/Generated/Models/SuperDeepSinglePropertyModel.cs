// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtMockAndSample.Models
{
    /// <summary> This is a single property of string. </summary>
    internal partial class SuperDeepSinglePropertyModel
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="SuperDeepSinglePropertyModel"/>. </summary>
        public SuperDeepSinglePropertyModel()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SuperDeepSinglePropertyModel"/>. </summary>
        /// <param name="super"> This is a single property of string. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal SuperDeepSinglePropertyModel(VeryDeepSinglePropertyModel super, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Super = super;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> This is a single property of string. </summary>
        internal VeryDeepSinglePropertyModel Super { get; set; }
        /// <summary> This is a string property. </summary>
        public string DeepSomething
        {
            get => Super is null ? default : Super.DeepSomething;
            set
            {
                if (Super is null)
                    Super = new VeryDeepSinglePropertyModel();
                Super.DeepSomething = value;
            }
        }
    }
}
