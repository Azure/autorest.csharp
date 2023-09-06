// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace xms_error_responses.Models
{
    /// <summary> The Animal. </summary>
    public partial class Animal
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        protected internal Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="Animal"/>. </summary>
        internal Animal()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Animal"/>. </summary>
        /// <param name="aniType"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Animal(string aniType, Dictionary<string, BinaryData> rawData)
        {
            AniType = aniType;
            _rawData = rawData;
        }

        /// <summary> Gets the ani type. </summary>
        public string AniType { get; }
    }
}
