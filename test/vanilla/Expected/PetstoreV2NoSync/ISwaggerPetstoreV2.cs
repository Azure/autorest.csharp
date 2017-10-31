// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>

namespace Fixtures.PetstoreV2NoSync
{
    using Models;
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// This is a sample server Petstore server.  You can find out more about Swagger at &lt;a
    /// href="http://swagger.io"&gt;http://swagger.io&lt;/a&gt; or on irc.freenode.net, #swagger.  For this sample, you
    /// can use the api key "special-key" to test the authorization filters
    /// </summary>
    public partial interface ISwaggerPetstoreV2 : System.IDisposable
    {
        /// <summary>
        /// Gets or sets the base URI of the service.
        /// </summary>
        System.Uri BaseUri { get; set; }

        /// <summary>
        /// Gets or sets JSON serialization settings.
        /// </summary>
        JsonSerializerSettings SerializationSettings { get; }

        /// <summary>
        /// Gets or sets JSON deserialization settings.
        /// </summary>
        JsonSerializerSettings DeserializationSettings { get; }


        /// <summary>
        /// Add a new pet to the store
        /// </summary>
        /// <param name='body'>
        /// Pet object that needs to be added to the store
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<Pet> AddPetAsync(Pet body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Update an existing pet
        /// </summary>
        /// <param name='body'>
        /// Pet object that needs to be added to the store
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task UpdatePetAsync(Pet body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Finds Pets by status
        /// </summary>
        /// <remarks>
        /// Multiple status values can be provided with comma seperated strings
        /// </remarks>
        /// <param name='status'>
        /// Status values that need to be considered for filter
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<IList<Pet>> FindPetsByStatusAsync(IList<string> status, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Finds Pets by tags
        /// </summary>
        /// <remarks>
        /// Muliple tags can be provided with comma seperated strings. Use tag1, tag2, tag3 for testing.
        /// </remarks>
        /// <param name='tags'>
        /// Tags to filter by
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<IList<Pet>> FindPetsByTagsAsync(IList<string> tags, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Find pet by Id
        /// </summary>
        /// <remarks>
        /// Returns a single pet
        /// </remarks>
        /// <param name='petId'>
        /// Id of pet to return
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<Pet> GetPetByIdAsync(long petId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Updates a pet in the store with form data
        /// </summary>
        /// <param name='petId'>
        /// Id of pet that needs to be updated
        /// </param>
        /// <param name='fileContent'>
        /// File to upload.
        /// </param>
        /// <param name='fileName'>
        /// Updated name of the pet
        /// </param>
        /// <param name='status'>
        /// Updated status of the pet
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task UpdatePetWithFormAsync(long petId, Stream fileContent, string fileName = default(string), string status = default(string), CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Deletes a pet
        /// </summary>
        /// <param name='petId'>
        /// Pet id to delete
        /// </param>
        /// <param name='apiKey'>
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task DeletePetAsync(long petId, string apiKey = "", CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Returns pet inventories by status
        /// </summary>
        /// <remarks>
        /// Returns a map of status codes to quantities
        /// </remarks>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<IDictionary<string, int?>> GetInventoryAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Place an order for a pet
        /// </summary>
        /// <param name='body'>
        /// order placed for purchasing the pet
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<Order> PlaceOrderAsync(Order body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Find purchase order by Id
        /// </summary>
        /// <remarks>
        /// For valid response try integer IDs with value &lt;= 5 or &gt; 10. Other values will generated exceptions
        /// </remarks>
        /// <param name='orderId'>
        /// Id of pet that needs to be fetched
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<Order> GetOrderByIdAsync(string orderId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete purchase order by Id
        /// </summary>
        /// <remarks>
        /// For valid response try integer IDs with value &lt; 1000. Anything above 1000 or nonintegers will generate API
        /// errors
        /// </remarks>
        /// <param name='orderId'>
        /// Id of the order that needs to be deleted
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task DeleteOrderAsync(string orderId, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Create user
        /// </summary>
        /// <remarks>
        /// This can only be done by the logged in user.
        /// </remarks>
        /// <param name='body'>
        /// Created user object
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task CreateUserAsync(User body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name='body'>
        /// List of user object
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task CreateUsersWithArrayInputAsync(IList<User> body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Creates list of users with given input array
        /// </summary>
        /// <param name='body'>
        /// List of user object
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task CreateUsersWithListInputAsync(IList<User> body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Logs user into the system
        /// </summary>
        /// <param name='username'>
        /// The user name for login
        /// </param>
        /// <param name='password'>
        /// The password for login in clear text
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<string> LoginUserAsync(string username, string password, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Logs out current logged in user session
        /// </summary>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task LogoutUserAsync(CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Get user by user name
        /// </summary>
        /// <param name='username'>
        /// The name that needs to be fetched. Use user1 for testing.
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task<User> GetUserByNameAsync(string username, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Updated user
        /// </summary>
        /// <remarks>
        /// This can only be done by the logged in user.
        /// </remarks>
        /// <param name='username'>
        /// name that need to be deleted
        /// </param>
        /// <param name='body'>
        /// Updated user object
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task UpdateUserAsync(string username, User body, CancellationToken cancellationToken = default(CancellationToken));
        /// <summary>
        /// Delete user
        /// </summary>
        /// <remarks>
        /// This can only be done by the logged in user.
        /// </remarks>
        /// <param name='username'>
        /// The name that needs to be deleted
        /// </param>
        /// <param name='cancellationToken'>
        /// The cancellation token.
        /// </param>
        Task DeleteUserAsync(string username, CancellationToken cancellationToken = default(CancellationToken));
    }
}
