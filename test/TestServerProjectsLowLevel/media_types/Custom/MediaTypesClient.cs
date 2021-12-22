// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;

namespace media_types_LowLevel
{
    /// <summary> The MediaTypes service client. </summary>
    [CodeGenSuppress("PutTextAndJsonBodyAsync", typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("PutTextAndJsonBody", typeof(RequestContent), typeof(RequestContext))]
    [CodeGenSuppress("CreatePutTextAndJsonBodyRequest", typeof(RequestContent), typeof(RequestContext))]
    public partial class MediaTypesClient
    {
        /// <summary> Body that&apos;s either text/plain or application/json. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;text/plain&quot; | &quot;application/json&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual async Task<Response> PutTextAndJsonBodyAsync(RequestContent content, ContentType contentType, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("MediaTypesClient.PutTextAndJsonBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutTextAndJsonBodyRequest(content, contentType, context);
                return await _pipeline.ProcessMessageAsync(message, _clientDiagnostics, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Body that&apos;s either text/plain or application/json. </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="contentType"> Upload file type. Allowed values: &quot;text/plain&quot; | &quot;application/json&quot;. </param>
        /// <param name="context"> The request context, which can override default behaviors on the request on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
#pragma warning disable AZC0002
        public virtual Response PutTextAndJsonBody(RequestContent content, ContentType contentType, RequestContext context = null)
#pragma warning restore AZC0002
        {
            using var scope = _clientDiagnostics.CreateScope("MediaTypesClient.PutTextAndJsonBody");
            scope.Start();
            try
            {
                using HttpMessage message = CreatePutTextAndJsonBodyRequest(content, contentType, context);
                return _pipeline.ProcessMessage(message, _clientDiagnostics, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal HttpMessage CreatePutTextAndJsonBodyRequest(RequestContent content, ContentType contentType, RequestContext context)
        {
            var message = _pipeline.CreateMessage(context);
            var request = message.Request;
            request.Method = RequestMethod.Post;
            var uri = new RawRequestUriBuilder();
            uri.Reset(_endpoint);
            uri.AppendPath("/mediatypes/textAndJson", false);
            request.Uri = uri;
            request.Headers.Add("Accept", "text/plain");
            request.Headers.Add("Content-Type", contentType.ToString());
            request.Content = content;
            message.ResponseClassifier = ResponseClassifier200.Instance;
            return message;
        }
    }
}
