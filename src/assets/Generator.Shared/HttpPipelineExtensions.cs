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
        public static async ValueTask<Response> ProcessMessageAsync(this HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, RequestOptions? requestOptions, CancellationToken cancellationToken = default)
        {
            var (userCt, statusOption) = ApplyRequestOptions(requestOptions, message);
            if (!userCt.CanBeCanceled || !cancellationToken.CanBeCanceled)
            {
                await pipeline.SendAsync(message, cancellationToken.CanBeCanceled ? cancellationToken : userCt).ConfigureAwait(false);
            }
            else
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(userCt, cancellationToken);
                await pipeline.SendAsync(message, cts.Token).ConfigureAwait(false);
            }

            if (statusOption == ResponseStatusOption.NoThrow || !message.ResponseClassifier.IsErrorResponse(message))
            {
                return message.Response;
            }

            throw await clientDiagnostics.CreateRequestFailedExceptionAsync(message.Response).ConfigureAwait(false);
        }

        public static Response ProcessMessage(this HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, RequestOptions? requestOptions, CancellationToken cancellationToken = default)
        {
            var (userCt, statusOption) = ApplyRequestOptions(requestOptions, message);
            if (!userCt.CanBeCanceled || !cancellationToken.CanBeCanceled)
            {
                pipeline.Send(message, cancellationToken.CanBeCanceled ? cancellationToken : userCt);
            }
            else
            {
                using var cts = CancellationTokenSource.CreateLinkedTokenSource(userCt, cancellationToken);
                pipeline.Send(message, cts.Token);
            }

            if (statusOption == ResponseStatusOption.NoThrow || !message.ResponseClassifier.IsErrorResponse(message))
            {
                return message.Response;
            }

            throw clientDiagnostics.CreateRequestFailedException(message.Response);
        }

        public static async ValueTask<Response<bool>> ProcessHeadAsBoolMessageAsync(this HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, RequestOptions? requestOptions)
        {
            var response = await pipeline.ProcessMessageAsync(message, clientDiagnostics, requestOptions).ConfigureAwait(false);
            switch (response.Status)
            {
                case >= 200 and < 300:
                    return Response.FromValue(true, response);
                case >= 400 and < 500:
                    return Response.FromValue(false, response);
                default:
                    var exception = await clientDiagnostics.CreateRequestFailedExceptionAsync(response).ConfigureAwait(false);
                    return new ErrorResponse<bool>(response, exception);
            }
        }

        public static Response<bool> ProcessHeadAsBoolMessage(this HttpPipeline pipeline, HttpMessage message, ClientDiagnostics clientDiagnostics, RequestOptions? requestOptions)
        {
            var response = pipeline.ProcessMessage(message, clientDiagnostics, requestOptions);
            switch (response.Status)
            {
                case >= 200 and < 300:
                    return Response.FromValue(true, response);
                case >= 400 and < 500:
                    return Response.FromValue(false, response);
                default:
                    var exception = clientDiagnostics.CreateRequestFailedException(response);
                    return new ErrorResponse<bool>(response, exception);
            }
        }

        private static (CancellationToken CancellationToken, ResponseStatusOption StatusOption) ApplyRequestOptions(RequestOptions? requestOptions, HttpMessage message)
        {
            if (requestOptions == null)
            {
                return (CancellationToken.None, ResponseStatusOption.Default);
            }

            RequestOptions.Apply(requestOptions, message);
            return (requestOptions.CancellationToken, requestOptions.StatusOption);
        }
#endif
    }
}
