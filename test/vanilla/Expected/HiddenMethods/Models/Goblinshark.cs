// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Fixtures.HiddenMethods.Models
{
    using Newtonsoft.Json;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    [Newtonsoft.Json.JsonObject("goblin")]
    public partial class Goblinshark : Shark
    {
        /// <summary>
        /// Initializes a new instance of the Goblinshark class.
        /// </summary>
        public Goblinshark()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the Goblinshark class.
        /// </summary>
        public Goblinshark(double length, System.DateTime birthday, string species = default(string), IList<Fish> siblings = default(IList<Fish>), int? age = default(int?), int? jawsize = default(int?))
            : base(length, birthday, species, siblings, age)
        {
            Jawsize = jawsize;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "jawsize")]
        public int? Jawsize { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public override void Validate()
        {
            base.Validate();
        }
    }
}
