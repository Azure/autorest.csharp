// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Zapappi.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class UpdateSIPTrunkModel
    {
        /// <summary>
        /// Initializes a new instance of the UpdateSIPTrunkModel class.
        /// </summary>
        public UpdateSIPTrunkModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the UpdateSIPTrunkModel class.
        /// </summary>
        public UpdateSIPTrunkModel(string endpointId = default(string), string description = default(string), string forceClid = default(string), int? globalChannelCap = default(int?), int? inboundChannelCap = default(int?), string notifcationsEmails = default(string), int? outboundChannelCap = default(int?), bool? useBlacklist = default(bool?), bool? useWhitelist = default(bool?), string accountCode = default(string), bool? enabled = default(bool?))
        {
            EndpointId = endpointId;
            Description = description;
            ForceClid = forceClid;
            GlobalChannelCap = globalChannelCap;
            InboundChannelCap = inboundChannelCap;
            NotifcationsEmails = notifcationsEmails;
            OutboundChannelCap = outboundChannelCap;
            UseBlacklist = useBlacklist;
            UseWhitelist = useWhitelist;
            AccountCode = accountCode;
            Enabled = enabled;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "EndpointId")]
        public string EndpointId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ForceClid")]
        public string ForceClid { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "GlobalChannelCap")]
        public int? GlobalChannelCap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "InboundChannelCap")]
        public int? InboundChannelCap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "NotifcationsEmails")]
        public string NotifcationsEmails { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "OutboundChannelCap")]
        public int? OutboundChannelCap { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UseBlacklist")]
        public bool? UseBlacklist { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "UseWhitelist")]
        public bool? UseWhitelist { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AccountCode")]
        public string AccountCode { get; private set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Enabled")]
        public bool? Enabled { get; private set; }

    }
}
