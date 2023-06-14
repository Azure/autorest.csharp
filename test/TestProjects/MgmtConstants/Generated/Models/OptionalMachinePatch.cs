// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtConstants.Models
{
    /// <summary> Describes a Virtual Machine Update. </summary>
    public partial class OptionalMachinePatch : UpdateResource
    {
        /// <summary> Initializes a new instance of OptionalMachinePatch. </summary>
        public OptionalMachinePatch()
        {
        }

        /// <summary> Describes Protocol and thumbprint of Windows Remote Management listener. </summary>
        public ModelWithRequiredConstant Listener { get; set; }
        /// <summary> Specifies additional XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup. Contents are defined by setting name, component name, and the pass in which the content is applied. </summary>
        public ModelWithOptionalConstant Content { get; set; }
    }
}
