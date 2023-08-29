// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> A barrel of apples. </summary>
    public partial class AppleBarrel
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="AppleBarrel"/>. </summary>
        public AppleBarrel()
        {
            GoodApples = new ChangeTrackingList<string>();
            BadApples = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of <see cref="AppleBarrel"/>. </summary>
        /// <param name="goodApples"></param>
        /// <param name="badApples"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal AppleBarrel(IList<string> goodApples, IList<string> badApples, Dictionary<string, BinaryData> rawData)
        {
            GoodApples = goodApples;
            BadApples = badApples;
            _rawData = rawData;
        }

        /// <summary> Gets the good apples. </summary>
        public IList<string> GoodApples { get; }
        /// <summary> Gets the bad apples. </summary>
        public IList<string> BadApples { get; }
    }
}
