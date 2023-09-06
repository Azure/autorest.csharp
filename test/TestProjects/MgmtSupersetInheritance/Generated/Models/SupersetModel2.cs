// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtSupersetInheritance.Models
{
    /// <summary> This model does not have id property, it's Non-Resource. </summary>
    public partial class SupersetModel2
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="SupersetModel2"/>. </summary>
        public SupersetModel2()
        {
        }

        /// <summary> Initializes a new instance of <see cref="SupersetModel2"/>. </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="supersetModel2Type"></param>
        /// <param name="new"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal SupersetModel2(string id, string name, string supersetModel2Type, string @new, Dictionary<string, BinaryData> rawData)
        {
            ID = id;
            Name = name;
            SupersetModel2Type = supersetModel2Type;
            New = @new;
            _rawData = rawData;
        }

        /// <summary> Gets or sets the id. </summary>
        public string ID { get; set; }
        /// <summary> Gets or sets the name. </summary>
        public string Name { get; set; }
        /// <summary> Gets or sets the superset model 2 type. </summary>
        public string SupersetModel2Type { get; set; }
        /// <summary> Gets or sets the new. </summary>
        public string New { get; set; }
    }
}
