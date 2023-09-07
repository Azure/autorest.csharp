// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtLRO.Models
{
    /// <summary> The instance view of a resource. </summary>
    internal partial class BarProperties
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="BarProperties"/>. </summary>
        public BarProperties()
        {
        }

        /// <summary> Initializes a new instance of <see cref="BarProperties"/>. </summary>
        /// <param name="buzz"> Update Domain count. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal BarProperties(Guid? buzz, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Buzz = buzz;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Update Domain count. </summary>
        public Guid? Buzz { get; set; }
    }
}
