// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Zapappi.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class CalloutReturnModel
    {
        /// <summary>
        /// Initializes a new instance of the CalloutReturnModel class.
        /// </summary>
        public CalloutReturnModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the CalloutReturnModel class.
        /// </summary>
        public CalloutReturnModel(string messageId = default(string), bool? isAccepted = default(bool?), string reason = default(string))
        {
            MessageId = messageId;
            IsAccepted = isAccepted;
            Reason = reason;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "MessageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "IsAccepted")]
        public bool? IsAccepted { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Reason")]
        public string Reason { get; set; }

    }
}
