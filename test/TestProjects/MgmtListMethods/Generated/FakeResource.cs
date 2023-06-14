// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
using MgmtListMethods.Models;

namespace MgmtListMethods
{
    /// <summary>
    /// A Class representing a Fake along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="FakeResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetFakeResource method.
    /// Otherwise you can get one from its parent resource <see cref="SubscriptionResource" /> using the GetFake method.
    /// </summary>
    public partial class FakeResource : ArmResource
    {
        /// <summary> Generate the resource identifier of a <see cref="FakeResource"/> instance. </summary>
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string fakeName)
        {
            var resourceId = $"/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}";
            return new ResourceIdentifier(resourceId);
        }

        private readonly ClientDiagnostics _fakeClientDiagnostics;
        private readonly FakesRestOperations _fakeRestClient;
        private readonly FakeData _data;

        /// <summary> Initializes a new instance of the <see cref="FakeResource"/> class for mocking. </summary>
        protected FakeResource()
        {
        }

        /// <summary> Initializes a new instance of the <see cref = "FakeResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="data"> The resource that is the target of operations. </param>
        internal FakeResource(ArmClient client, FakeData data) : this(client, data.Id)
        {
            HasData = true;
            _data = data;
        }

        /// <summary> Initializes a new instance of the <see cref="FakeResource"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        internal FakeResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _fakeClientDiagnostics = new ClientDiagnostics("MgmtListMethods", ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(ResourceType, out string fakeApiVersion);
            _fakeRestClient = new FakesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, fakeApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        /// <summary> Gets the resource type for the operations. </summary>
        public static readonly ResourceType ResourceType = "Microsoft.Fake/fakes";

        /// <summary> Gets whether or not the current instance has data. </summary>
        public virtual bool HasData { get; }

        /// <summary> Gets the data representing this Feature. </summary>
        /// <exception cref="InvalidOperationException"> Throws if there is no data loaded in the current instance. </exception>
        public virtual FakeData Data
        {
            get
            {
                if (!HasData)
                    throw new InvalidOperationException("The current instance does not have data, you must call Get first.");
                return _data;
            }
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceType), nameof(id));
        }

        /// <summary> Gets a collection of FakeParentWithAncestorWithNonResChWithLocResources in the Fake. </summary>
        /// <returns> An object representing collection of FakeParentWithAncestorWithNonResChWithLocResources and their operations over a FakeParentWithAncestorWithNonResChWithLocResource. </returns>
        public virtual FakeParentWithAncestorWithNonResChWithLocCollection GetFakeParentWithAncestorWithNonResChWithLocs()
        {
            return GetCachedClient(Client => new FakeParentWithAncestorWithNonResChWithLocCollection(Client, Id));
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChWithLocs/{fakeParentWithAncestorWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<FakeParentWithAncestorWithNonResChWithLocResource>> GetFakeParentWithAncestorWithNonResChWithLocAsync(string fakeParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            return await GetFakeParentWithAncestorWithNonResChWithLocs().GetAsync(fakeParentWithAncestorWithNonResChWithLocName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChWithLocs/{fakeParentWithAncestorWithNonResChWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<FakeParentWithAncestorWithNonResChWithLocResource> GetFakeParentWithAncestorWithNonResChWithLoc(string fakeParentWithAncestorWithNonResChWithLocName, CancellationToken cancellationToken = default)
        {
            return GetFakeParentWithAncestorWithNonResChWithLocs().Get(fakeParentWithAncestorWithNonResChWithLocName, cancellationToken);
        }

        /// <summary> Gets a collection of FakeParentWithAncestorWithNonResChResources in the Fake. </summary>
        /// <returns> An object representing collection of FakeParentWithAncestorWithNonResChResources and their operations over a FakeParentWithAncestorWithNonResChResource. </returns>
        public virtual FakeParentWithAncestorWithNonResChCollection GetFakeParentWithAncestorWithNonResChes()
        {
            return GetCachedClient(Client => new FakeParentWithAncestorWithNonResChCollection(Client, Id));
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<FakeParentWithAncestorWithNonResChResource>> GetFakeParentWithAncestorWithNonResChAsync(string fakeParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            return await GetFakeParentWithAncestorWithNonResChes().GetAsync(fakeParentWithAncestorWithNonResChName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithNonResChes/{fakeParentWithAncestorWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithNonResChName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<FakeParentWithAncestorWithNonResChResource> GetFakeParentWithAncestorWithNonResCh(string fakeParentWithAncestorWithNonResChName, CancellationToken cancellationToken = default)
        {
            return GetFakeParentWithAncestorWithNonResChes().Get(fakeParentWithAncestorWithNonResChName, cancellationToken);
        }

        /// <summary> Gets a collection of FakeParentWithAncestorWithLocResources in the Fake. </summary>
        /// <returns> An object representing collection of FakeParentWithAncestorWithLocResources and their operations over a FakeParentWithAncestorWithLocResource. </returns>
        public virtual FakeParentWithAncestorWithLocCollection GetFakeParentWithAncestorWithLocs()
        {
            return GetCachedClient(Client => new FakeParentWithAncestorWithLocCollection(Client, Id));
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithLocs/{fakeParentWithAncestorWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<FakeParentWithAncestorWithLocResource>> GetFakeParentWithAncestorWithLocAsync(string fakeParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            return await GetFakeParentWithAncestorWithLocs().GetAsync(fakeParentWithAncestorWithLocName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestorWithLocs/{fakeParentWithAncestorWithLocName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestorWithLocs_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorWithLocName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorWithLocName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorWithLocName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<FakeParentWithAncestorWithLocResource> GetFakeParentWithAncestorWithLoc(string fakeParentWithAncestorWithLocName, CancellationToken cancellationToken = default)
        {
            return GetFakeParentWithAncestorWithLocs().Get(fakeParentWithAncestorWithLocName, cancellationToken);
        }

        /// <summary> Gets a collection of FakeParentWithAncestorResources in the Fake. </summary>
        /// <returns> An object representing collection of FakeParentWithAncestorResources and their operations over a FakeParentWithAncestorResource. </returns>
        public virtual FakeParentWithAncestorCollection GetFakeParentWithAncestors()
        {
            return GetCachedClient(Client => new FakeParentWithAncestorCollection(Client, Id));
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestors_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<FakeParentWithAncestorResource>> GetFakeParentWithAncestorAsync(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            return await GetFakeParentWithAncestors().GetAsync(fakeParentWithAncestorName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithAncestors/{fakeParentWithAncestorName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithAncestors_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithAncestorName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithAncestorName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithAncestorName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<FakeParentWithAncestorResource> GetFakeParentWithAncestor(string fakeParentWithAncestorName, CancellationToken cancellationToken = default)
        {
            return GetFakeParentWithAncestors().Get(fakeParentWithAncestorName, cancellationToken);
        }

        /// <summary> Gets a collection of FakeParentWithNonResChResources in the Fake. </summary>
        /// <returns> An object representing collection of FakeParentWithNonResChResources and their operations over a FakeParentWithNonResChResource. </returns>
        public virtual FakeParentWithNonResChCollection GetFakeParentWithNonResChes()
        {
            return GetCachedClient(Client => new FakeParentWithNonResChCollection(Client, Id));
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<FakeParentWithNonResChResource>> GetFakeParentWithNonResChAsync(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            return await GetFakeParentWithNonResChes().GetAsync(fakeParentWithNonResChName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParentWithNonResChes/{fakeParentWithNonResChName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParentWithNonResChes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentWithNonResChName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentWithNonResChName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentWithNonResChName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<FakeParentWithNonResChResource> GetFakeParentWithNonResCh(string fakeParentWithNonResChName, CancellationToken cancellationToken = default)
        {
            return GetFakeParentWithNonResChes().Get(fakeParentWithNonResChName, cancellationToken);
        }

        /// <summary> Gets a collection of FakeParentResources in the Fake. </summary>
        /// <returns> An object representing collection of FakeParentResources and their operations over a FakeParentResource. </returns>
        public virtual FakeParentCollection GetFakeParents()
        {
            return GetCachedClient(Client => new FakeParentCollection(Client, Id));
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<FakeParentResource>> GetFakeParentAsync(string fakeParentName, CancellationToken cancellationToken = default)
        {
            return await GetFakeParents().GetAsync(fakeParentName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Retrieves information.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/fakeParents/{fakeParentName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>FakeParents_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fakeParentName"> Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="fakeParentName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="fakeParentName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<FakeParentResource> GetFakeParent(string fakeParentName, CancellationToken cancellationToken = default)
        {
            return GetFakeParents().Get(fakeParentName, cancellationToken);
        }

        /// <summary> Gets a collection of FakeConfigurationResources in the Fake. </summary>
        /// <returns> An object representing collection of FakeConfigurationResources and their operations over a FakeConfigurationResource. </returns>
        public virtual FakeConfigurationCollection GetFakeConfigurations()
        {
            return GetCachedClient(Client => new FakeConfigurationCollection(Client, Id));
        }

        /// <summary>
        /// Get configuration for each VM family in workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/configurations/{configurationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Configurations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="configurationName"> The name of the configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual async Task<Response<FakeConfigurationResource>> GetFakeConfigurationAsync(string configurationName, CancellationToken cancellationToken = default)
        {
            return await GetFakeConfigurations().GetAsync(configurationName, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get configuration for each VM family in workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/configurations/{configurationName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Configurations_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="configurationName"> The name of the configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="configurationName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="configurationName"/> is null. </exception>
        [ForwardsClientCalls]
        public virtual Response<FakeConfigurationResource> GetFakeConfiguration(string configurationName, CancellationToken cancellationToken = default)
        {
            return GetFakeConfigurations().Get(configurationName, cancellationToken);
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<FakeResource>> GetAsync(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _fakeClientDiagnostics.CreateScope("FakeResource.Get");
            scope.Start();
            try
            {
                var response = await _fakeRestClient.GetAsync(Id.SubscriptionId, Id.Name, expand, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Retrieves information about an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="expand"> May be used to expand the participants. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<FakeResource> Get(string expand = null, CancellationToken cancellationToken = default)
        {
            using var scope = _fakeClientDiagnostics.CreateScope("FakeResource.Get");
            scope.Start();
            try
            {
                var response = _fakeRestClient.Get(Id.SubscriptionId, Id.Name, expand, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new FakeResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<FakeResource>> UpdateAsync(WaitUntil waitUntil, FakeData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeResource.Update");
            scope.Start();
            try
            {
                var response = await _fakeRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.Name, data, cancellationToken).ConfigureAwait(false);
                var operation = new MgmtListMethodsArmOperation<FakeResource>(Response.FromValue(new FakeResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or update an fake.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_CreateOrUpdate</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="data"> Parameters supplied to the Create Availability Set operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<FakeResource> Update(WaitUntil waitUntil, FakeData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeResource.Update");
            scope.Start();
            try
            {
                var response = _fakeRestClient.CreateOrUpdate(Id.SubscriptionId, Id.Name, data, cancellationToken);
                var operation = new MgmtListMethodsArmOperation<FakeResource>(Response.FromValue(new FakeResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Update configurations for each VM family in workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/updateConfigurations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_UpdateConfigurations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value"> The parameters for updating a list of fake configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <returns> An async collection of <see cref="FakeConfigurationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<FakeConfigurationResource> UpdateConfigurationsAsync(FakeConfigurationListResult value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(value, nameof(value));

            HttpMessage FirstPageRequest(int? pageSizeHint) => _fakeRestClient.CreateUpdateConfigurationsRequest(Id.SubscriptionId, Id.Name, value);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new FakeConfigurationResource(Client, FakeConfigurationData.DeserializeFakeConfigurationData(e)), _fakeClientDiagnostics, Pipeline, "FakeResource.UpdateConfigurations", "value", null, cancellationToken);
        }

        /// <summary>
        /// Update configurations for each VM family in workspace.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}/updateConfigurations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_UpdateConfigurations</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="value"> The parameters for updating a list of fake configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <returns> A collection of <see cref="FakeConfigurationResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<FakeConfigurationResource> UpdateConfigurations(FakeConfigurationListResult value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(value, nameof(value));

            HttpMessage FirstPageRequest(int? pageSizeHint) => _fakeRestClient.CreateUpdateConfigurationsRequest(Id.SubscriptionId, Id.Name, value);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, e => new FakeConfigurationResource(Client, FakeConfigurationData.DeserializeFakeConfigurationData(e)), _fakeClientDiagnostics, Pipeline, "FakeResource.UpdateConfigurations", "value", null, cancellationToken);
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<FakeResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeResource.AddTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues[key] = value;
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _fakeRestClient.GetAsync(Id.SubscriptionId, Id.Name, null, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new FakeResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags[key] = value;
                    var result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<FakeResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeResource.AddTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues[key] = value;
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _fakeRestClient.Get(Id.SubscriptionId, Id.Name, null, cancellationToken);
                    return Response.FromValue(new FakeResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags[key] = value;
                    var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<FakeResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeResource.SetTags");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    await GetTagResource().DeleteAsync(WaitUntil.Completed, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _fakeRestClient.GetAsync(Id.SubscriptionId, Id.Name, null, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new FakeResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    var result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<FakeResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeResource.SetTags");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    GetTagResource().Delete(WaitUntil.Completed, cancellationToken: cancellationToken);
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.ReplaceWith(tags);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _fakeRestClient.Get(Id.SubscriptionId, Id.Name, null, cancellationToken);
                    return Response.FromValue(new FakeResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.ReplaceWith(tags);
                    var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<FakeResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeResource.RemoveTag");
            scope.Start();
            try
            {
                if (await CanUseTagResourceAsync(cancellationToken: cancellationToken).ConfigureAwait(false))
                {
                    var originalTags = await GetTagResource().GetAsync(cancellationToken).ConfigureAwait(false);
                    originalTags.Value.Data.TagValues.Remove(key);
                    await GetTagResource().CreateOrUpdateAsync(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken).ConfigureAwait(false);
                    var originalResponse = await _fakeRestClient.GetAsync(Id.SubscriptionId, Id.Name, null, cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(new FakeResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                    current.Tags.Remove(key);
                    var result = await UpdateAsync(WaitUntil.Completed, current, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/providers/Microsoft.Fake/fakes/{fakeName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Fakes_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<FakeResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _fakeClientDiagnostics.CreateScope("FakeResource.RemoveTag");
            scope.Start();
            try
            {
                if (CanUseTagResource(cancellationToken: cancellationToken))
                {
                    var originalTags = GetTagResource().Get(cancellationToken);
                    originalTags.Value.Data.TagValues.Remove(key);
                    GetTagResource().CreateOrUpdate(WaitUntil.Completed, originalTags.Value.Data, cancellationToken: cancellationToken);
                    var originalResponse = _fakeRestClient.Get(Id.SubscriptionId, Id.Name, null, cancellationToken);
                    return Response.FromValue(new FakeResource(Client, originalResponse.Value), originalResponse.GetRawResponse());
                }
                else
                {
                    var current = Get(cancellationToken: cancellationToken).Value.Data;
                    current.Tags.Remove(key);
                    var result = Update(WaitUntil.Completed, current, cancellationToken: cancellationToken);
                    return Response.FromValue(result.Value, result.GetRawResponse());
                }
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
