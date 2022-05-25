// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Output.Models.Requests;

namespace AutoRest.CSharp.Output.Models
{
    internal record LowLevelClientMethod(MethodSignature Signature, RestClientMethod RequestMethod, LowLevelOperationSchemaInfo OperationSchemas, Diagnostic Diagnostic, LowLevelPagingInfo? PagingInfo, bool IsLongRunning)
    {
        /// <summary>
        /// Whether the protocol method is a paging method.
        /// </summary>
        public bool IsPaging => PagingInfo != null;

        public LowLevelClientMethod CloneWithAllParametersRequired()
        {
            return this with
            {
                Signature = Signature.CloneWithAllParametersRequired(),
            };
        }
    }

}
