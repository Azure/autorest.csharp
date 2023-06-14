// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> Storage account keys creation time. </summary>
    public partial class KeyCreationTime
    {
        /// <summary> Initializes a new instance of KeyCreationTime. </summary>
        internal KeyCreationTime()
        {
        }

        /// <summary> Initializes a new instance of KeyCreationTime. </summary>
        /// <param name="key1"></param>
        /// <param name="key2"></param>
        internal KeyCreationTime(DateTimeOffset? key1, DateTimeOffset? key2)
        {
            Key1 = key1;
            Key2 = key2;
        }

        /// <summary> Gets the key 1. </summary>
        public DateTimeOffset? Key1 { get; }
        /// <summary> Gets the key 2. </summary>
        public DateTimeOffset? Key2 { get; }
    }
}
