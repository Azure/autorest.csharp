using System;
using NUnit.Framework;

namespace CadlRanchProjects.Tests
{
    public static class BinaryDataAssert
    {
        public static void AreEqual(BinaryData expected, BinaryData result)
        {
            CollectionAssert.AreEqual(expected?.ToArray(), result?.ToArray());
        }
    }
}
