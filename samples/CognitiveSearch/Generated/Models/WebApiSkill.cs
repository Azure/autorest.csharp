// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace CognitiveSearch.Models
{
    /// <summary> A skill that can call a Web API endpoint, allowing you to extend a skillset by having it call your custom code. </summary>
    public partial class WebApiSkill : Skill
    {
        /// <summary> Initializes a new instance of WebApiSkill. </summary>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <param name="uri"> The url for the Web API. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="inputs"/>, <paramref name="outputs"/> or <paramref name="uri"/> is null. </exception>
        public WebApiSkill(IEnumerable<InputFieldMappingEntry> inputs, IEnumerable<OutputFieldMappingEntry> outputs, string uri) : base(inputs, outputs)
        {
            Argument.AssertNotNull(inputs, nameof(inputs));
            Argument.AssertNotNull(outputs, nameof(outputs));
            Argument.AssertNotNull(uri, nameof(uri));

            Uri = uri;
            HttpHeaders = new ChangeTrackingDictionary<string, string>();
            OdataType = "#Microsoft.Skills.Custom.WebApiSkill";
        }

        /// <summary> Initializes a new instance of WebApiSkill. </summary>
        /// <param name="odataType"> Identifies the concrete type of the skill. </param>
        /// <param name="name"> The name of the skill which uniquely identifies it within the skillset. A skill with no name defined will be given a default name of its 1-based index in the skills array, prefixed with the character '#'. </param>
        /// <param name="description"> The description of the skill which describes the inputs, outputs, and usage of the skill. </param>
        /// <param name="context"> Represents the level at which operations take place, such as the document root or document content (for example, /document or /document/content). The default is /document. </param>
        /// <param name="inputs"> Inputs of the skills could be a column in the source data set, or the output of an upstream skill. </param>
        /// <param name="outputs"> The output of a skill is either a field in a search index, or a value that can be consumed as an input by another skill. </param>
        /// <param name="uri"> The url for the Web API. </param>
        /// <param name="httpHeaders"> The headers required to make the http request. </param>
        /// <param name="httpMethod"> The method for the http request. </param>
        /// <param name="timeout"> The desired timeout for the request. Default is 30 seconds. </param>
        /// <param name="batchSize"> The desired batch size which indicates number of documents. </param>
        /// <param name="degreeOfParallelism"> If set, the number of parallel calls that can be made to the Web API. </param>
        internal WebApiSkill(string odataType, string name, string description, string context, IList<InputFieldMappingEntry> inputs, IList<OutputFieldMappingEntry> outputs, string uri, IDictionary<string, string> httpHeaders, string httpMethod, TimeSpan? timeout, int? batchSize, int? degreeOfParallelism) : base(odataType, name, description, context, inputs, outputs)
        {
            Uri = uri;
            HttpHeaders = httpHeaders;
            HttpMethod = httpMethod;
            Timeout = timeout;
            BatchSize = batchSize;
            DegreeOfParallelism = degreeOfParallelism;
            OdataType = odataType ?? "#Microsoft.Skills.Custom.WebApiSkill";
        }

        /// <summary> The url for the Web API. </summary>
        public string Uri { get; set; }
        /// <summary> The headers required to make the http request. </summary>
        public IDictionary<string, string> HttpHeaders { get; }
        /// <summary> The method for the http request. </summary>
        public string HttpMethod { get; set; }
        /// <summary> The desired timeout for the request. Default is 30 seconds. </summary>
        public TimeSpan? Timeout { get; set; }
        /// <summary> The desired batch size which indicates number of documents. </summary>
        public int? BatchSize { get; set; }
        /// <summary> If set, the number of parallel calls that can be made to the Web API. </summary>
        public int? DegreeOfParallelism { get; set; }
    }
}
