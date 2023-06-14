// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace ProtocolMethodsInRestClient.Models
{
    /// <summary> Parameter group. </summary>
    public partial class Grouped
    {
        /// <summary> Initializes a new instance of Grouped. </summary>
        /// <param name="second"> Second in group. </param>
        public Grouped(int second)
        {
            Second = second;
        }

        /// <summary> First in group. </summary>
        public string First { get; set; }
        /// <summary> Second in group. </summary>
        public int Second { get; }
    }
}
