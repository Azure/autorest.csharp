// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.Azure.AcceptanceTestsCustomBaseUri
{
    using Microsoft.Rest;
    using Microsoft.Rest.Azure;
    using Models;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// PathsOperations operations.
    /// </summary>
    public partial class PathsOperations : IPathsOperations
    {
        /// <summary>
        /// Initializes a new instance of the PathsOperations class.
        /// </summary>
        /// <param name='operationsWithHttpMessages'>
        /// Reference to the low level operations
        /// </param>
        /// <exception cref='System.ArgumentNullException'>
        /// Thrown when a required parameter is null.
        /// </exception>
        public PathsOperations(IPathsOperationsWithHttpMessages operationsWithHttpMessages)
        {
            if (operationsWithHttpMessages == null)
            {
                throw new System.ArgumentNullException(nameof(operationsWithHttpMessages));
            }
            OperationsWithHttpMessages = operationsWithHttpMessages;
        }

        private IPathsOperationsWithHttpMessages OperationsWithHttpMessages { get; set; }

        public IPathsOperationsWithHttpMessages WithHttpMessages()
        {
            return OperationsWithHttpMessages;
        }

        /// <summary>
        /// Get a 200 to test a valid base uri
        /// </summary>
        /// <param name='accountName'>
        /// Account Name
        /// </param>
        public void GetEmpty(string accountName)
        {
            GetEmptyAsync(accountName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a 200 to test a valid base uri
        /// </summary>
        /// <param name='accountName'>
        /// Account Name
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task GetEmptyAsync(string accountName, CancellationToken cancellationToken = default(CancellationToken))
        {
            (await OperationsWithHttpMessages.GetEmptyAsync(accountName, null, cancellationToken).ConfigureAwait(false)).Dispose();
        }

    }
}
