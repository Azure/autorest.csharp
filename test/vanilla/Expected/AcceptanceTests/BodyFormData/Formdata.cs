// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsBodyFormData
{
    using Microsoft.Rest;
    using Models;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Formdata operations.
    /// </summary>
    public partial class Formdata : IFormdata
    {
        /// <summary>
        /// Initializes a new instance of the Formdata class.
        /// </summary>
        /// <param name='operationsWithHttpMessages'>
        /// Reference to the low level operations
        /// </param>
        /// <exception cref='System.ArgumentNullException'>
        /// Thrown when a required parameter is null.
        /// </exception>
        public Formdata(IFormdataWithHttpMessages operationsWithHttpMessages)
        {
            if (operationsWithHttpMessages == null)
            {
                throw new System.ArgumentNullException(nameof(operationsWithHttpMessages));
            }
            OperationsWithHttpMessages = operationsWithHttpMessages;
        }

        private IFormdataWithHttpMessages OperationsWithHttpMessages { get; set; }

        public IFormdataWithHttpMessages WithHttpMessages()
        {
            return OperationsWithHttpMessages;
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name='fileContent'>
        /// File to upload.
        /// </param>
        /// <param name='fileName'>
        /// File name to upload. Name has to be spelled exactly as written here.
        /// </param>
        public Stream UploadFile(Stream fileContent, string fileName)
        {
            return UploadFileAsync(fileContent, fileName).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name='fileContent'>
        /// File to upload.
        /// </param>
        /// <param name='fileName'>
        /// File name to upload. Name has to be spelled exactly as written here.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<Stream> UploadFileAsync(Stream fileContent, string fileName, CancellationToken cancellationToken = default(CancellationToken))
        {
            var _result = await OperationsWithHttpMessages.UploadFileAsync(fileContent, fileName, null, cancellationToken).ConfigureAwait(false);
            _result.Request.Dispose();
            return _result.Body;
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name='fileContent'>
        /// File to upload.
        /// </param>
        public Stream UploadFileViaBody(Stream fileContent)
        {
            return UploadFileViaBodyAsync(fileContent).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Upload file
        /// </summary>
        /// <param name='fileContent'>
        /// File to upload.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<Stream> UploadFileViaBodyAsync(Stream fileContent, CancellationToken cancellationToken = default(CancellationToken))
        {
            var _result = await OperationsWithHttpMessages.UploadFileViaBodyAsync(fileContent, null, cancellationToken).ConfigureAwait(false);
            _result.Request.Dispose();
            return _result.Body;
        }

    }
}
