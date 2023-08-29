// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtListMethods.Models
{
    /// <summary> Describes the properties of a Non Resource Child. </summary>
    public partial class NonResourceChild
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="NonResourceChild"/>. </summary>
        internal NonResourceChild()
        {
        }

        /// <summary> Initializes a new instance of <see cref="NonResourceChild"/>. </summary>
        /// <param name="name"> Name. </param>
        /// <param name="numberOfCores"> Test Desc. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal NonResourceChild(string name, int? numberOfCores, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            NumberOfCores = numberOfCores;
            _rawData = rawData;
        }

        /// <summary> Name. </summary>
        public string Name { get; }
        /// <summary> Test Desc. </summary>
        public int? NumberOfCores { get; }
    }
}
