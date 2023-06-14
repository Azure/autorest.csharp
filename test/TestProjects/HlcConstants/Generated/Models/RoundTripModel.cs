// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace HlcConstants.Models
{
    /// <summary> The RoundTripModel. </summary>
    public partial class RoundTripModel
    {
        /// <summary> Initializes a new instance of RoundTripModel. </summary>
        public RoundTripModel()
        {
        }

        /// <summary> Initializes a new instance of RoundTripModel. </summary>
        /// <param name="requiredConstantModel"> Describes Protocol and thumbprint of Windows Remote Management listener. </param>
        /// <param name="optionalConstantModel"> Specifies additional XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup. Contents are defined by setting name, component name, and the pass in which the content is applied. </param>
        internal RoundTripModel(ModelWithRequiredConstant requiredConstantModel, ModelWithOptionalConstant optionalConstantModel)
        {
            RequiredConstantModel = requiredConstantModel;
            OptionalConstantModel = optionalConstantModel;
        }

        /// <summary> Describes Protocol and thumbprint of Windows Remote Management listener. </summary>
        public ModelWithRequiredConstant RequiredConstantModel { get; set; }
        /// <summary> Specifies additional XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup. Contents are defined by setting name, component name, and the pass in which the content is applied. </summary>
        public ModelWithOptionalConstant OptionalConstantModel { get; set; }
    }
}
