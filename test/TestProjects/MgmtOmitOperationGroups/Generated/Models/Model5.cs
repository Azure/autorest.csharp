// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;

namespace MgmtOmitOperationGroups.Models
{
    /// <summary> The Model5. </summary>
    public partial class Model5
    {
        /// <summary> Initializes a new instance of Model5. </summary>
        public Model5()
        {
            Modelqs = new ChangeTrackingList<ModelQ>();
        }

        /// <summary> Initializes a new instance of Model5. </summary>
        /// <param name="id"></param>
        /// <param name="k"></param>
        /// <param name="modelqs"></param>
        internal Model5(string id, string k, IList<ModelQ> modelqs)
        {
            Id = id;
            K = k;
            Modelqs = modelqs;
        }

        /// <summary> Gets or sets the id. </summary>
        public string Id { get; set; }
        /// <summary> Gets the k. </summary>
        public string K { get; }
        /// <summary> Gets the modelqs. </summary>
        public IList<ModelQ> Modelqs { get; }
    }
}
