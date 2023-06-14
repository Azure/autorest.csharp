// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Projection.ProjectedName.Models
{
    /// <summary> The JsonProjectedNameModel. </summary>
    public partial class JsonProjectedNameModel
    {
        /// <summary> Initializes a new instance of JsonProjectedNameModel. </summary>
        /// <param name="defaultName"> Pass in true. </param>
        public JsonProjectedNameModel(bool defaultName)
        {
            DefaultName = defaultName;
        }

        /// <summary> Pass in true. </summary>
        public bool DefaultName { get; }
    }
}
