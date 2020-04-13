using System.Collections.Generic;
using Azure.Core;

namespace SerializationCustomization.Models
{
    public partial class EmptyAsUndefinedTestModel
    {
        [CodeGenMember(EmptyAsUndefined = true)]
        public IList<Item> EmptyAsUndefinedList { get; set; }
    }
}