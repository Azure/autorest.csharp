using Azure.Core;

namespace NamespaceForEnums
{
    [CodeGenModel("DaysOfWeek")]
    internal partial struct CustomDaysOfWeek
    {
        [CodeGenMember("Monday")]
        public static CustomDaysOfWeek FancyMonday { get; } = new CustomDaysOfWeek(FancyMondayValue);
        [CodeGenMember("Tuesday")]
        public static CustomDaysOfWeek FancyTuesday { get; } = new CustomDaysOfWeek(FancyTuesdayValue);

    }
}