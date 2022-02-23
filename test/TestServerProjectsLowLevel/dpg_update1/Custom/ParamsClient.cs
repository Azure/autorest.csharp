// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace dpg_update1_LowLevel
{
    /// <summary> The Params service client. </summary>
    [CodeGenSuppress("PostParametersAsync", typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("PostParameters", typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreatePostParametersRequest", typeof(RequestContent), typeof(RequestContext))]
    public partial class ParamsClient
    {
        /// <summary> Get true Boolean value on path. </summary>
        /// <param name="parameter"> I am a required parameter. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameter"/> is null. </exception>
        public virtual async Task<Response> GetRequiredAsync(string parameter, RequestContext context)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            using var scope = ClientDiagnostics.CreateScope("ParamsClient.GetRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRequiredRequest(parameter, null, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get true Boolean value on path. </summary>
        /// <param name="parameter"> I am a required parameter. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="parameter"/> is null. </exception>
        public virtual Response GetRequired(string parameter, RequestContext context)
        {
            Argument.AssertNotNull(parameter, nameof(parameter));

            using var scope = ClientDiagnostics.CreateScope("ParamsClient.GetRequired");
            scope.Start();
            try
            {
                using HttpMessage message = CreateGetRequiredRequest(parameter, null, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST a JSON. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   url: string (required)
        /// }
        /// </code>
        ///
        /// </remarks>
        public virtual async Task<Response> PostParametersAsync(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ParamsClient.PostParameters");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostParametersRequest(content, ContentType.ApplicationJson, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST a JSON. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <remarks>
        /// Schema for <c>Request Body</c>:
        /// <code>{
        ///   url: string (required)
        /// }
        /// </code>
        ///
        /// </remarks>
        public virtual Response PostParameters(RequestContent content, RequestContext context = null)
        {
            Argument.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateScope("ParamsClient.PostParameters");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostParametersRequest(content, ContentType.ApplicationJson, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // TODO: this method should be auto generated when https://github.com/Azure/autorest.csharp/issues/1746 is fixed.
        /// <summary> POST a JSON or a JPEG. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;image/jpeg&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual async Task<Response> PostParametersAsync(RequestContent content, ContentType contentType, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParamsClient.PostParameters");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostParametersRequest(content, contentType, context);
                return await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // TODO: this method should be auto generated when https://github.com/Azure/autorest.csharp/issues/1746 is fixed.
        /// <summary> POST a JSON or a JPEG. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;image/jpeg&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        public virtual Response PostParameters(RequestContent content, ContentType contentType, RequestContext context = null)
        {
            using var scope = ClientDiagnostics.CreateScope("ParamsClient.PostParameters");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostParametersRequest(content, contentType, context);
                return _pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // TODO: this method should be auto generated when https://github.com/Azure/autorest.csharp/issues/1746 is fixed.
        internal HttpMessage CreatePostParametersRequest(RequestContent content, ContentType contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/serviceDriven/parameters", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "application/json");
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }
    }
}
