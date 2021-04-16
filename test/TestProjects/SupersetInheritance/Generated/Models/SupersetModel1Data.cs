// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using Azure.ResourceManager.Core;

namespace SupersetInheritance
{
    /// <summary> The SupersetModel1. </summary>
    public partial class SupersetModel1Data : Resource<TenantResourceIdentifier>
    {
        /// <summary> Initializes a new instance of SupersetModel1Data. </summary>
        public SupersetModel1Data()
        {
        }

        /// <summary> Initializes a new instance of SupersetModel1Data. </summary>
        /// <param name="id"> . </param>
        /// <param name="name"> . </param>
        /// <param name="type"> . </param>
        /// <param name="new"> . </param>
        internal SupersetModel1Data(string id, string name, string type, string @new)
        {
            Id = id;
            Name = name;
            Type = type;
            New = @new;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string New { get; set; }
    }
}
