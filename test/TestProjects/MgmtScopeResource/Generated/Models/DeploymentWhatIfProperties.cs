// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtScopeResource.Models
{
    /// <summary> Deployment What-if properties. </summary>
    public partial class DeploymentWhatIfProperties : DeploymentProperties
    {
        /// <summary> Initializes a new instance of <see cref="DeploymentWhatIfProperties"/>. </summary>
        /// <param name="mode"> The mode that is used to deploy resources. This value can be either Incremental or Complete. In Incremental mode, resources are deployed without deleting existing resources that are not included in the template. In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted. Be careful when using Complete mode as you may unintentionally delete resources. </param>
        public DeploymentWhatIfProperties(DeploymentMode mode) : base(mode)
        {
        }

        /// <summary> Initializes a new instance of <see cref="DeploymentWhatIfProperties"/>. </summary>
        /// <param name="template"> The template content. You use this element when you want to pass the template syntax directly in the request rather than link to an existing template. It can be a JObject or well-formed JSON string. Use either the templateLink property or the template property, but not both. </param>
        /// <param name="parameters"> Name and value pairs that define the deployment parameters for the template. You use this element when you want to provide the parameter values directly in the request rather than link to an existing parameter file. Use either the parametersLink property or the parameters property, but not both. It can be a JObject or a well formed JSON string. </param>
        /// <param name="mode"> The mode that is used to deploy resources. This value can be either Incremental or Complete. In Incremental mode, resources are deployed without deleting existing resources that are not included in the template. In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted. Be careful when using Complete mode as you may unintentionally delete resources. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        /// <param name="whatIfSettings"> Optional What-If operation settings. </param>
        internal DeploymentWhatIfProperties(BinaryData template, BinaryData parameters, DeploymentMode mode, IDictionary<string, BinaryData> serializedAdditionalRawData, DeploymentWhatIfSettings whatIfSettings) : base(template, parameters, mode, serializedAdditionalRawData)
        {
            WhatIfSettings = whatIfSettings;
        }

        /// <summary> Initializes a new instance of <see cref="DeploymentWhatIfProperties"/> for deserialization. </summary>
        internal DeploymentWhatIfProperties()
        {
        }

        /// <summary> Optional What-If operation settings. </summary>
        internal DeploymentWhatIfSettings WhatIfSettings { get; set; }
        /// <summary> The format of the What-If results. </summary>
        public WhatIfResultFormat? WhatIfResultFormat
        {
            get => WhatIfSettings is null ? default : WhatIfSettings.ResultFormat;
            set
            {
                if (WhatIfSettings is null)
                    WhatIfSettings = new DeploymentWhatIfSettings();
                WhatIfSettings.ResultFormat = value;
            }
        }
    }
}
