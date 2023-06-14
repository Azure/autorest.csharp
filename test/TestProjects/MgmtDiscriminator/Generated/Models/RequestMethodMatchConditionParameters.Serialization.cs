// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace MgmtDiscriminator.Models
{
    public partial class RequestMethodMatchConditionParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("typeName"u8);
            writer.WriteStringValue(TypeName.ToString());
            writer.WritePropertyName("operator"u8);
            writer.WriteStringValue(Operator.ToString());
            if (Optional.IsDefined(NegateCondition))
            {
                writer.WritePropertyName("negateCondition"u8);
                writer.WriteBooleanValue(NegateCondition.Value);
            }
            if (Optional.IsCollectionDefined(Transforms))
            {
                writer.WritePropertyName("transforms"u8);
                writer.WriteStartArray();
                foreach (var item in Transforms)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            if (Optional.IsCollectionDefined(MatchValues))
            {
                writer.WritePropertyName("matchValues"u8);
                writer.WriteStartArray();
                foreach (var item in MatchValues)
                {
                    writer.WriteStringValue(item.ToString());
                }
                writer.WriteEndArray();
            }
            writer.WriteEndObject();
        }

        internal static RequestMethodMatchConditionParameters DeserializeRequestMethodMatchConditionParameters(JsonElement element)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            RequestMethodMatchConditionParametersTypeName typeName = default;
            RequestMethodOperator @operator = default;
            Optional<bool> negateCondition = default;
            Optional<IList<Transform>> transforms = default;
            Optional<IList<RequestMethodMatchConditionParametersMatchValuesItem>> matchValues = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("typeName"u8))
                {
                    typeName = new RequestMethodMatchConditionParametersTypeName(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("operator"u8))
                {
                    @operator = new RequestMethodOperator(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("negateCondition"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    negateCondition = property.Value.GetBoolean();
                    continue;
                }
                if (property.NameEquals("transforms"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<Transform> array = new List<Transform>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new Transform(item.GetString()));
                    }
                    transforms = array;
                    continue;
                }
                if (property.NameEquals("matchValues"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<RequestMethodMatchConditionParametersMatchValuesItem> array = new List<RequestMethodMatchConditionParametersMatchValuesItem>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(new RequestMethodMatchConditionParametersMatchValuesItem(item.GetString()));
                    }
                    matchValues = array;
                    continue;
                }
            }
            return new RequestMethodMatchConditionParameters(typeName, @operator, Optional.ToNullable(negateCondition), Optional.ToList(transforms), Optional.ToList(matchValues));
        }
    }
}
