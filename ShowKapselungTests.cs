using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldDempProject
{
    [TestClass]
    class ShowKapselungTests
    {
        [TestMethod]
        public void DemoKapselung()
        {
            var mock = new ShowKapselung();
            mock.TestA();
            mock.TestC();

            var child = new Child();

            child.ParentMethodD();
        }
    }
}
