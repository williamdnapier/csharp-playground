using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace _007_CloneableClasses
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    //Problem
    //You need to create a method of performing shallow cloning operations,
    //a deep cloning operation, or both on a data type that may also reference
    //other types, but ICloneable interface should not be used as it violates
    //the .NET Framework Design Guidelines.

    //Solution
    //To resolve the issue, you create two other interfaces to establish
    //a copying pattern, IShallowCopy<T> and IDeepCopy<T>:

    public interface IShallowCopy<T>
    {
        T ShallowCopy();
    }

    public interface IDeepCopy<T>
    {
        T DeepCopy();
    }

    //Shallow copying means that the copied object's fields will reference
    //the same objects as the original object. To allow shallow copying,
    //implement the IShallowCopy<T> interface in the class.

    public class ShallowClone : IShallowCopy<ShallowClone>
    {
        public int Data = 1;
        public List<string> ListData = new List<string>();
        public object ObjData = new object();

        public ShallowClone ShallowCopy() => (ShallowClone)this.MemberwiseClone();
    }

    //Deep copying or cloning means that the copied object's fields will reference
    //new copies of the original object's fields. To allow deep copying, implement
    //the IDeepCopy<T> interface in the class.

    [Serializable]
    public class DeepClone : IDeepCopy<DeepClone>
    {
        public int data = 1;
        public List<string> ListData = new List<string>();
        public object objData = new object();

        public DeepClone DeepCopy()
        {
            BinaryFormatter BF = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            BF.Serialize(memStream, this);
            memStream.Flush();
            memStream.Position = 0;

            return (DeepClone)BF.Deserialize(memStream);

        }
    }

    //To support both types of copying, you need to implement both interfaces.
    //Here is an example.

    [Serializable]
    public class MultiClone : IShallowCopy<MultiClone>, IDeepCopy<MultiClone>
    {
        public int data = 1;
        public List<string> ListData = new List<string>();
        public object objData = new object();

        public MultiClone ShallowCopy() => (MultiClone)this.MemberwiseClone();

        public MultiClone DeepCopy()
        {
            BinaryFormatter BF = new BinaryFormatter();
            MemoryStream memStream = new MemoryStream();

            BF.Serialize(memStream, this);
            memStream.Flush();
            memStream.Position = 0;

            return (MultiClone)BF.Deserialize(memStream);
        }
    }

    //Discussion
    //The .NET Framework has an interface called ICloneable which was
    //originally designed as the means through which cloning was to be
    //implemented in .NET. The design recommendation is now not to use that
    //interface.
    /*
     public interface ICloneable
     {
        object Clone();
     }
     */
     //There is only a single method, Clone, which returns an object.
     //But, it is not known whether or not it returns a shallow clone or
     //a deep clone.
}
