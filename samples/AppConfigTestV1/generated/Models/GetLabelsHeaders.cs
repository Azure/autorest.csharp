// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Appconfiguration.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Defines headers for GetLabels operation.
    /// </summary>
    public partial class GetLabelsHeaders
    {
        /// <summary>
        /// Initializes a new instance of the GetLabelsHeaders class.
        /// </summary>
        public GetLabelsHeaders()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the GetLabelsHeaders class.
        /// </summary>
        /// <param name="syncToken">Enables real-time consistency between
        /// requests by providing the returned value in the next request made
        /// to the server.</param>
        public GetLabelsHeaders(string syncToken = default(string))
        {
            SyncToken = syncToken;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets enables real-time consistency between requests by
        /// providing the returned value in the next request made to the
        /// server.
        /// </summary>
        [JsonProperty(PropertyName = "Sync-Token")]
        public string SyncToken { get; set; }

    }
}
