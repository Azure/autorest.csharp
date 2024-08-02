// <auto-generated/>

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Threading;

namespace OpenAI
{
    // Data plane generated sub-client.
    /// <summary> The FineTuning sub-client. </summary>
    public partial class FineTuning
    {
        private const string AuthorizationHeader = "Authorization";
        private readonly ApiKeyCredential _keyCredential;
        private const string AuthorizationApiKeyPrefix = "Bearer";
        private readonly ClientPipeline _pipeline;
        private readonly Uri _endpoint;

        /// <summary> The HTTP pipeline for sending and receiving REST requests and responses. </summary>
        public virtual ClientPipeline Pipeline => _pipeline;

        /// <summary> Initializes a new instance of FineTuning for mocking. </summary>
        protected FineTuning()
        {
        }

        /// <summary> Initializes a new instance of FineTuning. </summary>
        /// <param name="pipeline"> The HTTP pipeline for sending and receiving REST requests and responses. </param>
        /// <param name="keyCredential"> The key credential to copy. </param>
        /// <param name="endpoint"> The <see cref="string"/> to use. </param>
        internal FineTuning(ClientPipeline pipeline, ApiKeyCredential keyCredential, Uri endpoint)
        {
            _pipeline = pipeline;
            _keyCredential = keyCredential;
            _endpoint = endpoint;
        }

        private FineTuningJobs _cachedFineTuningJobs;

        /// <summary> Initializes a new instance of FineTuningJobs. </summary>
        public virtual FineTuningJobs GetFineTuningJobsClient()
        {
            return Volatile.Read(ref _cachedFineTuningJobs) ?? Interlocked.CompareExchange(ref _cachedFineTuningJobs, new FineTuningJobs(_pipeline, _keyCredential, _endpoint), null) ?? _cachedFineTuningJobs;
        }
    }
}
