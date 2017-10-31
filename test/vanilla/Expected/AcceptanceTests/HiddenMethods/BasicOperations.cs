// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.AcceptanceTestsHiddenMethods
{
    using Microsoft.Rest;
    using Models;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// BasicOperations operations.
    /// </summary>
    public partial class BasicOperations : IBasicOperations
    {
        /// <summary>
        /// Initializes a new instance of the BasicOperations class.
        /// </summary>
        /// <param name='operationsWithHttpMessages'>
        /// Reference to the low level operations
        /// </param>
        /// <exception cref='System.ArgumentNullException'>
        /// Thrown when a required parameter is null.
        /// </exception>
        public BasicOperations(IBasicOperationsWithHttpMessages operationsWithHttpMessages)
        {
            if (operationsWithHttpMessages == null)
            {
                throw new System.ArgumentNullException(nameof(operationsWithHttpMessages));
            }
            OperationsWithHttpMessages = operationsWithHttpMessages;
        }

        private IBasicOperationsWithHttpMessages OperationsWithHttpMessages { get; set; }

        public IBasicOperationsWithHttpMessages WithHttpMessages()
        {
            return OperationsWithHttpMessages;
        }

        /// <summary>
        /// Get complex type {id: 2, name: 'abc', color: 'YELLOW'}
        /// </summary>
        public Basic GetValid()
        {
            return GetValidAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get complex type {id: 2, name: 'abc', color: 'YELLOW'}
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<Basic> GetValidAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await OperationsWithHttpMessages.GetValidAsync(null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get a basic complex type that is invalid for the local strong type
        /// </summary>
        public Basic GetInvalid()
        {
            return GetInvalidAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a basic complex type that is invalid for the local strong type
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<Basic> GetInvalidAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await OperationsWithHttpMessages.GetInvalidAsync(null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get a basic complex type that is empty
        /// </summary>
        public Basic GetEmpty()
        {
            return GetEmptyAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a basic complex type that is empty
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<Basic> GetEmptyAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await OperationsWithHttpMessages.GetEmptyAsync(null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get a basic complex type whose properties are null
        /// </summary>
        public Basic GetNull()
        {
            return GetNullAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a basic complex type whose properties are null
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<Basic> GetNullAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await OperationsWithHttpMessages.GetNullAsync(null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

        /// <summary>
        /// Get a basic complex type while the server doesn't provide a response payload
        /// </summary>
        public Basic GetNotProvided()
        {
            return GetNotProvidedAsync().GetAwaiter().GetResult();
        }

        /// <summary>
        /// Get a basic complex type while the server doesn't provide a response payload
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        public async Task<Basic> GetNotProvidedAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var _result = await OperationsWithHttpMessages.GetNotProvidedAsync(null, cancellationToken).ConfigureAwait(false))
            {
                return _result.Body;
            }
        }

    }
}
