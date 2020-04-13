// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace SerializationCustomization.Models
{
    public partial class AlwaysInitializeTestModel
    {
        [CodeGenMember(InitializeWith = typeof(List<Item>))]
        public IList<Item> AlwaysInitializeList { get; }

        [CodeGenMember(InitializeWith = typeof(List<Item>))]
        public IList<Item> RequiredAlwaysInitializeList { get; }

        [CodeGenMember(InitializeWith = typeof(Item))]
        public Item RequiredAlwaysInitializeObject { get; }

        [CodeGenMember(InitializeWith = typeof(Item))]
        public Item AlwaysInitializeObject { get; }
    }
}