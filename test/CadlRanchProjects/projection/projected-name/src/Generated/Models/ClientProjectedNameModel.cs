// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Projection.ProjectedName.Models
{
    /// <summary> The ClientProjectedNameModel. </summary>
    public partial class ClientProjectedNameModel
    {
        /// <summary> Initializes a new instance of ClientProjectedNameModel. </summary>
        /// <param name="clientName"> Pass in true. </param>
        public ClientProjectedNameModel(bool clientName)
        {
            ClientName = clientName;
        }

        /// <summary> Pass in true. </summary>
        public bool ClientName { get; }
    }
}
