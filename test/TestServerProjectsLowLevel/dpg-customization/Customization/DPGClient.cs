// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using dpg_customization_LowLevel.Models;

namespace dpg_customization_LowLevel
{
    public partial class DPGClient
    {
        /// <summary> Initializes a new instance of DPGClient. </summary>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="endpoint"> server parameter. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <param name="nestedSpanSuppression">Flag controlling if <see cref="System.Diagnostics.Activity"/>
        ///  created by <see cref="ClientDiagnostics"/> for client method calls should be suppressed when called
        ///  by other Azure SDK client methods.  It's recommended to set it to true for new clients; use default (null)
        ///  for backward compatibility reasons, or set it to false to explicitly disable suppression for specific cases.
        ///  The default value could change in the future, the flag should be only set to false if suppression for the client
        ///  should never be enabled.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="credential"/> or <paramref name="endpoint"/> is null. </exception>
        public DPGClient(AzureKeyCredential credential, Uri endpoint, DPGClientOptions options, bool nestedSpanSuppression)
        {
            Argument.AssertNotNull(credential, nameof(credential));
            Argument.AssertNotNull(endpoint, nameof(endpoint));
            options ??= new DPGClientOptions();

            ClientDiagnostics = new ClientDiagnostics(options, nestedSpanSuppression);
            _keyCredential = credential;
            _pipeline = HttpPipelineBuilder.Build(options, Array.Empty<HttpPipelinePolicy>(), new HttpPipelinePolicy[] { new AzureKeyCredentialPolicy(_keyCredential, AuthorizationHeader) }, new ResponseClassifier());
            _endpoint = endpoint;
        }

        /// <summary> Get models that you will either return to end users as a raw body, or with a model added during grow up. </summary>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        public virtual async Task<Response<Product>> GetModelValueAsync(string mode, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("DPGClient.GetModelValue");
            scope.Start();
            try
            {
                RequestContext requestContext = new RequestContext { CancellationToken = cancellationToken };
                Response response = await GetModelAsync(mode, requestContext);
                return Response.FromValue((Product)response, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get models that you will either return to end users as a raw body, or with a model added during grow up. </summary>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        public virtual Response<Product> GetModelValue(string mode, CancellationToken cancellationToken = default)
        {
            using var scope = ClientDiagnostics.CreateScope("DPGClient.GetModelValue");
            scope.Start();
            try
            {
                RequestContext requestContext = new RequestContext { CancellationToken = cancellationToken };
                Response response = GetModel(mode, requestContext);
                return Response.FromValue((Product)response, response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Post either raw response as a model and pass in &apos;raw&apos; for mode, or grow up your operation to take a model instead, and put in &apos;model&apos; as mode. </summary>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="input"> Please put {&apos;hello&apos;: &apos;world!&apos;}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> or <paramref name="input"/> is null. </exception>
        public virtual async Task<Response<Product>> PostModelAsync(string mode, Input input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext requestContext = new RequestContext();
            requestContext.CancellationToken = cancellationToken;

            Response response = await PostModelAsync("model", Input.ToRequestContent(input), requestContext);
            return Response.FromValue((Product)response, response);
        }

        /// <summary> Post either raw response as a model and pass in &apos;raw&apos; for mode, or grow up your operation to take a model instead, and put in &apos;model&apos; as mode. </summary>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="input"> Please put {&apos;hello&apos;: &apos;world!&apos;}. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> or <paramref name="input"/> is null. </exception>
        public virtual Response<Product> PostModel(string mode, Input input, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(input, nameof(input));

            RequestContext requestContext = new RequestContext();
            requestContext.CancellationToken = cancellationToken;

            Response result = PostModel("model", Input.ToRequestContent(input), requestContext);
            return Response.FromValue((Product)result, result);
        }

        /// <summary> Long running put request that will either return to end users a final payload of a raw body, or a final payload of a model after the SDK has grown up. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        public virtual async Task<Operation<Product>> LroValueAsync(WaitUntil waitUntil, string mode, CancellationToken cancellationToken = default)
        {
            var requestContext = new RequestContext { CancellationToken = cancellationToken };
            using var scope = ClientDiagnostics.CreateScope("DPGClient.LroValue");
            scope.Start();
            try
            {
                var lro = await LroAsync(waitUntil, mode, requestContext).ConfigureAwait(false);
                return ProtocolOperationHelpers.Convert(lro, r => (Product)r, ClientDiagnostics, "DPGClient.LroValue");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Long running put request that will either return to end users a final payload of a raw body, or a final payload of a model after the SDK has grown up. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        public virtual Operation<Product> LroValue(WaitUntil waitUntil, string mode, CancellationToken cancellationToken = default)
        {
            var requestContext = new RequestContext { CancellationToken = cancellationToken };
            using var scope = ClientDiagnostics.CreateScope("DPGClient.LroValue");
            scope.Start();
            try
            {
                var lro = Lro(waitUntil, mode, requestContext);
                return ProtocolOperationHelpers.Convert(lro, r => (Product)r, ClientDiagnostics, "DPGClient.LroValue");
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get pages that you will either return to users in pages of raw bodies, or pages of models following growup. </summary>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        public virtual AsyncPageable<Product> GetPageValuesAsync(string mode, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mode, nameof(mode));

            var context = new RequestContext { CancellationToken = cancellationToken };

            AsyncPageable<BinaryData> pageableBindaryData = GetPagesImplementationAsync("DPGClient.GetPagesValues", mode, context);
            return PageableHelpers.Select(pageableBindaryData, response => ((ProductResult)response).Values);
        }

        /// <summary> Get pages that you will either return to users in pages of raw bodies, or pages of models following growup. </summary>
        /// <param name="mode"> The mode with which you&apos;ll be handling your returned body. &apos;raw&apos; for just dealing with the raw body, and &apos;model&apos; if you are going to convert the raw body to a customized body before returning to users. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="mode"/> is null. </exception>
        public virtual Pageable<Product> GetPageValues(string mode, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(mode, nameof(mode));

            RequestContext context = new RequestContext();
            context.CancellationToken = cancellationToken;

            Pageable<BinaryData> pageableBindaryData = GetPagesImplementation("DPGClient.GetPagesValues", mode, context);
            return PageableHelpers.Select(pageableBindaryData, response => ((ProductResult)response).Values);
        }
    }
}
