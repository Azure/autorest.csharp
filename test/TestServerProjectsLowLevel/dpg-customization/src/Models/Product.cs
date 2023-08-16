// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System;
using System.Text.Json;
using Azure;

namespace dpg_customization_LowLevel.Models
{
    /// <summary> The Product. </summary>
    public partial class Product
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of Product. </summary>
        /// <param name="received"></param>
        public Product(ProductReceived received)
        {
            Received = received;
        }

        /// <summary> Initializes a new instance of Product. </summary>
        /// <param name="received"></param>
        /// <param name="rawData"></param>
        internal Product(ProductReceived received, Dictionary<string, BinaryData> rawData)
        {
            Received = received;
            _rawData = rawData;
        }

        /// <summary> Gets the received. </summary>
        public ProductReceived Received { get; }
    }
}
