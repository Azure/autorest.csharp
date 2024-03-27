using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Payload.JsonMergePatch.Models;

namespace AutoRest.TestServerLowLevel.Tests
{
    public class JsonMergePatchTests
    {
        [Test]
        public void AccessIsChanged()
        {
            var baseModel = new BaseModelSolution1();
            baseModel.IsChanged();

            var extendedModel = new ExtendedModelSolution1();
            extendedModel.IsChanged();
        }

        [Test]
        public void RefAccess()
        {
            IList<BaseModelSolution1> list = new List<BaseModelSolution1>();
            var item = list.First();
            ref BaseModelSolution1 test = ref item;

        }

        [Test]
        public void DictionaryAccess()
        {
            var baseModel = new BaseModelSolution1();
            // Assume baseDict has a set and set it to null
            baseModel.BaseDict = null;
        }
    }
}
