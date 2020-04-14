// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace SerializationCustomization.Models
{
    public partial class AlwaysInitializeTestModel
    {
        [CodeGenMember(Initialize = true)]
        public IList<Item> AlwaysInitializeList { get; }

        [CodeGenMember(Initialize = true)]
        public IList<Item> RequiredAlwaysInitializeList { get; }

        [CodeGenMember(Initialize = true)]
        public Item RequiredAlwaysInitializeObject { get; }

        [CodeGenMember(Initialize = true)]
        public Item AlwaysInitializeObject { get; }
    }
}