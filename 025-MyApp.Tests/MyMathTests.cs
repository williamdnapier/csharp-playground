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
            object o1 = myMath.Abacus;
            object o2 = myMath.AncientCalculator;

            //Assert
            Assert.AreSame(o1, o2);
        }

        //Test Naming Conventions

        //[UnitOfWork_StateUnderTest_ExpectedBehavior]

        //UnitOfWork == method name
        //StateUnderTest == something like invalid password or good email
        //ExpectedBehavior == value or result or system state change
      
        //Public void Sum_NegativeNumberAs1stParam_ExceptionThrown()
        //Public void Sum_NegativeNumberAs2ndParam_ExceptionThrown ()
        //Public void Sum_simpleValues_Calculated ()

        [Test]
        public void ZeroEqualsOne_MathIsNotReal_False()
        {
            //Arrange
            MyMath myMath = new MyMath();

            //Act

            //Assert
            Assert.IsFalse(myMath.ZeroEqualsOne());
        }

        [Test]
        public void ZeroEqualsZero_MathIsReal_True()
        {
            //Arrange
            MyMath myMath = new MyMath();

            //Act

            //Assert
            Assert.IsTrue(myMath.ZeroEqualsZero());
        }

        [Test]
        public void GetStudentsBrain_NoBrainExists_IsNull()
        {
            //Arrange
            MyMath myMath = new MyMath();

            //Act
            object studentBrain = null;

            //Assert
            Assert.IsNull(myMath.GetStudentsBrain(studentBrain));
        }

        [Test]
        public void GetTeachersBrain_BrainExists_IsNotNull()
        {
            //Arrange
            MyMath myMath = new MyMath();

            //Act
            object teacherBrain = new object();

            //Assert
            Assert.IsNotNull(myMath.GetTeachersBrain(teacherBrain));
        }
    }

    public class CustomAssert
    {
        public static void AssertOdd(int i)
        {
            int[] a = { i };
            AssertOdd(a);
        }

        public static void AssertOdd(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Assert.IsFalse(a[i] % 2 == 0);
            }
        }
    }

    [TestFixture]
    public class CustomAssertTests
    {
        [Test]
        public void Test1()
        {
            CustomAssert.AssertOdd(1);
            int[] a = { 1, 3, 5 };
            CustomAssert.AssertOdd(a);
        }
    }
}
