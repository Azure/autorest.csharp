// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtXmlDeserialization;

namespace MgmtXmlDeserialization.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtXmlDeserializationModelFactory
    {
        /// <summary> Initializes a new instance of XmlInstanceData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <returns> A new <see cref="MgmtXmlDeserialization.XmlInstanceData"/> instance for mocking. </returns>
        public static XmlInstanceData XmlInstanceData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null)
        {
            return new XmlInstanceData(id, name, resourceType, systemData);
        }
    }
}
