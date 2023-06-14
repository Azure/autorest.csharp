// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Spread.Models;

namespace Spread
{
    // Data plane generated client.
    /// <summary> This is a spread model or alias service. </summary>
    public partial class SpreadClient
    {
        private readonly HttpPipeline _pipeline;
        private readonly Uri _endpoint;
        private readonly string _apiVersion;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal ClientDiagnostics ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual HttpPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of SpreadClient for mocking. </summary>
        protected SpreadClient()
        {
        }

        /// <summary> Initializes a new instance of SpreadClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public SpreadClient(Uri endpoint) : this(endpoint, new SpreadClientOptions())
        {
        }

        /// <summary> Initializes a new instance of SpreadClient. </summary>
        /// <param name="endpoint"> The Uri to use. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="endpoint"/> is null. </exception>
        public SpreadClient(Uri endpoint, SpreadClientOptions options)
        {
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new SpreadClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, true);
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), Array.Empty<HttpPipelinePolicy>(), new ResponseClassifier());
            _endpoint = endpoint;
            _apiVersion = options.Version;
        }

        /// <summary> spread a model as body. </summary>
        /// <param name="thing"> The Thing to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="thing"/> is null. </exception>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadModelAsync(Thing,CancellationToken)']/*" />
        public virtual async Task<Response> SpreadModelAsync(Thing thing, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(thing, nameof(thing));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SpreadModelAsync(thing.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> spread a model as body. </summary>
        /// <param name="thing"> The Thing to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="thing"/> is null. </exception>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadModel(Thing,CancellationToken)']/*" />
        public virtual Response SpreadModel(Thing thing, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(thing, nameof(thing));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SpreadModel(thing.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] spread a model as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadModelAsync(Thing,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadModelAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SpreadModelAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SpreadClient.SpreadModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadModelRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] spread a model as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadModel(Thing,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadModel(RequestContent,RequestContext)']/*" />
        public virtual Response SpreadModel(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SpreadClient.SpreadModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadModelRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> spread an alias as body. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasAsync(string,int,CancellationToken)']/*" />
        public virtual async Task<Response> SpreadAliasAsync(string name, int age, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadAliasRequest spreadAliasRequest = new SpreadAliasRequest(name, age);
            Response response = await SpreadAliasAsync(spreadAliasRequest.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> spread an alias as body. </summary>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAlias(string,int,CancellationToken)']/*" />
        public virtual Response SpreadAlias(string name, int age, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadAliasRequest spreadAliasRequest = new SpreadAliasRequest(name, age);
            Response response = SpreadAlias(spreadAliasRequest.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] spread an alias as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAliasAsync(string,int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasAsync(RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SpreadAliasAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SpreadClient.SpreadAlias");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAliasRequest(content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] spread an alias as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAlias(string,int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAlias(RequestContent,RequestContext)']/*" />
        public virtual Response SpreadAlias(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SpreadClient.SpreadAlias");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAliasRequest(content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> spread an alias which has multiple target property as body. </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadMultiTargetAliasAsync(string,int,string,int,CancellationToken)']/*" />
        public virtual async Task<Response> SpreadMultiTargetAliasAsync(string id, int top, string name, int age, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadMultiTargetAliasRequest spreadMultiTargetAliasRequest = new SpreadMultiTargetAliasRequest(name, age);
            Response response = await SpreadMultiTargetAliasAsync(id, top, spreadMultiTargetAliasRequest.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> spread an alias which has multiple target property as body. </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadMultiTargetAlias(string,int,string,int,CancellationToken)']/*" />
        public virtual Response SpreadMultiTargetAlias(string id, int top, string name, int age, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadMultiTargetAliasRequest spreadMultiTargetAliasRequest = new SpreadMultiTargetAliasRequest(name, age);
            Response response = SpreadMultiTargetAlias(id, top, spreadMultiTargetAliasRequest.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] spread an alias which has multiple target property as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadMultiTargetAliasAsync(string,int,string,int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadMultiTargetAliasAsync(string,int,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SpreadMultiTargetAliasAsync(string id, int top, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SpreadClient.SpreadMultiTargetAlias");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadMultiTargetAliasRequest(id, top, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] spread an alias which has multiple target property as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadMultiTargetAlias(string,int,string,int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadMultiTargetAlias(string,int,RequestContent,RequestContext)']/*" />
        public virtual Response SpreadMultiTargetAlias(string id, int top, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SpreadClient.SpreadMultiTargetAlias");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadMultiTargetAliasRequest(id, top, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> spread an alias which contains a complex model property as body. </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="thing"> The Thing to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="thing"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasWithModelAsync(string,int,Thing,CancellationToken)']/*" />
        public virtual async Task<Response> SpreadAliasWithModelAsync(string id, int top, Thing thing, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(thing, nameof(thing));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = await SpreadAliasWithModelAsync(id, top, thing.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> spread an alias which contains a complex model property as body. </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="thing"> The Thing to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="thing"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasWithModel(string,int,Thing,CancellationToken)']/*" />
        public virtual Response SpreadAliasWithModel(string id, int top, Thing thing, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(thing, nameof(thing));

            RequestContext context = FromCancellationToken(cancellationToken);
            Response response = SpreadAliasWithModel(id, top, thing.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] spread an alias which contains a complex model property as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAliasWithModelAsync(string,int,Thing,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasWithModelAsync(string,int,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SpreadAliasWithModelAsync(string id, int top, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SpreadClient.SpreadAliasWithModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAliasWithModelRequest(id, top, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] spread an alias which contains a complex model property as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAliasWithModel(string,int,Thing,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasWithModel(string,int,RequestContent,RequestContext)']/*" />
        public virtual Response SpreadAliasWithModel(string id, int top, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SpreadClient.SpreadAliasWithModel");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAliasWithModelRequest(id, top, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> spread an alias with contains another alias property as body. </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasWithSpreadAliasAsync(string,int,string,int,CancellationToken)']/*" />
        public virtual async Task<Response> SpreadAliasWithSpreadAliasAsync(string id, int top, string name, int age, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadAliasWithSpreadAliasRequest spreadAliasWithSpreadAliasRequest = new SpreadAliasWithSpreadAliasRequest(name, age);
            Response response = await SpreadAliasWithSpreadAliasAsync(id, top, spreadAliasWithSpreadAliasRequest.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> spread an alias with contains another alias property as body. </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="name"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasWithSpreadAlias(string,int,string,int,CancellationToken)']/*" />
        public virtual Response SpreadAliasWithSpreadAlias(string id, int top, string name, int age, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(name, nameof(name));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadAliasWithSpreadAliasRequest spreadAliasWithSpreadAliasRequest = new SpreadAliasWithSpreadAliasRequest(name, age);
            Response response = SpreadAliasWithSpreadAlias(id, top, spreadAliasWithSpreadAliasRequest.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] spread an alias with contains another alias property as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAliasWithSpreadAliasAsync(string,int,string,int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasWithSpreadAliasAsync(string,int,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SpreadAliasWithSpreadAliasAsync(string id, int top, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SpreadClient.SpreadAliasWithSpreadAlias");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAliasWithSpreadAliasRequest(id, top, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] spread an alias with contains another alias property as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAliasWithSpreadAlias(string,int,string,int,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasWithSpreadAlias(string,int,RequestContent,RequestContext)']/*" />
        public virtual Response SpreadAliasWithSpreadAlias(string id, int top, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SpreadClient.SpreadAliasWithSpreadAlias");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAliasWithSpreadAliasRequest(id, top, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> spread an alias with contains optional properties as body. </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="items"> required array. </param>
        /// <param name="color"> optional property of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="elements"> optional array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="name"/> or <paramref name="items"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasWithOptionalPropsAsync(string,int,string,IEnumerable{int},string,int?,IEnumerable{string},CancellationToken)']/*" />
        public virtual async Task<Response> SpreadAliasWithOptionalPropsAsync(string id, int top, string name, IEnumerable<int> items, string color = null, int? age = null, IEnumerable<string> elements = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(items, nameof(items));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadAliasWithOptionalPropsRequest spreadAliasWithOptionalPropsRequest = new SpreadAliasWithOptionalPropsRequest(name, items.ToList())
            {
                Color = color,
                Age = age
            };
            if (elements != null)
            {
                foreach (var value in elements)
                {
                    spreadAliasWithOptionalPropsRequest.Elements.Add(value);
                }
            }
            SpreadAliasWithOptionalPropsRequest spreadAliasWithOptionalPropsRequest0 = spreadAliasWithOptionalPropsRequest;
            Response response = await SpreadAliasWithOptionalPropsAsync(id, top, spreadAliasWithOptionalPropsRequest0.ToRequestContent(), context).ConfigureAwait(false);
            return response;
        }

        /// <summary> spread an alias with contains optional properties as body. </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="name"> name of the Thing. </param>
        /// <param name="items"> required array. </param>
        /// <param name="color"> optional property of the Thing. </param>
        /// <param name="age"> age of the Thing. </param>
        /// <param name="elements"> optional array. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/>, <paramref name="name"/> or <paramref name="items"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasWithOptionalProps(string,int,string,IEnumerable{int},string,int?,IEnumerable{string},CancellationToken)']/*" />
        public virtual Response SpreadAliasWithOptionalProps(string id, int top, string name, IEnumerable<int> items, string color = null, int? age = null, IEnumerable<string> elements = null, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(items, nameof(items));

            RequestContext context = FromCancellationToken(cancellationToken);
            SpreadAliasWithOptionalPropsRequest spreadAliasWithOptionalPropsRequest = new SpreadAliasWithOptionalPropsRequest(name, items.ToList())
            {
                Color = color,
                Age = age
            };
            if (elements != null)
            {
                foreach (var value in elements)
                {
                    spreadAliasWithOptionalPropsRequest.Elements.Add(value);
                }
            }
            SpreadAliasWithOptionalPropsRequest spreadAliasWithOptionalPropsRequest0 = spreadAliasWithOptionalPropsRequest;
            Response response = SpreadAliasWithOptionalProps(id, top, spreadAliasWithOptionalPropsRequest0.ToRequestContent(), context);
            return response;
        }

        /// <summary>
        /// [Protocol Method] spread an alias with contains optional properties as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAliasWithOptionalPropsAsync(string,int,string,IEnumerable{int},string,int?,IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasWithOptionalPropsAsync(string,int,RequestContent,RequestContext)']/*" />
        public virtual async Task<Response> SpreadAliasWithOptionalPropsAsync(string id, int top, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SpreadClient.SpreadAliasWithOptionalProps");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAliasWithOptionalPropsRequest(id, top, content, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] spread an alias with contains optional properties as body.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="SpreadAliasWithOptionalProps(string,int,string,IEnumerable{int},string,int?,IEnumerable{string},CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="id"> The String to use. </param>
        /// <param name="top"> The Int32 to use. </param>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> or <paramref name="content"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="RequestFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        /// <include file="Docs/SpreadClient.xml" path="doc/members/member[@name='SpreadAliasWithOptionalProps(string,int,RequestContent,RequestContext)']/*" />
        public virtual Response SpreadAliasWithOptionalProps(string id, int top, RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("SpreadClient.SpreadAliasWithOptionalProps");
            scope.Start();
            try
            {
                using HttpMessage message = CreateSpreadAliasWithOptionalPropsRequest(id, top, content, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreateSpreadModelRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/spreadModel", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSpreadAliasRequest(RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/spreadAlias", false);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSpreadMultiTargetAliasRequest(string id, int top, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/spreadMultiTargetAlias/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("top", top);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSpreadAliasWithModelRequest(string id, int top, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/spreadAliasWithModel/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("top", top);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSpreadAliasWithSpreadAliasRequest(string id, int top, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/spreadAliasWithSpreadAlias/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("top", top);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal HttpMessage CreateSpreadAliasWithOptionalPropsRequest(string id, int top, RequestContent content, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context, ResponseClassifier204);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/spreadAliasWithOptionalProps/", false);
            uri.AppendPath(id, true);
            uri.AppendQuery("api-version", _apiVersion, true);
            request.Uri = uri;
            request.Headers.Add("top", top);
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", "application/json");
            request.Content = content;
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

        private static ResponseClassifier _responseClassifier204;
        private static ResponseClassifier ResponseClassifier204 => _responseClassifier204 ??= new StatusCodeClassifier(stackalloc ushort[] { 204 });
    }
}
