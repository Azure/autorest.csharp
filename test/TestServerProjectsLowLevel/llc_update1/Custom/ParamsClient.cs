// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;

namespace llc_update1_LowLevel
{
    /// <summary> The Params service client. </summary>
    [CodeGenSuppress("PostParametersAsync", typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("PostParameters", typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreatePostParametersRequest", typeof(RequestContent), typeof(RequestContext))]
    public partial class ParamsClient
    {
        /// <summary> POST a JSON or a JPEG. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;image/jpeg&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual async Task<Response> PostParametersAsync(RequestContent content, ContentType contentType, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("ParamsClient.PostParameters");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostParametersRequest(content, contentType, context);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> POST a JSON or a JPEG. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;application/json&quot; | &quot;image/jpeg&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual Response PostParameters(RequestContent content, ContentType contentType, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("ParamsClient.PostParameters");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePostParametersRequest(content, contentType, context);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

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
