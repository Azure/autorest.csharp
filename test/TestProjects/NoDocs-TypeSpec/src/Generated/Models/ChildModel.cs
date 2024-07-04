// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace NoDocsTypeSpec.Models
{
    public partial class ChildModel : BaseModel
    {
        public ChildModel(sbyte level, IEnumerable<BaseModel> parent) : base(level)
        {
            Argument.AssertNotNull(parent, nameof(parent));

            Parent = parent.ToList();
        }

        internal ChildModel(sbyte level, IDictionary<string, BinaryData> serializedAdditionalRawData, IList<BaseModel> parent) : base(level, serializedAdditionalRawData)
        {
            Parent = parent;
        }

        internal ChildModel()
        {
        }

        public IList<BaseModel> Parent { get; }
    }
}
