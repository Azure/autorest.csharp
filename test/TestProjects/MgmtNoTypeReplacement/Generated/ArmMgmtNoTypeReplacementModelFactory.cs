// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Linq;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtNoTypeReplacement;

namespace MgmtNoTypeReplacement.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtNoTypeReplacementModelFactory
    {

        /// <summary> Initializes a new instance of NoTypeReplacementModel1Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="fooId"> Gets or sets the foo. </param>
        /// <returns> A new <see cref="MgmtNoTypeReplacement.NoTypeReplacementModel1Data"/> instance for mocking. </returns>
        public static NoTypeReplacementModel1Data NoTypeReplacementModel1Data(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, ResourceIdentifier fooId = null)
        {
            return new NoTypeReplacementModel1Data(id, name, resourceType, systemData, fooId != null ? ResourceManagerModelFactory.SubResource(fooId) : null);
        }

        /// <summary> Initializes a new instance of NoTypeReplacementModel2Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="fooId"></param>
        /// <returns> A new <see cref="MgmtNoTypeReplacement.NoTypeReplacementModel2Data"/> instance for mocking. </returns>
        public static NoTypeReplacementModel2Data NoTypeReplacementModel2Data(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string fooId = null)
        {
            return new NoTypeReplacementModel2Data(id, name, resourceType, systemData, fooId != null ? new NoSubResourceModel(fooId) : null);
        }

        /// <summary> Initializes a new instance of NoTypeReplacementModel3Data. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="fooId"></param>
        /// <returns> A new <see cref="MgmtNoTypeReplacement.NoTypeReplacementModel3Data"/> instance for mocking. </returns>
        public static NoTypeReplacementModel3Data NoTypeReplacementModel3Data(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, string fooId = null)
        {
            return new NoTypeReplacementModel3Data(id, name, resourceType, systemData, fooId != null ? new MiddleResourceModel(new NoSubResourceModel2(fooId)) : null);
        }
    }
}
