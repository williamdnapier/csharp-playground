using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace _025_MyApp.Tests
{
    [TestFixture]
    public class MyMathTests
    {
        [Test]
        public void MyAddTest()
        {
            //Arrange
            MyMath myMath = new MyMath();

            //Act

            //Assert
            Assert.AreEqual(myMath.Add(2, 3), 5);
        }

        [Test]
        public void MyObjTest()
        {
            //Arrange
            MyMath myMath = new MyMath();

            //Act
            object o1 = myMath.Obj;
            object o2 = myMath.Obj2;

            //Assert
            Assert.AreSame(o1, o2);
        }

        //[Test]
        //public void MyFailedTest()
        //{
        //    //Arrange
        //    MyMath myMath = new MyMath();

        //    //Act

        //    //Assert
        //    Assert.Fail("This test is intentionally failing!");
        //}
    }
}
