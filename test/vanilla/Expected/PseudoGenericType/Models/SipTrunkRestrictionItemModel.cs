// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Zapappi.Client.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class SipTrunkRestrictionItemModel
    {
        /// <summary>
        /// Initializes a new instance of the SipTrunkRestrictionItemModel
        /// class.
        /// </summary>
        public SipTrunkRestrictionItemModel()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the SipTrunkRestrictionItemModel
        /// class.
        /// </summary>
        public SipTrunkRestrictionItemModel(int? id = default(int?), bool? blacklist = default(bool?), string prefix = default(string), string description = default(string))
        {
            Id = id;
            Blacklist = blacklist;
            Prefix = prefix;
            Description = description;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Id")]
        public int? Id { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Blacklist")]
        public bool? Blacklist { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Prefix")]
        public string Prefix { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Description")]
        public string Description { get; set; }

    }
}
