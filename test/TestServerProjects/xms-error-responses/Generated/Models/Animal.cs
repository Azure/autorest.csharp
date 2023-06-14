// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xms_error_responses.Models
{
    /// <summary> The Animal. </summary>
    public partial class Animal
    {
        /// <summary> Initializes a new instance of Animal. </summary>
        internal Animal()
        {
        }

        /// <summary> Initializes a new instance of Animal. </summary>
        /// <param name="aniType"></param>
        internal Animal(string aniType)
        {
            AniType = aniType;
        }

        /// <summary> Gets the ani type. </summary>
        public string AniType { get; }
    }
}
