// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> Represents a datasource definition, which can be used to configure an indexer. </summary>
    public partial class DataSource
    {
        private Dictionary<string, BinaryData> _rawData;

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.DataSource
        ///
        /// </summary>
        /// <param name="name"> The name of the datasource. </param>
        /// <param name="type"> The type of the datasource. </param>
        /// <param name="credentials"> Credentials for the datasource. </param>
        /// <param name="container"> The data container for the datasource. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/>, <paramref name="credentials"/> or <paramref name="container"/> is null. </exception>
        public DataSource(string name, DataSourceType type, DataSourceCredentials credentials, DataContainer container)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(credentials, nameof(credentials));
            Argument.AssertNotNull(container, nameof(container));

            Name = name;
            Type = type;
            Credentials = credentials;
            Container = container;
        }

        /// <summary>
        /// Initializes a new instance of global::CognitiveSearch.Models.DataSource
        ///
        /// </summary>
        /// <param name="name"> The name of the datasource. </param>
        /// <param name="description"> The description of the datasource. </param>
        /// <param name="type"> The type of the datasource. </param>
        /// <param name="credentials"> Credentials for the datasource. </param>
        /// <param name="container"> The data container for the datasource. </param>
        /// <param name="dataChangeDetectionPolicy">
        /// The data change detection policy for the datasource.
        /// Please note <see cref="DataChangeDetectionPolicy"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="HighWaterMarkChangeDetectionPolicy"/> and <see cref="SqlIntegratedChangeTrackingPolicy"/>.
        /// </param>
        /// <param name="dataDeletionDetectionPolicy">
        /// The data deletion detection policy for the datasource.
        /// Please note <see cref="DataDeletionDetectionPolicy"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SoftDeleteColumnDeletionDetectionPolicy"/>.
        /// </param>
        /// <param name="eTag"> The ETag of the DataSource. </param>
        /// <param name="rawData"> Keeps track of any properties unknown to the library. </param>
        internal DataSource(string name, string description, DataSourceType type, DataSourceCredentials credentials, DataContainer container, DataChangeDetectionPolicy dataChangeDetectionPolicy, DataDeletionDetectionPolicy dataDeletionDetectionPolicy, string eTag, Dictionary<string, BinaryData> rawData)
        {
            Name = name;
            Description = description;
            Type = type;
            Credentials = credentials;
            Container = container;
            DataChangeDetectionPolicy = dataChangeDetectionPolicy;
            DataDeletionDetectionPolicy = dataDeletionDetectionPolicy;
            ETag = eTag;
            _rawData = rawData;
        }

        /// <summary> Initializes a new instance of <see cref="DataSource"/> for deserialization. </summary>
        internal DataSource()
        {
        }

        /// <summary> The name of the datasource. </summary>
        public string Name { get; set; }
        /// <summary> The description of the datasource. </summary>
        public string Description { get; set; }
        /// <summary> The type of the datasource. </summary>
        public DataSourceType Type { get; set; }
        /// <summary> Credentials for the datasource. </summary>
        public DataSourceCredentials Credentials { get; set; }
        /// <summary> The data container for the datasource. </summary>
        public DataContainer Container { get; set; }
        /// <summary>
        /// The data change detection policy for the datasource.
        /// Please note <see cref="DataChangeDetectionPolicy"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="HighWaterMarkChangeDetectionPolicy"/> and <see cref="SqlIntegratedChangeTrackingPolicy"/>.
        /// </summary>
        public DataChangeDetectionPolicy DataChangeDetectionPolicy { get; set; }
        /// <summary>
        /// The data deletion detection policy for the datasource.
        /// Please note <see cref="DataDeletionDetectionPolicy"/> is the base class. According to the scenario, a derived class of the base class might need to be assigned here, or this property needs to be casted to one of the possible derived classes.
        /// The available derived classes include <see cref="SoftDeleteColumnDeletionDetectionPolicy"/>.
        /// </summary>
        public DataDeletionDetectionPolicy DataDeletionDetectionPolicy { get; set; }
        /// <summary> The ETag of the DataSource. </summary>
        public string ETag { get; set; }
    }
}
