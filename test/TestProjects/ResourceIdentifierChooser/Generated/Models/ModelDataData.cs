// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources.Models;

namespace ResourceIdentifierChooser
{
    /// <summary> A class representing the ModelData data model. </summary>
    public partial class ModelDataData : Model1
    {
        /// <summary> Initializes a new instance of ModelDataData. </summary>
        /// <param name="location"> The location. </param>
        public ModelDataData(Location location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of ModelDataData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="type"> The type. </param>
        /// <param name="location"> The location. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="mango"> Fruit. </param>
        /// <param name="strawberry"> Fruit. </param>
        /// <param name="cherry"> Fruit. </param>
        internal ModelDataData(ResourceGroupResourceIdentifier id, string name, ResourceType type, Location location, IDictionary<string, string> tags, string mango, string strawberry, string cherry) : base(id, name, type, location, tags, mango, strawberry)
        {
            Cherry = cherry;
        }

        /// <summary> Fruit. </summary>
        public string Cherry { get; set; }
    }
}
