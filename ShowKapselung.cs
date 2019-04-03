using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldDempProject
{
    class ShowKapselung
    {
        public void TestA()
        {

        }

        private void TestB()
        {

        }
        internal void TestC()
        {

        }

        
    }

    public class Child : Parent
    {
        readonly private Parent _parent = new Parent();


        public Child()
        {
            ParentMethodA();
            //ParentMethodC();
        }

        //public override void ParentMethodC()
        //{
        //    throw new NotImplementedException();
        //}
    }

    public class Parent
    {
        protected void ParentMethodA() { }

        private void ParentMethodB() { }

        //public abstract void ParentMethodC();
        
        virtual public void ParentMethodD()
        {


        }
    }
}
