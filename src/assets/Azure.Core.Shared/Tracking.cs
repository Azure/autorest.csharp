// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Azure.Core
{
    public static class Tracking
    {
        public static bool IsCollectionChanged<TKey, TValue>(IDictionary<TKey, TValue> collection)
        {
            return !(collection is TrackingDictionary<TKey, TValue> changeTrackingList && !(changeTrackingList.ChangedKeys?.Count > 0));
        }
    }
}
