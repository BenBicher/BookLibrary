using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using BLL;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetIneerValuByBaseCategory()
        {
            List<InnerCategory> innerVAlues = null;
            var valuByBase = Categories.CateggrisDictionery.TryGetValue(BaseCategory.Cooking, out innerVAlues);

        }
    }
}
