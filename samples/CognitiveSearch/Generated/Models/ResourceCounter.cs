// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Represents a resource's usage and quota. </summary>
    public partial class ResourceCounter
    {
        /// <summary> Initializes a new instance of ResourceCounter. </summary>
        /// <param name="usage"> The resource usage amount. </param>
        internal ResourceCounter(long usage)
        {
            Usage = usage;
        }

        /// <summary> Initializes a new instance of ResourceCounter. </summary>
        /// <param name="usage"> The resource usage amount. </param>
        /// <param name="quota"> The resource amount quota. </param>
        internal ResourceCounter(long usage, long? quota)
        {
            Usage = usage;
            Quota = quota;
        }

        /// <summary> The resource usage amount. </summary>
        public long Usage { get; }
        /// <summary> The resource amount quota. </summary>
        public long? Quota { get; }
    }
}
