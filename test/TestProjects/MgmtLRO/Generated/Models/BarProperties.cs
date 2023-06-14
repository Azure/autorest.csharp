// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace MgmtLRO.Models
{
    /// <summary> The instance view of a resource. </summary>
    internal partial class BarProperties
    {
        /// <summary> Initializes a new instance of BarProperties. </summary>
        public BarProperties()
        {
        }

        /// <summary> Initializes a new instance of BarProperties. </summary>
        /// <param name="buzz"> Update Domain count. </param>
        internal BarProperties(Guid? buzz)
        {
            Buzz = buzz;
        }

        /// <summary> Update Domain count. </summary>
        public Guid? Buzz { get; set; }
    }
}
