// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.Resources.Sample
{
    /// <summary> Deployment properties. </summary>
    public partial class DeploymentProperties
    {
        /// <summary> Initializes a new instance of DeploymentProperties. </summary>
        /// <param name="mode"> The mode that is used to deploy resources. This value can be either Incremental or Complete. In Incremental mode, resources are deployed without deleting existing resources that are not included in the template. In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted. Be careful when using Complete mode as you may unintentionally delete resources. </param>
        public DeploymentProperties(DeploymentMode mode)
        {
            Mode = mode;
        }

        /// <summary> The template content. You use this element when you want to pass the template syntax directly in the request rather than link to an existing template. It can be a JObject or well-formed JSON string. Use either the templateLink property or the template property, but not both. </summary>
        public object Template { get; set; }
        /// <summary> The URI of the template. Use either the templateLink property or the template property, but not both. </summary>
        public TemplateLink TemplateLink { get; set; }
        /// <summary> Name and value pairs that define the deployment parameters for the template. You use this element when you want to provide the parameter values directly in the request rather than link to an existing parameter file. Use either the parametersLink property or the parameters property, but not both. It can be a JObject or a well formed JSON string. </summary>
        public object Parameters { get; set; }
        /// <summary> The URI of parameters file. You use this element to link to an existing parameters file. Use either the parametersLink property or the parameters property, but not both. </summary>
        public ParametersLink ParametersLink { get; set; }
        /// <summary> The mode that is used to deploy resources. This value can be either Incremental or Complete. In Incremental mode, resources are deployed without deleting existing resources that are not included in the template. In Complete mode, resources are deployed and existing resources in the resource group that are not included in the template are deleted. Be careful when using Complete mode as you may unintentionally delete resources. </summary>
        public DeploymentMode Mode { get; }
        /// <summary> The debug setting of the deployment. </summary>
        public DebugSetting DebugSetting { get; set; }
        /// <summary> The deployment on error behavior. </summary>
        public OnErrorDeployment OnErrorDeployment { get; set; }
        /// <summary> Specifies whether template expressions are evaluated within the scope of the parent template or nested template. Only applicable to nested templates. If not specified, default value is outer. </summary>
        public ExpressionEvaluationOptions ExpressionEvaluationOptions { get; set; }
    }
}
