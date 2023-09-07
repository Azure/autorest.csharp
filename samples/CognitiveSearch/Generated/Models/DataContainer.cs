// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Represents information about the entity (such as Azure SQL table or CosmosDB collection) that will be indexed. </summary>
    public partial class DataContainer
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="DataContainer"/>. </summary>
        /// <param name="name"> The name of the table or view (for Azure SQL data source) or collection (for CosmosDB data source) that will be indexed. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public DataContainer(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
        }

        /// <summary> Initializes a new instance of <see cref="DataContainer"/>. </summary>
        /// <param name="name"> The name of the table or view (for Azure SQL data source) or collection (for CosmosDB data source) that will be indexed. </param>
        /// <param name="query"> A query that is applied to this data container. The syntax and meaning of this parameter is datasource-specific. Not supported by Azure SQL datasources. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal DataContainer(string name, string query, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            Name = name;
            Query = query;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="DataContainer"/> for deserialization. </summary>
        internal DataContainer()
        {
        }

        /// <summary> The name of the table or view (for Azure SQL data source) or collection (for CosmosDB data source) that will be indexed. </summary>
        public string Name { get; set; }
        /// <summary> A query that is applied to this data container. The syntax and meaning of this parameter is datasource-specific. Not supported by Azure SQL datasources. </summary>
        public string Query { get; set; }
    }
}
