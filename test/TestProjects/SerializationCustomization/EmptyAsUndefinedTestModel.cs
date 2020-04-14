// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;

namespace SerializationCustomization.Models
{
    public partial class EmptyAsUndefinedTestModel
    {
        [CodeGenMember(EmptyAsUndefined = true)]
        public IList<Item> EmptyAsUndefinedList { get; set; }

        [CodeGenMember(EmptyAsUndefined = true, Initialize = true)]
        public IList<Item> EmptyAsAlwaysInitializeList { get; }
    }
}