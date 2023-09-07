// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtConstants.Models
{
    /// <summary> Describes a Virtual Machine Update. </summary>
    public partial class OptionalMachinePatch : UpdateResource
    {
        /// <summary> Initializes a new instance of <see cref="OptionalMachinePatch"/>. </summary>
        public OptionalMachinePatch()
        {
        }

        /// <summary> Initializes a new instance of <see cref="OptionalMachinePatch"/>. </summary>
        /// <param name="tags"> Resource tags. </param>
        /// <param name="listener"> Describes Protocol and thumbprint of Windows Remote Management listener. </param>
        /// <param name="content"> Specifies additional XML formatted information that can be included in the Unattend.xml file, which is used by Windows Setup. Contents are defined by setting name, component name, and the pass in which the content is applied. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal OptionalMachinePatch(IDictionary<string, string> tags, ModelWithRequiredConstant listener, ModelWithOptionalConstant content, Dictionary<string, BinaryData> serializedAdditionalRawData) : base(tags, serializedAdditionalRawData)
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
