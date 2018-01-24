namespace Fixtures.HiddenMethods
{
    using Microsoft.Rest;
    using Models;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// BasicOperations operations.
    /// </summary>
    public partial interface IBasicOperations
    {
        /// <summary>
        /// Accepts a name, color and optional id
        /// </summary>
        /// <param name='name'>
        /// The name
        /// </param>
        /// <param name='color'>
        /// The color
        /// </param>
        /// <param name='id'>
        /// The id
        /// </param>
        /// <param name='customHeaders'>
        /// The headers that will be added to request.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        /// <exception cref="ErrorException">
        /// Thrown when the operation returned an invalid status code
        /// </exception>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown when a required parameter is null
        /// </exception>
        Task PutValidAsync(string name, string color, int? id = null, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}