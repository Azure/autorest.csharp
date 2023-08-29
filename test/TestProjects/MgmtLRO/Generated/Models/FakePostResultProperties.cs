// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtLRO.Models
{
    /// <summary> The FakePostResultProperties. </summary>
    internal partial class FakePostResultProperties
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="FakePostResultProperties"/>. </summary>
        internal FakePostResultProperties()
        {
        }

        /// <summary> Initializes a new instance of <see cref="FakePostResultProperties"/>. </summary>
        /// <param name="bar"> Bar property. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal FakePostResultProperties(string bar, Dictionary<string, BinaryData> rawData)
        {
            Bar = bar;
            _rawData = rawData;
        }

        /// <summary> Bar property. </summary>
        public string Bar { get; }
    }
}
