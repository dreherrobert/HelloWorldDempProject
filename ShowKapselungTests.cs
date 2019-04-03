
using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelloWorldDempProject;

namespace UnitTest2
{
    [TestClass]
    public class ShowKapselungTests
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
