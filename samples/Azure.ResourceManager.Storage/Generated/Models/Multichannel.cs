// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Multichannel setting. Applies to Premium FileStorage only. </summary>
    internal partial class Multichannel
    {
        /// <summary> Initializes a new instance of Multichannel. </summary>
        public Multichannel()
        {
        }

        /// <summary> Initializes a new instance of Multichannel. </summary>
        /// <param name="enabled"> Indicates whether multichannel is enabled. </param>
        internal Multichannel(bool? enabled)
        {
            Enabled = enabled;
        }

        /// <summary> Indicates whether multichannel is enabled. </summary>
        public bool? Enabled { get; set; }
    }
}
