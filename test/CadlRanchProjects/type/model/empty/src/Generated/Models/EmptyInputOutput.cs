// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Model.Empty.Models
{
    /// <summary> Empty model used in both parameter and return type. </summary>
    public partial class EmptyInputOutput
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private IDictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="EmptyInputOutput"/>. </summary>
        public EmptyInputOutput()
        {
            _serializedAdditionalRawData = new ChangeTrackingDictionary<string, BinaryData>();
        }

        /// <summary> Initializes a new instance of <see cref="EmptyInputOutput"/>. </summary>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal EmptyInputOutput(IDictionary<string, BinaryData> serializedAdditionalRawData)
        {
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }
    }
}
