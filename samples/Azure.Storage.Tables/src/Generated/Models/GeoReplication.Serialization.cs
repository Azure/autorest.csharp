// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Xml.Linq;
using Azure.Core;

namespace Azure.Storage.Tables.Models
{
    public partial class GeoReplication
    {
        internal static GeoReplication DeserializeGeoReplication(XElement element)
        {
            GeoReplicationStatusType status = default;
            DateTimeOffset lastSyncTime = default;
            if (element.Element("Status") is XElement statusElement)
            {
                status = new GeoReplicationStatusType(statusElement.Value);
            }
            if (element.Element("LastSyncTime") is XElement lastSyncTimeElement)
            {
                lastSyncTime = lastSyncTimeElement.GetDateTimeOffsetValue("R");
            }
            return new GeoReplication(status, lastSyncTime);
        }
    }
}
