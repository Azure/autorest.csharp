// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace CognitiveSearch.Models
{
    /// <summary> A skill that can call a Web API endpoint, allowing you to extend a skillset by having it call your custom code. </summary>
    public partial class WebApiSkill : Skill
    {
        /// <summary> Initializes a new instance of WebApiSkill. </summary>
        public WebApiSkill()
        {
            OdataType = "#Microsoft.Skills.Custom.WebApiSkill";
        }
        /// <summary> The url for the Web API. </summary>
        public string Uri { get; set; }
        /// <summary> The headers required to make the http request. </summary>
        public IDictionary<string, string> HttpHeaders { get; set; }
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
