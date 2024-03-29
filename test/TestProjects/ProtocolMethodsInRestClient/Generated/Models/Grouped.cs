// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace ProtocolMethodsInRestClient.Models
{
    /// <summary> Parameter group. </summary>
    public partial class Grouped
    {
        /// <summary> Initializes a new instance of <see cref="Grouped"/>. </summary>
        /// <param name="second"> Second in group. </param>
        public Grouped(int second)
        {
            Second = second;
        }

        /// <summary> Initializes a new instance of <see cref="Grouped"/>. </summary>
        /// <param name="first"> First in group. </param>
        /// <param name="second"> Second in group. </param>
        internal Grouped(string first, int second)
        {
            First = first;
            Second = second;
        }

        /// <summary> First in group. </summary>
        public string First { get; set; }
        /// <summary> Second in group. </summary>
        public int Second { get; }
    }
}
