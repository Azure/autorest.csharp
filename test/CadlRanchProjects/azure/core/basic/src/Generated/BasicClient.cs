// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using _Specs_.Azure.Core.Basic.Models;

namespace _Specs_.Azure.Core.Basic
{
    // Data plane generated client.
    /// <summary> Illustrates bodies templated with Azure Core. </summary>
    public partial class BasicClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of BasicClient. </summary>
        public BasicClient() : this(new Uri("http://localhost:3000"), new BasicClientOptions())
        {
        }

        /// <summary> Initializes a new instance of BasicClient. </summary>
        /// <param name="endpoint"> TestServer endpoint. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public BasicClient(Uri endpoint, BasicClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new BasicClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary>
        /// [Protocol Method] Adds a user or updates a user's fields.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='CreateOrUpdateAsync(int,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> CreateOrUpdateAsync(int id, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("BasicClient.CreateOrUpdate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateOrUpdateRequest(id, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Adds a user or updates a user's fields.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='CreateOrUpdate(int,RequestContent,RequestContext)']/*" />
        public virtual Response CreateOrUpdate(int id, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("BasicClient.CreateOrUpdate");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateOrUpdateRequest(id, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Adds a user or replaces a user's fields. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="resource"> The resource instance. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resource"/> is null. </exception>
        /// <remarks> Creates or replaces a User. </remarks>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='CreateOrReplaceAsync(int,User,CancellationToken)']/*" />
        public virtual async Task<Response<User>> CreateOrReplaceAsync(int id, User resource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resource, nameof(resource));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await CreateOrReplaceAsync(id, resource.ToRequestContent(), context).ConfigureAwait(false);
            return Response.FromValue(User.FromResponse(response), response);
        }

        /// <summary> Adds a user or replaces a user's fields. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="resource"> The resource instance. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="resource"/> is null. </exception>
        /// <remarks> Creates or replaces a User. </remarks>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='CreateOrReplace(int,User,CancellationToken)']/*" />
        public virtual Response<User> CreateOrReplace(int id, User resource, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(resource, nameof(resource));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = CreateOrReplace(id, resource.ToRequestContent(), context);
            return Response.FromValue(User.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Adds a user or replaces a user's fields.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateOrReplaceAsync(int,User,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='CreateOrReplaceAsync(int,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> CreateOrReplaceAsync(int id, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("BasicClient.CreateOrReplace");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateOrReplaceRequest(id, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Adds a user or replaces a user's fields.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateOrReplace(int,User,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='CreateOrReplace(int,RequestContent,RequestContext)']/*" />
        public virtual Response CreateOrReplace(int id, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("BasicClient.CreateOrReplace");
            scope.Start();
            try
            {
                using HttpMessage message = CreateCreateOrReplaceRequest(id, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a user. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Gets a User. </remarks>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetUserAsync(int,CancellationToken)']/*" />
        public virtual async Task<Response<User>> GetUserAsync(int id, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await GetUserAsync(id, context).ConfigureAwait(false);
            return Response.FromValue(User.FromResponse(response), response);
        }

        /// <summary> Gets a user. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Gets a User. </remarks>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetUser(int,CancellationToken)']/*" />
        public virtual Response<User> GetUser(int id, CancellationToken cancellationToken = default)
        {
            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = GetUser(id, context);
            return Response.FromValue(User.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Gets a user.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetUserAsync(int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetUserAsync(int,RequestContext)']/*" />
        public virtual async Task<Response> GetUserAsync(int id, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("BasicClient.GetUser");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetUserRequest(id, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Gets a user.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetUser(int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetUser(int,RequestContext)']/*" />
        public virtual Response GetUser(int id, RequestContext context)
        {
            using var scope = ClientDiagnostics.CreateScope("BasicClient.GetUser");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetUserRequest(id, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Deletes a user.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='DeleteAsync(int,RequestContext)']/*" />
        public virtual async Task<Response> DeleteAsync(int id, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BasicClient.Delete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteRequest(id, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Deletes a user.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='Delete(int,RequestContext)']/*" />
        public virtual Response Delete(int id, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("BasicClient.Delete");
            scope.Start();
            try
            {
                using HttpMessage message = CreateDeleteRequest(id, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Exports a user. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="format"> The format of the data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="format"/> is null. </exception>
        /// <remarks> Exports a User. </remarks>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='ExportAsync(int,string,CancellationToken)']/*" />
        public virtual async Task<Response<User>> ExportAsync(int id, string format, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(format, nameof(format));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await ExportAsync(id, format, context).ConfigureAwait(false);
            return Response.FromValue(User.FromResponse(response), response);
        }

        /// <summary> Exports a user. </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="format"> The format of the data. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="format"/> is null. </exception>
        /// <remarks> Exports a User. </remarks>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='Export(int,string,CancellationToken)']/*" />
        public virtual Response<User> Export(int id, string format, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(format, nameof(format));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = Export(id, format, context);
            return Response.FromValue(User.FromResponse(response), response);
        }

        /// <summary>
        /// [Protocol Method] Exports a user.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="ExportAsync(int,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="format"> The format of the data. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="format"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='ExportAsync(int,string,RequestContext)']/*" />
        public virtual async Task<Response> ExportAsync(int id, string format, RequestContext context)
        {
            Argument.AssertNotNull(format, nameof(format));

            using var scope = ClientDiagnostics.CreateScope("BasicClient.Export");
            scope.Start();
            try
            {
                using HttpMessage message = CreateExportRequest(id, format, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Exports a user.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Export(int,string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The user's id. </param>
        /// <param name="format"> The format of the data. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="format"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='Export(int,string,RequestContext)']/*" />
        public virtual Response Export(int id, string format, RequestContext context)
        {
            Argument.AssertNotNull(format, nameof(format));

            using var scope = ClientDiagnostics.CreateScope("BasicClient.Export");
            scope.Start();
            try
            {
                using HttpMessage message = CreateExportRequest(id, format, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Lists all users. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="orderby"> Expressions that specify the order of returned results. </param>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="select"> Select the specified fields to be included in the response. </param>
        /// <param name="expand"> Expand the indicated resources into the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Lists all Users. </remarks>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetUsersAsync(int?,int?,int?,IEnumerable{string},string,IEnumerable{string},IEnumerable{string},CancellationToken)']/*" />
        public virtual AsyncPageable<User> GetUsersAsync(int? maxCount = null, int? skip = null, int? maxpagesize = null, IEnumerable<string> orderby = null, string filter = null, IEnumerable<string> select = null, IEnumerable<string> expand = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetUsersRequest(maxCount, skip, maxpagesize, orderby, filter, select, expand, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetUsersNextPageRequest(nextLink, maxCount, skip, maxpagesize, orderby, filter, select, expand, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, User.DeserializeUser, ClientDiagnostics, _pipeline, "BasicClient.GetUsers", "value", "nextLink", context);
        }

        /// <summary> Lists all users. </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="orderby"> Expressions that specify the order of returned results. </param>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="select"> Select the specified fields to be included in the response. </param>
        /// <param name="expand"> Expand the indicated resources into the response. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <remarks> Lists all Users. </remarks>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetUsers(int?,int?,int?,IEnumerable{string},string,IEnumerable{string},IEnumerable{string},CancellationToken)']/*" />
        public virtual Pageable<User> GetUsers(int? maxCount = null, int? skip = null, int? maxpagesize = null, IEnumerable<string> orderby = null, string filter = null, IEnumerable<string> select = null, IEnumerable<string> expand = null, CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetUsersRequest(maxCount, skip, maxpagesize, orderby, filter, select, expand, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetUsersNextPageRequest(nextLink, maxCount, skip, maxpagesize, orderby, filter, select, expand, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, User.DeserializeUser, ClientDiagnostics, _pipeline, "BasicClient.GetUsers", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Lists all users.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetUsersAsync(int?,int?,int?,IEnumerable{string},string,IEnumerable{string},IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="orderby"> Expressions that specify the order of returned results. </param>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="select"> Select the specified fields to be included in the response. </param>
        /// <param name="expand"> Expand the indicated resources into the response. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetUsersAsync(int?,int?,int?,IEnumerable{string},string,IEnumerable{string},IEnumerable{string},RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetUsersAsync(int? maxCount, int? skip, int? maxpagesize, IEnumerable<string> orderby, string filter, IEnumerable<string> select, IEnumerable<string> expand, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetUsersRequest(maxCount, skip, maxpagesize, orderby, filter, select, expand, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetUsersNextPageRequest(nextLink, maxCount, skip, maxpagesize, orderby, filter, select, expand, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "BasicClient.GetUsers", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] Lists all users.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetUsers(int?,int?,int?,IEnumerable{string},string,IEnumerable{string},IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="maxCount"> The number of result items to return. </param>
        /// <param name="skip"> The number of result items to skip. </param>
        /// <param name="maxpagesize"> The maximum number of result items per page. </param>
        /// <param name="orderby"> Expressions that specify the order of returned results. </param>
        /// <param name="filter"> Filter the result list using the given expression. </param>
        /// <param name="select"> Select the specified fields to be included in the response. </param>
        /// <param name="expand"> Expand the indicated resources into the response. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetUsers(int?,int?,int?,IEnumerable{string},string,IEnumerable{string},IEnumerable{string},RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetUsers(int? maxCount, int? skip, int? maxpagesize, IEnumerable<string> orderby, string filter, IEnumerable<string> select, IEnumerable<string> expand, RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetUsersRequest(maxCount, skip, maxpagesize, orderby, filter, select, expand, context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetUsersNextPageRequest(nextLink, maxCount, skip, maxpagesize, orderby, filter, select, expand, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "BasicClient.GetUsers", "value", "nextLink", context);
        }

        /// <summary> List with Azure.Core.Page&lt;&gt;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetWithPageAsync(CancellationToken)']/*" />
        public virtual AsyncPageable<User> GetWithPageAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWithPageRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetWithPageNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, User.DeserializeUser, ClientDiagnostics, _pipeline, "BasicClient.GetWithPage", "value", "nextLink", context);
        }

        /// <summary> List with Azure.Core.Page&lt;&gt;. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetWithPage(CancellationToken)']/*" />
        public virtual Pageable<User> GetWithPage(CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWithPageRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetWithPageNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, User.DeserializeUser, ClientDiagnostics, _pipeline, "BasicClient.GetWithPage", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] List with Azure.Core.Page&lt;&gt;.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetWithPageAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetWithPageAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetWithPageAsync(RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWithPageRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetWithPageNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "BasicClient.GetWithPage", "value", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] List with Azure.Core.Page&lt;&gt;.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetWithPage(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetWithPage(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetWithPage(RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWithPageRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetWithPageNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "BasicClient.GetWithPage", "value", "nextLink", context);
        }

        /// <summary> List with custom page model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetWithCustomPageModelAsync(CancellationToken)']/*" />
        public virtual AsyncPageable<User> GetWithCustomPageModelAsync(CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWithCustomPageModelRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetWithCustomPageModelNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, User.DeserializeUser, ClientDiagnostics, _pipeline, "BasicClient.GetWithCustomPageModel", "items", "nextLink", context);
        }

        /// <summary> List with custom page model. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetWithCustomPageModel(CancellationToken)']/*" />
        public virtual Pageable<User> GetWithCustomPageModel(CancellationToken cancellationToken = default)
        {
            RequestContext context = cancellationToken.CanBeCanceled ? new RequestContext { CancellationToken = cancellationToken } : null;
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWithCustomPageModelRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetWithCustomPageModelNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, User.DeserializeUser, ClientDiagnostics, _pipeline, "BasicClient.GetWithCustomPageModel", "items", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] List with custom page model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetWithCustomPageModelAsync(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="AsyncPageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetWithCustomPageModelAsync(RequestContext)']/*" />
        public virtual AsyncPageable<BinaryData> GetWithCustomPageModelAsync(RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWithCustomPageModelRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetWithCustomPageModelNextPageRequest(nextLink, context);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "BasicClient.GetWithCustomPageModel", "items", "nextLink", context);
        }

        /// <summary>
        /// [Protocol Method] List with custom page model.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetWithCustomPageModel(CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The <see cref="Pageable{T}"/> from the service containing a list of <see cref="BinaryData"/> objects. Details of the body schema for each item in the collection are in the Remarks section below. </returns>
        /// <include file="Docs/BasicClient.xml" path="doc/members/member[@name='GetWithCustomPageModel(RequestContext)']/*" />
        public virtual Pageable<BinaryData> GetWithCustomPageModel(RequestContext context)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => CreateGetWithCustomPageModelRequest(context);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => CreateGetWithCustomPageModelNextPageRequest(nextLink, context);
            return PageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => BinaryData.FromString(e.GetRawText()), ClientDiagnostics, _pipeline, "BasicClient.GetWithCustomPageModel", "items", "nextLink", context);
        }

        internal HttpMessage CreateCreateOrUpdateRequest(int id, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201);
            var request = message.Request;
            request.Method = RequestMethod.Patch;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/basic/users/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/merge-patch+json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateCreateOrReplaceRequest(int id, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200201);
            var request = message.Request;
            request.Method = RequestMethod.Put;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/basic/users/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateGetUserRequest(int id, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/basic/users/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetUsersRequest(int? maxCount, int? skip, int? maxpagesize, IEnumerable<string> orderby, string filter, IEnumerable<string> select, IEnumerable<string> expand, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/basic/users", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            if (maxCount != null)
            {
                uri.AppendQuery("top", maxCount.Value, true);
            }
            if (skip != null)
            {
                uri.AppendQuery("skip", skip.Value, true);
            }
            if (maxpagesize != null)
            {
                uri.AppendQuery("maxpagesize", maxpagesize.Value, true);
            }
            if (orderby != null && Optional.IsCollectionDefined(orderby))
            {
                foreach (var param in orderby)
                {
                    uri.AppendQuery("orderby", param, true);
                }
            }
            if (filter != null)
            {
                uri.AppendQuery("filter", filter, true);
            }
            if (select != null && Optional.IsCollectionDefined(select))
            {
                foreach (var param in select)
                {
                    uri.AppendQuery("select", param, true);
                }
            }
            if (expand != null && Optional.IsCollectionDefined(expand))
            {
                foreach (var param in expand)
                {
                    uri.AppendQuery("expand", param, true);
                }
            }
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetWithPageRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/basic/page", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetWithCustomPageModelRequest(RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/basic/custom-page", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateDeleteRequest(int id, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Delete;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/basic/users/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateExportRequest(int id, string format, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/azure/core/basic/users/", false);
            uri.AppendPath(id, true);
            uri.AppendPath(":export", false);
            uri.AppendQuery("format", format, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetUsersNextPageRequest(string nextLink, int? maxCount, int? skip, int? maxpagesize, IEnumerable<string> orderby, string filter, IEnumerable<string> select, IEnumerable<string> expand, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetWithPageNextPageRequest(string nextLink, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        internal HttpMessage CreateGetWithCustomPageModelNextPageRequest(string nextLink, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier200);
            var request = message.Request;
            request.Method = RequestMethod.Get;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendRawNextLink(nextLink, false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            return message;
        }

        private static RequestContext DefaultRequestContext = new RequestContext();
        internal static RequestContext FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestContext() { CancellationToken = cancellationToken };
        }

        private static ResponseClassifier _responseClassifier200201;
        private static ResponseClassifier ResponseClassifier200201 => _responseClassifier200201 ??= new StatusCodeClassifier(stackalloc ushort[] { 200, 201 });
        private static ResponseClassifier _responseClassifier200;
        private static ResponseClassifier ResponseClassifier200 => _responseClassifier200 ??= new StatusCodeClassifier(stackalloc ushort[] { 200 });
        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
