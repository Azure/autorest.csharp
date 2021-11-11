// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    internal static class HttpPipelineExtensions
    {
#if EXPERIMENTAL
        public static async ValueTask<Response> ProcessMessageAsync(this HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, RequestContext? requestContext, CancellationToken cancellationToken = default)
        {
            var (userCt, statusOption) = ApplyRequestContext(requestContext);
            if (!userCt.CanBeCanceled || !cancellationToken.CanBeCanceled)
            {
                await pipeline.SendAsync(message, cancellationToken.CanBeCanceled ? cancellationToken : userCt).ConfigureAwait(false);
            }
            else
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(userCt, cancellationToken);
                await pipeline.SendAsync(message, cts.Token).ConfigureAwait(false);
            }

            if (statusOption == ErrorOptions.NoThrow || !message.ResponseClassifier.IsErrorResponse(message))
            {
                return message.Response;
            }

            throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
        }

        public static Response ProcessMessage(this HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, RequestContext? requestContext, CancellationToken cancellationToken = default)
        {
            var (userCt, statusOption) = ApplyRequestContext(requestContext);
            if (!userCt.CanBeCanceled || !cancellationToken.CanBeCanceled)
            {
                pipeline.Send(message, cancellationToken.CanBeCanceled ? cancellationToken : userCt);
            }
            else
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(userCt, cancellationToken);
                pipeline.Send(message, cts.Token);
            }

            if (statusOption == ErrorOptions.NoThrow || !message.ResponseClassifier.IsErrorResponse(message))
            {
                return message.Response;
            }

            throw clientDiagnostics.CreateRequestFailedException(message.Response);
        }

        public static async ValueTask<Response<bool>> ProcessHeadAsBoolMessageAsync(this HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, RequestContext? requestContext)
        {
            var (cancellationToken, statusOption) = ApplyRequestContext(requestContext);
            await pipeline.SendAsync(message, cancellationToken).ConfigureAwait(false);
            switch (message.Response.Status)
            {
                case >= 200 and < 300:
                    return Response.FromValue(true, message.Response);
                case >= 400 and < 500:
                    return Response.FromValue(false, message.Response);
                default:
                    var exception = await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
                    if (statusOption == ErrorOptions.NoThrow)
                    {
                        return new ErrorResponse<bool>(message.Response, exception);
                    }

                    throw exception;
            }
        }

        public static Response<bool> ProcessHeadAsBoolMessage(this HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, RequestContext? requestContext)
        {
            var (cancellationToken, statusOption) = ApplyRequestContext(requestContext);
            pipeline.Send(message, cancellationToken);
            switch (message.Response.Status)
            {
                case >= 200 and < 300:
                    return Response.FromValue(true, message.Response);
                case >= 400 and < 500:
                    return Response.FromValue(false, message.Response);
                default:
                    var exception = clientDiagnostics.CreateRequestFailedException(message.Response);
                    if (statusOption == ErrorOptions.NoThrow)
                    {
                        return new ErrorResponse<bool>(message.Response, exception);
                    }

                    throw exception;
            }
        }

        private static (CancellationToken CancellationToken, ErrorOptions ErrorOptions) ApplyRequestContext(RequestContext? requestContext)
        {
            if (requestContext == null)
            {
                return (CancellationToken.None, ErrorOptions.Default);
            }

            return (requestContext.CancellationToken, requestContext.ErrorOptions);
        }
#endif
    }
}
