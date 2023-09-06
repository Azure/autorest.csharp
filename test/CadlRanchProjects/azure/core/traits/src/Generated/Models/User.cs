// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace _Specs_.Azure.Core.Traits.Models
{
    /// <summary> Sample Model. </summary>
    public partial class User
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of User. </summary>
        internal User()
        {
        }

        /// <summary> Initializes a new instance of User. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="name"> The user's name. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal User(int id, string name, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            Name = name;
            _rawData = rawData;
        }

        /// <summary> The user's id. </summary>
        public int Id { get; }
        /// <summary> The user's name. </summary>
        public string Name { get; }
    }
}
