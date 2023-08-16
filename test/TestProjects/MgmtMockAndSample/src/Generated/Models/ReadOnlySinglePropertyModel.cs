// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtMockAndSample.Models
{
    /// <summary> This is a single property of read-only string. </summary>
    internal partial class ReadOnlySinglePropertyModel
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::MgmtMockAndSample.Models.ReadOnlySinglePropertyModel
        ///
        /// </summary>
        public ReadOnlySinglePropertyModel()
        {
        }

        /// <summary>
        /// Initializes a new instance of global::MgmtMockAndSample.Models.ReadOnlySinglePropertyModel
        ///
        /// </summary>
        /// <param name="readOnlySomething"> This is a read only string property. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal ReadOnlySinglePropertyModel(string readOnlySomething, Dictionary<string, BinaryData> rawData)
        {
            ReadOnlySomething = readOnlySomething;
            _rawData = rawData;
        }

        /// <summary> This is a read only string property. </summary>
        public string ReadOnlySomething { get; }
    }
}
