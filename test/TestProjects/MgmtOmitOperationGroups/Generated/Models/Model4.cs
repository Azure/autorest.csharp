// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtOmitOperationGroups.Models
{
    /// <summary> The Model4. </summary>
    public partial class Model4
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary> Initializes a new instance of <see cref="Model4"/>. </summary>
        internal Model4()
        {
        }

        /// <summary> Initializes a new instance of <see cref="Model4"/>. </summary>
        /// <param name="id"></param>
        /// <param name="j"></param>
        /// <param name="modelz"></param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal Model4(string id, string j, ModelZ modelz, Dictionary<string, BinaryData> rawData)
        {
            Id = id;
            J = j;
            Modelz = modelz;
            _rawData = rawData;
        }

        /// <summary> Gets the id. </summary>
        public string Id { get; }
        /// <summary> Gets the j. </summary>
        public string J { get; }
        /// <summary> Gets the modelz. </summary>
        public ModelZ Modelz { get; }
    }
}
