namespace Fixtures.AcceptanceTestsExtensibleEnums.Models
{
    public struct MonthOfYearExtensibleEnums: System.IEquatable<MonthOfYearExtensibleEnums>
    {
        public MonthOfYearExtensibleEnums(string value)
        {
            Value = value;
        }

        public static implicit operator MonthOfYearExtensibleEnums(string value) => new MonthOfYearExtensibleEnums(value);

        private static MonthOfYearExtensibleEnums GetBaseTypeForAllowedType(MonthOfYearExtensibleEnums other)
        {
            return new MonthOfYearExtensibleEnums();
        }        

        public static bool operator ==(MonthOfYearExtensibleEnums m1, MonthOfYearExtensibleEnums m2) => m2.Equals(m1);

        public static bool operator !=(MonthOfYearExtensibleEnums m1, MonthOfYearExtensibleEnums m2) => !m2.Equals(m1);

        public bool Equals(MonthOfYearExtensibleEnums m) => ( GetBaseTypeForAllowedType(m.Value)!=null || Value.Equals(m.Value));

        public override int GetHashCode()
        {
            var baseType = GetBaseTypeForAllowedType(this);
            if(baseType!=null)
            {
                return baseType.Value.GetHashCode();
            }
            return Value.GetHashCode();
        }

        public string Value {get; private set;}

        private static MonthOfYearExtensibleEnums? GetBaseTypeForAllowedType(string value)
        {
            switch(value)
            {
                case "Jan": return new MonthOfYearExtensibleEnums("January");
                case "Feb": return new MonthOfYearExtensibleEnums("February");
                case "Mar": return new MonthOfYearExtensibleEnums("March");
                case "Apr": return new MonthOfYearExtensibleEnums("April");
                case "Jun": return new MonthOfYearExtensibleEnums("June");
                case "Jul": return new MonthOfYearExtensibleEnums("July");
                case "Aug": return new MonthOfYearExtensibleEnums("August");
                case "Sep": return new MonthOfYearExtensibleEnums("September");
                case "Sept": return new MonthOfYearExtensibleEnums("September");
                case "Oct": return new MonthOfYearExtensibleEnums("October");
                case "Nov": return new MonthOfYearExtensibleEnums("November");
                case "Dec": return new MonthOfYearExtensibleEnums("December");
                default: return null;
            }
        }


    }

}