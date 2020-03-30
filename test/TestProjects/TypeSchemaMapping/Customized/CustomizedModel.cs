using System.Text.Json;
using Azure.Core;
using NamespaceForEnums;

namespace CustomNamespace
{
    [CodeGenModel("Model")]
    [CodeGenSuppress("CustomizedModel", typeof(CustomFruitEnum), typeof(CustomDaysOfWeek))]
    internal partial class CustomizedModel: BaseClassForCustomizedModel
    {
        /// <summary> Day of week. </summary>
        public CustomDaysOfWeek DaysOfWeek { get; }

        [CodeGenMember("ModelProperty")]
        internal int? PropertyRenamedAndTypeChanged { get; set; }

        internal static CustomizedModel DeserializeCustomizedModel(JsonElement element)
        {
            int? propertyRenamedAndTypeChanged = default;
            CustomFruitEnum fruit = default;
            CustomDaysOfWeek daysOfWeek = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("ModelProperty"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    propertyRenamedAndTypeChanged = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("Fruit"))
                {
                    fruit = property.Value.GetString().ToCustomFruitEnum();
                    continue;
                }
                if (property.NameEquals("DaysOfWeek"))
                {
                    daysOfWeek = new CustomDaysOfWeek(property.Value.GetString());
                    continue;
                }
            }
            return new CustomizedModel(propertyRenamedAndTypeChanged, fruit, daysOfWeek);
        }
    }
}
