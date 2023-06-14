// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtSupersetInheritance.Models
{
    /// <summary> id is integer, the model is Non-Resource. </summary>
    public partial class SupersetModel3
    {
        /// <summary> Initializes a new instance of SupersetModel3. </summary>
        public SupersetModel3()
        {
        }

        /// <summary> Initializes a new instance of SupersetModel3. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="supersetModel3Type"></param>
        /// <param name="new"></param>
        internal SupersetModel3(int? id, string name, string supersetModel3Type, string @new)
        {
            Id = id;
            Name = name;
            SupersetModel3Type = supersetModel3Type;
            New = @new;
        }

        /// <summary> Gets or sets the id. </summary>
        public int? Id { get; set; }
        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
        /// <summary> Gets or sets the superset model 3 type. </summary>
        public string SupersetModel3Type { get; set; }
        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
