// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace MgmtListMethods.Models
{
    /// <summary> The properties for Quota update or retrieval. </summary>
    public partial class QuotaBaseProperties
    {
        /// <summary> Initializes a new instance of QuotaBaseProperties. </summary>
        public QuotaBaseProperties()
        {
        }

        /// <summary> Initializes a new instance of QuotaBaseProperties. </summary>
        /// <param name="id"> Specifies the resource ID. </param>
        /// <param name="quotaBasePropertiesType"> Specifies the resource type. </param>
        /// <param name="limit"> The maximum permitted quota of the resource. </param>
        /// <param name="unit"> An enum describing the unit of quota measurement. </param>
        internal QuotaBaseProperties(string id, string quotaBasePropertiesType, long? limit, QuotaUnit? unit)
        {
            Id = id;
            QuotaBasePropertiesType = quotaBasePropertiesType;
            Limit = limit;
            Unit = unit;
        }

        /// <summary> Specifies the resource ID. </summary>
        public string Id { get; set; }
        /// <summary> Specifies the resource type. </summary>
        public string QuotaBasePropertiesType { get; set; }
        /// <summary> The maximum permitted quota of the resource. </summary>
        public long? Limit { get; set; }
        /// <summary> An enum describing the unit of quota measurement. </summary>
        public QuotaUnit? Unit { get; set; }
    }
}
