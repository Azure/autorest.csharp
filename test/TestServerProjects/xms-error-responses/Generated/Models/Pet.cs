// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace xms_error_responses.Models
{
    /// <summary> The Pet. </summary>
    public partial class Pet : Animal
    {
        /// <summary> Initializes a new instance of Pet. </summary>
        internal Pet()
        {
        }

        /// <summary> Initializes a new instance of Pet. </summary>
        /// <param name="aniType"></param>
        /// <param name="name"> Gets the Pet by id. </param>
        internal Pet(string aniType, string name) : base(aniType)
        {
            Name = name;
        }

        /// <summary> Gets the Pet by id. </summary>
        public string Name { get; }
    }
}
