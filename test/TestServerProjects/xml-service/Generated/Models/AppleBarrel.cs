// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace xml_service.Models
{
    /// <summary> A barrel of apples. </summary>
    public partial class AppleBarrel
    {
        /// <summary> Initializes a new instance of AppleBarrel. </summary>
        public AppleBarrel()
        {
            GoodApples = new ChangeTrackingList<string>();
            BadApples = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of AppleBarrel. </summary>
        /// <param name="goodApples"></param>
        /// <param name="badApples"></param>
        internal AppleBarrel(IList<string> goodApples, IList<string> badApples)
        {
            GoodApples = goodApples;
            BadApples = badApples;
        }

        /// <summary> Gets the good apples. </summary>
        public IList<string> GoodApples { get; }
        /// <summary> Gets the bad apples. </summary>
        public IList<string> BadApples { get; }
    }
}
