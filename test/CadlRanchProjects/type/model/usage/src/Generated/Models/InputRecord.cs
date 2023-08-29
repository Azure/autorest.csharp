// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace _Type.Model.Usage.Models
{
    /// <summary> Record used in operation parameters. </summary>
    public partial class InputRecord
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of InputRecord. </summary>
        /// <param name="requiredProp"></param>
        /// <exception cref="ArgumentNullException"> <paramref name="requiredProp"/> is null. </exception>
        public InputRecord(string requiredProp)
        {
            Argument.AssertNotNull(requiredProp, nameof(requiredProp));

            RequiredProp = requiredProp;
        }

        /// <summary> Initializes a new instance of InputRecord. </summary>
        /// <param name="requiredProp"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal InputRecord(string requiredProp, Dictionary<string, BinaryData> rawData)
        {
            RequiredProp = requiredProp;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="InputRecord"/> for deserialization. </summary>
        internal InputRecord()
        {
        }

        /// <summary> Gets the required prop. </summary>
        public string RequiredProp { get; }
    }
}
