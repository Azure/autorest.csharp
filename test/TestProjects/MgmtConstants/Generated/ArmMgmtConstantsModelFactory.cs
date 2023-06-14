// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.Models;
using MgmtConstants;

namespace MgmtConstants.Models
{
    /// <summary> Model factory for models. </summary>
    public static partial class ArmMgmtConstantsModelFactory
    {
        /// <summary> Initializes a new instance of OptionalMachineData. </summary>
        /// <param name="id"> The id. </param>
        /// <param name="name"> The name. </param>
        /// <param name="resourceType"> The resourceType. </param>
        /// <param name="systemData"> The systemData. </param>
        /// <param name="tags"> The tags. </param>
        /// <param name="location"> The location. </param>
        /// <param name="listener"> Describes Protocol and thumbprint of Windows Remote Management listener. </param>
        /// <param name="content"> Specifies additional XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup. Contents are defined by setting name, component name, and the pass in which the content is applied. </param>
        /// <returns> A new <see cref="MgmtConstants.OptionalMachineData"/> instance for mocking. </returns>
        public static OptionalMachineData OptionalMachineData(ResourceIdentifier id = null, string name = null, ResourceType resourceType = default, SystemData systemData = null, IDictionary<string, string> tags = null, AzureLocation location = default, ModelWithRequiredConstant listener = null, ModelWithOptionalConstant content = null)
        {
            tags ??= new Dictionary<string, string>();

            return new OptionalMachineData(id, name, resourceType, systemData, tags, location, listener, content);
        }

        /// <summary> Initializes a new instance of ModelWithRequiredConstant. </summary>
        /// <param name="requiredStringConstant"> A constant based on string, the only allowable value is default. </param>
        /// <param name="requiredIntConstant"> A constant based on integer. </param>
        /// <param name="requiredBooleanConstant"> A constant based on boolean. </param>
        /// <param name="requiredFloatConstant"> A constant based on float. </param>
        /// <returns> A new <see cref="Models.ModelWithRequiredConstant"/> instance for mocking. </returns>
        public static ModelWithRequiredConstant ModelWithRequiredConstant(StringConstant requiredStringConstant = default, IntConstant requiredIntConstant = default, bool requiredBooleanConstant = default, FloatConstant requiredFloatConstant = default)
        {
            return new ModelWithRequiredConstant(requiredStringConstant, requiredIntConstant, requiredBooleanConstant, requiredFloatConstant);
        }
    }
}
