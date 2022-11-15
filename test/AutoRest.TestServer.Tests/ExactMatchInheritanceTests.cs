using System;
using Azure.Core.Expressions.DataFactory;
using ExactMatchInheritance;
using NUnit.Framework;

namespace AutoRest.TestServer.Tests
{
    public class ExactMatchInheritanceTests
    {
        [Test]
        public void DataFactoryExpressionProperties()
        {
            Assert.AreEqual(typeof(DataFactoryExpression<string>), typeof(ExactMatchModel1Data).GetProperty("Type5").PropertyType);
            Assert.AreEqual(typeof(DataFactoryExpression<double>), typeof(ExactMatchModel1Data).GetProperty("Type6").PropertyType);
            Assert.AreEqual(typeof(DataFactoryExpression<bool>), typeof(ExactMatchModel1Data).GetProperty("Type7").PropertyType);
            Assert.AreEqual(typeof(DataFactoryExpression<int>), typeof(ExactMatchModel1Data).GetProperty("Type8").PropertyType);
            Assert.AreEqual(typeof(DataFactoryExpression<Array>), typeof(ExactMatchModel1Data).GetProperty("Type9").PropertyType);
        }
    }
}
