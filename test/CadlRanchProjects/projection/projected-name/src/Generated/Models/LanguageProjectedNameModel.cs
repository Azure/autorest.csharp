// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Projection.ProjectedName.Models
{
    /// <summary> The LanguageProjectedNameModel. </summary>
    public partial class LanguageProjectedNameModel
    {
        /// <summary> Initializes a new instance of LanguageProjectedNameModel. </summary>
        /// <param name="csName"> Pass in true. </param>
        public LanguageProjectedNameModel(bool csName)
        {
            CSName = csName;
        }

        /// <summary> Pass in true. </summary>
        public bool CSName { get; }
    }
}
