// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace AppConfiguration.Models
{
    /// <summary> The Key. </summary>
    public partial class Key
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="Key"/>. </summary>
        internal Key()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Key"/>. </summary>
        /// <param name="name"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Key(string name, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            _rawData = rawData;
        }

        /// <summary> Gets the name. </summary>
        public string Name { get; }
    }
}
