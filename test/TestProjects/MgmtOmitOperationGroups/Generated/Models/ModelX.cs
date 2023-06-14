// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtOmitOperationGroups.Models
{
    /// <summary> The ModelX. </summary>
    public partial class ModelX : ModelY
    {
        /// <summary> Initializes a new instance of ModelX. </summary>
        public ModelX()
        {
        }

        /// <summary> Initializes a new instance of ModelX. </summary>
        /// <param name="e"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        internal ModelX(string e, string c, string d) : base(e)
        {
            C = c;
            D = d;
        }

        /// <summary> Gets or sets the c. </summary>
        public string C { get; set; }
        /// <summary> Gets or sets the d. </summary>
        public string D { get; set; }
    }
}
