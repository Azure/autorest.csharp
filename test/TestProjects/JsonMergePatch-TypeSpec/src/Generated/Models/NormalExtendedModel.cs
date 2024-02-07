// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace Payload.JsonMergePatch.Models
{
    /// <summary> The NormalExtendedModel. </summary>
    public partial class NormalExtendedModel : NormalBaseModel
    {
        /// <summary> Initializes a new instance of <see cref="NormalExtendedModel"/>. </summary>
        public NormalExtendedModel()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NormalExtendedModel"/>. </summary>
        /// <param name="normalValue"></param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="extendedValue"></param>
        internal NormalExtendedModel(string normalValue, IDictionary<string, BinaryData> serializedAdditionalRawData, string extendedValue) : base(normalValue, serializedAdditionalRawData)
        {
            ExtendedValue = extendedValue;
        }

        private string _extendedValue;
        private protected bool _extendedValueChanged;
        public string ExtendedValue
        {
            get => _extendedValue;
            set
            {
                _extendedValue = value;
                _extendedValueChanged = true;
            }
        }
    }
}
