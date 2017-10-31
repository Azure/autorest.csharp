// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.Azure.AcceptanceTestsAzureSpecials
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// XMsClientRequestIdOperations operations.
    /// </summary>
    public partial class XMsClientRequestIdOperations : IXMsClientRequestIdOperations
    {
        /// <summary>
        /// Initializes a new instance of the XMsClientRequestIdOperations class.
        /// </summary>
        /// <param name='operationsWithHttpMessages'>
        /// Reference to the low level operations
        /// </param>
        /// <exception cref='System.ArgumentNullException'>
        /// Thrown when a required parameter is null.
        /// </exception>
        public XMsClientRequestIdOperations(IXMsClientRequestIdOperationsWithHttpMessages operationsWithHttpMessages)
        {
            if (operationsWithHttpMessages == null)
            {
                throw new System.ArgumentNullException(nameof(operationsWithHttpMessages));
            }
            OperationsWithHttpMessages = operationsWithHttpMessages;
        }

        private IXMsClientRequestIdOperationsWithHttpMessages OperationsWithHttpMessages { get; set; }

        public IXMsClientRequestIdOperationsWithHttpMessages WithHttpMessages()
        {
            return OperationsWithHttpMessages;
        }

        /// <summary>
        /// Get method that overwrites x-ms-client-request header with value 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0.
        /// </summary>
        public void Get()
        {
            GetAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get method that overwrites x-ms-client-request header with value 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0.
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task GetAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            (await OperationsWithHttpMessages.GetAsync(null, cancellationToken).ConfigureAwait(false)).Dispose();
        }

        /// <summary>
        /// Get method that overwrites x-ms-client-request header with value 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0.
        /// </summary>
        /// <param name='xMsClientRequestId'>
        /// This should appear as a method parameter, use value '9C4D50EE-2D56-4CD3-8152-34347DC9F2B0'
        /// </param>
        public void ParamGet(string xMsClientRequestId)
        {
            ParamGetAsync(xMsClientRequestId).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get method that overwrites x-ms-client-request header with value 9C4D50EE-2D56-4CD3-8152-34347DC9F2B0.
        /// </summary>
        /// <param name='xMsClientRequestId'>
        /// This should appear as a method parameter, use value '9C4D50EE-2D56-4CD3-8152-34347DC9F2B0'
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task ParamGetAsync(string xMsClientRequestId, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await OperationsWithHttpMessages.ParamGetAsync(xMsClientRequestId, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }

    }
}
