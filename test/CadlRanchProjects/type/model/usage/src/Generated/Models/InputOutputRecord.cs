// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Model.Usage.Models
{
    /// <summary> Record used both as operation parameter and return type. </summary>
    public partial class InputOutputRecord
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of InputOutputRecord. </summary>
        /// <param name="requiredProp"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProp"/> is null. </exception>
        public InputOutputRecord(string requiredProp)
        {
            Argument.AssertNotNull(requiredProp, nameof(requiredProp));

            RequiredProp = requiredProp;
        }

        /// <summary> Initializes a new instance of InputOutputRecord. </summary>
        /// <param name="requiredProp"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal InputOutputRecord(string requiredProp, Dictionary<string, BinaryData> rawData)
        {
            RequiredProp = requiredProp;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the required prop. </summary>
        public string RequiredProp { get; set; }
    }
}
