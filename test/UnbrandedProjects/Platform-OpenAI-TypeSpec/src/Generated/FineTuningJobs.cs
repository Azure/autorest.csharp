// <auto-generated/>

#nullable disable

using System;
using System.Net.ClientModel;
using System.Net.ClientModel.Core;
using System.Net.ClientModel.Core.Pipeline;
using System.Net.ClientModel.Internal;
using System.Threading;
using System.Threading.Tasks;
using OpenAI.Models;

namespace OpenAI
{
    // Data plane generated sub-client.
    /// <summary> The FineTuningJobs sub-client. </summary>
    public partial class FineTuningJobs
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly KeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly MessagePipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The ClientDiagnostics is used to provide tracing support for the client library. </summary>
        internal TelemetrySource ClientDiagnostics { get; }

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual MessagePipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of FineTuningJobs for mocking. </summary>
        protected FineTuningJobs()
        {
        }

        /// <summary> Initializes a new instance of FineTuningJobs. </summary>
        /// <param name="clientDiagnostics"> The handler for diagnostic messaging in the client. </param>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> OpenAI Endpoint. </param>
        internal FineTuningJobs(TelemetrySource clientDiagnostics, MessagePipeline pipeline, KeyCredential keyCredential, Uri endpoint)
        {
            ClientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
        }

        /// <summary>
        /// Creates a job that fine-tunes a specified model from a given dataset.
        ///
        /// Response includes details of the enqueued job including job status and the name of the
        /// fine-tuned models once complete.
        ///
        /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
        /// </summary>
        /// <param name="job"> The <see cref="CreateFineTuningJobRequest"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="job"/> is null. </exception>
        public virtual async Task<Result<FineTuningJob>> CreateAsync(CreateFineTuningJobRequest job, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNull(job, nameof(job));

            RequestOptions context = FromCancellationToken(cancellationToken);
            using RequestBody content = job.ToRequestBody();
            Result result = await CreateAsync(content, context).ConfigureAwait(false);
            return Result.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// Creates a job that fine-tunes a specified model from a given dataset.
        ///
        /// Response includes details of the enqueued job including job status and the name of the
        /// fine-tuned models once complete.
        ///
        /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
        /// </summary>
        /// <param name="job"> The <see cref="CreateFineTuningJobRequest"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="job"/> is null. </exception>
        public virtual Result<FineTuningJob> Create(CreateFineTuningJobRequest job, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNull(job, nameof(job));

            RequestOptions context = FromCancellationToken(cancellationToken);
            using RequestBody content = job.ToRequestBody();
            Result result = Create(content, context);
            return Result.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Creates a job that fine-tunes a specified model from a given dataset.
        ///
        /// Response includes details of the enqueued job including job status and the name of the
        /// fine-tuned models once complete.
        ///
        /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CreateAsync(CreateFineTuningJobRequest,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Result> CreateAsync(RequestBody content, RequestOptions context = null)
        {
            ClientUtilities.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateSpan("FineTuningJobs.Create");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateCreateRequest(content, context);
                return Result.FromResponse(await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Creates a job that fine-tunes a specified model from a given dataset.
        ///
        /// Response includes details of the enqueued job including job status and the name of the
        /// fine-tuned models once complete.
        ///
        /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Create(CreateFineTuningJobRequest,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> The content to send as the body of the request. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Result Create(RequestBody content, RequestOptions context = null)
        {
            ClientUtilities.AssertNotNull(content, nameof(content));

            using var scope = ClientDiagnostics.CreateSpan("FineTuningJobs.Create");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateCreateRequest(content, context);
                return Result.FromResponse(_pipeline.ProcessMessage(message, context));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <param name="after"> Identifier for the last job from the previous pagination request. </param>
        /// <param name="limit"> Number of fine-tuning jobs to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Result<ListPaginatedFineTuningJobsResponse>> GetPaginatedsAsync(string after = null, long? limit = null, CancellationToken cancellationToken = default)
        {
            RequestOptions context = FromCancellationToken(cancellationToken);
            Result result = await GetPaginatedsAsync(after, limit, context).ConfigureAwait(false);
            return Result.FromValue(ListPaginatedFineTuningJobsResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <param name="after"> Identifier for the last job from the previous pagination request. </param>
        /// <param name="limit"> Number of fine-tuning jobs to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Result<ListPaginatedFineTuningJobsResponse> GetPaginateds(string after = null, long? limit = null, CancellationToken cancellationToken = default)
        {
            RequestOptions context = FromCancellationToken(cancellationToken);
            Result result = GetPaginateds(after, limit, context);
            return Result.FromValue(ListPaginatedFineTuningJobsResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetPaginatedsAsync(string,long?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="after"> Identifier for the last job from the previous pagination request. </param>
        /// <param name="limit"> Number of fine-tuning jobs to retrieve. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Result> GetPaginatedsAsync(string after, long? limit, RequestOptions context)
        {
            using var scope = ClientDiagnostics.CreateSpan("FineTuningJobs.GetPaginateds");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateGetPaginatedsRequest(after, limit, context);
                return Result.FromResponse(await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method]
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetPaginateds(string,long?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="after"> Identifier for the last job from the previous pagination request. </param>
        /// <param name="limit"> Number of fine-tuning jobs to retrieve. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Result GetPaginateds(string after, long? limit, RequestOptions context)
        {
            using var scope = ClientDiagnostics.CreateSpan("FineTuningJobs.GetPaginateds");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateGetPaginatedsRequest(after, limit, context);
                return Result.FromResponse(_pipeline.ProcessMessage(message, context));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get info about a fine-tuning job.
        ///
        /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
        /// </summary>
        /// <param name="fineTuningJobId"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fineTuningJobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fineTuningJobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Result<FineTuningJob>> RetrieveAsync(string fineTuningJobId, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(fineTuningJobId, nameof(fineTuningJobId));

            RequestOptions context = FromCancellationToken(cancellationToken);
            Result result = await RetrieveAsync(fineTuningJobId, context).ConfigureAwait(false);
            return Result.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// Get info about a fine-tuning job.
        ///
        /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
        /// </summary>
        /// <param name="fineTuningJobId"> The <see cref="string"/> to use. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fineTuningJobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fineTuningJobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Result<FineTuningJob> Retrieve(string fineTuningJobId, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(fineTuningJobId, nameof(fineTuningJobId));

            RequestOptions context = FromCancellationToken(cancellationToken);
            Result result = Retrieve(fineTuningJobId, context);
            return Result.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Get info about a fine-tuning job.
        ///
        /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="RetrieveAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fineTuningJobId"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fineTuningJobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fineTuningJobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Result> RetrieveAsync(string fineTuningJobId, RequestOptions context)
        {
            ClientUtilities.AssertNotNullOrEmpty(fineTuningJobId, nameof(fineTuningJobId));

            using var scope = ClientDiagnostics.CreateSpan("FineTuningJobs.Retrieve");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateRetrieveRequest(fineTuningJobId, context);
                return Result.FromResponse(await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get info about a fine-tuning job.
        ///
        /// [Learn more about fine-tuning](/docs/guides/fine-tuning)
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Retrieve(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fineTuningJobId"> The <see cref="string"/> to use. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fineTuningJobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fineTuningJobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Result Retrieve(string fineTuningJobId, RequestOptions context)
        {
            ClientUtilities.AssertNotNullOrEmpty(fineTuningJobId, nameof(fineTuningJobId));

            using var scope = ClientDiagnostics.CreateSpan("FineTuningJobs.Retrieve");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateRetrieveRequest(fineTuningJobId, context);
                return Result.FromResponse(_pipeline.ProcessMessage(message, context));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get status updates for a fine-tuning job. </summary>
        /// <param name="fineTuningJobId"> The ID of the fine-tuning job to get events for. </param>
        /// <param name="after"> Identifier for the last event from the previous pagination request. </param>
        /// <param name="limit"> Number of events to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fineTuningJobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fineTuningJobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Result<ListFineTuningJobEventsResponse>> GetEventsAsync(string fineTuningJobId, string after = null, int? limit = null, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(fineTuningJobId, nameof(fineTuningJobId));

            RequestOptions context = FromCancellationToken(cancellationToken);
            Result result = await GetEventsAsync(fineTuningJobId, after, limit, context).ConfigureAwait(false);
            return Result.FromValue(ListFineTuningJobEventsResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Get status updates for a fine-tuning job. </summary>
        /// <param name="fineTuningJobId"> The ID of the fine-tuning job to get events for. </param>
        /// <param name="after"> Identifier for the last event from the previous pagination request. </param>
        /// <param name="limit"> Number of events to retrieve. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fineTuningJobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fineTuningJobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Result<ListFineTuningJobEventsResponse> GetEvents(string fineTuningJobId, string after = null, int? limit = null, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(fineTuningJobId, nameof(fineTuningJobId));

            RequestOptions context = FromCancellationToken(cancellationToken);
            Result result = GetEvents(fineTuningJobId, after, limit, context);
            return Result.FromValue(ListFineTuningJobEventsResponse.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Get status updates for a fine-tuning job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetEventsAsync(string,string,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fineTuningJobId"> The ID of the fine-tuning job to get events for. </param>
        /// <param name="after"> Identifier for the last event from the previous pagination request. </param>
        /// <param name="limit"> Number of events to retrieve. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fineTuningJobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fineTuningJobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Result> GetEventsAsync(string fineTuningJobId, string after, int? limit, RequestOptions context)
        {
            ClientUtilities.AssertNotNullOrEmpty(fineTuningJobId, nameof(fineTuningJobId));

            using var scope = ClientDiagnostics.CreateSpan("FineTuningJobs.GetEvents");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateGetEventsRequest(fineTuningJobId, after, limit, context);
                return Result.FromResponse(await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Get status updates for a fine-tuning job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="GetEvents(string,string,int?,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fineTuningJobId"> The ID of the fine-tuning job to get events for. </param>
        /// <param name="after"> Identifier for the last event from the previous pagination request. </param>
        /// <param name="limit"> Number of events to retrieve. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fineTuningJobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fineTuningJobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Result GetEvents(string fineTuningJobId, string after, int? limit, RequestOptions context)
        {
            ClientUtilities.AssertNotNullOrEmpty(fineTuningJobId, nameof(fineTuningJobId));

            using var scope = ClientDiagnostics.CreateSpan("FineTuningJobs.GetEvents");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateGetEventsRequest(fineTuningJobId, after, limit, context);
                return Result.FromResponse(_pipeline.ProcessMessage(message, context));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Immediately cancel a fine-tune job. </summary>
        /// <param name="fineTuningJobId"> The ID of the fine-tuning job to cancel. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fineTuningJobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fineTuningJobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual async Task<Result<FineTuningJob>> CancelAsync(string fineTuningJobId, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(fineTuningJobId, nameof(fineTuningJobId));

            RequestOptions context = FromCancellationToken(cancellationToken);
            Result result = await CancelAsync(fineTuningJobId, context).ConfigureAwait(false);
            return Result.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary> Immediately cancel a fine-tune job. </summary>
        /// <param name="fineTuningJobId"> The ID of the fine-tuning job to cancel. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fineTuningJobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fineTuningJobId"/> is an empty string, and was expected to be non-empty. </exception>
        public virtual Result<FineTuningJob> Cancel(string fineTuningJobId, CancellationToken cancellationToken = default)
        {
            ClientUtilities.AssertNotNullOrEmpty(fineTuningJobId, nameof(fineTuningJobId));

            RequestOptions context = FromCancellationToken(cancellationToken);
            Result result = Cancel(fineTuningJobId, context);
            return Result.FromValue(FineTuningJob.FromResponse(result.GetRawResponse()), result.GetRawResponse());
        }

        /// <summary>
        /// [Protocol Method] Immediately cancel a fine-tune job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="CancelAsync(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fineTuningJobId"> The ID of the fine-tuning job to cancel. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fineTuningJobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fineTuningJobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual async Task<Result> CancelAsync(string fineTuningJobId, RequestOptions context)
        {
            ClientUtilities.AssertNotNullOrEmpty(fineTuningJobId, nameof(fineTuningJobId));

            using var scope = ClientDiagnostics.CreateSpan("FineTuningJobs.Cancel");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateCancelRequest(fineTuningJobId, context);
                return Result.FromResponse(await _pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// [Protocol Method] Immediately cancel a fine-tune job.
        /// <list type="bullet">
        /// <item>
        /// <description>
        /// This <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/ProtocolMethods.md">protocol method</see> allows explicit creation of the request and processing of the response for advanced scenarios.
        /// </description>
        /// </item>
        /// <item>
        /// <description>
        /// Please try the simpler <see cref="Cancel(string,CancellationToken)"/> convenience overload with strongly typed models first.
        /// </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="fineTuningJobId"> The ID of the fine-tuning job to cancel. </param>
        /// <param name="context"> The request context, which can override default behaviors of the client pipeline on a per-call basis. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="fineTuningJobId"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="fineTuningJobId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="MessageFailedException"> Service returned a non-success status code. </exception>
        /// <returns> The response returned from the service. </returns>
        public virtual Result Cancel(string fineTuningJobId, RequestOptions context)
        {
            ClientUtilities.AssertNotNullOrEmpty(fineTuningJobId, nameof(fineTuningJobId));

            using var scope = ClientDiagnostics.CreateSpan("FineTuningJobs.Cancel");
            scope.Start();
            try
            {
                using PipelineMessage message = CreateCancelRequest(fineTuningJobId, context);
                return Result.FromResponse(_pipeline.ProcessMessage(message, context));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        internal PipelineMessage CreateCreateRequest(RequestBody content, RequestOptions context)
        {
            var message = _pipeline.CreateMessage(context, ResponseErrorClassifier200);
            var request = message.Request;
            request.SetMethod("POST");
            var uri = new RequestUri();
            uri.Reset(_endpoint);
            uri.AppendPath("/fine_tuning/jobs", false);
            request.Uri = uri.ToUri();
            request.SetHeaderValue("Accept", "application/json");
            request.SetHeaderValue("Content-Type", "application/json");
            request.Content = content;
            return message;
        }

        internal PipelineMessage CreateGetPaginatedsRequest(string after, long? limit, RequestOptions context)
        {
            var message = _pipeline.CreateMessage(context, ResponseErrorClassifier200);
            var request = message.Request;
            request.SetMethod("GET");
            var uri = new RequestUri();
            uri.Reset(_endpoint);
            uri.AppendPath("/fine_tuning/jobs", false);
            if (after != null)
            {
                uri.AppendQuery("after", after, true);
            }
            if (limit != null)
            {
                uri.AppendQuery("limit", limit.Value, true);
            }
            request.Uri = uri.ToUri();
            request.SetHeaderValue("Accept", "application/json");
            return message;
        }

        internal PipelineMessage CreateRetrieveRequest(string fineTuningJobId, RequestOptions context)
        {
            var message = _pipeline.CreateMessage(context, ResponseErrorClassifier200);
            var request = message.Request;
            request.SetMethod("GET");
            var uri = new RequestUri();
            uri.Reset(_endpoint);
            uri.AppendPath("/fine_tuning/jobs/", false);
            uri.AppendPath(fineTuningJobId, true);
            request.Uri = uri.ToUri();
            request.SetHeaderValue("Accept", "application/json");
            return message;
        }

        internal PipelineMessage CreateGetEventsRequest(string fineTuningJobId, string after, int? limit, RequestOptions context)
        {
            var message = _pipeline.CreateMessage(context, ResponseErrorClassifier200);
            var request = message.Request;
            request.SetMethod("GET");
            var uri = new RequestUri();
            uri.Reset(_endpoint);
            uri.AppendPath("/fine_tuning/jobs/", false);
            uri.AppendPath(fineTuningJobId, true);
            uri.AppendPath("/events", false);
            if (after != null)
            {
                uri.AppendQuery("after", after, true);
            }
            if (limit != null)
            {
                uri.AppendQuery("limit", limit.Value, true);
            }
            request.Uri = uri.ToUri();
            request.SetHeaderValue("Accept", "application/json");
            return message;
        }

        internal PipelineMessage CreateCancelRequest(string fineTuningJobId, RequestOptions context)
        {
            var message = _pipeline.CreateMessage(context, ResponseErrorClassifier200);
            var request = message.Request;
            request.SetMethod("POST");
            var uri = new RequestUri();
            uri.Reset(_endpoint);
            uri.AppendPath("/fine_tuning/jobs/", false);
            uri.AppendPath(fineTuningJobId, true);
            uri.AppendPath("/cancel", false);
            request.Uri = uri.ToUri();
            request.SetHeaderValue("Accept", "application/json");
            return message;
        }

        private static RequestOptions DefaultRequestContext = new RequestOptions();
        internal static RequestOptions FromCancellationToken(CancellationToken cancellationToken = default)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                return DefaultRequestContext;
            }

            return new RequestOptions() { CancellationToken = cancellationToken };
        }

        private static ResponseErrorClassifier _responseErrorClassifier200;
        private static ResponseErrorClassifier ResponseErrorClassifier200 => _responseErrorClassifier200 ??= new StatusResponseClassifier(stackalloc ushort[] { 200 });
    }
}
