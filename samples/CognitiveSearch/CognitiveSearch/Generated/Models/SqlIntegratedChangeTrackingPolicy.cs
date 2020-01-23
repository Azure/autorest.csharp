// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace CognitiveSearch.Models
{
    /// <summary> Defines a data change detection policy that captures changes using the Integrated Change Tracking feature of Azure SQL Database. </summary>
    public partial class SqlIntegratedChangeTrackingPolicy : DataChangeDetectionPolicy
    {
        /// <summary> Initializes a new instance of SqlIntegratedChangeTrackingPolicy. </summary>
        public SqlIntegratedChangeTrackingPolicy()
        {
            OdataType = "#Microsoft.Azure.Search.SqlIntegratedChangeTrackingPolicy";
        }
    }
}
