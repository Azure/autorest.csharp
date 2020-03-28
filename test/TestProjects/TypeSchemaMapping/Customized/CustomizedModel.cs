using System.Text.Json;
using Azure.Core;
using NamespaceForEnums;

namespace CustomNamespace
{
    [CodeGenSchema("Model")]
    [CodeGenSuppress("CustomizedModel(CustomFruitEnum, CustomDaysOfWeek)")]
    internal partial class CustomizedModel: BaseClassForCustomizedModel
    {
        /// <summary> Initializes a new instance of CustomizedModel. </summary>
        /// <param name="customizedStringProperty"> A description about the set of tags. </param>
        /// <param name="customizedFancyField"> Fruit. </param>
        /// <param name="daysOfWeek"> Day of week. </param>
        internal CustomizedModel(string customizedStringProperty, CustomFruitEnum customizedFancyField, CustomDaysOfWeek daysOfWeek)
        {
            CustomizedStringProperty = customizedStringProperty;
            CustomizedFancyField = customizedFancyField;
            DaysOfWeek = daysOfWeek;
        }

        /// <summary> Day of week. </summary>
        public CustomDaysOfWeek DaysOfWeek { get; }

        [CodeGenSchemaMember("ModelProperty")]
        internal string CustomizedStringProperty { get; }

        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (CustomizedStringProperty != null)
            {
                writer.WritePropertyName("ModelProperty");
                writer.WriteStringValue(CustomizedStringProperty);
            }
            writer.WritePropertyName("Fruit");
            writer.WriteStringValue(CustomizedFancyField.ToSerialString());
            writer.WritePropertyName("DaysOfWeek");
            writer.WriteStringValue(DaysOfWeek.ToString());
            writer.WriteEndObject();
        }

        internal static CustomizedModel DeserializeCustomizedModel(JsonElement element)
        {
            string modelProperty = default;
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
                    modelProperty = property.Value.GetString();
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
            return new CustomizedModel(modelProperty, fruit, daysOfWeek);
        }
    }
}
