// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace MgmtScopeResource.Models
{
    /// <summary> Information from validate template deployment response. </summary>
    public partial class DeploymentValidateResult
    {
        /// <summary> Initializes a new instance of DeploymentValidateResult. </summary>
        internal DeploymentValidateResult()
        {
        }

        /// <summary> Initializes a new instance of DeploymentValidateResult. </summary>
        /// <param name="errorResponse"> The deployment validation error. </param>
        /// <param name="properties"> The template deployment properties. </param>
        internal DeploymentValidateResult(ErrorResponse errorResponse, DeploymentPropertiesExtended properties)
        {
            ErrorResponse = errorResponse;
            Properties = properties;
        }

        /// <summary> The deployment validation error. </summary>
        internal ErrorResponse ErrorResponse { get; }
        /// <summary> The details of the error. </summary>
        public string Error
        {
            get => ErrorResponse?.Error;
        }

        /// <summary> The template deployment properties. </summary>
        public DeploymentPropertiesExtended Properties { get; }
    }
}
