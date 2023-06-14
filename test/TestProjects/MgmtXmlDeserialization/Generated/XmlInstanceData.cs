// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;

namespace MgmtXmlDeserialization
{
    /// <summary>
    /// A class representing the XmlInstance data model.
    /// Xml instance details.
    /// </summary>
    public partial class XmlInstanceData : ResourceData
    {
        /// <summary> Initializes a new instance of XmlInstanceData. </summary>
        public XmlInstanceData()
        {
        }

        /// <summary> Initializes a new instance of XmlInstanceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        internal XmlInstanceData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData) : base(id, name, resourceType, systemData)
        {
        }
    }
}
