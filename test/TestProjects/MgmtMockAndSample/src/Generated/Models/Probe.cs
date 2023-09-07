// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;

namespace MgmtMockAndSample.Models
{
    /// <summary> Probe describes a health check to be performed against an App Instance to determine whether it is alive or ready to receive traffic. </summary>
    public partial class Probe
    {
        /// <summary> Keeps track of any properties unknown to the library. </summary>
        private Dictionary<string, BinaryData> _serializedAdditionalRawData;

        /// <summary> Initializes a new instance of <see cref="Probe"/>. </summary>
        /// <param name="disableProbe"> Indicate whether the probe is disabled. </param>
        public Probe(bool disableProbe)
        {
            DisableProbe = disableProbe;
        }

        /// <summary> Initializes a new instance of <see cref="Probe"/>. </summary>
        /// <param name="disableProbe"> Indicate whether the probe is disabled. </param>
        /// <param name="initialDelaySeconds"> Number of seconds after the App Instance has started before probes are initiated. More info: https://kubernetes.io/docs/concepts/workloads/pods/pod-lifecycle#container-probes. </param>
        /// <param name="periodSeconds"> How often (in seconds) to perform the probe. Minimum value is 1. </param>
        /// <param name="timeoutSeconds"> Number of seconds after which the probe times out. Minimum value is 1. </param>
        /// <param name="failureThreshold"> Minimum consecutive failures for the probe to be considered failed after having succeeded. Minimum value is 1. </param>
        /// <param name="successThreshold"> Minimum consecutive successes for the probe to be considered successful after having failed. Must be 1 for liveness and startup. Minimum value is 1. </param>
        /// <param name="serializedAdditionalRawData"> Keeps track of any properties unknown to the library. </param>
        internal Probe(bool disableProbe, int? initialDelaySeconds, int? periodSeconds, int? timeoutSeconds, int? failureThreshold, int? successThreshold, Dictionary<string, BinaryData> serializedAdditionalRawData)
        {
            DisableProbe = disableProbe;
            InitialDelaySeconds = initialDelaySeconds;
            PeriodSeconds = periodSeconds;
            TimeoutSeconds = timeoutSeconds;
            FailureThreshold = failureThreshold;
            SuccessThreshold = successThreshold;
            _serializedAdditionalRawData = serializedAdditionalRawData;
        }

        /// <summary> Initializes a new instance of <see cref="Probe"/> for deserialization. </summary>
        internal Probe()
        {
        }

        /// <summary> Indicate whether the probe is disabled. </summary>
        public bool DisableProbe { get; set; }
        /// <summary> Number of seconds after the App Instance has started before probes are initiated. More info: https://kubernetes.io/docs/concepts/workloads/pods/pod-lifecycle#container-probes. </summary>
        public int? InitialDelaySeconds { get; set; }
        /// <summary> How often (in seconds) to perform the probe. Minimum value is 1. </summary>
        public int? PeriodSeconds { get; set; }
        /// <summary> Number of seconds after which the probe times out. Minimum value is 1. </summary>
        public int? TimeoutSeconds { get; set; }
        /// <summary> Minimum consecutive failures for the probe to be considered failed after having succeeded. Minimum value is 1. </summary>
        public int? FailureThreshold { get; set; }
        /// <summary> Minimum consecutive successes for the probe to be considered successful after having failed. Must be 1 for liveness and startup. Minimum value is 1. </summary>
        public int? SuccessThreshold { get; set; }
    }
}
