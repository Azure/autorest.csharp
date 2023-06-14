// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtOmitOperationGroups.Models
{
    /// <summary> The ModelY. </summary>
    public partial class ModelY
    {
        /// <summary> Initializes a new instance of ModelY. </summary>
        public ModelY()
        {
        }

        /// <summary> Initializes a new instance of ModelY. </summary>
        /// <param name="e"></param>
        internal ModelY(string e)
        {
            E = e;
        }

        /// <summary> Gets or sets the e. </summary>
        public string E { get; set; }
    }
}
