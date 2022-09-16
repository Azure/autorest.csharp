// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using MgmtPolymorphicResources;

namespace MgmtPolymorphicResources.Models
{
    /// <summary> The List operation response, that contains the Cassandra tables and their properties. </summary>
    internal partial class CassandraTableListResult
    {
        /// <summary> Initializes a new instance of CassandraTableListResult. </summary>
        internal CassandraTableListResult()
        {
            Value = new ChangeTrackingList<CassandraTableData>();
        }

        /// <summary> Initializes a new instance of CassandraTableListResult. </summary>
        /// <param name="value"> List of Cassandra tables and their properties. </param>
        internal CassandraTableListResult(IReadOnlyList<CassandraTableData> value)
        {
            Value = value;
        }

        /// <summary> List of Cassandra tables and their properties. </summary>
        public IReadOnlyList<CassandraTableData> Value { get; }
    }
}
