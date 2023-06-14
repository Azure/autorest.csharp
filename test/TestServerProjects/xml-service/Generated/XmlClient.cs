// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using xml_service.Models;

namespace xml_service
{
    /// <summary> The Xml service client. </summary>
    public partial class XmlClient
    {
        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;
        internal XmlRestClient RestClient { get; }

        /// <summary> Initializes a new instance of XmlClient for mocking. </summary>
        protected XmlClient()
        {
        }

        /// <summary> Initializes a new instance of XmlClient. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="clientDiagnostics"/> or <paramref name="pipeline"/> is null. </exception>
        internal XmlClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Uri endpoint = null)
        {
            RestClient = new XmlRestClient(clientDiagnostics, pipeline, endpoint);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
        }

        /// <summary> Get a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RootWithRefAndNoMeta>> GetComplexTypeRefNoMetaAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetComplexTypeRefNoMeta");
            scope.Start();
            try
            {
                return await RestClient.GetComplexTypeRefNoMetaAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RootWithRefAndNoMeta> GetComplexTypeRefNoMeta(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetComplexTypeRefNoMeta");
            scope.Start();
            try
            {
                return RestClient.GetComplexTypeRefNoMeta(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="model"> The RootWithRefAndNoMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutComplexTypeRefNoMetaAsync(RootWithRefAndNoMeta model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutComplexTypeRefNoMeta");
            scope.Start();
            try
            {
                return await RestClient.PutComplexTypeRefNoMetaAsync(model, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts a complex type that has a ref to a complex type with no XML node. </summary>
        /// <param name="model"> The RootWithRefAndNoMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutComplexTypeRefNoMeta(RootWithRefAndNoMeta model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutComplexTypeRefNoMeta");
            scope.Start();
            try
            {
                return RestClient.PutComplexTypeRefNoMeta(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<RootWithRefAndMeta>> GetComplexTypeRefWithMetaAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetComplexTypeRefWithMeta");
            scope.Start();
            try
            {
                return await RestClient.GetComplexTypeRefWithMetaAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<RootWithRefAndMeta> GetComplexTypeRefWithMeta(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetComplexTypeRefWithMeta");
            scope.Start();
            try
            {
                return RestClient.GetComplexTypeRefWithMeta(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="model"> The RootWithRefAndMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutComplexTypeRefWithMetaAsync(RootWithRefAndMeta model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutComplexTypeRefWithMeta");
            scope.Start();
            try
            {
                return await RestClient.PutComplexTypeRefWithMetaAsync(model, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts a complex type that has a ref to a complex type with XML node. </summary>
        /// <param name="model"> The RootWithRefAndMeta to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutComplexTypeRefWithMeta(RootWithRefAndMeta model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutComplexTypeRefWithMeta");
            scope.Start();
            try
            {
                return RestClient.PutComplexTypeRefWithMeta(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a simple XML document. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Slideshow>> GetSimpleAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetSimple");
            scope.Start();
            try
            {
                return await RestClient.GetSimpleAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a simple XML document. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Slideshow> GetSimple(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetSimple");
            scope.Start();
            try
            {
                return RestClient.GetSimple(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a simple XML document. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutSimpleAsync(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutSimple");
            scope.Start();
            try
            {
                return await RestClient.PutSimpleAsync(slideshow, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put a simple XML document. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutSimple(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutSimple");
            scope.Start();
            try
            {
                return RestClient.PutSimple(slideshow, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an XML document with multiple wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AppleBarrel>> GetWrappedListsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetWrappedLists");
            scope.Start();
            try
            {
                return await RestClient.GetWrappedListsAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an XML document with multiple wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AppleBarrel> GetWrappedLists(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetWrappedLists");
            scope.Start();
            try
            {
                return RestClient.GetWrappedLists(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put an XML document with multiple wrapped lists. </summary>
        /// <param name="wrappedLists"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutWrappedListsAsync(AppleBarrel wrappedLists, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutWrappedLists");
            scope.Start();
            try
            {
                return await RestClient.PutWrappedListsAsync(wrappedLists, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put an XML document with multiple wrapped lists. </summary>
        /// <param name="wrappedLists"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutWrappedLists(AppleBarrel wrappedLists, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutWrappedLists");
            scope.Start();
            try
            {
                return RestClient.PutWrappedLists(wrappedLists, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get strongly-typed response headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> GetHeadersAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetHeaders");
            scope.Start();
            try
            {
                return (await RestClient.GetHeadersAsync(cancellationToken).ConfigureAwait(false)).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get strongly-typed response headers. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response GetHeaders(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetHeaders");
            scope.Start();
            try
            {
                return RestClient.GetHeaders(cancellationToken).GetRawResponse();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an empty list. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Slideshow>> GetEmptyListAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetEmptyList");
            scope.Start();
            try
            {
                return await RestClient.GetEmptyListAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an empty list. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Slideshow> GetEmptyList(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetEmptyList");
            scope.Start();
            try
            {
                return RestClient.GetEmptyList(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts an empty list. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutEmptyListAsync(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutEmptyList");
            scope.Start();
            try
            {
                return await RestClient.PutEmptyListAsync(slideshow, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts an empty list. </summary>
        /// <param name="slideshow"> The Slideshow to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutEmptyList(Slideshow slideshow, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutEmptyList");
            scope.Start();
            try
            {
                return RestClient.PutEmptyList(slideshow, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets some empty wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<AppleBarrel>> GetEmptyWrappedListsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetEmptyWrappedLists");
            scope.Start();
            try
            {
                return await RestClient.GetEmptyWrappedListsAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets some empty wrapped lists. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<AppleBarrel> GetEmptyWrappedLists(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetEmptyWrappedLists");
            scope.Start();
            try
            {
                return RestClient.GetEmptyWrappedLists(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts some empty wrapped lists. </summary>
        /// <param name="appleBarrel"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutEmptyWrappedListsAsync(AppleBarrel appleBarrel, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutEmptyWrappedLists");
            scope.Start();
            try
            {
                return await RestClient.PutEmptyWrappedListsAsync(appleBarrel, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts some empty wrapped lists. </summary>
        /// <param name="appleBarrel"> The AppleBarrel to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutEmptyWrappedLists(AppleBarrel appleBarrel, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutEmptyWrappedLists");
            scope.Start();
            try
            {
                return RestClient.PutEmptyWrappedLists(appleBarrel, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<Banana>>> GetRootListAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetRootList");
            scope.Start();
            try
            {
                return await RestClient.GetRootListAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<Banana>> GetRootList(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetRootList");
            scope.Start();
            try
            {
                return RestClient.GetRootList(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts a list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutRootListAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutRootList");
            scope.Start();
            try
            {
                return await RestClient.PutRootListAsync(bananas, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts a list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutRootList(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutRootList");
            scope.Start();
            try
            {
                return RestClient.PutRootList(bananas, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list with a single item. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<Banana>>> GetRootListSingleItemAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetRootListSingleItem");
            scope.Start();
            try
            {
                return await RestClient.GetRootListSingleItemAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a list with a single item. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<Banana>> GetRootListSingleItem(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetRootListSingleItem");
            scope.Start();
            try
            {
                return RestClient.GetRootListSingleItem(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts a list with a single item. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutRootListSingleItemAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutRootListSingleItem");
            scope.Start();
            try
            {
                return await RestClient.PutRootListSingleItemAsync(bananas, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts a list with a single item. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutRootListSingleItem(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutRootListSingleItem");
            scope.Start();
            try
            {
                return RestClient.PutRootListSingleItem(bananas, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets an empty list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<Banana>>> GetEmptyRootListAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetEmptyRootList");
            scope.Start();
            try
            {
                return await RestClient.GetEmptyRootListAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets an empty list as the root element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<Banana>> GetEmptyRootList(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetEmptyRootList");
            scope.Start();
            try
            {
                return RestClient.GetEmptyRootList(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts an empty list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutEmptyRootListAsync(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutEmptyRootList");
            scope.Start();
            try
            {
                return await RestClient.PutEmptyRootListAsync(bananas, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts an empty list as the root element. </summary>
        /// <param name="bananas"> The ArrayOfBanana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutEmptyRootList(IEnumerable<Banana> bananas, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutEmptyRootList");
            scope.Start();
            try
            {
                return RestClient.PutEmptyRootList(bananas, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets an XML document with an empty child element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Banana>> GetEmptyChildElementAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetEmptyChildElement");
            scope.Start();
            try
            {
                return await RestClient.GetEmptyChildElementAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets an XML document with an empty child element. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Banana> GetEmptyChildElement(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetEmptyChildElement");
            scope.Start();
            try
            {
                return RestClient.GetEmptyChildElement(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts a value with an empty child element. </summary>
        /// <param name="banana"> The Banana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutEmptyChildElementAsync(Banana banana, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutEmptyChildElement");
            scope.Start();
            try
            {
                return await RestClient.PutEmptyChildElementAsync(banana, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts a value with an empty child element. </summary>
        /// <param name="banana"> The Banana to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutEmptyChildElement(Banana banana, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutEmptyChildElement");
            scope.Start();
            try
            {
                return RestClient.PutEmptyChildElement(banana, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists containers in a storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ListContainersResponse>> ListContainersAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.ListContainers");
            scope.Start();
            try
            {
                return await RestClient.ListContainersAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists containers in a storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ListContainersResponse> ListContainers(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.ListContainers");
            scope.Start();
            try
            {
                return RestClient.ListContainers(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets storage service properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<StorageServiceProperties>> GetServicePropertiesAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetServiceProperties");
            scope.Start();
            try
            {
                return await RestClient.GetServicePropertiesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets storage service properties. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<StorageServiceProperties> GetServiceProperties(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetServiceProperties");
            scope.Start();
            try
            {
                return RestClient.GetServiceProperties(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts storage service properties. </summary>
        /// <param name="properties"> The StorageServiceProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutServicePropertiesAsync(StorageServiceProperties properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutServiceProperties");
            scope.Start();
            try
            {
                return await RestClient.PutServicePropertiesAsync(properties, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts storage service properties. </summary>
        /// <param name="properties"> The StorageServiceProperties to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutServiceProperties(StorageServiceProperties properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutServiceProperties");
            scope.Start();
            try
            {
                return RestClient.PutServiceProperties(properties, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets storage ACLs for a container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<IReadOnlyList<SignedIdentifier>>> GetAclsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetAcls");
            scope.Start();
            try
            {
                return await RestClient.GetAclsAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets storage ACLs for a container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<IReadOnlyList<SignedIdentifier>> GetAcls(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetAcls");
            scope.Start();
            try
            {
                return RestClient.GetAcls(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts storage ACLs for a container. </summary>
        /// <param name="properties"> The SignedIdentifiers to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutAclsAsync(IEnumerable<SignedIdentifier> properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutAcls");
            scope.Start();
            try
            {
                return await RestClient.PutAclsAsync(properties, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Puts storage ACLs for a container. </summary>
        /// <param name="properties"> The SignedIdentifiers to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutAcls(IEnumerable<SignedIdentifier> properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutAcls");
            scope.Start();
            try
            {
                return RestClient.PutAcls(properties, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists blobs in a storage container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ListBlobsResponse>> ListBlobsAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.ListBlobs");
            scope.Start();
            try
            {
                return await RestClient.ListBlobsAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists blobs in a storage container. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ListBlobsResponse> ListBlobs(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.ListBlobs");
            scope.Start();
            try
            {
                return RestClient.ListBlobs(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> A Swagger with XML that has one operation that takes JSON as input. You need to send the ID number 42. </summary>
        /// <param name="properties"> The JsonInput to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> JsonInputAsync(JsonInput properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.JsonInput");
            scope.Start();
            try
            {
                return await RestClient.JsonInputAsync(properties, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> A Swagger with XML that has one operation that takes JSON as input. You need to send the ID number 42. </summary>
        /// <param name="properties"> The JsonInput to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response JsonInput(JsonInput properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.JsonInput");
            scope.Start();
            try
            {
                return RestClient.JsonInput(properties, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> A Swagger with XML that has one operation that returns JSON. ID number 42. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<JsonOutput>> JsonOutputAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.JsonOutput");
            scope.Start();
            try
            {
                return await RestClient.JsonOutputAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> A Swagger with XML that has one operation that returns JSON. ID number 42. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<JsonOutput> JsonOutput(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.JsonOutput");
            scope.Start();
            try
            {
                return RestClient.JsonOutput(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get back an XML object with an x-ms-text property, which should translate to the returned object's 'language' property being 'english' and its 'content' property being 'I am text'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ObjectWithXMsTextProperty>> GetXMsTextAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetXMsText");
            scope.Start();
            try
            {
                return await RestClient.GetXMsTextAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get back an XML object with an x-ms-text property, which should translate to the returned object's 'language' property being 'english' and its 'content' property being 'I am text'. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ObjectWithXMsTextProperty> GetXMsText(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetXMsText");
            scope.Start();
            try
            {
                return RestClient.GetXMsText(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an XML document with binary property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ModelWithByteProperty>> GetBytesAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetBytes");
            scope.Start();
            try
            {
                return await RestClient.GetBytesAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an XML document with binary property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ModelWithByteProperty> GetBytes(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetBytes");
            scope.Start();
            try
            {
                return RestClient.GetBytes(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put an XML document with binary property. </summary>
        /// <param name="slideshow"> The ModelWithByteProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutBinaryAsync(ModelWithByteProperty slideshow, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutBinary");
            scope.Start();
            try
            {
                return await RestClient.PutBinaryAsync(slideshow, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put an XML document with binary property. </summary>
        /// <param name="slideshow"> The ModelWithByteProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutBinary(ModelWithByteProperty slideshow, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutBinary");
            scope.Start();
            try
            {
                return RestClient.PutBinary(slideshow, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an XML document with uri property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<ModelWithUrlProperty>> GetUriAsync(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetUri");
            scope.Start();
            try
            {
                return await RestClient.GetUriAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get an XML document with uri property. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<ModelWithUrlProperty> GetUri(CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.GetUri");
            scope.Start();
            try
            {
                return RestClient.GetUri(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put an XML document with uri property. </summary>
        /// <param name="model"> The ModelWithUrlProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> PutUriAsync(ModelWithUrlProperty model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutUri");
            scope.Start();
            try
            {
                return await RestClient.PutUriAsync(model, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Put an XML document with uri property. </summary>
        /// <param name="model"> The ModelWithUrlProperty to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response PutUri(ModelWithUrlProperty model, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("XmlClient.PutUri");
            scope.Start();
            try
            {
                return RestClient.PutUri(model, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
