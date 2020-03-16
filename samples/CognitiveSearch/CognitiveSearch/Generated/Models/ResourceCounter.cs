// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace CognitiveSearch.Models
{
    /// <summary> Represents a resource&apos;s usage and quota. </summary>
    public partial class ResourceCounter
    {
        /// <summary> Initializes a new instance of ResourceCounter. </summary>
        internal ResourceCounter()
        {
        }
        /// <summary> Initializes a new instance of ResourceCounter. </summary>
        /// <param name="usage"> The resource usage amount. </param>
        /// <param name="quota"> The resource amount quota. </param>
        internal ResourceCounter(long? usage, long? quota)
        {
            Usage = usage;
            Quota = quota;
        }
        /// <summary> The resource usage amount. </summary>
        public long? Usage { get; set; }
        /// <summary> The resource amount quota. </summary>
        public long? Quota { get; set; }
    }
}
