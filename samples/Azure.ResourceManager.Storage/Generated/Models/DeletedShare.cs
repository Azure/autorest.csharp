// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.ResourceManager.Storage.Models
{
    /// <summary> The deleted share to be restored. </summary>
    public partial class DeletedShare
    {
        /// <summary> Initializes a new instance of DeletedShare. </summary>
        /// <param name="deletedShareName"> Required. Identify the name of the deleted share that will be restored. </param>
        /// <param name="deletedShareVersion"> Required. Identify the version of the deleted share that will be restored. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="deletedShareName"/> or <paramref name="deletedShareVersion"/> is null. </exception>
        public DeletedShare(string deletedShareName, string deletedShareVersion)
        {
            Argument.AssertNotNull(deletedShareName, nameof(deletedShareName));
            Argument.AssertNotNull(deletedShareVersion, nameof(deletedShareVersion));

            DeletedShareName = deletedShareName;
            DeletedShareVersion = deletedShareVersion;
        }

        /// <summary> Required. Identify the name of the deleted share that will be restored. </summary>
        public string DeletedShareName { get; }
        /// <summary> Required. Identify the version of the deleted share that will be restored. </summary>
        public string DeletedShareVersion { get; }
    }
}
