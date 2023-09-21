using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoRest.CSharp.Mgmt.Report
{
    internal class TransformerItem : IEquatable<TransformerItem?>
    {
        public string Type { get; set; }
        public string Target { get; set; }
        public string Argument { get; set; }

        public TransformerItem(string type, string target, string argument)
        {
            Type = type;
            Target = target;
            Argument = argument;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TransformerItem);
        }

        public bool Equals(TransformerItem? other)
        {
            return other is not null &&
                   Type == other.Type &&
                   Target == other.Target &&
                   Argument == other.Argument;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Type, Target, Argument);
        }

        public static bool operator ==(TransformerItem? left, TransformerItem? right)
        {
            return EqualityComparer<TransformerItem>.Default.Equals(left, right);
        }

        public static bool operator !=(TransformerItem? left, TransformerItem? right)
        {
            return !(left == right);
        }
    }
}
