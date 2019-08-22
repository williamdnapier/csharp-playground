using NUnit.Framework;

namespace UnitTestStubs.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }

    //Discussion
    //Stubs help break dependencies.

    //In the real world, objects under test often rely on another object 
    //which we have no control over. This object could be a web service, the time
    //of day, threading or a lot of other things.

    //The important point is that our code cannot control over what the dependency
    //returns to our code under test or how it behaves. That's why you need to 
    //use stubs.

    //External dependency
    //An object in your system that your code under test interacts with, and over
    //which you have no control. For example, a filesystem, threads, memory, time, etc.

    //Stub
    //A stub is a controllable replacement for an existing dependency (or collaborator)
    //in the system. By using a stub, you can test your code without dealing with the
    //dependency directly.

}