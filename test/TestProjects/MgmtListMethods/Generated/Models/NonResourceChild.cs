// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtListMethods.Models
{
    /// <summary> Describes the properties of a Non Resource Child. </summary>
    public partial class NonResourceChild
    {
        /// <summary> Initializes a new instance of NonResourceChild. </summary>
        internal NonResourceChild()
        {
        }

        /// <summary> Initializes a new instance of NonResourceChild. </summary>
        /// <param name="name"> Name. </param>
        /// <param name="numberOfCores"> Test Desc. </param>
        internal NonResourceChild(string name, int? numberOfCores)
        {
            Name = name;
            NumberOfCores = numberOfCores;
        }

        /// <summary> Name. </summary>
        public string Name { get; }
        /// <summary> Test Desc. </summary>
        public int? NumberOfCores { get; }
    }
}
