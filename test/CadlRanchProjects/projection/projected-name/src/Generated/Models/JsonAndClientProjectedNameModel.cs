// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Projection.ProjectedName.Models
{
    /// <summary> The JsonAndClientProjectedNameModel. </summary>
    public partial class JsonAndClientProjectedNameModel
    {
        /// <summary> Initializes a new instance of JsonAndClientProjectedNameModel. </summary>
        /// <param name="clientName"> Pass in true. </param>
        public JsonAndClientProjectedNameModel(bool clientName)
        {
            ClientName = clientName;
        }

        /// <summary> Pass in true. </summary>
        public bool ClientName { get; }
    }
}
