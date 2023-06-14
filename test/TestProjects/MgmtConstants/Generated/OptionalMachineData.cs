// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtConstants.Models;

namespace MgmtConstants
{
    /// <summary>
    /// A class representing the OptionalMachine data model.
    /// Describes a Virtual Machine.
    /// </summary>
    public partial class OptionalMachineData : TrackedResourceData
    {
        /// <summary> Initializes a new instance of OptionalMachineData. </summary>
        /// <param name="location"> The location. </param>
        public OptionalMachineData(AzureLocation location) : base(location)
        {
        }

        /// <summary> Initializes a new instance of OptionalMachineData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="listener"> Describes Protocol and thumbprint of Windows Remote Management listener. </param>
        /// <param name="content"> Specifies additional XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup. Contents are defined by setting name, component name, and the pass in which the content is applied. </param>
        internal OptionalMachineData(ResourceIdentifier id, string name, ResourceType resourceType, SystemData systemData, IDictionary<string, string> tags, AzureLocation location, ModelWithRequiredConstant listener, ModelWithOptionalConstant content) : base(id, name, resourceType, systemData, tags, location)
        {
            Listener = listener;
            Content = content;
        }

        /// <summary> Describes Protocol and thumbprint of Windows Remote Management listener. </summary>
        public ModelWithRequiredConstant Listener { get; set; }
        /// <summary> Specifies additional XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup. Contents are defined by setting name, component name, and the pass in which the content is applied. </summary>
        public ModelWithOptionalConstant Content { get; set; }
    }
}
