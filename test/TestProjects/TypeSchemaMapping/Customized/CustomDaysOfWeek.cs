using System.ComponentModel;
using Azure.Core;

namespace NamespaceForEnums
{
    [CodeGenSchema("DaysOfWeek")]
    internal partial struct CustomDaysOfWeek
    {
        [CodeGenSchemaMember("Monday")]
        public static CustomDaysOfWeek FancyMonday { get; } = new CustomDaysOfWeek(FancyMondayValue);
        [CodeGenSchemaMember("Tuesday")]
        public static CustomDaysOfWeek FancyTuesday { get; } = new CustomDaysOfWeek(FancyTuesdayValue);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}